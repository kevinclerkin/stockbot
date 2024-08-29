import axios, { AxiosResponse } from "axios"
import { Company, CompanyIncomeStatement, CompanyKeyMetrics, CompanyProfile } from "../company"

interface searchResponse {
    data: Company[];

}

const API = "https://stockbotapi-b4u2s7hk5q-ew.a.run.app/api/stock-data/";
//const API2 = "https://localhost:7297/api/stock-data/";

export const getStockData = async (query: string): Promise<string | AxiosResponse<searchResponse, any>> => {
    try{
        const response = await axios.get<searchResponse>(API + `${query}`);
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
        const data = await axios.get<CompanyProfile>(API + `overview/${query}`);
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
        const data = await axios.get<CompanyKeyMetrics[]>(API + `key-metrics/${query}`);
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
        const data = await axios.get<CompanyIncomeStatement[]>(API + `income/${query}`);
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