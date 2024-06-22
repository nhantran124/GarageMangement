import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const RoleDetailsList: React.FC<any> = (props) => {
    const { roleDetailsList, onEdit, onDelete, setSelectedRoleDetails, setShowForm } = props;

    return (
      <div className="extended-width h-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ QUYỀN
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
                setSelectedRoleDetails(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Thêm Quyền
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Quyền
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Quyền
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {roleDetailsList.map((roleDetails: any) => (
                <tr className='text-center' key={roleDetails.roleId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {roleDetails.roleId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {roleDetails.roleName}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(roleDetails)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(roleDetails.roleId)}
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

export default RoleDetailsList;
