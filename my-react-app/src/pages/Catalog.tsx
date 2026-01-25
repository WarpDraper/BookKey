<<<<<<< HEAD
import { useGetBooksQuery } from '../services/bookService';
import { BookList } from '../components/books/BookList';
import { useSelector } from 'react-redux';
import type { RootState } from '../store';

const Catalog = () => {
  const { data: books, isLoading, error } = useGetBooksQuery();
  const searchQuery = useSelector((state: RootState) => state.search.query);
=======
import { useGetBooksQuery } from '../store/bookSlice';
import { BookList } from '../components/books/BookList';

const Catalog = () => {
  const { data: books, isLoading, error } = useGetBooksQuery();
>>>>>>> b79f40358c97693e3cbe40aeb5d035e72b98c778

  if (isLoading) return <div className="p-10 text-center">Завантаження...</div>;
  if (error) return <div className="text-red-500 text-center">Помилка API</div>;

<<<<<<< HEAD
  const filteredBooks = books?.filter(book => 
    book.title.toLowerCase().includes(searchQuery.toLowerCase()) ||
    book.author.toLowerCase().includes(searchQuery.toLowerCase())
  );

  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold">{searchQuery ? `Результати для: "${searchQuery}"` : "Каталог книг"}</h1>
      <BookList books={filteredBooks || []} />
=======
  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold">Каталог</h1>
      <BookList books={books || []} />
>>>>>>> b79f40358c97693e3cbe40aeb5d035e72b98c778
    </div>
  );
};

export default Catalog;