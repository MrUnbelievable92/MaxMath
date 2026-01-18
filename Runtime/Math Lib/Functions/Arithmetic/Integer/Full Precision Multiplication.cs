using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using Unity.Burst;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Computes the full unsigned 256-bit product of two <see cref="UInt128"/> values, returning the respective 128 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(UInt128 x, UInt128 y, [NoAlias] out UInt128 lo, [NoAlias] out UInt128 hi)
        {
            __UInt256__ t = __UInt256__.umul256(x, y);
            lo = t.lo128;
            hi = t.hi128;
        }


        /// <summary>       Computes the full unsigned 16-bit product of two <see langword="byte"/> values, returning the respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(byte x, byte y, [NoAlias] out byte lo, [NoAlias] out byte hi)
        {
            int full = x * y;
            lo = (byte)full;
            hi = (byte)(full >> 8);
        }
        
        /// <summary>       Computes the componentwise full unsigned 16-bit products of two <see cref="MaxMath.byte2"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(byte2 x, byte2 y, [NoAlias] out byte2 lo, [NoAlias] out byte2 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi8(x, y, 2);
                hi = Xse.mulhi_epu8(x, y, 2);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 16-bit products of two <see cref="MaxMath.byte3"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(byte3 x, byte3 y, [NoAlias] out byte3 lo, [NoAlias] out byte3 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi8(x, y, 3);
                hi = Xse.mulhi_epu8(x, y, 3);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 16-bit products of two <see cref="MaxMath.byte4"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(byte4 x, byte4 y, [NoAlias] out byte4 lo, [NoAlias] out byte4 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi8(x, y, 4);
                hi = Xse.mulhi_epu8(x, y, 4);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
                mulwide(x.w, y.w, out lo.w, out hi.w);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 16-bit products of two <see cref="MaxMath.byte8"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(byte8 x, byte8 y, [NoAlias] out byte8 lo, [NoAlias] out byte8 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi8(x, y, 8);
                hi = Xse.mulhi_epu8(x, y, 8);
            }
            else
            {
                mulwide(x.x0, y.x0, out lo.x0, out hi.x0);
                mulwide(x.x1, y.x1, out lo.x1, out hi.x1);
                mulwide(x.x2, y.x2, out lo.x2, out hi.x2);
                mulwide(x.x3, y.x3, out lo.x3, out hi.x3);
                mulwide(x.x4, y.x4, out lo.x4, out hi.x4);
                mulwide(x.x5, y.x5, out lo.x5, out hi.x5);
                mulwide(x.x6, y.x6, out lo.x6, out hi.x6);
                mulwide(x.x7, y.x7, out lo.x7, out hi.x7);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 16-bit products of two <see cref="MaxMath.byte16"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(byte16 x, byte16 y, [NoAlias] out byte16 lo, [NoAlias] out byte16 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi8(x, y);
                hi = Xse.mulhi_epu8(x, y);
            }
            else
            {
                mulwide(x.x0,  y.x0,  out lo.x0,  out hi.x0);
                mulwide(x.x1,  y.x1,  out lo.x1,  out hi.x1);
                mulwide(x.x2,  y.x2,  out lo.x2,  out hi.x2);
                mulwide(x.x3,  y.x3,  out lo.x3,  out hi.x3);
                mulwide(x.x4,  y.x4,  out lo.x4,  out hi.x4);
                mulwide(x.x5,  y.x5,  out lo.x5,  out hi.x5);
                mulwide(x.x6,  y.x6,  out lo.x6,  out hi.x6);
                mulwide(x.x7,  y.x7,  out lo.x7,  out hi.x7);
                mulwide(x.x8,  y.x8,  out lo.x8,  out hi.x8);
                mulwide(x.x9,  y.x9,  out lo.x9,  out hi.x9);
                mulwide(x.x10, y.x10, out lo.x10, out hi.x10);
                mulwide(x.x11, y.x11, out lo.x11, out hi.x11);
                mulwide(x.x12, y.x12, out lo.x12, out hi.x12);
                mulwide(x.x13, y.x13, out lo.x13, out hi.x13);
                mulwide(x.x14, y.x14, out lo.x14, out hi.x14);
                mulwide(x.x15, y.x15, out lo.x15, out hi.x15);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 16-bit products of two <see cref="MaxMath.byte32"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(byte32 x, byte32 y, [NoAlias] out byte32 lo, [NoAlias] out byte32 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Xse.mm256_mullo_epi8(x, y);
                hi = Xse.mm256_mulhi_epu8(x, y);
            }
            else
            {
                mulwide(x.v16_0,  y.v16_0,  out byte16 lolo, out byte16 hilo);
                mulwide(x.v16_16, y.v16_16, out byte16 lohi, out byte16 hihi);

                lo = new byte32(lolo, lohi);
                hi = new byte32(hilo, hihi);
            }
        }


        /// <summary>       Computes the full unsigned 32-bit product of two <see langword="ushort"/> values, returning the respective 16 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(ushort x, ushort y, [NoAlias] out ushort lo, [NoAlias] out ushort hi)
        {
            int full = x * y;
            lo = (ushort)full;
            hi = (ushort)(full >> 16);
        }
        
        /// <summary>       Computes the componentwise full unsigned 32-bit products of two <see cref="MaxMath.ushort2"/> values, returning the packed, respective 16 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(ushort2 x, ushort2 y, [NoAlias] out ushort2 lo, [NoAlias] out ushort2 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi16(x, y);
                hi = Xse.mulhi_epu16(x, y);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 32-bit products of two <see cref="MaxMath.ushort3"/> values, returning the packed, respective 16 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(ushort3 x, ushort3 y, [NoAlias] out ushort3 lo, [NoAlias] out ushort3 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi16(x, y);
                hi = Xse.mulhi_epu16(x, y);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 32-bit products of two <see cref="MaxMath.ushort4"/> values, returning the packed, respective 16 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(ushort4 x, ushort4 y, [NoAlias] out ushort4 lo, [NoAlias] out ushort4 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi16(x, y);
                hi = Xse.mulhi_epu16(x, y);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
                mulwide(x.w, y.w, out lo.w, out hi.w);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 32-bit products of two <see cref="MaxMath.ushort8"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(ushort8 x, ushort8 y, [NoAlias] out ushort8 lo, [NoAlias] out ushort8 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi16(x, y);
                hi = Xse.mulhi_epu16(x, y);
            }
            else
            {
                mulwide(x.x0, y.x0, out lo.x0, out hi.x0);
                mulwide(x.x1, y.x1, out lo.x1, out hi.x1);
                mulwide(x.x2, y.x2, out lo.x2, out hi.x2);
                mulwide(x.x3, y.x3, out lo.x3, out hi.x3);
                mulwide(x.x4, y.x4, out lo.x4, out hi.x4);
                mulwide(x.x5, y.x5, out lo.x5, out hi.x5);
                mulwide(x.x6, y.x6, out lo.x6, out hi.x6);
                mulwide(x.x7, y.x7, out lo.x7, out hi.x7);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 32-bit products of two <see cref="MaxMath.ushort16"/> values, returning the packed, respective 16 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(ushort16 x, ushort16 y, [NoAlias] out ushort16 lo, [NoAlias] out ushort16 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Avx2.mm256_mullo_epi16(x, y);
                hi = Avx2.mm256_mulhi_epu16(x, y);
            }
            else
            {
                mulwide(x.v8_0, y.v8_0, out ushort8 lolo, out ushort8 hilo);
                mulwide(x.v8_8, y.v8_8, out ushort8 lohi, out ushort8 hihi);

                lo = new ushort16(lolo, lohi);
                hi = new ushort16(hilo, hihi);
            }
        }


        /// <summary>       Computes the full unsigned 64-bit product of two <see langword="uint"/> values, returning the respective 32 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(uint x, uint y, [NoAlias] out uint lo, [NoAlias] out uint hi)
        {
            ulong full = (ulong)x * (ulong)y;
            lo = (uint)full;
            hi = (uint)(full >> 32);
        }
        
        /// <summary>       Computes the componentwise full unsigned 64-bit products of two <see cref="uint2"/> values, returning the packed, respective 32 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(uint2 x, uint2 y, [NoAlias] out uint2 lo, [NoAlias] out uint2 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = RegisterConversion.ToUInt2(Xse.mullo_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
                hi = RegisterConversion.ToUInt2(Xse.mulhi_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 64-bit products of two <see cref="uint3"/> values, returning the packed, respective 32 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(uint3 x, uint3 y, [NoAlias] out uint3 lo, [NoAlias] out uint3 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = RegisterConversion.ToUInt3(Xse.mullo_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
                hi = RegisterConversion.ToUInt3(Xse.mulhi_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 64-bit products of two <see cref="uint4"/> values, returning the packed, respective 32 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(uint4 x, uint4 y, [NoAlias] out uint4 lo, [NoAlias] out uint4 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = RegisterConversion.ToUInt4(Xse.mullo_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
                hi = RegisterConversion.ToUInt4(Xse.mulhi_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
                mulwide(x.w, y.w, out lo.w, out hi.w);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 64-bit products of two <see cref="MaxMath.uint32"/> values, returning the packed, respective 32 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(uint8 x, uint8 y, [NoAlias] out uint8 lo, [NoAlias] out uint8 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Avx2.mm256_mullo_epi32(x, y);
                hi = Xse.mm256_mulhi_epu32(x, y);
            }
            else
            {
                mulwide(x.v4_0, y.v4_0, out uint4 lov4_0, out uint4 hiv4_0);
                mulwide(x.v4_4, y.v4_4, out uint4 lov4_4, out uint4 hiv4_4);

                lo = new uint8(lov4_0, lov4_4);
                hi = new uint8(hiv4_0, hiv4_4);
            }
        }


        /// <summary>       Computes the full unsigned 128-bit product of two <see langword="ulong"/> values, returning the respective 64 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(ulong x, ulong y, [NoAlias] out ulong lo, [NoAlias] out ulong hi)
        {
            lo = Common.umul128(x, y, out hi);
        }
        
        /// <summary>       Computes the componentwise full unsigned 128-bit products of two <see cref="MaxMath.ulong2"/> values, returning the packed, respective 64 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(ulong2 x, ulong2 y, [NoAlias] out ulong2 lo, [NoAlias] out ulong2 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi64(x, y);
                hi = Xse.mulhi_epu64(x, y);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 128-bit products of two <see cref="MaxMath.ulong3"/> values, returning the packed, respective 64 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(ulong3 x, ulong3 y, [NoAlias] out ulong3 lo, [NoAlias] out ulong3 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Xse.mm256_mullo_epi64(x, y, 3);
                hi = Xse.mm256_mulhi_epu64(x, y, 3);
            }
            else
            {
                mulwide(x.xy, y.xy, out ulong2 loxy, out ulong2 hixy);
                mulwide(x.z, y.z, out ulong loz, out ulong hiz);

                lo = new ulong3(loxy, loz);
                hi = new ulong3(hixy, hiz);
            }
        }
        
        /// <summary>       Computes the componentwise full unsigned 128-bit products of two <see cref="MaxMath.ulong4"/> values, returning the packed, respective 64 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(ulong4 x, ulong4 y, [NoAlias] out ulong4 lo, [NoAlias] out ulong4 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Xse.mm256_mullo_epi64(x, y);
                hi = Xse.mm256_mulhi_epu64(x, y);
            }
            else
            {
                mulwide(x.xy, y.xy, out ulong2 loxy, out ulong2 hixy);
                mulwide(x.zw, y.zw, out ulong2 lozw, out ulong2 hizw);

                lo = new ulong4(loxy, lozw);
                hi = new ulong4(hixy, hizw);
            }
        }


        /// <summary>       Computes the full signed 256-bit product of two <see cref="UInt128"/> values, returning the respective 128 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(Int128 x, Int128 y, [NoAlias] out Int128 lo, [NoAlias] out Int128 hi)
        {
            __UInt256__ t = __UInt256__.imul256(x, y);
            lo = (Int128)t.lo128;
            hi = (Int128)t.hi128;
        }


        /// <summary>       Computes the full signed 16-bit product of two <see langword="sbyte"/> values, returning the respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(sbyte x, sbyte y, [NoAlias] out sbyte lo, [NoAlias] out sbyte hi)
        {
            int full = x * y;
            lo = (sbyte)full;
            hi = (sbyte)(full >> 8);
        }
        
        /// <summary>       Computes the componentwise full signed 16-bit products of two <see cref="MaxMath.sbyte2"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(sbyte2 x, sbyte2 y, [NoAlias] out sbyte2 lo, [NoAlias] out sbyte2 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi8(x, y, 2);
                hi = Xse.mulhi_epi8(x, y, 2);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 16-bit products of two <see cref="MaxMath.sbyte3"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(sbyte3 x, sbyte3 y, [NoAlias] out sbyte3 lo, [NoAlias] out sbyte3 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi8(x, y, 3);
                hi = Xse.mulhi_epi8(x, y, 3);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 16-bit products of two <see cref="MaxMath.sbyte4"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(sbyte4 x, sbyte4 y, [NoAlias] out sbyte4 lo, [NoAlias] out sbyte4 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi8(x, y, 4);
                hi = Xse.mulhi_epi8(x, y, 4);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
                mulwide(x.w, y.w, out lo.w, out hi.w);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 16-bit products of two <see cref="MaxMath.sbyte8"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(sbyte8 x, sbyte8 y, [NoAlias] out sbyte8 lo, [NoAlias] out sbyte8 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi8(x, y, 8);
                hi = Xse.mulhi_epi8(x, y, 8);
            }
            else
            {
                mulwide(x.x0, y.x0, out lo.x0, out hi.x0);
                mulwide(x.x1, y.x1, out lo.x1, out hi.x1);
                mulwide(x.x2, y.x2, out lo.x2, out hi.x2);
                mulwide(x.x3, y.x3, out lo.x3, out hi.x3);
                mulwide(x.x4, y.x4, out lo.x4, out hi.x4);
                mulwide(x.x5, y.x5, out lo.x5, out hi.x5);
                mulwide(x.x6, y.x6, out lo.x6, out hi.x6);
                mulwide(x.x7, y.x7, out lo.x7, out hi.x7);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 16-bit products of two <see cref="MaxMath.sbyte16"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(sbyte16 x, sbyte16 y, [NoAlias] out sbyte16 lo, [NoAlias] out sbyte16 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi8(x, y);
                hi = Xse.mulhi_epi8(x, y);
            }
            else
            {
                mulwide(x.x0,  y.x0,  out lo.x0,  out hi.x0);
                mulwide(x.x1,  y.x1,  out lo.x1,  out hi.x1);
                mulwide(x.x2,  y.x2,  out lo.x2,  out hi.x2);
                mulwide(x.x3,  y.x3,  out lo.x3,  out hi.x3);
                mulwide(x.x4,  y.x4,  out lo.x4,  out hi.x4);
                mulwide(x.x5,  y.x5,  out lo.x5,  out hi.x5);
                mulwide(x.x6,  y.x6,  out lo.x6,  out hi.x6);
                mulwide(x.x7,  y.x7,  out lo.x7,  out hi.x7);
                mulwide(x.x8,  y.x8,  out lo.x8,  out hi.x8);
                mulwide(x.x9,  y.x9,  out lo.x9,  out hi.x9);
                mulwide(x.x10, y.x10, out lo.x10, out hi.x10);
                mulwide(x.x11, y.x11, out lo.x11, out hi.x11);
                mulwide(x.x12, y.x12, out lo.x12, out hi.x12);
                mulwide(x.x13, y.x13, out lo.x13, out hi.x13);
                mulwide(x.x14, y.x14, out lo.x14, out hi.x14);
                mulwide(x.x15, y.x15, out lo.x15, out hi.x15);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 16-bit products of two <see cref="MaxMath.sbyte32"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(sbyte32 x, sbyte32 y, [NoAlias] out sbyte32 lo, [NoAlias] out sbyte32 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Xse.mm256_mullo_epi8(x, y);
                hi = Xse.mm256_mulhi_epi8(x, y);
            }
            else
            {
                mulwide(x.v16_0,  y.v16_0,  out sbyte16 lolo, out sbyte16 hilo);
                mulwide(x.v16_16, y.v16_16, out sbyte16 lohi, out sbyte16 hihi);

                lo = new sbyte32(lolo, lohi);
                hi = new sbyte32(hilo, hihi);
            }
        }


        /// <summary>       Computes the full signed 32-bit product of two <see langword="short"/> values, returning the respective 16 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(short x, short y, [NoAlias] out short lo, [NoAlias] out short hi)
        {
            int full = x * y;
            lo = (short)full;
            hi = (short)(full >> 16);
        }
        
        /// <summary>       Computes the componentwise full signed 32-bit products of two <see cref="MaxMath.short2"/> values, returning the packed, respective 16 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(short2 x, short2 y, [NoAlias] out short2 lo, [NoAlias] out short2 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi16(x, y);
                hi = Xse.mulhi_epi16(x, y);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 32-bit products of two <see cref="MaxMath.short3"/> values, returning the packed, respective 16 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(short3 x, short3 y, [NoAlias] out short3 lo, [NoAlias] out short3 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi16(x, y);
                hi = Xse.mulhi_epi16(x, y);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 32-bit products of two <see cref="MaxMath.short4"/> values, returning the packed, respective 16 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(short4 x, short4 y, [NoAlias] out short4 lo, [NoAlias] out short4 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi16(x, y);
                hi = Xse.mulhi_epi16(x, y);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
                mulwide(x.w, y.w, out lo.w, out hi.w);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 32-bit products of two <see cref="MaxMath.short8"/> values, returning the packed, respective 8 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(short8 x, short8 y, [NoAlias] out short8 lo, [NoAlias] out short8 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi16(x, y);
                hi = Xse.mulhi_epi16(x, y);
            }
            else
            {
                mulwide(x.x0, y.x0, out lo.x0, out hi.x0);
                mulwide(x.x1, y.x1, out lo.x1, out hi.x1);
                mulwide(x.x2, y.x2, out lo.x2, out hi.x2);
                mulwide(x.x3, y.x3, out lo.x3, out hi.x3);
                mulwide(x.x4, y.x4, out lo.x4, out hi.x4);
                mulwide(x.x5, y.x5, out lo.x5, out hi.x5);
                mulwide(x.x6, y.x6, out lo.x6, out hi.x6);
                mulwide(x.x7, y.x7, out lo.x7, out hi.x7);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 32-bit products of two <see cref="MaxMath.short16"/> values, returning the packed, respective 16 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(short16 x, short16 y, [NoAlias] out short16 lo, [NoAlias] out short16 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Avx2.mm256_mullo_epi16(x, y);
                hi = Avx2.mm256_mulhi_epi16(x, y);
            }
            else
            {
                mulwide(x.v8_0, y.v8_0, out short8 lolo, out short8 hilo);
                mulwide(x.v8_8, y.v8_8, out short8 lohi, out short8 hihi);

                lo = new short16(lolo, lohi);
                hi = new short16(hilo, hihi);
            }
        }


        /// <summary>       Computes the full signed 64-bit product of two <see langword="int"/> values, returning the respective 32 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(int x, int y, [NoAlias] out int lo, [NoAlias] out int hi)
        {
            long full = (long)x * (long)y;
            lo = (int)full;
            hi = (int)(full >> 32);
        }
        
        /// <summary>       Computes the componentwise full signed 64-bit products of two <see cref="int2"/> values, returning the packed, respective 32 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(int2 x, int2 y, [NoAlias] out int2 lo, [NoAlias] out int2 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = RegisterConversion.ToInt2(Xse.mullo_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
                hi = RegisterConversion.ToInt2(Xse.mulhi_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 64-bit products of two <see cref="int3"/> values, returning the packed, respective 32 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(int3 x, int3 y, [NoAlias] out int3 lo, [NoAlias] out int3 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = RegisterConversion.ToInt3(Xse.mullo_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
                hi = RegisterConversion.ToInt3(Xse.mulhi_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 64-bit products of two <see cref="int4"/> values, returning the packed, respective 32 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(int4 x, int4 y, [NoAlias] out int4 lo, [NoAlias] out int4 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = RegisterConversion.ToInt4(Xse.mullo_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
                hi = RegisterConversion.ToInt4(Xse.mulhi_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
                mulwide(x.z, y.z, out lo.z, out hi.z);
                mulwide(x.w, y.w, out lo.w, out hi.w);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 64-bit products of two <see cref="MaxMath.int32"/> values, returning the packed, respective 32 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(int8 x, int8 y, [NoAlias] out int8 lo, [NoAlias] out int8 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Avx2.mm256_mullo_epi32(x, y);
                hi = Xse.mm256_mulhi_epi32(x, y);
            }
            else
            {
                mulwide(x.v4_0, y.v4_0, out int4 lov4_0, out int4 hiv4_0);
                mulwide(x.v4_4, y.v4_4, out int4 lov4_4, out int4 hiv4_4);

                lo = new int8(lov4_0, lov4_4);
                hi = new int8(hiv4_0, hiv4_4);
            }
        }


        /// <summary>       Computes the full signed 128-bit product of two <see langword="long"/> values, returning the respective 64 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(long x, long y, [NoAlias] out long lo, [NoAlias] out long hi)
        {
            mulwide((ulong)x, (ulong)y, out ulong ulo, out ulong uhi);
            lo = (long)ulo;
            hi = (long)uhi;

            if (constexpr.IS_TRUE(x >= 0 && y >= 0))
            {
                ;
            }
            else
            {
                hi -= ((x >> 63) & y) + ((y >> 63) & x);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 128-bit products of two <see cref="MaxMath.long2"/> values, returning the packed, respective 64 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(long2 x, long2 y, [NoAlias] out long2 lo, [NoAlias] out long2 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                lo = Xse.mullo_epi64(x, y);
                hi = Xse.mulhi_epi64(x, y);
            }
            else
            {
                mulwide(x.x, y.x, out lo.x, out hi.x);
                mulwide(x.y, y.y, out lo.y, out hi.y);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 128-bit products of two <see cref="MaxMath.long3"/> values, returning the packed, respective 64 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(long3 x, long3 y, [NoAlias] out long3 lo, [NoAlias] out long3 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Xse.mm256_mullo_epi64(x, y, 3);
                hi = Xse.mm256_mulhi_epi64(x, y, 3);
            }
            else
            {
                mulwide(x.xy, y.xy, out long2 loxy, out long2 hixy);
                mulwide(x.z, y.z, out long loz, out long hiz);

                lo = new long3(loxy, loz);
                hi = new long3(hixy, hiz);
            }
        }
        
        /// <summary>       Computes the componentwise full signed 128-bit products of two <see cref="MaxMath.long4"/> values, returning the packed, respective 64 bit halves as <see langword="out"/> parameters.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mulwide(long4 x, long4 y, [NoAlias] out long4 lo, [NoAlias] out long4 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Xse.mm256_mullo_epi64(x, y);
                hi = Xse.mm256_mulhi_epi64(x, y);
            }
            else
            {
                mulwide(x.xy, y.xy, out long2 loxy, out long2 hixy);
                mulwide(x.zw, y.zw, out long2 lozw, out long2 hizw);

                lo = new long4(loxy, lozw);
                hi = new long4(hixy, hizw);
            }
        }
    }
}