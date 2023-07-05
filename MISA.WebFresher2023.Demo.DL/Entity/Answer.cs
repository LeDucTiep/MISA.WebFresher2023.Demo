using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher2023.Demo.DL.Entity
{
    public class Answer : BaseEntity
    {
        public Guid AnswerId { get; set; }

        public string FullName { get; set; }

        public string Content { set; get; }

        public Guid QuestionId { get; set; }
    }
}
