using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jabil.Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet(Name = "GetVisitorTokenV2")]
        public string GetVisitorTokenV2()
        {
            var userInfo = new UserInfo
            {
                PaCode = "CN51",// input.PaCode,
                UserId = -1,
                SiteId = 1122334455,// site.SiteId,
                SiteCode = "CTU",// site.SiteCode ?? "",
                ClientId = "",
                LoginType = 1,
                WorkDayId = "-1",
                Name = "Vistor",
                UserType = "0",  //访客
                AppLoginType = "1"
            };
            var pairToken = PairToken.GeneratePairToken(userInfo);
            return pairToken.Token;
        }

    }
}
