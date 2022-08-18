using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="UInt128"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 touint128(bool a)
        { 
            return tobyte(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="Int128"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 toint128(bool a)
        { 
            return tobyte(a);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="byte"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobyte(bool a)
        { 
Assert.IsSafeBoolean(a);

            return *(byte*)&a;
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="MaxMath.byte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tobyte(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return *(byte2*)&x;
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="MaxMath.byte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tobyte(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return *(byte3*)&x;
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="MaxMath.byte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tobyte(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return *(byte4*)&x;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.byte8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tobyte(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            if (Sse2.IsSse2Supported)
            {
                return (v128)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.byte16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tobyte(bool16 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);

            if (Sse2.IsSse2Supported)
            {
                return (v128)x;
            }
            else
            {
                return *(byte16*)&x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as a <see cref="MaxMath.byte32"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tobyte(bool32 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);
Assert.IsSafeBoolean(x.x16);
Assert.IsSafeBoolean(x.x17);
Assert.IsSafeBoolean(x.x18);
Assert.IsSafeBoolean(x.x19);
Assert.IsSafeBoolean(x.x20);
Assert.IsSafeBoolean(x.x21);
Assert.IsSafeBoolean(x.x22);
Assert.IsSafeBoolean(x.x23);
Assert.IsSafeBoolean(x.x24);
Assert.IsSafeBoolean(x.x25);
Assert.IsSafeBoolean(x.x26);
Assert.IsSafeBoolean(x.x27);
Assert.IsSafeBoolean(x.x28);
Assert.IsSafeBoolean(x.x29);
Assert.IsSafeBoolean(x.x30);
Assert.IsSafeBoolean(x.x31);

            if (Avx2.IsAvx2Supported)
            {
                return (v256)x;
            }
            else if (Sse2.IsSse2Supported)
            {
                return new byte32 { _v16_0 = (v128)x._v16_0, _v16_16 = (v128)x._v16_16 };
            }
            else
            {
                return *(byte32*)&x;
            }
        }
        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="sbyte"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbyte(bool a)
        { 
Assert.IsSafeBoolean(a);

            return *(sbyte*)&a;
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as an <see cref="MaxMath.sbyte2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tosbyte(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return *(sbyte2*)&x;
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as an <see cref="MaxMath.sbyte3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tosbyte(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return *(sbyte3*)&x;
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as an <see cref="MaxMath.sbyte4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tosbyte(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return *(sbyte4*)&x;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.sbyte8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tosbyte(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            if (Sse2.IsSse2Supported)
            {
                return (v128)x;
            }
            else
            {
                return *(sbyte8*)&x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as an <see cref="MaxMath.sbyte16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tosbyte(bool16 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);

            if (Sse2.IsSse2Supported)
            {
                return (v128)x;
            }
            else
            {
                return *(sbyte16*)&x;
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool32"/> to its integer representation as an <see cref="MaxMath.sbyte32"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tosbyte(bool32 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);
Assert.IsSafeBoolean(x.x16);
Assert.IsSafeBoolean(x.x17);
Assert.IsSafeBoolean(x.x18);
Assert.IsSafeBoolean(x.x19);
Assert.IsSafeBoolean(x.x20);
Assert.IsSafeBoolean(x.x21);
Assert.IsSafeBoolean(x.x22);
Assert.IsSafeBoolean(x.x23);
Assert.IsSafeBoolean(x.x24);
Assert.IsSafeBoolean(x.x25);
Assert.IsSafeBoolean(x.x26);
Assert.IsSafeBoolean(x.x27);
Assert.IsSafeBoolean(x.x28);
Assert.IsSafeBoolean(x.x29);
Assert.IsSafeBoolean(x.x30);
Assert.IsSafeBoolean(x.x31);

            if (Avx2.IsAvx2Supported)
            {
                return (v256)x;
            }
            else if (Sse2.IsSse2Supported)
            {
                return new sbyte32 { _v16_0 = (v128)x._v16_0, _v16_16 = (v128)x._v16_16 };
            }
            else
            {
                return *(sbyte32*)&x;
            }
        }

        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ushort"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushort(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="MaxMath.ushort2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 toushort(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (ushort2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="MaxMath.ushort3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 toushort(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (ushort3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="MaxMath.ushort4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 toushort(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (ushort4)(*(byte4*)&x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.ushort8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 toushort(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            if (Sse2.IsSse2Supported)
            {
                return (ushort8)((byte8)(v128)x);
            }
            else
            {
                return (ushort8)(*(byte8*)&x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.ushort16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 toushort(bool16 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);

            if (Avx2.IsAvx2Supported)
            {
                return (ushort16)((byte16)(v128)x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new ushort16(tobyte(x.v8_0), tobyte(x.v8_8));
            }
            else
            {
                return (ushort16)(*(byte16*)&x);
            }
        }

        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="short"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshort(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="MaxMath.short2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 toshort(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (short2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="MaxMath.short3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 toshort(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (short3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="MaxMath.short4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 toshort(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (short4)(*(byte4*)&x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.short8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 toshort(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            if (Sse2.IsSse2Supported)
            {
                return (short8)((byte8)(v128)x);
            }
            else
            {
                return (short8)(*(byte8*)&x);
            }
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool16"/> to its integer representation as a <see cref="MaxMath.short16"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 toshort(bool16 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);
Assert.IsSafeBoolean(x.x8);
Assert.IsSafeBoolean(x.x9);
Assert.IsSafeBoolean(x.x10);
Assert.IsSafeBoolean(x.x11);
Assert.IsSafeBoolean(x.x12);
Assert.IsSafeBoolean(x.x13);
Assert.IsSafeBoolean(x.x14);
Assert.IsSafeBoolean(x.x15);

            if (Avx2.IsAvx2Supported)
            {
                return (short16)((byte16)(v128)x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new short16(tobyte(x.v8_0), tobyte(x.v8_8));
            }
            else
            {
                return (short16)(*(byte16*)&x);
            }
        }

        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="uint"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touint(bool a)
        { 
            return (uint)toint(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="uint2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 touint(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (uint2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="uint3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 touint(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (uint3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="uint4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 touint(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (uint4)(*(byte4*)&x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as a <see cref="MaxMath.uint8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 touint(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            if (Avx2.IsAvx2Supported)
            {
                return (uint8)((byte8)(v128)x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new uint8(touint(x.v4_0), touint(x.v4_4));
            }
            else
            {
                return (uint8)(*(byte8*)&x);
            }
        }

        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="int"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int toint(bool a)
        { 
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as an <see cref="int2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 toint(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (int2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as an <see cref="int3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 toint(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (int3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as an <see cref="int4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 toint(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (int4)(*(byte4*)&x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its integer representation as an <see cref="MaxMath.int8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 toint(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            if (Avx2.IsAvx2Supported)
            {
                return (int8)((byte8)(v128)x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new int8(toint(x.v4_0), toint(x.v4_4));
            }
            else
            {
                return (int8)(*(byte8*)&x);
            }
        }

        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ulong"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulong(bool a)
        { 
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="MaxMath.ulong2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 toulong(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (ulong2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="MaxMath.ulong3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 toulong(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (ulong3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="MaxMath.ulong4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 toulong(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (ulong4)(*(byte4*)&x);
        }

        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="long"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolong(bool a)
        { 
            return tobyte(a);
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its integer representation as a <see cref="MaxMath.long2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tolong(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (long2)(*(byte2*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its integer representation as a <see cref="MaxMath.long3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tolong(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            return (long3)(*(byte3*)&x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its integer representation as a <see cref="MaxMath.long4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tolong(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (long4)(*(byte4*)&x);
        }

        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="quarter"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarter(bool a)
        {
            return new quarter((byte)(-tosbyte(a) & ((quarter)1f).value));
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its floating point representation as a <see cref="MaxMath.quarter2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 toquarter(bool2 x)
        {
            return asquarter(select(default(byte2), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its floating point representation as a <see cref="MaxMath.quarter3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 toquarter(bool3 x)
        {
            return asquarter(select(default(byte3), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its floating point representation as a <see cref="MaxMath.quarter4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 toquarter(bool4 x)
        {
            return asquarter(select(default(byte4), ((quarter)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.quarter8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 toquarter(bool8 x)
        {
            return asquarter(select(default(byte8), ((quarter)1f).value, x));
        }

        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="half"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalf(bool a)
        { 
            return new half { value = (ushort)(-tosbyte(a) & ((half)1f).value) };
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its floating point representation as a <see cref="half2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 tohalf(bool2 x)
        {
            return ashalf(select(default(ushort2), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its floating point representation as a <see cref="half3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 tohalf(bool3 x)
        {
            return ashalf(select(default(ushort3), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its floating point representation as a <see cref="half4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 tohalf(bool4 x)
        {
            return ashalf(select(default(ushort4), ((half)1f).value, x));
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.half8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 tohalf(bool8 x)
        {
            return ashalf(select(default(ushort8), ((half)1f).value, x));
        }

        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="float"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloat(bool a)
        { 
            return math.asfloat(-tosbyte(a) & math.asint(1f));
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its floating point representation as a <see cref="float2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tofloat(bool2 x)
        {
            return math.select(default(float2), new float2(1f), x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its floating point representation as a <see cref="float3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tofloat(bool3 x)
        {
            return math.select(default(float3), new float3(1f), x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its floating point representation as a <see cref="float4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tofloat(bool4 x)
        {
            return math.select(default(float4), new float4(1f), x);
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.bool8"/> to its floating point representation as a <see cref="MaxMath.float8"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tofloat(bool8 x)
        {
            return select(default(float8), new float8(1f), x);
        }

        
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="double"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todouble(bool a)
        { 
            return math.asdouble(-(long)toulong(a) & math.aslong(1d));
        }

        /// <summary>       Converts each value in a <see cref="bool2"/> to its floating point representation as a <see cref="double2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 todouble(bool2 x)
        {
            return math.select(default(double2), new double2(1d), x);
        }

        /// <summary>       Converts each value in a <see cref="bool3"/> to its floating point representation as a <see cref="double3"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 todouble(bool3 x)
        {
            return math.select(default(double3), new double3(1d), x);
        }

        /// <summary>       Converts each value in a <see cref="bool4"/> to its floating point representation as a <see cref="double4"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 todouble(bool4 x)
        {
            return math.select(default(double4), new double4(1d), x);
        }

        
        /// <summary>       Converts a <see cref="byte"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(byte a)
        { 
Assert.IsBetween(a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.byte2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(byte2 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);

            return *(bool2*)&x;
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.byte3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(byte3 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);

            return *(bool3*)&x;
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.byte4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(byte4 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);
Assert.IsBetween(x.w, 0, 1);

            return *(bool4*)&x;
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.byte8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(byte8 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);

            if (Sse2.IsSse2Supported)
            {
                return (v128)x;
            }
            else
            {
                return *(bool8*)&x;
            }
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.byte16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(byte16 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x9,  0, 1);
Assert.IsBetween(x.x10, 0, 1);
Assert.IsBetween(x.x11, 0, 1);
Assert.IsBetween(x.x12, 0, 1);
Assert.IsBetween(x.x13, 0, 1);
Assert.IsBetween(x.x14, 0, 1);
Assert.IsBetween(x.x15, 0, 1);

            if (Sse2.IsSse2Supported)
            {
                return (v128)x;
            }
            else
            {
                return *(bool16*)&x;
            }
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.byte32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool(byte32 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);
Assert.IsBetween(x.x8,  0, 1);
Assert.IsBetween(x.x9,  0, 1);
Assert.IsBetween(x.x10, 0, 1);
Assert.IsBetween(x.x11, 0, 1);
Assert.IsBetween(x.x12, 0, 1);
Assert.IsBetween(x.x13, 0, 1);
Assert.IsBetween(x.x14, 0, 1);
Assert.IsBetween(x.x15, 0, 1);
Assert.IsBetween(x.x16, 0, 1);
Assert.IsBetween(x.x17, 0, 1);
Assert.IsBetween(x.x18, 0, 1);
Assert.IsBetween(x.x19, 0, 1);
Assert.IsBetween(x.x20, 0, 1);
Assert.IsBetween(x.x21, 0, 1);
Assert.IsBetween(x.x22, 0, 1);
Assert.IsBetween(x.x23, 0, 1);
Assert.IsBetween(x.x24, 0, 1);
Assert.IsBetween(x.x25, 0, 1);
Assert.IsBetween(x.x26, 0, 1);
Assert.IsBetween(x.x27, 0, 1);
Assert.IsBetween(x.x28, 0, 1);
Assert.IsBetween(x.x29, 0, 1);
Assert.IsBetween(x.x30, 0, 1);
Assert.IsBetween(x.x31, 0, 1);

            if (Avx2.IsAvx2Supported)
            {
                return (v256)x;
            }
            else if (Sse2.IsSse2Supported)
            {
                return new bool32 { _v16_0 = (v128)x._v16_0, _v16_16 = (v128)x._v16_16 };
            }
            else
            {
                return *(bool32*)&x;
            }
        }


        /// <summary>       Converts an <see cref="sbyte"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(sbyte a)
        { 
Assert.IsBetween(a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(sbyte2 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);

            return *(bool2*)&x;
        }
        
        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(sbyte3 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);

            return *(bool3*)&x;
        }
        
        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(sbyte4 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);
Assert.IsBetween(x.w, 0, 1);

            return *(bool4*)&x;
        }
        
        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(sbyte8 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);

            if (Sse2.IsSse2Supported)
            {
                return (v128)x;
            }
            else
            {
                return *(bool8*)&x;
            }
        }
        
        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(sbyte16 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);
Assert.IsBetween(x.x8,  0, 1);
Assert.IsBetween(x.x9,  0, 1);
Assert.IsBetween(x.x10, 0, 1);
Assert.IsBetween(x.x11, 0, 1);
Assert.IsBetween(x.x12, 0, 1);
Assert.IsBetween(x.x13, 0, 1);
Assert.IsBetween(x.x14, 0, 1);
Assert.IsBetween(x.x15, 0, 1);

            if (Sse2.IsSse2Supported)
            {
                return (v128)x;
            }
            else
            {
                return *(bool16*)&x;
            }
        }
        
        /// <summary>       Converts each value in an <see cref="MaxMath.sbyte32"/> to its boolean representation as a <see cref="MaxMath.bool32"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool(sbyte32 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);
Assert.IsBetween(x.x8,  0, 1);
Assert.IsBetween(x.x9,  0, 1);
Assert.IsBetween(x.x10, 0, 1);
Assert.IsBetween(x.x11, 0, 1);
Assert.IsBetween(x.x12, 0, 1);
Assert.IsBetween(x.x13, 0, 1);
Assert.IsBetween(x.x14, 0, 1);
Assert.IsBetween(x.x15, 0, 1);
Assert.IsBetween(x.x16, 0, 1);
Assert.IsBetween(x.x17, 0, 1);
Assert.IsBetween(x.x18, 0, 1);
Assert.IsBetween(x.x19, 0, 1);
Assert.IsBetween(x.x20, 0, 1);
Assert.IsBetween(x.x21, 0, 1);
Assert.IsBetween(x.x22, 0, 1);
Assert.IsBetween(x.x23, 0, 1);
Assert.IsBetween(x.x24, 0, 1);
Assert.IsBetween(x.x25, 0, 1);
Assert.IsBetween(x.x26, 0, 1);
Assert.IsBetween(x.x27, 0, 1);
Assert.IsBetween(x.x28, 0, 1);
Assert.IsBetween(x.x29, 0, 1);
Assert.IsBetween(x.x30, 0, 1);
Assert.IsBetween(x.x31, 0, 1);

            if (Avx2.IsAvx2Supported)
            {
                return (v256)x;
            }
            else if (Sse2.IsSse2Supported)
            {
                return new bool32 { _v16_0 = (v128)x._v16_0, _v16_16 = (v128)x._v16_16 };
            }
            else
            {
                return *(bool32*)&x;
            }
        }

        
        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(short a)
        { 
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.short2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(short2 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
            
            if (Sse2.IsSse2Supported)
            {
                v128 res = Sse2.packs_epi16(x, x);

                return *(bool*)&res;
            }

            return tobool((byte2)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.short3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(short3 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);

            if (Sse2.IsSse2Supported)
            {
                RegisterConversion.ToType<bool3>(Sse2.packs_epi16(x, x));
            }

            return tobool((byte3)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.short4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(short4 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);
Assert.IsBetween(x.w, 0, 1);

            if (Sse2.IsSse2Supported)
            {
                RegisterConversion.ToType<bool4>(Sse2.packs_epi16(x, x));
            }

            return tobool((byte4)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.short8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(short8 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);

            if (Sse2.IsSse2Supported)
            {
                return Sse2.packs_epi16(x, x);
            }

            return tobool((byte8)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.short16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(short16 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);
Assert.IsBetween(x.x8,  0, 1);
Assert.IsBetween(x.x9,  0, 1);
Assert.IsBetween(x.x10, 0, 1);
Assert.IsBetween(x.x11, 0, 1);
Assert.IsBetween(x.x12, 0, 1);
Assert.IsBetween(x.x13, 0, 1);
Assert.IsBetween(x.x14, 0, 1);
Assert.IsBetween(x.x15, 0, 1);

            if (Sse2.IsSse2Supported)
            {
                return Sse2.packs_epi16(x.v8_0, x.v8_8);
            }

            return tobool((byte16)x);
        }
        

        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(ushort a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }
        /// <summary>       Converts each value in a <see cref="MaxMath.ushort2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(ushort2 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
            
            if (Sse2.IsSse2Supported)
            {
                v128 res = Sse2.packs_epi16(x, x);

                return *(bool*)&res;
            }

            return tobool((byte2)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.ushort3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<bool3>(Sse2.packs_epi16(x, x));
            }

            return tobool((byte3)x);
        }
        
        /// <summary>       Converts each value in a ushor4 vector to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(ushort4 x)
        {
Assert.IsBetween(x.x, 0, 1);
Assert.IsBetween(x.y, 0, 1);
Assert.IsBetween(x.z, 0, 1);
Assert.IsBetween(x.w, 0, 1);

            if (Sse2.IsSse2Supported)
            {
                RegisterConversion.ToType<bool4>(Sse2.packs_epi16(x, x));
            }

            return tobool((byte4)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.ushort8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(ushort8 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);

            if (Sse2.IsSse2Supported)
            {
                return Sse2.packs_epi16(x, x);
            }

            return tobool((byte8)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.ushort16"/> to its boolean representation as a <see cref="MaxMath.bool16"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool(ushort16 x)
        {
Assert.IsBetween(x.x0,  0, 1);
Assert.IsBetween(x.x1,  0, 1);
Assert.IsBetween(x.x2,  0, 1);
Assert.IsBetween(x.x3,  0, 1);
Assert.IsBetween(x.x4,  0, 1);
Assert.IsBetween(x.x5,  0, 1);
Assert.IsBetween(x.x6,  0, 1);
Assert.IsBetween(x.x7,  0, 1);
Assert.IsBetween(x.x8,  0, 1);
Assert.IsBetween(x.x9,  0, 1);
Assert.IsBetween(x.x10, 0, 1);
Assert.IsBetween(x.x11, 0, 1);
Assert.IsBetween(x.x12, 0, 1);
Assert.IsBetween(x.x13, 0, 1);
Assert.IsBetween(x.x14, 0, 1);
Assert.IsBetween(x.x15, 0, 1);

            if (Sse2.IsSse2Supported)
            {
                return Sse2.packs_epi16(x.v8_0, x.v8_8);
            }

            return tobool((byte16)x);
        }

        
        /// <summary>       Converts an <see cref="int"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static bool tobool(int a)
        { 
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in an <see cref="int2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(int2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return RegisterConversion.ToType<bool2>(Ssse3.shuffle_epi8(RegisterConversion.ToV128(x), new v128(0, 4, 8, 12,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 epi16 = Sse2.packs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(x));

                return RegisterConversion.ToType<bool2>(Sse2.packus_epi16(epi16, epi16));
            }
            else
            {
                return tobool((byte2)x);
            }
        }
        
        /// <summary>       Converts each value in an <see cref="int3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(int3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return RegisterConversion.ToType<bool3>(Ssse3.shuffle_epi8(RegisterConversion.ToV128(x), new v128(0, 4, 8, 12,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 epi16 = Sse2.packs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(x));

                return RegisterConversion.ToType<bool3>(Sse2.packus_epi16(epi16, epi16));
            }
            else
            {
                return tobool((byte3)x);
            }
        }
        
        /// <summary>       Converts each value in an <see cref="int4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(int4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return RegisterConversion.ToType<bool4>(Ssse3.shuffle_epi8(RegisterConversion.ToV128(x), new v128(0, 4, 8, 12,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 epi16 = Sse2.packs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(x));

                return RegisterConversion.ToType<bool4>(Sse2.packus_epi16(epi16, epi16));
            }
            else
            {
                return tobool((byte4)x);
            }
        }
        
        /// <summary>       Converts each value in an <see cref="MaxMath.int8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(int8 x)
        {
            return tobool((byte8)x);
        }

        
        /// <summary>       Converts a <see cref="uint"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(uint a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in a <see cref="uint2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(uint2 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return RegisterConversion.ToType<bool2>(Ssse3.shuffle_epi8(RegisterConversion.ToV128(x), new v128(0, 4, 8, 12,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 epi16 = Sse2.packs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(x));

                return RegisterConversion.ToType<bool2>(Sse2.packus_epi16(epi16, epi16));
            }
            else
            {
                return tobool((byte2)x);
            }
        }
        
        /// <summary>       Converts each value in a <see cref="uint3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(uint3 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return RegisterConversion.ToType<bool3>(Ssse3.shuffle_epi8(RegisterConversion.ToV128(x), new v128(0, 4, 8, 12,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 epi16 = Sse2.packs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(x));

                return RegisterConversion.ToType<bool3>(Sse2.packus_epi16(epi16, epi16));
            }
            else
            {
                return tobool((byte3)x);
            }
        }
        

        /// <summary>       Converts each value in a <see cref="uint4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(uint4 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return RegisterConversion.ToType<bool4>(Ssse3.shuffle_epi8(RegisterConversion.ToV128(x), new v128(0, 4, 8, 12,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 epi16 = Sse2.packs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(x));

                return RegisterConversion.ToType<bool4>(Sse2.packus_epi16(epi16, epi16));
            }
            else
            {
                return tobool((byte4)x);
            }
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.uint8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(uint8 x)
        {
            return tobool((byte8)x);
        }

        
        /// <summary>       Converts a <see cref="long"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(long a)
        {
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.long2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(long2 x)
        {
            return tobool((byte2)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.long3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(long3 x)
        {
            return tobool((byte3)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.long4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(long4 x)
        {
            return tobool((byte4)x);
        }

        
        /// <summary>       Converts a <see cref="ulong"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(ulong a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.ulong2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(ulong2 x)
        {
            return tobool((byte2)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.ulong3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(ulong3 x)
        {
            return tobool((byte3)x);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.ulong4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(ulong4 x)
        {
            return tobool((byte4)x);
        }

        
        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(quarter a)
        {
Assert.IsTrue(a.value == ((quarter)1f).value || a.value == 0 || a.value == 1 << 7);

            return a.value == ((quarter)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="MaxMath.quarter2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(quarter2 x)
        {
Assert.IsTrue(x.x == (quarter)0f || x.x == (quarter)1f);
Assert.IsTrue(x.y == (quarter)0f || x.y == (quarter)1f);

            return asbyte(x) == ((quarter)1f).value;
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.quarter3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(quarter3 x)
        {
Assert.IsTrue(x.x == (quarter)0f || x.x == (quarter)1f);
Assert.IsTrue(x.y == (quarter)0f || x.y == (quarter)1f);
Assert.IsTrue(x.z == (quarter)0f || x.z == (quarter)1f);

            return asbyte(x) == ((quarter)1f).value;
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.quarter4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(quarter4 x)
        {
Assert.IsTrue(x.x == (quarter)0f || x.x == (quarter)1f);
Assert.IsTrue(x.y == (quarter)0f || x.y == (quarter)1f);
Assert.IsTrue(x.z == (quarter)0f || x.z == (quarter)1f);
Assert.IsTrue(x.w == (quarter)0f || x.w == (quarter)1f);

            return asbyte(x) == ((quarter)1f).value;
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.quarter8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(quarter8 x)
        {
Assert.IsTrue(x.x0 == (quarter)0f || x.x0 == (quarter)1f);
Assert.IsTrue(x.x1 == (quarter)0f || x.x1 == (quarter)1f);
Assert.IsTrue(x.x2 == (quarter)0f || x.x2 == (quarter)1f);
Assert.IsTrue(x.x3 == (quarter)0f || x.x3 == (quarter)1f);
Assert.IsTrue(x.x4 == (quarter)0f || x.x4 == (quarter)1f);
Assert.IsTrue(x.x5 == (quarter)0f || x.x5 == (quarter)1f);
Assert.IsTrue(x.x6 == (quarter)0f || x.x6 == (quarter)1f);
Assert.IsTrue(x.x7 == (quarter)0f || x.x7 == (quarter)1f);

            return asbyte(x) == ((quarter)1f).value;
        }

        
        /// <summary>       Converts a <see cref="half"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(half a)
        {
Assert.IsTrue(a.value == ((half)1f).value || a.value == 0 || a.value == 1 << 15);

            return a.value == ((half)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="half2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(half2 x)
        {
Assert.IsTrue(x.x == 0f || x.x == (half)1f);
Assert.IsTrue(x.y == 0f || x.y == (half)1f);

            return asushort(x) == ((half)1f).value;
        }

        /// <summary>       Converts each value in a <see cref="half3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(half3 x)
        {
Assert.IsTrue(x.x == 0f || x.x == (half)1f);
Assert.IsTrue(x.y == 0f || x.y == (half)1f);
Assert.IsTrue(x.z == 0f || x.z == (half)1f);

            return asushort(x) == ((half)1f).value;
        }
        
        /// <summary>       Converts each value in a <see cref="half4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(half4 x)
        {
Assert.IsTrue(x.x == 0f || x.x == (half)1f);
Assert.IsTrue(x.y == 0f || x.y == (half)1f);
Assert.IsTrue(x.z == 0f || x.z == (half)1f);
Assert.IsTrue(x.w == 0f || x.w == (half)1f);

            return asushort(x) == ((half)1f).value;
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.half8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(half8 x)
        {
Assert.IsTrue(x.x0 == 0f || x.x0 == (half)1f);
Assert.IsTrue(x.x1 == 0f || x.x1 == (half)1f);
Assert.IsTrue(x.x2 == 0f || x.x2 == (half)1f);
Assert.IsTrue(x.x3 == 0f || x.x3 == (half)1f);
Assert.IsTrue(x.x4 == 0f || x.x4 == (half)1f);
Assert.IsTrue(x.x5 == 0f || x.x5 == (half)1f);
Assert.IsTrue(x.x6 == 0f || x.x6 == (half)1f);
Assert.IsTrue(x.x7 == 0f || x.x7 == (half)1f);

            return asushort(x) == ((half)1f).value;
        }
        

        /// <summary>       Converts a <see cref="float"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(float a)
        {
Assert.IsTrue(a == 1f || a == 0f);

            return math.asint(a) == math.asint(1f);
        }

        /// <summary> Converts each value in a <see cref="float2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(float2 x)
        {
Assert.IsTrue(x.x == 0f || x.x == 1f);
Assert.IsTrue(x.y == 0f || x.y == 1f);

            return math.asint(x) == math.asint(1f);
        }

        /// <summary>       Converts each value in a <see cref="float3"/> to its boolean representation as a <see cref="bool3"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(float3 x)
        {
Assert.IsTrue(x.x == 0f || x.x == 1f);
Assert.IsTrue(x.y == 0f || x.y == 1f);
Assert.IsTrue(x.z == 0f || x.z == 1f);

            return math.asint(x) == math.asint(1f);
        }
        
        /// <summary>       Converts each value in a <see cref="float4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(float4 x)
        {
Assert.IsTrue(x.x == 0f || x.x == 1f);
Assert.IsTrue(x.y == 0f || x.y == 1f);
Assert.IsTrue(x.z == 0f || x.z == 1f);
Assert.IsTrue(x.w == 0f || x.w == 1f);

            return math.asint(x) == math.asint(1f);
        }
        
        /// <summary>       Converts each value in a <see cref="MaxMath.float8"/> to its boolean representation as a <see cref="MaxMath.bool8"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool(float8 x)
        {
Assert.IsTrue(x.x0 == 0f || x.x0 == 1f);
Assert.IsTrue(x.x1 == 0f || x.x1 == 1f);
Assert.IsTrue(x.x2 == 0f || x.x2 == 1f);
Assert.IsTrue(x.x3 == 0f || x.x3 == 1f);
Assert.IsTrue(x.x4 == 0f || x.x4 == 1f);
Assert.IsTrue(x.x5 == 0f || x.x5 == 1f);
Assert.IsTrue(x.x6 == 0f || x.x6 == 1f);
Assert.IsTrue(x.x7 == 0f || x.x7 == 1f);

            return asint(x) == math.asint(1f);
        }
        

        /// <summary>       Converts a <see cref="double"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(double a)
        {
Assert.IsTrue(a == 1d || a == 0d);

            return math.aslong(a) == math.aslong(1d);
        }

        /// <summary>       Converts each value in a <see cref="double2"/> to its boolean representation as a <see cref="bool2"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool(double2 x)
        {
Assert.IsTrue(x.x == 0d || x.x == 1d);
Assert.IsTrue(x.y == 0d || x.y == 1d);

            return aslong(x) == math.aslong(1d);
        }

        /// <summary>       Converts each value in a <see cref="double3"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool(double3 x)
        {
Assert.IsTrue(x.x == 0d || x.x == 1d);
Assert.IsTrue(x.y == 0d || x.y == 1d);
Assert.IsTrue(x.z == 0d || x.z == 1d);

            return aslong(x) == math.aslong(1d);
        }
        
        /// <summary>       Converts each value in a <see cref="double4"/> to its boolean representation as a <see cref="bool4"/>. The corresponding value is expected to be either 0 or 1. 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool(double4 x)
        {
Assert.IsTrue(x.x == 0d || x.x == 1d);
Assert.IsTrue(x.y == 0d || x.y == 1d);
Assert.IsTrue(x.z == 0d || x.z == 1d);
Assert.IsTrue(x.w == 0d || x.w == 1d);

            return aslong(x) == math.aslong(1d);
        }
    }
}