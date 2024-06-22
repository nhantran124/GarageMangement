import React, { useEffect, useState } from 'react';
import { createAccessDetails, getAllAccessDetails, updateAccessDetails, deleteAccessDetails } from '../../../api/accessdetails';
import AccessDetailsForm from './AccessDetailsForm';
import AccessDetailsList from './AccessDetailsList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';

const AccessDetailsManagement: React.FC = () => {
    const [accessDetailsList, setAccessDetailsList] = useState<any[]>([]);
    const [selectedAccessDetails, setSelectedAccessDetails] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchAccessDetailsList();
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

    const fetchAccessDetailsList = async () => {
        const response = await getAllAccessDetails();
        setAccessDetailsList(response);
    };

    const handleCreateAccessDetails = async (accessDetails: Partial<{}>) => {

    try {
        const response = await createAccessDetails(accessDetails);
        fetchAccessDetailsList();
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

    const handleUpdateAccessDetails = async (accessDetails: {}) => {
        await updateAccessDetails(accessDetails);
        fetchAccessDetailsList();
        setShowForm(false); // Hide form after updating AccessDetails
    };

    const handleDeleteAccessDetails = async (id: string) => {
        await deleteAccessDetails(id);
        fetchAccessDetailsList();
    };

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                        <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                                {selectedAccessDetails ? `ID: ${selectedAccessDetails.accessId}` : "THÊM ĐƯỜNG DẪN"}
                            </div>
                            <button     
                                className="text-white text-2xl hover:green-red-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <AccessDetailsForm 
                            initialData={selectedAccessDetails || {}} 
                            onSubmit={selectedAccessDetails ? handleUpdateAccessDetails : handleCreateAccessDetails} 
                        />
                    </div>
                </div>
            )}
            <AccessDetailsList 
                accessDetailsList={accessDetailsList} 
                onEdit={(accessDetails: any) => {
                    setSelectedAccessDetails(accessDetails);
                    setShowForm(true);
                }} 
                onDelete={handleDeleteAccessDetails} 
                setSelectedAccessDetails={setSelectedAccessDetails} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default AccessDetailsManagement;
