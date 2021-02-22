using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class PostCategoryRepositoryAsync : GenericRepositoryAsync<PostCategory>, IPostCategoryRepositoryAsync
    {
        private readonly DbSet<PostCategory> _postCategories;
        public PostCategoryRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _postCategories = dbContext.Set<PostCategory>();
        }
    }
}
