using Dapper;
using ShoppingCore.Applicatons.Intfs;
using ShoppingCore.Infrastructure.Core;
using ShoppingCore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Impls
{
    public class ProductCategoryService : BaseApplication, IProductCategoryService
    {

        public ProductCategoryService (IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<IEnumerable<ProductCategory>> ClientGetAll()
        {
            string _commandText = "ClientGetAll";
            IEnumerable<ProductCategory> productCategory = null;
            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                  {
                      productCategory = conn.Query<ProductCategory>(_commandText, commandType: CommandType.StoredProcedure);
                  });
            return productCategory.ToList();
        }
    }
}
