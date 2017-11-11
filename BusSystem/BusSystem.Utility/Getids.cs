using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusSystem.Utility
{
      /// <summary>
        /// 
        /// </summary>
        public static class DataBaseGenerator
        {
            /// <summary>
            /// 
            /// </summary>
            private static Int64 seed = Int64.Parse(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds.ToString("0"));

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static Int64 GetPrimaryKey()
            {
                return Interlocked.Increment(ref seed);
            }
        }
    
}
