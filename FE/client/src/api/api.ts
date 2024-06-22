import axios from "axios";

export const apiBaseUrl = "https://localhost:7522"; // URL của backend API

export const apiClient = axios.create({
    baseURL: apiBaseUrl,
    headers: {
        'Content-Type': 'application/json'
    }
});

apiClient.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('token');
        if (token) {
            config.headers['Authorization'] = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

// Utility function to handle errors
const handleError = (error: unknown): Error => {
    if (axios.isAxiosError(error)) {
        return new Error(error.response?.data?.message || 'Failed to fetch protected data');
    }
    return new Error('An unexpected error occurred');
};

export const fetchProtectedData = async () => {
    try {
        const response = await apiClient.get('/api/protected-endpoint');
        return response.data;
    } catch (error: unknown) {
        throw handleError(error);
    }
};



