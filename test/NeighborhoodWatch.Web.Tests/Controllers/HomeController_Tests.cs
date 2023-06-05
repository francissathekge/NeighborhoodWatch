using System.Threading.Tasks;
using NeighborhoodWatch.Models.TokenAuth;
using NeighborhoodWatch.Web.Controllers;
using Shouldly;
using Xunit;

namespace NeighborhoodWatch.Web.Tests.Controllers
{
    public class HomeController_Tests: NeighborhoodWatchWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}