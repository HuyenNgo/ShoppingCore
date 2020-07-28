using ShoppingCore.Infrastructure.Core;
using ShoppingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Intfs
{
    public interface IProductService
    {
        Task<PaginationSet<Product>> GetAll(string keyword, int page, int pageSize);
        Task<IEnumerable<Product>> gethotproduct(int key);
        Task<IEnumerable<Product>> getlastproduct(int key);
        Task<IEnumerable<Product>> GetById(int key);
        Task<PaginationSet<Product>> getallbycategory(int keyword, int page, int pageSize);
    }
}
