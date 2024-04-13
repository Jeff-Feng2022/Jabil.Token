using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;



namespace Jabil.Token
{
    public class PairToken
    {
        private static readonly string issuer = "JabileNextWFO";
        private static readonly string audience = "JabilHREmployee";
        private static readonly string tokenKey = "ohi0Pm+m9AQQg6obn3M%zJ";//acess key
        private static readonly string refreshTokenKey = "SjxnW$%ciN9E85YoyGkmMP";//refresh key
        private static readonly int refreshTokenExpireMinutesForApp =2160;// JWTTokenConfig.RefreshTokenExpireMinutesForApp;
        private static readonly int refreshTokenExpireMinutesForPortal = 480;//= JWTTokenConfig.RefreshTokenExpireMinutesForPortal;
        private static readonly int accessTokenExpireMinutesForApp = 120;//JWTTokenConfig.AccessTokenExpireMinutesForApp;
        private static readonly int accessTokenExpireMinutesForPortal = 120;//JWTTokenConfig.AccessTokenExpireMinutesForPortal;

        /// <summary>
        /// 生成 pair token
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="clientId">客户端id</param>
        /// <param name="expiresTime">过期时间</param>
        /// <param name="loginType">登录方式 0-PC 1-移动端(企业微信) 2-微信公众号 12-邮件待办 long数字-iframe方式所属系统id</param>
        /// <returns></returns>
        public static PairTokenT GeneratePairToken(UserInfo userInfo)
        {
            var pairToken = new PairTokenT();
            pairToken.Token = GenerateAccessToken(userInfo);
            int expireMinutes = refreshTokenExpireMinutesForPortal;
            if (userInfo.LoginType == 1)
                expireMinutes = refreshTokenExpireMinutesForApp;
            pairToken.RefreshToken = GenerateRefreshToken(userInfo.UserId, expireMinutes);
            pairToken.UserId = userInfo.UserId;
            pairToken.Code = TokenCode.TOKEN_OK;
            return pairToken;
        }

        /// <summary>
        /// 刷新 pair token
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="clientId">客户端id</param>
        /// <param name="expiresTime">过期时间</param>
        /// <param name="loginType"></param>
        /// <returns></returns>
        public static PairTokenT RefreshPairToken(string accessToken, string refreshToken, UserInfo? user = null)
        {
            var res = new PairTokenT();
            var parseRefreshToken = ParseRefreshToken(refreshToken);
            if (parseRefreshToken == null || !parseRefreshToken.IsValid)
            {
                res.Code = TokenCode.REFRESH_TOKEN_INVALID;
                return res;
            }
            var userinfo = ParseAcessToken(accessToken, false);
            if (userinfo == null || !userinfo.IsVerify)
            {
                res.Code = TokenCode.ACCESS_TOKEN_INVALID;
                return res;
            }
            if (userinfo.UserId.ToString() != parseRefreshToken.UD)
            {
                res.Code = TokenCode.TWO_TOKEN_NOT_MATCH;
                return res;
            }
            if (user == null)
                user = userinfo;
            return GeneratePairToken(user);
        }

