using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class QuestionCommentRepositoryAsync : GenericRepositoryAsync<QuestionComment>, IQuestionCommentRepositoryAsync
    {
        private readonly DbSet<QuestionComment> _questionComments;

        public QuestionCommentRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _questionComments = dbContext.Set<QuestionComment>();
        }
    }
}
