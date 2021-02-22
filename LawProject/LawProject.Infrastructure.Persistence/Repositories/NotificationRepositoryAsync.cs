using LawProject.Application.Interfaces.Repositories;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace LawProject.Infrastructure.Persistence.Repositories
{
    public class NotificationRepositoryAsync : GenericRepositoryAsync<Notification>, INotificationRepositoryAsync
    {
        private readonly DbSet<Notification> _notifications;

        public NotificationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _notifications = dbContext.Set<Notification>();
        }
    }
}
