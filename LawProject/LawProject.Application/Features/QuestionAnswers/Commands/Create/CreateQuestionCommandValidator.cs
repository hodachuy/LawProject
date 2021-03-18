using FluentValidation;
using LawProject.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LawProject.Application.Features.QuestionAnswers.Commands.Create
{
    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionAnswerCommand>
    {
        private readonly IQuestionRepositoryAsync questionRepository;

        public CreateQuestionCommandValidator(IQuestionRepositoryAsync questionRepository)
        {
            this.questionRepository = questionRepository;

            RuleFor(q => q.QuesContent)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(q => q.QuesCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsUniqueQuestioncode).WithMessage("{PropertyName} already exists.");

            RuleFor(q => q.QuesContentText)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();        
        }

        private async Task<bool> IsUniqueQuestioncode(string questionCode, CancellationToken cancellationToken)
        {
            return await questionRepository.IsUniqueQuestionCodeAsync(questionCode);
        }
    }
}
