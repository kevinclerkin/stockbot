import './App.css';
import NavBar from './Components/NavBar/NavBar';
import { Outlet } from 'react-router';
import { UserProvider } from './Context/AuthContext';

function App() {
  
  return (
    <div className="App">
      <UserProvider>
      <NavBar />
      <Outlet />
      </UserProvider>
    </div>
  );
}

export default App;
