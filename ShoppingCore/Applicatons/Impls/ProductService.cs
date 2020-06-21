using Dapper;
using ShoppingCore.Applicatons.Intfs;
using ShoppingCore.Infrastructure.Core;
using ShoppingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Impls
{
    public class ProductService : BaseApplication, IProductService
    {
        public ProductService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            string _commandText = "Select * from Products";
            IEnumerable<Product> products = null;
            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                   {
                      products = conn.Query<Product>(_commandText);
                   });
            return products.ToList();
        }

        public async Task<IEnumerable<Product>> gethotproduct(int key)
        {
            string _commandText = "Select top "+key+ "* from Products where Status=1 and HotFlag = 1";
            IEnumerable<Product> products = null;
            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                  {
                      products = conn.Query<Product>(_commandText);
                  });
            return products.ToList();
        }

        public async Task<IEnumerable<Product>> getlastproduct(int key)
        {
            string _commandText = "Select top " + key + "* from Products where Status=1 ";
            IEnumerable<Product> products = null;
            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                  {
                      products = conn.Query<Product>(_commandText);
                  });
            return products.ToList();
        }
    }
}
