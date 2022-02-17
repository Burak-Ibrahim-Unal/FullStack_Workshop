﻿using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public class CacheService : ICacheService
    {
        IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        //single parameter cache remove
        //public void Remove(string key)
        //{
        //    _cache.Remove(key);
        //}


        //multi parameter cache remove
        public void Remove(params string[] keys)
        {
            foreach (var key in keys)
            {
                _cache.Remove(key);
            }
        }
    }
}
