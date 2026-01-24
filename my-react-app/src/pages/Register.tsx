import { Link } from 'react-router-dom';

const Register = () => {
  return (
    <div className="max-w-md mx-auto mt-12 bg-white p-8 rounded-3xl shadow-sm border border-slate-100">
      <h2 className="text-3xl font-bold text-center mb-8">Створити аккаунт</h2>
      <form className="space-y-5">
        <div>
          <label className="block text-sm font-medium text-slate-700 mb-2">Ім'я</label>
          <input type="text" className="w-full px-4 py-3 rounded-xl border border-slate-200 focus:ring-2 focus:ring-blue-500 outline-none" />
        </div>
        <div>
          <label className="block text-sm font-medium text-slate-700 mb-2">Email</label>
          <input type="email" className="w-full px-4 py-3 rounded-xl border border-slate-200 focus:ring-2 focus:ring-blue-500 outline-none" />
        </div>
        <div>
          <label className="block text-sm font-medium text-slate-700 mb-2">Пароль</label>
          <input type="password" className="w-full px-4 py-3 rounded-xl border border-slate-200 focus:ring-2 focus:ring-blue-500 outline-none" />
        </div>
        <button className="w-full bg-slate-900 text-white py-3 rounded-xl font-bold hover:bg-black transition-all shadow-md mt-2">
          Зареєструватися
        </button>
      </form>
      <p className="text-center mt-6 text-slate-600">
        Вже маєте аккаунт? <Link to="/login" className="text-blue-600 font-semibold hover:underline">Увійти</Link>
      </p>
    </div>
  );
};

export default Register;