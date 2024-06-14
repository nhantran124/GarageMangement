import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllVehicles = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/vehicle`);
    return res?.data;
};

export const getVehicleById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/vehicle/${id}`);
};

export const createVehicle = async (vehicle: any) => {
    return await axios.post(`${apiBaseUrl}/api/vehicle`, vehicle);
};

export const updateVehicle = async (vehicle: any) => {
    return await axios.put(`${apiBaseUrl}/api/vehicle`, vehicle);
};

export const deleteVehicle = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/vehicle/${id}`);
};
