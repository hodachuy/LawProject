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
    public class AgencyRepositoryAsync : GenericRepositoryAsync<Agency>, IAgencyRepositoryAsync
    {
        private readonly DbSet<Agency> _agencies;
        public AgencyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _agencies = dbContext.Set<Agency>();
        }
    }
}
