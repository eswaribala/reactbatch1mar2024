import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import axios from 'axios'
import {ExpressUrl} from "../../configurations/configuration";

const initialState = {
    contents: [],
    isLoading: false,
    error: null,
}

export const fetchContent = createAsyncThunk(
    'content/fetchContent',
    async () => {
        const res = await axios.get(ExpressUrl+"api/customers")
        const data = await res.data
        return data
    }
)

export const contentSlice = createSlice({
    name: 'content',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder.addCase(fetchContent.pending, (state) => {
            state.isLoading = false
        })
        builder.addCase(fetchContent.fulfilled, (state, action) => {
            state.isLoading = true
            alert(action.payload);
            state.contents = action.payload
        })
        builder.addCase(fetchContent.rejected, (state, action) => {
            state.isLoading = true
            state.error = action.error.message
        })
    },
})

export default contentSlice.reducer