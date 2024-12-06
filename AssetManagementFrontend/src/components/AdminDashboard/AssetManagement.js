import React, { useEffect, useState } from "react";
import {
  addAsset,
  getAssets,
  updateAsset,
  deleteAsset,
} from "../../services/assetService";

const AssetManagement = () => {
  const [assets, setAssets] = useState([]);
  const [assetForm, setAssetForm] = useState({
    assetId: "",
    assetName: "",
    assetCategory: "",
    assetModel: "",
    manufacturingDate: "",
    expiryDate: "",
    assetValue: "",
    status: "Available",
  });
  const [isEditing, setIsEditing] = useState(false);
  const [searchTerm, setSearchTerm] = useState("");

  // Fetch all assets on component mount
  useEffect(() => {
    fetchAssets();
  }, []);

  const fetchAssets = async () => {
    try {
      const data = await getAssets();
      setAssets(data);
    } catch (error) {
      console.error("Error fetching assets:", error);
    }
  };

  // Handle form input changes
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setAssetForm({ ...assetForm, [name]: value });
  };

  // Add or Update an asset
  const handleSaveAsset = async (e) => {
    e.preventDefault();
    try {
      if (isEditing) {
        // Update the existing asset
        await updateAsset(assetForm);
      } else {
        // Add a new asset
        await addAsset({
          ...assetForm,
          assetId: undefined, // Exclude assetId for new asset creation
        });
      }
      fetchAssets(); // Refresh the asset list
      resetForm();
    } catch (error) {
      console.error("Error saving asset:", error);
    }
  };

  // Delete an asset
  const handleDeleteAsset = async (id) => {
    if (window.confirm("Are you sure you want to delete this asset?")) {
      try {
        await deleteAsset(id);
        fetchAssets(); // Refresh the asset list
      } catch (error) {
        console.error("Error deleting asset:", error);
      }
    }
  };

  // Select an asset for editing
  const handleEditAsset = (asset) => {
    setAssetForm({
      assetId: asset.assetId,
      assetName: asset.assetName,
      assetCategory: asset.assetCategory,
      assetModel: asset.assetModel,
      manufacturingDate: asset.manufacturingDate.split("T")[0], // Format date for input
      expiryDate: asset.expiryDate.split("T")[0], // Format date for input
      assetValue: asset.assetValue,
      status: asset.status,
    });
    setIsEditing(true);
  };

  // Reset the form
  const resetForm = () => {
    setAssetForm({
      assetId: "",
      assetName: "",
      assetCategory: "",
      assetModel: "",
      manufacturingDate: "",
      expiryDate: "",
      assetValue: "",
      status: "Available",
    });
    setIsEditing(false);
  };

  // Filter assets by search term
  const filteredAssets = assets.filter((asset) =>
    asset.assetName.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <div className="container mt-4">
      <h2 className="mb-4 text-center">Asset Management</h2>

      {/* Search */}
      <div className="mb-3">
        <input
          type="text"
          className="form-control"
          placeholder="Search assets by name..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
      </div>

      {/* Asset Form */}
      <form
        onSubmit={handleSaveAsset}
        className="mb-4 p-3 border rounded shadow-sm"
      >
        <h4>{isEditing ? "Edit Asset" : "Add New Asset"}</h4>
        <div className="row">
          <div className="col-md-4">
            <input
              type="text"
              name="assetName"
              className="form-control mb-3"
              placeholder="Asset Name"
              value={assetForm.assetName}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="col-md-4">
            <input
              type="text"
              name="assetCategory"
              className="form-control mb-3"
              placeholder="Category"
              value={assetForm.assetCategory}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="col-md-4">
            <input
              type="text"
              name="assetModel"
              className="form-control mb-3"
              placeholder="Model"
              value={assetForm.assetModel}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="col-md-4">
            <input
              type="date"
              name="manufacturingDate"
              className="form-control mb-3"
              value={assetForm.manufacturingDate}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="col-md-4">
            <input
              type="date"
              name="expiryDate"
              className="form-control mb-3"
              value={assetForm.expiryDate}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="col-md-4">
            <input
              type="number"
              step="0.01"
              name="assetValue"
              className="form-control mb-3"
              placeholder="Value (e.g., 500.00)"
              value={assetForm.assetValue}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="col-md-4">
            <select
              name="status"
              className="form-control mb-3"
              value={assetForm.status}
              onChange={handleInputChange}
              required
            >
              <option value="Available">Available</option>
              <option value="In Use">In Use</option>
              <option value="Expired">Expired</option>
            </select>
          </div>
        </div>
        <button type="submit" className="btn btn-primary me-2">
          {isEditing ? "Update" : "Add"}
        </button>
        {isEditing && (
          <button
            type="button"
            className="btn btn-secondary"
            onClick={resetForm}
          >
            Cancel
          </button>
        )}
      </form>

      {/* Asset Table */}
      <div className="table-responsive">
        <table className="table table-bordered table-hover shadow-sm">
          <thead className="table-primary">
            <tr>
              <th>ID</th>
              <th>Name</th>
              <th>Category</th>
              <th>Model</th>
              <th>Manufacturing Date</th>
              <th>Expiry Date</th>
              <th>Value</th>
              <th>Status</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {filteredAssets.length > 0 ? (
              filteredAssets.map((asset) => (
                <tr key={asset.assetId}>
                  <td>{asset.assetId}</td>
                  <td>{asset.assetName}</td>
                  <td>{asset.assetCategory}</td>
                  <td>{asset.assetModel}</td>
                  <td>{asset.manufacturingDate.split("T")[0]}</td>
                  <td>{asset.expiryDate.split("T")[0]}</td>
                  <td>{asset.assetValue}</td>
                  <td>{asset.status}</td>
                  <td>
                    <button
                      className="btn btn-sm btn-warning me-2"
                      onClick={() => handleEditAsset(asset)}
                    >
                      Edit
                    </button>
                    <button
                      className="btn btn-sm btn-danger"
                      onClick={() => handleDeleteAsset(asset.assetId)}
                    >
                      Delete
                    </button>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan="9" className="text-center">
                  No assets found.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default AssetManagement;


{/*import React, { useEffect, useState } from "react";
import axios from "axios";

const AssetManagement = () => {
  const [assets, setAssets] = useState([]);

  useEffect(() => {
    const fetchAssets = async () => {
      try {
        const res = await axios.get("https://localhost:7107/api/Assets");
        setAssets(res.data);
      } catch (error) {
        console.error("Error fetching assets:", error);
      }
    };
    fetchAssets();
  }, []);

  return (
    <div className="container mt-4">
      <h2>Asset Management</h2>
      <table className="table table-bordered">
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Category</th>
            <th>Model</th>
            <th>Status</th>
          </tr>
        </thead>
        <tbody>
          {assets.map((asset) => (
            <tr key={asset.assetId}>
              <td>{asset.assetId}</td>
              <td>{asset.assetName}</td>
              <td>{asset.assetCategory}</td>
              <td>{asset.assetModel}</td>
              <td>{asset.status}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default AssetManagement;*/}
