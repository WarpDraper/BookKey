
import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import type { RootState } from '../../store';
import { setSearchQuery } from '../../store/searchSlice';

export const Header = () => {
  const dispatch = useDispatch();
  const query = useSelector((state: RootState) => state.search.query);

  return (
    <header className="sticky top-0 z-50 bg-white/80 backdrop-blur-md border-b border-slate-200">
      <div className="container mx-auto px-4 h-16 flex items-center justify-between">

        <div className="text-2xl font-bold bg-gradient-to-r from-blue-600 to-indigo-600 bg-clip-text text-transparent">
          <a href="/">
          BookHub
          </a>
        </div>


        <div className="hidden md:flex flex-1 max-w-md mx-8">
          <input 
            value={query}
            onChange={(e) => dispatch(setSearchQuery(e.target.value))}
            type="text" 
            placeholder="Пошук книг або авторів..." 
            className="w-full px-4 py-2 bg-slate-100 border-none rounded-full text-sm focus:ring-2 focus:ring-blue-500 transition-all"
          />
        </div>


        <nav className="flex items-center gap-6 font-medium text-slate-600">
          {/* <a href="/catalog" className="hover:text-blue-600 transition-colors">Каталог</a> */}
          <a href="/profile" className="hover:text-blue-600 transition-colors">Мій профіль</a>
          <a href="/login">
          <button className="bg-blue-600 text-white px-5 py-2 rounded-full hover:bg-blue-700 transition-all shadow-md active:scale-95">
            Увійти
          </button>
          </a>
        </nav>
      </div>
    </header>
  );
};