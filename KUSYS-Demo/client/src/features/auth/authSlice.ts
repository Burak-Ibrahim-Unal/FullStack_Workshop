import { toast } from 'react-toastify';
import { createAsyncThunk, isAnyOf } from '@reduxjs/toolkit';
import { createSlice } from '@reduxjs/toolkit';
import { User } from "../../app/models/user";
import agent from '../../app/api/agent';
import { FieldValues } from "react-hook-form";
import { history } from '../..';

interface AuthState {
    user: User | null;
}

const initialState: AuthState = {
    user: null
}

export const signInUser = createAsyncThunk<User, FieldValues>(
    "auth/signInUser",
    async (data, thunkApi) => {
        try {
            const userDto = await agent.Auth.login(data);
            const { basket, ...user } = userDto;
            localStorage.setItem("user", JSON.stringify(user));
            return user;
        } catch (error: any) {
            return thunkApi.rejectWithValue({ error: error.data });
        }
    }
)

export const fetchCurrentUser = createAsyncThunk<User>(
    "auth/fetchCurrentUser",
    async (_, thunkApi) => {
        thunkApi.dispatch(setUser(JSON.parse(localStorage.getItem("user")!)))
        try {
            const userDto = await agent.Auth.currentUser();
            const { basket, ...user } = userDto;
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

export const AuthSlice = createSlice({
    name: "auth",
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

export const { signOut, setUser } = AuthSlice.actions;