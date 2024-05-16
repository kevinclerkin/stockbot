import axios from "axios"
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
        console.log(e)

        }
}

export const toRegisterAPI = async (username: string, email: string, password: string) =>{
    try{

        const response = await axios.post<UserToken>(API + "/appuser/register",{
                username: username,
                email: email,
                password: password
        })
        return response.data

        }
    catch(e){
        console.log(e)

        }
}
