using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class UploadFileRepositoryAsync : GenericRepositoryAsync<UploadFile>, IUploadFileRepositoryAsync
    {
        private readonly DbSet<UploadFile> _uploadFiles;

        public UploadFileRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _uploadFiles = dbContext.Set<UploadFile>();
        }
    }
}



