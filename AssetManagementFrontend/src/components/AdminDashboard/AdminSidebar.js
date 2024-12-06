import React from "react";
import { Link } from "react-router-dom";

const AdminSidebar = () => {
  return (
    <div className="sidebar bg-dark text-white vh-100">
      <nav className="nav flex-column p-3">
        <h4 className="mb-4">Admin Dashboard</h4>
        <Link to="/admin/home" className="nav-link text-white">
          Home
        </Link>
        <Link to="/admin/employees" className="nav-link text-white">
          Employee Management
        </Link>
        <Link to="/admin/assets" className="nav-link text-white">
          Asset Management
        </Link>
        <Link to="/admin/requests" className="nav-link text-white">
          Asset Requests
        </Link>
        <Link to ="/login" className="nav-link text-white">Logout</Link>
      </nav>
    </div>
  );
};

export default AdminSidebar;
