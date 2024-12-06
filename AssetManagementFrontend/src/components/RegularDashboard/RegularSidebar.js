import React from "react";
import { Link } from "react-router-dom";
import { Outlet } from "react-router-dom";


const RegularSidebar = () => {
  return (
    <div className="sidebar bg-dark text-white vh-100">
      <nav className="nav flex-colnumn p-3">
      <h4 className="mb-4">User Dashboard</h4>
        <Link to="/regular/home" className="nav-link text-white">
          Home
        </Link>
        <Link to="/regular/assets" className="nav-link text-white">
           Asset Catalog
        </Link>
        <Link to="/regular/borrowed" className="nav-link text-white">
          Borrowed Assets
        </Link>
        <Link to="/regular/assetdashboard" className="nav-link text-white">
          Asset Dashboard
        </Link>
        <Link to="/login" className="nav-link text-white">
           Logout
        </Link>
      </nav>
      <Outlet/>
    </div>
  );
};

export default RegularSidebar;



{/*import React from "react";
import {Link} from "react-router-dom";
import { Outlet } from "react-router-dom";

const RegularSidebar = () => {
  return (
    <div className="sidebar bg-dark text-white vh-100">
      <nav className="nav flex-column p-3">
        <h4 className="mb-4">User Dashboard</h4>
        <Link to ="/regular/home" className="nav-link text-white">
          Home
        </Link>
        <Link to ="/regular/assets" className="nav-link text-white">
        Asset Catalog
        </Link>
        <Link to ="/regular/borrowed" className="nav-link text-white">
        Borrowed Assets
        </Link>
        <Link to ="/login" className="nav-link text-white">Logout</Link>
        <Outlet></Outlet>
      </nav>
    </div>
  )
};
export default RegularSidebar;*/}

{/*import React from "react";
import { Link, Outlet } from "react-router-dom";

const RegularSidebar = () => {
  return (
    <div className="sidebar bg-dark text-white vh-100">
       <nav className="nav flex-column p-3">
      <h4>User Dashboard</h4>
      <ul className="nav flex-column">
        <li className="nav-item">
          <Link className="nav-link" to="/regular/home">
            Home
          </Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link" to="/regular/assets">
            Asset Catalog
          </Link>
        </li>
        <li className="nav-item">
          <Link className="nav-link" to="/regular/borrowed">
            Borrowed Assets
          </Link>
        </li>

      </ul>
      <Outlet></Outlet>
      </nav>
    </div>
  );
};

export default RegularSidebar;*/}
   