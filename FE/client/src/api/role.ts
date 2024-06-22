import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllRoleDetails = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/roleDetails`);
    return res?.data;
};

export const getRoleDetailsById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/roleDetails/${id}`);
};

export const createRoleDetails = async (roleDetails: any) => {
    return await axios.post(`${apiBaseUrl}/api/roleDetails`, roleDetails);
};

export const updateRoleDetails = async (roleDetails: any) => {
    return await axios.put(`${apiBaseUrl}/api/roleDetails`, roleDetails);
};

export const deleteRoleDetails = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/roleDetails/${id}`);
};