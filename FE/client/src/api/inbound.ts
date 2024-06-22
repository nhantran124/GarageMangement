import axios from 'axios';
import { apiBaseUrl } from './api';

export const getAllInbound = async () => {
    const res = await axios.get(`${apiBaseUrl}/api/inbound`);
    return res?.data;
};

export const getInboundById = async (id: string) => {
    return await axios.get(`${apiBaseUrl}/api/inbound/${id}`);
};

export const createInbound = async (inbound: any) => {
    return await axios.post(`${apiBaseUrl}/api/inbound`, inbound);
};

export const updateInbound = async (inbound: any) => {
    return await axios.put(`${apiBaseUrl}/api/inbound`, inbound);
};

export const deleteInbound = async (id: string) => {
    return await axios.delete(`${apiBaseUrl}/api/inbound/${id}`);
};
