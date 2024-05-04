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
            {path:"stock/:ticker", element:<Stock/>},
        ]

    }
    
])