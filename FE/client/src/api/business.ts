import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllBusiness = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/business`);
    return res?.data;
};

export const getBusinessById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/business/${id}`);
};

export const createBusiness = async (business: any) => {
    return await axios.post(`${apiBaseUrl}/api/business`, business);
};

export const updateBusiness = async (business: any) => {
    return await axios.put(`${apiBaseUrl}/api/business`, business);
};

export const deleteBusiness = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/business/${id}`);
};
