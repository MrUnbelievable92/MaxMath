using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class int3DebuggerProxy
    {
        public int x;
        public int y;
        public int z;
        
        public int3DebuggerProxy(int3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(int3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct int3 : IEquatable<int3>, IEquatable<Unity.Mathematics.int3>, IEquatable<int>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.int3 __x0;
        
        public ref int x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(int3* ptr = &this) { return ref *((int*)ptr +  0); } } }
        public ref int y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(int3* ptr = &this) { return ref *((int*)ptr +  1); } } }
        public ref int z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(int3* ptr = &this) { return ref *((int*)ptr +  2); } } }


        public static int3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(int x, int y, int z)
        {
            __x0 = new Unity.Mathematics.int3(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(int x, int2 yz)
        {
            __x0 = new Unity.Mathematics.int3(x, yz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(int2 xy, int z)
        {
            __x0 = new Unity.Mathematics.int3(xy, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(int3 xyz)
        {
            __x0 = new Unity.Mathematics.int3(xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(int v)
        {
            __x0 = new Unity.Mathematics.int3(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(Unity.Mathematics.int3 xyz)
        {
            __x0 = new Unity.Mathematics.int3(xyz);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(bool v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(bool3 v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(mask8x3 v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(mask16x3 v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(mask32x3 v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(mask64x3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(byte v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(byte3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(sbyte v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(sbyte3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(ushort v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(ushort3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(short v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(short3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(uint v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(uint3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(ulong v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(ulong3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(long v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(long3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(UInt128 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(Int128 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(quarter v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(quarter3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(half v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(half3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(float v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(float3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(double v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(double3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(quadruple v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(Unity.Mathematics.bool3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(Unity.Mathematics.uint3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(Unity.Mathematics.half v)
        {
            this = (int3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(Unity.Mathematics.half3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(Unity.Mathematics.float3 v)
        {
            this = (int3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(Unity.Mathematics.double3 v)
        {
            this = (int3)v;
        }

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(v128 v) => math.asint((uint3)v);

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(int3 v) => math.asuint(v);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(bool3 x) => (int3)(Unity.Mathematics.bool3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(Unity.Mathematics.bool3 x) => new int3 { __x0 = (Unity.Mathematics.int3)x };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int3)(mask32x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int3)(mask32x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi32(x);
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(mask64x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int3)(mask32x3)x;
            }
            else
            {
                return *(int3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(int3 x) => (mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(int3 x) => (mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(int3 x) => (mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(int3 x) => (mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(int3 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(int3 x) => (mask32x3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3(byte x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3(sbyte x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3(ushort x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int3(short x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(ulong x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(long x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(UInt128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(Int128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(quarter x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(quadruple x) => (int)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half3(int3 x) => (half3)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(UnityEngine.Vector3Int v) => new int3 { __x0 = new Unity.Mathematics.int3(v.x, v.y, v.z) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Vector3Int(int3 v) => new UnityEngine.Vector3Int(v.x, v.y, v.z);
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(Unity.Mathematics.int3 v) => new int3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int3(int3 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(Unity.Mathematics.uint3 v) => new int3 { __x0 = (int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(int3 v) => (Unity.Mathematics.uint3)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(Unity.Mathematics.half v) => (int)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(Unity.Mathematics.half3 v) => (int3)(half3)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(Unity.Mathematics.float3 v) => new int3 { __x0 = (Unity.Mathematics.int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(int3 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(Unity.Mathematics.double3 v) => new int3 { __x0 = (Unity.Mathematics.int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(int3 v) => v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(int v) => new int3 { __x0 = (Unity.Mathematics.int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(uint v) => new int3 { __x0 = (Unity.Mathematics.int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(uint3 v) => new int3 { __x0 = (Unity.Mathematics.int3)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(half v) => (int)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(float v) => new int3 { __x0 = (Unity.Mathematics.int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(float3 v) => new int3 { __x0 = (Unity.Mathematics.int3)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(double v) => new int3 { __x0 = (Unity.Mathematics.int3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(double3 v) => new int3 { __x0 = (Unity.Mathematics.int3)v.__x0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 val) => +val.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 val) => -val.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ++ (int3 val) => val.__x0 + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator -- (int3 val) => val.__x0 - 1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, int3 rhs) => lhs.__x0 + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, int rhs) => lhs.__x0 + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int lhs, int3 rhs) => lhs + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, int3 rhs) => lhs.__x0 - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, int rhs) => lhs.__x0 - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int lhs, int3 rhs) => lhs - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, int3 rhs) => lhs.__x0 * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, int rhs) => lhs.__x0 * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int lhs, int3 rhs) => lhs * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, int3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi32(lhs, rhs, 3);
            }
            else
            {
                return lhs.__x0 / rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, int rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(rhs))
                {
                    return Xse.constdiv_epi32(lhs, rhs, 3);
                }

                return Xse.div_epi32(lhs, Xse.set1_epi32(rhs, 3), 3);
            }
            else
            {
                return lhs.__x0 / rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int lhs, int3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi32(Xse.set1_epi32(lhs, 3), rhs, 3);
            }
            else
            {
                return lhs / rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, int3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi32(lhs, rhs, 3);
            }
            else
            {
                return lhs.__x0 % rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, int rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(rhs))
                {
                    return Xse.constrem_epi32(lhs, rhs, 3);
                }

                return Xse.rem_epi32(lhs, Xse.set1_epi32(rhs, 3), 3);
            }
            else
            {
                return lhs.__x0 % rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int lhs, int3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi32(Xse.set1_epi32(lhs, 3), rhs, 3);
            }
            else
            {
                return lhs % rhs.__x0;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, byte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (byte lhs, int3 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, byte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (byte lhs, int3 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, byte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (byte lhs, int3 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, byte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (byte lhs, int3 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, byte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (byte lhs, int3 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, sbyte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (sbyte lhs, int3 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, sbyte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (sbyte lhs, int3 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, sbyte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (sbyte lhs, int3 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, sbyte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (sbyte lhs, int3 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, sbyte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (sbyte lhs, int3 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, short rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (short lhs, int3 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, short rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (short lhs, int3 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, short rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (short lhs, int3 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, short rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (short lhs, int3 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, short rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (short lhs, int3 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, ushort rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (ushort lhs, int3 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, ushort rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (ushort lhs, int3 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, ushort rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (ushort lhs, int3 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, ushort rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (ushort lhs, int3 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, ushort rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (ushort lhs, int3 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, byte3 rhs) => lhs + (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, byte3 rhs) => lhs - (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, byte3 rhs) => lhs * (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, byte3 rhs) => lhs / (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, byte3 rhs) => lhs % (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (byte3 lhs, int3 rhs) => (int3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (byte3 lhs, int3 rhs) => (int3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (byte3 lhs, int3 rhs) => (int3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (byte3 lhs, int3 rhs) => (int3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (byte3 lhs, int3 rhs) => (int3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, sbyte3 rhs) => lhs + (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, sbyte3 rhs) => lhs - (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, sbyte3 rhs) => lhs * (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, sbyte3 rhs) => lhs / (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, sbyte3 rhs) => lhs % (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (sbyte3 lhs, int3 rhs) => (int3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (sbyte3 lhs, int3 rhs) => (int3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (sbyte3 lhs, int3 rhs) => (int3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (sbyte3 lhs, int3 rhs) => (int3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (sbyte3 lhs, int3 rhs) => (int3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, short3 rhs) => lhs + (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, short3 rhs) => lhs - (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, short3 rhs) => lhs * (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, short3 rhs) => lhs / (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, short3 rhs) => lhs % (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (short3 lhs, int3 rhs) => (int3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (short3 lhs, int3 rhs) => (int3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (short3 lhs, int3 rhs) => (int3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (short3 lhs, int3 rhs) => (int3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (short3 lhs, int3 rhs) => (int3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, ushort3 rhs) => lhs + (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, ushort3 rhs) => lhs - (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, ushort3 rhs) => lhs * (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, ushort3 rhs) => lhs / (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, ushort3 rhs) => lhs % (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (ushort3 lhs, int3 rhs) => (int3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (ushort3 lhs, int3 rhs) => (int3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (ushort3 lhs, int3 rhs) => (int3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (ushort3 lhs, int3 rhs) => (int3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (ushort3 lhs, int3 rhs) => (int3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (int3 lhs, Unity.Mathematics.int3 rhs) => lhs + (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (int3 lhs, Unity.Mathematics.int3 rhs) => lhs - (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (int3 lhs, Unity.Mathematics.int3 rhs) => lhs * (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (int3 lhs, Unity.Mathematics.int3 rhs) => lhs / (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (int3 lhs, Unity.Mathematics.int3 rhs) => lhs % (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (int3 lhs, Unity.Mathematics.float3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (int3 lhs, Unity.Mathematics.float3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (int3 lhs, Unity.Mathematics.float3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (int3 lhs, Unity.Mathematics.float3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (int3 lhs, Unity.Mathematics.float3 rhs) => lhs % (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (int3 lhs, Unity.Mathematics.double3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (int3 lhs, Unity.Mathematics.double3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (int3 lhs, Unity.Mathematics.double3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (int3 lhs, Unity.Mathematics.double3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (int3 lhs, Unity.Mathematics.double3 rhs) => lhs % (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator << (int3 lhs, int rhs) => lhs.__x0 << rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator >> (int3 lhs, int rhs) => lhs.__x0 >> rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ~ (int3 v) => ~v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, int3 rhs) => lhs.__x0 & rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, int rhs) => lhs.__x0 & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int lhs, int3 rhs) => lhs & rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, int3 rhs) => lhs.__x0 | rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, int rhs) => lhs.__x0 | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int lhs, int3 rhs) => lhs | rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, int3 rhs) => lhs.__x0 ^ rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, int rhs) => lhs.__x0 ^ rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int lhs, int3 rhs) => lhs ^ rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, byte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (byte lhs, int3 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, byte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (byte lhs, int3 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, byte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (byte lhs, int3 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, sbyte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (sbyte lhs, int3 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, sbyte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (sbyte lhs, int3 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, sbyte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (sbyte lhs, int3 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, short rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (short lhs, int3 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, short rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (short lhs, int3 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, short rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (short lhs, int3 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, ushort rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (ushort lhs, int3 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, ushort rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (ushort lhs, int3 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, ushort rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (ushort lhs, int3 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, byte3 rhs) => lhs & (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, byte3 rhs) => lhs | (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, byte3 rhs) => lhs ^ (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (byte3 lhs, int3 rhs) => (int3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (byte3 lhs, int3 rhs) => (int3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (byte3 lhs, int3 rhs) => (int3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, sbyte3 rhs) => lhs & (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, sbyte3 rhs) => lhs | (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, sbyte3 rhs) => lhs ^ (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (sbyte3 lhs, int3 rhs) => (int3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (sbyte3 lhs, int3 rhs) => (int3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (sbyte3 lhs, int3 rhs) => (int3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, short3 rhs) => lhs & (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, short3 rhs) => lhs | (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, short3 rhs) => lhs ^ (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (short3 lhs, int3 rhs) => (int3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (short3 lhs, int3 rhs) => (int3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (short3 lhs, int3 rhs) => (int3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, ushort3 rhs) => lhs & (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, ushort3 rhs) => lhs | (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, ushort3 rhs) => lhs ^ (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (ushort3 lhs, int3 rhs) => (int3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (ushort3 lhs, int3 rhs) => (int3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (ushort3 lhs, int3 rhs) => (int3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (int3 lhs, Unity.Mathematics.int3 rhs) => lhs & (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (int3 lhs, Unity.Mathematics.int3 rhs) => lhs | (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (int3 lhs, Unity.Mathematics.int3 rhs) => lhs ^ (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, int3 rhs) => (uint3)lhs == (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, int rhs) => lhs == (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int lhs, int3 rhs) => (int3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, int3 rhs) => (uint3)lhs != (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, int rhs) => lhs != (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int lhs, int3 rhs) => (int3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, int3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epi32(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, int rhs) => lhs < (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int lhs, int3 rhs) => (int3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, int3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epi32(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, int rhs) => lhs > (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int lhs, int3 rhs) => (int3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, int3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpgt_epi32(lhs, rhs));
            }
            else
            {
                return new mask32x3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, int rhs) => lhs <= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int lhs, int3 rhs) => (int3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, int3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmplt_epi32(lhs, rhs));
            }
            else
            {
                return new mask32x3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, int rhs) => lhs >= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int lhs, int3 rhs) => (int3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, byte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (byte lhs, int3 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, byte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (byte lhs, int3 rhs) => (int)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, byte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (byte lhs, int3 rhs) => (int)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, byte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (byte lhs, int3 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, byte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (byte lhs, int3 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, byte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (byte lhs, int3 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, sbyte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (sbyte lhs, int3 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, sbyte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (sbyte lhs, int3 rhs) => (int)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, sbyte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (sbyte lhs, int3 rhs) => (int)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, sbyte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (sbyte lhs, int3 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, sbyte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (sbyte lhs, int3 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, sbyte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (sbyte lhs, int3 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, short rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (short lhs, int3 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, short rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (short lhs, int3 rhs) => (int)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, short rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (short lhs, int3 rhs) => (int)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, short rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (short lhs, int3 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, short rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (short lhs, int3 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, short rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (short lhs, int3 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, ushort rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (ushort lhs, int3 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, ushort rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (ushort lhs, int3 rhs) => (int)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, ushort rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (ushort lhs, int3 rhs) => (int)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, ushort rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (ushort lhs, int3 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, ushort rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (ushort lhs, int3 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, ushort rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (ushort lhs, int3 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, byte3 rhs) => lhs == (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, byte3 rhs) => lhs != (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, byte3 rhs) => lhs < (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, byte3 rhs) => lhs > (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, byte3 rhs) => lhs <= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, byte3 rhs) => lhs >= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (byte3 lhs, int3 rhs) => (int3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (byte3 lhs, int3 rhs) => (int3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (byte3 lhs, int3 rhs) => (int3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (byte3 lhs, int3 rhs) => (int3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (byte3 lhs, int3 rhs) => (int3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (byte3 lhs, int3 rhs) => (int3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, sbyte3 rhs) => lhs == (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, sbyte3 rhs) => lhs != (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, sbyte3 rhs) => lhs < (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, sbyte3 rhs) => lhs > (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, sbyte3 rhs) => lhs <= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, sbyte3 rhs) => lhs >= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (sbyte3 lhs, int3 rhs) => (int3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (sbyte3 lhs, int3 rhs) => (int3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (sbyte3 lhs, int3 rhs) => (int3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (sbyte3 lhs, int3 rhs) => (int3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (sbyte3 lhs, int3 rhs) => (int3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (sbyte3 lhs, int3 rhs) => (int3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, short3 rhs) => lhs == (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, short3 rhs) => lhs != (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, short3 rhs) => lhs < (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, short3 rhs) => lhs > (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, short3 rhs) => lhs <= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, short3 rhs) => lhs >= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (short3 lhs, int3 rhs) => (int3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (short3 lhs, int3 rhs) => (int3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (short3 lhs, int3 rhs) => (int3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (short3 lhs, int3 rhs) => (int3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (short3 lhs, int3 rhs) => (int3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (short3 lhs, int3 rhs) => (int3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, ushort3 rhs) => lhs == (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, ushort3 rhs) => lhs != (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, ushort3 rhs) => lhs < (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, ushort3 rhs) => lhs > (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, ushort3 rhs) => lhs <= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, ushort3 rhs) => lhs >= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (ushort3 lhs, int3 rhs) => (int3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (ushort3 lhs, int3 rhs) => (int3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (ushort3 lhs, int3 rhs) => (int3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (ushort3 lhs, int3 rhs) => (int3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (ushort3 lhs, int3 rhs) => (int3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (ushort3 lhs, int3 rhs) => (int3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, Unity.Mathematics.int3 rhs) => lhs == (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, Unity.Mathematics.int3 rhs) => lhs != (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, Unity.Mathematics.int3 rhs) => lhs < (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, Unity.Mathematics.int3 rhs) => lhs > (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, Unity.Mathematics.int3 rhs) => lhs <= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, Unity.Mathematics.int3 rhs) => lhs >= (int3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.int3 lhs, int3 rhs) => (int3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, Unity.Mathematics.float3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, Unity.Mathematics.float3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, Unity.Mathematics.float3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, Unity.Mathematics.float3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, Unity.Mathematics.float3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, Unity.Mathematics.float3 rhs) => lhs >= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.float3 lhs, int3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (int3 lhs, Unity.Mathematics.double3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (int3 lhs, Unity.Mathematics.double3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (int3 lhs, Unity.Mathematics.double3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (int3 lhs, Unity.Mathematics.double3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (int3 lhs, Unity.Mathematics.double3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (int3 lhs, Unity.Mathematics.double3 rhs) => lhs >= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.double3 lhs, int3 rhs) => (double3)lhs >= rhs;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int3 xyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public int2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly int2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zz; }
        }


        public int this[int index]
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
        public readonly bool Equals(int other) => __x0.Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(int3 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.int3 other) => __x0.Equals(other);
        
        public override readonly bool Equals(object o) => (o is int3 converted && Equals(converted)) || (o is Unity.Mathematics.int3 convertedU && Equals(convertedU)) || (o is int convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => __x0.ToString(format, formatProvider);
    }
}
