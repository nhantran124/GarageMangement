import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const AccessoryWarehouseList: React.FC<any> = (props) => {
    const { accessoryWarehouseList, onEdit, onDelete, setSelectedAccessoryWarehouse, setShowForm } = props;

    return (
      <div className="main-content h-full w-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            PHỤ TÙNG KHO
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
                setSelectedAccessoryWarehouse(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Phụ Tùng Kho
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Phụ Tùng Nhà Cung Cấp
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Phụ Tùng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Giá Nhập
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Số Lượng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Nhà Cung Cấp
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Ngày Nhập
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Mã Vạch
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Hoá Đơn Nhập
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Phiếu Sữa Chữa
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {accessoryWarehouseList.map((accessoryWarehouse: any) => (
                <tr className='text-center' key={accessoryWarehouse.supplierSparePartId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessoryWarehouse.supplierSparePartId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessoryWarehouse.sparePartDetailsId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessoryWarehouse.inputPrice}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessoryWarehouse.quantity}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessoryWarehouse.supplierId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessoryWarehouse.dayEnter}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessoryWarehouse.barcode}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessoryWarehouse.invoiceEnterId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {accessoryWarehouse.repairCardId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(accessoryWarehouse)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(accessoryWarehouse.supplierSparePartId)}
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

export default AccessoryWarehouseList;
