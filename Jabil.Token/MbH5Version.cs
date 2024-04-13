namespace Jabil.Token
{
    public class MbH5Version
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Desc:版本号        
        /// </summary>           
        public string Version { get; set; }

        /// <summary>
        /// Desc:更新说明       
        /// </summary>           
        public string Remark { get; set; }

        /// <summary>
        /// Desc:是否强制更新,1 强制, 0 不强制      
        /// </summary>           
        public string ForceUpgrade { get; set; }

        /// <summary>
        /// Desc:安卓安装包地址     
        /// </summary>
        public string ApkUrl { get; set; }

        /// <summary>
        /// Desc:ios安装包地址    
        /// </summary>
        public string IpaUrl { get; set; }

        /// <summary>
        /// Desc:plist地址      
        /// </summary>
        public string PlistUrl { get; set; }

        /// <summary>
        /// Desc:下载地址二维码      
        /// </summary>
        public string QrCode { get; set; }

        /// <summary>
        /// Desc:更新时间      
        /// </summary>
        public string UpdateTime { get; set; }

    }
}
