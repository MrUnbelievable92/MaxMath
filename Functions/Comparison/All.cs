using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x2 x)
        {
            return math.all(*(bool4*)&x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x3 x)
        {
            return all(*(bool3x2*)&x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool2x4 x)
        {
            return all(*(bool4x2*)&x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x2 x)
        {
            return math.all(x.c0) & math.all(x.c1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x3 x)
        {
            return math.all(new bool3(math.all(x.c0), math.all(x.c1), math.all(x.c2)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool3x4 x)
        {
            return all(*(bool4x3*)&x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x2 x)
        {
            return new byte8(byte.MaxValue).Equals(X86.Sse2.cmpgt_epi8(*(byte8*)&x, default(v128)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x3 x)
        {
            return math.all(new bool3(math.all(x.c0), math.all(x.c1), math.all(x.c2)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool4x4 x)
        {
            return new byte16(byte.MaxValue).Equals(X86.Sse2.cmpgt_epi8(*(byte16*)&x, default(v128)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all(bool32 x)
        {
            return new byte32(byte.MaxValue).Equals(X86.Avx2.mm256_cmpgt_epi8(*(byte32*)&x, default(v256)));
        }
    }
}