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
        public async Task<IEnumerable<Product>> GetAll()
        {
            string _commandText = "GetAllProduct";
            IEnumerable<Product> products = null;
            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                   {
                       products = conn.Query<Product>(_commandText,commandType: CommandType.StoredProcedure);
                   });
            return products.ToList();
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
                      products = conn.Query<Product>(_commandText,p, commandType: CommandType.StoredProcedure);
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
                      products = conn.Query<Product>(_commandText,p,commandType:CommandType.StoredProcedure);
                  });
            return products.ToList();
        }
    }
}
