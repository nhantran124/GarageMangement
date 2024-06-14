import { faEdit, faTrashAlt,faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

const FactoryList: React.FC<any> = (props) => {
    const { factoryList, onEdit, onDelete, setSelectedFactory, setShowForm } = props;

    return (
        <div className="main-content h-full w-[80%] p-4 mt-20">
            <div className="flex justify-between items-center">
                <h2 className="text-[25px] leading-normal font-bold mb-4">
                    QUẢN LÝ XƯỞNG
                </h2>
                <button
                    className="mb-4 p-2 bg-violet-500 text-white rounded"
                    onClick={() => {
                        setSelectedFactory(null);
                        setShowForm(true);
                    }}
                >
                    <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Xưởng
                </button>
            </div>
            <div className="overflow-x-auto">
                <table className="min-w-full bg-white">
                    <thead>
                        <tr>
                            <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                                ID Xưởng
                            </th>
                            <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                                Tên Xưởng
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
                        {factoryList.map((factory: any) => (
                            <tr className='text-center' key={factory.factoryId}>
                                <td className="border border-gray-500 px-4 py-2">
                                    {factory.factoryId}
                                </td>
                                <td className="border border-gray-500 px-4 py-2">
                                    {factory.factoryName}
                                </td>
                                <td className="border border-gray-500 px-4 py-2">
                                    {factory.note}
                                </td>
                                <td className="border border-gray-500 px-4 py-2">
                                    <div className="flex justify-center items-center">
                                        {/* Icon sửa */}
                                        <button
                                            onClick={() => onEdit(factory)}
                                            className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                                            style={{ maxWidth: "30px" }}
                                        >
                                            <FontAwesomeIcon icon={faEdit} />
                                        </button>

                                        {/* Icon xóa */}
                                        <button
                                            onClick={() => onDelete(factory.factoryId)}
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

export default FactoryList;
