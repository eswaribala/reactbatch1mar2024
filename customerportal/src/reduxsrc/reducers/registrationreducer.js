import {SAVE_REGISTRATION} from "../types/types";

const initialState = {
    loading: false,
    customerValues: [],
    error: ''
}

const registrationReducer = (state = initialState, action) => {
    switch (action.type) {

        case SAVE_REGISTRATION:
            return {
                loading: false,
                customerValues: action.payload,
                error: ''
            }


        default: return state
    }
}

export default registrationReducer