using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        T Get<T>(string key);
        object Get(string key);
        bool isAddedToMemory(string key); // check informations that added to memory or not
        void Remove(string key);
        void RemoveByPattern(string pattern );


    }
}
