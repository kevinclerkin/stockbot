import axios from "axios"
import { GetPortfolio, PostPortfolio } from "../Models/Portfolio"

const API = "https://localhost:7297/api"


export const GetPortfolioFromAPI = async () => {
    try {
        const data = await axios.get<GetPortfolio[]>(API)
        return data
    }
    catch(error) {
        console.error(error)
    }
}


export const AddPortfolioFromAPI = async (symbol: string) => {
    try {
        const data = await axios.post<PostPortfolio>(`${API}/portfolio/?symbol=${ symbol }`)
        return data
    }
    catch(error) {
        console.error(error)
    }
}


export const DeletePortfolioFromAPI = async (symbol: string) => {
    try {
        const data = await axios.delete<PostPortfolio>(`${API}/portfolio/?symbol=${ symbol }`)
        return data
    }
    catch(error) {
        console.error(error)
    }
}

