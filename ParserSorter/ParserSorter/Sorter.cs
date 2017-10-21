using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserSorter
{
    public class Sorter
    {
        public List<T> QuickSort<T>(List<T> elements) where T : IComparable
        {
            if (elements.Count() < 2) return elements;
            Int32 pivot = new Random().Next(elements.Count());
            T val = elements[pivot];
            List<T> left = new List<T>();
            List<T> right = new List<T>();
            for (Int32 i = 0; i < elements.Count(); i++)
            {
                if (i != pivot)
                {
                    if (elements[i].CompareTo(val) < 0)
                    {
                        left.Add(elements[i]);
                    }
                    else
                    {
                        right.Add(elements[i]);
                    }
                }
            }

            List<T> merged = QuickSort(left);
            merged.Add(val);
            merged.AddRange(QuickSort(right));

            return merged;
        }
    }
}
