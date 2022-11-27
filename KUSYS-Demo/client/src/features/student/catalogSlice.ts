import { RootState } from '../../app/store/configureStore';
import { Student, StudentParams } from '../../app/models/student';
import { createAsyncThunk, createEntityAdapter, createSlice } from "@reduxjs/toolkit";
import agent from '../../app/api/agent';
import { MetaData } from '../../app/models/pagination';

interface CatalogState {
    studentsLoaded: boolean;
    filtersLoaded: boolean;
    status: string;
    courses: string[];
    studentParams: StudentParams;
    metaData: MetaData | null;
}

const studentsAdapter = createEntityAdapter<Student>();

function getAxiosParams(studentParams: StudentParams) {
    const params = new URLSearchParams();
    params.append("pageNumber", studentParams.pageNumber.toString());
    params.append("pageSize", studentParams.pageSize.toString());
    params.append("orderBy", studentParams.orderBy);
    if (studentParams.searchTerm) params.append("searchTerm", studentParams.searchTerm);
    if (studentParams.courses?.length > 0) params.append("courses", studentParams.courses.toString());
    return params;
}

export const fetchStudentsAsync = createAsyncThunk<Student[], void, { state: RootState }>(
    "catalog/fetchStudentsAsync",
    async (_, thunkApi) => {
        const params = getAxiosParams(thunkApi.getState().catalog.studentParams);
        try {
            const response = await agent.Catalog.list(params);
            thunkApi.dispatch(setMetaData(response.metaData));
            return response.items;
        } catch (error: any) {
            //console.log(error);
            return thunkApi.rejectWithValue({ error: error.data });
        }
    }
)

export const fetchStudentAsync = createAsyncThunk<Student, number>(
    "catalog/fetchStudentAsync",
    async (studentId, thunkApi) => {
        try {
            return await agent.Catalog.details(studentId);
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
        orderBy: "name",
        courses: [],
        types: []
    }
}

export const catalogSlice = createSlice({
    name: "catalog",
    initialState: studentsAdapter.getInitialState<CatalogState>({
        studentsLoaded: false,
        filtersLoaded: false,
        status: "idle",
        courses: [],
        studentParams: initParams(),
        metaData: null
    }),
    reducers: {
        setStudentParams: (state, action) => {
            state.studentsLoaded = false;
            state.studentParams = { ...state.studentParams, ...action.payload, pageNumber: 1 };
        },
        setPageNumber: (state, action) => {
            state.studentsLoaded = false;
            state.studentParams = { ...state.studentParams, ...action.payload };
        },
        setMetaData: (state, action) => {
            state.metaData = action.payload;
        },
        resetStudentParams: (state) => {
            state.studentParams = initParams();
        }
    },
    extraReducers: (builder => {
        builder.addCase(fetchStudentsAsync.pending, (state) => {
            state.status = "pendingFetchStudents";
        });
        builder.addCase(fetchStudentsAsync.fulfilled, (state, action) => {
            studentsAdapter.setAll(state, action.payload);
            state.status = "idle";
            state.studentsLoaded = true;
        });
        builder.addCase(fetchStudentsAsync.rejected, (state, action) => {
            console.log(action.payload);
            state.status = "idle";
        });
        builder.addCase(fetchStudentAsync.pending, (state) => {
            state.status = "pendingFetchStudent";
        });
        builder.addCase(fetchStudentAsync.fulfilled, (state, action) => {
            studentsAdapter.upsertOne(state, action.payload);
            state.status = "idle";
        });
        builder.addCase(fetchStudentAsync.rejected, (state, action) => {
            console.log(action);
            state.status = "idle";
        });
        builder.addCase(fetchFilters.pending, (state) => {
            state.status = "pendingFetchFilters";
        });
        builder.addCase(fetchFilters.fulfilled, (state, action) => {
            state.courses = action.payload.courses;
            state.status = "idle";
            state.filtersLoaded = true;
        });
        builder.addCase(fetchFilters.rejected, (state, action) => {
            state.status = "idle";
            console.log(action.payload);
        });
    })
})

export const studentSelectors = studentsAdapter.getSelectors((state: RootState) => state.catalog);
export const { setStudentParams, resetStudentParams, setMetaData, setPageNumber } = catalogSlice.actions;