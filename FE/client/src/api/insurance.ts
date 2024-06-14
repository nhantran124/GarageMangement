import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllInsurances = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/insurance`);
    return res?.data;
};

export const getInsuranceById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/insurance/${id}`);
};

export const createInsurance = async (insurance: any) => {
    return await axios.post(`${apiBaseUrl}/api/insurance`, insurance);
};

export const updateInsurance = async (insurance: any) => {
    return await axios.put(`${apiBaseUrl}/api/insurance`, insurance);
};

export const deleteInsurance = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/insurance/${id}`);
};
