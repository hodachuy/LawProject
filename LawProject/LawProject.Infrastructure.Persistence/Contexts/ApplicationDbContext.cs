using LawProject.Application.Interfaces;
using LawProject.Domain.Common;
using LawProject.Domain.Entities;
using LawProject.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LawProject.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;
        private readonly IDomainEventService _domainEventService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser, IDomainEventService domainEventService) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
            _domainEventService = domainEventService;

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<DocumentsType> DocumentsTypes { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<LegalDocument> LegalDocuments { get; set; }
        public DbSet<LegalDocumentGroup> LegalDocumentGroups { get; set; }
        public DbSet<LegalDocumentRelate> LegalDocumentRelates { get; set; }
        public DbSet<LegalDocumentType> LegalDocumentTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionComment> QuestionComments { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UploadFile> UploadFiles { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get;set; }

        public virtual void Save()
        {
            base.SaveChanges();
        }
        public override int SaveChanges()
        {
            TrackChanges();
            var result =  base.SaveChanges();
            DispatchEvents();
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            TrackChanges();
            var result = await base.SaveChangesAsync(cancellationToken);
            await DispatchEvents();
            return result;
        }

        private void TrackChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = _dateTime.NowUtc;
                        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
                        break;
                }
            }
        }

        /// <summary>
        /// dispatch domain event to logs 
        /// </summary>
        /// <returns></returns>
        private async Task DispatchEvents()
        {
            while (true)
            {
                var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
                    .Select(x => x.Entity.DomainEvents)
                    .SelectMany(x => x)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .FirstOrDefault();
                if (domainEventEntity == null) break;

                domainEventEntity.IsPublished = true;
                await _domainEventService.Publish(domainEventEntity);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Configure using Fluent API
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ActivityConfiguration());
            builder.ApplyConfiguration(new AgencyConfiguration());
            builder.ApplyConfiguration(new AnswerConfiguration());
            builder.ApplyConfiguration(new AreaConfiguration());
            builder.ApplyConfiguration(new ArticleConfiguration());
            builder.ApplyConfiguration(new ChapterConfiguration());
            builder.ApplyConfiguration(new DistrictConfiguration());
            builder.ApplyConfiguration(new DocumentsTypeConfiguration());
            builder.ApplyConfiguration(new EditorConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
            builder.ApplyConfiguration(new LawOfficeConfiguration());
            builder.ApplyConfiguration(new LawyerConfiguration());
            builder.ApplyConfiguration(new LegalDocumentConfiguration());
            builder.ApplyConfiguration(new LegalDocumentGroupConfiguration());
            builder.ApplyConfiguration(new LegalDocumentRelateConfiguration());
            builder.ApplyConfiguration(new LegalDocumentTypeConfiguration());
            builder.ApplyConfiguration(new NotificationConfiguration());
            builder.ApplyConfiguration(new PageConfiguration());
            builder.ApplyConfiguration(new PartConfiguration());
            builder.ApplyConfiguration(new ProvinceConfiguration());
            builder.ApplyConfiguration(new QuestionCommentConfiguration());
            builder.ApplyConfiguration(new QuestionConfiguration());
            builder.ApplyConfiguration(new QuestionTagConfiguration());
            builder.ApplyConfiguration(new TagConfiguration());
            builder.ApplyConfiguration(new UploadFileConfiguration());
            builder.ApplyConfiguration(new WardConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new PostTagConfiguration());
            builder.ApplyConfiguration(new PostCategoryConfiguration());
            //All Decimals will have 18,6 Range

            //foreach (var property in builder.Model.GetEntityTypes()
            //.SelectMany(t => t.GetProperties())
            //.Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            //{
            //    property.SetColumnType("decimal(18,6)");
            //}

            base.OnModelCreating(builder);
        }
    }
}
