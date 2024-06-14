import React from 'react';
import backgroundImage from '../assets/basic-bg.jpeg';
import garageLogo from '../assets/garage-logo.png';

const LoginPage: React.FC = () => {
    return (
        <div
            className="flex justify-center items-center h-screen z-30"
            style={{ backgroundImage: `url(${backgroundImage})`, backgroundSize: 'cover', backgroundPosition: 'center' }}
        >
            {/* Phần cột chứa logo */}
            <div className="hidden lg:block lg:w-1/4 overflow-hidden">
                <img src={garageLogo} alt="Garage Logo" className="object-cover" />
            </div>
            {/* Phần cột chứa form */}
            <div className="w-full lg:w-1/3 px-4">
                <div className="dark:bg-neutral-800 shadow-md rounded-lg px-8 pt-6 pb-8 mx-auto max-w-md">
                    <h2 className="text-3xl font-bold mb-6 flex justify-center text-white">Garage Management Login</h2>
                    <form>
                        <div className="mb-4">
                            <label className="block text-gray-200 text-sm font-bold mb-2" htmlFor="username">
                                Username
                            </label>
                            <input
                                className="shadow appearance-none border rounded w-full py-3 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline bg-neutral-800 border-gray-600 placeholder-gray-500 text-white"
                                id="username"
                                type="text"
                                placeholder="Enter your username"
                            />
                        </div>
                        <div className="mb-6">
                            <label className="block text-gray-200 text-sm font-bold mb-2" htmlFor="password">
                                Password
                            </label>
                            <input
                                className="shadow appearance-none border rounded w-full py-3 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline bg-neutral-800 border-gray-600 placeholder-gray-500 text-white"
                                id="password"
                                type="password"
                                placeholder="Enter your password"
                            />
                        </div>
                        <div className="flex items-center justify-between">
                            <button
                                className="mt-2 text-white font-bold py-3 px-4 rounded w-full focus:outline-none focus:shadow-outline bg-gradient-to-r from-orange-500 via-red-500 via-pink-500 to-purple-500 hover:from-orange-600 hover:via-red-600 hover:to-pink-600 transition-colors duration-300"
                                type="submit"
                            >
                                Login
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;
