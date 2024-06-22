import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const CustomerList: React.FC<any> = (props) => {
    const { customerList, onEdit, onDelete, setSelectedCustomer, setShowForm } = props;

    return (
      <div className="customer-details h-full w-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ THÔNG TIN KHÁCH HÀNG
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
              setSelectedCustomer(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Khách Hàng
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Khách Hàng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Khách Hàng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Địa Chỉ Khách Hàng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Điện Thoại Khách Hàng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  MST
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {customerList.map((customer: any) => (
                <tr className='text-center' key={customer.customerId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {customer.customerId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {customer.customerName}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {customer.customerAddress}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {customer.customerPhonenumber}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {customer.customerTax}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(customer)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(customer.customerId)}
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

export default CustomerList;
