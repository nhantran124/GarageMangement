import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllVehicleDetails = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/vehicledetails`);
    return res?.data;
};

export const getVehicleDetailsById = async (id: string) => {
    const res = await axios.get(`${apiBaseUrl}/api/vehicledetails/${id}`);
    return res?.data;
};

export const createVehicleDetails = async (vehicledetails: any) => {
    const res = await axios.post(`${apiBaseUrl}/api/vehicledetails`, vehicledetails);
    return res?.data;
};

export const updateVehicleDetails = async (vehicledetails: any) => {
    const res = await axios.put(`${apiBaseUrl}/api/vehicledetails`, vehicledetails);
    return res?.data;
};

export const deleteVehicleDetails = async (id: string) => {
    const res = await axios.delete(`${apiBaseUrl}/api/vehicledetails/${id}`);
    return res?.data;
};
