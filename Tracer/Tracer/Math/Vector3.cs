
namespace Math
{
    [System.Serializable]
    public struct Vector3
    {
        public static Vector3 Zero { get { return new Vector3(0, 0, 0); } }
        public static Vector3 One { get { return new Vector3(1, 1, 1); } }
        public static Vector3 Up { get { return new Vector3(0,1,0);} }
        public static Vector3 Right { get { return new Vector3(1, 0, 0); } }
        public static Vector3 Forward { get { return new Vector3(0, 0, 1); } }

        public float X
        {
            get => x;
            set => x = value;
        }

        public float Y
        {
            get => y;
            set => y = value;
        }

        public float Z
        {
            get => z;
            set => z = value;
        }

        public float Length { get => (float)System.Math.Sqrt(X * X + Y * Y + Z * Z); }
        public float Summ { get => summ; }
        public float Dot { get => dot; }


        private float
            x, y, z,
            summ, dot;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            summ = dot = 0;

        }

        public static Vector3 Cross(Vector3 left, Vector3 right)
        {
            Vector3 returnValue = Zero;

            returnValue.x = left.y * right.z - left.z * right.y;
            returnValue.y = left.z * right.x - left.x * right.z;
            returnValue.z = left.x * right.y - left.y * right.x;

            return returnValue;
        }

        public static Vector3 operator -(Vector3 a)
        {
            a.x = -a.x;
            a.y = -a.y;
            a.z = -a.z;

            return a;
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            a.x = a.x - b.x;
            a.y = a.y - b.y;
            a.z = a.z - b.z;

            return a;
        }
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            a.x = a.x + b.x;
            a.y = a.y + b.y;
            a.z = a.z + b.z;

            return a;
        }
        public static Vector3 operator *(Vector3 a, float b)
        {
            a.x = a.x * b;
            a.y = a.y * b;
            a.z = a.z * b;

            return a;
        }
        public static Vector3 operator /(Vector3 a, float b)
        {
            a.x = a.x / b;
            a.y = a.y / b;
            a.z = a.z / b;

            return a;
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, float alpha)
        {
            a.x += (b.x - a.x) * alpha;
            a.y += (b.y - a.y) * alpha;
            a.z += (b.z - a.z) * alpha;

            return a;
        }

        public override string ToString()
        {
            return $"({x};{y};{z})";
        }

        public override bool Equals(object obj)
        {
            return obj is Vector3 vector &&
                   x == vector.x &&
                   y == vector.y &&
                   z == vector.z;
        }
    }
}
