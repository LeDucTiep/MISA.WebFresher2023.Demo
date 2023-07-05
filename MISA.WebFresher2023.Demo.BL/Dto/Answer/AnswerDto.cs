using MISA.WebFresher2023.Demo.Common.Attribute;
using MISA.WebFresher2023.Demo.Common.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher2023.Demo.BL.Dto
{
    public class AnswerDto
    {
        public Guid AnswerId { get; set; }

        [MSMaxLength(Length = 100, ErrorCode = (int)AnswerErrorCode.FullNameToLong)]
        public string FullName { get; set; }

        [MSMaxLength(Length = 255, ErrorCode = (int)AnswerErrorCode.ContentToLong)]
        public string Content { set; get; }

        public Guid QuestionId { get; set; }
    }
}
