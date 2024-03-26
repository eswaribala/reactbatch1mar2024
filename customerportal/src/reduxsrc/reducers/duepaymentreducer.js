import {ExpressUrl} from "../../configurations/configuration";
import axios from "axios";
import {createSlice} from "@reduxjs/toolkit";

const duePaymentSlice=createSlice({

    name: "customers",
    initialState:{
        customers:{},
        isLoading: false
    },
    reducers:{
       fetch:(state,param)=>{
           return {
               ...state,
               customers:param.payload,
               isLoading: true
           }
       }
    }

})

export const {fetch} = duePaymentSlice.actions;
export default duePaymentSlice.reducer;


export const fetchAllCustomers=()=>(dispatch)=>{

    axios.get(ExpressUrl+"api/customers").then(response=>{
        dispatch(fetch(response.data));
    })
}







