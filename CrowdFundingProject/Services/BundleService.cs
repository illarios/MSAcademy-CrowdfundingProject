using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowdFundingProject.Services
{
    public class BundleService : IBundleService
    {
        private readonly AppDbContext dbContext = new AppDbContext();
        public Bundle AddBundle(BundleOptions bundleOpt, int projectId)
        {
            if (projectId < 0) return null;
            Project project = dbContext.Projects.Find(projectId);
            if (project == null) return null;

            Bundle bundle = new Bundle {
                Description = bundleOpt.Description,
                Prize = bundleOpt.Prize,
                Project = project
            };
            dbContext.Bundles.Add(bundle);
            ////////////////
            project.Bundles.Add(bundle);
            ////////////////
            dbContext.SaveChanges();
            return bundle;
        }
        public List<Bundle> GetBundlesOfProjects(int projectId){
            List<Bundle> bundles = dbContext.Bundles.Where(c => c.Project.Id == projectId).ToList();
            return bundles;
        }
        public List<Bundle> GetBundles()
        {
            List<Bundle> bundles = dbContext.Bundles.ToList();
            return bundles;
        }
        public bool DeleteBundle(int bundleId)
        {
            if (bundleId < 0) return false;
            Bundle bundle = dbContext.Bundles.Find(bundleId);
            if (bundle == null) return false;

            dbContext.Bundles.Remove(bundle);
            dbContext.SaveChanges();
            return true;
        }

        public Bundle UpdateBundle(BundleOptions bundleOpt, int bundleId)
        {
            if (bundleId < 0) return null;
            Bundle bundle = dbContext.Bundles.Find(bundleId);
            if (bundle == null) return null;

            bundle.Description = bundleOpt.Description;
            bundle.Prize = bundleOpt.Prize;
            bundle.Project = bundleOpt.Project;

            dbContext.SaveChanges();
            return bundle;
        }
    }
}
