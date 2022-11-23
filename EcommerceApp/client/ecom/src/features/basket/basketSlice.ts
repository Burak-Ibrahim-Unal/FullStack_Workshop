import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import agent from "../../app/api/agent";
import { Basket } from "../../app/models/basket";

interface BasketState {
    basket: Basket | null;
    status: string;
}

const initialState: BasketState = {
    basket: null,
    status: "idle"
}

export const addBasketItemAsync = createAsyncThunk<Basket, { productId: number, quantity?: number }>(
    "basket/addBasketItemAsync",
    async ({ productId, quantity = 1 }) => {
        try {
            return await agent.Basket.addItem(productId, quantity);
        } catch (error) {

        }
    }
)

export const removeBasketItemAsync = createAsyncThunk<void, { productId: number, quantity: number }>(
    "basket/removeBasketItemAsync",
    async ({ productId, quantity = 1 }) => {
        try {
            await agent.Basket.removeItem(productId, quantity);
        } catch (error) {

        }
    }
)

export const basketSlice = createSlice({
    name: "basket",
    initialState,
    reducers: {
        setBasket: (state, action) => {
            state.basket = action.payload
        }
    },
    extraReducers: (builder => {
        builder.addCase(addBasketItemAsync.pending, (state, action) => {
            console.log(action);
            state.status = "pendingAddItem" + action.meta.arg.productId;
        });
        builder.addCase(addBasketItemAsync.fulfilled, (state, action) => {
            state.basket = action.payload;
            state.status = "idle";
        });
        builder.addCase(addBasketItemAsync.rejected, (state) => {
            state.status = "idle";
        });
        builder.addCase(removeBasketItemAsync.pending, (state, action) => {
            state.status = "pendingRemoveItem" + action.meta.arg.productId;
        });
        builder.addCase(removeBasketItemAsync.fulfilled, (state, action) => {
            const { productId, quantity } = action.meta.arg;
            const itemIndex = state.basket?.items.findIndex(i => i.productId === productId);

            if (itemIndex === -1 || itemIndex === undefined) return;
            state.basket!.items[itemIndex].quantity -= quantity!;

            if (state.basket?.items[itemIndex].quantity === 0) state.basket.items.splice(itemIndex, 1);

            state.status = "idle";
        });
        builder.addCase(removeBasketItemAsync.rejected, (state) => {
            state.status = "idle";
        });
    })
})

export const { setBasket } = basketSlice.actions;