import './App.css';
import NavBar from './Components/NavBar/NavBar';
import { Outlet } from 'react-router';

function App() {
  
  return (
    <div className="App">
      <NavBar />
      <Outlet />
    </div>
  );
}

export default App;
