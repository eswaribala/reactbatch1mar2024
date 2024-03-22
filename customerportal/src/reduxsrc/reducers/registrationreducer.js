import {SAVE_REGISTRATION} from "../types/types";

const registrationReducer = (state = {}, action) => {
    switch (action.type) {

        case SAVE_REGISTRATION:
            return {
                ...state,
                isLoaded: true,
                user:action.payload
            }


        default: return state
    }
}

export default registrationReducer