import { createApi } from "@reduxjs/toolkit/query/react";
import { createBaseQuery } from "../utils/createBaseQuery";
import type { Book } from "../types/books";

export const bookService = createApi({
  reducerPath: 'bookService',
  baseQuery: createBaseQuery('book'),
  tagTypes: ['Book'],

  endpoints: (build) => ({
    // 🔹 Отримати всі книги
    getBooks: build.query<Book[], void>({
      query: () => ({
        url: '',
        method: 'GET',
      }),
      providesTags: ['Book'],
    }),

    // 🔹 Отримати книгу по id (BookDetails)
    getBookById: build.query<Book, number>({
      query: (id) => ({
        url: `/${id}`,
        method: 'GET',
      }),
      providesTags: (_result, _error, id) => [
        { type: 'Book', id },
      ],
    }),
  }),
});

export const {
  useGetBooksQuery,
  useGetBookByIdQuery, // 👈 новий хук
} = bookService;
