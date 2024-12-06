import React from "react";
import { Outlet } from "react-router-dom";
import AdminSidebar from "./AdminSidebar";
import Header from "../Header"
const AdminDashboard = () => {
  return (
    <div className="d-flex">
      <AdminSidebar />
     
      <div className="main-content p-4 w-100">
        <Outlet />
      </div>
    </div>
  );
};

export default AdminDashboard;


