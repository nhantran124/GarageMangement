import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllPermissionDetails = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/permissionDetails`);
    return res?.data;
};

export const getPermissionDetailsById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/permissionDetails/${id}`);
};

export const createPermissionDetails = async (permissionDetails: any) => {
    return await axios.post(`${apiBaseUrl}/api/permissionDetails`, permissionDetails);
};

export const updatePermissionDetails = async (permissionDetails: any) => {
    return await axios.put(`${apiBaseUrl}/api/permissionDetails`, permissionDetails);
};

export const deletePermissionDetails = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/permissionDetails/${id}`);
};