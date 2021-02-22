using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class AnswerRepositoryAsync : GenericRepositoryAsync<Answer>, IAnswerRepositoryAsync
    {
        private readonly DbSet<Answer> _answers;
        public AnswerRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _answers = dbContext.Set<Answer>();
        }
    }
}
