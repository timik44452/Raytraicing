using System;

namespace Math
{
    public static class MathService
    {
        public static float Min(float a, float b)
        {
            return a > b ? b : a;
        }

        public static float Max(float a, float b)
        {
            return a < b ? b : a;
        }

        public static void Min(out float min, out float max, float a, float b)
        {
            if(a > b)
            {
                min = b;
                max = a;
            }
            else
            {
                min = a;
                max = b;
            }
        }

        public static float ToEuler(float value)
        {
            return value / (float)System.Math.PI * 180;
        }

        public static float ToRadian(float value)
        {
            return value / 180F * (float)System.Math.PI;
        }

        public static Vector3 ToEuler(Vector3 value)
        {
            return value / (float)System.Math.PI * 180;
        }

        public static Vector3 ToRadian(Vector3 value)
        {
            return value / 180F * (float)System.Math.PI;
        }

        public static float Lerp(float from, float to, float time)
        {
            return from + (to - from) * time;
        }

        public static float Clamp01(float value)
        {
            if(value > 1F)
            {
                return 1F;
            }
            else if(value < 0)
            {
                return 0;
            }
            else
            {
                return value;
            }
        }
    }
}
