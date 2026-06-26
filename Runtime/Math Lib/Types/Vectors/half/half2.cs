using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
#if DEBUG
    internal sealed class half2DebuggerProxy
    {
        public half x;
        public half y;

        public half2DebuggerProxy(half2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(half2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public partial struct half2 : IEquatable<half2>, IEquatable<Unity.Mathematics.half2>, IEquatable<half>, IEquatable<Unity.Mathematics.half>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal Unity.Mathematics.half2 __x0;
        
        public ref half x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half2* ptr = &this) { return ref *((half*)ptr +  0); } } }
        public ref half y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(half2* ptr = &this) { return ref *((half*)ptr +  1); } } }


        public static half2 zero => default;
        

        internal readonly bool2 IsZero => (math.asushort(this) & 0x7FFF) == 0;
        internal readonly bool2 IsNotZero => (math.asushort(this) & 0x7FFF) != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(half x, half y)
        {
            __x0 = new Unity.Mathematics.half2(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(half2 xy)
        {
            __x0 = new Unity.Mathematics.half2(xy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(half v)
        {
            __x0 = new Unity.Mathematics.half2(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(Unity.Mathematics.half2 xy)
        {
            __x0 = new Unity.Mathematics.half2(xy);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(Unity.Mathematics.half v)
        {
            __x0 = new Unity.Mathematics.half2(v);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(bool v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(bool2 v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(mask8x2 v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(mask16x2 v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(mask32x2 v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(mask64x2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(byte v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(byte2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(sbyte v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(sbyte2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(ushort v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(ushort2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(short v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(short2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(uint v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(uint2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(int v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(int2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(ulong v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(ulong2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(long v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(long2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(UInt128 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(Int128 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(quarter v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(quarter2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(float v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(float2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(double v)
        {
            this = (half2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(double2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(quadruple v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(Unity.Mathematics.bool2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(Unity.Mathematics.uint2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(Unity.Mathematics.int2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(Unity.Mathematics.float2 v)
        {
            this = (half2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half2(Unity.Mathematics.double2 v)
        {
            this = (half2)v;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(v128 v) => math.ashalf((ushort2)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(half2 v) => math.asushort(v);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(bool x) => (half2)(mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(bool2 x) => (half2)(mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(Unity.Mathematics.bool2 x) => (half2)(mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half2)(mask16x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_ph((half)1f));
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half2)(mask16x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (half2)(mask16x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(half2 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(half2 x) => (bool2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(half2 x) => (mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(half2 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(half2 x) => (mask16x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(half2 x) => (mask16x2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(UInt128 x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(Int128 x) => (half)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(quadruple x) => (half)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(half v) => math.ashalf((ushort2)v.value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(Unity.Mathematics.half v) => (half)v;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(Unity.Mathematics.half2 v) => new half2 { __x0 = v };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half2(half2 v) => v.__x0;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator half2(sbyte input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(sbyte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_ph(input, elements: 2);
            }
            else
            {
                return new half2(input.x, input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi8(input, 2);
            }
            else
            {
                return new sbyte2((sbyte)input.x, (sbyte)input.y);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator half2(byte input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(byte2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_ph(input, elements: 2);
            }
            else
            {
                return new half2(input.x, input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu8(input, 2);
            }
            else
            {
                return new byte2((byte)input.x, (byte)input.y);
            }
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(short input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(short2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_ph(input, elements: 2);
            }
            else
            {
                return new half2(input.x, input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(input, 2);
            }
            else
            {
                return new short2((short)input.x, (short)input.y);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(ushort input) =>(half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(ushort2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_ph(input, MaxMath.half.PositiveInfinity, elements: 2);
            }
            else
            {
                return new half2((half)input.x, (half)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu16(input, 2);
            }
            else
            {
                return new ushort2((ushort)input.x, (ushort)input.y);
            }
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(int input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(int2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_ph(input, MaxMath.half.PositiveInfinity, elements: 2);
            }
            else
            {
                return new half2((half)input.x, (half)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi32(input, 2);
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(uint input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(uint2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_ph(input, MaxMath.half.PositiveInfinity, elements: 2);
            }
            else
            {
                return new half2((half)input.x, (half)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu32(input, 2);
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(Unity.Mathematics.int2 input) => (half2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(half2 input) => (Unity.Mathematics.int2)(int2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(Unity.Mathematics.uint2 input) => (half2)(uint2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(half2 input) => (Unity.Mathematics.uint2)(uint2)input;
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(long input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(long2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_ph(input, MaxMath.half.PositiveInfinity);
            }
            else
            {
                return new half2((half)input.x, (half)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi64(input);
            }
            else
            {
                return new long2((long)input.x, (long)input.y);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(ulong input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(ulong2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu64_ph(input, MaxMath.half.PositiveInfinity);
            }
            else
            {
                return new half2((half)input.x, (half)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(float input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(float2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_ph(input, elements: 2);
            }
            else
            {
                return new half2((half)input.x, (half)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_ps(input, elements: 2);
            }
            else
            {
                return new float2((float)input.x, (float)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(Unity.Mathematics.float2 input) => (half2)(float2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float2(half2 input) => (Unity.Mathematics.float2)(float2)input;
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(double input) => (half)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(double2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpd_ph(input);
            }
            else
            {
                return new half2((half)input.x, (half)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(half2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_pd(input);
            }
            else
            {
                return new double2((double)input.x, (double)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half2(Unity.Mathematics.double2 input) => (half2)(double2)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double2(half2 input) => (Unity.Mathematics.double2)(double2)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 operator + (half2 val) => val;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 operator - (half2 val) => math.ashalf(math.asushort(val) ^ 0x8000);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (half2 lhs, float rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (half2 lhs, float rhs) => (float2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (half2 lhs, float rhs) => (float2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (half2 lhs, float rhs) => (float2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (half2 lhs, float rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (float lhs, half2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (float lhs, half2 rhs) => lhs - (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (float lhs, half2 rhs) => lhs * (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (float lhs, half2 rhs) => lhs / (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (float lhs, half2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 lhs, half2 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 lhs, half2 rhs) => lhs - (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 lhs, half2 rhs) => lhs * (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 lhs, half2 rhs) => lhs / (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 lhs, half2 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (half2 lhs, double rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (half2 lhs, double rhs) => (double2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (half2 lhs, double rhs) => (double2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (half2 lhs, double rhs) => (double2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (half2 lhs, double rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (double lhs, half2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (double lhs, half2 rhs) => lhs - (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (double lhs, half2 rhs) => lhs * (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (double lhs, half2 rhs) => lhs / (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (double lhs, half2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 lhs, half2 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 lhs, half2 rhs) => lhs - (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 lhs, half2 rhs) => lhs * (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 lhs, half2 rhs) => lhs / (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 lhs, half2 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_ph(lhs, rhs, elements: 2);
            }
            else
            {
                return new mask16x2(lhs.x == rhs.x, lhs.y == rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, half rhs) => lhs == (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half lhs, half2 rhs) => (half2)lhs == rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_ph(lhs, rhs, elements: 2);
            }
            else
            {
                return new mask16x2(lhs.x == rhs.x, lhs.y == rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, half rhs) => lhs != (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half lhs, half2 rhs) => (half2)lhs != rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_ph(lhs, rhs, elements: 2);
            }
            else
            {
                return new mask16x2(lhs.x < rhs.x, lhs.y < rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, half rhs) => lhs < (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half lhs, half2 rhs) => (half2)lhs < rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_ph(lhs, rhs, elements: 2);
            }
            else
            {
                return new mask16x2(lhs.x > rhs.x, lhs.y > rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, half rhs) => lhs > (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half lhs, half2 rhs) => (half2)lhs > rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_ph(lhs, rhs, elements: 2);
            }
            else
            {
                return new mask16x2(lhs.x <= rhs.x, lhs.y <= rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, half rhs) => lhs <= (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half lhs, half2 rhs) => (half2)lhs <= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_ph(lhs, rhs, elements: 2);
            }
            else
            {
                return new mask16x2(lhs.x >= rhs.x, lhs.y >= rhs.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, half rhs) => lhs >= (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half lhs, half2 rhs) => (half2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs == rhs;
            }
            else
            {
                return lhs == (half2)rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs != rhs;
            }
            else
            {
                return lhs != (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs < rhs;
            }
            else
            {
                return lhs < (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs > rhs;
            }
            else
            {
                return lhs > (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs <= rhs;
            }
            else
            {
                return lhs <= (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, quarter rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs >= rhs;
            }
            else
            {
                return lhs >= (half2)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (quarter lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float2)rhs;
            }
            else
            {
                return (half2)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (quarter lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float2)rhs;
            }
            else
            {
                return (half2)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (quarter lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float2)rhs;
            }
            else
            {
                return (half2)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (quarter lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float2)rhs;
            }
            else
            {
                return (half2)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (quarter lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float2)rhs;
            }
            else
            {
                return (half2)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (quarter lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float2)rhs;
            }
            else
            {
                return (half2)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, Unity.Mathematics.half2 rhs) => lhs == (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, Unity.Mathematics.half2 rhs) => lhs != (half2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, Unity.Mathematics.half2 rhs) => lhs < (half2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, Unity.Mathematics.half2 rhs) => lhs > (half2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, Unity.Mathematics.half2 rhs) => lhs <= (half2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, Unity.Mathematics.half2 rhs) => lhs >= (half2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.half2 lhs, half2 rhs) => (half2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.half2 lhs, half2 rhs) => (half2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.half2 lhs, half2 rhs) => (half2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.half2 lhs, half2 rhs) => (half2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.half2 lhs, half2 rhs) => (half2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.half2 lhs, half2 rhs) => (half2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, Unity.Mathematics.half rhs) => lhs == (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, Unity.Mathematics.half rhs) => lhs != (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, Unity.Mathematics.half rhs) => lhs < (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, Unity.Mathematics.half rhs) => lhs > (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, Unity.Mathematics.half rhs) => lhs <= (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, Unity.Mathematics.half rhs) => lhs >= (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.half lhs, half2 rhs) => (half)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.half lhs, half2 rhs) => (half)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.half lhs, half2 rhs) => (half)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.half lhs, half2 rhs) => (half)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.half lhs, half2 rhs) => (half)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.half lhs, half2 rhs) => (half)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, float rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, float rhs) => (float2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, float rhs) => (float2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, float rhs) => (float2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, float rhs) => (float2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, float rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (float lhs, half2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (float lhs, half2 rhs) => lhs != (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (float lhs, half2 rhs) => lhs < (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (float lhs, half2 rhs) => lhs > (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (float lhs, half2 rhs) => lhs <= (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (float lhs, half2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.float2 lhs, half2 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.float2 lhs, half2 rhs) => lhs != (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.float2 lhs, half2 rhs) => lhs < (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.float2 lhs, half2 rhs) => lhs > (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.float2 lhs, half2 rhs) => lhs <= (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.float2 lhs, half2 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, double rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, double rhs) => (double2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, double rhs) => (double2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, double rhs) => (double2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, double rhs) => (double2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, double rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (double lhs, half2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (double lhs, half2 rhs) => lhs != (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (double lhs, half2 rhs) => lhs < (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (double lhs, half2 rhs) => lhs > (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (double lhs, half2 rhs) => lhs <= (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (double lhs, half2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (Unity.Mathematics.double2 lhs, half2 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (Unity.Mathematics.double2 lhs, half2 rhs) => lhs != (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (Unity.Mathematics.double2 lhs, half2 rhs) => lhs < (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (Unity.Mathematics.double2 lhs, half2 rhs) => lhs > (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (Unity.Mathematics.double2 lhs, half2 rhs) => lhs <= (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (Unity.Mathematics.double2 lhs, half2 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, byte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half2)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, byte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs != rhs;
            }
            else
            {
                return lhs != (half2)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, byte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs < rhs;
            }
            else
            {
                return lhs < (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, byte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs > rhs;
            }
            else
            {
                return lhs > (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, byte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs <= rhs;
            }
            else
            {
                return lhs <= (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, byte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs >= rhs;
            }
            else
            {
                return lhs >= (half2)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (byte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float2)rhs;
            }
            else
            {
                return math.andnot((half2)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (byte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float2)rhs;
            }
            else
            {
                return (half2)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (byte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float2)rhs;
            }
            else
            {
                return (half2)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (byte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float2)rhs;
            }
            else
            {
                return (half2)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (byte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float2)rhs;
            }
            else
            {
                return (half2)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (byte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float2)rhs;
            }
            else
            {
                return (half2)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half2)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs != rhs;
            }
            else
            {
                return lhs != (half2)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs < rhs;
            }
            else
            {
                return lhs < (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs > rhs;
            }
            else
            {
                return lhs > (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs <= rhs;
            }
            else
            {
                return lhs <= (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, byte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs >= rhs;
            }
            else
            {
                return lhs >= (half2)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (byte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float2)rhs;
            }
            else
            {
                return (half2)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (byte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float2)rhs;
            }
            else
            {
                return (half2)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (byte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float2)rhs;
            }
            else
            {
                return (half2)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (byte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float2)rhs;
            }
            else
            {
                return (half2)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (byte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float2)rhs;
            }
            else
            {
                return (half2)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (byte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float2)rhs;
            }
            else
            {
                return (half2)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, sbyte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half2)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, sbyte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs != rhs;
            }
            else
            {
                return lhs != (half2)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, sbyte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs < rhs;
            }
            else
            {
                return lhs < (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, sbyte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs > rhs;
            }
            else
            {
                return lhs > (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, sbyte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs <= rhs;
            }
            else
            {
                return lhs <= (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, sbyte2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs >= rhs;
            }
            else
            {
                return lhs >= (half2)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (sbyte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float2)rhs;
            }
            else
            {
                return math.andnot((half2)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (sbyte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float2)rhs;
            }
            else
            {
                return (half2)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (sbyte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float2)rhs;
            }
            else
            {
                return (half2)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (sbyte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float2)rhs;
            }
            else
            {
                return (half2)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (sbyte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float2)rhs;
            }
            else
            {
                return (half2)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (sbyte2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float2)rhs;
            }
            else
            {
                return (half2)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half2)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs != rhs;
            }
            else
            {
                return lhs != (half2)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs < rhs;
            }
            else
            {
                return lhs < (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs > rhs;
            }
            else
            {
                return lhs > (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs <= rhs;
            }
            else
            {
                return lhs <= (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, sbyte rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs >= rhs;
            }
            else
            {
                return lhs >= (half2)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (sbyte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float2)rhs;
            }
            else
            {
                return (half2)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (sbyte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float2)rhs;
            }
            else
            {
                return (half2)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (sbyte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float2)rhs;
            }
            else
            {
                return (half2)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (sbyte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float2)rhs;
            }
            else
            {
                return (half2)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (sbyte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float2)rhs;
            }
            else
            {
                return (half2)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (sbyte lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float2)rhs;
            }
            else
            {
                return (half2)lhs >= rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, short2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half2)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, short2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs != rhs;
            }
            else
            {
                return lhs != (half2)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, short2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs < rhs;
            }
            else
            {
                return lhs < (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, short2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs > rhs;
            }
            else
            {
                return lhs > (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, short2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs <= rhs;
            }
            else
            {
                return lhs <= (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, short2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs >= rhs;
            }
            else
            {
                return lhs >= (half2)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float2)rhs;
            }
            else
            {
                return math.andnot((half2)lhs == rhs, math.isinf(rhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float2)rhs;
            }
            else
            {
                return (half2)lhs != rhs | math.isinf(rhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float2)rhs;
            }
            else
            {
                return (half2)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float2)rhs;
            }
            else
            {
                return (half2)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float2)rhs;
            }
            else
            {
                return (half2)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short2 lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float2)rhs;
            }
            else
            {
                return (half2)lhs >= rhs;
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (half2 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs == rhs;
            }
            else
            {
                return math.andnot(lhs == (half2)rhs, math.isinf(lhs));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (half2 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs != rhs;
            }
            else
            {
                return lhs != (half2)rhs | math.isinf(lhs);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (half2 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs < rhs;
            }
            else
            {
                return lhs < (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (half2 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs > rhs;
            }
            else
            {
                return lhs > (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (half2 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs <= rhs;
            }
            else
            {
                return lhs <= (half2)rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (half2 lhs, short rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float2)lhs >= rhs;
            }
            else
            {
                return lhs >= (half2)rhs;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator == (short lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs == (float2)rhs;
            }
            else
            {
                return (half2)lhs == rhs;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator != (short lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs != (float2)rhs;
            }
            else
            {
                return (half2)lhs != rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator < (short lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs < (float2)rhs;
            }
            else
            {
                return (half2)lhs < rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator > (short lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs > (float2)rhs;
            }
            else
            {
                return (half2)lhs > rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator <= (short lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs <= (float2)rhs;
            }
            else
            {
                return (half2)lhs <= rhs;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 operator >= (short lhs, half2 rhs)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return lhs >= (float2)rhs;
            }
            else
            {
                return (half2)lhs >= rhs;
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yxy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yyy; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.xx; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.xy; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.xy = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public half2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get { return __x0.yx; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { __x0.yx = value; }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly half2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return __x0.yy; }
        }

        
        public half this[int index]
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
        public readonly bool Equals(half other) => math.all(this == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.half other) => math.all(this == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(half2 other) => math.all(this == other);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(Unity.Mathematics.half2 other) => math.all(this == other);

        public override readonly bool Equals(object o) => (o is half2 converted && Equals(converted)) || (o is Unity.Mathematics.half2 convertedU && Equals(convertedU)) || (o is half2 convertedS && Equals(convertedS)) || (o is Unity.Mathematics.half convertedSU && Equals(convertedSU)); 


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString()
        {
            return string.Format("half2({0}, {1})", x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("half2({0}, {1})", x.ToString(format, formatProvider), y.ToString(format, formatProvider));
        }
    }
}
