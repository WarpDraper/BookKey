import { BookCard } from './BookCard'; // Зверніть увагу на назву вашого файлу!

export const BookList = ({ books }: { books: any[] }) => {
  return (
    <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
      {books.map((b) => (
        <BookCard key={b.id} book={b} />
      ))}
    </div>
  );
};