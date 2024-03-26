import {applyMiddleware, configureStore, createStore} from '@reduxjs/toolkit';
import {thunk} from "redux-thunk";
import rootReducer from '../reducers/index'


const index =
 configureStore({
     reducer: {
       topSlicer: rootReducer
     },
})


export default index;