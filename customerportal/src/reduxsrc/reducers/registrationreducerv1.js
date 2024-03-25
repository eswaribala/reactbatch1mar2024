import {createAsyncThunk, createSlice} from "@reduxjs/toolkit";
import {ExpressUrl} from "../../configurations/configuration";
import axios from "axios";



export const registrationSlice
    = createSlice({
    name: 'user',
    initialState: {
        user: {},
        isLoaded:false
    },
    reducers:{

        SAVE_REGISTRATION:(state,action)=>{

            axios.post(ExpressUrl+"api/customers",action.payload).then(response=>{
                console.log(response);
            });
          return{
              ...state,
              isLoaded: true,
              user:action.payload

          }
        }
    }
});
export const { SAVE_REGISTRATION } = registrationSlice.actions;

export default registrationSlice.reducer;