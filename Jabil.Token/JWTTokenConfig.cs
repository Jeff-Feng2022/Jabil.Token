using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jabil.Token
{
    public class JWTTokenConfig
    {
        /// <summary>
        /// 签发人
        /// </summary>
        /// <value></value>
        public static string Issuer { get; set; } = string.Empty;

        /// <summary>
        /// 受众
        /// </summary>
        /// <value></value>
        public static string Audience { get; set; } = string.Empty;

        /// <summary>
        /// Acess Token 签名秘钥
        /// </summary>
        public static string AccessTokenSigningKey { get; set; } = string.Empty;

        /// <summary>
        /// Refresh token 签名秘钥
        /// </summary>
        public static string RefreshTokenSigningKey { get; set; } = string.Empty;
        /// <summary>
        /// app refresh token过期时间：分钟
        /// </summary>
        public static int RefreshTokenExpireMinutesForApp { get; set; }
        /// <summary>
        /// portal refresh token过期时间：分钟
        /// </summary>
        public static int RefreshTokenExpireMinutesForPortal { get; set; }
        /// <summary>
        /// app access token过期时间：分钟
        /// </summary>
        public static int AccessTokenExpireMinutesForApp { get; set; }
        /// <summary>
        /// portal access token过期时间：分钟
        /// </summary>
        public static int AccessTokenExpireMinutesForPortal { get; set; }
    }
}
