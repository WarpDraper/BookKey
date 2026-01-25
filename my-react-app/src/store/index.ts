import { configureStore } from '@reduxjs/toolkit';
import { bookService } from '../services/bookService';
import searchReducer from './searchSlice';
// import bookReducer from './bookSlice';

export const store = configureStore({
  reducer: {
    // books: bookReducer,
    [ bookService.reducerPath]: bookService.reducer,
    search: searchReducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(bookService.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;