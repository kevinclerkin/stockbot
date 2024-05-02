import axios, { AxiosResponse } from "axios";
import { Company } from "./company";

interface searchResponse {
    data: Company[];

}

export const searchCompany = async (query: string): Promise<string | AxiosResponse<searchResponse, any>> => {
    try{
        const response = await axios.get<searchResponse>(`https://financialmodelingprep.com/api/v3/search?query=${query}&limit=10&exchange=NASDAQ&apikey=${process.env.REACT_APP_API_KEY}`);
        return response;
    } catch (error) {
        if(axios.isAxiosError(error)) {
            console.log(error.message);
            return error.message;
        }
        else{
            console.log(error);
            return error as string;
        }
    }
};