import React, { useEffect, useState } from 'react';
import SupplierForm from './SupplierForm';
import SupplierList from './SupplierList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';
import { createSupplier, deleteSupplier, getAllSuppliers, updateSupplier } from '../../../api/supplier';

const SupplierManagement: React.FC = () => {
    const [supplierList, setSupplierList] = useState([]);
    const [selectedSupplier, setSelectedSupplier] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchSupplierList();
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
    const fetchSupplierList = async () => {
        const response = await getAllSuppliers();
        setSupplierList(response);
    };
    const handleCreateSupplier = async (supplier: Partial<{}>) => {
        await createSupplier(supplier);
        fetchSupplierList();
        setShowForm(false); 
    };
    const handleUpdateSupplier = async (supplier: {}) => {
        await updateSupplier(supplier);
        fetchSupplierList();
        setShowForm(false); 
    };
    const handleDeleteSupplier = async (id: string) => {
        await deleteSupplier(id);
        fetchSupplierList();
    };
    

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                    <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                            {selectedSupplier ? `ID: ${selectedSupplier.supplierId}` : "THÊM NHÀ CUNG CẤP"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:text-green-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <SupplierForm 
                            initialData={selectedSupplier || {}} 
                            onSubmit={selectedSupplier ? handleUpdateSupplier : handleCreateSupplier} 
                        />
                    </div>
                </div>
            )}
            <SupplierList 
                supplierList={supplierList} 
                onEdit={(supplier: any) => {
                    setSelectedSupplier(supplier);
                    setShowForm(true);
     
                }} 
                onDelete={handleDeleteSupplier} 
                setSelectedSupplier={setSelectedSupplier} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default SupplierManagement;
