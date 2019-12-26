using System;

namespace Math
{
    public struct Matrix4x4
    {
        public float
            a11, a21, a31, a41,
            a12, a22, a32, a42,
            a13, a23, a33, a43,
            a14, a24, a34, a44;


        public static Matrix4x4 Idenity { get => idenity; }

        public Matrix4x4(
            float a11, float a21, float a31, float a41,
            float a12, float a22, float a32, float a42,
            float a13, float a23, float a33, float a43,
            float a14, float a24, float a34, float a44)
        {
            this.a11 = a11;
            this.a21 = a21;
            this.a31 = a31;
            this.a41 = a41;

            this.a12 = a12;
            this.a22 = a22;
            this.a32 = a32;
            this.a42 = a42;

            this.a13 = a13;
            this.a23 = a23;
            this.a33 = a33;
            this.a43 = a43;

            this.a14 = a14;
            this.a24 = a24;
            this.a34 = a34;
            this.a44 = a44;
        }

        private static Matrix4x4 idenity = 
            new Matrix4x4(
                 1, 0, 0, 0,
                 0, 1, 0, 0,
                 0, 0, 1, 0,
                 0, 0, 0, 1);

        public static Matrix4x4 operator * (Matrix4x4 a, Matrix4x4 b)
        {
            float a11 = a.a11 * b.a11 + a.a21 * b.a12 + a.a31 * b.a13 + a.a41 * b.a14;
            float a21 = a.a11 * b.a21 + a.a21 * b.a22 + a.a31 * b.a23 + a.a41 * b.a24;
            float a31 = a.a11 * b.a31 + a.a21 * b.a32 + a.a31 * b.a33 + a.a41 * b.a34;
            float a41 = a.a11 * b.a41 + a.a21 * b.a42 + a.a31 * b.a43 + a.a41 * b.a44;

            float a12 = a.a12 * b.a11 + a.a22 * b.a12 + a.a32 * b.a13 + a.a42 * b.a14;
            float a22 = a.a12 * b.a21 + a.a22 * b.a22 + a.a32 * b.a23 + a.a42 * b.a24;
            float a32 = a.a12 * b.a31 + a.a22 * b.a32 + a.a32 * b.a33 + a.a42 * b.a34;
            float a42 = a.a12 * b.a41 + a.a22 * b.a42 + a.a32 * b.a43 + a.a42 * b.a44;

            float a13 = a.a13 * b.a11 + a.a23 * b.a12 + a.a33 * b.a13 + a.a43 * b.a14;
            float a23 = a.a13 * b.a21 + a.a23 * b.a22 + a.a33 * b.a23 + a.a43 * b.a24;
            float a33 = a.a13 * b.a31 + a.a23 * b.a32 + a.a33 * b.a33 + a.a43 * b.a34;
            float a43 = a.a13 * b.a41 + a.a23 * b.a42 + a.a33 * b.a43 + a.a43 * b.a44;

            float a14 = a.a14 * b.a11 + a.a24 * b.a12 + a.a34 * b.a13 + a.a44 * b.a14;
            float a24 = a.a14 * b.a21 + a.a24 * b.a22 + a.a34 * b.a23 + a.a44 * b.a24;
            float a34 = a.a14 * b.a31 + a.a24 * b.a32 + a.a34 * b.a33 + a.a44 * b.a34;
            float a44 = a.a14 * b.a41 + a.a24 * b.a42 + a.a34 * b.a43 + a.a44 * b.a44;

            a.a11 = a11;
            a.a21 = a21;
            a.a31 = a31;
            a.a41 = a41;

            a.a12 = a12;
            a.a22 = a22;
            a.a32 = a32;
            a.a42 = a42;

            a.a13 = a13;
            a.a23 = a23;
            a.a33 = a33;
            a.a43 = a43;

            a.a14 = a14;
            a.a24 = a24;
            a.a34 = a34;
            a.a44 = a44;

            return a;
        }

