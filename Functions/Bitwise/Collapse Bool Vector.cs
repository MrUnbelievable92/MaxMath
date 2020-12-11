using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        ///<summary>        Returns a bitmask representation of a bool8. Storing one 1 bit per component in LSB order, from lower to higher bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, byte.MaxValue)]
        public static int bitmask(bool8 value)
        {
Assert.IsBetween(*(byte*)&value.x0, 0, 1);
Assert.IsBetween(*(byte*)&value.x1, 0, 1);
Assert.IsBetween(*(byte*)&value.x2, 0, 1);
Assert.IsBetween(*(byte*)&value.x3, 0, 1);
Assert.IsBetween(*(byte*)&value.x4, 0, 1);
Assert.IsBetween(*(byte*)&value.x5, 0, 1);
Assert.IsBetween(*(byte*)&value.x6, 0, 1);
Assert.IsBetween(*(byte*)&value.x7, 0, 1);

            return byte.MaxValue & Sse2.movemask_epi8(Sse2.cmpeq_epi8(value, new byte8(1)));
        }

        ///<summary>        Returns a bitmask representation of a bool16. Storing one 1 bit per component in LSB order, from lower to higher bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, ushort.MaxValue)]
        public static int bitmask(bool16 value)
        {
Assert.IsBetween(*(byte*)&value.x0,  0, 1);
Assert.IsBetween(*(byte*)&value.x1,  0, 1);
Assert.IsBetween(*(byte*)&value.x2,  0, 1);
Assert.IsBetween(*(byte*)&value.x3,  0, 1);
Assert.IsBetween(*(byte*)&value.x4,  0, 1);
Assert.IsBetween(*(byte*)&value.x5,  0, 1);
Assert.IsBetween(*(byte*)&value.x6,  0, 1);
Assert.IsBetween(*(byte*)&value.x7,  0, 1);
Assert.IsBetween(*(byte*)&value.x8,  0, 1);
Assert.IsBetween(*(byte*)&value.x9,  0, 1);
Assert.IsBetween(*(byte*)&value.x10, 0, 1);
Assert.IsBetween(*(byte*)&value.x11, 0, 1);
Assert.IsBetween(*(byte*)&value.x12, 0, 1);
Assert.IsBetween(*(byte*)&value.x13, 0, 1);
Assert.IsBetween(*(byte*)&value.x14, 0, 1);
Assert.IsBetween(*(byte*)&value.x15, 0, 1);

            return Sse2.movemask_epi8(Sse2.cmpeq_epi8(value, new byte8(1)));
        }

        ///<summary>        Returns a bitmask representation of a bool32. Storing one 1 bit per component in LSB order, from lower to higher bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask(bool32 value)
        {
Assert.IsBetween(*(byte*)&value.x0,  0, 1);
Assert.IsBetween(*(byte*)&value.x1,  0, 1);
Assert.IsBetween(*(byte*)&value.x2,  0, 1);
Assert.IsBetween(*(byte*)&value.x3,  0, 1);
Assert.IsBetween(*(byte*)&value.x4,  0, 1);
Assert.IsBetween(*(byte*)&value.x5,  0, 1);
Assert.IsBetween(*(byte*)&value.x6,  0, 1);
Assert.IsBetween(*(byte*)&value.x7,  0, 1);
Assert.IsBetween(*(byte*)&value.x8,  0, 1);
Assert.IsBetween(*(byte*)&value.x9,  0, 1);
Assert.IsBetween(*(byte*)&value.x10, 0, 1);
Assert.IsBetween(*(byte*)&value.x11, 0, 1);
Assert.IsBetween(*(byte*)&value.x12, 0, 1);
Assert.IsBetween(*(byte*)&value.x13, 0, 1);
Assert.IsBetween(*(byte*)&value.x14, 0, 1);
Assert.IsBetween(*(byte*)&value.x15, 0, 1);
Assert.IsBetween(*(byte*)&value.x16, 0, 1);
Assert.IsBetween(*(byte*)&value.x17, 0, 1);
Assert.IsBetween(*(byte*)&value.x18, 0, 1);
Assert.IsBetween(*(byte*)&value.x19, 0, 1);
Assert.IsBetween(*(byte*)&value.x20, 0, 1);
Assert.IsBetween(*(byte*)&value.x21, 0, 1);
Assert.IsBetween(*(byte*)&value.x22, 0, 1);
Assert.IsBetween(*(byte*)&value.x23, 0, 1);
Assert.IsBetween(*(byte*)&value.x24, 0, 1);
Assert.IsBetween(*(byte*)&value.x25, 0, 1);
Assert.IsBetween(*(byte*)&value.x26, 0, 1);
Assert.IsBetween(*(byte*)&value.x27, 0, 1);
Assert.IsBetween(*(byte*)&value.x28, 0, 1);
Assert.IsBetween(*(byte*)&value.x29, 0, 1);
Assert.IsBetween(*(byte*)&value.x31, 0, 1);
Assert.IsBetween(*(byte*)&value.x30, 0, 1);

            return Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi8(value, new byte32(1)));
        }
    }
}
