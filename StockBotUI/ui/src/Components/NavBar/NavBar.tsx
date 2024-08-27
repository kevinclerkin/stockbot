import { Link } from 'react-router-dom';
import { AuthContext } from '../../Context/AuthContext';

interface Props {}

const NavBar = (props: Props) => {
  const {user, logoutUser, isLoggedIn} = AuthContext();

  
  return (
      <nav className="relative container mx-auto p-6">
        <div className="flex items-center justify-between">
          <div className="flex items-center space-x-20">
            <Link to="/">
            <img src="stockbot-landing-logo.jpg" alt="StockBot" />
            </Link>
            <div className="hidden font-bold lg:flex">
              <Link to="/search" className="text-black hover:text-darkBlue">
                Dashboard
              </Link>
            </div>
          </div>
          {isLoggedIn() ? (
             <div className="hidden lg:flex items-center space-x-6 text-back">
             <div className="hover:text-darkBlue">{user?.email}</div>
             <button
               onClick={() => logoutUser()}
               className="px-8 py-3 font-bold rounded text-white bg-lightGreen hover:opacity-70"
             >
               Logout
             </button>
           </div>
           ) : (
            <div className="hidden lg:flex items-center space-x-6 text-back">
            <Link to="/login" className="hover:text-darkBlue">Login</Link>
            <Link
              to="/register"
              className="px-8 py-3 font-bold rounded text-white bg-lightGreen hover:opacity-70"
            >
              Signup
            </Link>
          </div>
        )}
          </div>
      </nav>
    );
  };

export default NavBar