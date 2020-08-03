using Microsoft.AspNetCore.Mvc;
using ShoppingCore.Infrastructure.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Infrastructure.Core
{
    [TypeFilter(typeof(CoreExceptionFilter))]
    public class ApiBaseController: ControllerBase
    {
    }
}
