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
        public static int bitmask(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            return byte.MaxValue & Sse2.movemask_epi8(Sse2.slli_epi16(x, 7));
        }

        ///<summary>        Returns a bitmask representation of a bool16. Storing one 1 bit per component in LSB order, from lower to higher bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, ushort.MaxValue)]
        public static int bitmask(bool16 x)
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

            return Sse2.movemask_epi8(Sse2.slli_epi16(x, 7));
        }

        ///<summary>        Returns a bitmask representation of a bool32. Storing one 1 bit per component in LSB order, from lower to higher bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask(bool32 x)
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
Assert.IsSafeBoolean(x.x31);
Assert.IsSafeBoolean(x.x30);

            return Avx2.mm256_movemask_epi8(Avx2.mm256_slli_epi16(x, 7));
        }
    }
}