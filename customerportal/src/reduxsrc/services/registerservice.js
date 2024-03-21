import axios from "axios";
import {Url} from '../../configurations/configuration'

const create = (data) => {
    return axios.post(Url+"/api/v1/Customers", data);
};
//step4
const RegisterService={
    //step5
    create
}

export default RegisterService