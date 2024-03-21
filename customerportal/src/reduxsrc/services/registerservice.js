import axios from "axios";
import {Url} from '../../configurations/configuration'

const create = (data) => {
    let requestData={
        "id": 0,
        "name": {
            "firstName": data.firstName,
            "lastName": data.lastName,
            "middleName": ""
        },
        "email": data.email,
        "password": data.password,
        "phone": data.mobileNo
    }

    return axios.post(Url+"api/v1/Customers", requestData);
};
//step4
const RegisterService={
    //step5
    create
}

export default RegisterService