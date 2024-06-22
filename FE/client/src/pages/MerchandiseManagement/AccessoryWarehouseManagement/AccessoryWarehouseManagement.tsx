import React, { useEffect, useState } from 'react';
import { createAccessoryWarehouse, getAllAccessoryWarehouse, updateAccessoryWarehouse, deleteAccessoryWarehouse } from '../../../api/accessoryWarehouse';
import AccessoryWarehouseForm from './AccessoryWarehouseForm';
import AccessoryWarehouseList from './AccessoryWarehouseList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';

const AccessoryWarehouseManagement: React.FC = () => {
    const [accessoryWarehouseList, setAccessoryWarehouseList] = useState<any[]>([]);
    const [selectedAccessoryWarehouse, setSelectedAccessoryWarehouse] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchAccessoryWarehouseList();
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

    const fetchAccessoryWarehouseList = async () => {
        const response = await getAllAccessoryWarehouse();
        setAccessoryWarehouseList(response);
    };

    const handleCreateAccessoryWarehouse = async (accessoryWarehouse: Partial<{}>) => {
        console.log('Creating accessory warehouse with data:', accessoryWarehouse); // Thêm logging
    try {
        const response = await createAccessoryWarehouse(accessoryWarehouse);
        fetchAccessoryWarehouseList();
        setShowForm(false);
    } catch (error: any) {
        if (error.response) {
            console.error('Error data:', error.response.data);
            console.error('Error status:', error.response.status);
            console.error('Error headers:', error.response.headers);
        } else {
            console.error('Error message:', error.message);
        }
    }
    };

    const handleUpdateAccessoryWarehouse = async (accessoryWarehouse: {}) => {
        await updateAccessoryWarehouse(accessoryWarehouse);
        fetchAccessoryWarehouseList();
        setShowForm(false); // Hide form after updating AccessoryWarehouse
    };

    const handleDeleteAccessoryWarehouse = async (id: string) => {
        await deleteAccessoryWarehouse(id);
        fetchAccessoryWarehouseList();
    };

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                        <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                                {selectedAccessoryWarehouse ? `ID: ${selectedAccessoryWarehouse.supplierSparePartId}` : "THÊM PHỤ TÙNG KHO"}
                            </div>
                            <button     
                                className="text-white text-2xl hover:green-red-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <AccessoryWarehouseForm 
                            initialData={selectedAccessoryWarehouse || {}} 
                            onSubmit={selectedAccessoryWarehouse ? handleUpdateAccessoryWarehouse : handleCreateAccessoryWarehouse} 
                        />
                    </div>
                </div>
            )}
            <AccessoryWarehouseList 
                accessoryWarehouseList={accessoryWarehouseList} 
                onEdit={(accessoryWarehouse: any) => {
                    setSelectedAccessoryWarehouse(accessoryWarehouse);
                    setShowForm(true);
                }} 
                onDelete={handleDeleteAccessoryWarehouse} 
                setSelectedAccessoryWarehouse={setSelectedAccessoryWarehouse} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default AccessoryWarehouseManagement;
