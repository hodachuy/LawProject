using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class EditorRepositoryAsync : GenericRepositoryAsync<Editor>, IEditorRepositoryAsync
    {
        private readonly DbSet<Editor> _editors;
        public EditorRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _editors = dbContext.Set<Editor>();
        }
    }
}
