using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the index of the first <see langword="true" /> of a <see cref="bool2"/> or 4 if none are <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 4)] 
        public static int first(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (int)((uint)math.tzcnt((uint)*(ushort*)&x) / 8);
        }

        /// <summary>       Returns the index of the first <see langword="true" /> of a <see cref="bool3"/> or 4 if none are <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 4)] 
        public static int first(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            int toInt = *(byte*)&x.z << 16;
            *(ushort*)&toInt = *(ushort*)&x;

            return (int)((uint)math.tzcnt(toInt) / 8);
        }

        /// <summary>       Returns the index of the first <see langword="true" /> of a <see cref="bool4"/> or 4 if none are <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 4)] 
        public static int first(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (int)((uint)math.tzcnt(*(int*)&x) / 8);
        }

        /// <summary>       Returns the index of the first <see langword="true" /> of a <see cref="MaxMath.bool8"/> or 8 if none are <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 8)] 
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

            if (Sse2.IsSse2Supported)
            {
                return (int)((uint)math.tzcnt(((v128)x).SLong0) / 8);
            }
            else
            {
                return (int)((uint)math.tzcnt(*(long*)&x) / 8);
            }
        }

        /// <summary>       Returns the index of the first <see langword="true" /> of a <see cref="MaxMath.bool16"/> or 32 if none are <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 32)]
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

            if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(Sse2.movemask_epi8(Sse2.slli_epi16(x, 7)));
            }
            else
            {
                int first8 = first(x.v8_0);

                if (first8 == 8)
                {
                    int last8 = first(x.v8_8);

                    return last8 == 8 ? 32 : 8 + last8;
                }
                else
                {
                    return first8;
                }
            }
        }

        /// <summary>       Returns the index of the first <see langword="true" /> of a <see cref="MaxMath.bool32"/> or 32 if none are <see langword="true" />.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 32)]
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

            if (Avx2.IsAvx2Supported)
            {
                return math.tzcnt(Avx2.mm256_movemask_epi8(Avx2.mm256_slli_epi16(x, 7)));
            }
            else if (Sse2.IsSse2Supported)
            {
                return math.tzcnt(Sse2.movemask_epi8(Sse2.slli_epi16(x._v16_0, 7)) | (Sse2.movemask_epi8(Sse2.slli_epi16(x._v16_16, 7)) << 16));
            }
            else
            {
                int first16 = first(x.v16_0);

                if (first16 == 32)
                {
                    int last16 = first(x.v16_16);

                    return last16 == 32 ? 32 : 16 + last16;
                }
                else
                {
                    return first16;
                }
            }
        }
    }
}