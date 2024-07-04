import axios from "axios"
import { UserToken } from "../AuthTypes"

const API = "https://localhost:7297/api"

export const toLoginAPI = async (username: string, password: string) =>{
    try{

        const response = await axios.post<UserToken>(API + "/user/login",{
                username: username,
                password: password
        })
        return response.data

        }
    catch(e){
        console.log(e)

        }
}

export const toRegisterAPI = async (username: string, password: string, email:string) =>{
    try{

        const response = await axios.post<UserToken>(API + "/user/register",{
            email: email,
            username: username,
            password: password
        })
        return response.data

        }
    catch(e){
        console.log(e)

        }
}
