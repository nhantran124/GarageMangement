import React, { useEffect, useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';
import { createFactory, getAllFactory, updateFactory, deleteFactory } from '../../../api/factory';
import FactoryForm from './FactoryForm';
import FactoryList from './FactoryList';
const FactoryManagement: React.FC = () => {
    const [factoryList, setFactoryList] = useState<any[]>([]);
    const [selectedFactory, setSelectedFactory] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchFactoryList();
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

    const fetchFactoryList = async () => {
        const response = await getAllFactory();
        setFactoryList(response);
    };

    const handleCreateFactory = async (factory: Partial<{}>) => {
        await createFactory(factory);
        fetchFactoryList();
        setShowForm(false); // Hide form after creating factory
    };

    const handleUpdatefactory = async (factory: {}) => {
        await updateFactory(factory);
        fetchFactoryList();
        setShowForm(false); // Hide form after updating factory
    };

    const handleDeleteFactory = async (id: string) => {
        await deleteFactory(id);
        fetchFactoryList();
    };

    return (
        <div className="relative">  
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                        <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                                {selectedFactory ? `ID: ${selectedFactory.factoryId}` : "THÊM XƯỞNG"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:green-red-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <FactoryForm 
                            initialData={selectedFactory || {}} 
                            onSubmit={selectedFactory ? handleUpdatefactory : handleCreateFactory} 
                        />
                    </div>
                </div>
            )}
            <FactoryList 
                factoryList={factoryList} 
                onEdit={(factory: any) => {
                    setSelectedFactory(factory);
                    setShowForm(true);
                }} 
                onDelete={handleDeleteFactory} 
                setSelectedFactory={setSelectedFactory} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default FactoryManagement;
