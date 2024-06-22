import { faEdit, faPlusCircle, faArrowAltCircleLeft } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import { useForm } from 'react-hook-form';

const SparePartsDetailsForm: React.FC<any> = ({ initialData = {}, onSubmit, onCancel }) => {
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
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="sparePartDetailsName">
                        Accessories Name
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                            {...register("sparePartDetailsName")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập tên phụ tùng"
                            
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="sparePartDetailsOtherName">
                            Other Name 
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                           
                            {...register("sparePartDetailsOtherName")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập tên gọi khác"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="sparePartId">
                            ID Type Of Accessories 
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                          
                            {...register("sparePartId")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập ID loại phụ tùng"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="sparePartSupplierId">
                            ID Supplier
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                            {...register("sparePartSupplierId")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập ID nhà cung cấp"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="sparePartPrice">
                            Unit Price
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="number"
                            {...register("sparePartPrice")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập đơn giá"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="sparePartPosition">
                            Position
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                            
                            {...register("sparePartPosition")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập vị trí" 
                        />
                    </div>

                    <div className="w-full px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="sparePartUnitCal">
                            Unit Measurement
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                            {...register("sparePartUnitCal")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập đơn vị tính"
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
                            initialData.sparePartDetailsId ? 'bg-green-500 hover:bg-green-700' : 'bg-blue-500 hover:bg-violet-500'
                        }`}
                    >
                        {initialData.sparePartDetailsId ? (
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

export default SparePartsDetailsForm;
