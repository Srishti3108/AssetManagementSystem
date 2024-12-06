import React from "react";
import { useNavigate } from "react-router-dom";

const Header = () => {
  const navigate = useNavigate();

  const handleLogout = () => {
    localStorage.removeItem("token"); // Clear token
    localStorage.removeItem("role"); // Clear role if stored
    navigate("/login"); // Redirect to login page
  };

  return (
    <header >
      {/*<h3>Dashboard</h3>
      <button className="btn btn-danger" onClick={handleLogout}>
        Logout
      </button>*/}
    </header>
  );
};

export default Header;
