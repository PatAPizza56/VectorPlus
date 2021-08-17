using System;
using System.Collections.Generic;
using System.Numerics;

namespace VectorPlus
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector5 a = new Vector5(3f, 7.4f, -2.6f, 1f, 0f);
            Vector5 zero = Vector5.Zero;
            Vector5 one = Vector5.One;
            Vector5 b = new Vector5(2.9f, 17.2f, 0f, 0f, -13.1f);

            float[] bArray = new float[7];
            b.CopyTo(bArray, 1);

            Console.WriteLine(a + zero);
            Console.WriteLine(b + one);
            Console.WriteLine(String.Join(',', bArray));
        }
    }

    struct Vector5
    {
        public float x;
        public float y;
        public float z;
        public float w;
        public float v;

        public static Vector5 One { get => new Vector5(1, 1, 1, 1, 1); }
        public static Vector5 UnitX { get => new Vector5(1); }
        public static Vector5 UnitY { get => new Vector5(0, 1); }
        public static Vector5 UnitZ { get => new Vector5(0, 0, 1); }
        public static Vector5 UnitW { get => new Vector5(0, 0, 0, 1); }
        public static Vector5 UnitV { get => new Vector5(0, 0, 0, 0, 1); }
        public static Vector5 Zero { get => new Vector5(0, 0, 0, 0, 0); }

        public static Vector5 operator +(Vector5 value1, Vector5 value2) => new Vector5(value1.x + value2.x, value1.y + value2.y, value1.z + value2.z, value1.w + value2.w, value1.v + value2.v);
        public static Vector5 operator -(Vector5 value) => new Vector5(-Math.Abs(value.x), -Math.Abs(value.y), -Math.Abs(value.z), -Math.Abs(value.w), -Math.Abs(value.v));
        public static Vector5 operator -(Vector5 value1, Vector5 value2) => new Vector5(value1.x - value2.x, value1.y - value2.y, value1.z - value2.z, value1.w - value2.w, value1.v - value2.v);
        public static Vector5 operator *(Vector5 value, float multiplier) => new Vector5(value.x * multiplier, value.y * multiplier, value.z * multiplier, value.w * multiplier, value.v * multiplier);
        public static Vector5 operator *(float multiplier, Vector5 value) => new Vector5(value.x * multiplier, value.y * multiplier, value.z * multiplier, value.w * multiplier, value.v * multiplier);
        public static Vector5 operator *(Vector5 value1, Vector5 value2) => new Vector5(value1.x * value2.x, value1.y * value2.y, value1.z * value2.z, value1.w * value2.w, value1.v * value2.v);
        public static Vector5 operator /(Vector5 value, float divisor) => new Vector5(value.x / divisor, value.y / divisor, value.z / divisor, value.w / divisor, value.v / divisor);
        public static Vector5 operator /(Vector5 value1, Vector5 value2) => new Vector5(value1.x / value2.x, value1.y / value2.y, value1.z / value2.z, value1.w / value2.w, value1.v / value2.v);
        public static bool operator ==(Vector5 value1, Vector5 value2)
        {
            if (value1.x == value2.x && value1.y == value2.y && value1.z == value2.z && value1.w == value2.w && value1.v == value2.v)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Vector5 value1, Vector5 value2)
        {
            if (value1.x == value2.x && value1.y == value2.y && value1.z == value2.z && value1.w == value2.w && value1.v == value2.v)
            {
                return false;
            }
            return true;
        }

        public static Vector5 Abs(Vector5 value)
        {
            return new Vector5(Math.Abs(value.x), Math.Abs(value.y), Math.Abs(value.z), Math.Abs(value.w), Math.Abs(value.v));
        }
        public static Vector5 Add(Vector5 value1, Vector5 value2)
        {
            return value1 + value2;
        }
        public static Vector5 Clamp(Vector5 value, Vector5 min, Vector5 max)
        {
            return new Vector5(Math.Clamp(value.x, min.x, max.x), Math.Clamp(value.y, min.y, max.y), Math.Clamp(value.z, min.z, max.z), Math.Clamp(value.w, min.w, max.w), Math.Clamp(value.v, min.v, max.v));
        }
        public void CopyTo(float[] array)
        {
            array[0] = this.x;
            array[1] = this.y;
            array[2] = this.z;
            array[3] = this.w;
            array[4] = this.v;
        }
        public void CopyTo(float[] array, int index)
        {
            array[index] = this.x;
            array[index + 1] = this.y;
            array[index + 2] = this.z;
            array[index + 3] = this.w;
            array[index + 4] = this.v;
        }
        public static Vector5 Cross(Vector5 value1, Vector5 value2)
        {
            return value1 * value2;
        }
        public static float Distance(Vector5 value1, Vector5 value2)
        {
            return Math.Abs(value1.x - value2.x) + Math.Abs(value1.y - value2.y) + Math.Abs(value1.z - value2.z) + Math.Abs(value1.w - value2.w) + Math.Abs(value1.v - value2.v);
        }
        public static float DistanceSquared(Vector5 value1, Vector5 value2)
        {
            Vector5 delta = value2 - value1;
            return Dot(delta, delta);
        }
        public static Vector5 Divide(Vector5 value, float divisor)
        {
            return value / divisor;
        }
        public static Vector5 Divide(Vector5 value1, Vector5 value2)
        {
            return value1 / value2;
        }
        public static float Dot(Vector5 value1, Vector5 value2)
        {
            return (value1.x * value2.x) + (value1.y * value2.y) + (value1.z * value2.z) + (value1.w * value2.w) + (value1.v * value2.v);
        }
        public override bool Equals(object? obj)
        {
            return this == (Vector5)obj;
        }
        public bool Equals(Vector5 value)
        {
            return this == value;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z, w, v);
        }
        public float Length()
        {
            return MathF.Sqrt(Dot(this, this));
        }
        public float LengthSquared()
        {
            return Dot(this, this);
        }
        public static Vector5 Lerp(Vector5 value1, Vector5 value2, float amount)
        {
            return value1 + (value2 - value1) * amount;
        }
        public static Vector5 Max(Vector5 value1, Vector5 value2)
        {
            return new Vector5(Math.Max(value1.x, value2.x), Math.Max(value1.y, value2.y), Math.Max(value1.z, value2.z), Math.Max(value1.w, value2.w), Math.Max(value1.v, value2.v));
        }
        public static Vector5 Min(Vector5 value1, Vector5 value2)
        {
            return new Vector5(Math.Min(value1.x, value2.x), Math.Min(value1.y, value2.y), Math.Min(value1.z, value2.z), Math.Min(value1.w, value2.w), Math.Min(value1.v, value2.v));
        }
        public static Vector5 Multiply(Vector5 value, float multipier)
        {
            return value * multipier;
        }
        public static Vector5 Multiply(Vector5 value1, Vector5 value2)
        {
            return value1 * value2;
        }
        public static Vector5 Negate(Vector5 value)
        {
            return new Vector5(-Math.Abs(value.x), -Math.Abs(value.y), -Math.Abs(value.z), -Math.Abs(value.w), -Math.Abs(value.v));
        }
        public static Vector5 Normalize(Vector5 value)
        {
            return value / value.Length();
        }
        public static Vector5 Reflect(Vector5 value, Vector5 normal)
        {
            return value - 2 * Dot(value, normal) * normal;
        }
        public static Vector5 SquareRoot(Vector5 value)
        {
            return value * value;
        }
        public override string ToString()
        {
            return $"({this.x}, {this.y}, {this.z}, {this.w}, {this.v})";
        }
        public Vector5(float x = 0, float y = 0, float z = 0, float w = 0, float v = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
            this.v = v;
        }
    }
}
