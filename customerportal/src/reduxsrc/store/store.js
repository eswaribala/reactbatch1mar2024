import {configureStore} from '@reduxjs/toolkit';
import rootReducer from "../reducers";
import {thunk} from "redux-thunk";

//step1

const index = configureStore({
    reducer:   rootReducer,
    middleware: thunk

});

export default index;