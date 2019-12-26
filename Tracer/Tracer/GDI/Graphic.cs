using System.Drawing;
using System.Runtime.InteropServices;
using Renderer;

namespace GDI
{
    public class Graphic
    {
        public int Width
        {
            get => width;
        }

        public int Height
        {
            get => height;
        }

        private HandleRef href;
        private BITMAPINFO info;
        private FrameBuffer frame;

        private int width;
        private int height;

        public Graphic(int Width, int Height, Graphics graphics)
        {
            info = GDIHelper.CreateBitmapinfo(Width, Height);
            href = new HandleRef(graphics, graphics.GetHdc());
            frame = new FrameBuffer(Width, Height);

            width = Width;
            height = Height;
        }

        public void Draw()
        {
            GDIHelper.SetDIBitsToDevice(href, 0, 0, width, height, 0, 0, 0, height, ref frame.Data[0], ref info, 0);
        }

        public void SetPixel(int x, int y, Pixel color)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
                frame.Data[x + y * width] = color.ToRGB();
        }
    }
}
