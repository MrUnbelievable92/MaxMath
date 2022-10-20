using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 setall_si128() => new v128(-1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 setall_ps() => setall_si128();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 setall_pd() => setall_si128();


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_setall_si256() => new v256(-1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_setall_ps() => mm256_setall_si256();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_setall_pd() => mm256_setall_si256();
    }
}
