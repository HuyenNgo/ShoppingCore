using Dapper;
using ShoppingCore.Applicatons.Intfs;
using ShoppingCore.Infrastructure.Core;
using ShoppingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace ShoppingCore.Applicatons.Impls
{
    public class ProductService : BaseApplication, IProductService
    {
        public ProductService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public async Task<PaginationSet<Product>> GetAll(string keyword, int page, int pageSize)
        {
            string _commandText = "Products_Search";
            IEnumerable<Product> products = null;

            var p = new DynamicParameters();
            p.Add("@Keyword", keyword ?? default);
            p.Add("@Page", page < 0 ? 1 : page);
            p.Add("@PageSize", pageSize);
            p.Add("@TotalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                  {
                      products = conn.Query<Product>(_commandText, p, commandType: CommandType.StoredProcedure);
                  });

            int totalCount = p.Get<int>("@TotalCount");

            return new PaginationSet<Product>()
            {
                Items = products,
                Page = page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((decimal)totalCount / pageSize)
            };


        }

        public async Task<PaginationSet<Product>> getallbycategory(int keyword, int page, int pageSize)
        {
            string _commandText = "Products_GetID";
            IEnumerable<Product> products = null;

            var p = new DynamicParameters();
            p.Add("@Keyword", keyword < 0 ? 1 :keyword);
            p.Add("@Page", page < 0 ? 1 : page);
            p.Add("@PageSize", pageSize);
            p.Add("@TotalCount", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                   {
                       products = conn.Query<Product>(_commandText, p, commandType: CommandType.StoredProcedure);
                   });

            int totalCount = p.Get<int>("@TotalCount");

            return new PaginationSet<Product>()
            {
                Items = products,
                Page = page,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((decimal)totalCount / pageSize)
            };
        }

        public async Task<IEnumerable<Product>> GetById(int key)
        {
            var p = new DynamicParameters();
            p.Add("@key", key);
            string _commandText = "GetById";
            IEnumerable<Product> products = null;
            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                  {
                      products = conn.Query<Product>(_commandText, p, commandType: CommandType.StoredProcedure);
                  });
            return products.ToList();
        }

        public async Task<IEnumerable<Product>> gethotproduct(int key)
        {

            var p = new DynamicParameters();
            p.Add("@key", key);
            string _commandText = "GetHotProduct";
            IEnumerable<Product> products = null;
            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                  {
                      products = conn.Query<Product>(_commandText, p, commandType: CommandType.StoredProcedure);
                  });
            return products.ToList();
        }

        public async Task<IEnumerable<Product>> getlastproduct(int key)
        {
            var p = new DynamicParameters();
            p.Add("@key", key);
            string _commandText = "GetLastproduct";
            IEnumerable<Product> products = null;
            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                  {
                      products = conn.Query<Product>(_commandText, p, commandType: CommandType.StoredProcedure);
                  });
            return products.ToList();
        }
    }
}
