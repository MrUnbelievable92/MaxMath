using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x2 x)
        {
            return math.any(*(bool4*)&x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x3 x)
        {
            return any(*(bool3x2*)&x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool2x4 x)
        {
            return any(*(bool4x2*)&x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x2 x)
        {
            return math.any(x.c0) & math.any(x.c1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x3 x)
        {
            return math.any(new bool3(math.any(x.c0), math.any(x.c1), math.any(x.c2)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool3x4 x)
        {
            return any(*(bool4x3*)&x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x2 x)
        {
            return !(default(byte8).Equals(X86.Sse2.cmpgt_epi8(*(byte8*)&x, default(v128))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x3 x)
        {
            return math.any(new bool3(math.any(x.c0), math.any(x.c1), math.any(x.c2)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool4x4 x)
        {
            return !(default(byte16).Equals(X86.Sse2.cmpgt_epi8(*(byte16*)&x, default(v128))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool any(bool32 x)
        {
            return !(default(byte32).Equals(X86.Avx2.mm256_cmpgt_epi8(*(byte32*)&x, default(v256))));
        }
    }
}