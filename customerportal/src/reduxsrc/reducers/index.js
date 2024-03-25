import {combineReducers} from 'redux'
import userReducer from "./registrationreducerv1"
import {contentSlice} from "./fetchregistrationreducer";



const rootReducer = combineReducers({
    reducer: {
        slicer: userReducer,
        content: contentSlice
    },
})

export default rootReducer