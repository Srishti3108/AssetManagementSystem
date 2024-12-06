import React, { useState, useEffect } from "react";
import axios from "axios";

const BorrowedAssets = () => {
  const [borrowedAssets, setBorrowedAssets] = useState([]);

  useEffect(() => {
    fetchBorrowings();
  }, []);

  const fetchBorrowings = async () => {
    try {
      const response = await axios.get("https://localhost:7107/api/AssetBorrowings", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("token")}`, // JWT token for secure access
        },
      });
      setBorrowedAssets(response.data);
    } catch (error) {
      console.error("Error fetching borrowed assets:", error);
    }
  };

  return (
    <div>
      <h2>Borrowed Assets</h2>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Borrow ID</th>
            <th>Employee Name</th>
            <th>Asset Name</th>
            <th>Category</th>
            <th>Borrow Date</th>
            <th>Return Date</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {borrowedAssets.map((borrowing) => (
            <tr key={borrowing.borrowId}>
              <td>{borrowing.borrowId}</td>
              <td>{borrowing.employee?.name || "Srishti"}</td>
              <td>{borrowing.asset?.assetName || "Dell"}</td>
              <td>{borrowing.asset?.assetCategory || "Laptop"}</td>
              <td>{new Date(borrowing.borrowDate).toLocaleDateString()}</td>
              <td>{new Date(borrowing.returnDate).toLocaleDateString()}</td>
              <td>{borrowing.status}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BorrowedAssets;
