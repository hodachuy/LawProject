using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class LawOfficeRepositoryAsync : GenericRepositoryAsync<LawOffice>, ILawOfficeRepositoryAsync
    {
        private readonly DbSet<LawOffice> _lawOffices;
        public LawOfficeRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _lawOffices = dbContext.Set<LawOffice>();
        }
    }
}
