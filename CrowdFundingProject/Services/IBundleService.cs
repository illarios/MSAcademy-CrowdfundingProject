using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public interface IBundleService
    {
        Bundle AddBundle(BundleOptions bundleOpt, int projectId);
        Bundle UpdateBundle(BundleOptions bundleOpt, int bundleId);
        List<Bundle> GetBundles();
        List<Bundle> GetBundlesOfProjects(int projectId);
        bool DeleteBundle(int bundleId);
    }
}
