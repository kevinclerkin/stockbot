import './App.css';
import NavBar from './Components/NavBar/NavBar';
import { Outlet } from 'react-router';
import { UserProvider } from './Context/AuthContext';

function App() {
  
  return (
    <>
      <UserProvider>
      <NavBar />
      <Outlet />
      </UserProvider>
    </>
  );
}

export default App;
