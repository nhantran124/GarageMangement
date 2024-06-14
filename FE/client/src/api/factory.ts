import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllFactory = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/factory`);
    return res?.data;
};

export const getFactoryById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/factory/${id}`);
};

export const createFactory = async (factory: any) => {
    return await axios.post(`${apiBaseUrl}/api/factory`, factory);
};

export const updateFactory = async (factory: any) => {
    return await axios.put(`${apiBaseUrl}/api/factory`, factory);
};

export const deleteFactory = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/factory/${id}`);
};
