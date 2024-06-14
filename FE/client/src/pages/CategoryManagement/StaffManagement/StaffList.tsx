import { faEdit, faTrashAlt,faPlusCircle } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

const StaffList: React.FC<any> = (props) => {
    const { staffList, onEdit, onDelete, setSelectedStaff, setShowForm } = props;

    return (
      <div className="main-content h-full w-[80%] p-4 mt-20 ">
        <div className="flex justify-between items-center">
          <h2 className="text-[25px] leading-normal font-bold mb-4">
            QUẢN LÝ NHÂN VIÊN
          </h2>
          <button
            className="mb-4 p-2 bg-violet-500 text-white rounded"
            onClick={() => {
              setSelectedStaff(null);
              setShowForm(true);
            }}
          >
            <FontAwesomeIcon className='mr-2' icon={faPlusCircle} />Tạo Nhân Viên
          </button>
        </div>
        <div className="overflow-x-auto">
          <table className="min-w-full bg-white">
            <thead>
              <tr>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Nhân Viên
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Bộ Phận
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  ID Quyền
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Nhân Viên
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Địa chỉ Nhân viên
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Điện thoại Nhân viên
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Tên Đăng Nhập
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Ngày Vào Làm
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Ngày Phép
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Trạng Thái
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Actions
                </th>
                <th className="border border-gray-500 bg-gray-300 px-4 py-2">
                  Thao Tác
                </th>
              </tr>
            </thead>
            <tbody>
              {staffList.map((staff: any) => (
                <tr className='text-center' key={staff.staffId}>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.staffId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.departmentId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.roleId}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.staffName}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.staffAddress}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.staffPhonenumber}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.username}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.accountActive}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.dayIn}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.premissionDay}
                  </td>
                  <td className="border border-gray-500 px-4 py-2">
                    {staff.status}
                  </td>

                  <td className="border border-gray-500 px-4 py-2">
                    <div className="flex justify-center items-center">
                      {/* Icon sửa */}
                      <button
                        onClick={() => onEdit(staff)}
                        className="p-2 bg-green-500 text-white rounded hover:underline mx-2"
                        style={{ maxWidth: "30px" }}
                      >
                        <FontAwesomeIcon icon={faEdit} />
                      </button>

                      {/* Icon xóa */}
                      <button
                        onClick={() => onDelete(staff.staffId)}
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

export default StaffList;