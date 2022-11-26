import { toast } from 'react-toastify';
import { createAsyncThunk, isAnyOf } from '@reduxjs/toolkit';
import { createSlice } from '@reduxjs/toolkit';
import { User } from "../../app/models/user";
import agent from '../../app/api/agent';
import { FieldValues } from "react-hook-form";
import { history } from '../..';

interface AccountState {
    user: User | null;
}

const initialState: AccountState = {
    user: null
}

export const signInUser = createAsyncThunk<User, FieldValues>(
    "account/signUInUser",
    async (data, thunkApi) => {
        try {
            const user = await agent.Account.login(data);
            localStorage.setItem("user", JSON.stringify(user));
            return user;
        } catch (error: any) {
            return thunkApi.rejectWithValue({ error: error.data });
        }
    }
)

export const fetchCurrentUser = createAsyncThunk<User>(
    "account/fetchCurrentUser",
    async (_, thunkApi) => {
        thunkApi.dispatch(setUser(JSON.parse(localStorage.getItem("user")!)))
        try {
            const user = await agent.Account.currentUser();
            localStorage.setItem("user", JSON.stringify(user));
            return user;
        } catch (error: any) {
            return thunkApi.rejectWithValue({ error: error.data });
        }
    },
    {
        condition: () => {
            if (!localStorage.getItem("user")) return false;
        }
    }
)

export const AccountSlice = createSlice({
    name: "account",
    initialState,
    reducers: {
        signOut: (state) => {
            state.user = null;
            localStorage.removeItem("user");
            history.push("/");
        },
        setUser: (state, action) => {
            state.user = action.payload;
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchCurrentUser.fulfilled, (state) => {
            state.user = null;
            localStorage.removeItem("user");
            toast.error("Session expired. Please re-login");
            history.push("/");
        });
        builder.addMatcher(isAnyOf(signInUser.fulfilled, fetchCurrentUser.fulfilled), (state, action) => {
            state.user = action.payload;
        });
        builder.addMatcher(isAnyOf(signInUser.rejected, fetchCurrentUser.rejected), (state, action) => {
            console.log(action.payload);
        });
    }),
})

export const { signOut, setUser } = AccountSlice.actions;