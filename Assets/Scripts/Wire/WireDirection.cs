using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Flags]
public enum WireDirection
{
    Up = 0x01,
    Down = 0x02,
    Left = 0x04,
    Right = 0x08
}
