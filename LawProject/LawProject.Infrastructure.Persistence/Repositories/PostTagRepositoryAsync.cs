using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class PostTagRepositoryAsync : GenericRepositoryAsync<PostTag>, IPostTagRepositoryAsync
    {
        private readonly DbSet<PostTag> _postTags;
        public PostTagRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _postTags = dbContext.Set<PostTag>();
        }
    }
}

