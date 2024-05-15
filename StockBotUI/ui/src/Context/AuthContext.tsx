import React, { createContext } from "react";


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