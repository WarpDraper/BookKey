import { createApi } from '@reduxjs/toolkit/query/react';
import { createBaseQuery } from '../utils/createBaseQuery';

const baseQuery = createBaseQuery('books');

export const bookSlice = createApi({
  reducerPath: 'bookSlice',
  baseQuery: baseQuery,
  tagTypes: ['Books'], 
  endpoints: (builder) => ({

    getBooks: builder.query<any[], void>({
      query: () => '/books',
      providesTags: ['Books'],
    }),

    getBookById: builder.query<any, string>({
      query: (id) => `/books/${id}`,
      providesTags: (result, error, id) => [{ type: 'Books', id }],
    }),
  }),
});

export const { useGetBooksQuery, useGetBookByIdQuery } = bookSlice;