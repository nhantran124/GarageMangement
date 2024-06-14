import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllSuppliers = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/supplier`);
    return res?.data;
};

export const getSupplierById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/supplier/${id}`);
};

export const createSupplier = async (supplier: any) => {
    return await axios.post(`${apiBaseUrl}/api/supplier`, supplier);
};

export const updateSupplier = async (supplier: any) => {
    return await axios.put(`${apiBaseUrl}/api/supplier`, supplier);
};

export const deleteSupplier = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/supplier/${id}`);
};
