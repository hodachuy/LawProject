using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class LegalRelateRepositoryAsync : GenericRepositoryAsync<LegalDocumentRelate>, ILegalRelateRepositoryAsync
    {
        private readonly DbSet<LegalDocumentRelate> _legalRelates;
        public LegalRelateRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _legalRelates = dbContext.Set<LegalDocumentRelate>();
        }
    }
}
