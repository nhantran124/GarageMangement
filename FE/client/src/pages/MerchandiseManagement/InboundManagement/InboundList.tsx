import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const InboundList: React.FC<any> = (props) => {
    const { inboundList, onEdit, onDelete, setSelectedInbound, setShowForm } = props;

    return (
      <div className="main-content h-full w-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ NHẬP HÀNG
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
              setSelectedInbound(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Hoá Đơn Nhập
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Hoá Đơn Nhập
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Ngày Nhập
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Nhà Cung Cấp
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tổng Tiền
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tình Trạng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Nhân Viên
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Mã Hoá Đơn
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  VAT
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Mã Sữa Chữa CV
                </th>
              </tr>
            </thead>
            <tbody>
              {inboundList.map((inbound: any) => (
                <tr className='text-center' key={inbound.invoiceEnterId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {inbound.dayEnter}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {inbound.supplierId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {inbound.totalPrice}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {inbound.status}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {inbound.staffId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {inbound.invoiceCode}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {inbound.vat}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {inbound.repairCodeId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(inbound)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(inbound.invoiceEnterId)}
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

export default InboundList;
