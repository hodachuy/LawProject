using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class DocumentsTypeRepositoryAsync : GenericRepositoryAsync<DocumentsType>, IDocumentsTypeRepositoryAsync
    {
        private readonly DbSet<DocumentsType> _documentsTypes;
        public DocumentsTypeRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _documentsTypes = dbContext.Set<DocumentsType>();
        }
    }
}
