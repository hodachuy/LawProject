using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class LegalRepositoryAsync : GenericRepositoryAsync<LegalDocument>, ILegalRepositoryAsync
    {
        private readonly DbSet<LegalDocument> _legals;

        public LegalRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _legals = dbContext.Set<LegalDocument>();
        }

        public Task<bool> IsUniqueLegalCode(string legalCode)
        {
            throw new NotImplementedException();
        }
    }
}
