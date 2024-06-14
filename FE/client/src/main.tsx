import React from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter as Router, Routes, Route, useLocation } from 'react-router-dom'; 
import Header from './layouts/Header';
import './index.css';
import LoginPage from './views/LoginPage';
import DepartmentManagement from './pages/CategoryManagement/DepartmentManagement/DepartmentManagement'; 
import Sidebar from './layouts/Sidebar';
import StaffManagement from './pages/CategoryManagement/StaffManagement/StaffMangement';
import SupplierManagement from './pages/CategoryManagement/SupplierManagement/SupplierManagement';
import FactoryManagement from './pages/CategoryManagement/FactoryManagement/FactoryManagement';
import VehicleManagement from './pages/CategoryManagement/VehicleManagement/VehicleManagement';
import VehicleDetailsManagement from './pages/CategoryManagement/VehicleDetailsManagement/VehicleDetailsManagement';
import BusinessManagement from './pages/CategoryManagement/BusinessManagement/BusinessManagement';
import InsuranceManagement from './pages/CategoryManagement/InsuranceManagement/InsuranceManagement';
import CompanyManagement from './pages/CategoryManagement/CompanyManagement/CompanyManagement';

const AppContent = () => {
  const location = useLocation();
  const isLoginPage = location.pathname === '/';

  return (
    <div className="content">
      {!isLoginPage && <Header />}
      <div className="flex">
        {!isLoginPage && <Sidebar />}
        <Routes>
          <Route path="/" element={<LoginPage />} />
          <Route path="/admin/department-management" element={<DepartmentManagement />} />
          <Route path="/admin/staff-management" element={<StaffManagement />} />
          <Route path="/admin/supplier-management" element={<SupplierManagement />} />
          <Route path="/admin/factory-management" element={<FactoryManagement />} />
          <Route path="/admin/vehicle-management" element={<VehicleManagement />} />
          <Route path="/admin/vehicle-details-management" element={<VehicleDetailsManagement />} />
          <Route path="/admin/business-management" element={<BusinessManagement />} />
          <Route path="/admin/insurance-management" element={<InsuranceManagement />} />
          <Route path="/admin/company-management" element={<CompanyManagement />} />
          
          {/* Add other routes here */}
        </Routes>
      </div>
    </div>
  );
};

const rootElement = document.getElementById('root');

if (rootElement) {
  createRoot(rootElement).render(
    <React.StrictMode>
      <Router>
        <AppContent />
      </Router>
    </React.StrictMode>
  );
} else {
  console.error('Failed to find the root element.');
}
