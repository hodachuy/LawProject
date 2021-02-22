using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class TagRepositoryAsync : GenericRepositoryAsync<Tag>, ITagRepositoryAsync
    {
        private readonly DbSet<Tag> _tags;

        public TagRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _tags = dbContext.Set<Tag>();
        }
    }
}


