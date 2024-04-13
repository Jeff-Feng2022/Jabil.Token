using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yitter.IdGenerator;


namespace Jabil.Token
{
    public class IdGenerator
    {
        /// <summary>
        /// 初始化，应用启动时执行。
        /// </summary>
        public static void Init(ushort workerId = 1)
        {
            //创建 IdGeneratorOptions 对象，请在构造函数中输入 WorkerId
            var options = new IdGeneratorOptions(workerId);
            //保存参数（必须的操作，否则以上设置都不能生效）
            YitIdHelper.SetIdGenerator(options);
        }

        /// <summary>
        /// 最小值
        /// </summary>
        public const long MinValue = 100000000000000;

        /// <summary>
        /// 生成新的id
        /// </summary>
        /// <returns></returns>
        public static long NextId()
        {
            return YitIdHelper.NextId();
        }

        /// <summary>
        /// 将long转换为int
        /// </summary>
        /// <returns>int，转换失败返回0</returns>
        public static int ConvertToInt(long id)
        {
            string idString = id.ToString();
            return int.TryParse(string.Concat(idString.AsSpan(0, 3), idString.AsSpan(9, 6)), out int i) ? i : 0;
        }
    }
}
