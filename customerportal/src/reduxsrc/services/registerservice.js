import axios from "axios";
import {Url} from '../../configurations/configuration'
import { AES } from 'crypto-js';
const secretPass = "XkhZG4fW2t2W";

const create = (data) => {
    let requestData={
        "id": 0,
        "name": {
            "firstName": AES.encrypt( JSON.stringify(data.firstName),
                secretPass
            ).toString(),
            "lastName": AES.encrypt( JSON.stringify(data.lastName),
                secretPass
            ).toString(),
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