using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        /*duration cache de ne kadar duracak */
        T Get<T>(string key);
        object Get(string key);//Generic olmayan kısım yukarıdakini böyle yazabiliriz ama dönüşüm yapmak lazım
        void Add(string key, object value, int duration);
        bool IsAdd(string key);//veritabanında var mı yoksa ekle
        void Remove(string key);
        void RemoveByPattern(string pattern);//regex pattern versem
    }
}
