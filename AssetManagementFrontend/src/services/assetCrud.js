import React, { useState, useEffect } from 'react';
import { addAsset, getAssets, getAssetById, updateAsset, deleteAsset, searchAssetsByName } from './assetService';

const AssetCRUD = () => {
  const [assets, setAssets] = useState([]);
  const [assetName, setAssetName] = useState('');
  const [searchTerm, setSearchTerm] = useState('');
  const [selectedAsset, setSelectedAsset] = useState(null);

  useEffect(() => {
    fetchAssets();
  }, []);

  const fetchAssets = async () => {
    try {
      const result = await getAssets();
      setAssets(result);
    } catch (error) {
      console.error('Error fetching assets:', error);
    }
  };

  const handleAddAsset = async (e) => {
    e.preventDefault();
    const newAsset = {
      assetName: assetName,
      // Add other fields as required for your Asset object
    };
    try {
      await addAsset(newAsset);
      fetchAssets(); // Refresh asset list after adding
    } catch (error) {
      console.error('Error adding asset:', error);
    }
  };

  const handleUpdateAsset = async (e) => {
    e.preventDefault();
    if (selectedAsset) {
      try {
        await updateAsset(selectedAsset);
        fetchAssets(); // Refresh asset list after updating
      } catch (error) {
        console.error('Error updating asset:', error);
      }
    }
  };

  const handleDeleteAsset = async (id) => {
    try {
      await deleteAsset(id);
      fetchAssets(); // Refresh asset list after deleting
    } catch (error) {
      console.error('Error deleting asset:', error);
    }
  };

  const handleSearch = async () => {
    try {
      const result = await searchAssetsByName(searchTerm);
      setAssets(result);
    } catch (error) {
      console.error('Error searching assets:', error);
    }
  };

  const handleSelectAsset = (asset) => {
    setSelectedAsset(asset);
    setAssetName(asset.assetName); // Populate form with asset details
  };

  return (
    <div>
      <h1>Asset Management</h1>

      {/* Add Asset */}
      <form onSubmit={handleAddAsset}>
        <input
          type="text"
          value={assetName}
          onChange={(e) => setAssetName(e.target.value)}
          placeholder="Asset Name"
        />
        <button type="submit">Add Asset</button>
      </form>

      {/* Search Assets */}
      <input
        type="text"
        value={searchTerm}
        onChange={(e) => setSearchTerm(e.target.value)}
        placeholder="Search by Name"
      />
      <button onClick={handleSearch}>Search</button>

      {/* Asset List */}
      <ul>
        {assets.map((asset) => (
          <li key={asset.assetId}>
            {asset.assetName}
            <button onClick={() => handleSelectAsset(asset)}>Edit</button>
            <button onClick={() => handleDeleteAsset(asset.assetId)}>Delete</button>
          </li>
        ))}
      </ul>

      {/* Update Asset Form */}
      {selectedAsset && (
        <div>
          <h2>Edit Asset</h2>
          <form onSubmit={handleUpdateAsset}>
            <input
              type="text"
              value={selectedAsset.assetName}
              onChange={(e) =>
                setSelectedAsset({ ...selectedAsset, assetName: e.target.value })
              }
            />
            <button type="submit">Update Asset</button>
          </form>
        </div>
      )}
    </div>
  );
};

export default AssetCRUD;
