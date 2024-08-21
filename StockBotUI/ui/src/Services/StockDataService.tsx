import axios, { AxiosResponse } from "axios"
import { Company, CompanyIncomeStatement, CompanyKeyMetrics, CompanyProfile } from "../company"

interface searchResponse {
    data: Company[];

}

export const getStockData = async (query: string): Promise<string | AxiosResponse<searchResponse, any>> => {
    try{
        const response = await axios.get<searchResponse>(`https://stockbotapi-b4u2s7hk5q-ew.a.run.app/api/stock-data/${query}`);
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
        const data = await axios.get<CompanyProfile>(`https://stockbotapi-b4u2s7hk5q-ew.a.run.app/api/stock-data/overview/${query}`);
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
        const data = await axios.get<CompanyKeyMetrics[]>(`https://stockbotapi-b4u2s7hk5q-ew.a.run.app/api/stock-data/key-metrics/${query}`);
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
        const data = await axios.get<CompanyIncomeStatement[]>(`https://stockbotapi-b4u2s7hk5q-ew.a.run.app/api/stock-data/income/${query}`);
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