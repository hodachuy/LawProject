using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class QuestionTagRepositoryAsync : GenericRepositoryAsync<QuestionTag>, IQuestionTagRepositoryAsync
    {
        private readonly DbSet<QuestionTag> _questionTags;

        public QuestionTagRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _questionTags = dbContext.Set<QuestionTag>();
        }
    }
}

