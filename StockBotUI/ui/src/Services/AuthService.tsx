import axios from "axios"
import { error } from "console"
import { UserToken } from "../AuthTypes"

const API = "https://localhost:7237/api"

    export const toLoginAPI = async (username: string, password: string) =>{
        try{

            const response = await axios.post<UserToken>(API + "/appuser/login",{
                username: username,
                password: password
            })
            return response.data

        }
        catch(e){
            error(e)

        }
    }