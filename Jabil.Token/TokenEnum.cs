using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jabil.Token
{
    public enum TokenCode
    {
        /// <summary>
        /// token ok
        /// </summary>
        TOKEN_OK = 200,

        /// <summary>
        /// token invalid
        /// </summary>
        TOKEN_INVALID = 401,

        /// <summary>
        /// refresh token invalid(失效)
        /// </summary>
        REFRESH_TOKEN_INVALID = 1001,

        /// <summary>
        /// access token invalid(失效)
        /// </summary>
        ACCESS_TOKEN_INVALID = 1002,

        /// <summary>
        /// refresh token and access token not match(2个token不匹配)
        /// </summary>
        TWO_TOKEN_NOT_MATCH = 1003,

    }
}
