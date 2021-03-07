using FluentValidation;
using LawProject.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LawProject.Application.Features.Questions.Commands.CreateQuestion
{
    public class CreateQuestionCommandValidator : AbstractValidator<CreateQuestionCommand>
    {
        private readonly IQuestionRepositoryAsync questionRepository;

        public CreateQuestionCommandValidator(IQuestionRepositoryAsync questionRepository)
        {
            this.questionRepository = questionRepository;

            RuleFor(q => q.QuesCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueQuestioncode).WithMessage("{PropertyName} already exists.");

            RuleFor(q => q.QuesContent)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(q => q.QuesCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(q => q.StatusValue)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(q => q.AccountID)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }

        private async Task<bool> IsUniqueQuestioncode(string questionCode, CancellationToken cancellationToken)
        {
            return await questionRepository.IsUniqueQuestionCodeAsync(questionCode);
        }
    }
}
