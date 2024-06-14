import React, { useEffect, useState } from 'react';
import { createDepartment, getAllDepartments, updateDepartment, deleteDepartment } from '../../../api/department';
import DepartmentForm from './DepartmentForm';
import DepartmentList from './DepartmentList';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faXmarkCircle } from '@fortawesome/free-solid-svg-icons';

const DepartmentManagement: React.FC = () => {
    const [departmentList, setDepartmentList] = useState<any[]>([]);
    const [selectedDepartment, setSelectedDepartment] = useState<any>(null);
    const [showForm, setShowForm] = useState(false);

    useEffect(() => {
        fetchDepartmentList();
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

    const fetchDepartmentList = async () => {
        const response = await getAllDepartments();
        setDepartmentList(response);
    };

    const handleCreateDepartment = async (department: Partial<{}>) => {
        await createDepartment(department);
        fetchDepartmentList();
        setShowForm(false); // Hide form after creating department
    };

    const handleUpdateDepartment = async (department: {}) => {
        await updateDepartment(department);
        fetchDepartmentList();
        setShowForm(false); // Hide form after updating department
    };

    const handleDeleteDepartment = async (id: string) => {
        await deleteDepartment(id);
        fetchDepartmentList();
    };

    return (
        <div className="relative">
            {showForm && (
                <div className="fixed inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="bg-white p-4 rounded shadow-md mt-20 w-[50%] relative">
                        <div className="flex justify-between items-center bg-violet-500 p-4 rounded-t">
                            <div className="text-white text-2xl font-bold">
                                {selectedDepartment ? `ID: ${selectedDepartment.departmentId}` : "THÊM BỘ PHẬN"}
                            </div>
                            <button 
                                className="text-white text-2xl hover:green-red-500" 
                                onClick={() => setShowForm(false)}
                            >
                                <FontAwesomeIcon icon={faXmarkCircle} />
                            </button>
                        </div>
                        <DepartmentForm 
                            initialData={selectedDepartment || {}} 
                            onSubmit={selectedDepartment ? handleUpdateDepartment : handleCreateDepartment} 
                        />
                    </div>
                </div>
            )}
            <DepartmentList 
                departmentList={departmentList} 
                onEdit={(department: any) => {
                    setSelectedDepartment(department);
                    setShowForm(true);
                }} 
                onDelete={handleDeleteDepartment} 
                setSelectedDepartment={setSelectedDepartment} 
                setShowForm={setShowForm}
            />
        </div>
    );
};

export default DepartmentManagement;
