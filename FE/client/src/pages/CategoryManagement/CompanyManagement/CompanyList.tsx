import { faEdit, faTrashAlt, faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';


const CompanyList: React.FC<any> = (props) => {
    const { companyList, onEdit, onDelete, setSelectedCompany, setShowForm } = props;

    return (
      <div className="main-content h-full w-full p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ THÔNG TIN CÔNG TY
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
              setSelectedCompany(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Công Ty
          </button>
        </div>
        <div className="overflow-x-auto ">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Công Ty
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Công Ty
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Địa Chỉ Công Ty
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Điện Thoại Công Ty
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Email Công Ty
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Website Công Ty
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  MST
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Báo Giá
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {companyList.map((company: any) => (
                <tr className='text-center' key={company.companyId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {company.companyId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {company.companyName}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {company.companyAddress}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {company.companyPhoneNumber}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {company.companyEmail}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {company.companyWeb}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {company.companyTax}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {company.notePrice}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(company)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(company.companyId)}
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

export default CompanyList;
