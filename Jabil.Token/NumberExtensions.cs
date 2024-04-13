using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jabil.Token
{
    public static class NumberExtensions
    {
        /// <summary>
        /// 将int转换为日期时间
        /// </summary>
        /// <param name="ticks">Ticks时间刻度</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this int ticks)
        {
            DateTime startTime = new(1970, 1, 1, 0, 0, 0);
            startTime = startTime.AddSeconds(ticks).ToLocalTime();
            return startTime;
        }

        /// <summary>
        /// 判断id是否是IdGenerator
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static bool IsIdGenerator(this long id)
        {
            return id > IdGenerator.MinValue;
        }

        /// <summary>
        /// 判断id是否是IdGenerator
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public static bool IsIdGenerator(this long? id)
        {
            return id.HasValue && id.Value > IdGenerator.MinValue;
        }

        /// <summary>
        /// 判断数字是否出现在参数中的数字里
        /// </summary>
        /// <param name="i">要判断的数字</param>
        /// <param name="iArray">数字参数数组</param>
        /// <returns></returns>
        public static bool In(this int i, params int[] iArray)
        {
            foreach (int j in iArray)
            {
                if (i == j)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断数字没有出现在参数里
        /// </summary>
        /// <param name="i">要判断的数字</param>
        /// <param name="iArray">数字参数数组</param>
        /// <returns></returns>
        public static bool NotIn(this int i, params int[] iArray)
        {
            foreach (int j in iArray)
            {
                if (i == j)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
