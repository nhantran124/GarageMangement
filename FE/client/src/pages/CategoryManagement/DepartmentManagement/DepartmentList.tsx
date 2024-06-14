import { faEdit, faTrashAlt,faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

const DepartmentList: React.FC<any> = (props) => {
    const { departmentList, onEdit, onDelete, setSelectedDepartment, setShowForm } = props;

    return (
        <div className="main-content h-full w-[80%] p-4 mt-20">
            <div className="flex justify-between items-center">
                <h2 className="text-[25px] leading-normal font-bold mb-4">
                    QUẢN LÝ BỘ PHẬN
                </h2>
                <button
                    className="mb-4 p-2 bg-violet-500 text-white rounded"
                    onClick={() => {
                        setSelectedDepartment(null);
                        setShowForm(true);
                    }}
                >
                    <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Bộ Phận
                </button>
            </div>
            <div className="overflow-x-auto">
                <table className="min-w-full bg-white">
                    <thead>
                        <tr>
                            <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                                ID Bộ Phận
                            </th>
                            <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                                Tên Bộ Phận
                            </th>
                            <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                                Ghi Chú
                            </th>
                            <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {departmentList.map((department: any) => (
                            <tr className='text-center' key={department.departmentId}>
                                <td className="border border-gray-500 px-4 py-2">
                                    {department.departmentId}
                                </td>
                                <td className="border border-gray-500 px-4 py-2">
                                    {department.departmentName}
                                </td>
                                <td className="border border-gray-500 px-4 py-2">
                                    {department.departmentNote}
                                </td>
                                <td className="border border-gray-500 px-4 py-2">
                                    <div className="flex justify-center items-center">
                                        {/* Icon sửa */}
                                        <button
                                            onClick={() => onEdit(department)}
                                            className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                                            style={{ maxWidth: "30px" }}
                                        >
                                            <FontAwesomeIcon icon={faEdit} />
                                        </button>

                                        {/* Icon xóa */}
                                        <button
                                            onClick={() => onDelete(department.departmentId)}
                                            className="p-2 bg-red-500 text-white rounded hover:underline mx-2"
                                            style={{ maxWidth: "30px" }}
                                        >
                                            <FontAwesomeIcon icon={faTrashAlt} />
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default DepartmentList;
