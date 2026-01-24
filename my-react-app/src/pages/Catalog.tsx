import { useGetBooksQuery } from '../store/bookSlice';
import { BookList } from '../components/books/BookList';

const Catalog = () => {
  const { data: books, isLoading, error } = useGetBooksQuery();

  if (isLoading) return <div className="p-10 text-center">Завантаження...</div>;
  if (error) return <div className="text-red-500 text-center">Помилка API</div>;

  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold">Каталог</h1>
      <BookList books={books || []} />
    </div>
  );
};

export default Catalog;