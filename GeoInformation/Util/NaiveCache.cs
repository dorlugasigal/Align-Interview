using GeoInformation.Models;
using System;
using System.Collections.Generic;
using System.Web.Caching;

namespace GeoInformation.Util
{
    public class NaiveCache
    {
        Dictionary<object, Picture> _cache = new Dictionary<object, Picture>();
        List<int> _unUsedIds;
        static Random rnd = new Random();

        public NaiveCache()
        {
            
            _unUsedIds = new List<int>();
        }
        public Picture GetItem(int key, Func<Picture> create)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = create();
            }
            _unUsedIds.Remove(key);
            return _cache[key];
        }
        public Picture[] GetItems(int amount)
        {
            if (Empty())
            {
                return null;
            }
            List<Picture> res = new List<Picture>();
            while (res.Count <= amount && _unUsedIds.Count > 0)
            {
                int randomId = rnd.Next(_unUsedIds.Count);
                res.Add(_cache[_unUsedIds[randomId]]);
                _unUsedIds.Remove(randomId);
            }
            return res.ToArray();
        }
        public bool Empty()
        {
            return _cache.Count == 0;
        }
        public void InsertMany(Picture[] arr, int[] ids)
        {
            _unUsedIds.AddRange(ids);
            foreach (Picture item in arr)
            {
                _cache[item.Id] = item;
            }
        }
    }
}