using CrowdFundingProject.Data;

namespace CrowdFundingProject.Services
{
    public class BackerBundleService
    {
        private readonly AppDbContext dbContext;
        public BackerBundleService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}