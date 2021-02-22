using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class LawyerRepositoryAsync : GenericRepositoryAsync<Lawyer>, ILawyerRepositoryAsync
    {
        private readonly DbSet<Lawyer> _lawyers;
        public LawyerRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _lawyers = dbContext.Set<Lawyer>();
        }
    }
}
