using AutoMapper;
using MISA.WebFresher2023.Demo.BL.Dto;
using MISA.WebFresher2023.Demo.DL.Entity;
using MISA.WebFresher2023.Demo.DL.Repository;

namespace MISA.WebFresher2023.Demo.BL.Service
{
    public class QuestionService : BaseService<Question, QuestionDto, QuestionCreateDto, QuestionUpdateDto>, IQuestionService
    {
        public QuestionService(
            IQuestionRepository questionRepository,
            IMapper mapper) : base(questionRepository, mapper)
        {
        }
    }
}
