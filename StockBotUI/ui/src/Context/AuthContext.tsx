import React, { createContext, useEffect } from "react";
import { UserProfile } from "../Models/User";
import { useNavigate } from "react-router-dom";


type UserContextType = {
    user: UserProfile | null;
    token: string | null;
    registerUser(username: string, email: string, password: string): Promise<void>;
    loginUser(username: string, password: string): Promise<void>;
    logoutUser(): void;
    isLoggedIn(): boolean;

};

type Props = {children: React.ReactNode};

const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({children}: Props) => {

    const navigate = useNavigate();
    const [user, setUser] = React.useState<UserProfile | null>(null);
    const [token, setToken] = React.useState<string | null>(null);
    const [isReady, setIsReady] = React.useState<boolean>(false);

    useEffect(() => {
        const user = localStorage.getItem("user");
        const token = localStorage.getItem("token");

        if(user && token){
            setUser(JSON.parse(user));
            setToken(token);
        }
        setIsReady(true);
    },[]);

}