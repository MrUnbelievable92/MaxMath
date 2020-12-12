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
Assert.IsBetween(*(byte*)&x.x0, 0, 1);
Assert.IsBetween(*(byte*)&x.x1, 0, 1);
Assert.IsBetween(*(byte*)&x.x2, 0, 1);
Assert.IsBetween(*(byte*)&x.x3, 0, 1);
Assert.IsBetween(*(byte*)&x.x4, 0, 1);
Assert.IsBetween(*(byte*)&x.x5, 0, 1);
Assert.IsBetween(*(byte*)&x.x6, 0, 1);
Assert.IsBetween(*(byte*)&x.x7, 0, 1);

            return math.tzcnt(x.cast_long) / 8;
        }

        /// <summary>       Returns the index of the first true bool value of a bool16 vector or 32 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 16)]
        public static int first(bool16 x)
        {
Assert.IsBetween(*(byte*)&x.x0,  0, 1);
Assert.IsBetween(*(byte*)&x.x1,  0, 1);
Assert.IsBetween(*(byte*)&x.x2,  0, 1);
Assert.IsBetween(*(byte*)&x.x3,  0, 1);
Assert.IsBetween(*(byte*)&x.x4,  0, 1);
Assert.IsBetween(*(byte*)&x.x5,  0, 1);
Assert.IsBetween(*(byte*)&x.x6,  0, 1);
Assert.IsBetween(*(byte*)&x.x7,  0, 1);
Assert.IsBetween(*(byte*)&x.x8,  0, 1);
Assert.IsBetween(*(byte*)&x.x9,  0, 1);
Assert.IsBetween(*(byte*)&x.x10, 0, 1);
Assert.IsBetween(*(byte*)&x.x11, 0, 1);
Assert.IsBetween(*(byte*)&x.x12, 0, 1);
Assert.IsBetween(*(byte*)&x.x13, 0, 1);
Assert.IsBetween(*(byte*)&x.x14, 0, 1);
Assert.IsBetween(*(byte*)&x.x15, 0, 1);

            return math.tzcnt(Sse2.movemask_epi8(Operator.shl_short(x, 7)));
        }

        /// <summary>       Returns the index of the first true bool value of a bool32 vector or 32 if none are true.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(0, 32)]
        public static int first(bool32 x)
        {
Assert.IsBetween(*(byte*)&x.x0,  0, 1);
Assert.IsBetween(*(byte*)&x.x1,  0, 1);
Assert.IsBetween(*(byte*)&x.x2,  0, 1);
Assert.IsBetween(*(byte*)&x.x3,  0, 1);
Assert.IsBetween(*(byte*)&x.x4,  0, 1);
Assert.IsBetween(*(byte*)&x.x5,  0, 1);
Assert.IsBetween(*(byte*)&x.x6,  0, 1);
Assert.IsBetween(*(byte*)&x.x7,  0, 1);
Assert.IsBetween(*(byte*)&x.x8,  0, 1);
Assert.IsBetween(*(byte*)&x.x9,  0, 1);
Assert.IsBetween(*(byte*)&x.x10, 0, 1);
Assert.IsBetween(*(byte*)&x.x11, 0, 1);
Assert.IsBetween(*(byte*)&x.x12, 0, 1);
Assert.IsBetween(*(byte*)&x.x13, 0, 1);
Assert.IsBetween(*(byte*)&x.x14, 0, 1);
Assert.IsBetween(*(byte*)&x.x15, 0, 1);
Assert.IsBetween(*(byte*)&x.x16, 0, 1);
Assert.IsBetween(*(byte*)&x.x17, 0, 1);
Assert.IsBetween(*(byte*)&x.x18, 0, 1);
Assert.IsBetween(*(byte*)&x.x19, 0, 1);
Assert.IsBetween(*(byte*)&x.x20, 0, 1);
Assert.IsBetween(*(byte*)&x.x21, 0, 1);
Assert.IsBetween(*(byte*)&x.x22, 0, 1);
Assert.IsBetween(*(byte*)&x.x23, 0, 1);
Assert.IsBetween(*(byte*)&x.x24, 0, 1);
Assert.IsBetween(*(byte*)&x.x25, 0, 1);
Assert.IsBetween(*(byte*)&x.x26, 0, 1);
Assert.IsBetween(*(byte*)&x.x27, 0, 1);
Assert.IsBetween(*(byte*)&x.x28, 0, 1);
Assert.IsBetween(*(byte*)&x.x29, 0, 1);
Assert.IsBetween(*(byte*)&x.x30, 0, 1);
Assert.IsBetween(*(byte*)&x.x31, 0, 1);

            return math.tzcnt(Avx2.mm256_movemask_epi8(Operator.shl_short(x, 7)));
        }
    }
}