using ShoppingCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Intfs
{
    public interface IProductCategoryService
    {

        Task<IEnumerable<ProductCategory>> ClientGetAll();


    }
}
