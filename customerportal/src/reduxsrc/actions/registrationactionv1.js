import {saveRegistration} from "./registrationaction";
import { SAVE_REGISTRATION } from '../reducers/registrationreducerv1'
import RegisterService from "../services/registerservice";


export const saveRegistrationAsync = (values) => {
    return async (dispatch) => {

        try {
             const res = await RegisterService.create(values);
             const payload=res.data
             dispatch(SAVE_REGISTRATION(payload));

            return Promise.resolve(res.data);
        } catch (err) {
            return Promise.reject(err);
        }
    };
};


