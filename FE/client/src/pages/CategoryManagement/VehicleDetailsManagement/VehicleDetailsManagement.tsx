import React, { useEffect, useState } from 'react';
import VehicleDetailsForm from './VehicleDetailsForm';
import VehicleDetailsList from './VehicleDetailsList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';
import { createVehicleDetails, deleteVehicleDetails, getAllVehicleDetails, updateVehicleDetails } from '../../../api/vehicledetails';

const VehicleDetailsManagement: React.FC = () => {
    const [vehicleDetailsList, setVehicleDetailsList] = useState([]);
    const [selectedVehicleDetails, setSelectedVehicleDetails] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchVehicleDetailsList();
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

    const fetchVehicleDetailsList = async () => {
        const response = await getAllVehicleDetails();
        setVehicleDetailsList(response);
    };

    const handleCreateVehicleDetails = async (vehicledetails: Partial<{}>) => {
        await createVehicleDetails(vehicledetails);
        fetchVehicleDetailsList();
        setShowForm(false); 
    };

    const handleUpdateVehicleDetails = async (vehicledetails: {}) => {
        await updateVehicleDetails(vehicledetails);
        fetchVehicleDetailsList();
        setShowForm(false); 
    };  

    const handleDeleteVehicleDetails = async (id: string) => {
        await deleteVehicleDetails(id);
        fetchVehicleDetailsList();
    };

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                        <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                                {selectedVehicleDetails ? `ID: ${selectedVehicleDetails.vehicleId}` : "THÊM XE"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:text-green-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <VehicleDetailsForm 
                            initialData={selectedVehicleDetails || {}} 
                            onSubmit={selectedVehicleDetails ? handleUpdateVehicleDetails : handleCreateVehicleDetails} 
                        />
                    </div>
                </div>
            )}
            <VehicleDetailsList 
                vehicleDetailsList={vehicleDetailsList} 
                onEdit={(vehicledetails: any) => {
                    setSelectedVehicleDetails(vehicledetails);
                    setShowForm(true);
                }} 
                onDelete={handleDeleteVehicleDetails} 
                setSelectedVehicleDetails={setSelectedVehicleDetails} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default VehicleDetailsManagement;
