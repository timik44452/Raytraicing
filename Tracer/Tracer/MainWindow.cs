using GDI;
using Math;
using Renderer;
using Tracer.Core;
using Tracer.Windows;

using System.Drawing;
using System.Windows.Forms;

namespace Tracer
{
    public class MainWindow : Window
    {
        private bool UseParallel = true;
        private bool Simulate = false;

        private Camera camera;
        private World world;
        private Graphic graphic;
        private Graphics graphics;
        private int regionCount = 4;
        private int regionIndex = 0;
        private int regionWidth;
        private int regionHeight;

        System.DateTime now;

        public MainWindow() : base()
        {
            Width = 1280;
            Height = 720;

            world = new World(100, 100, 100);
            
            //camera = new Camera(new Vector3(0, 0, -99), new Vector3(0, 0, 0));
            camera = new Camera(new Vector3(162, -37, -99), new Vector3(49, 32, 0));


        }

        public override void OnLoad()
        {
            graphics = CreateGraphics();
            graphic = new Graphic(Width, Height, graphics);

            regionWidth = Width / regionCount;
            regionHeight = Height / regionCount;

        }

        public override void OnKeyDown(Keys key)
        {
            switch(key)
            {
                case Keys.A:
                    {
                        camera.SetPosition(camera.Position - camera.Right * 1F);
                    }
                    break;
                case Keys.D:
                    {
                        camera.SetPosition(camera.Position + camera.Right * 1F);
                    }
                    break;
                case Keys.W:
                    {
                        camera.SetPosition(camera.Position + camera.Forward * 1F);
                    }
                    break;
                case Keys.S:
                    {
                        camera.SetPosition(camera.Position - camera.Forward * 1F);
                    }
                    break;
                case Keys.Space:
                    {
                        Simulate = !Simulate;
                    }
                    break;
            }
        }

        public override void OnMouseEvent()
        {
            if (IsMouseLeft)
            {
                camera.SetRotation(camera.Rotation + new Vector3(-MouseDelta.Y, MouseDelta.X, 0) * 0.1F, Camera.RotationMode.Euler);
            }

            if(IsMouseMiddle)
            {
                camera.SetPosition(camera.Position - camera.Up * MouseDelta.Y - camera.Right * MouseDelta.X);
            }
        }

        public override void OnUpdate()
        {
            if (Simulate)
            {
                world.Update();
            }

            if (UseParallel)
            {
                ParallelDrawing();
            }
            else
            {
                Drawing();
            }

            graphic.Draw();

            Text = (1000F / (System.DateTime.Now - now).Milliseconds).ToString();
            now = System.DateTime.Now;
        }

        private void ParallelDrawing()
        {
            System.Threading.Tasks.Parallel.For(0, regionCount * regionCount, r =>
            {
                int regionX = r % regionCount * regionWidth;
                int regionY = r / regionCount * regionHeight;

                for (int i = 0; i < regionWidth * regionHeight; i++)
                {
                    int X = regionX + i % regionWidth;
                    int Y = regionY + i / regionWidth;

                    float dx = ((X / (float)graphic.Width) - 0.5F) * 2;
                    float dy = ((Y / (float)graphic.Width) - 0.5F) * 2;

                    float directionX = camera.Forward.X + camera.Up.X * dy + camera.Right.X * dx;
                    float directionY = camera.Forward.Y + camera.Up.Y * dy + camera.Right.Y * dx;
                    float directionZ = camera.Forward.Z + camera.Up.Z * dy + camera.Right.Z * dx;

                    Pixel pixel = world.Trace(camera.Position, directionX, directionY, directionZ);

                    graphic.SetPixel(X, Y, pixel);
                }

                regionIndex++;

                if (regionIndex > regionCount * regionCount)
                {
                    regionIndex = 0;
                }
            });
        }

        private void Drawing()
        {
            int regionX = regionIndex % regionCount * regionWidth;
            int regionY = regionIndex / regionCount * regionHeight;

            //graphic.SetPixel(regionX, regionY, Pixel.Gray);
            //graphic.SetPixel(regionX + regionWidth, regionY, Pixel.Gray);
            //graphic.SetPixel(regionX + regionWidth, regionY + regionHeight, Pixel.Gray);
            //graphic.SetPixel(regionX, regionY + regionHeight, Pixel.Gray);

            for (int i = 0; i < regionWidth * regionHeight; i++)
            {
                int X = regionX + i % regionWidth;
                int Y = regionY + i / regionWidth;

                float dx = ((X / (float)graphic.Width) - 0.5F) * 2;
                float dy = ((Y / (float)graphic.Width) - 0.5F) * 2;

                float directionX = camera.Forward.X + camera.Up.X * dy + camera.Right.X * dx;
                float directionY = camera.Forward.Y + camera.Up.Y * dy + camera.Right.Y * dx;
                float directionZ = camera.Forward.Z + camera.Up.Z * dy + camera.Right.Z * dx;

                Pixel pixel = world.Trace(camera.Position, directionX, directionY, directionZ);

                graphic.SetPixel(X, Y, pixel);
            }

            regionIndex++;

            if (regionIndex > regionCount * regionCount)
            {
                regionIndex = 0;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(741, 457);
            this.Name = "MainWindow";
            this.ResumeLayout(false);

        }
    }
}
