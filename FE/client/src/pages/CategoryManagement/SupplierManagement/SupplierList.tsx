import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const SupplierList: React.FC<any> = (props) => {
    const { supplierList, onEdit, onDelete, setSelectedSupplier, setShowForm } = props;

    return (
      <div className="main-content h-full w-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ NHÀ CUNG CẤP
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
              setSelectedSupplier(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo NCC
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Nhà Cung Cấp
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Nhà Cung Cấp
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Địa Chỉ Nhà Cung Cấp
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Điện Thoại Nhà Cung Cấp
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  MST
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Ngân Hàng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Chi Nhánh
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Số Tài Khoản
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {supplierList.map((supplier: any) => (
                <tr className='text-center' key={supplier.supplierId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {supplier.supplierId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {supplier.supplierName}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {supplier.supplierAddress}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {supplier.supplierPhonenumber}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {supplier.supplierTax}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {supplier.supplierBank}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {supplier.supplierBranch}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {supplier.accountNumber}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(supplier)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(supplier.supplierId)}
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

export default SupplierList;
