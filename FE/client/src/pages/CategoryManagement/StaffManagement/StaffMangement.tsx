import React, { useEffect, useState } from 'react';
import { getAllStaff, createStaff, updateStaff, deleteStaff } from '../../../api/staff';
import StaffForm from './StaffForm';
import StaffList from './StaffList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';

const StaffManagement: React.FC = () => {
    const [staffList, setStaffList] = useState([]);
    const [selectedStaff, setSelectedStaff] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchStaffList();
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

    const fetchStaffList = async () => {
        const response = await getAllStaff();
        setStaffList(response);
    };

    const handleCreateStaff = async (staff: Partial<{}>) => {
        await createStaff(staff);
        fetchStaffList();
        setShowForm(false); // Hide form after creating staff
    };

    const handleUpdateStaff = async (staff: {}) => {
        await updateStaff(staff);
        fetchStaffList();
        setShowForm(false); // Hide form after updating staff
    };

    const handleDeleteStaff = async (id: string) => {
        await deleteStaff(id);
        fetchStaffList();
    };

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                        <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                                {selectedStaff ? `ID: ${selectedStaff.staffId}` : "THÊM NHÂN VIÊN"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:green-red-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                    
                        <StaffForm 
                            initialData={selectedStaff || {}} 
                            onSubmit={selectedStaff ? handleUpdateStaff : handleCreateStaff} 
                        />
                    </div>
                </div>
            )}
            <StaffList 
                staffList={staffList} 
                onEdit={(staff: any) => {
                    setSelectedStaff(staff);
                    setShowForm(true);
     
                }} 
                onDelete={handleDeleteStaff} 
                setSelectedStaff={setSelectedStaff} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default StaffManagement;
