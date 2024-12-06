import React, { useEffect, useState } from "react";
import axios from "axios";

const AdminHome = () => {
  const [metrics, setMetrics] = useState({ employees: 0, assets: 0, requests: 0 });

  useEffect(() => {
    const fetchMetrics = async () => {
      try {
        const [employeesRes, assetsRes, requestsRes] = await Promise.all([
          axios.get("https://localhost:7107/api/Employees"),
          axios.get("https://localhost:7107/api/Assets"),
          axios.get("https://localhost:7107/api/AssetServiceRequests"),
        ]);
        setMetrics({
          employees: employeesRes.data.length,
          assets: assetsRes.data.length,
          requests:requestsRes.data.length,
          
        });
      } catch (error) {
        console.error("Error fetching metrics:", error);
      }
    };
    fetchMetrics();
  }, []);

  return (
    <div className="container mt-4">
      <h2>Admin Dashboard</h2>
      <div className="row">
        <div className="col-md-4">
          <div className="card bg-info text-white">
            <div className="card-body">
              <h5>Total Employees</h5>
              <h3>{metrics.employees}</h3>
            </div>
          </div>
        </div>
        <div className="col-md-4">
          <div className="card bg-success text-white">
            <div className="card-body">
              <h5>Total Assets</h5>
              <h3>{metrics.assets}</h3>
            </div>
          </div>
        </div>
        <div className="col-md-4">
          <div className="card bg-warning text-white">
            <div className="card-body">
              <h5>Pending Requests</h5>
              <h3>{metrics.requests}</h3>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AdminHome;
