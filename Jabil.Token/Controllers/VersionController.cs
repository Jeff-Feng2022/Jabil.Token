using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.AspNetCore;

namespace Jabil.Token.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionController : ControllerBase
    {

        private readonly IRedisDatabase _redisDatabase;
        public VersionController(IRedisDatabase redisDatabase)
        {
            _redisDatabase = redisDatabase;
        }


        [HttpGet(Name = "GetLaestVersion")]
        public async Task<MbH5Version> GetLaestVersion()
        {
            

            string key = "MobileApp_LatestVersion_Json";
            var version = await _redisDatabase.GetAsync<MbH5Version>(key);
            return version;

        }
    }
}
