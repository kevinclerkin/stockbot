import axios from "axios"
import { PostPortfolio } from "../Models/Portfolio"

const API = "https://localhost:7297/api"

export const AddPortfolioFromAPI = async (symbol: string) => {
    try {
        const data = await axios.post<PostPortfolio>(`${API}/portfolio/?symbol=${ symbol }`)
        return data
    }
    catch(error) {
        console.error(error)
    }
}