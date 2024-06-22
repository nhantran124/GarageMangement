import React, { useEffect, useState } from 'react';
import CustomerForm from './CustomerForm';
import CustomerList from './CustomerList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';
import { createCustomer, deleteCustomer, getAllCustomer, updateCustomer } from '../../../api/customer';

const CustomerManagement: React.FC = () => {
    const [customerList, setCustomerList] = useState([]);
    const [selectedCustomer, setSelectedCustomer] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchCustomerList();
    }, []);


    useEffect(() => {
        const handleKeyDown = (event: KeyboardEvent) => {
            if (event.key === 'Escape') {
                setShowForm(false);
            }
        };

        document.addEventListener('keydown', handleKeyDown);
        return () => {
            document.removeEventListener('keydown', handleKeyDown);
        };
    }, []);
    const fetchCustomerList = async () => {
        const response = await getAllCustomer();
        setCustomerList(response);
    };
    const handleCreateCustomer = async (customer: Partial<{}>) => {
        await createCustomer(customer);
        fetchCustomerList();
        setShowForm(false); 
    };
    const handleUpdateCustomer = async (customer: {}) => {
        await updateCustomer(customer);
        fetchCustomerList();
        setShowForm(false); 
    };
    const handleDeleteCustomer = async (id: string) => {
        await deleteCustomer(id);
        fetchCustomerList();
    };
    

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                    <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                            {selectedCustomer ? `ID: ${selectedCustomer.customerId}` : "THÊM KHÁCH HÀNG"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:text-green-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <CustomerForm 
                            initialData={selectedCustomer || {}} 
                            onSubmit={selectedCustomer ? handleUpdateCustomer : handleCreateCustomer} 
                        />
                    </div>
                </div>
            )}
            <CustomerList 
                customerList={customerList} 
                onEdit={(customer: any) => {
                    setSelectedCustomer(customer);
                    setShowForm(true);
     
                }} 
                onDelete={handleDeleteCustomer} 
                setSelectedCustomer={setSelectedCustomer} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default CustomerManagement;
