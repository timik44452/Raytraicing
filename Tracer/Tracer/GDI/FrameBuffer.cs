using System;
using System.Collections.Generic;
using System.Text;

namespace GDI
{
    public class FrameBuffer
    {
        public int[] Data;

        public FrameBuffer(int Width, int Height)
        {
            Data = new int[Width * Height];
        }
    }
}
