using AutoMapper;
using LawProject.Application.Features.LegalDocuments.Commands.Create;
using LawProject.Application.Features.LegalDocuments.Queries.GetAll;
using LawProject.Application.Features.QuestionAnswers.Commands.Create;
using LawProject.Domain.Entities;

namespace LawProject.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateLegalCommand, LegalDocument>();
            CreateMap<GetAllLegalsQuery, GetAllLegalsParameter>();

            CreateMap<CreateQuestionAnswerCommand, Question>();
        }
    }
}
