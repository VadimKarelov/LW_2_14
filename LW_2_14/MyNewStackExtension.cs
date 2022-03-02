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

        public static int Count<T>(this MyNewStack<T> ms, Func<T, bool> predicate)
        {
            int res = 0;
            foreach (var item in ms)
            {
                if (predicate(item))
                {
                    res++;
                }
            }
            return res;
        }

        public static double Average<T>(this MyNewStack<T> ms)
        {
            if (ms is MyNewStack<Organization> msO)
            {
                return msO.Average(x => x.AverageSalary);
            }
            return ms.Average();
        }

        public static double Min<T>(this MyNewStack<T> ms)
        {
            if (ms is MyNewStack<Organization> msO)
            {
                return msO.Min(x => x.AverageSalary);
            }
            return ms.Min();
        }

        public static double Max<T>(this MyNewStack<T> ms)
        {
            if (ms is MyNewStack<Organization> msO)
            {
                return msO.Max(x => x.AverageSalary);
            }
            return ms.Max();
        }

        public static double Sum<T>(this MyNewStack<T> ms)
        {
            if (ms is MyNewStack<Organization> msO)
            {
                return msO.Sum(x => x.AverageSalary);
            }
            return ms.Sum();
        }
    }
}
