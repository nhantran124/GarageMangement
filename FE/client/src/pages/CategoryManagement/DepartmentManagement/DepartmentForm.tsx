import { faArrowAltCircleLeft, faEdit, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import { useForm } from 'react-hook-form';

const DepartmentForm: React.FC<any> = ({ initialData = {}, onSubmit, onCancel }) => {
    const { register, handleSubmit, reset } = useForm({
        defaultValues: initialData
    });

    const handleFormSubmit = (data: any) => {
        onSubmit(data);
        reset(); // Optional: Reset form after submit
    };

    return (
        <form onSubmit={handleSubmit(handleFormSubmit)} className="w-full mx-auto p-4 bg-white rounded shadow-md">
            <div className="space-y-4">
                <div className="flex flex-wrap -mx-2">
                    <div className="w-full px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="email">
                            Department Name <span className="text-red-500">*</span>
                        </label>
                        <input
                            type="text"
                            {...register("departmentName", { required: true })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập tên bộ phận"
                        />
                    </div>

                    <div className="w-full px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="role">
                            Note 
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                           
                            {...register("departmentNote")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Ghi chú (nếu có)"
                        />
                    </div>
                    
                </div>

                <div className="flex justify-end space-x-4 mt-4">
                <button
                        type="button"
                        onClick={onCancel}
                        className="w-full sm:w-auto bg-red-500 text-white py-2 px-4 rounded hover:bg-gray-700 focus:outline-none focus:shadow-outline"
                    >
                        <FontAwesomeIcon icon={faArrowAltCircleLeft} className="mr-2" />Bỏ qua
                    </button>
                    <button
                        type="submit"
                        className={`w-full sm:w-auto text-white py-2 px-4 rounded focus:outline-none focus:shadow-outline ${
                            initialData.departmentId ? 'bg-green-500 hover:bg-green-700' : 'bg-blue-500 hover:bg-violet-500'
                        }`}
                    >
                        {initialData.departmentId ? (
                            <>
                                <FontAwesomeIcon icon={faEdit} className="mr-2" />
                                Cập nhật
                            </>
                        ) : (
                            <>
                                <FontAwesomeIcon icon={faPlusCircle} className="mr-2" />
                                Thêm mới
                            </>
                        )}
                    </button>
                </div>
            </div>
        </form>
    );
};

export default DepartmentForm;
