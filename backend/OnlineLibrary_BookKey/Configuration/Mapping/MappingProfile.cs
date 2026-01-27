using AuthBLL.Services;
using AuthDomain;
using AutoMapper;
using RustProject.Models;
using WebApplication25.Models;
namespace WebApplication25.Configuration.Mapping
{
    public class MappingProfile : Profile
    {
      //  private readonly TokenService _tokenService;

        public MappingProfile() {
           var _tokenService = ServiceLocator.ServiceProviderPublic.GetService<TokenService>();

            CreateMap<RegisterDto, ApplicationUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
             .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName));

        }
    }

    public class TokenServiceProvider
    {
        private readonly IConfiguration _configuration;
        public TokenServiceProvider(IConfiguration configuration) {
            _configuration = configuration;
        }
        public TokenService GetTokenService()
        {
            return new TokenService(_configuration);
        }
    }
}
