import axios, { AxiosResponse } from "axios"
import { Company, CompanyIncomeStatement, CompanyKeyMetrics, CompanyProfile } from "../company"

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

export const getCompanyProfile = async (query: string)  => {
    try{
        const data = await axios.get<CompanyProfile[]>(`https://localhost:7297/api/profile/${query}`);
        return data;
    }
    catch (error: any) {
        if(axios.isAxiosError(error)) {
            console.log(error.message);
            return error.message;
        }
        else{
            console.log(error);
            return error as string;
        }
    }
}

export const getKeyMetrics = async (query: string)  => {
    try{
        const data = await axios.get<CompanyKeyMetrics[]>(`https://localhost:7297/api/key-metrics/${query}`);
        return data;
    }
    catch (error: any) {
        if(axios.isAxiosError(error)) {
            console.log(error.message);
            return error.message;
        }
        else{
            console.log(error);
            return error as string;
        }
    }
}

export const getIncomeStatement = async (query: string)  => {
    try{
        const data = await axios.get<CompanyIncomeStatement[]>(`https://localhost:7297/api/income/${query}`);
        return data;
    }
    catch (error: any) {
        if(axios.isAxiosError(error)) {
            console.log(error.message);
            return error.message;
        }
        else{
            console.log(error);
            return error as string;
        }
    }
}