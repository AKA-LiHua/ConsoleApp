using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.泛型
{
    /// <summary>
    /// 泛型缓存：针对类型进行缓存
    ///           不能分别为张三/李四缓存
    ///           性能高，除了内存损耗，几乎无性能损耗
    /// </summary>
    public class GenericCache<T>
    {
        private static string CacheData = null;

        //静态构造函数：一个类只有一个，不能调用，CLR调用的
        static GenericCache()
        {
            CacheData = $"{typeof(T).FullName}_{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}";
        }
        public static string GetData()
        {
            return CacheData;
        }
    }

    /// <summary>
    /// 普通字典缓存，数据量大的时候，有瓶颈
    /// 字典：hash寻址，空间用的也多
    /// list：数组结构，不适合增删改
    /// </summary>
    public class CommonCahe
    {
        private static Dictionary<string, string> CommonCacheDictionary = new Dictionary<string, string>();
        private static string Get<T>()
        {
            string key = $"{typeof(T).FullName}";
            if (CommonCacheDictionary.ContainsKey(key))
            {
                return CommonCacheDictionary[key];
            }
            else
            {
                string value = $"{typeof(T).FullName}_{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff")}";
                CommonCacheDictionary[key] = value;
                return value;
            }
        }
    }
}
