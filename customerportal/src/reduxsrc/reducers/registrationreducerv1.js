import {createSlice} from "@reduxjs/toolkit";
import {ExpressUrl} from "../../configurations/configuration";
import axios from "axios";


const registrationSlice
    = createSlice({
    name: 'RegistrationStatus',
    initialState:{
        isLoaded: false,
        user:{}
    },
    reducers:{
        SAVE_REGISTRATION(state,action){
            state.user=action.payload;
            axios.post(ExpressUrl+"/customers",state.user).then(response=>{
                console.log(response);
            })
            state.isLoaded=true;

        }
    }
});
export const { SAVE_REGISTRATION } = registrationSlice.actions;

export default registrationSlice.reducer;