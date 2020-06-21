using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Infrastructure.Core
{
    public class BaseApplication
    {
        protected string _connStr;
        protected IConfiguration config;
        public BaseApplication(IServiceProvider serviceProvider)
        {
            this.config = (IConfiguration)serviceProvider.GetService(typeof(IConfiguration));
            this._connStr = this.config.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
    }
}
