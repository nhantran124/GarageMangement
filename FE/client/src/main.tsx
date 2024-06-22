import React from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter as Router, Routes, Route, useLocation } from 'react-router-dom'; 
import Header from './layouts/Header';
import './App.css';
import './index.css';
import LoginPage from './components/LoginPage';
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
import CustomerManagement from './pages/CategoryManagement/CustomerManagement/CustomerManagement';
import SparePartsMangement from './pages/MerchandiseManagement/SparePartsMangement/SparePartsMangement';
import SparePartsDetailsMangement from './pages/MerchandiseManagement/SparePartsDetailsMangement/SparePartsDetailsMangement';
import InboundManagement from './pages/MerchandiseManagement/InboundManagement/InboundManagement';
import AccessoryWarehouseManagement from './pages/MerchandiseManagement/AccessoryWarehouseManagement/AccessoryWarehouseManagement';
import RoleDetailsManagement from './pages/AuthorizationManagement/RoleManagement/RoleDetailsManagement';
import PermissionDetailsManagement from './pages/AuthorizationManagement/PermissionManagement/PermissionDetailsManagement';
import AccessDetailsManagement from './pages/AuthorizationManagement/AccessManagement/AccessDetailsManagement';

const AppContent = () => {
  const location = useLocation();
  const isLoginPage = location.pathname === '/';

  return (
    <div className="modal-overlay">
      {!isLoginPage && <Header />}
      <div className="flex modal-content">
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
          <Route path="/admin/customer-management" element={<CustomerManagement />} />
          <Route path="/admin/spareparts-management" element={<SparePartsMangement />} />
          <Route path="/admin/sparepartsdetails-management" element={<SparePartsDetailsMangement />} />
          <Route path="/admin/inbound-management" element={<InboundManagement />} />
          <Route path="/admin/accessorywarehouse-management" element={<AccessoryWarehouseManagement/>} />
          <Route path="/admin/Role-management" element={<RoleDetailsManagement/>} />
          <Route path="/admin/permission-management" element={<PermissionDetailsManagement />} />
          <Route path="/admin/access-management" element={<AccessDetailsManagement />} />
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
