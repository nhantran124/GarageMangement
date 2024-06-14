import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const InsuranceList: React.FC<any> = (props) => {
    const { insuranceList, onEdit, onDelete, setSelectedInsurance, setShowForm } = props;

    return (
      <div className="main-content h-full w-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ BẢO HIỂM
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
              setSelectedInsurance(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Bảo Hiểm
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Bảo Hiểm
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Bảo Hiểm
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Mã Số Thuế
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Địa Chỉ
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Số Tài Khoản
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Ngân Hàng
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Chi Nhánh
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {insuranceList.map((insurance: any) => (
                <tr className='text-center' key={insurance.insuranceId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {insurance.insuranceId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {insurance.insuranceName}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {insurance.insuranceTax}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {insurance.insuranceAddress}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {insurance.insuranceNumberAccount}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {insurance.insuranceBank}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {insurance.insuranceBranch}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(insurance)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(insurance.insuranceId)}
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

export default InsuranceList;
