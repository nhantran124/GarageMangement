import React, { useEffect, useState } from 'react';
import { createRoleDetails, getAllRoleDetails, updateRoleDetails, deleteRoleDetails } from '../../../api/role';
import RoleDetailsForm from './RoleDetailsForm';
import RoleDetailsList from './RoleDetailsList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';

const RoleDetailsManagement: React.FC = () => {
    const [roleDetailsList, setRoleDetailsList] = useState<any[]>([]);
    const [selectedRoleDetails, setSelectedRoleDetails] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchRoleDetailsList();
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

    const fetchRoleDetailsList = async () => {
        const response = await getAllRoleDetails();
        setRoleDetailsList(response);
    };

    const handleCreateRoleDetails = async (roleDetails: Partial<{}>) => {

    try {
        const response = await createRoleDetails(roleDetails);
        fetchRoleDetailsList();
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

    const handleUpdateRoleDetails = async (roleDetails: {}) => {
        await updateRoleDetails(roleDetails);
        fetchRoleDetailsList();
        setShowForm(false); // Hide form after updating RoleDetails
    };

    const handleDeleteRoleDetails = async (id: string) => {
        await deleteRoleDetails(id);
        fetchRoleDetailsList();
    };

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                        <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                                {selectedRoleDetails ? `ID: ${selectedRoleDetails.roleId}` : "THÊM QUYỀN"}
                            </div>
                            <button     
                                className="text-white text-2xl hover:green-red-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <RoleDetailsForm 
                            initialData={selectedRoleDetails || {}} 
                            onSubmit={selectedRoleDetails ? handleUpdateRoleDetails : handleCreateRoleDetails} 
                        />
                    </div>
                </div>
            )}
            <RoleDetailsList 
                roleDetailsList={roleDetailsList} 
                onEdit={(roleDetails: any) => {
                    setSelectedRoleDetails(roleDetails);
                    setShowForm(true);
                }} 
                onDelete={handleDeleteRoleDetails} 
                setSelectedRoleDetails={setSelectedRoleDetails} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default RoleDetailsManagement;
