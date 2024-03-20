import axios from 'axios'

const RestAPIUrl="http://54.165.173.13:8085/filter/"
export function getChitsByCustomerId(customerId){
    axios.get(RestAPIUrl+customerId).then(response=>{
        sessionStorage.setItem("response",response.data)
    })

}
