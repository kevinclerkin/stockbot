import React, { createContext, useEffect } from "react";
import { UserProfile } from "../Models/User";
import { useNavigate } from "react-router-dom";
import { toLoginAPI, toRegisterAPI } from "../Services/AuthService";
import axios from "axios";

type UserContextType = {
    user: UserProfile | null;
    token: string | null;
    registerUser(username: string, email: string, password: string): Promise<void>;
    loginUser(username: string, password: string): Promise<boolean>;
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
            axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
        }
        setIsReady(true);
    },[]);

    const registerUser = async (username: string, email: string, password: string) => {
        await toRegisterAPI(username, email, password)
          .then((res) => {
            if(res){
                localStorage.setItem("token", res.token!);
                const userObj ={
                    username: res?.username,
                    email: res?.email
                }
                localStorage.setItem("user", JSON.stringify(userObj));
                setToken(res?.token!);
                setUser(userObj!);
                navigate("/search");
            }
        
        })
          .catch((e) => ("Registration failed. Please try again"));
    
    };

    const loginUser = async (username: string, password: string) => {
        await toLoginAPI(username, password)
          .then((res) => {
            if (res) {
              localStorage.setItem("token", res?.token);
              const userObj = {
                username: res?.username,
                email: res?.email,
              };
              localStorage.setItem("user", JSON.stringify(userObj));
              setToken(res?.token!);
              setUser(userObj!);
              navigate("/search");
              return true;
            }
          })
          .catch((e) => ("Login failed. Check your credentials and try again"));
          return false; 
    };

    const isLoggedIn = () => {
        return !!user;
    };

    const logoutUser = () => {
        localStorage.removeItem("user");
        localStorage.removeItem("token");
        setUser(null);
        setToken("");
        navigate("/");
    };

    return (
        <UserContext.Provider value={{user, token, registerUser, loginUser, logoutUser, isLoggedIn}}>
            {isReady ? children : null}
        </UserContext.Provider>
    );

}

export const AuthContext = () => React.useContext(UserContext);