import React from 'react'
import { Navigate, useLocation } from 'react-router-dom';
import { AuthContext } from '../Context/AuthContext';

type Props = {children: React.ReactNode}

const Protected = ({children}: Props) => {
    const location = useLocation();
    const {isLoggedIn} = AuthContext();
  return (
    isLoggedIn() ? (
        <>{children}</>
      ) : (
        <Navigate to="/login" state={{ from: location }} replace />
    )
    );
};

export default Protected