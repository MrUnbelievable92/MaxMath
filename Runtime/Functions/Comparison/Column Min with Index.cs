using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the index of the minimum component of a ushort2 vector with the minimum component as an out parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort2 x, out ushort min)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 temp = Sse4_1.minpos_epu16(Sse2.or_si128(x, new v128(0, -1, -1, -1)));
                min = temp.UShort0;

                return temp.UShort1;
            }
            else
            {
                if (x.x < x.y)
                {
                    min = x.x;
                    return 0;
                }
                else
                {
                    min = x.y;
                    return 1;
                }
            }
        }

        /// <summary>       Returns the index of the minimum component of a ushort3 vector with the minimum component as an out parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort3 x, out ushort min)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 temp = Sse4_1.minpos_epu16(Sse2.or_si128(x, new v128(0u, 0xFFFF_0000u, uint.MaxValue, uint.MaxValue)));
                min = temp.UShort0;

                return temp.UShort1;
            }
            else
            {
                min = cmin(x);

                if (min == x.x)
                {
                    return 0;
                }
                else if (min == x.y)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        /// <summary>       Returns the index of the minimum component of a ushort4 vector with the minimum component as an out parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort4 x, out ushort min)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 temp = Sse4_1.minpos_epu16(Sse2.or_si128(x, new v128(0, 0, -1, -1)));
                min = temp.UShort0;

                return temp.UShort1;
            }
            else
            {
                min = cmin(x);

                if (min == x.x)
                {
                    return 0;
                }
                else if (min == x.y)
                {
                    return 1;
                }
                else if (min == x.z)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
        }

        /// <summary>       Returns the index of the minimum component of a ushort8 vector with the minimum component as an out parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort8 x, out ushort min)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 temp = Sse4_1.minpos_epu16(x);
                min = temp.UShort0;

                return temp.UShort1;
            }
            else
            {
                min = cmin(x);

                if (min == x.x0)
                {
                    return 0;
                }
                else if (min == x.x1)
                {
                    return 1;
                }
                else if (min == x.x2)
                {
                    return 2;
                }
                else if (min == x.x3)
                {
                    return 3;
                }
                else if (min == x.x4)
                {
                    return 4;
                }
                else if (min == x.x5)
                {
                    return 5;
                }
                else if (min == x.x6)
                {
                    return 6;
                }
                else
                {
                    return 7;
                }
            }
        }
    }
}