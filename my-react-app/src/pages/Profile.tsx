import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const Profile = () => {
  const navigate = useNavigate();

  // Імітація перевірки авторизації (в майбутньому тут буде перевірка токена або стейту)
  const isAuthorized = false; // Змініть на true, щоб побачити профіль

  const userData = {
    name: "Юрій Користувач",
    email: "yura.example@gmail.com",
    role: "Читач",
    booksRead: 4,
    avatarLetter: "Ю"
  };

  useEffect(() => {

    if (!isAuthorized) {
      navigate('/login');
    }
  }, [isAuthorized, navigate]);


  if (!isAuthorized) return null;

  return (
    <div className="max-w-4xl mx-auto space-y-8 animate-fadeIn">

      <div className="bg-white p-8 rounded-3xl shadow-sm border border-slate-100 flex flex-col md:flex-row items-center gap-8">
        <div className="w-32 h-32 bg-gradient-to-tr from-blue-600 to-indigo-500 rounded-full flex items-center justify-center text-4xl text-white font-bold border-4 border-white shadow-xl">
          {userData.avatarLetter}
        </div>
        
        <div className="text-center md:text-left flex-grow">
          <h1 className="text-3xl font-bold text-slate-900">{userData.name}</h1>
          <p className="text-slate-500 mb-4">{userData.email}</p>
          <div className="flex flex-wrap gap-2 justify-center md:justify-start">
            <span className="bg-blue-50 text-blue-600 px-4 py-1.5 rounded-full text-xs font-bold uppercase tracking-wider border border-blue-100">
              {userData.role}
            </span>
            <span className="bg-green-50 text-green-600 px-4 py-1.5 rounded-full text-xs font-bold uppercase tracking-wider border border-green-100">
              {userData.booksRead} Книги прочитано
            </span>
          </div>
        </div>

        <div className="flex flex-col gap-2">
          <button className="px-6 py-2.5 bg-slate-900 text-white rounded-xl hover:bg-black transition-all font-medium shadow-sm">
            Редагувати
          </button>
          <button className="px-6 py-2.5 border border-red-100 text-red-500 rounded-xl hover:bg-red-50 transition-all font-medium">
            Вийти
          </button>
        </div>
      </div>


      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        <div className="bg-white p-6 rounded-2xl border border-slate-100 shadow-sm text-center">
          <div className="text-2xl font-bold text-blue-600">12</div>
          <div className="text-sm text-slate-500">В списку бажань</div>
        </div>
        <div className="bg-white p-6 rounded-2xl border border-slate-100 shadow-sm text-center">
          <div className="text-2xl font-bold text-indigo-600">8</div>
          <div className="text-sm text-slate-500">Відгуків залишено</div>
        </div>
        <div className="bg-white p-6 rounded-2xl border border-slate-100 shadow-sm text-center">
          <div className="text-2xl font-bold text-purple-600">2</div>
          <div className="text-sm text-slate-500">Автори улюблених</div>
        </div>
      </div>


      {/* <div className="space-y-6">
        <h2 className="text-2xl font-bold text-slate-800">Останні читання</h2>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
          <div className="bg-white p-5 rounded-2xl border border-slate-100 flex gap-4 items-center hover:border-blue-200 transition-colors group">
            <div className="w-16 h-24 bg-slate-100 rounded-lg overflow-hidden flex-shrink-0 shadow-sm">
               <img src="https://images.booksense.com/images/154/403/9780316438154.jpg" className="w-full h-full object-cover" alt="book" />
            </div>
            <div className="flex-grow">
              <h4 className="font-bold text-slate-900 group-hover:text-blue-600 transition-colors">Відьмак: Останнє бажання</h4>
              <p className="text-sm text-slate-500">Завершено 12.01.2026</p>
              <div className="mt-2 h-1.5 w-full bg-slate-100 rounded-full overflow-hidden">
                <div className="h-full bg-green-500 w-full"></div>
              </div>
            </div>
          </div>
        </div>
      </div> */}
    </div>
  );
};

export default Profile;