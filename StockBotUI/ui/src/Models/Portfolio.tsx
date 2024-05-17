export type GetPortfolio = {
    id: number;
    symbol: string;
    companyName: string;
    purchasePrice: number;
    lastDiv: number;
    industry: string;
    marketCap: number;
}

export type PostPortfolio = {
    symbol: string;
    companyName: string;
    purchasePrice: number;
    lastDiv: number;
    industry: string;
    marketCap: number;
}