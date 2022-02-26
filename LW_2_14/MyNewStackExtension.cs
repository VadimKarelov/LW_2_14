using LW_2_13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW_2_14
{
    public static class MyNewStackExtension
    {
        public static IEnumerable<T> Select<T>(this MyNewStack<T> ms, Func<T, bool> selector)
        {
            List<T> res = new List<T>();
            foreach (var item in ms)
            {
                if (selector(item))
                {
                    res.Add(item);
                }
            }
            return res;
        }
    }
}
