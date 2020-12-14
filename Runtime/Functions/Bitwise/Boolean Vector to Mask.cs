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
        public static int bitmask(bool8 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);

            return byte.MaxValue & Sse2.movemask_epi8(Sse2.slli_epi16(v, 7));
        }

        ///<summary>        Returns a bitmask representation of a bool16. Storing one 1 bit per component in LSB order, from lower to higher bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, ushort.MaxValue)]
        public static int bitmask(bool16 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);
Assert.IsSafeBoolean(v.x8);
Assert.IsSafeBoolean(v.x9);
Assert.IsSafeBoolean(v.x10);
Assert.IsSafeBoolean(v.x11);
Assert.IsSafeBoolean(v.x12);
Assert.IsSafeBoolean(v.x13);
Assert.IsSafeBoolean(v.x14);
Assert.IsSafeBoolean(v.x15);

            return Sse2.movemask_epi8(Sse2.slli_epi16(v, 7));
        }

        ///<summary>        Returns a bitmask representation of a bool32. Storing one 1 bit per component in LSB order, from lower to higher bits.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bitmask(bool32 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);
Assert.IsSafeBoolean(v.x8);
Assert.IsSafeBoolean(v.x9);
Assert.IsSafeBoolean(v.x10);
Assert.IsSafeBoolean(v.x11);
Assert.IsSafeBoolean(v.x12);
Assert.IsSafeBoolean(v.x13);
Assert.IsSafeBoolean(v.x14);
Assert.IsSafeBoolean(v.x15);
Assert.IsSafeBoolean(v.x16);
Assert.IsSafeBoolean(v.x17);
Assert.IsSafeBoolean(v.x18);
Assert.IsSafeBoolean(v.x19);
Assert.IsSafeBoolean(v.x20);
Assert.IsSafeBoolean(v.x21);
Assert.IsSafeBoolean(v.x22);
Assert.IsSafeBoolean(v.x23);
Assert.IsSafeBoolean(v.x24);
Assert.IsSafeBoolean(v.x25);
Assert.IsSafeBoolean(v.x26);
Assert.IsSafeBoolean(v.x27);
Assert.IsSafeBoolean(v.x28);
Assert.IsSafeBoolean(v.x29);
Assert.IsSafeBoolean(v.x31);
Assert.IsSafeBoolean(v.x30);

            return Avx2.mm256_movemask_epi8(Avx2.mm256_slli_epi16(v, 7));
        }
    }
}