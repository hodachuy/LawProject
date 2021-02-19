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
    public class LegalGroupRepositoryAsync : GenericRepositoryAsync<LegalDocumentGroup>, ILegalGroupRepositoryAsync
    {
        private readonly DbSet<LegalDocumentGroup> _legalGroups;
        public LegalGroupRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _legalGroups = dbContext.Set<LegalDocumentGroup>();
        }
    }
}
