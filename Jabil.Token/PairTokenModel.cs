using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jabil.Token
{
    public class RefreshTokenInfo
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string? GD { get; set; }
        /// <summary>
        /// User Id
        /// </summary>
        public string? UD { get; set; }
        /// <summary>
        /// Expire Time
        /// </summary>
        public DateTime ET { get; set; }
        /// <summary>
        /// Is Valid
        /// </summary>
        public bool IsValid { get; set; }
    }

    public class PairTokenT
    {
        /// <summary>
        /// jwt-token access
        /// </summary>
        public string? Token { get; set; }
        /// <summary>
        /// jwt-token refresh
        /// </summary>
        public string? RefreshToken { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// access guid 
        /// </summary>
        public TokenCode? Code { get; set; }
    }
}
