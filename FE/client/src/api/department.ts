import { apiBaseUrl } from './api';
import axios from 'axios';


export const getAllDepartments = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/department`);
    return res?.data;
};

export const getDepartmentById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/department/${id}`);
};

export const createDepartment = async (department: any) => {
    return await axios.post(`${apiBaseUrl}/api/department`, department);
};

export const updateDepartment = async (department: any) => {
    return await axios.put(`${apiBaseUrl}/api/department`, department);
};

export const deleteDepartment = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/department/${id}`);
};
