using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public interface ICartService
    {
        Cart AddItemToCart(Backer backer, int projectId, int bundleId);
        List<Bundle> GetCartItems(int cartId);
        bool DeleteItemFromCart(int cartId, int projectId, int bundleId);
    }
}
