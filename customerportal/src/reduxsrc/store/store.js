import {applyMiddleware, configureStore, createStore} from '@reduxjs/toolkit';
import rootReducer from "../reducers";
import {thunk} from "redux-thunk";
import userReducer, {registrationSlice} from "../reducers/registrationreducerv1";
import contentSlice from '../reducers/fetchregistrationreducer'
//step1

const index =
 configureStore({
     reducer: {
         slicer: userReducer,
         content: contentSlice
     },
})


export default index;