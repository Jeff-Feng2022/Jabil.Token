using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Jabil.Token
{
    public static class StringExtensions
    {
        /// <summary>
        /// 去掉字符串所有空格
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string TrimAll(this string? str)
        {
            return string.IsNullOrWhiteSpace(str) ? string.Empty : Regex.Replace(str, @"\s", "");
        }

        /// <summary>
        /// 去掉空格，如果为null或Empty则返回string.Empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimNullOrEmpty(this string? str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : str.Trim();
        }

        /// <summary>
        /// 转换为不为空的字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>如果字符串为null返回string.Empty，否则返回字符串本身。</returns>
        public static string ToEmptyString(this string? str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : str;
        }

        /// <summary>
        /// 将字符串分割为数组
        /// </summary>
        /// <param name="str">要分割的字符串</param>
        /// <param name="separator">分隔符</param>
        /// <param name="options">分割选项</param>
        /// <returns>字符串数组</returns>
        public static string[] SplitToArray(this string? str, string separator = ",", StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            return string.IsNullOrWhiteSpace(str) ? Array.Empty<string>() : str.Split(separator, options);
        }

        /// <summary>
        /// 将字符串分割为long数组
        /// </summary>
        /// <param name="str">要分割的字符串</param>
        /// <param name="separator">分隔符</param>
        /// <param name="options">分割选项</param>
        /// <returns>long List</returns>
        public static List<long> SplitToLongList(this string? str, string separator = ",", StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            string[] array = str.SplitToArray(separator, options);
            var list = new List<long>();
            foreach (string a in array)
            {
                if (a.IsLong(out long l))
                {
                    list.Add(l);
                }
            }
            return list;
        }

        /// <summary>
        /// 将字符串分割为int数组
        /// </summary>
        /// <param name="str">要分割的字符串</param>
        /// <param name="separator">分隔符</param>
        /// <param name="options">分割选项</param>
        /// <returns>int List</returns>
        public static List<int> SplitToIntList(this string? str, string separator = ",", StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            string[] array = str.SplitToArray(separator, options);
            var list = new List<int>();
            foreach (string a in array)
            {
                if (a.IsInt(out int i))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        /// <summary>
        /// 判断字符串是否是int类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsInt(this string? str)
        {
            return int.TryParse(str, out _);
        }

        /// <summary>
        /// 判断字符串是否是int类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="i">如果是数字返回int</param>
        /// <returns></returns>
        public static bool IsInt(this string? str, out int i)
        {
            return int.TryParse(str, out i);
        }

        /// <summary>
        /// 将字符串转换为int
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns></returns>
        public static int ToInt(this string? str, int defaultValue = 0)
        {
            return str.IsInt(out int i) ? i : defaultValue;
        }

        /// <summary>
        /// 判断字符串是否是long类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsLong(this string? str)
        {
            return long.TryParse(str, out _);
        }

        /// <summary>
        /// 判断字符串是否是long类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="i">如果是数字返回long</param>
        /// <returns></returns>
        public static bool IsLong(this string? str, out long l)
        {
            return long.TryParse(str, out l);
        }

        /// <summary>
        /// 将字符串转换为long
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns></returns>
        public static long ToLong(this string? str, long defaultValue = 0)
        {
            return str.IsLong(out long l) ? l : defaultValue;
        }

        /// <summary>
        /// 判断字符串是否是decimal类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(this string? str)
        {
            return decimal.TryParse(str, out _);
        }

        /// <summary>
        /// 判断字符串是否是decimal类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(this string? str, out decimal d)
        {
            return decimal.TryParse(str, out d);
        }

        /// <summary>
        /// 字符串转换为decimal类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string? str, decimal defaultValue = 0)
        {
            return str.IsDecimal(out decimal d) ? d : defaultValue;
        }

        /// <summary>
        /// 判断字符串是否是float类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsFloat(this string? str, out float f)
        {
            return float.TryParse(str, out f);
        }

        /// <summary>
        /// 字符串转换为float类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns></returns>
        public static float ToFloat(this string? str, float defaultValue = 0)
        {
            return str.IsFloat(out float f) ? f : defaultValue;
        }

        /// <summary>
        /// 字符串转换为float类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="format">转换失败时的默认值</param>
        /// <returns></returns>
        public static float ToFloat2(this string? str, string format)
        {
            string result = "";
            try
            {
                if (str == null) return 0;
                if (format == "")
                {
                    result = str.ToString();
                }
                else
                {
                    result = string.Format("{0:" + format + "}", str);
                }
            }
            catch
            {
                return 0;
            }
            return float.TryParse(result, out float f) ? f : 0;
        }

        /// <summary>
        /// 判断字符串是否是double类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsDouble(this string? str, out double d)
        {
            return double.TryParse(str, out d);
        }

        /// <summary>
        /// 字符串转换为double类型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns></returns>
        public static double ToDouble(this string? str, double defaultValue = 0)
        {
            return str.IsDouble(out double d) ? d : defaultValue;
        }

        /// <summary>
        /// 判断字符串是否为bool类型
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="b"></param>
        /// <returns>如果字符串为"1"或"true"（不区分大小写，去掉所有空格）时返回true否则返回false</returns>
        public static bool IsBool(this string? str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            string str1 = str.TrimAll();
            return "true".EqualsIgnoreCase(str1) || "1".Equals(str1);
        }

        /// <summary>
        /// 将字符串转换为bool
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>如果字符串为1或true（不区分大小写），则返回true，否则返回false</returns>
        public static bool ToBool(this string? str)
        {
            return str.IsBool();
        }

        /// <summary>
        /// 判断一个字符串是否是日期时间类型
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="dt">输出转换后的日期时间</param>
        /// <returns></returns>
        public static bool IsDateTime(this string? str, out DateTime dt)
        {
            return DateTime.TryParse(str, out dt);
        }

        /// <summary>
        /// 判断一个字符串是否是日期时间类型
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static bool IsDateTime(this string? str)
        {
            return str.IsDateTime(out _);
        }

        /// <summary>
        /// 将字符串转换为时间时间
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defaultValue">转换失败时返回的默认值</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string? str, DateTime defaultValue)
        {
            return str.IsDateTime(out DateTime dt) ? dt : defaultValue;
        }

        /// <summary>
        /// 将字符串转换为时间时间
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defaultValue">转换失败时返回的默认值</param>
        /// <returns>如果转换失败则返回null</returns>
        public static DateTime? ToDateTime(this string? str)
        {
            return str.IsDateTime(out DateTime dt) ? dt : new DateTime?();
        }

        /// <summary>
        /// 比较字符串区分大小写
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="str1">要比较的字符串</param>
        /// <returns>是否相同</returns>
        public static bool EqualsCase(this string? str, string? str1)
        {
            return string.Equals(str, str1);
        }

        /// <summary>
        /// 比较字符串是否与参数中任意一个字符串相等
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="strs">要比较的字符串</param>
        /// <returns>是否与参数中任意一个字符串相等</returns>
        public static bool EqualsAny(this string? str, params string[] strs)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            foreach (string s in strs)
            {
                if (s.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断字符串与参数中的字符串都不相等
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="strs">要比较的字符串</param>
        /// <returns></returns>
        public static bool NotEqualsAny(this string? str, params string[] strs)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            foreach (string s in strs)
            {
                if (s.Equals(str))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 比较字符串不区分大小写
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="str1">要比较的字符串</param>
        /// <returns>是否相同</returns>
        public static bool EqualsIgnoreCase(this string? str, string? str1)
        {
            return string.Equals(str, str1, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 比较字符串是否与参数中任意一个字符串相等（不区分大小写）
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="strs">要比较的字符串</param>
        /// <returns>是否与参数中任意一个字符串相等</returns>
        public static bool EqualsAnyIgnoreCase(this string? str, params string[] strs)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            foreach (string s in strs)
            {
                if (s.Equals(str, StringComparison.CurrentCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断字符串与参数中的字符串都不相等（不区分大小写）
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="strs">要比较的字符串</param>
        /// <returns>是否与参数中任意一个字符串相等</returns>
        public static bool NotEqualsAnyIgnoreCase(this string? str, params string[] strs)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            foreach (string s in strs)
            {
                if (s.Equals(str, StringComparison.CurrentCultureIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断字符串中是否包含str1字符串（区分大小写）
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="str1">被包含的字符串</param>
        /// <param name="stringComparison">StringComparison</param>
        /// <returns></returns>
        public static bool ContainsCase(this string? str, string? str1)
        {
            return str != null && str1 != null && str.Contains(str1);
        }

        /// <summary>
        /// 判断字符串中是否包含str1字符串（不区分大小写）
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="str1">被包含的字符串</param>
        /// <returns></returns>
        public static bool ContainsIgnoreCase(this string? str, string? str1)
        {
            return str != null && str1 != null && str.Contains(str1, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 判断字符串出现的位置（为区分大小写）
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="str1">子字符串</param>
        /// <returns></returns>
        public static int IndexOfIgnoreCase(this string? str, string str1)
        {
            return str == null ? -1 : str.IndexOf(str1, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 去掉开头的字符串
        /// </summary>
        /// <param name="str">要去掉的字符串</param>
        /// <param name="trimString">开头的字符串</param>
        /// <returns></returns>
        public static string TrimStartString(this string? str, string trimString)
        {
            return string.IsNullOrWhiteSpace(str) ? string.Empty : !str.StartsWith(trimString) ? str : str.Substring(trimString.Length);
        }

        /// <summary>
        /// 去掉开头的字符串（不区分大小写）
        /// </summary>
        /// <param name="str">要去掉的字符串</param>
        /// <param name="trimString">开头的字符串</param>
        /// <returns></returns>
        public static string TrimStartStringIgnoreCase(this string? str, string trimString)
        {
            return string.IsNullOrWhiteSpace(str) ? string.Empty : !str.StartsWithIgnoreCase(trimString) ? str : str.Substring(trimString.Length);
        }

        /// <summary>
        /// 去掉结尾的字符串
        /// </summary>
        /// <param name="str">要去掉的字符串</param>
        /// <param name="trimString">结尾的字符串</param>
        /// <returns></returns>
        public static string TrimEndString(this string? str, string trimString)
        {
            return string.IsNullOrWhiteSpace(str) ? string.Empty : !str.EndsWith(trimString) ? str : str.Substring(0, str.Length - trimString.Length);
        }

        /// <summary>
        /// 去掉结尾的字符串（不区分大小写）
        /// </summary>
        /// <param name="str">要去掉的字符串</param>
        /// <param name="trimString">结尾的字符串</param>
        /// <returns></returns>
        public static string TrimEndStringIgnoreCase(this string? str, string trimString)
        {
            return string.IsNullOrWhiteSpace(str) ? string.Empty : !str.EndsWithIgnoreCase(trimString) ? str : str.Substring(0, str.Length - trimString.Length);
        }

        /// <summary>
        /// 将字符串md5加密
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns></returns>
        public static string MD5(this string? str)
        {
            return string.IsNullOrEmpty(str) ? "" : Encryption.MD5(str.Trim());
        }

        /// <summary>
        /// 将字符串des加密
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns></returns>
        public static string DESEncrypt(this string? str)
        {
            return string.IsNullOrEmpty(str) ? "" : Encryption.DESEncrypt(str.Trim());
        }

        /// <summary>
        /// 将字符串des解密
        /// </summary>
        /// <param name="str">要解密的字符串</param>
        /// <returns></returns>
        public static string DESDecrypt(this string? str)
        {
            return string.IsNullOrEmpty(str) ? "" : Encryption.DESDecrypt(str.Trim());
        }

        /// <summary>
        /// 判断一个字符串是否是用户id字符串（u_开头）
        /// </summary>
        /// <param name="str">id字符串</param>
        /// <returns></returns>
        public static bool IsUserId(this string? str)
        {
            return !string.IsNullOrEmpty(str) && str.Trim().StartsWith("u_");
        }

        /// <summary>
        /// 判断一个字符串是否是用户id字符串（u_开头）
        /// </summary>
        /// <param name="str">id字符串</param>
        /// <param name="userId">输出转换后的用户long id</param>
        /// <returns></returns>
        public static bool IsUserId(this string? str, out long userId)
        {
            if (!string.IsNullOrEmpty(str) && str.Trim().StartsWith("u_"))
            {
                userId = str.Trim().TrimStart('u', '_').ToLong();
                return true;
            }
            else
            {
                userId = IdGenerator.MinValue;
                return false;
            }
        }

        /// <summary>
        /// 将包含u_long的字符串转换为人员id（去掉u_再转换为long，如果字符串不是u_开头则直接转换为long）
        /// </summary>
        /// <param name="str">u_long的字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns></returns>
        public static long ToUserId(this string? str, long defaultValue = 0)
        {
            return !string.IsNullOrEmpty(str) && str.Trim().StartsWith("u_") ? str.Trim().TrimStart('u', '_').ToLong(defaultValue) : str.ToLong(defaultValue);
        }

        /// <summary>
        /// 判断一个字符串是否是工作组id字符串（w_开头）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsWorkgroupId(this string? str)
        {
            return !string.IsNullOrEmpty(str) && str.Trim().StartsWith("w_");
        }

        /// <summary>
        /// 判断一个字符串是否是工作组id字符串（w_开头）
        /// </summary>
        /// <param name="str">id字符串</param>
        /// <param name="workgroupId">输出转换后的工作组long id</param>
        /// <returns></returns>
        public static bool IsWorkgroupId(this string? str, out long workgroupId)
        {
            if (!string.IsNullOrEmpty(str) && str.Trim().StartsWith("w_"))
            {
                workgroupId = str.Trim().TrimStart('w', '_').ToLong();
                return true;
            }
            else
            {
                workgroupId = IdGenerator.MinValue;
                return false;
            }
        }

        /// <summary>
        /// 将包含w_long的字符串转换为工作组id（去掉w_再转换为long，如果字符串不是w_开头则直接转换为long）
        /// </summary>
        /// <param name="str">w_long的字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns></returns>
        public static long ToWorkgroupId(this string? str, long defaultValue = 0)
        {
            return !string.IsNullOrEmpty(str) && str.Trim().StartsWith("w_") ? str.Trim().TrimStart('w', '_').ToLong(defaultValue) : str.ToLong(defaultValue);
        }

        /// <summary>
        /// 判断一个字符串是否是组织与用户关系id字符串（r_开头）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsOrganizeUserId(this string? str)
        {
            return !string.IsNullOrEmpty(str) && str.Trim().StartsWith("r_");
        }

        /// <summary>
        /// 判断一个字符串是否是用户关系id字符串（r_开头）
        /// </summary>
        /// <param name="str">id字符串</param>
        /// <param name="workgroupId">输出转换后的用户关系long id</param>
        /// <returns></returns>
        public static bool IsOrganizeUserId(this string? str, out long organizeUserId)
        {
            if (!string.IsNullOrEmpty(str) && str.Trim().StartsWith("r_"))
            {
                organizeUserId = str.Trim().TrimStart('r', '_').ToLong();
                return true;
            }
            else
            {
                organizeUserId = IdGenerator.MinValue;
                return false;
            }
        }

        /// <summary>
        /// 将包含r_long的字符串转换为组织与用户关系id（去掉r_再转换为long，如果字符串不是r_开头则直接转换为long）
        /// </summary>
        /// <param name="str">r_long的字符串</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns></returns>
        public static long ToOrganizeUserId(this string? str, long defaultValue = 0)
        {
            return !string.IsNullOrEmpty(str) && str.Trim().StartsWith("r_") ? str.Trim().TrimStart('r', '_').ToLong(defaultValue) : str.ToLong(defaultValue);
        }

        /// <summary>
        /// 是否是以字符串数组参数中任意一个字符串开头的字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="values">开头的字符串数组</param>
        /// <returns></returns>
        public static bool StartsWithAny(this string? str, params string[] values)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            foreach (string value in values)
            {
                if (str.StartsWith(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否是以字符串数组参数中任意一个字符串开头的字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringComparison">StringComparison, 可设置是否区分大小写</param>
        /// <param name="values">开头的字符串数组</param>
        /// <returns></returns>
        public static bool StartsWithAny(this string? str, StringComparison stringComparison, params string[] values)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }
            foreach (string value in values)
            {
                if (str.StartsWith(value, stringComparison))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断字符串是否以某个字符串开头（不区分大小写）
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <param name="startString">开头的字符串</param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase(this string? str, string startString)
        {
            return !string.IsNullOrEmpty(str) && str.StartsWith(startString, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 判断字符串是否以某个字符串结尾（不区分大小写）
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <param name="startString">结尾的字符串</param>
        /// <returns></returns>
        public static bool EndsWithIgnoreCase(this string? str, string startString)
        {
            return !string.IsNullOrEmpty(str) && str.EndsWith(startString, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 替换字符串，不区分大不写
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="oldValue">要替换的字符串</param>
        /// <param name="newValue">新字符串</param>
        /// <returns></returns>
        public static string ReplaceIgnoreCase(this string? str, string oldValue, string? newValue)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : str.Replace(oldValue, newValue, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 将字符串转换为对应类型的对象
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static object ToTypeObject(this string? str, out Type type)
        {
            if (string.IsNullOrEmpty(str) || str.EqualsIgnoreCase("null"))
            {
                type = typeof(string);
                return string.Empty;
            }
            else if (str.IsInt(out int objInt))
            {
                type = typeof(int);
                return objInt;
            }
            else if (str.IsLong(out long objLong))
            {
                type = typeof(long);
                return objLong;
            }
            else if (Guid.TryParse(str, out Guid objGuid))
            {
                type = typeof(Guid);
                return objGuid;
            }
            else if (str.IsFloat(out float objFloat))
            {
                type = typeof(float);
                return objFloat;
            }
            else if (str.IsDouble(out double objDouble))
            {
                type = typeof(double);
                return objDouble;
            }
            else if (str.IsDecimal(out decimal objDecimal))
            {
                type = typeof(decimal);
                return objDecimal;
            }
            else if (str.IsDateTime(out DateTime objDateTime))
            {
                type = typeof(DateTime);
                return objDateTime;
            }
            else if ("true".EqualsIgnoreCase(str) || "false".EqualsIgnoreCase(str))
            {
                type = typeof(bool);
                return "true".EqualsIgnoreCase(str);
            }
            type = typeof(string);
            return str;
        }

        /// <summary>
        /// url编码
        /// </summary>
        /// <param name="str">要编码的url</param>
        /// <returns></returns>
        public static string UrlEncode(this string? url)
        {
            return string.IsNullOrWhiteSpace(url) ? string.Empty : Uri.EscapeDataString(url).Replace("'", "%27");
        }

        /// <summary>
        /// url解码
        /// </summary>
        /// <param name="str">要解码的url</param>
        /// <returns></returns>
        public static string UrlDecode(this string? url)
        {
            return string.IsNullOrWhiteSpace(url) ? string.Empty : Uri.UnescapeDataString(url).Replace("%27", "'");
        }

        /// <summary>
        /// 得到排序字符串，验证字符串过滤掉不符合排序规则的危险字符串。
        /// </summary>
        /// <param name="str">排序字符串</param>
        /// <returns></returns>
        //public static string GetOrderBy(this string str)
        //{
        //    if (string.IsNullOrWhiteSpace(str))
        //    {
        //        return string.Empty;
        //    }
        //    string[] strArray = str.SplitToArray(" ");
        //    if (strArray.Length == 0)
        //    {
        //        return string.Empty;
        //    }
        //    if (strArray.Length == 1)
        //    {
        //        return strArray[0].Trim() + " ASC";
        //    }
        //    string order = strArray[1].Trim();
        //    return (strArray[0].Trim() + " " + (!order.EqualsIgnoreCase("asc") && !order.EqualsIgnoreCase("desc") ? "ASC" : order)).ToSqlFilter();
        //}

        /// <summary>
        /// 过滤查询SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static string FilterSelectSql(this string? sql)
        {
            return string.IsNullOrWhiteSpace(sql) ? string.Empty
                : sql.ReplaceIgnoreCase("delete ", "")
                .ReplaceIgnoreCase("update ", "")
                .ReplaceIgnoreCase("insert ", "")
                .ReplaceIgnoreCase("truncate ", "")
                .ReplaceIgnoreCase("drop ", "")
                .ReplaceIgnoreCase("exec ", "")
                .ReplaceIgnoreCase("execute ", "")
                .ReplaceIgnoreCase("create ", "")
                .ReplaceIgnoreCase("xp_cmdshell", "")
                .ReplaceIgnoreCase("net localgroup", "")
                .ReplaceIgnoreCase(@"\s+exec(\s|\+)+(s|x)p\w+", "");//防止执行sql server 内部存储过程或扩展存储过程
        }

        /// <summary>
        /// Build SQL string with ANY(VALUES(...)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="separator"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        //public static string ToPostgreSQLAnyValues(this string? str, string separator = ",", StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        //{
        //    string[] array = str.SplitToArray(separator, options);
        //    var list = new List<string>();
        //    Type type;
        //    foreach (string a in array)
        //    {
        //        _ = a.ToTypeObject(out type);
        //        if (type == typeof(string))
        //        {
        //            list.Add($@"('{a}')");
        //        }
        //        else
        //        {
        //            list.Add($@"({a})");
        //        }
        //    }

        //    return $@"any(values{list.JoinToString()})";
        //}

        /// <summary>
        /// 转换为string字符串类型
        /// </summary>
        /// <param name="s">获取需要转换的值</param>
        /// <param name="format">需要格式化的位数</param>
        /// <returns>返回一个新的字符串</returns>
        public static string ToStr(this object s, string format = "")
        {
            string result = "";
            try
            {
                if (s == null) return "";
                if (format == "")
                {
                    result = s.ToString();
                }
                else
                {
                    result = string.Format("{0:" + format + "}", s);
                }
            }
            catch
            {
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static decimal ToDecimal2(this object obj, decimal def = 0)
        {
            try
            {
                if (obj == null) return def;
                return obj.ToString().ToDecimal(def);
            }
            catch
            {
                return def;
            }
        }

        /// <summary>
        /// 进位取整
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static decimal ToDecimal3(this object obj, decimal def = 0)
        {
            try
            {
                if (obj == null) return def;
                return Math.Ceiling(obj.ToString().ToDecimal(def));
            }
            catch
            {
                return def;
            }
        }

        /// <summary>
        /// 默认保留2位小数
        /// </summary>
        /// <param name="dig">默认保留2位小数</param>
        /// <param name="digtal"></param>
        /// <returns></returns>
        public static decimal ToDecimalByDig(this object dig, int digtal = 2)
        {
            var dec = dig.ToDecimal2(0);
            return Math.Round(dec, digtal, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 默认保留2位小数
        /// </summary>
        /// <param name="dig">默认保留2位小数</param>
        /// <param name="digtal"></param>
        /// <returns></returns>
        public static float ToFloatByDig(this object dig, int digtal = 2)
        {
            var dec = dig.ToDecimal2(0);
            return Math.Round(dec, digtal, MidpointRounding.AwayFromZero).ToString().ToFloat();
        }

        public static string ToJoinedString<T>(this IEnumerable<T> source, string separator = ",")
        {
            return string.Join(separator, source);
        }
    }
}
