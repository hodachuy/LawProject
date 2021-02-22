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
    public class ActivityRepositoryAsync : GenericRepositoryAsync<Activity>, IActivityRepositoryAsync
    {
        private readonly DbSet<Activity> _activities;
        public ActivityRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _activities = dbContext.Set<Activity>();
        }
    }
}
