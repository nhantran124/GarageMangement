import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const VehicleList: React.FC<any> = (props) => {
    const { vehicleList, onEdit, onDelete, setSelectedVehicle, setShowForm } = props;

    return (
      <div className="vehicle-list-details h-screen w-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ LOẠI XE
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
              setSelectedVehicle(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Loại Xe
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Loại Xe
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Loại Xe
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Ghi Chú
                </th>
                <th className="w-[100px] border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {vehicleList.map((vehicle: any) => (
                <tr className='text-center' key={vehicle.typeOfVehicleId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {vehicle.typeOfVehicleId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {vehicle.nameOfVehicle}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {vehicle.note}
                  </td>
                  
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(vehicle)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(vehicle.typeOfVehicleId)}
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

export default VehicleList;
