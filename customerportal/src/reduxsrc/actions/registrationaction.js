import RegisterService from "../services/registerservice";

export const saveRegistration=async(values)=>{

    await RegisterService.create(values)
}



