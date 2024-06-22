import React, { useEffect, useState } from 'react';
import { createSparepart, getAllSparepart, updateSparepart, deleteSparepart } from '../../../api/spareparts';
import SparepartsForm from './SparePartsForm';
import SparepartsList from './SparePartsList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';

const SparepartManagement: React.FC = () => {
    const [sparepartList, setSparepartList] = useState<any[]>([]);
    const [selectedSparepart, setSelectedSparepart] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchSparepartList();
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

    const fetchSparepartList = async () => {
        const response = await getAllSparepart();
        setSparepartList(response);
    };

    const handleCreateSparepart = async (sparepart: Partial<{}>) => {
        await createSparepart(sparepart);
        fetchSparepartList();
        setShowForm(false); // Hide form after creating Sparepart
    };

    const handleUpdateSparepart = async (sparepart: {}) => {
        await updateSparepart(sparepart);
        fetchSparepartList();
        setShowForm(false); // Hide form after updating Sparepart
    };

    const handleDeleteSparepart = async (id: string) => {
        await deleteSparepart(id);
        fetchSparepartList();
    };

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                        <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                                {selectedSparepart ? `ID: ${selectedSparepart.sparePartId}` : "THÊM PHỤ TÙNG"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:green-red-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <SparepartsForm 
                            initialData={selectedSparepart || {}} 
                            onSubmit={selectedSparepart ? handleUpdateSparepart : handleCreateSparepart} 
                        />
                    </div>
                </div>
            )}
            <SparepartsList 
                sparepartList={sparepartList} 
                onEdit={(sparepart: any) => {
                    setSelectedSparepart(sparepart);
                    setShowForm(true);
                }} 
                onDelete={handleDeleteSparepart} 
                setSelectedSparepart={setSelectedSparepart} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default SparepartManagement;
