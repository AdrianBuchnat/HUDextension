using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace HUDextension
{
[StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
