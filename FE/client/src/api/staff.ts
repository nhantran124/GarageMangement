
import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllStaff = async () => {

    const res = await axios.get(`${apiBaseUrl}/api/staff`);
    return res?.data;
};

export const getStaffById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/staff/${id}`);
};

export const createStaff = async (staff: any) => {
    return await axios.post(`${apiBaseUrl}/api/staff`, staff);
};

export const updateStaff = async (staff: any) => {
    return await axios.put(`${apiBaseUrl}/api/staff`, staff);
};

export const deleteStaff = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/staff/${id}`);
};
