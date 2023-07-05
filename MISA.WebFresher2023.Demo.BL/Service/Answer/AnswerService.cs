using AutoMapper;
using MISA.WebFresher2023.Demo.BL.Dto;
using MISA.WebFresher2023.Demo.DL.Entity;
using MISA.WebFresher2023.Demo.DL.Repository;

namespace MISA.WebFresher2023.Demo.BL.Service
{
    public class AnswerService : BaseService<Answer, AnswerDto, AnswerCreateDto, AnswerUpdateDto>, IAnswerService
    {
        public AnswerService(
            IAnswerRepository answerRepository,
            IMapper mapper) : base(answerRepository, mapper)
        {
        }
    }
}
