import {applyMiddleware, configureStore, createStore} from '@reduxjs/toolkit';
import rootReducer from "../reducers";
import {thunk} from "redux-thunk";

//step1

const index =
    createStore(rootReducer,applyMiddleware(thunk))



export default index;