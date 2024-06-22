import { faEdit, faPlusCircle, faArrowAltCircleLeft, faCircleExclamation } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import { useForm } from 'react-hook-form';
import { ErrorMessage } from "@hookform/error-message";

const ErrorIconMessage: React.FC<{ message: string }> = ({ message }) => (
    <div className="flex items-center text-red-500 text-xs">
        <FontAwesomeIcon icon={faCircleExclamation} className="mr-1" />
        {message}
    </div>
);

const CustomerForm: React.FC<any> = ({ initialData = {}, onSubmit, onCancel }) => {
    const { register, handleSubmit, reset, formState: { errors } } = useForm({
        defaultValues: initialData
    });

    const handleFormSubmit = (data: any) => {
        onSubmit(data);
        reset();
    };

    return (
        <form onSubmit={handleSubmit(handleFormSubmit)} className="w-full mx-auto p-4 bg-white rounded shadow-md">
            <div className="space-y-4">
                <div className="flex flex-wrap -mx-2">
                <div className="w-full px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="customerId">
                            Customer ID<span className="text-red-500">*</span>
                        </label>
                        <input
                            type="text"
                            {...register("customerId", { required: `Customer ID is required` })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập ID khách hàng"
                        />
                        
                        <ErrorMessage
                            errors={errors}
                            name="customerId"
                            render={({ message }) => <ErrorIconMessage message={message} />}
                        />
                    </div>
                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="customerName">
                            Customer Name<span className="text-red-500">*</span>
                        </label>
                        <input
                            type="text"
                            {...register("customerName", { required: `Customer Name is required` })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập tên khách hàng"
                        />
                        <ErrorMessage
                            errors={errors}
                            name="customerId"
                            render={({ message }) => <ErrorIconMessage message={message} />}
                        />
                    </div>
                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="customerAddress">
                            Customer Address
                        </label>
                        <input
                            type="text"
                            {...register("customerAddress")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập địa chỉ khách hàng"
                        />
                    </div>
                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="customerPhonenumber">
                            Customer Phonenumber
                        </label>
                        <input
                            type="text"
                            {...register("customerPhonenumber")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập số điện thoại khách hàng"
                        />
                    </div>
                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="customerTax">
                            MST
                        </label>
                        <input
                            type="text"
                            {...register("customerTax")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập mã số thuế"
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
                            initialData.customerId ? 'bg-green-500 hover:bg-green-700' : 'bg-blue-500 hover:bg-violet-500'
                        }`}
                    >
                        {initialData.customerId ? (
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


export default CustomerForm;
