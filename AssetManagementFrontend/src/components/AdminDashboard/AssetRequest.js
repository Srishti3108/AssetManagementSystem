import React, { useEffect, useState } from "react";
import axios from "axios";

const AssetRequests = () => {
  const [requests, setRequests] = useState([]);

  useEffect(() => {
    const fetchRequests = async () => {
      try {
        const res = await axios.get("https://localhost:7107/api/AssetServiceRequests");
        setRequests(res.data);
      } catch (error) {
        console.error("Error fetching requests:", error);
      }
    };
    fetchRequests();
  }, []);

  return (
    <div className="container mt-4">
      <h2>Asset Requests</h2>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>ID</th>
            <th>Asset</th>
            <th>Employee</th>
            <th>Issue</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {requests.map((request) => (
            <tr key={request.requestId}>
              <td>{request.requestId}</td>
              <td>{request.assetId}</td>
              <td>{request.employeeId}</td>
              <td>{request.issueType}</td>
              <td>{request.status}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default AssetRequests;
