import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllCustomer = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/customer`);
    return res?.data;
};

export const getCustomerById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/customer/${id}`);
};

export const createCustomer = async (customer: any) => {
    return await axios.post(`${apiBaseUrl}/api/customer`, customer);
};

export const updateCustomer = async (customer: any) => {
    return await axios.put(`${apiBaseUrl}/api/customer`, customer);
};

export const deleteCustomer = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/customer/${id}`);
};
