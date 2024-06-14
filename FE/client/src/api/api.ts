import axios from "axios";

export const apiBaseUrl = "https://localhost:7522"; // URL của backend API

export const apiClient = axios.create({
    baseURL: apiBaseUrl,
    headers: {
        'Content-Type': 'application/json'
    }
});


