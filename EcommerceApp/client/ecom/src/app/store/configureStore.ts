import { catalogSlice } from './../../features/product/catalogSlice';
import { basketSlice } from './../../features/basket/basketSlice';
import { TypedUseSelectorHook,useDispatch, useSelector } from 'react-redux';
import { counterSlice } from './../../features/contact/counterSlice';
import { configureStore } from '@reduxjs/toolkit';

export const store = configureStore({
    reducer: {
        counter: counterSlice.reducer,
        basket:basketSlice.reducer,
        catalog:catalogSlice.reducer
    }
})

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;