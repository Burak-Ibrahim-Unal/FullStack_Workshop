import { RootState } from './../../app/store/configureStore';
import { Product, ProductParams } from './../../app/models/product';
import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import agent from '../../app/api/agent';

interface CatalogState {
    productsLoaded: boolean;
    filtersLoaded: boolean;
    status: string;
    brands: string[];
    types: string[];
    productParams: ProductParams;
}

const productsAdapter = createEntityAdapter<Product>();

export const fetchProductsAsync = createAsyncThunk<Product[]>(
    "catalog/fetchProductsAsync",
    async (_, thunkApi) => {
        try {
            return await agent.Catalog.list();
        } catch (error: any) {
            //console.log(error);
            return thunkApi.rejectWithValue({ error: error.data });
        }
    }
)

export const fetchProductAsync = createAsyncThunk<Product, number>(
    "catalog/fetchProductAsync",
    async (productId, thunkApi) => {
        try {
            return await agent.Catalog.details(productId);
        } catch (error: any) {
            // console.log(error);
            return thunkApi.rejectWithValue({ error: error.data })
        }
    }
)

export const fetchFilters = createAsyncThunk(
    "catalog/fetchFilters",
    async (_, thunkApi) => {
        try {
            return agent.Catalog.fetchFilters();
        } catch (error: any) {
            return thunkApi.rejectWithValue({ error: error.data });
        }
    }
)

function initParams() {
    return {
        pageNumber: 1,
        pageSize: 6,
        orderBy: "name"
    }
}

export const catalogSlice = createSlice({
    name: "catalog",
    initialState: productsAdapter.getInitialState<CatalogState>({
        productsLoaded: false,
        filtersLoaded: false,
        status: "idle",
        brands: [],
        types: [],
        productParams: initParams()
    }),
    reducers: {
        setProductParams: (state, action) => {
            state.productsLoaded = false;
            state.productParams = { ...state.productParams, ...action.payload };
        },
        resetProductParams: (state) => {
            state.productParams = initParams();
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchProductsAsync.pending, (state) => {
            state.status = "pendingFetchProducts";
        });
        builder.addCase(fetchProductsAsync.fulfilled, (state, action) => {
            productsAdapter.setAll(state, action.payload);
            state.status = "idle";
            state.productsLoaded = true;
        });
        builder.addCase(fetchProductsAsync.rejected, (state, action) => {
            console.log(action.payload);
            state.status = "idle";
        });
        builder.addCase(fetchProductAsync.pending, (state) => {
            state.status = "pendingFetchProduct";
        });
        builder.addCase(fetchProductAsync.fulfilled, (state, action) => {
            productsAdapter.upsertOne(state, action.payload);
            state.status = "idle";
        });
        builder.addCase(fetchProductAsync.rejected, (state, action) => {
            console.log(action);
            state.status = "idle";
        });
        builder.addCase(fetchFilters.pending, (state) => {
            state.status = "pendingFetchFilters";
        });
        builder.addCase(fetchFilters.fulfilled, (state, action) => {
            state.brands = action.payload.brands;
            state.types = action.payload.types;
            state.status = "idle";
            state.filtersLoaded = true;
        });
        builder.addCase(fetchFilters.rejected, (state, action) => {
            state.status = "idle";
            console.log(action.payload);
        });


    })
})

export const productSelectors = productsAdapter.getSelectors((state: RootState) => state.catalog);
export const { setProductParams, resetProductParams } = catalogSlice.actions;