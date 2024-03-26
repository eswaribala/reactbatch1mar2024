import {combineReducers} from 'redux'
import userReducer from "./registrationreducerv1"
import paymentReducer from "./duepaymentreducer";



export default combineReducers({
    slicer:userReducer,
    dueSlicer:paymentReducer
})