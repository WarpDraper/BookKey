import { configureStore } from '@reduxjs/toolkit';
import { bookService } from '../services/bookService';
<<<<<<< HEAD
import searchReducer from './searchSlice';
=======
>>>>>>> b79f40358c97693e3cbe40aeb5d035e72b98c778
// import bookReducer from './bookSlice';

export const store = configureStore({
  reducer: {
    // books: bookReducer,
    [ bookService.reducerPath]: bookService.reducer,
<<<<<<< HEAD
    search: searchReducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(bookService.middleware),
=======
  },
>>>>>>> b79f40358c97693e3cbe40aeb5d035e72b98c778
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;