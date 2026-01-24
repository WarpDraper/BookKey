import { configureStore } from '@reduxjs/toolkit';
import { bookService } from '../services/bookService';
// import bookReducer from './bookSlice';

export const store = configureStore({
  reducer: {
    // books: bookReducer,
    [ bookService.reducerPath]: bookService.reducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;