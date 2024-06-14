import { faArrowAltCircleLeft, faEdit, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import { useForm } from 'react-hook-form';

const StaffForm: React.FC<any> = ({ initialData = {}, onSubmit, onCancel }) => {
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
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="email">
                            Department ID <span className="text-red-500">*</span>
                        </label>
                        <input
                            type="text"
                            {...register("departmentId", { required: true })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập ID bộ phận"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="role">
                            Role ID <span className="text-red-500">*</span>
                        </label>
                        <input
                            type="number"
                           
                            {...register("roleId", { required: true })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập ID quyền"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
                            Staff Name <span className="text-red-500">*</span>
                        </label>
                        <input
                            type="text"
                          
                            {...register("staffName", { required: true })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập tên nhân viên"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="confirmPassword">
                            Staff Address <span className="text-red-500">*</span>
                        </label>
                        <input
                            type="text"
                            
                            {...register("staffAddress", { required: true })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhâp địa chỉ nhân viên"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="fullName">
                            Staff Phonenumber <span className="text-red-500">*</span>
                        </label>
                        <input
                            type="text"
                            
                            {...register("staffPhonenumber", { required: true })}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập số điện thoại nhân viên"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="phoneNumber">
                            Username 
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                            
                            {...register("username")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập tên đăng nhập"
                        />
                    </div>

                    <div className="w-full sm:w-1/2 px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="address">
                            Password 
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="text"
                            {...register("password")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập mật khẩu"
                        />
                    </div>
                    <div className="w-full sm:w-1/2  px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="address">
                            Account active
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="number"
                            {...register("accountActive")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập mật khẩu"
                        />
                    </div>
                    <div className="w-full sm:w-1/2  px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="address">
                            Day in
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input
                            type="date"
                            {...register("dayIn")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Ngày bắt đầu vào làm"
                        />
                    </div>
                    <div className="w-full sm:w-1/2  px-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="address">
                            Premission day
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input  
                            type="number"
                            {...register("premissionDay")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập ngày phép"
                        />
                    </div>
                    <div className="w-full x-2 mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="address">
                            Status
                            {/* <span className="text-red-500">*</span> */}
                        </label>
                        <input  
                            type="number"
                            {...register("status")}
                            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            placeholder="Nhập trạng thái"
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
                            initialData.staffId ? 'bg-green-500 hover:bg-green-700' : 'bg-blue-500 hover:bg-violet-500'
                        }`}
                    >
                        {initialData.staffId ? (
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

export default StaffForm;
