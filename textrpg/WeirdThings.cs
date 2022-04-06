using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TextRpg
{
    class WeirdThings
    {
        public static int IntMax(int a, int b)
            => (a > b) ? a : b;
        public static int IntMin(int a, int b)
            => (a < b) ? a : b;
        public static void Delay(int ms)
            => System.Threading.Thread.Sleep(ms);

        public class ConnectionsEqCmp : IEqualityComparer<ushort[]>
        {
            public bool Equals(ushort[] x, ushort[] y)
            {
                if (x.Length != y.Length)
                    return false;
                for (int i = 0; i < x.Length; i++)
                    if (x[i] != y[i])
                        return false;
                return true;
            }
            public int GetHashCode(ushort[] obj)
            {
                int result = 17;
                for (int i = 0; i < obj.Length; i++)
                {
                    unchecked
                    {
                        result = result * 23 + obj[i];
                    }
                }
                return result;
            }
        }
    }
}
