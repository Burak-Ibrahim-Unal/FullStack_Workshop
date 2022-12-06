import { productSlice } from './../../features/product/productSlice';
import { configureStore } from "@reduxjs/toolkit";
import { TypedUseSelectorHook, useDispatch, useSelector } from "react-redux";
// import { accountSlice } from "../../features/account/accountSlice";
// import { basketSlice } from "../../features/basket/basketSlice";
// import { counterSlice } from "../../features/contact/counterSlice";

// export function configureStore() {
//     return createStore(counterReducer);
// }

export const store = configureStore({
reducer: {
        // counter: counterSlice.reducer,
        // basket: basketSlice.reducer,
        product: productSlice.reducer,
        //account: accountSlice.reducer
    }
})

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export const useAppDispatch = () => useDispatch<AppDispatch>();
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;