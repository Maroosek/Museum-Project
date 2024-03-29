using System;
using System.Collections.Generic;

namespace Muzeum.Common.Extensions
{
    public static class ListExtension
    {
        //metoda permutująca dane w liście
        public static void Shuffle<T>(this IList<T> list)  
        {  
            var rnd = new Random();  

            var n = list.Count;  
            while (n > 1) {  
                n--;  
                var k = rnd.Next(n + 1);
                var value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }  
        }

    }
}