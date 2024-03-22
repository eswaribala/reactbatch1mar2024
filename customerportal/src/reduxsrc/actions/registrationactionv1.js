import {saveRegistration} from "./registrationaction";
import {SAVE_REGISTRATION} from "../types/types";
import RegisterService from "../services/registerservice";


const saveRegistrationAsync = (values) => {
    return async (dispatch) => {

        try {
            setTimeout(() => {
                const res = RegisterService.create(values);
                 const payload=res.data
                dispatch(payload);
            }, 1000);

        } catch (error) {

        }
    };
};


