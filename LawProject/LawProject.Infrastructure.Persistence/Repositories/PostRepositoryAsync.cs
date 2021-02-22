using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class PostRepositoryAsync : GenericRepositoryAsync<Post>, IPostRepositoryAsync
    {
        private readonly DbSet<Post> _posts;
        public PostRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _posts = dbContext.Set<Post>();
        }
    }
}
