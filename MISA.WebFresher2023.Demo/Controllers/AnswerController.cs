using MISA.WebFresher2023.Demo.BL.Dto;
using MISA.WebFresher2023.Demo.BL.Service;
using MISA.WebFresher2023.Demo.DL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace MISA.WebFresher2023.Demo.Controllers
{
    [Route("api/v1/[controller]s")]
    public class AnswerController : BaseController<Answer, AnswerDto, AnswerCreateDto, AnswerUpdateDto>
    {
        public AnswerController(IAnswerService answerService
            ) : base(answerService)
        {
        }
    }
}
