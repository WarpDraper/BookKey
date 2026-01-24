import { Link } from 'react-router-dom';

const Login = () => {
  return (
    <div className="max-w-md mx-auto mt-12 bg-white p-8 rounded-3xl shadow-sm border border-slate-100">
      <h2 className="text-3xl font-bold text-center mb-8">З поверненням!</h2>
      <form className="space-y-6">
        <div>
          <label className="block text-sm font-medium text-slate-700 mb-2">Електронна пошта</label>
          <input 
            type="email" 
            placeholder="example@mail.com"
            className="w-full px-4 py-3 rounded-xl border border-slate-200 focus:ring-2 focus:ring-blue-500 outline-none transition-all"
          />
        </div>
        <div>
          <label className="block text-sm font-medium text-slate-700 mb-2">Пароль</label>
          <input 
            type="password" 
            placeholder="••••••••"
            className="w-full px-4 py-3 rounded-xl border border-slate-200 focus:ring-2 focus:ring-blue-500 outline-none transition-all"
          />
        </div>
        <button className="w-full bg-blue-600 text-white py-3 rounded-xl font-bold hover:bg-blue-700 transition-all shadow-md active:scale-95">
          Увійти
        </button>
      </form>
      <p className="text-center mt-6 text-slate-600">
        Немає аккаунту? <Link to="/register" className="text-blue-600 font-semibold hover:underline">Створити</Link>
      </p>
    </div>
  );
};

export default Login;