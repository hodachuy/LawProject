using LawProject.Application.Interfaces.Repositories;
using LawProject.Application.Wrappers;
using AutoMapper;
using LawProject.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LawProject.Domain.Enum;

namespace LawProject.Application.Features.Questions.Commands.CreateQuestion
{
    public partial class CreateQuestionCommand : IRequest<Response<Question>>
    {
    }
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Response<Question>>
    {
        private readonly IQuestionRepositoryAsync _questionRepository;

        private readonly IMapper _mapper;
        public CreateQuestionCommandHandler(IQuestionRepositoryAsync questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<Question>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = _mapper.Map<Question>(request);
            await _questionRepository.AddAsync(question);
            return new Response<Question>(question);
        }
    }
}
