import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const SparePartsDetailsList: React.FC<any> = (props) => {
    const { sparePartsDetailsList, onEdit, onDelete, setSelectedSparePartsDetails, setShowForm } = props;

    return (
      <div className="main-content h-full w-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ PHỤ TÙNG
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
              setSelectedSparePartsDetails(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Phụ Tùng
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Phụ Tùng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Phụ Tùng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Gọi Khác
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Loại Phụ Tùng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Nhà Sản Xuất
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Đơn Giá Bán
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Vị Trí
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Báo Giá
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Đơn Vị Tính
                </th>
              </tr>
            </thead>
            <tbody>
              {sparePartsDetailsList.map((sparepartdetails: any) => (
                <tr className='text-center' key={sparepartdetails.sparePartDetailsId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {sparepartdetails.sparePartDetailsId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {sparepartdetails.sparePartDetailsName}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {sparepartdetails.sparePartDetailsOtherName}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {sparepartdetails.sparePartId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {sparepartdetails.sparePartSupplierId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {sparepartdetails.sparePartPrice}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {sparepartdetails.sparePartPosition}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {sparepartdetails.sparePartUnitCal}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(sparepartdetails)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(sparepartdetails.sparePartDetailsId)}
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

export default SparePartsDetailsList;
