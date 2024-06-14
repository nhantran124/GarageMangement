import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const BusinessList: React.FC<any> = (props) => {
    const { businessList, onEdit, onDelete, setSelectedBusiness, setShowForm } = props;

    return (
      <div className="business-details h-full w-full p-9 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ CÔNG VIỆC
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
              setSelectedBusiness(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Công Việc
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Công Việc
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2 ml-2">
                  Tên Công Việc
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Loại Công Việc
                </th>
                <th className="w-[100px] border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {businessList.map((business: any) => (
                <tr className='text-center' key={business.businessDetailsId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {business.businessDetailsId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {business.businessDetailsName}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {business.typeOfBusinessDetailsId}
                  </td>
                  
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(business)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(business.businessDetailsId)}
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

export default BusinessList;
