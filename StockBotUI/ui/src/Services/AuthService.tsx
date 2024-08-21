import axios from "axios"
import { UserToken } from "../AuthTypes"

const API = "https://stockbotapi-b4u2s7hk5q-ew.a.run.app/api"

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
