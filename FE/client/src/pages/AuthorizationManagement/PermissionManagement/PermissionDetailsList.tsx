import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const PermissionDetailsList: React.FC<any> = (props) => {
    const { permissionDetailsList, onEdit, onDelete, setSelectedPermissionDetails, setShowForm } = props;

    return (
      <div className="vehicle-details h-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ TRUY CẬP
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
                setSelectedPermissionDetails(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Thêm Quyền Truy Cập
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Truy Cập
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Truy Cập
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Ký Hiệu
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {permissionDetailsList.map((permissionDetails: any) => (
                <tr className='text-center' key={permissionDetails.roleId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {permissionDetails.permissionId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {permissionDetails.permissionName}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {permissionDetails.permissionSymbol}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(permissionDetails)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(permissionDetails.permissionId)}
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

export default PermissionDetailsList;
