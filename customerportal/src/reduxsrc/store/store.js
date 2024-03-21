import {configureStore} from '@reduxjs/toolkit';
import rootReducer from "../reducers";



const index = configureStore({
    reducer:   rootReducer,

});

export default index;