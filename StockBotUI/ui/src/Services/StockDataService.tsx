import axios, { AxiosResponse } from "axios"
import { Company } from "../company"

interface searchResponse {
    data: Company[];

}

export const getStockData = async (query: string): Promise<string | AxiosResponse<searchResponse, any>> => {
    try{
        const response = await axios.get<searchResponse>(`https://localhost:7297/api/stock-data/${query}`);
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