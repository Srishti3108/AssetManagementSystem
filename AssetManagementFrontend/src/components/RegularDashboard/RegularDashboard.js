import React from "react";
import Header from "../Header";
import RegularSidebar from "./RegularSidebar";
import { Outlet } from "react-router-dom";
import AdminSidebar from "../AdminDashboard/AdminSidebar";

const RegularDashboard = () => {
  return (
    <div className="d-flex">
      <RegularSidebar />
     
      <div className="main-content p-4 w-100">
        <Outlet />
      </div>
    </div>
  );
};

export default RegularDashboard;


{/*import React from "react";
import Header from "../Header";
import RegularSidebar from "./RegularSidebar";
import { Outlet } from "react-router-dom";

const RegularDashboard = () => {
  return (
    <div className="d-flex">
      <RegularSidebar />
      <div className="main-content p-4 w-100">
        <Outlet />
      </div>
    </div>
  );
};

export default RegularDashboard;*/}
