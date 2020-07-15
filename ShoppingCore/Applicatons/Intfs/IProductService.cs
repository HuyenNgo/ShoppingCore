using ShoppingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Intfs
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> gethotproduct(int key);
        Task<IEnumerable<Product>> getlastproduct(int key);
        Task<IEnumerable<Product>> GetById(int key);
    }
}
