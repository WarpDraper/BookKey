import { createApi } from "@reduxjs/toolkit/query/react";
import { createBaseQuery } from "../utils/createBaseQuery";
import type { Book } from "../types/books";

export const bookService = createApi({
  reducerPath: 'bookService',
  baseQuery: createBaseQuery('books'),
  tagTypes: ['Books'],

  endpoints: (build) => ({
    // 🔹 Отримати всі книги
    getBooks: build.query<Book[], void>({
      query: () => ({
        url: '',
        method: 'GET',
      }),
      providesTags: ['Books'],
    }),

    // 🔹 Отримати книгу по id (BookDetails)
    getBookById: build.query<Book, number>({
      query: (id) => ({
        url: `/${id}`,
        method: 'GET',
      }),
      providesTags: (_result, _error, id) => [
        { type: 'Books', id },
      ],
    }),
  }),
});

export const {
  useGetBooksQuery,
  useGetBookByIdQuery, // 👈 новий хук
} = bookService;
