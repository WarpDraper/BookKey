import { useNavigate } from 'react-router-dom';

const NotFound = () => {
  const navigate = useNavigate();

  return (
    <div className="min-h-[70vh] flex flex-col items-center justify-center text-center px-4">

      <div className="relative mb-8">
        <h1 className="text-[12rem] font-black text-slate-100 leading-none select-none">
          404
        </h1>
        <div className="absolute inset-0 flex items-center justify-center">
          <div className="text-6xl animate-bounce">📖</div>
        </div>
      </div>

      <div className="max-w-md space-y-4">
        <h2 className="text-3xl font-bold text-slate-900">Ой! Цей розділ ще не написаний</h2>
        <p className="text-slate-500 text-lg">
          Схоже, ви намагаєтеся прочитати сторінку, якої не існує. Можливо, її викрав книжковий черв'як або ми просто переставили полиці.
        </p>
      </div>

      <div className="mt-10 flex flex-col sm:flex-row gap-4">
        <button 
          onClick={() => navigate('/')}
          className="px-8 py-3 bg-blue-600 text-white rounded-2xl font-bold hover:bg-blue-700 transition-all shadow-lg shadow-blue-200 active:scale-95"
        >
          На головну
        </button>
        
        <button 
          onClick={() => navigate(-1)}
          className="px-8 py-3 bg-white text-slate-700 border border-slate-200 rounded-2xl font-bold hover:bg-slate-50 transition-all active:scale-95"
        >
          Повернутися назад
        </button>
      </div>


      <div className="mt-16 flex gap-2">
        <div className="w-2 h-2 rounded-full bg-slate-200"></div>
        <div className="w-2 h-2 rounded-full bg-slate-300"></div>
        <div className="w-2 h-2 rounded-full bg-slate-200"></div>
      </div>
    </div>
  );
};

export default NotFound;