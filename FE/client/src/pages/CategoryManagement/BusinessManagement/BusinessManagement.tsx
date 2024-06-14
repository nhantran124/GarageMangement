import React, { useEffect, useState } from 'react';
import BusinessForm from './BusinessForm';
import BusinessList from './BusinessList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';
import { createBusiness, deleteBusiness, getAllBusiness, updateBusiness } from '../../../api/business';

const BusinessManagement: React.FC = () => {
    const [businessList, setBusinessList] = useState([]);
    const [selectedBusiness, setSelectedBusiness] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchBusinessList();
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
    const fetchBusinessList = async () => {
        const response = await getAllBusiness();
        setBusinessList(response);
    };
    const handleCreateBusiness = async (business: Partial<{}>) => {
        await createBusiness(business);
        fetchBusinessList();
        setShowForm(false); 
    };
    const handleUpdateBusiness = async (business: {}) => {
        await updateBusiness(business);
        fetchBusinessList();
        setShowForm(false); 
    };
    const handleDeleteBusiness = async (id: string) => {
        await deleteBusiness(id);
        fetchBusinessList();
    };
    

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                    <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                            {selectedBusiness ? `ID: ${selectedBusiness.businessDetailsId}` : "THÊM CÔNG VIỆC"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:text-green-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <BusinessForm 
                            initialData={selectedBusiness || {}} 
                            onSubmit={selectedBusiness ? handleUpdateBusiness : handleCreateBusiness} 
                        />
                    </div>
                </div>
            )}
            <BusinessList 
                businessList={businessList} 
                onEdit={(business: any) => {
                    setSelectedBusiness(business);
                    setShowForm(true);
     
                }} 
                onDelete={handleDeleteBusiness} 
                setSelectedBusiness={setSelectedBusiness} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default BusinessManagement;
