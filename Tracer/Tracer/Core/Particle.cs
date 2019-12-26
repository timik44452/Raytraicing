using Math;
using Renderer;

namespace Tracer.Core
{
    public class Particle
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Pixel Color;

        public float temperature;

        private Vector3[] deltas = new Vector3[]
            {
                Vector3.Up,
                -Vector3.Up,

                Vector3.Right,
                -Vector3.Right,

                Vector3.Forward,
                -Vector3.Forward
            };


        public Particle(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;

            Color = new Pixel(0, 1F, 0);
        }

        public void Simulate(Particle[,,] particles)
        {
            if (X == 50)
            {
                temperature = 1;
            }

            int count = 1;

            foreach (Vector3 delta in deltas)
            {
                int x = (int)(X + delta.X);
                int y = (int)(Y + delta.Y);
                int z = (int)(Z + delta.Z);

                if (x >= 0 && x < particles.GetLength(0) &&
                    y >= 0 && y < particles.GetLength(1) &&
                    z >= 0 && z < particles.GetLength(2))
                {
                    temperature += particles[x, y, z].temperature;
                    count++;
                }
            }

            temperature /= count;

            foreach (Vector3 delta in deltas)
            {
                int x = (int)(X + delta.X);
                int y = (int)(Y + delta.Y);
                int z = (int)(Z + delta.Z);

                if (x >= 0 && x < particles.GetLength(0) &&
                    y >= 0 && y < particles.GetLength(1) &&
                    z >= 0 && z < particles.GetLength(2))
                {
                    particles[x, y, z].temperature = temperature;
                }
            }

            Color = new Pixel(temperature, 1F - temperature, 0, temperature);
        }
    }
}
