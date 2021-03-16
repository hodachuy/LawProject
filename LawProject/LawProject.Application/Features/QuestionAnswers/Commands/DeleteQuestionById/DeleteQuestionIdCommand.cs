using LawProject.Application.Exceptions;
using LawProject.Application.Interfaces.Repositories;
using LawProject.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LawProject.Application.Features.QuestionAnswers.Commands.DeleteQuestionById
{
    public class DeleteQuestionIdCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public class DeleteQuestionIdCommandHandler : IRequestHandler<DeleteQuestionIdCommand, Response<long>>
        {
            private readonly IQuestionRepositoryAsync _questionRepository;
            public DeleteQuestionIdCommandHandler(IQuestionRepositoryAsync questionRepository)
            {
                _questionRepository = questionRepository;
            }
            public async Task<Response<long>> Handle(DeleteQuestionIdCommand command, CancellationToken cancellationToken)
            {
                var question = await _questionRepository.GetByIdAsync(command.Id);
                if (question == null) throw new ApiException($"Question Not Found.");
                await _questionRepository.DeleteAsync(question);
                return new Response<long>(question.QuesID);
            }
        }
    }
}
