using CrowdFundingProject.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCrowdFundingProject(this IServiceCollection services)
        {
            //services.AddDbContext<Data.AppDbContext>;  //TODO

            services.AddScoped<IBackerService, BackerService>();
            services.AddScoped<ICreatorService, CreatorService>();
            services.AddScoped<IBundleService, BundleService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITagService, TagService>();
        }
    }
}