        /// <summary>
        /// 生成access token
        /// </summary>
        /// <param name="userInfo">用户信息</param>       
        /// <returns></returns>
        public static string GenerateAccessToken(UserInfo userInfo, DateTime? customerExpireTime = null)
        {
            int expireMinutes = accessTokenExpireMinutesForPortal;
            if (userInfo.LoginType == 1)
                expireMinutes = accessTokenExpireMinutesForApp;
            DateTime expireTime = DateTime.UtcNow.AddMinutes(expireMinutes);
            if (customerExpireTime.HasValue)
                expireTime = customerExpireTime.Value;
            var claims = new[]
            {
                new Claim("UserId", userInfo.UserId.ToString()),
                new Claim("WorkDayId", userInfo.WorkDayId??""),
                new Claim("Name",userInfo.Name??""),
                new Claim("SiteId", userInfo.SiteId.ToString()),
                new Claim("ClientId", userInfo.ClientId??""),
                new Claim("PlantCode", userInfo.PlantCode??""),
                new Claim("SiteCode",userInfo.SiteCode??""),
                new Claim("PaCode",userInfo.PaCode??""),
                new Claim("PlantSectionCode",userInfo.PlantSectionCode??""),
                new Claim("LoginType", userInfo.LoginType.ToString()),
                new Claim("EmployeeType",userInfo.EmployeeType.ToString()),
                new Claim("UserType",userInfo.UserType??""),
                new Claim("AppLoginType",userInfo.AppLoginType??""),
                new Claim("Expires", expireTime.ToString("yyyy-MM-dd HH:mm:ss"))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(issuer, audience, claims, expires: expireTime, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        /// <summary>
        /// 生成 refresh token
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expireMinutes"></param>       
        /// <returns></returns>
        private static string GenerateRefreshToken(long userId, int expireMinutes)
        {
            string guid = Guid.NewGuid().ToString("N").ToLower();
            DateTime expirTime = DateTime.UtcNow.AddMinutes(expireMinutes);
            //GD：当前token的guid,KP：配对的token的guid
            var claims = new[]
            {
                new Claim("GD", guid),
                new Claim("UD", userId.ToString())
            };
            var sign_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(refreshTokenKey));
            var credentials = new SigningCredentials(sign_key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(issuer, audience, claims, expires: expirTime, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        /// <summary>
        /// 解析token
        /// </summary>
        /// <param name="token">token字符串</param>
        /// <returns></returns>
        public static RefreshTokenInfo ParseRefreshToken(string token)
        {
            var res = new RefreshTokenInfo();
            if (string.IsNullOrWhiteSpace(token))
            {
                return res;
            }
            JwtSecurityToken jwt;
            try
            {
                jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            }
            catch
            {
                return res;
            }
            if (jwt == null)
            {
                return res;
            }

            string guid = string.Empty;
            string user_id = string.Empty;
            string expireTime = string.Empty;
            foreach (Claim? claim in jwt.Payload.Claims)
            {
                switch (claim.Type)
                {
                    case "GD":
                        guid = claim.Value;
                        break;
                    case "UD":
                        user_id = claim.Value;
                        break;
                }
            }
            res.GD = guid;
            res.UD = user_id;
            if (!string.IsNullOrEmpty(expireTime))
                res.ET = DateTime.Parse(expireTime);
            res.IsValid = IsVaildToken(token, refreshTokenKey);
            return res;
        }

        /// <summary>
        /// 解析token
        /// </summary>
        /// <param name="token">token字符串</param>
        /// <returns></returns>
        public static UserInfo ParseAcessToken(string token, bool isValidLifetime = true)
        {
            var user = new UserInfo();
            if (string.IsNullOrWhiteSpace(token) || !IsVaildToken(token, isValidLifetime))
            {
                user.IsVerify = false;
                return user;
            }
            return GetUser(token);
           }

            /// <summary>
            /// 根据token获取用户信息
            /// </summary>
            /// <param name="token"></param>
            /// <returns></returns>
            private static UserInfo GetUser(string token)
            {
                JwtSecurityToken jwt;
                try
                {
                    jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                }
                catch
                {
                    return new UserInfo();
                }
                if (jwt == null)
                {
                    return new UserInfo();
                }
                string userId = string.Empty;
                string clientId = string.Empty;
                string siteId = string.Empty;
                string workDayId = string.Empty;
                string name = string.Empty;
                long loginType = -1;
                string UserType = string.Empty;
                string plantCode = string.Empty;
                string paCode = string.Empty;
                string plantSectionCode = string.Empty;
                string siteCode = string.Empty;
                int employeeType = -1;
                string appLoginType = string.Empty;
                string systemCode = string.Empty;
                string systemKey = string.Empty;
                foreach (Claim? claim in jwt.Payload.Claims)
                {
                    switch (claim.Type)
                    {
                        case "UserId":
                            userId = claim.Value;
                            break;
                        case "SiteId":
                            siteId = claim.Value;
                            break;

                        case "ClientId":
                            clientId = claim.Value;
                            break;

                        case "WorkDayId":
                            workDayId = claim.Value;
                            break;

                        case "Name":
                            name = claim.Value;
                            break;

                        case "LoginType":
                            loginType = claim.Value.ToInt(-1);
                            break;

                        case "UserType":
                            UserType = claim.Value;
                            break;

                        case "PlantCode":
                            plantCode = claim.Value;
                            break;

                        case "PaCode":
                            paCode = claim.Value;
                            break;

                        case "PlantSectionCode":
                            plantSectionCode = claim.Value;
                            break;

                        case "SiteCode":
                            siteCode = claim.Value;
                            break;

                        case "EmployeeType":
                            employeeType = claim.Value.ToInt();
                            break;

                        case "AppLoginType":
                            appLoginType = claim.Value;
                            break;

                        case "SystemCode":
                            systemCode = claim.Value;
                            break;

                        case "SystemKey":
                            systemKey = claim.Value;
                            break;
                    }
                }
                int exp = jwt.Payload.Exp ?? 0;
                return new UserInfo
                {
                    PaCode = paCode,
                    PlantCode = plantCode,
                    PlantSectionCode = plantSectionCode,
                    SiteCode = siteCode,
                    EmployeeType = employeeType,
                    UserId = userId.ToLong(),
                    SiteId = siteId.ToLong(),
                    Expires = exp.ToDateTime(),
                    ClientId = clientId,
                    LoginType = loginType,
                    WorkDayId = workDayId,
                    Name = name,
                    IsVerify = true,
                    UserType = UserType,
                    AppLoginType = appLoginType,
                    Account = workDayId,
                    SystemCode = systemCode,
                    SystemKey = systemKey
                };
            }

            /// <summary>
            /// 验证token是否有效
            /// </summary>
            /// <param name="token"></param>
            /// <param name="isValidLifetime"></param>
            /// <returns></returns>
            public static bool IsVaildToken(string token, bool isValidLifetime = true)
        {
            return IsVaildToken(token, null, isValidLifetime);
        }

        /// <summary>
        ///  验证token是否有效
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <param name="isValidLifetime"></param>
        /// <returns></returns>
        public static bool IsVaildToken(string token, string? key, bool isValidLifetime = true)
        {
            if (key == null)
                key = tokenKey;
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = isValidLifetime,
                ValidateIssuerSigningKey = true,
                ValidAudience = audience,
                ValidIssuer = issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ClockSkew = TimeSpan.Zero
            };

            var tokenValidator = new JwtSecurityTokenHandler();
            try
            {
                tokenValidator.ValidateToken(token, tokenValidationParameters, out _);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 得到当前登录用户token
        /// </summary>
        /// <param name="request">HttpRequest，如果为空则通过注入静态HttpContext获取</param>
        /// <returns>token字符串，如果没获取到则返回string.Empty</returns>
        //public static string GetLoginToken(HttpRequest? request = null)
        //{
        //    string token = string.Empty;
        //    request ??= Tools.HttpRequest;
        //    if (request == null)
        //    {
        //        return token;
        //    }
        //    if (request.Headers.TryGetValue("Authorization", out StringValues mtoken))
        //    {
        //        token = mtoken.ToString();
        //        token = token.Replace("Bearer ", "");
        //        return token;
        //    }
        //    if (request.Headers.TryGetValue("token", out StringValues vtoken))
        //    {
        //        token = vtoken.ToString();
        //        token = token.Replace("Bearer ", "");
        //        return token;
        //    }
        //    //首先从headers中取
        //    if (request.Headers.TryGetValue("nRProcess-token", out StringValues sv))
        //    {
        //        token = sv.ToString();
        //    }

        //    //如果没有则从url参数中取
        //    if (string.IsNullOrWhiteSpace(token))
        //    {
        //        token = request.QueryStr("nRProcess-token");
        //    }

        //    //如果没有则从cookies中取
        //    if (string.IsNullOrWhiteSpace(token))
        //    {
        //        if (request.Cookies.TryGetValue("nRProcess-token", out string str) && !string.IsNullOrWhiteSpace(str))
        //        {
        //            token = str;
        //        }
        //    }
        //    return token;
        //}

        /// <summary>
        /// 得到OpenApi Token
        /// </summary>
        /// <param name="systemCode">所属系统代码</param>
        /// <param name="systemKey">所属系统key</param>
        /// <param name="userId">用户id</param>
        /// <param name="expireDateTime">过期时间</param>
        /// <returns></returns>
        public static string GetOpenApiToken(string systemCode, string systemKey, long userId, DateTime expireDateTime)
        {
            var claims = new[]
            {
                new Claim("UserId", userId.ToString()),
                new Claim("SystemCode", systemCode),
                new Claim("SystemKey",systemKey)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(issuer, audience, claims, expires: expireDateTime, signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
