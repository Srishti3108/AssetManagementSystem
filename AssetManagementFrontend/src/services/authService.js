import axios from "axios";

const API_URL = "https://localhost:7107/api/Authentication";

export const fetchSecuredData = async (endpoint) => {
  try {
    const response = await axios.get(`${API_URL}/${endpoint}`, {
      headers: {
        Authorization: `Bearer ${localStorage.getItem("token")}`,
      },
    });
    return response.data;
  } catch (error) {
    console.error("Error fetching secured data:", error);
    throw error;
  }
};

export const postSecuredData = async (endpoint, data) => {
  try {
    const response = await axios.post(`${API_URL}/${endpoint}`, data, {
      headers: {
        Authorization: `Bearer ${localStorage.getItem("token")}`,
      },
    });
    return response.data;
  } catch (error) {
    console.error("Error posting secured data:", error);
    throw error;
  }
};

