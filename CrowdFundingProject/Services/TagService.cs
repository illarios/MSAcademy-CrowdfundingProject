using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public class TagService : ITagService
    {
        private readonly AppDbContext dbContext;
        public TagService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Tag GetTagbyId(int tagId)
        {
            Tag tag = dbContext.Tags.Find(tagId);
            return tag;
        }
    }
}
