import React, { useState, useEffect } from "react";
import axios from "axios"; // Directly use axios instead of relying on a custom service

const AssetCatalog = () => {
  const [assets, setAssets] = useState([]);

  useEffect(() => {
    fetchAssets();
  }, []);

  const fetchAssets = async () => {
    try {
      const response = await axios.get("https://localhost:7107/api/Assets", {
        headers: {
          Authorization: `Bearer ${localStorage.getItem("token")}`, // Include JWT token if required
        },
      });
      console.log("Response from API:", response.data); // Debugging
      setAssets(response.data);
    } catch (error) {
      console.error("Error fetching assets:", error.response?.data || error.message);
    }
  };

  return (
    <div className="container mt-4">
      <h2>Asset Catalog</h2>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>Asset ID</th>
            <th>Name</th>
            <th>Category</th>
            <th>Model</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {assets.length > 0 ? (
            assets.map((asset) => (
              <tr key={asset.assetId}>
                <td>{asset.assetId}</td>
                <td>{asset.assetName}</td>
                <td>{asset.assetCategory}</td>
                <td>{asset.assetModel}</td>
                <td>{asset.status}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="5" className="text-center">
                No assets available.
              </td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
};

export default AssetCatalog;
