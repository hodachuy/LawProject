using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class LegalTypeRepositoryAsync : GenericRepositoryAsync<LegalDocumentType>, ILegalTypeRepositoryAsync
    {
        private readonly DbSet<LegalDocumentType> _legalTypes;

        public LegalTypeRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _legalTypes = dbContext.Set<LegalDocumentType>();
        }
    }
}
