import { faEdit, faTrashAlt,faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

const SparepartList: React.FC<any> = (props) => {
    const { sparepartList, onEdit, onDelete, setSelectedSparepart, setShowForm } = props;

    return (
        <div className="spareparts-details h-full w-[80%] p-4 mt-20">
            <div className="flex justify-between items-center">
                <h2 className="text-[25px] leading-normal font-bold mb-4">
                    QUẢN LÝ LOẠI PHỤ TÙNG
                </h2>
                <button
                    className="mb-4 p-2 bg-violet-500 text-white rounded"
                    onClick={() => {
                        setSelectedSparepart(null);
                        setShowForm(true);
                    }}
                >
                    <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Loại Phụ Tùng
                </button>
            </div>
            <div className="overflow-x-auto">
                <table className="min-w-full bg-white">
                    <thead>
                        <tr>
                            <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                                ID Loại Phụ Tùng
                            </th>
                            <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                                Tên Loại Phụ Tùng
                            </th>
                            <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                                Nội Dung
                            </th>
                            <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                                Thao tác
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {sparepartList.map((sparepart: any) => (
                            <tr className='text-center' key={sparepart.sparePartId}>
                                <td className="border border-gray-500 px-4 py-2">
                                    {sparepart.sparePartId}
                                </td>
                                <td className="border border-gray-500 px-4 py-2">
                                    {sparepart.sparePartName}
                                </td>
                                <td className="border border-gray-500 px-4 py-2">
                                    {sparepart.sparePartContent}
                                </td>
                                <td className="border border-gray-500 px-4 py-2">
                                    <div className="flex justify-center items-center">
                                        {/* Icon sửa */}
                                        <button
                                            onClick={() => onEdit(sparepart)}
                                            className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                                            style={{ maxWidth: "30px" }}
                                        >
                                            <FontAwesomeIcon icon={faEdit} />
                                        </button>

                                        {/* Icon xóa */}
                                        <button
                                            onClick={() => onDelete(sparepart.sparePartId)}
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

export default SparepartList;
