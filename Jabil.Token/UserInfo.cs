using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jabil.Token
{
    public class UserInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string PlantCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PaCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PlantSectionCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SiteCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int EmployeeType { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long SiteId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Expires { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 登录方式
        /// 0-PC
        /// 1-移动端 
        /// </summary>
        public long LoginType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WorkDayId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsVerify { get; set; }

        /// <summary>
        /// 0:游客,1:注册未入职(包含有员工号，已离职), 2:已入职(员工), 3：pc端用户
        /// 0.visitor 1.registed,2. employee,3 pc user
        public string UserType { get; set; }

        /// <summary>
        /// 1.mobile phone 2.okta
        /// </summary>
        public string AppLoginType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SystemCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SystemKey { get; set; }
    }
}
