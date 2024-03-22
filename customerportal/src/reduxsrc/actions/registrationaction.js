import RegisterService from "../services/registerservice";
import {SAVE_REGISTRATION} from "../types/types";

//step3
export const saveRegistration=(values) => async (dispatch) => {
    try {
        const res = await RegisterService.create(values);
        dispatch({
            type: SAVE_REGISTRATION,
            payload: res.data,
            isLoaded: false
        });
        return Promise.resolve(res.data);
    }catch (err) {
        return Promise.reject(err);
    }


}





