using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdFundingProject.Services
{
    public interface ICartService
    {
        CartOptions AddItemToCart(BackerOptions backer);
        bool DeleteItemFromCart(int id);
    }
}
