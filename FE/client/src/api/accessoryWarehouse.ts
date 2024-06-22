import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllAccessoryWarehouse = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/accessoryWarehouse`);
    return res?.data;
};

export const getAccessoryWarehouseById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/accessoryWarehouse/${id}`);
};

export const createAccessoryWarehouse = async (accessoryWarehouse: any) => {
    return await axios.post(`${apiBaseUrl}/api/accessoryWarehouse`, accessoryWarehouse);
};

export const updateAccessoryWarehouse = async (accessoryWarehouse: any) => {
    return await axios.put(`${apiBaseUrl}/api/accessoryWarehouse`, accessoryWarehouse);
};

export const deleteAccessoryWarehouse = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/accessoryWarehouse/${id}`);
};