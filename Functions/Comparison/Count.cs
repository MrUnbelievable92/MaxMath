using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary></summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 2)]
        public static int count(bool2 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);

            return math.countbits((int)(*(ushort*)&v));
        }

        /// <summary></summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 3)]
        public static int count(bool3 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);

            return math.countbits(*(int*)&v) & 0x00FF_FFFF;
        }

        /// <summary></summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 4)]
        public static int count(bool4 v)
        {
Assert.IsBetween(*(byte*)&v.x, 0, 1);
Assert.IsBetween(*(byte*)&v.y, 0, 1);
Assert.IsBetween(*(byte*)&v.z, 0, 1);
Assert.IsBetween(*(byte*)&v.w, 0, 1);

            return math.countbits(*(int*)&v);
        }

        /// <summary></summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 8)]
        public static int count(bool8 v)
        {
Assert.IsBetween(*(byte*)&v.x0, 0, 1);
Assert.IsBetween(*(byte*)&v.x1, 0, 1);
Assert.IsBetween(*(byte*)&v.x2, 0, 1);
Assert.IsBetween(*(byte*)&v.x3, 0, 1);
Assert.IsBetween(*(byte*)&v.x4, 0, 1);
Assert.IsBetween(*(byte*)&v.x5, 0, 1);
Assert.IsBetween(*(byte*)&v.x6, 0, 1);
Assert.IsBetween(*(byte*)&v.x7, 0, 1);

            return math.countbits(v.cast_long);
        }

        /// <summary></summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 16)]
        public static int count(bool16 v)
        {
Assert.IsBetween(*(byte*)&v.x0, 0, 1);
Assert.IsBetween(*(byte*)&v.x1, 0, 1);
Assert.IsBetween(*(byte*)&v.x2, 0, 1);
Assert.IsBetween(*(byte*)&v.x3, 0, 1);
Assert.IsBetween(*(byte*)&v.x4, 0, 1);
Assert.IsBetween(*(byte*)&v.x5, 0, 1);
Assert.IsBetween(*(byte*)&v.x6, 0, 1);
Assert.IsBetween(*(byte*)&v.x7, 0, 1);
Assert.IsBetween(*(byte*)&v.x8, 0, 1);
Assert.IsBetween(*(byte*)&v.x9, 0, 1);
Assert.IsBetween(*(byte*)&v.x10, 0, 1);
Assert.IsBetween(*(byte*)&v.x11, 0, 1);
Assert.IsBetween(*(byte*)&v.x12, 0, 1);
Assert.IsBetween(*(byte*)&v.x13, 0, 1);
Assert.IsBetween(*(byte*)&v.x14, 0, 1);
Assert.IsBetween(*(byte*)&v.x15, 0, 1);

            return math.countbits(Sse4_1.extract_epi64(v, 0)) + 
                   math.countbits(Sse4_1.extract_epi64(v, 1));
        }

        /// <summary></summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 32)]
        public static int count(bool32 v)
        {
Assert.IsBetween(*(byte*)&v.x0, 0, 1);
Assert.IsBetween(*(byte*)&v.x1, 0, 1);
Assert.IsBetween(*(byte*)&v.x2, 0, 1);
Assert.IsBetween(*(byte*)&v.x3, 0, 1);
Assert.IsBetween(*(byte*)&v.x4, 0, 1);
Assert.IsBetween(*(byte*)&v.x5, 0, 1);
Assert.IsBetween(*(byte*)&v.x6, 0, 1);
Assert.IsBetween(*(byte*)&v.x7, 0, 1);
Assert.IsBetween(*(byte*)&v.x8, 0, 1);
Assert.IsBetween(*(byte*)&v.x9, 0, 1);
Assert.IsBetween(*(byte*)&v.x10, 0, 1);
Assert.IsBetween(*(byte*)&v.x11, 0, 1);
Assert.IsBetween(*(byte*)&v.x12, 0, 1);
Assert.IsBetween(*(byte*)&v.x13, 0, 1);
Assert.IsBetween(*(byte*)&v.x14, 0, 1);
Assert.IsBetween(*(byte*)&v.x15, 0, 1);
Assert.IsBetween(*(byte*)&v.x16, 0, 1);
Assert.IsBetween(*(byte*)&v.x17, 0, 1);
Assert.IsBetween(*(byte*)&v.x18, 0, 1);
Assert.IsBetween(*(byte*)&v.x19, 0, 1);
Assert.IsBetween(*(byte*)&v.x20, 0, 1);
Assert.IsBetween(*(byte*)&v.x21, 0, 1);
Assert.IsBetween(*(byte*)&v.x22, 0, 1);
Assert.IsBetween(*(byte*)&v.x23, 0, 1);
Assert.IsBetween(*(byte*)&v.x24, 0, 1);
Assert.IsBetween(*(byte*)&v.x25, 0, 1);
Assert.IsBetween(*(byte*)&v.x26, 0, 1);
Assert.IsBetween(*(byte*)&v.x27, 0, 1);
Assert.IsBetween(*(byte*)&v.x28, 0, 1);
Assert.IsBetween(*(byte*)&v.x29, 0, 1);
Assert.IsBetween(*(byte*)&v.x30, 0, 1);
Assert.IsBetween(*(byte*)&v.x31, 0, 1);

            return math.countbits(Avx.mm256_extract_epi64(v, 0)) +
                   math.countbits(Avx.mm256_extract_epi64(v, 1)) +
                   math.countbits(Avx.mm256_extract_epi64(v, 2)) +
                   math.countbits(Avx.mm256_extract_epi64(v, 3));
        }
    }
}