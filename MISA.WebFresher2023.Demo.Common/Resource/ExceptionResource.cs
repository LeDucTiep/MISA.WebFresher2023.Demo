using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher2023.Demo.Common.Resource
{
    /// <summary>
    /// Resource nội dung lỗi 
    /// </summary>
    /// Author: LeDucTiep (23/05/2023)
    public static class InternalDevMessage
    {
        /// <summary>
        /// Lỗi không tìm thấy phòng ban 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string ConnectDbError = "Không kết nối được với cơ sở dữ liệu";
    }

    /// <summary>
    /// Thông tin lỗi cho người dùng
    /// </summary>
    /// Author: LeDucTiep (23/05/2023)
    public static class InternalUserMessage
    {
        /// <summary>
        /// Lỗi không tìm thấy phòng ban 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string ConnectDbError = "Có lỗi xảy ra vui lòng liên hệ Misa để được hỗ trợ";

        /// <summary>
        /// Lỗi không xác định
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string Unknown = "Có lỗi xảy ra vui lòng liên hệ Misa để được hỗ trợ";
    }

   

    /// <summary>
    /// Thông tin lỗi phân trang
    /// </summary>
    /// Author: LeDucTiep (23/05/2023)
    public static class PagingUserMessage
    {
        /// <summary>
        /// Lỗi kích thước trang không hợp lệ 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string InvalidPageSize = "Kích thước trang phải lớn hơn 0";

        /// <summary>
        /// Lỗi số thứ tự trang không hợp lệ 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string InvalidPageNumber = "số trang phải lớn hơn 0";

        /// <summary>
        /// Lỗi độ dài từ khóa tìm kiếm
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string EmployeeSearchTermTooLong = "Từ khóa tìm kiếm không được dài quá 255 kí tự";
    }

    /// <summary>
    /// Thông tin lỗi phân trang
    /// </summary>
    /// Author: LeDucTiep (23/05/2023)
    public static class PagingDevMessage
    {
        /// <summary>
        /// Lỗi kích thước trang không hợp lệ 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string InvalidPageSize = "PageSize phải lớn hơn 0";

        /// <summary>
        /// Lỗi số thứ tự trang không hợp lệ 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string InvalidPageNumber = "PageNumber phải lớn hơn 0";

        /// <summary>
        /// Lỗi độ dài từ khóa tìm kiếm
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        public static readonly string EmployeeSearchTermTooLong = "EmployeeSearchTerm không được dài quá 255 kí tự";
    }

    public static class AnswerUserMessage
    {
        public static readonly string FullNameToLong = "Họ tên không được dài quá 100 ký tự";
        public static readonly string ContentToLong = "Nội dung quá dài";
       

    }

    public static class AnswerDevMessage
    { 
        public static readonly string FullNameToLong = "Họ tên không được dài quá 100 ký tự";
        public static readonly string ContentToLong = "Nội dung quá dài";
     
    }

    public static class RequestUserMessage
    {
        public static readonly string GuidInvalid = "Có lỗi xảy ra vui lòng liên hệ Misa để được hỗ trợ";
    }
    public static class RequestDevMessage
    {
        public static readonly string GuidInvalid = "Id không đúng định dạng";
    }

}
