using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class LocConnection
    {
        public ushort[] fPoint;
        public ushort[] sPoint;
        public LocConnection(ushort[] fPoint_, ushort[] sPoint_)
        {
            fPoint = fPoint_;
            sPoint = sPoint_;
        }
    }
}
