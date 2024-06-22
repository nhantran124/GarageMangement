import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllSparepart = async () => {

    const res = await axios.get(`${apiBaseUrl}/api/sparepart`);
    return res?.data;
};

export const getSparepartById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/sparepart/${id}`);
};

export const createSparepart = async (sparepart: any) => {
    return await axios.post(`${apiBaseUrl}/api/sparepart`, sparepart);
};

export const updateSparepart = async (sparepart: any) => {
    return await axios.put(`${apiBaseUrl}/api/sparepart`, sparepart);
};

export const deleteSparepart = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/sparepart/${id}`);
};
