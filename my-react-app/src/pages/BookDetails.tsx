import { useParams, useNavigate } from 'react-router-dom';
import { useGetBookByIdQuery } from '../services/bookService';

const BookDetails = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();

  const { data: book, isLoading, error } = useGetBookByIdQuery(Number(id), {
    skip: !id,
  });

  if (isLoading) {
    return <div className="text-center py-20">Завантаження...</div>;
  }

  if (error || !book) {
    return <div className="text-center py-20">Книгу не знайдено</div>;
  }

  return (
    <div className="max-w-4xl mx-auto animate-fadeIn">

      <button
        onClick={() => navigate(-1)}
        className="mb-8 text-blue-600 hover:text-blue-800 flex items-center font-medium"
      >
        ← Назад до каталогу
      </button>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-10 mb-12">
        <div>
          <img
            src={book.image}
            alt={book.title}
            className="w-full rounded-2xl shadow-2xl border border-slate-200 object-cover"
          />
        </div>

        <div className="space-y-6">
          <h1 className="text-4xl font-bold">{book.title}</h1>
          <p className="text-xl">Автор: <b>{book.author}</b></p>
          <p className="text-lg text-slate-500">Рік видання: {book.year}</p>
          <span className="text-yellow-500 text-2xl font-bold">⭐ {book.rating}</span>
        </div>
      </div>

      <div className="bg-white p-8 rounded-3xl shadow-sm">
        <h2 className="text-2xl font-bold mb-6">Текст книги</h2>
        <p className="text-lg whitespace-pre-line">{book.content}</p>
      </div>

    </div>
  );
};

export default BookDetails;
