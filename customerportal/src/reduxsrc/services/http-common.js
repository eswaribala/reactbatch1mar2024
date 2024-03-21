import axios from "axios";
import {Url} from '../../configurations/configuration'
export default axios.create({
    baseURL: Url,
    headers: {
        "Content-type": "application/json"
    }
});
