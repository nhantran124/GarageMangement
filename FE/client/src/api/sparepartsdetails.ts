
import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllSparePartsDetails = async () => {

    const res = await axios.get(`${apiBaseUrl}/api/sparepartdetails`);
    return res?.data;
};

export const getSparePartsDetailsById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/sparepartdetails/${id}`);
};

export const createSparePartsDetails = async (sparepartdetails: any) => {
    return await axios.post(`${apiBaseUrl}/api/sparepartdetails`, sparepartdetails);
};

export const updateSparePartsDetails = async (sparepartdetails: any) => {
    return await axios.put(`${apiBaseUrl}/api/sparepartdetails`, sparepartdetails);
};

export const deleteSparePartsDetails = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/sparepartdetails/${id}`);
};
