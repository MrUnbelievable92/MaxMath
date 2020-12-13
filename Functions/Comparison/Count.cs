using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the number of true values in a bool2 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 2)]
        public static int count(bool2 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);

            return math.countbits((int)(*(ushort*)&v));
        }

        /// <summary>       Returns the number of true values in a bool3 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 3)]
        public static int count(bool3 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);

            return math.countbits(0x00FF_FFFF & *(int*)&v);
        }

        /// <summary>       Returns the number of true values in a bool4 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 4)]
        public static int count(bool4 v)
        {
Assert.IsSafeBoolean(v.x);
Assert.IsSafeBoolean(v.y);
Assert.IsSafeBoolean(v.z);
Assert.IsSafeBoolean(v.w);

            return math.countbits(*(int*)&v);
        }

        /// <summary>       Returns the number of true values in a bool8 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 8)]
        public static int count(bool8 v)
        {
Assert.IsSafeBoolean(v.x0);
Assert.IsSafeBoolean(v.x1);
Assert.IsSafeBoolean(v.x2);
Assert.IsSafeBoolean(v.x3);
Assert.IsSafeBoolean(v.x4);
Assert.IsSafeBoolean(v.x5);
Assert.IsSafeBoolean(v.x6);
Assert.IsSafeBoolean(v.x7);

            return math.countbits(v.cast_long);
        }

        /// <summary>       Returns the number of true values in a bool16 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 16)]
        public static int count(bool16 v)
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

            return math.countbits(Sse2.movemask_epi8(Sse2.slli_epi16(v, 7)));
        }

        /// <summary>       Returns the number of true values in a bool32 vector.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 32)]
        public static int count(bool32 v)
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
Assert.IsSafeBoolean(v.x30);
Assert.IsSafeBoolean(v.x31);

            return math.countbits(Avx2.mm256_movemask_epi8(Avx2.mm256_slli_epi16(v, 7)));
        }
    }
}