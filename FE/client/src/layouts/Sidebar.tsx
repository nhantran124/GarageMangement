import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {
  faChevronDown,
  faUsers,
  faBuilding,
  faTruck,
  faShieldAlt,
  faCar,
  faKey,
  faClipboardCheck,
  faInfoCircle,
  faCog,
  faBars,
  faCubesStacked,
  faUserSecret,
} from '@fortawesome/free-solid-svg-icons';
import { Link } from 'react-router-dom';
import './views.css';

const Sidebar: React.FC = () => {
  const userInfo = {
    name: "John Doe",
    role: "Admin",
    avatarUrl: "avatar.jpg",
  };

  const [isDropdownOpen, setIsDropdownOpen] = useState(false);
  const [isSubDropdownOpen, setIsSubDropdownOpen] = useState(false);

  const toggleDropdown = () => {
    setIsDropdownOpen(!isDropdownOpen);
    if (isSubDropdownOpen) {
      setIsSubDropdownOpen(false);
    }
  };

  const toggleSubDropdown = () => {
    setIsSubDropdownOpen(!isSubDropdownOpen);
    if (isDropdownOpen) {
      setIsDropdownOpen(false);
    }
  };
 
  return (
    <nav className="bg-neutral-800 text-white w-[270px] min-h-screen fixed flex-shrink-0 pt-[87px] h-full top-0 left-0 z-10 overflow-y-auto">
      <div className="p-4 flex items-center">
        <div className="mr-4 mt-20">
          <img className="w-12 h-12 rounded-full" src={userInfo.avatarUrl} alt="Avatar" />
        </div>
        <div>
          <h2 className="text-xl font-bold">{userInfo.name}</h2>
          <p className="text-sm text-gray-400">{userInfo.role}</p>
        </div>
      </div>
      <div className="p-4">
        <ul className="flex flex-col">
          <li className="px-4 py-2 mb-6 rounded-full relative">
            <button
              className="block text-gray-300 hover:text-white hover:bg-violet-400 rounded-full py-2 px-2 flex items-center justify-between w-full"
              onClick={toggleDropdown}
            >
              <FontAwesomeIcon icon={faBars} className="h-5 w-4 mr-2 ml-2" />Quản lý danh mục{' '}
              <FontAwesomeIcon
                icon={faChevronDown}
                className={`h-5 w-4 transform transition-transform duration-300 ${
                  isDropdownOpen ? 'rotate-180' : ''
                }`} 
              />
            </button>
            {isDropdownOpen && (
              <ul className="bg-neutral-600 text-white rounded-lg shadow-lg z-20 mt-1 animate-slide-down">
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faUsers} className="h-5 w-5 mr-2" /> Quản lý phân quyền
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faBuilding} className="h-5 w-5 mr-2" />
                  <Link to="/admin/department-management" className="flex-grow"> Quản lý bộ phận</Link>
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faUsers} className="h-5 w-5 mr-2" /> 
                  <Link to="/admin/staff-management" className="flex-grow"> Quản lý nhân viên</Link>
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faBuilding} className="h-5 w-5 mr-2" />
                  <Link to="/admin/supplier-management" className="flex-grow"> Quản lý NCC </Link>
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faCog} className="h-5 w-5 mr-2" />
                  <Link to="/admin/factory-management" className="flex-grow"> Quản lý xưởng </Link>
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faCar} className="h-5 w-5 mr-2" /> 
                  <Link to="/admin/vehicle-management" className="flex-grow"> Quản lý loại xe </Link>
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faKey} className="h-5 w-5 mr-2" /> 
                  <Link to="/admin/vehicle-details-management" className="flex-grow"> Quản lý xe ra vào </Link>
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faClipboardCheck} className="h-5 w-5 mr-2" /> 
                  <Link to="/admin/business-management" className="flex-grow"> Quản lý công việc </Link>
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faShieldAlt} className="h-5 w-5 mr-2" /> 
                  <Link to="/admin/insurance-management" className="flex-grow"> Quản lý bảo hiểm </Link>
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center  text-sm">
                  <FontAwesomeIcon icon={faInfoCircle} className="h-5 w-5 mr-2" />
                  <Link to="/admin/company-management" className="flex-grow"> Thông tin CT </Link>
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center  text-sm">
                  <FontAwesomeIcon icon={faUserSecret} className="h-5 w-5 mr-2" /> Thông tin KH
                </li>
              </ul>
            )}
          </li>
          <li className="px-4 py-2 mb-6 rounded-full relative">
            <button
              className="block text-gray-300 hover:text-white hover:bg-violet-400 rounded-full py-2 px-2 flex items-center justify-between w-full"
              onClick={toggleSubDropdown}
            >
              <FontAwesomeIcon icon={faCubesStacked} className="h-5 w-4 mr-2 ml-2" />Quản lý nhập hàng{' '}
              <FontAwesomeIcon
                icon={faChevronDown}
                className={`h-5 w-4 transform transition-transform duration-300 ${
                  isSubDropdownOpen ? 'rotate-180' : ''
                }`}
              />
            </button>
            {isSubDropdownOpen && (
              <ul className="bg-neutral-600 text-white rounded-lg shadow-lg z-20 mt-1 animate-slide-down">
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faTruck} className="h-5 w-5 mr-2" /> Quản lý phụ tùng
                </li>
                <li className="py-5 px-4 hover:bg-violet-400 rounded-full flex items-center text-sm">
                  <FontAwesomeIcon icon={faTruck} className="h-5 w-5 mr-2" /> Quản lý loại phụ tùng
                </li>
              </ul>
            )}
          </li>
          <li
            className={`px-4 py-2 mb-6 rounded-full transition-all duration-500 ${
              isDropdownOpen || isSubDropdownOpen ? 'mt-4' : ''
            }`}
          >
            <a
              href="#"
              className="block text-gray-300 hover:text-white hover:bg-violet-400 rounded-full py-2 px-4 flex items-center"
            >
              <FontAwesomeIcon icon={faCog} className="h-5 w-5 mr-2" /> Quản lý bảo dưỡng
            </a>
          </li>
        </ul>
      </div>
    </nav>
  );
};

export default Sidebar;
