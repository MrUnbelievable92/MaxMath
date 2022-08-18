using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the number of <see langword="true" />s in a <see cref="bool2"/>.       </summary>
        [return: AssumeRange(0ul, 2ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint count(bool2 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);

            return (uint)math.countbits((uint)(*(ushort*)&x));
        }

        /// <summary>       Returns the number of <see langword="true" />s in a <see cref="bool3"/>.       </summary>
        [return: AssumeRange(0ul, 3ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint count(bool3 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);

            int toInt = *(byte*)&x.z << 16;
            *(ushort*)&toInt = *(ushort*)&x;

            return (uint)math.countbits(toInt);
        }

        /// <summary>       Returns the number of <see langword="true" />s in a <see cref="bool4"/>.       </summary>
        [return: AssumeRange(0ul, 4ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint count(bool4 x)
        {
Assert.IsSafeBoolean(x.x);
Assert.IsSafeBoolean(x.y);
Assert.IsSafeBoolean(x.z);
Assert.IsSafeBoolean(x.w);

            return (uint)math.countbits(*(int*)&x);
        }

        /// <summary>       Returns the number of <see langword="true" />s in a <see cref="MaxMath.bool8"/>.       </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint count(bool8 x)
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
                return (uint)math.countbits(((v128)x).ULong0);
            }
            else
            {
                return (uint)math.countbits(*(long*)&x);
            }
        }

        /// <summary>       Returns the number of <see langword="true" />s in a <see cref="MaxMath.bool16"/>.       </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint count(bool16 x)
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
                return (uint)math.countbits(Sse2.movemask_epi8(Xse.neg_epi8(x)));
            }
            else
            {
                return count(x.v8_0) + count(x.v8_8);
            }
        }

        /// <summary>       Returns the number of <see langword="true" />s in a <see cref="MaxMath.bool32"/>.       </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static uint count(bool32 x)
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
                return (uint)math.countbits(Avx2.mm256_movemask_epi8(Xse.mm256_neg_epi8(x)));
            }
            else
            {
                return count(x.v16_0) + count(x.v16_16);
            }
        }
    }
}