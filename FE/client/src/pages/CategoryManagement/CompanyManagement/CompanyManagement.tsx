import React, { useEffect, useState } from 'react';
import CompanyForm from './CompanyForm';
import CompanyList from './CompanyList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';
import { createCompany, deleteCompany, getAllCompany, updateCompany } from '../../../api/company';

const CompanyManagement: React.FC = () => {
    const [companyList, setCompanyList] = useState([]);
    const [selectedCompany, setSelectedCompany] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchCompanyList();
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
    const fetchCompanyList = async () => {
        const response = await getAllCompany();
        setCompanyList(response);
    };
    const handleCreateCompany = async (company: Partial<{}>) => {
        await createCompany(company);
        fetchCompanyList();
        setShowForm(false); 
    };
    const handleUpdateCompany = async (company: {}) => {
        await updateCompany(company);
        fetchCompanyList();
        setShowForm(false); 
    };
    const handleDeleteCompany = async (id: string) => {
        await deleteCompany(id);
        fetchCompanyList();
    };
    

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                    <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                            {selectedCompany ? `ID: ${selectedCompany.companyId}` : "THÊM CÔNG TY"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:text-green-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <CompanyForm 
                            initialData={selectedCompany || {}} 
                            onSubmit={selectedCompany ? handleUpdateCompany : handleCreateCompany} 
                        />
                    </div>
                </div>
            )}
            <CompanyList 
                companyList={companyList} 
                onEdit={(company: any) => {
                    setSelectedCompany(company);
                    setShowForm(true);
     
                }} 
                onDelete={handleDeleteCompany} 
                setSelectedCompany={setSelectedCompany} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default CompanyManagement;
