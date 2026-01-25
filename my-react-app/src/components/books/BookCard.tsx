
import { Link } from 'react-router-dom';

export const BookCard = ({ book }: any) => {
  return (
    <div className="bg-white rounded-xl shadow-md overflow-hidden hover:shadow-lg transition-shadow border border-slate-100">
      <img src={book.image} alt={book.title} className="w-full h-64 object-cover" />
      <div className="p-4">
        <h3 className="font-bold text-lg truncate">{book.title}</h3>
        <p className="text-slate-500 text-sm">{book.author}</p>
        <div className="mt-3 flex items-center justify-between">
          <span className="text-yellow-500 font-bold">⭐ {book.rating}</span>
          <Link 
            to={`/catalog/${book.id}`} 
            className="px-4 py-2 bg-blue-50 text-blue-600 rounded-lg font-medium hover:bg-blue-600 hover:text-white transition-colors"
          >
            Деталі
          </Link>
        </div>
      </div>
    </div>
  );
};