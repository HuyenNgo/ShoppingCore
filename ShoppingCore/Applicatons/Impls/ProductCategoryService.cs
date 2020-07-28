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

        public async Task<PaginationSet<ProductCategory>> GetAll(string keyword, int page, int pageSize)
        {
            string _commandText = "ProductCategories_Search";
            IEnumerable<ProductCategory> productCategories = null;

            var p = new DynamicParameters();
            p.Add("@Keyword", keyword ?? default);
            p.Add("@Page", page < 0 ? 1 : page);
            p.Add("@PageSize", pageSize);
            p.Add("@TotalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                  {
                      productCategories = conn.Query<ProductCategory>(_commandText, p, commandType: CommandType.StoredProcedure);
                  });

            int totalCount = p.Get<int>("@TotalCount");

            return new PaginationSet<ProductCategory>()
            {
                Items = productCategories,
                Page = page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((decimal)totalCount / pageSize)
            };
        }
    }
}
