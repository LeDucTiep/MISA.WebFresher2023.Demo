using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher2023.Demo.Common.Constant
{
    public enum InternalErrorCode
    {
        /// <summary>
        /// Lỗi không xác định
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        Unknown = 5001,

        /// <summary>
        /// Lỗi không kết nối được database
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        ConnectDbError = 5002,
    }

    public enum PagingErrorCode
    {
        /// <summary>
        /// Lỗi kích thước trang không hợp lệ 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        InvalidPageSize = 2001,

        /// <summary>
        /// Lỗi số thứ tự trang không hợp lệ 
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        InvalidPageNumber = 2002,

        /// <summary>
        /// Lỗi độ dài từ khóa tìm kiếm
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        EmployeeSearchTermTooLong = 2003,
    }

    public enum RequestErrorCode
    {
        /// <summary>
        /// Lỗi không đúng Guid
        /// </summary>
        /// Author: LeDucTiep (23/05/2023)
        GuidInvalid = 6001,
    }
    public enum AnswerErrorCode
    {
        FullNameToLong = 1001,
        ContentToLong = 1002,
    }

    public enum QuestionErrorCode
    {

    }

}
