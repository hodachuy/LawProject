using LawProject.Application.Interfaces.Repositories;
using LawProject.Application.Wrappers;
using AutoMapper;
using LawProject.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using LawProject.Domain.Enum;
using LawProject.Application.Utilities;

namespace LawProject.Application.Features.QuestionAnswers.Commands.Create
{
    public partial class CreateQuestionAnswerCommand : IRequest<Response<Question>>
    {
        public string QuesCode { get; set; }
        public string QuesContent { get; set; }
        public string AnswerContent { get; set; }
        public string Title { get; set; }
        public string AccountID { get; set; }
        public long? AreaID { get; set; }
        public string QuesContentText { get; set; }
        public Status.QuestionAnswer StatusValue { get; set; }
        public bool IsTraining { get; set; }
        public long ViewCount { get; set; }
    }

    public partial class CreateQuestionCommand : IRequest<Response<long>>
    {
        public string QuesContent { get; set; }
        public string AccountID { get; set; }
    }

    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionAnswerCommand, Response<Question>>,
                                                IRequestHandler<CreateQuestionCommand, Response<long>>
    {
        private readonly IQuestionRepositoryAsync _questionRepository;
        private readonly IAnswerRepositoryAsync _answerRepository;
        private readonly IMapper _mapper;
        public CreateQuestionCommandHandler(IQuestionRepositoryAsync questionRepository,
                                            IAnswerRepositoryAsync answerRepository,
                                            IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _answerRepository = answerRepository;
        }

        public async Task<Response<Question>> Handle(CreateQuestionAnswerCommand request, CancellationToken cancellationToken)
        {
            var question = _mapper.Map<Question>(request);
            question.QuesContent = StringUtils.GetSafeHtml(request.QuesContent);
            question.QuesContentText = StringUtils.GetSafeText(request.QuesContent);
            await _questionRepository.AddAsync(question).ConfigureAwait(false);

            // update question code
            question.QuesCode = question.QuesID + question.CreatedDate.ToString("ddMMyyyy");
            await _questionRepository.UpdateAsync(question).ConfigureAwait(false); ;

            // add answer content
            if (!string.IsNullOrWhiteSpace(request.AnswerContent))
            {
                var answer = new Answer();
                answer.AnswerContent = StringUtils.GetSafeHtml(request.AnswerContent);
                answer.AccountID = request.AccountID;
                answer.QuesID = question.QuesID;
                await _answerRepository.AddAsync(answer);
            }

            return new Response<Question>(question);
        }

        public async Task<Response<long>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new Question();
            question.QuesContent = StringUtils.GetSafeHtml(request.QuesContent);
            question.QuesContentText = StringUtils.GetSafeText(request.QuesContent);
            await _questionRepository.AddAsync(question).ConfigureAwait(false);

            // update question code
            question.QuesCode = question.QuesID + question.CreatedDate.ToString("ddMMyyyy");
            await _questionRepository.UpdateAsync(question);

            return new Response<long>(question.QuesID);
        }
    }
}
