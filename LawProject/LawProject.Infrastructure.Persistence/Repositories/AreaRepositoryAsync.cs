using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class AreaRepositoryAsync : GenericRepositoryAsync<Area>, IAreaRepositoryAsync
    {
        private readonly DbSet<Area> _areas;
        public AreaRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _areas = dbContext.Set<Area>();
        }
    }
}
