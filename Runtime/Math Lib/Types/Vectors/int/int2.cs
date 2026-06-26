using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class int2DebuggerProxy
    {
        public int x;
        public int y;

        public int2DebuggerProxy(int2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(int2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct int2 : IEquatable<int2>, IEquatable<Unity.Mathematics.int2>, IEquatable<int>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.int2 __x0;
        
        public ref int x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(int2* ptr = &this) { return ref *((int*)ptr +  0); } } }
        public ref int y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(int2* ptr = &this) { return ref *((int*)ptr +  1); } } }


        public static int2 zero => default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(int x, int y)
        {
            __x0 = new Unity.Mathematics.int2(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(int2 xy)
        {
            __x0 = new Unity.Mathematics.int2(xy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(int v)
        {
            __x0 = new Unity.Mathematics.int2(v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(Unity.Mathematics.int2 xy)
        {
            __x0 = xy;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(bool v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(bool2 v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(mask8x2 v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(mask16x2 v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(mask32x2 v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(mask64x2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(byte v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(byte2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(sbyte v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(sbyte2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(ushort v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(ushort2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(short v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(short2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(uint v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(uint2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(ulong v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(ulong2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(long v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(long2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(UInt128 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(Int128 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(quarter v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(quarter2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(half v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(half2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(float v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(float2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(double v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(double2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(quadruple v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(Unity.Mathematics.bool2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(Unity.Mathematics.uint2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(Unity.Mathematics.half v)
        {
            this = (int2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(Unity.Mathematics.half2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(Unity.Mathematics.float2 v)
        {
            this = (int2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int2(Unity.Mathematics.double2 v)
        {
            this = (int2)v;
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(v128 v) => math.asint((uint2)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(int2 v) => math.asuint(v);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(bool2 x) => (int2)(Unity.Mathematics.bool2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Unity.Mathematics.bool2 x) => new int2 { __x0 = (Unity.Mathematics.int2)x };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int2)(mask32x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int2)(mask32x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi32(x);
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (int2)(mask32x2)x;
            }
            else
            {
                return *(int2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(int2 x) => (mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(int2 x) => (mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(int2 x) => (mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(int2 x) => (mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(int2 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(int2 x) => (mask32x2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2(byte x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2(sbyte x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2(ushort x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator int2(short x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(ulong x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(long x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(UInt128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Int128 x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(quarter x) => (int)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(quadruple x) => (int)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half2(int2 x) => (half2)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(UnityEngine.Vector2Int v) => new int2 { __x0 = new Unity.Mathematics.int2(v.x, v.y) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnityEngine.Vector2Int(int2 v) => new UnityEngine.Vector2Int(v.x, v.y);
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(Unity.Mathematics.int2 v) => new int2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int2(int2 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Unity.Mathematics.uint2 v) => new int2 { __x0 = (int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(int2 v) => (Unity.Mathematics.uint2)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Unity.Mathematics.half v) => (int)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Unity.Mathematics.half2 v) => (int2)(half2)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Unity.Mathematics.float2 v) => new int2 { __x0 = (Unity.Mathematics.int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(int2 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Unity.Mathematics.double2 v) => new int2 { __x0 = (Unity.Mathematics.int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(int2 v) => v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(int v) => new int2 { __x0 = (Unity.Mathematics.int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(uint v) => new int2 { __x0 = (Unity.Mathematics.int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(uint2 v) => new int2 { __x0 = (Unity.Mathematics.int2)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(half v) => (int)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(float v) => new int2 { __x0 = (Unity.Mathematics.int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(float2 v) => new int2 { __x0 = (Unity.Mathematics.int2)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(double v) => new int2 { __x0 = (Unity.Mathematics.int2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(double2 v) => new int2 { __x0 = (Unity.Mathematics.int2)v.__x0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 val) => +val.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 val) => -val.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ++ (int2 val) => val.__x0 + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator -- (int2 val) => val.__x0 - 1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, int2 rhs) => lhs.__x0 + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, int rhs) => lhs.__x0 + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int lhs, int2 rhs) => lhs + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, int2 rhs) => lhs.__x0 - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, int rhs) => lhs.__x0 - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int lhs, int2 rhs) => lhs - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, int2 rhs) => lhs.__x0 * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, int rhs) => lhs.__x0 * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int lhs, int2 rhs) => lhs * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, int2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi32(lhs, rhs, 2);
            }
            else
            {
                return lhs.__x0 / rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, int rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(rhs))
                {
                    return Xse.constdiv_epi32(lhs, rhs, 2);
                }

                return Xse.div_epi32(lhs, Xse.set1_epi32(rhs, 2), 2);
            }
            else
            {
                return lhs.__x0 / rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int lhs, int2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi32(Xse.set1_epi32(lhs, 2), rhs, 2);
            }
            else
            {
                return lhs / rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, int2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi32(lhs, rhs, 2);
            }
            else
            {
                return lhs.__x0 % rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, int rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(rhs))
                {
                    return Xse.constrem_epi32(lhs, rhs, 2);
                }

                return Xse.rem_epi32(lhs, Xse.set1_epi32(rhs, 2), 2);
            }
            else
            {
                return lhs.__x0 % rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int lhs, int2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi32(Xse.set1_epi32(lhs, 2), rhs, 2);
            }
            else
            {
                return lhs % rhs.__x0;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, byte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (byte lhs, int2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, byte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (byte lhs, int2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, byte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (byte lhs, int2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, byte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (byte lhs, int2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, byte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (byte lhs, int2 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, sbyte rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (sbyte lhs, int2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, sbyte rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (sbyte lhs, int2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, sbyte rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (sbyte lhs, int2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, sbyte rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (sbyte lhs, int2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, sbyte rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (sbyte lhs, int2 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, short rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (short lhs, int2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, short rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (short lhs, int2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, short rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (short lhs, int2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, short rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (short lhs, int2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, short rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (short lhs, int2 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, ushort rhs) => lhs + (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (ushort lhs, int2 rhs) => (int)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, ushort rhs) => lhs - (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (ushort lhs, int2 rhs) => (int)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, ushort rhs) => lhs * (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (ushort lhs, int2 rhs) => (int)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, ushort rhs) => lhs / (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (ushort lhs, int2 rhs) => (int)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, ushort rhs) => lhs % (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (ushort lhs, int2 rhs) => (int)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, byte2 rhs) => lhs + (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, byte2 rhs) => lhs - (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, byte2 rhs) => lhs * (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, byte2 rhs) => lhs / (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, byte2 rhs) => lhs % (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (byte2 lhs, int2 rhs) => (int2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (byte2 lhs, int2 rhs) => (int2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (byte2 lhs, int2 rhs) => (int2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (byte2 lhs, int2 rhs) => (int2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (byte2 lhs, int2 rhs) => (int2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, sbyte2 rhs) => lhs + (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, sbyte2 rhs) => lhs - (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, sbyte2 rhs) => lhs * (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, sbyte2 rhs) => lhs / (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, sbyte2 rhs) => lhs % (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (sbyte2 lhs, int2 rhs) => (int2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (sbyte2 lhs, int2 rhs) => (int2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (sbyte2 lhs, int2 rhs) => (int2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (sbyte2 lhs, int2 rhs) => (int2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (sbyte2 lhs, int2 rhs) => (int2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, short2 rhs) => lhs + (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, short2 rhs) => lhs - (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, short2 rhs) => lhs * (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, short2 rhs) => lhs / (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, short2 rhs) => lhs % (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (short2 lhs, int2 rhs) => (int2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (short2 lhs, int2 rhs) => (int2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (short2 lhs, int2 rhs) => (int2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (short2 lhs, int2 rhs) => (int2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (short2 lhs, int2 rhs) => (int2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, ushort2 rhs) => lhs + (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, ushort2 rhs) => lhs - (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, ushort2 rhs) => lhs * (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, ushort2 rhs) => lhs / (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, ushort2 rhs) => lhs % (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (ushort2 lhs, int2 rhs) => (int2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (ushort2 lhs, int2 rhs) => (int2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (ushort2 lhs, int2 rhs) => (int2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (ushort2 lhs, int2 rhs) => (int2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (ushort2 lhs, int2 rhs) => (int2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (int2 lhs, Unity.Mathematics.int2 rhs) => lhs + (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (int2 lhs, Unity.Mathematics.int2 rhs) => lhs - (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (int2 lhs, Unity.Mathematics.int2 rhs) => lhs * (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (int2 lhs, Unity.Mathematics.int2 rhs) => lhs / (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (int2 lhs, Unity.Mathematics.int2 rhs) => lhs % (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator + (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator - (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator * (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator / (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator % (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (int2 lhs, Unity.Mathematics.float2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (int2 lhs, Unity.Mathematics.float2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (int2 lhs, Unity.Mathematics.float2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (int2 lhs, Unity.Mathematics.float2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (int2 lhs, Unity.Mathematics.float2 rhs) => lhs % (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (int2 lhs, Unity.Mathematics.double2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (int2 lhs, Unity.Mathematics.double2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (int2 lhs, Unity.Mathematics.double2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (int2 lhs, Unity.Mathematics.double2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (int2 lhs, Unity.Mathematics.double2 rhs) => lhs % (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator << (int2 lhs, int rhs) => lhs.__x0 << rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator >> (int2 lhs, int rhs) => lhs.__x0 >> rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ~ (int2 v) => ~v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, int2 rhs) => lhs.__x0 & rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, int rhs) => lhs.__x0 & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int lhs, int2 rhs) => lhs & rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, int2 rhs) => lhs.__x0 | rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, int rhs) => lhs.__x0 | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int lhs, int2 rhs) => lhs | rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, int2 rhs) => lhs.__x0 ^ rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, int rhs) => lhs.__x0 ^ rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int lhs, int2 rhs) => lhs ^ rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, byte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (byte lhs, int2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, byte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (byte lhs, int2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, byte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (byte lhs, int2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, sbyte rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (sbyte lhs, int2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, sbyte rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (sbyte lhs, int2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, sbyte rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (sbyte lhs, int2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, short rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (short lhs, int2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, short rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (short lhs, int2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, short rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (short lhs, int2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, ushort rhs) => lhs & (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (ushort lhs, int2 rhs) => (int)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, ushort rhs) => lhs | (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (ushort lhs, int2 rhs) => (int)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, ushort rhs) => lhs ^ (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (ushort lhs, int2 rhs) => (int)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, byte2 rhs) => lhs & (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, byte2 rhs) => lhs | (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, byte2 rhs) => lhs ^ (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (byte2 lhs, int2 rhs) => (int2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (byte2 lhs, int2 rhs) => (int2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (byte2 lhs, int2 rhs) => (int2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, sbyte2 rhs) => lhs & (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, sbyte2 rhs) => lhs | (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, sbyte2 rhs) => lhs ^ (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (sbyte2 lhs, int2 rhs) => (int2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (sbyte2 lhs, int2 rhs) => (int2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (sbyte2 lhs, int2 rhs) => (int2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, short2 rhs) => lhs & (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, short2 rhs) => lhs | (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, short2 rhs) => lhs ^ (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (short2 lhs, int2 rhs) => (int2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (short2 lhs, int2 rhs) => (int2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (short2 lhs, int2 rhs) => (int2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, ushort2 rhs) => lhs & (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, ushort2 rhs) => lhs | (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, ushort2 rhs) => lhs ^ (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (ushort2 lhs, int2 rhs) => (int2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (ushort2 lhs, int2 rhs) => (int2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (ushort2 lhs, int2 rhs) => (int2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (int2 lhs, Unity.Mathematics.int2 rhs) => lhs & (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (int2 lhs, Unity.Mathematics.int2 rhs) => lhs | (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (int2 lhs, Unity.Mathematics.int2 rhs) => lhs ^ (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator & (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator | (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 operator ^ (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, int2 rhs) => (uint2)lhs == (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, int rhs) => lhs == (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int lhs, int2 rhs) => (int2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, int2 rhs) => (uint2)lhs != (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, int rhs) => lhs != (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int lhs, int2 rhs) => (int2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, int2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epi32(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x < rhs.x, lhs.y < rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, int rhs) => lhs < (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int lhs, int2 rhs) => (int2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, int2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epi32(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x > rhs.x, lhs.y > rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, int rhs) => lhs > (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int lhs, int2 rhs) => (int2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, int2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpgt_epi32(lhs, rhs));
            }
            else
            {
                return new mask32x2(lhs.x <= rhs.x, lhs.y <= rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, int rhs) => lhs <= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int lhs, int2 rhs) => (int2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, int2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmplt_epi32(lhs, rhs));
            }
            else
            {
                return new mask32x2(lhs.x >= rhs.x, lhs.y >= rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, int rhs) => lhs >= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int lhs, int2 rhs) => (int2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, byte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (byte lhs, int2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, byte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (byte lhs, int2 rhs) => (int)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, byte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (byte lhs, int2 rhs) => (int)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, byte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (byte lhs, int2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, byte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (byte lhs, int2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, byte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (byte lhs, int2 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, sbyte rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (sbyte lhs, int2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, sbyte rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (sbyte lhs, int2 rhs) => (int)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, sbyte rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (sbyte lhs, int2 rhs) => (int)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, sbyte rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (sbyte lhs, int2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, sbyte rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (sbyte lhs, int2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, sbyte rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (sbyte lhs, int2 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, short rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (short lhs, int2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, short rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (short lhs, int2 rhs) => (int)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, short rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (short lhs, int2 rhs) => (int)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, short rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (short lhs, int2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, short rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (short lhs, int2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, short rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (short lhs, int2 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, ushort rhs) => lhs == (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (ushort lhs, int2 rhs) => (int)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, ushort rhs) => lhs != (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (ushort lhs, int2 rhs) => (int)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, ushort rhs) => lhs < (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (ushort lhs, int2 rhs) => (int)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, ushort rhs) => lhs > (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (ushort lhs, int2 rhs) => (int)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, ushort rhs) => lhs <= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (ushort lhs, int2 rhs) => (int)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, ushort rhs) => lhs >= (int)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (ushort lhs, int2 rhs) => (int)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, byte2 rhs) => lhs == (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, byte2 rhs) => lhs != (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, byte2 rhs) => lhs < (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, byte2 rhs) => lhs > (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, byte2 rhs) => lhs <= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, byte2 rhs) => lhs >= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (byte2 lhs, int2 rhs) => (int2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (byte2 lhs, int2 rhs) => (int2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (byte2 lhs, int2 rhs) => (int2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (byte2 lhs, int2 rhs) => (int2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (byte2 lhs, int2 rhs) => (int2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (byte2 lhs, int2 rhs) => (int2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, sbyte2 rhs) => lhs == (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, sbyte2 rhs) => lhs != (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, sbyte2 rhs) => lhs < (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, sbyte2 rhs) => lhs > (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, sbyte2 rhs) => lhs <= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, sbyte2 rhs) => lhs >= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (sbyte2 lhs, int2 rhs) => (int2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (sbyte2 lhs, int2 rhs) => (int2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (sbyte2 lhs, int2 rhs) => (int2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (sbyte2 lhs, int2 rhs) => (int2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (sbyte2 lhs, int2 rhs) => (int2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (sbyte2 lhs, int2 rhs) => (int2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, short2 rhs) => lhs == (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, short2 rhs) => lhs != (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, short2 rhs) => lhs < (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, short2 rhs) => lhs > (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, short2 rhs) => lhs <= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, short2 rhs) => lhs >= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (short2 lhs, int2 rhs) => (int2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (short2 lhs, int2 rhs) => (int2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (short2 lhs, int2 rhs) => (int2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (short2 lhs, int2 rhs) => (int2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (short2 lhs, int2 rhs) => (int2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (short2 lhs, int2 rhs) => (int2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, ushort2 rhs) => lhs == (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, ushort2 rhs) => lhs != (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, ushort2 rhs) => lhs < (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, ushort2 rhs) => lhs > (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, ushort2 rhs) => lhs <= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, ushort2 rhs) => lhs >= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (ushort2 lhs, int2 rhs) => (int2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (ushort2 lhs, int2 rhs) => (int2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (ushort2 lhs, int2 rhs) => (int2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (ushort2 lhs, int2 rhs) => (int2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (ushort2 lhs, int2 rhs) => (int2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (ushort2 lhs, int2 rhs) => (int2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, Unity.Mathematics.int2 rhs) => lhs == (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, Unity.Mathematics.int2 rhs) => lhs != (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, Unity.Mathematics.int2 rhs) => lhs < (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, Unity.Mathematics.int2 rhs) => lhs > (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, Unity.Mathematics.int2 rhs) => lhs <= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, Unity.Mathematics.int2 rhs) => lhs >= (int2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.int2 lhs, int2 rhs) => (int2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, Unity.Mathematics.float2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, Unity.Mathematics.float2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, Unity.Mathematics.float2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, Unity.Mathematics.float2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, Unity.Mathematics.float2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, Unity.Mathematics.float2 rhs) => lhs >= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.float2 lhs, int2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (int2 lhs, Unity.Mathematics.double2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (int2 lhs, Unity.Mathematics.double2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (int2 lhs, Unity.Mathematics.double2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (int2 lhs, Unity.Mathematics.double2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (int2 lhs, Unity.Mathematics.double2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (int2 lhs, Unity.Mathematics.double2 rhs) => lhs >= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.double2 lhs, int2 rhs) => (double2)lhs >= rhs;


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
        public readonly bool Equals(int2 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.int2 other) => __x0.Equals(other);
        
        public override readonly bool Equals(object o) => (o is int2 converted && Equals(converted)) || (o is Unity.Mathematics.int2 convertedU && Equals(convertedU)) || (o is int convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => __x0.ToString(format, formatProvider);
    }
}
