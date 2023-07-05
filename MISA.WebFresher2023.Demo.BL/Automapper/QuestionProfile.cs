using AutoMapper;
using MISA.WebFresher2023.Demo.BL.Dto;
using MISA.WebFresher2023.Demo.DL.Entity;
using MISA.WebFresher2023.Demo.DL.Model;

namespace MISA.WebFresher2023.Demo.BL.Automapper
{
    /// <summary>
    /// Class Question dành cho automapper 
    /// </summary>
    /// Author: LeDucTiep (07/06/2023)
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            // Map Question sang QuestionDto
            CreateMap<Answer, QuestionDto>();
            CreateMap<QuestionDto, Answer>();
            // Map QuestionCreateDto sang Question
            CreateMap<QuestionCreateDto, Answer>();
            // Map QuestionUpdateDto sang Question
            CreateMap<QuestionUpdateDto, Answer>();
            CreateMap<BasePage<Answer>, BasePage<QuestionDto>>();

            CreateMap<QuestionUpdateDto, Answer>();

            CreateMap<QuestionCreateDto, QuestionDto>();

            CreateMap<QuestionUpdateDto, QuestionDto>();
        }
    }
}
