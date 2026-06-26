using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class float3DebuggerProxy
    {
        public float x;
        public float y;
        public float z;
        
        public float3DebuggerProxy(float3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(float3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct float3 : IEquatable<float3>, IEquatable<Unity.Mathematics.float3>, IEquatable<float>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.float3 __x0;
        
        public ref float x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float3* ptr = &this) { return ref *((float*)ptr +  0); } } }
        public ref float y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float3* ptr = &this) { return ref *((float*)ptr +  1); } } }
        public ref float z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(float3* ptr = &this) { return ref *((float*)ptr +  2); } } }


        public static float3 zero => default;
        
        /// <summary>   Unity's up axis (0, 1, 0).  </summary>
        public static float3 Up => new float3(0f, 1f, 0f);

        /// <summary>   Unity's down axis (0, -1, 0).   </summary>
        public static float3 Down => new float3(0f, -1f, 0f);

        /// <summary>   Unity's forward axis (0, 0, 1).     </summary>
        public static float3 Forward => new float3(0f, 0f, 1f);

        /// <summary>   Unity's back axis (0, 0, -1).   </summary>
        public static float3 Back => new float3(0f, 0f, -1f);

        /// <summary>   Unity's left axis (-1, 0, 0).   </summary>
        public static float3 Left => new float3(-1f, 0f, 0f);

        /// <summary>   Unity's right axis (1, 0, 0).   </summary>
        public static float3 Right => new float3(1f, 0f, 0f);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(float x, float y, float z)
        {
            __x0 = new Unity.Mathematics.float3(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(float x, float2 yz)
        {
            __x0 = new Unity.Mathematics.float3(x, yz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(float2 xy, float z)
        {
            __x0 = new Unity.Mathematics.float3(xy, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(float3 xyz)
        {
            __x0 = new Unity.Mathematics.float3(xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(float v)
        {
            __x0 = new Unity.Mathematics.float3(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(Unity.Mathematics.float3 xyz)
        {
            __x0 = new Unity.Mathematics.float3(xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(bool v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(bool3 v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(mask8x3 v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(mask16x3 v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(mask32x3 v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(mask64x3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(byte v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(byte3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(sbyte v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(sbyte3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(ushort v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(ushort3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(short v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(short3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(uint v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(uint3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(int v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(int3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(ulong v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(ulong3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(long v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(long3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(UInt128 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(Int128 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(quarter v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(quarter3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(half v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(half3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(double v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(double3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(quadruple v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(Unity.Mathematics.bool3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(Unity.Mathematics.uint3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(Unity.Mathematics.int3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(Unity.Mathematics.half v)
        {
            this = (float3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(Unity.Mathematics.half3 v)
        {
            this = (float3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(Unity.Mathematics.double3 v)
        {
            this = (float3)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(v128 v) => math.asfloat((uint3)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(float3 v) => math.asuint(v);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(bool x) => (float3)(mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(bool3 x) => (float3)(mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(Unity.Mathematics.bool3 x) => (float3)(mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float3)(mask32x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float3)(mask32x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_ps(x, Xse.set1_ps(1));
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(mask64x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (float3)(mask32x3)x;
            }
            else
            {
                return *(float3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(float3 x) => (Unity.Mathematics.bool3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(float3 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(float3 x) => (mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(float3 x) => (mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(float3 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(float3 x) => (mask32x3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float3(byte x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float3(sbyte x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float3(ushort x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator float3(short x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(ulong x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(long x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(UInt128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(Int128 x) => (float)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(quadruple x) => (float)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(UnityEngine.Vector3 v) => new float3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Vector3(float3 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(Unity.Mathematics.float3 v) => new float3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(float3 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(Unity.Mathematics.int3 v) => new float3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(float3 v) => (Unity.Mathematics.int3)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(Unity.Mathematics.uint3 v) => new float3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(float3 v) => (Unity.Mathematics.uint3)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(Unity.Mathematics.half v) => (half)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(Unity.Mathematics.half3 v) => (half3)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half3(float3 v) => (half3)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(Unity.Mathematics.double3 v) => new float3 { __x0 = (Unity.Mathematics.float3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(float3 v) => v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(float v) => new float3 { __x0 = (Unity.Mathematics.float3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(int v) => new float3 { __x0 = (Unity.Mathematics.float3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(int3 v) => new float3 { __x0 = (Unity.Mathematics.float3)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(uint v) => new float3 { __x0 = (Unity.Mathematics.float3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(uint3 v) => new float3 { __x0 = (Unity.Mathematics.float3)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(half v) => (float)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(double v) => new float3 { __x0 = (Unity.Mathematics.float3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(double3 v) => new float3 { __x0 = (Unity.Mathematics.float3)v.__x0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 val) => +val.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 val) => -val.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator ++ (float3 val) => val.__x0 + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator -- (float3 val) => val.__x0 - 1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, float3 rhs) => lhs.__x0 + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, float rhs) => lhs.__x0 + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float lhs, float3 rhs) => lhs + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, float3 rhs) => lhs.__x0 - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, float rhs) => lhs.__x0 - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float lhs, float3 rhs) => lhs - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, float3 rhs) => lhs.__x0 * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, float rhs) => lhs.__x0 * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float lhs, float3 rhs) => lhs * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, float3 rhs) => lhs.__x0 / rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, float rhs) => lhs.__x0 / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float lhs, float3 rhs) => lhs / rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, float3 rhs) => lhs.__x0 % rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, float rhs) => lhs.__x0 % rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float lhs, float3 rhs) => lhs % rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, Unity.Mathematics.float3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, Unity.Mathematics.float3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, Unity.Mathematics.float3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, Unity.Mathematics.float3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, Unity.Mathematics.float3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (float3 lhs, Unity.Mathematics.double3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (float3 lhs, Unity.Mathematics.double3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (float3 lhs, Unity.Mathematics.double3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (float3 lhs, Unity.Mathematics.double3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (float3 lhs, Unity.Mathematics.double3 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, quarter rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, quarter rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, quarter rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, quarter rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, quarter rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (quarter lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (quarter lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (quarter lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (quarter lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (quarter lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, quarter3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, quarter3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, quarter3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, quarter3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, quarter3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (quarter3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (quarter3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (quarter3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (quarter3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (quarter3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, half rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, half rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, half rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, half rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, half rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (half lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (half lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (half lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (half lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (half lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, half3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, half3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, half3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, half3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, half3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (half3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (half3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (half3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (half3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (half3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, Unity.Mathematics.half rhs) => lhs + (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, Unity.Mathematics.half rhs) => lhs - (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, Unity.Mathematics.half rhs) => lhs * (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, Unity.Mathematics.half rhs) => lhs / (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, Unity.Mathematics.half rhs) => lhs % (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, Unity.Mathematics.half3 rhs) => lhs + (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, Unity.Mathematics.half3 rhs) => lhs - (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, Unity.Mathematics.half3 rhs) => lhs * (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, Unity.Mathematics.half3 rhs) => lhs / (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, Unity.Mathematics.half3 rhs) => lhs % (half3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, byte3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, byte3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, byte3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, byte3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, byte3 rhs) => lhs % (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (byte3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (byte3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (byte3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (byte3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (byte3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, sbyte3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, sbyte3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, sbyte3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, sbyte3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, sbyte3 rhs) => lhs % (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (sbyte3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (sbyte3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (sbyte3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (sbyte3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (sbyte3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, short3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, short3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, short3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, short3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, short3 rhs) => lhs % (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (short3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (short3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (short3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (short3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (short3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, ushort3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, ushort3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, ushort3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, ushort3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, ushort3 rhs) => lhs % (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (ushort3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (ushort3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (ushort3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (ushort3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (ushort3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, int3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, int3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, int3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, int3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, int3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (int3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (int3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (int3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (int3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (int3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, uint3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, uint3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, uint3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, uint3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, uint3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (uint3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (uint3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (uint3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (uint3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (uint3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, long3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, long3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, long3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, long3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, long3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (long3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (long3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (long3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (long3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (long3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, ulong3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, ulong3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, ulong3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, ulong3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, ulong3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (ulong3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (ulong3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (ulong3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (ulong3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (ulong3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, Unity.Mathematics.int3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, Unity.Mathematics.int3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, Unity.Mathematics.int3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, Unity.Mathematics.int3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, Unity.Mathematics.int3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, byte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (byte lhs, float3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, byte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (byte lhs, float3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, byte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (byte lhs, float3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, byte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (byte lhs, float3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, byte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (byte lhs, float3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, sbyte rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (sbyte lhs, float3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, sbyte rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (sbyte lhs, float3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, sbyte rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (sbyte lhs, float3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, sbyte rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (sbyte lhs, float3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, sbyte rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (sbyte lhs, float3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, short rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (short lhs, float3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, short rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (short lhs, float3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, short rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (short lhs, float3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, short rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (short lhs, float3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, short rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (short lhs, float3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, ushort rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (ushort lhs, float3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, ushort rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (ushort lhs, float3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, ushort rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (ushort lhs, float3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, ushort rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (ushort lhs, float3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, ushort rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (ushort lhs, float3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, int rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (int lhs, float3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, int rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (int lhs, float3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, int rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (int lhs, float3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, int rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (int lhs, float3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, int rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (int lhs, float3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, uint rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (uint lhs, float3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, uint rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (uint lhs, float3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, uint rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (uint lhs, float3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, uint rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (uint lhs, float3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, uint rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (uint lhs, float3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, long rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (long lhs, float3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, long rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (long lhs, float3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, long rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (long lhs, float3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, long rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (long lhs, float3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, long rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (long lhs, float3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, ulong rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (ulong lhs, float3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, ulong rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (ulong lhs, float3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, ulong rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (ulong lhs, float3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, ulong rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (ulong lhs, float3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, ulong rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (ulong lhs, float3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, Int128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Int128 lhs, float3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, Int128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Int128 lhs, float3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, Int128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Int128 lhs, float3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, Int128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Int128 lhs, float3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, Int128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Int128 lhs, float3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (float3 lhs, UInt128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (UInt128 lhs, float3 rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (float3 lhs, UInt128 rhs) => lhs - (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (UInt128 lhs, float3 rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (float3 lhs, UInt128 rhs) => lhs * (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (UInt128 lhs, float3 rhs) => (float)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (float3 lhs, UInt128 rhs) => lhs / (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (UInt128 lhs, float3 rhs) => (float)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (float3 lhs, UInt128 rhs) => lhs % (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (UInt128 lhs, float3 rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, float3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_ps(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, float rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, float3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_ps(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, float rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, float3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_ps(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, float rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, float3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_ps(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, float rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, float3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_ps(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, float rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, float3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_ps(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, float rhs) => lhs >= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, Unity.Mathematics.float3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, Unity.Mathematics.float3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, Unity.Mathematics.float3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, Unity.Mathematics.float3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, Unity.Mathematics.float3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, Unity.Mathematics.float3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.float3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, Unity.Mathematics.double3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, Unity.Mathematics.double3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, Unity.Mathematics.double3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, Unity.Mathematics.double3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, Unity.Mathematics.double3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, Unity.Mathematics.double3 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.double3 lhs, float3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, quarter rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, quarter rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, quarter rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, quarter rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, quarter rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, quarter rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (quarter lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (quarter lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (quarter lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (quarter lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (quarter lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (quarter lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, quarter3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, quarter3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, quarter3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, quarter3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, quarter3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, quarter3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (quarter3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (quarter3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (quarter3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (quarter3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (quarter3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (quarter3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, half rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, half rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, half rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, half rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, half rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, half rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (half lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (half lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (half lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (half lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (half lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (half lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, half3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, half3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, half3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, half3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, half3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, half3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (half3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (half3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (half3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (half3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (half3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (half3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, Unity.Mathematics.half rhs) => lhs == (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, Unity.Mathematics.half rhs) => lhs != (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, Unity.Mathematics.half rhs) => lhs < (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, Unity.Mathematics.half rhs) => lhs > (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, Unity.Mathematics.half rhs) => lhs <= (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, Unity.Mathematics.half rhs) => lhs >= (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.half lhs, float3 rhs) => (half)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, Unity.Mathematics.half3 rhs) => lhs == (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, Unity.Mathematics.half3 rhs) => lhs != (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, Unity.Mathematics.half3 rhs) => lhs < (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, Unity.Mathematics.half3 rhs) => lhs > (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, Unity.Mathematics.half3 rhs) => lhs <= (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, Unity.Mathematics.half3 rhs) => lhs >= (half3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.half3 lhs, float3 rhs) => (half3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, byte3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, byte3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, byte3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, byte3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, byte3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, byte3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (byte3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (byte3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (byte3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (byte3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (byte3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (byte3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, sbyte3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, sbyte3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, sbyte3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, sbyte3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, sbyte3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, sbyte3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (sbyte3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (sbyte3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (sbyte3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (sbyte3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (sbyte3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (sbyte3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, ushort3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, ushort3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, ushort3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, ushort3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, ushort3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, ushort3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (ushort3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (ushort3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (ushort3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (ushort3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (ushort3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (ushort3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, short3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, short3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, short3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, short3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, short3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, short3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (short3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (short3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (short3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (short3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (short3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (short3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, int3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, int3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, int3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, int3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, int3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, int3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, uint3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, uint3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, uint3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, uint3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, uint3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, uint3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, Unity.Mathematics.int3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, Unity.Mathematics.int3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, Unity.Mathematics.int3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, Unity.Mathematics.int3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, Unity.Mathematics.int3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, Unity.Mathematics.int3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.int3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, Unity.Mathematics.uint3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.uint3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, long3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, long3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, long3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, long3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, long3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, long3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (long3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (long3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (long3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (long3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (long3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (long3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, ulong3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, ulong3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, ulong3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, ulong3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, ulong3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, ulong3 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (ulong3 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (ulong3 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (ulong3 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (ulong3 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (ulong3 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (ulong3 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, byte rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, byte rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, byte rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, byte rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, byte rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, byte rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (byte lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (byte lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (byte lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (byte lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (byte lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (byte lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, sbyte rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, sbyte rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, sbyte rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, sbyte rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, sbyte rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, sbyte rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (sbyte lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (sbyte lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (sbyte lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (sbyte lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (sbyte lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (sbyte lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, ushort rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, ushort rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, ushort rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, ushort rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, ushort rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, ushort rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (ushort lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (ushort lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (ushort lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (ushort lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (ushort lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (ushort lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, short rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, short rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, short rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, short rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, short rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, short rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (short lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (short lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (short lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (short lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (short lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (short lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, int rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, int rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, int rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, int rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, int rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, int rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, uint rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, uint rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, uint rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, uint rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, uint rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, uint rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, long rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, long rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, long rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, long rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, long rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, long rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (long lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (long lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (long lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (long lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (long lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (long lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, ulong rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, ulong rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, ulong rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, ulong rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, ulong rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, ulong rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (ulong lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (ulong lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (ulong lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (ulong lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (ulong lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (ulong lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, Int128 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, Int128 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, Int128 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, Int128 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, Int128 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, Int128 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Int128 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Int128 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Int128 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Int128 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Int128 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Int128 lhs, float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (float3 lhs, UInt128 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (float3 lhs, UInt128 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (float3 lhs, UInt128 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (float3 lhs, UInt128 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (float3 lhs, UInt128 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (float3 lhs, UInt128 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (UInt128 lhs, float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (UInt128 lhs, float3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (UInt128 lhs, float3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (UInt128 lhs, float3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (UInt128 lhs, float3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (UInt128 lhs, float3 rhs) => (float3)lhs >= rhs;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 xyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public float2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly float2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zz; }
        }


        public float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return __x0[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                __x0[index] = value;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float other) => __x0.Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(float3 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.float3 other) => __x0.Equals(other);
        
        public override readonly bool Equals(object o) => (o is float3 converted && Equals(converted)) || (o is Unity.Mathematics.float3 convertedU && Equals(convertedU)) || (o is float convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => __x0.ToString(format, formatProvider);
    }
}
