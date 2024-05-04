import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import Home from "../Pages/Home/Home";
import Stock from "../Pages/Stock/Stock";
import SearchPage from "../Pages/SearchPage/SearchPage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
        children:[
            {path:"", element:<Home/>},
            {path:"search", element:<SearchPage/>},
            {path:"stock/:ticker", 
            element:<Stock/>,
        children:[{path:"stock-profile", element:<Home/>},
        {path:"income-statement", element:<SearchPage/>},
        {path:"balance-sheet", element:<Home/>},
        {path:"cashflow-statement", element:<SearchPage/>},
        {path:"historical-dividend", element:<Home/>},
        {path:"latest-news", element:<SearchPage/>},]},
        ]

    }
    
])