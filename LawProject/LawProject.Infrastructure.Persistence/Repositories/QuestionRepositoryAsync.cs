using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class QuestionRepositoryAsync : GenericRepositoryAsync<Question>, IQuestionRepositoryAsync
    {
        private readonly DbSet<Question> _questions;

        public QuestionRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _questions = dbContext.Set<Question>();
        }

        public Task<bool> IsUniqueQuestionCodeAsync(string questionCode)
        {
            return _questions
                .AllAsync(p => p.QuesCode != questionCode);
        }
    }
}

