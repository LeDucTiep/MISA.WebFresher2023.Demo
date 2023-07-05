using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher2023.Demo.BL.Dto;
using MISA.WebFresher2023.Demo.BL.Service;
using MISA.WebFresher2023.Demo.DL.Entity;

namespace MISA.WebFresher2023.Demo.Controllers
{
    [Route("api/v1/[controller]s")]
    public class QuestionController : BaseController<Question, QuestionDto, QuestionCreateDto, QuestionUpdateDto>
    {
        public QuestionController(IQuestionService questionService
            ) : base(questionService)
        {
        }
    }
}
