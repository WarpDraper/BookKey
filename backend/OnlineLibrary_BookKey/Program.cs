using AuthBLL.EmailService;
using AuthDomain;
using BLL.BookService;
using BLL.BookUser;
using BLL.JwtToken;
using BLL.Services;
using DAL;
using DAL.Context;
using DAL.UnitOfWork;
using Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using OnlineLibrary_BookKey.Configuration.Role;
using OnlineLibrary_BookKey.Middleware;
using System.Reflection.Metadata;
using TaskerDAL;
using TaskerDAL.UnitOfWork;
using WebApplication25.Configuration.Mapping;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. Ï²ÄÊËÞ×ÅÍÍß ÁÀÇÈ, ÊÎÍÒÐÎËÅÐ²Â ÒÀ IDENTITY
// ==========================================
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 3;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedEmail = true;
    options.User.RequireUniqueEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
})
.AddEntityFrameworkStores<ApplicationContext>()
.AddDefaultTokenProviders();

// ==========================================
// 2. ÀÂÒÎÐÈÇÀÖ²ß (JWT + Cookies)
// ==========================================
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWTSettings:Issuer"],
        ValidAudience = builder.Configuration["JWTSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWTSettings:key"]))
    };
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.LoginPath = "/Authorize/login";
});

// ==========================================
// 3. ÂËÀÑÍ² ÑÅÐÂ²ÑÈ
// ==========================================
builder.Services.AddTransient<ITokenService,TokenService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookUserService, BookUserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IRepository<Book>, BookRepository>();
builder.Services.AddAutoMapper(x => x.AddProfile<MappingProfile>());
var emailSet = builder.Configuration.GetSection("EmailSettings").Get<EmailSettings>();
builder.Services.AddSingleton(emailSet);
builder.Services.AddTransient<IEmailService, EmailSender>();

// ==========================================
// 4. SWAGGER (ÍÀËÀØÒÓÂÀÍÍß)
// ==========================================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Íàëàøòóâàííÿ êíîïêè Authorize
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ââåä³òü 'Bearer' [ïðîá³ë] ³ âàø òîêåí.\n\nÏðèêëàä: \"Bearer eyJhbGciOiJIUzI1Ni...\""
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                // ÎÑÜ ÒÓÒ ÁÓËÀ ÏÎÌÈËÊÀ. Òåïåð âñå ïðàâèëüíî:
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

WebApplication25.Configuration.Mapping.ServiceLocator.ServiceProviderPublic = app.Services;


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 
app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await DbInitializer.SeedAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ïîìèëêà ïðè ñòâîðåíí³ ðîëåé");
    }
}
app.MapStaticAssets();
app.UseStaticFiles();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Document}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();