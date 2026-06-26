using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct float4x4 : IEquatable<float4x4>, IEquatable<Unity.Mathematics.float4x4>, IEquatable<float>, IFormattable
    {
        public float4 c0;
        public float4 c1;
        public float4 c2;
        public float4 c3;

        public static float4x4 identity => new float4x4(1.0f, 0.0f, 0.0f, 0.0f,   0.0f, 1.0f, 0.0f, 0.0f,   0.0f, 0.0f, 1.0f, 0.0f,   0.0f, 0.0f, 0.0f, 1.0f);
        public static float4x4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(float4 c0, float4 c1, float4 c2, float4 c3)
        {
            this.c0 = c0;
            this.c1 = c1;
            this.c2 = c2;
            this.c3 = c3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(float m00, float m01, float m02, float m03,
                        float m10, float m11, float m12, float m13,
                        float m20, float m21, float m22, float m23,
                        float m30, float m31, float m32, float m33)
        {
            this.c0 = new float4(m00, m10, m20, m30);
            this.c1 = new float4(m01, m11, m21, m31);
            this.c2 = new float4(m02, m12, m22, m32);
            this.c3 = new float4(m03, m13, m23, m33);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(bool v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(bool4x4 v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(mask8x4x4 v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(mask16x4x4 v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(mask32x4x4 v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(mask64x4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(byte v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(byte4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(sbyte v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(sbyte4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(ushort v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(ushort4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(short v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(short4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(uint v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(uint4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(int v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(int4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(ulong v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(ulong4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(long v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(long4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(UInt128 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(Int128 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(quarter v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(half v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(float v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(float4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(double v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(double4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(quadruple v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(Unity.Mathematics.bool4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(Unity.Mathematics.uint4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(Unity.Mathematics.int4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(Unity.Mathematics.half v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(Unity.Mathematics.float4x4 v)
        {
            this = (float4x4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(Unity.Mathematics.double4x4 v)
        {
            this = (float4x4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(AffineTransform transform) => this = Unity.Mathematics.math.float4x4(transform);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float4x4(Unity.Mathematics.AffineTransform transform) => this = Unity.Mathematics.math.float4x4(transform);
        
        /// <summary>   Constructs a <see cref="float4x4"/> from a <see cref="float3x3"/> rotation matrix and a <see cref="float3"/> translation vector.   </summary>
        public float4x4(float3x3 rotation, float3 translation) => this = Unity.Mathematics.math.float4x4(rotation, translation);

        /// <summary>   Constructs a <see cref="float4x4"/> from a quaternion and a <see cref="float3"/> translation vector.   </summary>
        public float4x4(quaternion rotation, float3 translation) => this = Unity.Mathematics.math.float4x4(rotation, translation);

        /// <summary>   Constructs a <see cref="float4x4"/> from a <see cref="RigidTransform"/>.   </summary>
        public float4x4(RigidTransform transform) => this = Unity.Mathematics.math.float4x4(transform);
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(UInt128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(Int128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(quarter x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(quadruple x) => (float)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(UnityEngine.Matrix4x4 v) => (Unity.Mathematics.float4x4)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Matrix4x4(float4x4 v) => (Unity.Mathematics.float4x4)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(Unity.Mathematics.float4x4 v) => new float4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4x4(float4x4 v) => new Unity.Mathematics.float4x4 { c0 = v.c0, c1 = v.c1, c2 = v.c2, c3 = v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4x4(float4x4 v) => new bool4x4 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2, c3 = (bool4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(Unity.Mathematics.bool4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4x4(float4x4 v) => new Unity.Mathematics.bool4x4 { c0 = (bool4)v.c0, c1 = (bool4)v.c1, c2 = (bool4)v.c2, c3 = (bool4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(Unity.Mathematics.int4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4x4(float4x4 v) => new int4x4 { c0 = (int4)v.c0, c1 = (int4)v.c1, c2 = (int4)v.c2, c3 = (int4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(Unity.Mathematics.uint4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4x4(float4x4 v) => new uint4x4 { c0 = (uint4)v.c0, c1 = (uint4)v.c1, c2 = (uint4)v.c2, c3 = (uint4)v.c3 };
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(Unity.Mathematics.double4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4x4(float4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(float v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(bool v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(bool4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float4x4(sbyte v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(sbyte4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float4x4(short v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(short4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(int v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(int4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(long v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(long4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float4x4(byte v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(byte4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float4x4(ushort v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(ushort4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(uint v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(uint4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(ulong v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(ulong4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4x4(half v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(double v) => new float4x4 { c0 = (float4)v, c1 = (float4)v, c2 = (float4)v, c3 = (float4)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(double4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(mask8x4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(mask16x4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(mask32x4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4x4(mask64x4x4 v) => new float4x4 { c0 = (float4)v.c0, c1 = (float4)v.c1, c2 = (float4)v.c2, c3 = (float4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4x4(float4x4 v) => new mask8x4x4 { c0 = (mask8x4)v.c0, c1 = (mask8x4)v.c1, c2 = (mask8x4)v.c2, c3 = (mask8x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4x4(float4x4 v) => new mask16x4x4 { c0 = (mask16x4)v.c0, c1 = (mask16x4)v.c1, c2 = (mask16x4)v.c2, c3 = (mask16x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4x4(float4x4 v) => new mask32x4x4 { c0 = (mask32x4)v.c0, c1 = (mask32x4)v.c1, c2 = (mask32x4)v.c2, c3 = (mask32x4)v.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4x4(float4x4 v) => new mask64x4x4 { c0 = (mask64x4)v.c0, c1 = (mask64x4)v.c1, c2 = (mask64x4)v.c2, c3 = (mask64x4)v.c3 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 val) => new float4x4 { c0 = +val.c0, c1 = +val.c1, c2 = +val.c2, c3 = +val.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 val) => new float4x4 { c0 = -val.c0, c1 = -val.c1, c2 = -val.c2, c3 = -val.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator ++ (float4x4 val) => new float4x4 { c0 = val.c0 + 1, c1 = val.c1 + 1, c2 = val.c2 + 1, c3 = val.c3 + 1 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator -- (float4x4 val) => new float4x4 { c0 = val.c0 - 1, c1 = val.c1 - 1, c2 = val.c2 - 1, c3 = val.c3 - 1 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, float4x4 rhs) => new float4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, float rhs) => new float4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float lhs, float4x4 rhs) => new float4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, float4x4 rhs) => new float4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, float rhs) => new float4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float lhs, float4x4 rhs) => new float4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, float4x4 rhs) => new float4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, float rhs) => new float4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float lhs, float4x4 rhs) => new float4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, float4x4 rhs) => new float4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, float rhs) => new float4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float lhs, float4x4 rhs) => new float4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, float4x4 rhs) => new float4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, float rhs) => new float4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float lhs, float4x4 rhs) => new float4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => new float4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => new float4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => new float4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => new float4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => new float4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => new float4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => new float4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => new float4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => new float4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => new float4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => new double4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => new double4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => new double4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => new double4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => new double4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator + (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => new double4x4 { c0 = lhs.c0 + rhs.c0, c1 = lhs.c1 + rhs.c1, c2 = lhs.c2 + rhs.c2, c3 = lhs.c3 + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator - (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => new double4x4 { c0 = lhs.c0 - rhs.c0, c1 = lhs.c1 - rhs.c1, c2 = lhs.c2 - rhs.c2, c3 = lhs.c3 - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator * (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => new double4x4 { c0 = lhs.c0 * rhs.c0, c1 = lhs.c1 * rhs.c1, c2 = lhs.c2 * rhs.c2, c3 = lhs.c3 * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator / (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => new double4x4 { c0 = lhs.c0 / rhs.c0, c1 = lhs.c1 / rhs.c1, c2 = lhs.c2 / rhs.c2, c3 = lhs.c3 / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4x4 operator % (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => new double4x4 { c0 = lhs.c0 % rhs.c0, c1 = lhs.c1 % rhs.c1, c2 = lhs.c2 % rhs.c2, c3 = lhs.c3 % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, quarter rhs) => new float4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, quarter rhs) => new float4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, quarter rhs) => new float4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, quarter rhs) => new float4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, quarter rhs) => new float4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (quarter lhs, float4x4 rhs) => new float4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (quarter lhs, float4x4 rhs) => new float4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (quarter lhs, float4x4 rhs) => new float4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (quarter lhs, float4x4 rhs) => new float4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (quarter lhs, float4x4 rhs) => new float4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, half rhs) => new float4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, half rhs) => new float4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, half rhs) => new float4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, half rhs) => new float4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, half rhs) => new float4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (half lhs, float4x4 rhs) => new float4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (half lhs, float4x4 rhs) => new float4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (half lhs, float4x4 rhs) => new float4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (half lhs, float4x4 rhs) => new float4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (half lhs, float4x4 rhs) => new float4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, Unity.Mathematics.half rhs) => new float4x4 { c0 = lhs.c0 + rhs, c1 = lhs.c1 + rhs, c2 = lhs.c2 + rhs, c3 = lhs.c3 + rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, Unity.Mathematics.half rhs) => new float4x4 { c0 = lhs.c0 - rhs, c1 = lhs.c1 - rhs, c2 = lhs.c2 - rhs, c3 = lhs.c3 - rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, Unity.Mathematics.half rhs) => new float4x4 { c0 = lhs.c0 * rhs, c1 = lhs.c1 * rhs, c2 = lhs.c2 * rhs, c3 = lhs.c3 * rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, Unity.Mathematics.half rhs) => new float4x4 { c0 = lhs.c0 / rhs, c1 = lhs.c1 / rhs, c2 = lhs.c2 / rhs, c3 = lhs.c3 / rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, Unity.Mathematics.half rhs) => new float4x4 { c0 = lhs.c0 % rhs, c1 = lhs.c1 % rhs, c2 = lhs.c2 % rhs, c3 = lhs.c3 % rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (Unity.Mathematics.half lhs, float4x4 rhs) => new float4x4 { c0 = lhs + rhs.c0, c1 = lhs + rhs.c1, c2 = lhs + rhs.c2, c3 = lhs + rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (Unity.Mathematics.half lhs, float4x4 rhs) => new float4x4 { c0 = lhs - rhs.c0, c1 = lhs - rhs.c1, c2 = lhs - rhs.c2, c3 = lhs - rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (Unity.Mathematics.half lhs, float4x4 rhs) => new float4x4 { c0 = lhs * rhs.c0, c1 = lhs * rhs.c1, c2 = lhs * rhs.c2, c3 = lhs * rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (Unity.Mathematics.half lhs, float4x4 rhs) => new float4x4 { c0 = lhs / rhs.c0, c1 = lhs / rhs.c1, c2 = lhs / rhs.c2, c3 = lhs / rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (Unity.Mathematics.half lhs, float4x4 rhs) => new float4x4 { c0 = lhs % rhs.c0, c1 = lhs % rhs.c1, c2 = lhs % rhs.c2, c3 = lhs % rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, byte4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, byte4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, byte4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, byte4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, byte4x4 rhs) => lhs % (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, sbyte4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, sbyte4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, sbyte4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, sbyte4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, sbyte4x4 rhs) => lhs % (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, short4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, short4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, short4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, short4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, short4x4 rhs) => lhs % (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (short4x4 lhs, float4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (short4x4 lhs, float4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (short4x4 lhs, float4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (short4x4 lhs, float4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (short4x4 lhs, float4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, ushort4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, ushort4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, ushort4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, ushort4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, ushort4x4 rhs) => lhs % (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, int4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, int4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, int4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, int4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, int4x4 rhs) => lhs % (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (int4x4 lhs, float4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (int4x4 lhs, float4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (int4x4 lhs, float4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (int4x4 lhs, float4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (int4x4 lhs, float4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, uint4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, uint4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, uint4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, uint4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, uint4x4 rhs) => lhs % (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs % (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs % (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, long4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, long4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, long4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, long4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, long4x4 rhs) => lhs % (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (long4x4 lhs, float4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (long4x4 lhs, float4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (long4x4 lhs, float4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (long4x4 lhs, float4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (long4x4 lhs, float4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, ulong4x4 rhs) => lhs + (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, ulong4x4 rhs) => lhs - (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, ulong4x4 rhs) => lhs * (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, ulong4x4 rhs) => lhs / (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, ulong4x4 rhs) => lhs % (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, byte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (byte lhs, float4x4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, byte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (byte lhs, float4x4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, byte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (byte lhs, float4x4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, byte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (byte lhs, float4x4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, byte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (byte lhs, float4x4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, sbyte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (sbyte lhs, float4x4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, sbyte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (sbyte lhs, float4x4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, sbyte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (sbyte lhs, float4x4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, sbyte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (sbyte lhs, float4x4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, sbyte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (sbyte lhs, float4x4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, short rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (short lhs, float4x4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, short rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (short lhs, float4x4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, short rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (short lhs, float4x4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, short rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (short lhs, float4x4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, short rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (short lhs, float4x4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, ushort rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (ushort lhs, float4x4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, ushort rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (ushort lhs, float4x4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, ushort rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (ushort lhs, float4x4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, ushort rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (ushort lhs, float4x4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, ushort rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (ushort lhs, float4x4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, int rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (int lhs, float4x4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, int rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (int lhs, float4x4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, int rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (int lhs, float4x4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, int rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (int lhs, float4x4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, int rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (int lhs, float4x4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, uint rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (uint lhs, float4x4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, uint rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (uint lhs, float4x4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, uint rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (uint lhs, float4x4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, uint rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (uint lhs, float4x4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, uint rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (uint lhs, float4x4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, long rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (long lhs, float4x4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, long rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (long lhs, float4x4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, long rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (long lhs, float4x4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, long rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (long lhs, float4x4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, long rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (long lhs, float4x4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, ulong rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (ulong lhs, float4x4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, ulong rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (ulong lhs, float4x4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, ulong rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (ulong lhs, float4x4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, ulong rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (ulong lhs, float4x4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, ulong rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (ulong lhs, float4x4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, Int128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (Int128 lhs, float4x4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, Int128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (Int128 lhs, float4x4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, Int128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (Int128 lhs, float4x4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, Int128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (Int128 lhs, float4x4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, Int128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (Int128 lhs, float4x4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (float4x4 lhs, UInt128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator + (UInt128 lhs, float4x4 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (float4x4 lhs, UInt128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator - (UInt128 lhs, float4x4 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (float4x4 lhs, UInt128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator * (UInt128 lhs, float4x4 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (float4x4 lhs, UInt128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator / (UInt128 lhs, float4x4 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (float4x4 lhs, UInt128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 operator % (UInt128 lhs, float4x4 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs.c0, c1 = lhs.c1 == rhs.c1, c2 = lhs.c2 == rhs.c2, c3 = lhs.c3 == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, float rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs.c0, c1 = lhs.c1 != rhs.c1, c2 = lhs.c2 != rhs.c2, c3 = lhs.c3 != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, float rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 < rhs.c0, c1 = lhs.c1 < rhs.c1, c2 = lhs.c2 < rhs.c2, c3 = lhs.c3 < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, float rhs) => new mask32x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 > rhs.c0, c1 = lhs.c1 > rhs.c1, c2 = lhs.c2 > rhs.c2, c3 = lhs.c3 > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, float rhs) => new mask32x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 <= rhs.c0, c1 = lhs.c1 <= rhs.c1, c2 = lhs.c2 <= rhs.c2, c3 = lhs.c3 <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, float rhs) => new mask32x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs.c0 >= rhs.c0, c1 = lhs.c1 >= rhs.c1, c2 = lhs.c2 >= rhs.c2, c3 = lhs.c3 >= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, float rhs) => new mask32x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, Unity.Mathematics.float4x4 rhs) => lhs >= (float4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (Unity.Mathematics.float4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs == (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs != (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs < (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs > (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs <= (double4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (float4x4 lhs, Unity.Mathematics.double4x4 rhs) => lhs >= (double4x4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator == (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => (double4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator != (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => (double4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator < (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => (double4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator > (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => (double4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator <= (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => (double4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4x4 operator >= (Unity.Mathematics.double4x4 lhs, float4x4 rhs) => (double4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, quarter rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, quarter rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, quarter rhs) => new mask32x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, quarter rhs) => new mask32x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, quarter rhs) => new mask32x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, quarter rhs) => new mask32x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (quarter lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (quarter lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (quarter lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (quarter lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (quarter lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (quarter lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, half rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, half rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, half rhs) => new mask32x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, half rhs) => new mask32x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, half rhs) => new mask32x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, half rhs) => new mask32x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, Unity.Mathematics.half rhs) => new mask32x4x4 { c0 = lhs.c0 == rhs, c1 = lhs.c1 == rhs, c2 = lhs.c2 == rhs, c3 = lhs.c3 == rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, Unity.Mathematics.half rhs) => new mask32x4x4 { c0 = lhs.c0 != rhs, c1 = lhs.c1 != rhs, c2 = lhs.c2 != rhs, c3 = lhs.c3 != rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, Unity.Mathematics.half rhs) => new mask32x4x4 { c0 = lhs.c0 < rhs, c1 = lhs.c1 < rhs, c2 = lhs.c2 < rhs, c3 = lhs.c3 < rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, Unity.Mathematics.half rhs) => new mask32x4x4 { c0 = lhs.c0 > rhs, c1 = lhs.c1 > rhs, c2 = lhs.c2 > rhs, c3 = lhs.c3 > rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, Unity.Mathematics.half rhs) => new mask32x4x4 { c0 = lhs.c0 <= rhs, c1 = lhs.c1 <= rhs, c2 = lhs.c2 <= rhs, c3 = lhs.c3 <= rhs };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, Unity.Mathematics.half rhs) => new mask32x4x4 { c0 = lhs.c0 >= rhs, c1 = lhs.c1 >= rhs, c2 = lhs.c2 >= rhs, c3 = lhs.c3 >= rhs };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Unity.Mathematics.half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs == rhs.c0, c1 = lhs == rhs.c1, c2 = lhs == rhs.c2, c3 = lhs == rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Unity.Mathematics.half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs != rhs.c0, c1 = lhs != rhs.c1, c2 = lhs != rhs.c2, c3 = lhs != rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (Unity.Mathematics.half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs < rhs.c0, c1 = lhs < rhs.c1, c2 = lhs < rhs.c2, c3 = lhs < rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (Unity.Mathematics.half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs > rhs.c0, c1 = lhs > rhs.c1, c2 = lhs > rhs.c2, c3 = lhs > rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (Unity.Mathematics.half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs <= rhs.c0, c1 = lhs <= rhs.c1, c2 = lhs <= rhs.c2, c3 = lhs <= rhs.c3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (Unity.Mathematics.half lhs, float4x4 rhs) => new mask32x4x4 { c0 = lhs >= rhs.c0, c1 = lhs >= rhs.c1, c2 = lhs >= rhs.c2, c3 = lhs >= rhs.c3 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, byte4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, byte4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, byte4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, byte4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, byte4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, byte4x4 rhs) => lhs >= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (byte4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, sbyte4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, sbyte4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, sbyte4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, sbyte4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, sbyte4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, sbyte4x4 rhs) => lhs >= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (sbyte4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, short4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, short4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, short4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, short4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, short4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, short4x4 rhs) => lhs >= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (short4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (short4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (short4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (short4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (short4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (short4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, ushort4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, ushort4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, ushort4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, ushort4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, ushort4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, ushort4x4 rhs) => lhs >= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (ushort4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, int4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, int4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, int4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, int4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, int4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, int4x4 rhs) => lhs >= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, uint4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, uint4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, uint4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, uint4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, uint4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, uint4x4 rhs) => lhs >= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, Unity.Mathematics.int4x4 rhs) => lhs >= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (Unity.Mathematics.int4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, Unity.Mathematics.uint4x4 rhs) => lhs >= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (Unity.Mathematics.uint4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, long4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, long4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, long4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, long4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, long4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, long4x4 rhs) => lhs >= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (long4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (long4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (long4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (long4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (long4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (long4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, ulong4x4 rhs) => lhs == (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, ulong4x4 rhs) => lhs != (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, ulong4x4 rhs) => lhs < (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, ulong4x4 rhs) => lhs > (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, ulong4x4 rhs) => lhs <= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, ulong4x4 rhs) => lhs >= (float4x4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (ulong4x4 lhs, float4x4 rhs) => (float4x4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, byte rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (byte lhs, float4x4 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, byte rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (byte lhs, float4x4 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, byte rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (byte lhs, float4x4 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, byte rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (byte lhs, float4x4 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, byte rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (byte lhs, float4x4 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, byte rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (byte lhs, float4x4 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, sbyte rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (sbyte lhs, float4x4 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, sbyte rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (sbyte lhs, float4x4 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, sbyte rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (sbyte lhs, float4x4 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, sbyte rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (sbyte lhs, float4x4 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, sbyte rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (sbyte lhs, float4x4 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, sbyte rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (sbyte lhs, float4x4 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, short rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (short lhs, float4x4 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, short rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (short lhs, float4x4 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, short rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (short lhs, float4x4 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, short rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (short lhs, float4x4 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, short rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (short lhs, float4x4 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, short rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (short lhs, float4x4 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, ushort rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (ushort lhs, float4x4 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, ushort rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (ushort lhs, float4x4 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, ushort rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (ushort lhs, float4x4 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, ushort rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (ushort lhs, float4x4 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, ushort rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (ushort lhs, float4x4 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, ushort rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (ushort lhs, float4x4 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, int rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (int lhs, float4x4 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, int rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (int lhs, float4x4 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, int rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (int lhs, float4x4 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, int rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (int lhs, float4x4 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, int rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (int lhs, float4x4 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, int rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (int lhs, float4x4 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, uint rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (uint lhs, float4x4 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, uint rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (uint lhs, float4x4 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, uint rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (uint lhs, float4x4 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, uint rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (uint lhs, float4x4 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, uint rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (uint lhs, float4x4 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, uint rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (uint lhs, float4x4 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, long rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (long lhs, float4x4 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, long rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (long lhs, float4x4 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, long rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (long lhs, float4x4 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, long rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (long lhs, float4x4 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, long rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (long lhs, float4x4 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, long rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (long lhs, float4x4 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, ulong rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (ulong lhs, float4x4 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, ulong rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (ulong lhs, float4x4 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, ulong rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (ulong lhs, float4x4 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, ulong rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (ulong lhs, float4x4 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, ulong rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (ulong lhs, float4x4 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, ulong rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (ulong lhs, float4x4 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, Int128 rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (Int128 lhs, float4x4 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, Int128 rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (Int128 lhs, float4x4 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, Int128 rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (Int128 lhs, float4x4 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, Int128 rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (Int128 lhs, float4x4 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, Int128 rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (Int128 lhs, float4x4 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, Int128 rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (Int128 lhs, float4x4 rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (float4x4 lhs, UInt128 rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator == (UInt128 lhs, float4x4 rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (float4x4 lhs, UInt128 rhs) => lhs != (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator != (UInt128 lhs, float4x4 rhs) => (float)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (float4x4 lhs, UInt128 rhs) => lhs < (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator < (UInt128 lhs, float4x4 rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (float4x4 lhs, UInt128 rhs) => lhs > (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator > (UInt128 lhs, float4x4 rhs) => (float)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (float4x4 lhs, UInt128 rhs) => lhs <= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator <= (UInt128 lhs, float4x4 rhs) => (float)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (float4x4 lhs, UInt128 rhs) => lhs >= (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4x4 operator >= (UInt128 lhs, float4x4 rhs) => (float)lhs >= rhs;


        public ref float4 this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (float4x4* array = &this) { return ref ((float4*)array)[index]; }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float other) => math.all(this.c0 == other & this.c1 == other & this.c2 == other & this.c3 == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.float4x4 other) => math.all(this.c0 == other.c0 & this.c1 == other.c1 & this.c2 == other.c2 & this.c3 == other.c3);
        
        public override readonly bool Equals(object o) => (o is float4x4 converted && Equals(converted)) || (o is Unity.Mathematics.float4x4 convertedU && Equals(convertedU)) || (o is float convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => ((Unity.Mathematics.float4x4)this).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => ((Unity.Mathematics.float4x4)this).ToString(format, formatProvider);


        /// <summary>   Returns a <see cref="float4x4"/> matrix representing a rotation around a unit axis by an angle in radians. The rotation direction is clockwise when looking along the rotation axis towards the origin.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 AxisAngle(float3 axis, float angle)
        {
            math.sincos(angle, out float sina, out float cosa);

            float4 u = new float4(axis, 0f);
            float4 u_yzx = u.yzxx;
            float4 u_zxy = u.zxyx;
            float4 u_inv_cosa = u - u * cosa;  // u * (1f - cosa);
            float4 t = new float4(u.xyz * sina, cosa);

            uint4 ppnp = new uint4(            0,             0,      1u << 31, 0);
            uint4 nppp = new uint4(     1u << 31,             0,             0, 0);
            uint4 pnpp = new uint4(            0,      1u << 31,             0, 0);
            uint4 mask = new uint4(uint.MaxValue, uint.MaxValue, uint.MaxValue, 0);

            return new float4x4(
                u.x * u_inv_cosa + math.asfloat((math.asuint(t.wzyx) ^ ppnp) & mask),
                u.y * u_inv_cosa + math.asfloat((math.asuint(t.zwxx) ^ nppp) & mask),
                u.z * u_inv_cosa + math.asfloat((math.asuint(t.yxwx) ^ pnpp) & mask),
                new float4(0f, 0f, 0f, 1f)
                );

        }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the x-axis, then the y-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerXYZ(float3 xyz)
        {
            math.sincos(xyz, out float3 s, out float3 c);
            return new float4x4(
                c.y * c.z,  c.z * s.x * s.y - c.x * s.z,    c.x * c.z * s.y + s.x * s.z,    0f,
                c.y * s.z,  c.x * c.z + s.x * s.y * s.z,    c.x * s.y * s.z - c.z * s.x,    0f,
                -s.y,       c.y * s.x,                      c.x * c.y,                      0f,
                0f,       0f,                           0f,                           1f
                );
        }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the x-axis, then the z-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerXZY(float3 xyz)
        {
            math.sincos(xyz, out float3 s, out float3 c);
            return new float4x4(
                c.y * c.z,  s.x * s.y - c.x * c.y * s.z,    c.x * s.y + c.y * s.x * s.z,    0f,
                s.z,        c.x * c.z,                      -c.z * s.x,                     0f,
                -c.z * s.y, c.y * s.x + c.x * s.y * s.z,    c.x * c.y - s.x * s.y * s.z,    0f,
                0f,       0f,                           0f,                           1f
                );
        }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the y-axis, then the x-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerYXZ(float3 xyz)
        {
            math.sincos(xyz, out float3 s, out float3 c);
            return new float4x4(
                c.y * c.z - s.x * s.y * s.z,    -c.x * s.z, c.z * s.y + c.y * s.x * s.z,    0f,
                c.z * s.x * s.y + c.y * s.z,    c.x * c.z,  s.y * s.z - c.y * c.z * s.x,    0f,
                -c.x * s.y,                     s.x,        c.x * c.y,                      0f,
                0f,                           0f,       0f,                           1f
                );
        }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the y-axis, then the z-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerYZX(float3 xyz)
        {
            math.sincos(xyz, out float3 s, out float3 c);
            return new float4x4(
                c.y * c.z,                      -s.z,       c.z * s.y,                      0f,
                s.x * s.y + c.x * c.y * s.z,    c.x * c.z,  c.x * s.y * s.z - c.y * s.x,    0f,
                c.y * s.x * s.z - c.x * s.y,    c.z * s.x,  c.x * c.y + s.x * s.y * s.z,    0f,
                0f,                           0f,       0f,                           1f
                );
        }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the z-axis, then the x-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. This is the default order rotation order in Unity.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerZXY(float3 xyz)
        {
            math.sincos(xyz, out float3 s, out float3 c);
            return new float4x4(
                c.y * c.z + s.x * s.y * s.z,    c.z * s.x * s.y - c.y * s.z,    c.x * s.y,  0f,
                c.x * s.z,                      c.x * c.z,                      -s.x,       0f,
                c.y * s.x * s.z - c.z * s.y,    c.y * c.z * s.x + s.y * s.z,    c.x * c.y,  0f,
                0f,                           0f,                           0f,       1f
                );
        }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the z-axis, then the y-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerZYX(float3 xyz)
        {
            math.sincos(xyz, out float3 s, out float3 c);
            return new float4x4(
                c.y * c.z,                      -c.y * s.z,                     s.y,        0f,
                c.z * s.x * s.y + c.x * s.z,    c.x * c.z - s.x * s.y * s.z,    -c.y * s.x, 0f,
                s.x * s.z - c.x * c.z * s.y,    c.z * s.x + c.x * s.y * s.z,    c.x * c.y,  0f,
                0f,                           0f,                           0f,       1f
                );
        }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the x-axis, then the y-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerXYZ(float x, float y, float z) { return EulerXYZ(new float3(x, y, z)); }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the x-axis, then the z-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerXZY(float x, float y, float z) { return EulerXZY(new float3(x, y, z)); }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the y-axis, then the x-axis and finally the z-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerYXZ(float x, float y, float z) { return EulerYXZ(new float3(x, y, z)); }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the y-axis, then the z-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerYZX(float x, float y, float z) { return EulerYZX(new float3(x, y, z)); }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the z-axis, then the x-axis and finally the y-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. This is the default order rotation order in Unity.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerZXY(float x, float y, float z) { return EulerZXY(new float3(x, y, z)); }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing a rotation around the z-axis, then the y-axis and finally the x-axis. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 EulerZYX(float x, float y, float z) { return EulerZYX(new float3(x, y, z)); }

        /// <summary>   Returns a <see cref="float4x4"/> constructed by first performing 3 rotations around the principal axes in a given order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. When the rotation order is known at compile time, it is recommended for performance reasons to use specific Euler rotation constructors such as EulerZXY(...).  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 Euler(float3 xyz, math.RotationOrder order = math.RotationOrder.Default)
        {
            switch (order)
            {
                case math.RotationOrder.XYZ: return EulerXYZ(xyz);
                case math.RotationOrder.XZY: return EulerXZY(xyz);
                case math.RotationOrder.YXZ: return EulerYXZ(xyz);
                case math.RotationOrder.YZX: return EulerYZX(xyz);
                case math.RotationOrder.ZXY: return EulerZXY(xyz);
                case math.RotationOrder.ZYX: return EulerZYX(xyz);
                default:                     return float4x4.identity;
            }
        }

        /// <summary>   Returns a <see cref="float4x4"/> rotation matrix constructed by first performing 3 rotations around the principal axes in a given order. All rotation angles are in radians and clockwise when looking along the rotation axis towards the origin. When the rotation order is known at compile time, it is recommended for performance reasons to use specific Euler rotation constructors such as EulerZXY(...).  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 Euler(float x, float y, float z, math.RotationOrder order = math.RotationOrder.Default)
        {
            return Euler(new float3(x, y, z), order);
        }

        /// <summary>   Returns a <see cref="float4x4"/> matrix that rotates around the x-axis by a given number of radians.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 RotateX(float angle)
        {
            math.sincos(angle, out float s, out float c);
            return new float4x4(1f, 0f, 0f, 0f,
                                0f, c,    -s,   0f,
                                0f, s,    c,    0f,
                                0f, 0f, 0f, 1f);
        }

        /// <summary>   Returns a <see cref="float4x4"/> matrix that rotates around the y-axis by a given number of radians.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 RotateY(float angle)
        {
            math.sincos(angle, out float s, out float c);
            return new float4x4(c,    0f, s,    0f,
                                0f, 1f, 0f, 0f,
                                -s,   0f, c,    0f,
                                0f, 0f, 0f, 1f);
        }

        /// <summary>   Returns a <see cref="float4x4"/> matrix that rotates around the z-axis by a given number of radians.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 RotateZ(float angle)
        {
            math.sincos(angle, out float s, out float c);
            return new float4x4(c,    -s,   0f, 0f,
                                s,    c,    0f, 0f,
                                0f, 0f, 1f, 0f,
                                0f, 0f, 0f, 1f);
        }

        /// <summary>   Returns a <see cref="float4x4"/> scale matrix given 3 axis scales.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 Scale(float s)
        {
            return new float4x4(s,    0f, 0f, 0f,
                                0f, s,    0f, 0f,
                                0f, 0f, s,    0f,
                                0f, 0f, 0f, 1f);
        }

        /// <summary>   Returns a <see cref="float4x4"/> scale matrix given a <see cref="float3"/> vector containing the 3 axis scales.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 Scale(float x, float y, float z)
        {
            return new float4x4(x,    0f, 0f, 0f,
                                0f, y,    0f, 0f,
                                0f, 0f, z,    0f,
                                0f, 0f, 0f, 1f);
        }

        /// <summary>   Returns a <see cref="float4x4"/> scale matrix given a <see cref="float3"/> vector containing the 3 axis scales.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 Scale(float3 scales)
        {
            return Scale(scales.x, scales.y, scales.z);
        }

        /// <summary>   Returns a <see cref="float4x4"/> translation matrix given a <see cref="float3"/> translation vector.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 Translate(float3 vector)
        {
            return new float4x4(new float4(1f, 0f, 0f, 0f),
                                new float4(0f, 1f, 0f, 0f),
                                new float4(0f, 0f, 1f, 0f),
                                new float4(vector.x, vector.y, vector.z, 1f));
        }

        /// <summary>   Returns a <see cref="float4x4"/> view matrix given an eye position, a target point and a unit length up vector. The up vector is assumed to be unit length, the eye and target points are assumed to be distinct and the vector between them is assumes to be collinear with the up vector. If these assumptions are not met use <see cref="float4x4.LookRotationSafe"/> instead. </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 LookAt(float3 eye, float3 target, float3 up)
        {
            float3x3 rot = float3x3.LookRotation(math.normalize(target - eye), up);

            float4x4 matrix;
            matrix.c0 = new float4(rot.c0, 0f);
            matrix.c1 = new float4(rot.c1, 0f);
            matrix.c2 = new float4(rot.c2, 0f);
            matrix.c3 = new float4(eye, 1f);
            return matrix;
        }

        /// <summary>   Returns a <see cref="float4x4"/> centered orthographic projection matrix.   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 Ortho(float width, float height, float near, float far)
        {
            float rcpdx = math.rcp(width);
            float rcpdy = math.rcp(height);
            float rcpdz = math.rcp(far - near);

            return new float4x4(
                2f * rcpdx,   0f,            0f,           0f,
                0f,           2f * rcpdy,    0f,           0f,
                0f,           0f,           -2f * rcpdz,  -(far + near) * rcpdz,
                0f,           0f,            0f,           1f
                );
        }

        /// <summary>   Returns a <see cref="float4x4"/> off-center orthographic projection matrix.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 OrthoOffCenter(float left, float right, float bottom, float top, float near, float far)
        {
            float rcpdx = math.rcp(right - left);
            float rcpdy = math.rcp(top - bottom);
            float rcpdz = math.rcp(far - near);

            return new float4x4(
                2f * rcpdx,   0f,           0f,               -(right + left) * rcpdx,
                0f,           2f * rcpdy,   0f,               -(top + bottom) * rcpdy,
                0f,           0f,          -2f * rcpdz,       -(far + near) * rcpdz,
                0f,           0f,           0f,                1f
                );
        }

        /// <summary>   Returns a <see cref="float4x4"/> perspective projection matrix based on field of view.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 PerspectiveFov(float verticalFov, float aspect, float near, float far)
        {
            float cotangent = math.rcp(math.tan(verticalFov * 0.5f));
            float rcpdz = math.rcp(near - far);

            return new float4x4(
                cotangent / aspect, 0f,       0f,                   0f,
                0f,               cotangent,  0f,                   0f,
                0f,               0f,       (far + near) * rcpdz,   2f * near * far * rcpdz,
                0f,               0f,      -1f,                   0f
                );
        }

        /// <summary>   Returns a <see cref="float4x4"/> off-center perspective projection matrix.  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far)
        {
            float rcpdz = math.rcp(near - far);
            float rcpWidth = math.rcp(right - left);
            float rcpHeight = math.rcp(top - bottom);

            return new float4x4(
                2f * near * rcpWidth,     0f,                       (left + right) * rcpWidth,     0f,
                0f,                       2f * near * rcpHeight,    (bottom + top) * rcpHeight,    0f,
                0f,                       0f,                        (far + near) * rcpdz,          2f * near * far * rcpdz,
                0f,                       0f,                       -1f,                          0f
                );
        }

        /// <summary>   Returns a <see cref="float4x4"/> matrix representing a combined scale-, rotation- and translation transform. Equivalent to mul(translationTransform, mul(rotationTransform, scaleTransform)).    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4x4 TRS(float3 translation, quaternion rotation, float3 scale)
        {
            float3x3 r = new float3x3(rotation);
            return new float4x4(new float4(r.c0 * scale.x, 0f),
                                new float4(r.c1 * scale.y, 0f),
                                new float4(r.c2 * scale.z, 0f),
                                new float4(translation, 1f));
        }
    }
}
