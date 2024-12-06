import React, { useEffect, useState } from "react";
import { fetchSecuredData } from "../services/authService";

const SecuredComponent = () => {
  const [data, setData] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const result = await fetchSecuredData("secured-endpoint"); // Replace with your API endpoint
        setData(result);
      } catch (error) {
        console.error("Failed to fetch secured data", error);
      }
    };

    fetchData();
  }, []);

  return (
    <div>
      <h1>Secured Data</h1>
      <pre>{JSON.stringify(data, null, 2)}</pre>
    </div>
  );
};

export default SecuredComponent;
