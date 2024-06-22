import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { FaCheckCircle, FaExclamationCircle } from 'react-icons/fa';
import backgroundImage from '../assets/basic-bg.jpeg';
import garageLogo from '../assets/garage-logo.png';
import { apiBaseUrl } from '../api/api';

const LoginPage: React.FC = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState('');
    const navigate = useNavigate();

    const handleLogin = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);

        try {
            const response = await fetch(`${apiBaseUrl}/api/staff/login`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ username, password }),
            });

            const data = await response.json();

            if (response.ok) {
                // Store the token in localStorage
                localStorage.setItem('token', data.token);
                // Show success message
                toast.success('Login Success', {
                    icon: <FaCheckCircle color='green'/>,
                    autoClose: 2000
                });
                // Redirect to a protected page or refresh the page after a short delay
                setTimeout(() => {
                    navigate('admin/staff-management');
                }, 2000);
            } else {
                setError(data.message || 'Login failed. Please try again.');
                // Show error message
                toast.error(data.message || 'Login failed. Please try again.', {
                    icon: <FaExclamationCircle color='red' />,
                    autoClose: 2000
                });
            }
        } catch (error) {
            setError('Login failed. Please try again.');
            toast.error('Login failed. Please try again.', {
                icon: <FaExclamationCircle color='red'/>,
            });
        } finally {
            setLoading(false);
        }
    };

    return (
        <div
            className="flex justify-center items-center h-screen z-30"
            style={{ backgroundImage: `url(${backgroundImage})`, backgroundSize: 'cover', backgroundPosition: 'center' }}
        >
            <div className="hidden lg:block lg:w-1/4 overflow-hidden">
                <img src={garageLogo} alt="Garage Logo" className="object-cover" />
            </div>
            <div className="w-full lg:w-1/3 px-4">
                <div className="dark:bg-neutral-800 shadow-md rounded-lg px-8 pt-6 pb-8 mx-auto max-w-md">
                    <h2 className="text-3xl font-bold mb-6 flex justify-center text-white">Garage Management Login</h2>
                    {error && <div className="text-red-500 mb-4">{error}</div>}
                    <form onSubmit={handleLogin}>
                        <div className="mb-4">
                            <label className="block text-gray-200 text-sm font-bold mb-2" htmlFor="username">
                                Username
                            </label>
                            <input
                                className="shadow appearance-none border rounded w-full py-3 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline bg-neutral-800 border-gray-600 placeholder-gray-500 text-white"
                                id="username"
                                type="text"
                                placeholder="Enter your username"
                                value={username}
                                onChange={(e) => setUsername(e.target.value)}
                                disabled={loading}
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
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                disabled={loading}
                            />
                        </div>
                        <div className="flex items-center justify-between">
                            <button
                                className="mt-2 text-white font-bold py-3 px-4 rounded w-full focus:outline-none focus:shadow-outline bg-gradient-to-r from-orange-500 via-red-500 via-pink-500 to-purple-500 hover:from-orange-600 hover:via-red-600 hover:to-pink-600 transition-colors duration-300"
                                type="submit"
                                disabled={loading}
                            >
                                {loading ? (
                                    <svg
                                        className="animate-spin h-5 w-5 text-white mx-auto"
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="none"
                                        viewBox="0 0 24 24"
                                    >
                                        <circle
                                            className="opacity-25"
                                            cx="12"
                                            cy="12"
                                            r="10"
                                            stroke="currentColor"
                                            strokeWidth="4"
                                        ></circle>
                                        <path
                                            className="opacity-75"
                                            fill="currentColor"
                                            d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4z"
                                        ></path>
                                    </svg>
                                ) : (
                                    'Login'
                                )}
                            </button>
                        </div>
                    </form>
                </div>
            </div>
            <ToastContainer />
        </div>
    );
};

export default LoginPage;