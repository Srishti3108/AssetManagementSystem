import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Login from './components/Login';
import AdminHome from './components/AdminDashboard/AdminHome';
import RegularHome from './components/RegularDashboard/RegularHome';
import EmployeeManagement from './components/AdminDashboard/EmployeeManagement';
import AssetManagement from './components/AdminDashboard/AssetManagement';
import AssetCatalog from './components/RegularDashboard/AssetCatalog';
import BorrowedAssets from './components/RegularDashboard/BorrowedAssets';

function AppRoutes() {
  return (
    <Routes>
      <Route path="/" element={<Login />} />
      <Route path="/admin" element={<AdminHome />} />
      <Route path="/admin/employees" element={<EmployeeManagement />} />
      <Route path="/admin/assets" element={<AssetManagement />} />
      <Route path="/dashboard" element={<RegularHome />} />
      <Route path="/dashboard/assets" element={<AssetCatalog />} />
      <Route path="/dashboard/borrowed" element={<BorrowedAssets />} />
    </Routes>
  );
}

export default AppRoutes;
