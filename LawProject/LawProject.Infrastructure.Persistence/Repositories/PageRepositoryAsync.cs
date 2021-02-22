using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class PageRepositoryAsync : GenericRepositoryAsync<Page>, IPageRepositoryAsync
    {
        private readonly DbSet<Page> _pages;

        public PageRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _pages = dbContext.Set<Page>();
        }
    }
}
