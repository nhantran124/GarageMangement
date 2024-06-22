import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllAccessDetails = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/accessDetails`);
    return res?.data;
};

export const getAccessDetailsById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/accessDetails/${id}`);
};

export const createAccessDetails = async (accessDetails: any) => {
    return await axios.post(`${apiBaseUrl}/api/accessDetails`, accessDetails);
};

export const updateAccessDetails = async (accessDetails: any) => {
    return await axios.put(`${apiBaseUrl}/api/accessDetails`, accessDetails);
};

export const deleteAccessDetails = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/accessDetails/${id}`);
};