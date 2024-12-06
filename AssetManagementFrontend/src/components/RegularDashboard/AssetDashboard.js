import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";
import Laptop from "../../Assets/Laptop.jpg";
import car from "../../Assets/car.jpg";
import Headphone from "../../Assets/Headphone.jpg";
import House from "../../Assets/House.jpg";
import loan from "../../Assets/loan.jpg";
import Mac from "../../Assets/Mac.jpg";
import Tablet from "../../Assets/Tablet.jpg";
import Mobile from "../../Assets/Mobile.jpg";

const AssetDashboard = () => {
  const [selectedAsset, setSelectedAsset] = useState(null);
  const [userInfo, setUserInfo] = useState({
    name: "",
    email: "",
    reason: "",
  });
  const [showForm, setShowForm] = useState(false);

  // Sample data for assets
  const assets = [
    { id: 1, name: "Laptop", image: Laptop },
    { id: 2, name: "Headphone", image: Headphone },
    { id: 3, name: "Loan", image: loan },
    { id: 4, name: "Tablet", image: Tablet },
    { id: 5, name: "House", image: House },
    { id: 6, name: "Car", image: car },
    { id: 7, name: "Mac", image: Mac },
    { id: 8, name: "Mobile", image: Mobile },
  ];

  // Handle opening the borrow request form
  const handleBorrowRequest = (asset) => {
    setSelectedAsset(asset);
    setShowForm(true);
  };

  // Handle form input changes
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setUserInfo({ ...userInfo, [name]: value });
  };

  // Handle form submission
  const handleSubmit = (e) => {
    e.preventDefault();
    alert(`Request for ${selectedAsset.name} sent successfully!`);
    // Reset form
    setUserInfo({ name: "", email: "", reason: "" });
    setShowForm(false);
  };

  return (
    <div className="container mt-4" style={{ color: "black" }}>
      <h2 className="text-center mb-4">Asset Dashboard</h2>
      <div className="row">
        {assets.map((asset) => (
          <div className="col-md-3 mb-4" key={asset.id}>
            <div className="card shadow-sm">
              <img
                src={asset.image}
                className="card-img-top"
                alt={asset.name}
                style={{ height: "150px", objectFit: "cover" }}
              />
              <div className="card-body text-center" style={{ color: "black" }}>
                <h5 className="card-title">{asset.name}</h5>
                <button
                  className="btn btn-primary"
                  onClick={() => handleBorrowRequest(asset)}
                >
                  Borrow Request
                </button>
              </div>
            </div>
          </div>
        ))}
      </div>

      {/* Borrow Request Form */}
      {showForm && (
        <div className="modal d-block" tabIndex="-1">
          <div className="modal-dialog">
            <div className="modal-content" style={{ color: "black" }}>
              <div className="modal-header">
                <h5 className="modal-title">Borrow Request Form</h5>
                <button
                  type="button"
                  className="btn-close"
                  onClick={() => setShowForm(false)}
                ></button>
              </div>
              <div className="modal-body">
                <p>
                  Requesting to borrow: <strong>{selectedAsset.name}</strong>
                </p>
                <form onSubmit={handleSubmit}>
                  <div className="mb-3">
                    <label htmlFor="name" className="form-label">
                      Your Name
                    </label>
                    <input
                      type="text"
                      className="form-control"
                      id="name"
                      name="name"
                      value={userInfo.name}
                      onChange={handleInputChange}
                      required
                    />
                  </div>
                  <div className="mb-3">
                    <label htmlFor="email" className="form-label">
                      Your Email
                    </label>
                    <input
                      type="email"
                      className="form-control"
                      id="email"
                      name="email"
                      value={userInfo.email}
                      onChange={handleInputChange}
                      required
                    />
                  </div>
                  <div className="mb-3">
                    <label htmlFor="reason" className="form-label">
                      Reason for Borrowing
                    </label>
                    <textarea
                      className="form-control"
                      id="reason"
                      name="reason"
                      rows="3"
                      value={userInfo.reason}
                      onChange={handleInputChange}
                      required
                    ></textarea>
                  </div>
                  <button type="submit" className="btn btn-success">
                    Submit
                  </button>
                </form>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default AssetDashboard;


