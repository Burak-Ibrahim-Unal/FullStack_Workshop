import { AuthSlice } from '../../features/auth/authSlice';
import { catalogSlice } from '../../features/student/catalogSlice';
import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';
import { counterSlice } from './../../features/contact/counterSlice';
import { configureStore } from '@reduxjs/toolkit';

export const store = configureStore({
    reducer: {
        counter: counterSlice.reducer,
        catalog: catalogSlice.reducer,
        auth: AuthSlice.reducer
    }
})

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;