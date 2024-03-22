import {saveRegistration} from "./registrationaction";
import { SAVE_REGISTRATION } from '../reducers/registrationreducerv1'
import RegisterService from "../services/registerservice";


export const saveRegistrationAsync = (values) => {
    return async (dispatch) => {

        try {
            setTimeout(() => {
                const res = RegisterService.create(values);
                 const payload=res.data
                dispatch(SAVE_REGISTRATION(payload));
            }, 1000);

        } catch (error) {

        }
    };
};


