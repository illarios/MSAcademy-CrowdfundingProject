using CrowdFundingProject.Data;
using CrowdFundingProject.Models;
using CrowdFundingProject.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowdFundingProject.Services
{
    public class CartService : ICartService
    {
        private readonly AppDbContext dbContext = new AppDbContext();
        public Cart AddItemToCart(Backer backer, int projectId, int bundleId)
        {
            Cart cart = dbContext.Carts.Find(backer.Cart);

            if (bundleId < 0) return null;
            Bundle bundle = dbContext.Bundles.Find(bundleId);
            if (bundle == null) return null;

            if (projectId < 0) return null;
            Project project = dbContext.Projects.Find(projectId);
            if (project == null) return null;

            cart.Projects.Add(project);
            cart.Bundles.Add(bundle);
            return cart;
        }

        public bool DeleteItemFromCart(int cartId, int projectId, int bundleId)
        {
            if (cartId < 0) return false;
            Cart cart = dbContext.Carts.Find(cartId);
            if (cart == null) return false;

            if (bundleId < 0) return false;
            Bundle bundle = dbContext.Bundles.Find(bundleId);
            if (bundle == null) return false;

            if (projectId < 0) return false;
            Project project = dbContext.Projects.Find(projectId);
            if (project == null) return false;

            dbContext.Carts.Find(cart).Bundles.Remove(bundle);
            dbContext.Carts.Find(cart).Projects.Remove(project);
            dbContext.SaveChanges();
            return true;
        }

        public List<Bundle> GetCartItems(int cartId)
        {
            Cart cart = dbContext.Carts.Find(cartId);
            List<Bundle> bundles = cart.Bundles.ToList();
            return bundles;
        }
    }
}
