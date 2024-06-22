import React, { useState } from 'react';
import garageLogo from '../assets/garage-logo.png';
import garageBackground from '../assets/basic-bg.jpeg';
import {faRightFromBracket, faUserLock, faUser} from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { useNavigate } from 'react-router-dom';


const Header: React.FC = () => {
  const [isDropdownOpen, setIsDropdownOpen] = useState(false);
  const navigate = useNavigate();

  const toggleDropdown = () => {
    setIsDropdownOpen(!isDropdownOpen);
  };

  const handleLogout = () => {
    // Xóa token từ localStorage
    localStorage.removeItem('token');
    // Đóng dropdown
    setIsDropdownOpen(false);
    // Chuyển hướng về trang đăng nhập
    navigate('/');
  };

  const handleInfoUser = () => {
    // Xử lý hiển thị thông tin người dùng
   
  };

  const handleChangePassword = () => { 
    // Xử lý thay đổi mật khẩu người dùng

  };
   

  return (
    <header className="bg-zinc-900 text-white px-4 py-5 flex justify-between items-center w-full z-20 fixed top-0 left-0 box-border"
            // style={{
            //   backgroundImage: `url(${garageBackground})`,
            //   backgroundSize: 'cover',
            //   backgroundPosition: 'center', 
            // }}
    >
      <div className="flex items-center">
        <img src={garageLogo} alt="Garage Logo" className="w-12 h-12 rounded-full border-2 border-white object-cover" />
        <h2 className='ml-4'>Garage Management</h2>
      </div>
      <div className="relative">
        <button onClick={toggleDropdown} className="focus:outline-none">
          <img
            className="h-8 w-8 rounded-full border-2 border-white"
            src="URL_TO_USER_AVATAR"
            alt="User Avatar"
          />
        </button>
        {isDropdownOpen && (
          <div className="absolute top-full right-0 mt-2 w-48 bg-white rounded shadow-lg">
            <ul>
              <li>
                <button onClick={handleInfoUser} className="block px-4 py-2 text-gray-800 hover:bg-violet-400 w-full text-left">
                <FontAwesomeIcon icon={faUser}/> Thông tin người dùng
                </button>
                <button onClick={handleInfoUser} className="block px-4 py-2 text-gray-800 hover:bg-violet-400 w-full text-left">
                <FontAwesomeIcon icon={faUserLock}/> Thay đổi mật khẩu
                </button>
                <button onClick={handleLogout} className="block px-4 py-2 text-gray-800 hover:bg-violet-400 w-full text-left">
                <FontAwesomeIcon icon={faRightFromBracket}/> Logout
                </button>
              </li>
            </ul>
          </div>
        )}
      </div>
    </header>
  );
};

export default Header;
