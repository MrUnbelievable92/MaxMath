using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the index of the first true bool value of a bool2 vector or 4 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 4)] 
        public static int first(bool2 x)
        {
            return math.tzcnt((uint)*(ushort*)&x) / 8;
        }

        /// <summary>       Returns the index of the first true bool value of a bool3 vector or 4 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 4)] 
        public static int first(bool3 x)
        {
            return math.tzcnt(0x00FF_FFFF & *(uint*)&x) / 8;
        }

        /// <summary>       Returns the index of the first true bool value of a bool4 vector or 4 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 4)] 
        public static int first(bool4 x)
        {
            return math.tzcnt(*(int*)&x) / 8;
        }

        /// <summary>       Returns the index of the first true bool value of a bool8 vector or 8 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 8)] 
        public static int first(bool8 x)
        {
Assert.IsSafeBoolean(x.x0);
Assert.IsSafeBoolean(x.x1);
Assert.IsSafeBoolean(x.x2);
Assert.IsSafeBoolean(x.x3);
Assert.IsSafeBoolean(x.x4);
Assert.IsSafeBoolean(x.x5);
Assert.IsSafeBoolean(x.x6);
Assert.IsSafeBoolean(x.x7);

            return math.tzcnt(x.cast_long) / 8;
        }

        /// <summary>       Returns the index of the first true bool value of a bool16 vector or 32 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 16)]
        public static int first(bool16 x)
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

            return math.tzcnt(Sse2.movemask_epi8(Sse2.slli_epi16(x, 7)));
        }

        /// <summary>       Returns the index of the first true bool value of a bool32 vector or 32 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 32)]
        public static int first(bool32 x)
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

            return math.tzcnt(Avx2.mm256_movemask_epi8(Avx2.mm256_slli_epi16(x, 7)));
        }
    }
}