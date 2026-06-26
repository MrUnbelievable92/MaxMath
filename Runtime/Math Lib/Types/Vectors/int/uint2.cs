using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class uint2DebuggerProxy
    {
        public uint x;
        public uint y;

        public uint2DebuggerProxy(uint2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(uint2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct uint2 : IEquatable<uint2>, IEquatable<Unity.Mathematics.uint2>, IEquatable<uint>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.uint2 __x0;
        
        public ref uint x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint2* ptr = &this) { return ref *((uint*)ptr +  0); } } }
        public ref uint y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint2* ptr = &this) { return ref *((uint*)ptr +  1); } } }


        public static uint2 zero => default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(uint x, uint y)
        {
            __x0 = new Unity.Mathematics.uint2(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(uint2 xy)
        {
            __x0 = new Unity.Mathematics.uint2(xy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(uint v)
        {
            __x0 = new Unity.Mathematics.uint2(v);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(Unity.Mathematics.uint2 xy)
        {
            __x0 = xy;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(bool v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(bool2 v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(mask8x2 v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(mask16x2 v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(mask32x2 v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(mask64x2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(byte v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(byte2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(sbyte v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(sbyte2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(ushort v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(ushort2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(short v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(short2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(int v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(int2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(ulong v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(ulong2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(long v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(long2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(UInt128 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(Int128 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(quarter v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(quarter2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(half v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(half2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(float v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(float2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(double v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(double2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(quadruple v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(Unity.Mathematics.bool2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(Unity.Mathematics.int2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(Unity.Mathematics.half v)
        {
            this = (uint2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(Unity.Mathematics.half2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(Unity.Mathematics.float2 v)
        {
            this = (uint2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint2(Unity.Mathematics.double2 v)
        {
            this = (uint2)v;
        }

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(v128 v)
        {
            return new uint2 { __x0 = new Unity.Mathematics.uint2 { x = v.UInt0, y = v.UInt1 } };
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(uint2 v)
        {
            v128 result;
            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                result = Uninitialized<v128>.Create();
            }

            result.UInt0 = v.__x0.x;
            result.UInt1 = v.__x0.y;

            return result;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(bool2 x) => (uint2)(Unity.Mathematics.bool2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(Unity.Mathematics.bool2 x) => new uint2 { __x0 = (Unity.Mathematics.uint2)x };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (uint2)(mask32x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (uint2)(mask32x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(mask32x2 x)
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
        public static explicit operator uint2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (uint2)(mask32x2)x;
            }
            else
            {
                return *(uint2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(uint2 x) => (mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(uint2 x) => (mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(uint2 x) => (mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(uint2 x) => (mask32x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(uint2 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(uint2 x) => (mask32x2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint2(byte x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(sbyte x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint2(ushort x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(short x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(ulong x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(long x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(UInt128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(Int128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(quarter x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(quadruple x) => (uint)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half2(uint2 x) => (half2)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(Unity.Mathematics.uint2 v) => new uint2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint2(uint2 v) => v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(Unity.Mathematics.int2 v) => new uint2 { __x0 = (uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(uint2 v) => (Unity.Mathematics.int2)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(Unity.Mathematics.half v) => (uint)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(Unity.Mathematics.half2 v) => (uint2)(half2)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(Unity.Mathematics.float2 v) => new uint2 { __x0 = (Unity.Mathematics.uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(uint2 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(Unity.Mathematics.double2 v) => new uint2 { __x0 = (Unity.Mathematics.uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(uint2 v) => v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(uint v) => new uint2 { __x0 = (Unity.Mathematics.uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(int v) => new uint2 { __x0 = (Unity.Mathematics.uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(int2 v) => new uint2 { __x0 = (Unity.Mathematics.uint2)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(half v) => (uint)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(float v) => new uint2 { __x0 = (Unity.Mathematics.uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(float2 v) => new uint2 { __x0 = (Unity.Mathematics.uint2)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(double v) => new uint2 { __x0 = (Unity.Mathematics.uint2)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(double2 v) => new uint2 { __x0 = (Unity.Mathematics.uint2)v.__x0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ++ (uint2 val) => val.__x0 + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator -- (uint2 val) => val.__x0 - 1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (uint2 lhs, uint2 rhs) => lhs.__x0 + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (uint2 lhs, uint rhs) => lhs.__x0 + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (uint lhs, uint2 rhs) => lhs + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (uint2 lhs, uint2 rhs) => lhs.__x0 - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (uint2 lhs, uint rhs) => lhs.__x0 - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (uint lhs, uint2 rhs) => lhs - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (uint2 lhs, uint2 rhs) => lhs.__x0 * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (uint2 lhs, uint rhs) => lhs.__x0 * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (uint lhs, uint2 rhs) => lhs * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (uint2 lhs, uint2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu32(lhs, rhs, 2);
            }
            else
            {
                return lhs.__x0 / rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (uint2 lhs, uint rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(rhs))
                {
                    return Xse.constdiv_epu32(lhs, rhs, 2);
                }

                return Xse.div_epu32(lhs, Xse.set1_epi32(rhs, 2), 2);
            }
            else
            {
                return lhs.__x0 / rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (uint lhs, uint2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu32(Xse.set1_epi32(lhs, 2), rhs, 2);
            }
            else
            {
                return lhs / rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (uint2 lhs, uint2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu32(lhs, rhs, 2);
            }
            else
            {
                return lhs.__x0 % rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (uint2 lhs, uint rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(rhs))
                {
                    return Xse.constrem_epu32(lhs, rhs, 2);
                }

                return Xse.rem_epu32(lhs, Xse.set1_epi32(rhs, 2), 2);
            }
            else
            {
                return lhs.__x0 % rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (uint lhs, uint2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu32(Xse.set1_epi32(lhs, 2), rhs, 2);
            }
            else
            {
                return lhs % rhs.__x0;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (uint2 lhs, byte rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (byte lhs, uint2 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (uint2 lhs, byte rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (byte lhs, uint2 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (uint2 lhs, byte rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (byte lhs, uint2 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (uint2 lhs, byte rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (byte lhs, uint2 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (uint2 lhs, byte rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (byte lhs, uint2 rhs) => (uint)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (uint2 lhs, ushort rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (ushort lhs, uint2 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (uint2 lhs, ushort rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (ushort lhs, uint2 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (uint2 lhs, ushort rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (ushort lhs, uint2 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (uint2 lhs, ushort rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (ushort lhs, uint2 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (uint2 lhs, ushort rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (ushort lhs, uint2 rhs) => (uint)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (uint2 lhs, byte2 rhs) => lhs + (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (uint2 lhs, byte2 rhs) => lhs - (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (uint2 lhs, byte2 rhs) => lhs * (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (uint2 lhs, byte2 rhs) => lhs / (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (uint2 lhs, byte2 rhs) => lhs % (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (byte2 lhs, uint2 rhs) => (uint2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (byte2 lhs, uint2 rhs) => (uint2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (byte2 lhs, uint2 rhs) => (uint2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (byte2 lhs, uint2 rhs) => (uint2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (byte2 lhs, uint2 rhs) => (uint2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (uint2 lhs, ushort2 rhs) => lhs + (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (uint2 lhs, ushort2 rhs) => lhs - (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (uint2 lhs, ushort2 rhs) => lhs * (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (uint2 lhs, ushort2 rhs) => lhs / (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (uint2 lhs, ushort2 rhs) => lhs % (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (ushort2 lhs, uint2 rhs) => (uint2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (ushort2 lhs, uint2 rhs) => (uint2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (ushort2 lhs, uint2 rhs) => (uint2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (ushort2 lhs, uint2 rhs) => (uint2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (ushort2 lhs, uint2 rhs) => (uint2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs + (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs - (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs * (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs / (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs % (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator + (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator - (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator * (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator / (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator % (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs - (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs * (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs / (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs % (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs - (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs * (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs / (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs % (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator << (uint2 lhs, int rhs) => lhs.__x0 << rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator >> (uint2 lhs, int rhs) => lhs.__x0 >> rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ~ (uint2 v) => ~v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (uint2 lhs, uint2 rhs) => lhs.__x0 & rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (uint2 lhs, uint rhs) => lhs.__x0 & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (uint lhs, uint2 rhs) => lhs & rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (uint2 lhs, uint2 rhs) => lhs.__x0 | rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (uint2 lhs, uint rhs) => lhs.__x0 | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (uint lhs, uint2 rhs) => lhs | rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (uint2 lhs, uint2 rhs) => lhs.__x0 ^ rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (uint2 lhs, uint rhs) => lhs.__x0 ^ rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (uint lhs, uint2 rhs) => lhs ^ rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (uint2 lhs, byte rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (byte lhs, uint2 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (uint2 lhs, byte rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (byte lhs, uint2 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (uint2 lhs, byte rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (byte lhs, uint2 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (uint2 lhs, ushort rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (ushort lhs, uint2 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (uint2 lhs, ushort rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (ushort lhs, uint2 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (uint2 lhs, ushort rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (ushort lhs, uint2 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (uint2 lhs, byte2 rhs) => lhs & (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (uint2 lhs, byte2 rhs) => lhs | (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (uint2 lhs, byte2 rhs) => lhs ^ (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (byte2 lhs, uint2 rhs) => (uint2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (byte2 lhs, uint2 rhs) => (uint2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (byte2 lhs, uint2 rhs) => (uint2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (uint2 lhs, ushort2 rhs) => lhs & (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (uint2 lhs, ushort2 rhs) => lhs | (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (uint2 lhs, ushort2 rhs) => lhs ^ (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (ushort2 lhs, uint2 rhs) => (uint2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (ushort2 lhs, uint2 rhs) => (uint2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (ushort2 lhs, uint2 rhs) => (uint2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs & (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs | (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs ^ (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator & (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator | (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 operator ^ (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint2 lhs, uint2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_epi32(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x == rhs.x, lhs.y == rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint2 lhs, uint rhs) => lhs == (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint lhs, uint2 rhs) => (uint2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint2 lhs, uint2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpeq_epi32(lhs, rhs));
            }
            else
            {
                return new mask32x2(lhs.x != rhs.x, lhs.y != rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint2 lhs, uint rhs) => lhs != (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint lhs, uint2 rhs) => (uint2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint2 lhs, uint2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epu32(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x < rhs.x, lhs.y < rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint2 lhs, uint rhs) => lhs < (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint lhs, uint2 rhs) => (uint2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint2 lhs, uint2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epu32(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x > rhs.x, lhs.y > rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint2 lhs, uint rhs) => lhs > (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint lhs, uint2 rhs) => (uint2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint2 lhs, uint2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_epu32(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x <= rhs.x, lhs.y <= rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint2 lhs, uint rhs) => lhs <= (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint lhs, uint2 rhs) => (uint2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint2 lhs, uint2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_epu32(lhs, rhs);
            }
            else
            {
                return new mask32x2(lhs.x >= rhs.x, lhs.y >= rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint2 lhs, uint rhs) => lhs >= (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint lhs, uint2 rhs) => (uint2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint2 lhs, byte rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (byte lhs, uint2 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint2 lhs, byte rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (byte lhs, uint2 rhs) => (uint)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint2 lhs, byte rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (byte lhs, uint2 rhs) => (uint)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint2 lhs, byte rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (byte lhs, uint2 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint2 lhs, byte rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (byte lhs, uint2 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint2 lhs, byte rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (byte lhs, uint2 rhs) => (uint)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint2 lhs, ushort rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (ushort lhs, uint2 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint2 lhs, ushort rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (ushort lhs, uint2 rhs) => (uint)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint2 lhs, ushort rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (ushort lhs, uint2 rhs) => (uint)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint2 lhs, ushort rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (ushort lhs, uint2 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint2 lhs, ushort rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (ushort lhs, uint2 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint2 lhs, ushort rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (ushort lhs, uint2 rhs) => (uint)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint2 lhs, byte2 rhs) => lhs == (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint2 lhs, byte2 rhs) => lhs != (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint2 lhs, byte2 rhs) => lhs < (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint2 lhs, byte2 rhs) => lhs > (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint2 lhs, byte2 rhs) => lhs <= (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint2 lhs, byte2 rhs) => lhs >= (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (byte2 lhs, uint2 rhs) => (uint2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (byte2 lhs, uint2 rhs) => (uint2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (byte2 lhs, uint2 rhs) => (uint2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (byte2 lhs, uint2 rhs) => (uint2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (byte2 lhs, uint2 rhs) => (uint2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (byte2 lhs, uint2 rhs) => (uint2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint2 lhs, ushort2 rhs) => lhs == (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint2 lhs, ushort2 rhs) => lhs != (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint2 lhs, ushort2 rhs) => lhs < (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint2 lhs, ushort2 rhs) => lhs > (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint2 lhs, ushort2 rhs) => lhs <= (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint2 lhs, ushort2 rhs) => lhs >= (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (ushort2 lhs, uint2 rhs) => (uint2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (ushort2 lhs, uint2 rhs) => (uint2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (ushort2 lhs, uint2 rhs) => (uint2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (ushort2 lhs, uint2 rhs) => (uint2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (ushort2 lhs, uint2 rhs) => (uint2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (ushort2 lhs, uint2 rhs) => (uint2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs == (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs != (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs < (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs > (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs <= (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint2 lhs, Unity.Mathematics.uint2 rhs) => lhs >= (uint2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.uint2 lhs, uint2 rhs) => (uint2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs != (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs < (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs > (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs <= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint2 lhs, Unity.Mathematics.float2 rhs) => lhs >= (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.float2 lhs, uint2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs != (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs < (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs > (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs <= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (uint2 lhs, Unity.Mathematics.double2 rhs) => lhs >= (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator == (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator != (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator < (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator > (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator <= (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 operator >= (Unity.Mathematics.double2 lhs, uint2 rhs) => (double2)lhs >= rhs;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yy; }
        }


        public uint this[int index]
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
        public readonly bool Equals(uint other) => __x0.Equals(other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint2 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.uint2 other) => __x0.Equals(other);
        
        public override readonly bool Equals(object o) => (o is uint2 converted && Equals(converted)) || (o is Unity.Mathematics.uint2 convertedU && Equals(convertedU)) || (o is uint convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => __x0.ToString(format, formatProvider);
    }
}
