import React, { useEffect, useState } from 'react';
import InsuranceForm from './InsuranceForm';
import InsuranceList from './InsuranceList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';
import { createInsurance, deleteInsurance, getAllInsurances, updateInsurance } from '../../../api/insurance';

const InsuranceManagement: React.FC = () => {
    const [insuranceList, setInsuranceList] = useState([]);
    const [selectedInsurance, setSelectedInsurance] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchInsuranceList();
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
    const fetchInsuranceList = async () => {
        const response = await getAllInsurances();
        setInsuranceList(response);
    };
    const handleCreateInsurance = async (insurance: Partial<{}>) => {
        await createInsurance(insurance);
        fetchInsuranceList();
        setShowForm(false); 
    };
    const handleUpdateInsurance = async (insurance: {}) => {
        await updateInsurance(insurance);
        fetchInsuranceList();
        setShowForm(false); 
    };
    const handleDeleteInsurance = async (id: string) => {
        await deleteInsurance(id);
        fetchInsuranceList();
    };
    

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                    <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                            {selectedInsurance ? `ID: ${selectedInsurance.insuranceId}` : "THÊM BẢO HIỂM"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:text-green-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <InsuranceForm 
                            initialData={selectedInsurance || {}} 
                            onSubmit={selectedInsurance ? handleUpdateInsurance : handleCreateInsurance} 
                        />
                    </div>
                </div>
            )}
            <InsuranceList 
                insuranceList={insuranceList} 
                onEdit={(insurance: any) => {
                    setSelectedInsurance(insurance);
                    setShowForm(true);
     
                }} 
                onDelete={handleDeleteInsurance} 
                setSelectedInsurance={setSelectedInsurance} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default InsuranceManagement;
