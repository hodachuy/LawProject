using LawProject.Application.Interfaces;
using LawProject.Application.Interfaces.Repositories;
using LawProject.Infrastructure.Persistence.Contexts;
using LawProject.Infrastructure.Persistence.Repositories;
using LawProject.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawProject.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseNpgsql(
                   configuration.GetConnectionString("LawProjectConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)).EnableSensitiveDataLogging());
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();
            services.AddTransient<IActivityRepositoryAsync, ActivityRepositoryAsync>();
            services.AddTransient<IAgencyRepositoryAsync, AgencyRepositoryAsync>();
            services.AddTransient<IAnswerRepositoryAsync, AnswerRepositoryAsync>();
            services.AddTransient<IAreaRepositoryAsync, AreaRepositoryAsync>();
            services.AddTransient<IDocumentsTypeRepositoryAsync, DocumentsTypeRepositoryAsync>();
            services.AddTransient<IEditorRepositoryAsync, EditorRepositoryAsync>();
            services.AddTransient<ILawOfficeRepositoryAsync, LawOfficeRepositoryAsync>();
            services.AddTransient<ILawyerRepositoryAsync, LawyerRepositoryAsync>();
            services.AddTransient<ILegalGroupRepositoryAsync, LegalGroupRepositoryAsync>();
            services.AddTransient<ILegalTypeRepositoryAsync, LegalTypeRepositoryAsync>();
            services.AddTransient<ILegalRepositoryAsync, LegalRepositoryAsync>();
            services.AddTransient<ILegalRelateRepositoryAsync, LegalRelateRepositoryAsync>();
            services.AddTransient<INotificationRepositoryAsync, NotificationRepositoryAsync>();
            services.AddTransient<IPageRepositoryAsync, PageRepositoryAsync>();
            services.AddTransient<IQuestionCommentRepositoryAsync, QuestionCommentRepositoryAsync>();
            services.AddTransient<IQuestionRepositoryAsync, QuestionRepositoryAsync>();
            services.AddTransient<IQuestionTagRepositoryAsync, QuestionTagRepositoryAsync>();
            services.AddTransient<ITagRepositoryAsync, TagRepositoryAsync>();
            services.AddTransient<IUploadFileRepositoryAsync, UploadFileRepositoryAsync>();
            services.AddTransient<IPostRepositoryAsync, PostRepositoryAsync>();
            services.AddTransient<IPostCategoryRepositoryAsync, PostCategoryRepositoryAsync>();
            services.AddTransient<IPostTagRepositoryAsync, PostTagRepositoryAsync>();

            #endregion
        }
    }
}
