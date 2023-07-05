using MISA.WebFresher2023.Demo.Common.Attribute;
using MISA.WebFresher2023.Demo.Common.Constant;

namespace MISA.WebFresher2023.Demo.BL.Dto
{
    public class QuestionDto
    {
        public Guid QuestionId { get; set; }

        public string FullName { get; set; }

        public string Title { get; set; }

        public int Type { get; set; }

        public string Content { get; set; }
    }
}
