import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllCompany = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/company`);
    return res?.data;
};

export const getCompanyById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/company/${id}`);
};

export const createCompany = async (company: any) => {
    return await axios.post(`${apiBaseUrl}/api/company`, company);
};

export const updateCompany = async (company: any) => {
    return await axios.put(`${apiBaseUrl}/api/company`, company);
};

export const deleteCompany = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/company/${id}`);
};
