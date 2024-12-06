import axios from 'axios';

// Base URL for your backend API
const API_URL = 'https://localhost:7107/api/Assets';

// Create new asset
export const addAsset = async (asset) => {
  try {
    const response = await axios.post(API_URL, asset);
    return response.data;
  } catch (error) {
    console.error("There was an error adding the asset!", error);
    throw error;
  }
};

// Get all assets
export const getAssets = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error("There was an error fetching the assets!", error);
    throw error;
  }
};

// Get asset by ID
export const getAssetById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`There was an error fetching the asset with id ${id}!`, error);
    throw error;
  }
};

// Update asset
export const updateAsset = async (asset) => {
  try {
    const response = await axios.put(API_URL,asset);  {/*`${API_URL}/${asset.assetId}`, asset);*/}
    return response.data;
  } catch (error) {
    console.error("There was an error updating the asset!", error);
    throw error;
  }
};

// Delete asset
export const deleteAsset = async (id) => {
  try {
    const response = await axios.delete(`${API_URL}?id=${id}`);
    return response.data;
  } catch (error) {
    console.error(`There was an error deleting the asset with id ${id}!`, error);
    throw error;
  }
};

// Search assets by name
export const searchAssetsByName = async (name) => {
  try {
    const response = await axios.get(`${API_URL}/search?name=${name}`);
    return response.data;
  } catch (error) {
    console.error(`There was an error searching for the asset by name ${name}!`, error);
    throw error;
  }
};




{/*import axios from "axios";

const API_URL = "https://localhost:7107/api/Assets"; // Replace with your backend URL

export const getAssets = async () => {
  return axios.get(`${API_URL}/assets`);
};

export const getBorrowings = async () => {
  return axios.get(`${API_URL}/AssetBorrowings`, {
    headers: {
      Authorization: `Bearer ${localStorage.getItem("token")}`,
    },
  });
};
*/}