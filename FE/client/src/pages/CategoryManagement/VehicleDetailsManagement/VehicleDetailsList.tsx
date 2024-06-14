import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const VehicleDetailsList: React.FC<any> = (props) => {
    const { vehicleDetailsList, onEdit, onDelete, setSelectedVehicleDetails, setShowForm } = props;

    return (
      <div className="vehicle-details h-full w-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ XE RA VÀO
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
                setSelectedVehicleDetails(null);
                setShowForm(true);
            }}  
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Xe Ra Vào
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
              <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID xe
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Loại xe
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Biển Số Xe
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Số Máy Xe
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Số Khung Xe
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Màu sắc
                </th>
                <th className="w-[100px] border border-gray-500 bg-gray-300 px-4">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {vehicleDetailsList.map((vehicledetails: any) => (
                <tr className='text-center' key={vehicledetails.vehicleId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {vehicledetails.vehicleId}
                  </td> 
                  <td className="border border-gray-500 px-4 py-2">
                    {vehicledetails.typeOfVehicleId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {vehicledetails.licensePlates}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {vehicledetails.vehicleNumber}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {vehicledetails.chassisNumber}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {vehicledetails.vehicleColor}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(vehicledetails)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(vehicledetails.vehicleId)}
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

export default VehicleDetailsList;
