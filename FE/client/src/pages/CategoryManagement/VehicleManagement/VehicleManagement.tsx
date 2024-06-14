import React, { useEffect, useState } from 'react';
import VehicleForm from './VehicleForm';
import VehicleList from './VehicleList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';
import { createVehicle, deleteVehicle, getAllVehicles, updateVehicle } from '../../../api/vehicle';

const VehicleManagement: React.FC = () => {
    const [vehicleList, setVehicleList] = useState([]);
    const [selectedVehicle, setSelectedVehicle] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchVehicleList();
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
    const fetchVehicleList = async () => {
        const response = await getAllVehicles();
        setVehicleList(response);
    };
    const handleCreateVehicle = async (vehicle: Partial<{}>) => {
        await createVehicle(vehicle);
        fetchVehicleList();
        setShowForm(false); 
    };
    const handleUpdateVehicle = async (vehicle: {}) => {
        await updateVehicle(vehicle);
        fetchVehicleList();
        setShowForm(false); 
    };
    const handleDeleteVehicle = async (id: string) => {
        await deleteVehicle(id);
        fetchVehicleList();
    };
    

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                    <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                            {selectedVehicle ? `ID: ${selectedVehicle.typeOfVehicleId}` : "THÊM LOẠI XE"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:text-green-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <VehicleForm 
                            initialData={selectedVehicle || {}} 
                            onSubmit={selectedVehicle ? handleUpdateVehicle : handleCreateVehicle} 
                        />
                    </div>
                </div>
            )}
            <VehicleList 
                vehicleList={vehicleList} 
                onEdit={(vehicle: any) => {
                    setSelectedVehicle(vehicle);
                    setShowForm(true);
     
                }} 
                onDelete={handleDeleteVehicle} 
                setSelectedVehicle={setSelectedVehicle} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default VehicleManagement;
