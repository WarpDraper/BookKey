import { useGetBooksQuery } from '../services/bookService';
import { BookList } from '../components/books/BookList';
import { useSelector } from 'react-redux';
import type { RootState } from '../store';

const Catalog = () => {
  const { data: books, isLoading, error } = useGetBooksQuery();
  const searchQuery = useSelector((state: RootState) => state.search.query);

  if (isLoading) return <div className="p-10 text-center">Завантаження...</div>;
  if (error) return <div className="text-red-500 text-center">Помилка API</div>;

  const filteredBooks = books?.filter(book => 
    book.title.toLowerCase().includes(searchQuery.toLowerCase()) ||
    book.author.toLowerCase().includes(searchQuery.toLowerCase())
  );

  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold">{searchQuery ? `Результати для: "${searchQuery}"` : "Каталог книг"}</h1>
      <BookList books={filteredBooks || []} />
    </div>
  );
};

export default Catalog;