import * as http from "http";

const create = (data) => {
    return http.post("/api/v1/Customers", data);
};
const RegisterService={
    create
}

export default RegisterService