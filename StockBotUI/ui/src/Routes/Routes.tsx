import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import Home from "../Pages/Home/Home";
import Stock from "../Pages/Stock/Stock";
import SearchPage from "../Pages/SearchPage/SearchPage";
import IncomeStatement from "../Components/IncomeStatement/IncomeStatement";
import StockProfile from "../Components/StockProfile/StockProfile";
import BalanceSheet from "../Components/BalanceSheet/BalanceSheet";
import CashFlowStatement from "../Components/CashFlowStatement/CashFlowStatement";
import HistoricalDiv from "../Components/HistoricalDiv/HistoricalDiv";
import LatestNews from "../Components/LatestNews/LatestNews";
import DesignPage from "../Pages/DesignPage/DesignPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children:[
            {path:"", element:<Home/>},
            {path:"register", element:<RegisterPage/>},
            {path:"login", element:<LoginPage/>},
            {path:"search", element:<SearchPage/>},
            {path: "design", element:<DesignPage/>},
            {path:"stock/:ticker", 
            element:<Stock/>,
        children:[{path:"stock-profile", element:<StockProfile/>},
        {path:"income-statement", element:<IncomeStatement/>},
        {path:"balance-sheet", element:<BalanceSheet/>},
        {path:"cashflow-statement", element:<CashFlowStatement/>},
        {path:"historical-dividend", element:<HistoricalDiv/>},
        {path:"latest-news", element:<LatestNews/>},]},
        ]

    }
    
])