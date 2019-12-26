using System;

namespace Math
{
    public struct Vector2
    {
        private float x;
        private float y;
        private float length;

        public static Vector2 right { get => new Vector2(1, 0); }
        public static Vector2 up { get => new Vector2(0, 1); }
        public static Vector2 one { get => new Vector2(1, 1); }
        public static Vector2 zero { get => new Vector2(0, 0); }

        public float X
        {
            get => x;
            set
            {
                x = value;
                Recalculate();
            }
        }
        public float Y
        {
            get => y;
            set
            {
                y = value;
                Recalculate();
            }
        }

        public float Length
        {
            get => length;
        }

        public Vector2 Normalized
        {
            get => this / length;
        }

        public Vector2(double X, double Y)
        {
            x = (float)X;
            y = (float)Y;

            length = 0;

            Recalculate();
        }

        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;

            length = 0;

            Recalculate();
        }

        public void SetXY(float X, float Y)
        {
            x = X;
            y = Y;

            Recalculate();
        }

        private void Recalculate()
        {
            //length = (float)Math.Sqrt(x * x + y * y);
        }

        public static Vector2 Lerp(Vector2 from, Vector2 to, float t)
        {
            return from + (to - from) * t;
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            return (a - b).Length;
        }

        public static Vector2 operator -(Vector2 a)
        {
            return a *= -1;
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            a.SetXY(a.X - b.X, a.Y - b.Y);

            return a;
        }
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            a.SetXY(a.X + b.X, a.Y + b.Y);

            return a;
        }
        public static Vector2 operator *(float b, Vector2 a)
        {
            a.SetXY(a.X * b, a.Y * b);

            return a;
        }
        public static Vector2 operator *(Vector2 a, float b)
        {
            a.SetXY(a.X * b, a.Y * b);

            return a;
        }
        public static Vector2 operator /(Vector2 a, float b)
        {
            a.SetXY(a.X / b, a.Y / b);

            return a;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2)
            {
                Vector2 v = (Vector2)obj;

                return
                     v.X == X &&
                     v.Y == Y;
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }
    }
}