﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher2023.Demo.BL.Dto
{
    public class QuestionUpdateDto
    {
        public Guid QuestionId { get; set; }

        public string FullName { get; set; }

        public string Title { get; set; }

        public int Type { get; set; }

        public string Content { get; set; }
    }
}