        public static Matrix4x4 X_Matrix(float angle)
        {
            float cos = (float)System.Math.Cos(angle);
            float sin = (float)System.Math.Sin(angle);

            return new Matrix4x4(1, 0, 0,0,
                                 0, cos, sin,0,
                                 0, -sin, cos,0,
                                 0,0,0,1);
        }
        public static Matrix4x4 Y_Matrix(float angle)
        {
            float cos = (float)System.Math.Cos(angle);
            float sin = (float)System.Math.Sin(angle);

            return new Matrix4x4(cos, 0, -sin,0,
                                 0, 1, 0,0,
                                 sin, 0, cos,0,
                                 0,0,0,1);
        }
        public static Matrix4x4 Z_Matrix(float angle)
        {
            float cos = (float)System.Math.Cos(angle);
            float sin = (float)System.Math.Sin(angle);

            return new Matrix4x4(cos, sin, 0,0,
                                 -sin, cos, 0,0,
                                 0, 0, 1,0,
                                 0,0,0,1);
        }

        public Vector3 Multiply(Vector3 vector)
        {
            float X = a11 * vector.X + a21 * vector.Y + a31 * vector.Z + a41;
            float Y = a12 * vector.X + a22 * vector.Y + a32 * vector.Z + a42;
            
            vector.Z = a13 * vector.X + a23 * vector.Y + a33 * vector.Z + a43;
            vector.Y = Y;
            vector.X = X;

            return vector;
        }

        public static Matrix4x4 RotationMatrix(Vector3 rotation)
        {
            return 
                Z_Matrix(rotation.Z) *
                Y_Matrix(rotation.Y) *
                X_Matrix(rotation.X);
        }

        public override bool Equals(object obj)
        {
            return obj is Matrix4x4 x &&
                   a11 == x.a11 &&
                   a21 == x.a21 &&
                   a31 == x.a31 &&
                   a41 == x.a41 &&
                   a12 == x.a12 &&
                   a22 == x.a22 &&
                   a32 == x.a32 &&
                   a42 == x.a42 &&
                   a13 == x.a13 &&
                   a23 == x.a23 &&
                   a33 == x.a33 &&
                   a43 == x.a43 &&
                   a14 == x.a14 &&
                   a24 == x.a24 &&
                   a34 == x.a34 &&
                   a44 == x.a44;
        }


        public override string ToString()
        {
            return
                $"{a11} {a21} {a31} {a41}" +
                $"{a12} {a22} {a32} {a42}" +
                $"{a13} {a23} {a33} {a43}" +
                $"{a14} {a24} {a34} {a44}";
        }

        public override int GetHashCode()
        {
            var hashCode = 1519117352;
            hashCode = hashCode * -1521134295 + a11.GetHashCode();
            hashCode = hashCode * -1521134295 + a21.GetHashCode();
            hashCode = hashCode * -1521134295 + a31.GetHashCode();
            hashCode = hashCode * -1521134295 + a41.GetHashCode();
            hashCode = hashCode * -1521134295 + a12.GetHashCode();
            hashCode = hashCode * -1521134295 + a22.GetHashCode();
            hashCode = hashCode * -1521134295 + a32.GetHashCode();
            hashCode = hashCode * -1521134295 + a42.GetHashCode();
            hashCode = hashCode * -1521134295 + a13.GetHashCode();
            hashCode = hashCode * -1521134295 + a23.GetHashCode();
            hashCode = hashCode * -1521134295 + a33.GetHashCode();
            hashCode = hashCode * -1521134295 + a43.GetHashCode();
            hashCode = hashCode * -1521134295 + a14.GetHashCode();
            hashCode = hashCode * -1521134295 + a24.GetHashCode();
            hashCode = hashCode * -1521134295 + a34.GetHashCode();
            hashCode = hashCode * -1521134295 + a44.GetHashCode();
            return hashCode;
        }
    }
}
