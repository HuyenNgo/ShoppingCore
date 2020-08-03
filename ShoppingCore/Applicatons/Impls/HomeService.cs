using Dapper;
using ShoppingCore.Applicatons.Dtos.Home;
using ShoppingCore.Applicatons.Intfs;
using ShoppingCore.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCore.Applicatons.Impls
{
    public class HomeService : BaseApplication, IHomeService
    {
        public HomeService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<HomeDto> GetAllHomeData()
        {
            string _commandText = "SELECT * FROM Slides";
            IEnumerable<SlideDto> slides = null;


            await CommandHelper.ExecuteCommandAsync(_connStr,
                  conn =>
                  {
                      slides = conn.Query<SlideDto>(_commandText, null, commandType: CommandType.Text);
                  });


            return new HomeDto()
            {
                Title="Home",
                Slides = slides
            };
        }

    }
}
