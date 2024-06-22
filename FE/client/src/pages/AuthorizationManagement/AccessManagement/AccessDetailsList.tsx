import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const AccessDetailsList: React.FC<any> = (props) => {
    const { accessDetailsList, onEdit, onDelete, setSelectedAccessDetails, setShowForm } = props;

    return (
      <div className="access-details h-full w-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ ĐƯỜNG DẪN
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
                setSelectedAccessDetails(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Thêm Đường Dẫn
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Dường Dẫn
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  URL Đường Dẫn
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Quyền
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Truy Cập
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Ký Hiệu
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  URL Truy Cập
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {accessDetailsList.map((accessDetails: any) => (
                <tr className='text-center' key={accessDetails.accessId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessDetails.accessId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessDetails.accessURL}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessDetails.roleId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessDetails.permissionId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessDetails.permissionSymbol}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessDetails.permissionURL}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(accessDetails)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(accessDetails.accessId)}
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

export default AccessDetailsList;
