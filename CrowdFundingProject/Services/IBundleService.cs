using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public interface IBundleService
    {
        BundleOptions AddBundle(Project project);
        BundleOptions UpdateBundle(int id);
        bool DeleteBundle(int id);
    }
}
