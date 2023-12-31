﻿using Microsoft.Extensions.Configuration;
using MISA.WebFresher2023.Demo.DL.Entity;

namespace MISA.WebFresher2023.Demo.DL.Repository
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
