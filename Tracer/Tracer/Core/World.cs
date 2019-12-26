using System.Collections.Generic;

using Math;
using Renderer;

namespace Tracer.Core
{
    public class World
    {
        public int Width { get; }
        public int Height { get; }
        public int Length { get; }

        private float object_width;
        private float object_height;
        private float object_length;

        public int density = 1;

        private Particle[,,] Buffer;


        public World(int Width, int Height, int Length)
        {
            this.Width = Width;
            this.Height = Height;
            this.Length = Length;

            object_height = Height + 1;
            object_width = Width + 1;
            object_length = Length + 1;

            Buffer = new Particle[Width, Height, Length];

            for (int X = 0; X < Width; X++)
                for (int Y = 0; Y < Height; Y++)
                    for (int Z = 0; Z < Length; Z++)
                    {
                        Buffer[X, Y, Z] = new Particle(X, Y, Z);
                    }
        }

        public Pixel Trace(Vector3 from, float dx, float dy, float dz)
        {
            if (RayBoxIntersection1(from, dx, dy, dz, out float tmin, out float tmax))
            {
                for (float t = tmin; t < tmax; t += 1)
                {
                    int X = (int)(from.X + dx * t);
                    int Y = (int)(from.Y + dy * t);
                    int Z = (int)(from.Z + dz * t);

                    if (X >= 0 && X < Width &&
                        Y >= 0 && Y < Height &&
                        Z >= 0 && Z < Length)
                    {

                        //if (Buffer[X, Y, Z].Color.A > 0)
                        {
                            return Buffer[X, Y, Z].Color;
                        }
                    }
                }
            }

            return Pixel.Black;
        }

        bool RayBoxIntersection1(Vector3 ray_pos, float dx, float dy, float dz, out float tmin, out float tmax)
        {
            MathService.Min(out float lo0, out float hi0, -ray_pos.X / dx, (object_width - ray_pos.X) / dx);
            MathService.Min(out float lo1, out float hi1, -ray_pos.Y / dy, (object_height - ray_pos.Y) / dy);
            MathService.Min(out float lo2, out float hi2, -ray_pos.Z / dz, (object_length - ray_pos.Z) / dz);

            tmin = MathService.Max(lo0, MathService.Max(lo1, lo2));
            tmax = MathService.Min(hi0, MathService.Min(hi1, hi2));

            return (tmin <= tmax) && (tmax >= 0);
        }

        public void Update()
        {
            System.Threading.Tasks.Parallel.For(0, Height * Length, i =>
            {
                for (int x = 0; x < Width; x++)
                {
                    int y = i % Height;
                    int z = i / Height;

                    Buffer[x, y, z].Simulate(Buffer);
                }
            });
        }
    }
}
