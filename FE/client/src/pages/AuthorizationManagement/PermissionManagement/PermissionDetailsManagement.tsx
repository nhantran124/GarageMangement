import React, { useEffect, useState } from 'react';
import { createPermissionDetails, getAllPermissionDetails, updatePermissionDetails, deletePermissionDetails } from '../../../api/permission';
import PermissionDetailsForm from './PermissionDetailsForm';
import PermissionDetailsList from './PermissionDetailsList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';

const PermissionDetailsManagement: React.FC = () => {
    const [permissionDetailsList, setPermissionDetailsList] = useState<any[]>([]);
    const [selectedPermissionDetails, setSelectedPermissionDetails] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchPermissionDetailsList();
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

    const fetchPermissionDetailsList = async () => {
        const response = await getAllPermissionDetails();
        setPermissionDetailsList(response);
    };

    const handleCreatePermissionDetails = async (permissionDetails: Partial<{}>) => {

    try {
        const response = await createPermissionDetails(permissionDetails);
        fetchPermissionDetailsList();
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

    const handleUpdatePermissionDetails = async (permissionDetails: {}) => {
        await updatePermissionDetails(permissionDetails);
        fetchPermissionDetailsList();
        setShowForm(false); // Hide form after updating PermissionDetails
    };

    const handleDeletePermissionDetails = async (id: string) => {
        await deletePermissionDetails(id);
        fetchPermissionDetailsList();
    };

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                        <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                                {selectedPermissionDetails ? `ID: ${selectedPermissionDetails.permissionId}` : "THÊM QUYỀN"}
                            </div>
                            <button     
                                className="text-white text-2xl hover:green-red-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <PermissionDetailsForm 
                            initialData={selectedPermissionDetails || {}} 
                            onSubmit={selectedPermissionDetails ? handleUpdatePermissionDetails : handleCreatePermissionDetails} 
                        />
                    </div>
                </div>
            )}
            <PermissionDetailsList 
                permissionDetailsList={permissionDetailsList} 
                onEdit={(permissionDetails: any) => {
                    setSelectedPermissionDetails(permissionDetails);
                    setShowForm(true);
                }} 
                onDelete={handleDeletePermissionDetails} 
                setSelectedPermissionDetails={setSelectedPermissionDetails} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default PermissionDetailsManagement;
