using ShoppingCore.Applicatons.Dtos.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Intfs
{
    public interface IHomeService
    {
        Task<HomeDto> GetAllHomeData();
    }
}
