import { createApi } from "@reduxjs/toolkit/query/react";
import { createBaseQuery } from "../utils/createBaseQuery";
import type { Book } from "../types/books";

export const bookService = createApi({
  reducerPath: 'bookService',
<<<<<<< HEAD
  baseQuery: createBaseQuery('book'),
  tagTypes: ['Book'],
=======
  baseQuery: createBaseQuery('books'),
  tagTypes: ['Books'],
>>>>>>> b79f40358c97693e3cbe40aeb5d035e72b98c778

  endpoints: (build) => ({
    // 🔹 Отримати всі книги
    getBooks: build.query<Book[], void>({
      query: () => ({
        url: '',
        method: 'GET',
      }),
<<<<<<< HEAD
      providesTags: ['Book'],
=======
      providesTags: ['Books'],
>>>>>>> b79f40358c97693e3cbe40aeb5d035e72b98c778
    }),

    // 🔹 Отримати книгу по id (BookDetails)
    getBookById: build.query<Book, number>({
      query: (id) => ({
        url: `/${id}`,
        method: 'GET',
      }),
      providesTags: (_result, _error, id) => [
<<<<<<< HEAD
        { type: 'Book', id },
=======
        { type: 'Books', id },
>>>>>>> b79f40358c97693e3cbe40aeb5d035e72b98c778
      ],
    }),
  }),
});

export const {
  useGetBooksQuery,
  useGetBookByIdQuery, // 👈 новий хук
} = bookService;
