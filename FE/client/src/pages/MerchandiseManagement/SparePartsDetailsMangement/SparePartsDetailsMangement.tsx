import React, { useEffect, useState } from 'react';
import SparePartsDetailsForm from './SparePartsDetailsForm';
import SparePartsDetailsList from './SparePartsDetailsList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';
import { createSparePartsDetails, deleteSparePartsDetails, getAllSparePartsDetails, updateSparePartsDetails } from '../../../api/sparepartsdetails';

const SparePartsDetailsManagement: React.FC = () => {
    const [sparePartsDetailsList, setSparePartsDetailsList] = useState([]);
    const [selectedSparePartsDetails, setSelectedSparePartsDetails] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchSparePartsDetailsList();
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
    const fetchSparePartsDetailsList = async () => {
        const response = await getAllSparePartsDetails();
        setSparePartsDetailsList(response);
    };
    const handleCreateSparePartsDetails = async (sparePartsDetails: Partial<{}>) => {
        await createSparePartsDetails(sparePartsDetails);
        fetchSparePartsDetailsList();
        setShowForm(false); 
    };
    const handleUpdateSparePartsDetails = async (sparePartsDetails: {}) => {
        await updateSparePartsDetails(sparePartsDetails);
        fetchSparePartsDetailsList();
        setShowForm(false); 
    };
    const handleDeleteSparePartsDetails = async (id: string) => {
        await deleteSparePartsDetails(id);
        fetchSparePartsDetailsList();
    };
    

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                    <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                            {selectedSparePartsDetails ? `ID: ${selectedSparePartsDetails.SparePartsDetailsId}` : "THÊM PHỤ TÙNG"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:text-green-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <SparePartsDetailsForm 
                            initialData={selectedSparePartsDetails || {}} 
                            onSubmit={selectedSparePartsDetails ? handleUpdateSparePartsDetails : handleCreateSparePartsDetails} 
                        />
                    </div>
                </div>
            )}
            <SparePartsDetailsList 
                sparePartsDetailsList={sparePartsDetailsList} 
                onEdit={(sparepartdetails: any) => {
                    setSelectedSparePartsDetails(sparepartdetails);
                    setShowForm(true);
     
                }} 
                onDelete={handleDeleteSparePartsDetails} 
                setSelectedSparePartsDetails={setSelectedSparePartsDetails} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default SparePartsDetailsManagement;
