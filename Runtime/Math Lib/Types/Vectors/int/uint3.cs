using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class uint3DebuggerProxy
    {
        public uint x;
        public uint y;
        public uint z;
        
        public uint3DebuggerProxy(uint3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(uint3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct uint3 : IEquatable<uint3>, IEquatable<Unity.Mathematics.uint3>, IEquatable<uint>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.uint3 __x0;
        
        public ref uint x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint3* ptr = &this) { return ref *((uint*)ptr +  0); } } }
        public ref uint y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint3* ptr = &this) { return ref *((uint*)ptr +  1); } } }
        public ref uint z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint3* ptr = &this) { return ref *((uint*)ptr +  2); } } }


        public static uint3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(uint x, uint y, uint z)
        {
            __x0 = new Unity.Mathematics.uint3(x, y, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(uint x, uint2 yz)
        {
            __x0 = new Unity.Mathematics.uint3(x, yz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(uint2 xy, uint z)
        {
            __x0 = new Unity.Mathematics.uint3(xy, z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(uint3 xyz)
        {
            __x0 = new Unity.Mathematics.uint3(xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(uint v)
        {
            __x0 = new Unity.Mathematics.uint3(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(Unity.Mathematics.uint3 xyz)
        {
            __x0 = new Unity.Mathematics.uint3(xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(bool v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(bool3 v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(mask8x3 v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(mask16x3 v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(mask32x3 v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(mask64x3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(byte v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(byte3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(sbyte v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(sbyte3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(ushort v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(ushort3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(short v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(short3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(int v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(int3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(ulong v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(ulong3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(long v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(long3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(UInt128 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(Int128 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(quarter v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(quarter3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(half v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(half3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(float v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(float3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(double v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(double3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(quadruple v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(Unity.Mathematics.bool3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(Unity.Mathematics.int3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(Unity.Mathematics.half v)
        {
            this = (uint3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(Unity.Mathematics.half3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(Unity.Mathematics.float3 v)
        {
            this = (uint3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(Unity.Mathematics.double3 v)
        {
            this = (uint3)v;
        }

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(v128 v)
        {
            return new uint3 { __x0 = new Unity.Mathematics.uint3 { x = v.UInt0, y = v.UInt1, z = v.UInt2 } };
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(uint3 v)
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
            result.UInt2 = v.__x0.z;

            return result;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(bool3 x) => (uint3)(Unity.Mathematics.bool3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(Unity.Mathematics.bool3 x) => new uint3 { __x0 = (Unity.Mathematics.uint3)x };
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (uint3)(mask32x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (uint3)(mask32x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(mask32x3 x)
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
        public static explicit operator uint3(mask64x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (uint3)(mask32x3)x;
            }
            else
            {
                return *(uint3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(uint3 x) => (mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(uint3 x) => (mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(uint3 x) => (mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(uint3 x) => (mask32x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(uint3 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(uint3 x) => (mask32x3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint3(byte x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(sbyte x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint3(ushort x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(short x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(ulong x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(long x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(UInt128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(Int128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(quarter x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(quadruple x) => (uint)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half3(uint3 x) => (half3)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(Unity.Mathematics.uint3 v) => new uint3 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint3(uint3 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(Unity.Mathematics.int3 v) => new uint3 { __x0 = (uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(uint3 v) => (Unity.Mathematics.int3)v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(Unity.Mathematics.half v) => (uint)(half)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(Unity.Mathematics.half3 v) => (uint3)(half3)v;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(Unity.Mathematics.float3 v) => new uint3 { __x0 = (Unity.Mathematics.uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(uint3 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(Unity.Mathematics.double3 v) => new uint3 { __x0 = (Unity.Mathematics.uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(uint3 v) => v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(uint v) => new uint3 { __x0 = (Unity.Mathematics.uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(int v) => new uint3 { __x0 = (Unity.Mathematics.uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(int3 v) => new uint3 { __x0 = (Unity.Mathematics.uint3)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(half v) => (uint)v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(float v) => new uint3 { __x0 = (Unity.Mathematics.uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(float3 v) => new uint3 { __x0 = (Unity.Mathematics.uint3)v.__x0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(double v) => new uint3 { __x0 = (Unity.Mathematics.uint3)v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(double3 v) => new uint3 { __x0 = (Unity.Mathematics.uint3)v.__x0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ++ (uint3 val) => val.__x0 + 1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator -- (uint3 val) => val.__x0 - 1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (uint3 lhs, uint3 rhs) => lhs.__x0 + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (uint3 lhs, uint rhs) => lhs.__x0 + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (uint lhs, uint3 rhs) => lhs + rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (uint3 lhs, uint3 rhs) => lhs.__x0 - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (uint3 lhs, uint rhs) => lhs.__x0 - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (uint lhs, uint3 rhs) => lhs - rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (uint3 lhs, uint3 rhs) => lhs.__x0 * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (uint3 lhs, uint rhs) => lhs.__x0 * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (uint lhs, uint3 rhs) => lhs * rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (uint3 lhs, uint3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu32(lhs, rhs, 3);
            }
            else
            {
                return lhs.__x0 / rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (uint3 lhs, uint rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(rhs))
                {
                    return Xse.constdiv_epu32(lhs, rhs, 3);
                }

                return Xse.div_epu32(lhs, Xse.set1_epi32(rhs, 3), 3);
            }
            else
            {
                return lhs.__x0 / rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (uint lhs, uint3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu32(Xse.set1_epi32(lhs, 3), rhs, 3);
            }
            else
            {
                return lhs / rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (uint3 lhs, uint3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu32(lhs, rhs, 3);
            }
            else
            {
                return lhs.__x0 % rhs.__x0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (uint3 lhs, uint rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(rhs))
                {
                    return Xse.constrem_epu32(lhs, rhs, 3);
                }

                return Xse.rem_epu32(lhs, Xse.set1_epi32(rhs, 3), 3);
            }
            else
            {
                return lhs.__x0 % rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (uint lhs, uint3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu32(Xse.set1_epi32(lhs, 3), rhs, 3);
            }
            else
            {
                return lhs % rhs.__x0;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (uint3 lhs, byte rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (byte lhs, uint3 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (uint3 lhs, byte rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (byte lhs, uint3 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (uint3 lhs, byte rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (byte lhs, uint3 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (uint3 lhs, byte rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (byte lhs, uint3 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (uint3 lhs, byte rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (byte lhs, uint3 rhs) => (uint)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (uint3 lhs, ushort rhs) => lhs + (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (ushort lhs, uint3 rhs) => (uint)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (uint3 lhs, ushort rhs) => lhs - (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (ushort lhs, uint3 rhs) => (uint)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (uint3 lhs, ushort rhs) => lhs * (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (ushort lhs, uint3 rhs) => (uint)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (uint3 lhs, ushort rhs) => lhs / (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (ushort lhs, uint3 rhs) => (uint)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (uint3 lhs, ushort rhs) => lhs % (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (ushort lhs, uint3 rhs) => (uint)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (uint3 lhs, byte3 rhs) => lhs + (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (uint3 lhs, byte3 rhs) => lhs - (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (uint3 lhs, byte3 rhs) => lhs * (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (uint3 lhs, byte3 rhs) => lhs / (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (uint3 lhs, byte3 rhs) => lhs % (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (byte3 lhs, uint3 rhs) => (uint3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (byte3 lhs, uint3 rhs) => (uint3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (byte3 lhs, uint3 rhs) => (uint3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (byte3 lhs, uint3 rhs) => (uint3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (byte3 lhs, uint3 rhs) => (uint3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (uint3 lhs, ushort3 rhs) => lhs + (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (uint3 lhs, ushort3 rhs) => lhs - (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (uint3 lhs, ushort3 rhs) => lhs * (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (uint3 lhs, ushort3 rhs) => lhs / (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (uint3 lhs, ushort3 rhs) => lhs % (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (ushort3 lhs, uint3 rhs) => (uint3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (ushort3 lhs, uint3 rhs) => (uint3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (ushort3 lhs, uint3 rhs) => (uint3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (ushort3 lhs, uint3 rhs) => (uint3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (ushort3 lhs, uint3 rhs) => (uint3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs + (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs - (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs * (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs / (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs % (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs - (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs * (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs / (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs % (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs - (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs * (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs / (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs % (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs - rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs * rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs / rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator << (uint3 lhs, int rhs) => lhs.__x0 << rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator >> (uint3 lhs, int rhs) => lhs.__x0 >> rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ~ (uint3 v) => ~v.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (uint3 lhs, uint3 rhs) => lhs.__x0 & rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (uint3 lhs, uint rhs) => lhs.__x0 & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (uint lhs, uint3 rhs) => lhs & rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (uint3 lhs, uint3 rhs) => lhs.__x0 | rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (uint3 lhs, uint rhs) => lhs.__x0 | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (uint lhs, uint3 rhs) => lhs | rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (uint3 lhs, uint3 rhs) => lhs.__x0 ^ rhs.__x0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (uint3 lhs, uint rhs) => lhs.__x0 ^ rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (uint lhs, uint3 rhs) => lhs ^ rhs.__x0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (uint3 lhs, byte rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (byte lhs, uint3 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (uint3 lhs, byte rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (byte lhs, uint3 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (uint3 lhs, byte rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (byte lhs, uint3 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (uint3 lhs, ushort rhs) => lhs & (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (ushort lhs, uint3 rhs) => (uint)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (uint3 lhs, ushort rhs) => lhs | (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (ushort lhs, uint3 rhs) => (uint)lhs | rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (uint3 lhs, ushort rhs) => lhs ^ (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (ushort lhs, uint3 rhs) => (uint)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (uint3 lhs, byte3 rhs) => lhs & (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (uint3 lhs, byte3 rhs) => lhs | (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (uint3 lhs, byte3 rhs) => lhs ^ (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (byte3 lhs, uint3 rhs) => (uint3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (byte3 lhs, uint3 rhs) => (uint3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (byte3 lhs, uint3 rhs) => (uint3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (uint3 lhs, ushort3 rhs) => lhs & (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (uint3 lhs, ushort3 rhs) => lhs | (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (uint3 lhs, ushort3 rhs) => lhs ^ (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (ushort3 lhs, uint3 rhs) => (uint3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (ushort3 lhs, uint3 rhs) => (uint3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (ushort3 lhs, uint3 rhs) => (uint3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs & (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs | (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs ^ (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs & rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs | rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs ^ rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint3 lhs, uint3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_epi32(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x == rhs.x, lhs.y == rhs.y, lhs.z == rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint3 lhs, uint rhs) => lhs == (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint lhs, uint3 rhs) => (uint3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint3 lhs, uint3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpeq_epi32(lhs, rhs));
            }
            else
            {
                return new mask32x3(lhs.x != rhs.x, lhs.y != rhs.y, lhs.z != rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint3 lhs, uint rhs) => lhs != (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint lhs, uint3 rhs) => (uint3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint3 lhs, uint3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epu32(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x < rhs.x, lhs.y < rhs.y, lhs.z < rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint3 lhs, uint rhs) => lhs < (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint lhs, uint3 rhs) => (uint3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint3 lhs, uint3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epu32(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x > rhs.x, lhs.y > rhs.y, lhs.z > rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint3 lhs, uint rhs) => lhs > (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint lhs, uint3 rhs) => (uint3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint3 lhs, uint3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_epu32(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x <= rhs.x, lhs.y <= rhs.y, lhs.z <= rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint3 lhs, uint rhs) => lhs <= (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint lhs, uint3 rhs) => (uint3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint3 lhs, uint3 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_epu32(lhs, rhs);
            }
            else
            {
                return new mask32x3(lhs.x >= rhs.x, lhs.y >= rhs.y, lhs.z >= rhs.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint3 lhs, uint rhs) => lhs >= (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint lhs, uint3 rhs) => (uint3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint3 lhs, byte rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (byte lhs, uint3 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint3 lhs, byte rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (byte lhs, uint3 rhs) => (uint)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint3 lhs, byte rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (byte lhs, uint3 rhs) => (uint)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint3 lhs, byte rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (byte lhs, uint3 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint3 lhs, byte rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (byte lhs, uint3 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint3 lhs, byte rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (byte lhs, uint3 rhs) => (uint)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint3 lhs, ushort rhs) => lhs == (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (ushort lhs, uint3 rhs) => (uint)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint3 lhs, ushort rhs) => lhs != (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (ushort lhs, uint3 rhs) => (uint)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint3 lhs, ushort rhs) => lhs < (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (ushort lhs, uint3 rhs) => (uint)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint3 lhs, ushort rhs) => lhs > (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (ushort lhs, uint3 rhs) => (uint)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint3 lhs, ushort rhs) => lhs <= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (ushort lhs, uint3 rhs) => (uint)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint3 lhs, ushort rhs) => lhs >= (uint)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (ushort lhs, uint3 rhs) => (uint)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint3 lhs, byte3 rhs) => lhs == (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint3 lhs, byte3 rhs) => lhs != (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint3 lhs, byte3 rhs) => lhs < (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint3 lhs, byte3 rhs) => lhs > (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint3 lhs, byte3 rhs) => lhs <= (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint3 lhs, byte3 rhs) => lhs >= (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (byte3 lhs, uint3 rhs) => (uint3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (byte3 lhs, uint3 rhs) => (uint3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (byte3 lhs, uint3 rhs) => (uint3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (byte3 lhs, uint3 rhs) => (uint3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (byte3 lhs, uint3 rhs) => (uint3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (byte3 lhs, uint3 rhs) => (uint3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint3 lhs, ushort3 rhs) => lhs == (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint3 lhs, ushort3 rhs) => lhs != (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint3 lhs, ushort3 rhs) => lhs < (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint3 lhs, ushort3 rhs) => lhs > (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint3 lhs, ushort3 rhs) => lhs <= (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint3 lhs, ushort3 rhs) => lhs >= (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (ushort3 lhs, uint3 rhs) => (uint3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (ushort3 lhs, uint3 rhs) => (uint3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (ushort3 lhs, uint3 rhs) => (uint3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (ushort3 lhs, uint3 rhs) => (uint3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (ushort3 lhs, uint3 rhs) => (uint3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (ushort3 lhs, uint3 rhs) => (uint3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs == (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs != (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs < (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs > (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs <= (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint3 lhs, Unity.Mathematics.uint3 rhs) => lhs >= (uint3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.uint3 lhs, uint3 rhs) => (uint3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs != (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs < (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs > (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs <= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint3 lhs, Unity.Mathematics.float3 rhs) => lhs >= (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.float3 lhs, uint3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs != (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs < (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs > (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs <= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (uint3 lhs, Unity.Mathematics.double3 rhs) => lhs >= (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator == (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator != (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs != rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator < (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs < rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator > (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs > rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator <= (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs <= rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 operator >= (Unity.Mathematics.double3 lhs, uint3 rhs) => (double3)lhs >= rhs;


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
        public readonly uint4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxz; }
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
        public readonly uint4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxzz; }
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
        public readonly uint4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxz; }
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
        public readonly uint4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzzz; }
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
        public readonly uint4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxz; }
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
        public readonly uint4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxzz; }
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
        public readonly uint4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxz; }
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
        public readonly uint4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzzz; }
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
        public readonly uint3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxz; }
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
        public uint3 xyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xyz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xyz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xzy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xzy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xzz; }
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
        public uint3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yxz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yxz = value; }
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
        public readonly uint3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yzx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yzx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yzz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zxy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zxy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zxz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zyx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zyx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zyz; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zzz; }
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
        public uint2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xz = value; }
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yz; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yz = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.zy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.zy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly uint2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.zz; }
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
        public readonly bool Equals(uint3 other) => __x0.Equals(other.__x0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.uint3 other) => __x0.Equals(other);
        
        public override readonly bool Equals(object o) => (o is uint3 converted && Equals(converted)) || (o is Unity.Mathematics.uint3 convertedU && Equals(convertedU)) || (o is uint convertedS && Equals(convertedS)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly string ToString() => __x0.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly string ToString(string format, IFormatProvider formatProvider) => __x0.ToString(format, formatProvider);
    }
}
