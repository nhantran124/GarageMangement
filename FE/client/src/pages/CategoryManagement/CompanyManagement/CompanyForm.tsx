import { faEdit, faPlusCircle, faArrowAltCircleLeft } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import { useForm } from 'react-hook-form';

const CompanyForm: React.FC<any> = ({ initialData = {}, onSubmit, onCancel }) => {
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
                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="companyName">
                            Company Name
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                            {...register("companyName")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập tên công ty"
                            
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="companyAddress">
                            Company address 
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                           
                            {...register("companyAddress")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập địa chỉ công ty"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="companyPhoneNumber">
                            Company Phonenumber 
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                          
                            {...register("companyPhoneNumber")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập số điện thoại nhà cung cấp"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="email">
                            Company Email
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="email"
                            {...register("companyEmail")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập email công ty"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="companyWeb">
                            Company Website
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                            
                            {...register("companyWeb")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập website công ty"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="companyTax">
                            MST
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                            
                            {...register("companyTax")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập mã số thuế công ty" 
                        />
                    </div>

                    <div className="w-full px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="notePrice">
                            Price
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                            {...register("notePrice")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập báo giá"
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
                            initialData.companyId ? 'bg-green-500 hover:bg-green-700' : 'bg-blue-500 hover:bg-violet-500'
                        }`}
                    >
                        {initialData.companyId ? (
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

export default CompanyForm;
