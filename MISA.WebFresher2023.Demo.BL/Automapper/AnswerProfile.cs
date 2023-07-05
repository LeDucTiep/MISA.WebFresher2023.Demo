using AutoMapper;
using MISA.WebFresher2023.Demo.BL.Dto;
using MISA.WebFresher2023.Demo.DL.Entity;
using MISA.WebFresher2023.Demo.DL.Model;
using static Dapper.SqlMapper;

namespace MISA.WebFresher2023.Demo.BL.Automapper
{
    /// <summary>
    /// Class Answer dành cho automapper 
    /// </summary>
    /// Author: LeDucTiep (07/06/2023)
    public class AnswerProfile : Profile
    {
        public AnswerProfile()
        {
            // Map Answer sang AnswerDto
            CreateMap<Answer, QuestionDto>();
            CreateMap<QuestionDto, Answer>();
            // Map AnswerCreateDto sang Answer
            CreateMap<QuestionCreateDto, Answer>();
            // Map AnswerUpdateDto sang Answer
            CreateMap<QuestionUpdateDto, Answer>();
            CreateMap<BasePage<Answer>, BasePage<QuestionDto>>();

            CreateMap<QuestionUpdateDto, Answer>();

            CreateMap<QuestionCreateDto, QuestionDto>();

            CreateMap<QuestionUpdateDto, QuestionDto>();
        }
    }
}
