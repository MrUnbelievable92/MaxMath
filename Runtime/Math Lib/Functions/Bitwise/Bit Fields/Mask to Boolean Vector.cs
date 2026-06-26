using System;
using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns a <see cref="MaxMath.bool2"/> from the first two bits of an <see cref="int"/>.     </summary>
        [Obsolete("Because of the implementation of native SIMD register boolean masks, this function was implemented for them, too, which is not possible due to overloads of a function not considering the return type. Please use either bool2.FromBitmask() or even the corresponding method for \"maskAxB\" types for a small performance gain in SIMD compatible code paths. This function will be removed in a consequent release.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool2(int mask) => MaxMath.bool2.FromBitmask(mask);

        /// <summary>       Returns a <see cref="MaxMath.bool3"/> from the first 3 bits of an <see cref="int"/>.     </summary>
        [Obsolete("Because of the implementation of native SIMD register boolean masks, this function was implemented for them, too, which is not possible due to overloads of a function not considering the return type. Please use either bool3.FromBitmask() or even the corresponding method for \"maskAxB\" types for a small performance gain in SIMD compatible code paths. This function will be removed in a consequent release.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool3(int mask) => MaxMath.bool3.FromBitmask(mask);

        /// <summary>       Returns a <see cref="MaxMath.bool4"/> from the first 4 bits of an <see cref="int"/>.     </summary>
        [Obsolete("Because of the implementation of native SIMD register boolean masks, this function was implemented for them, too, which is not possible due to overloads of a function not considering the return type. Please use either bool4.FromBitmask() or even the corresponding method for \"maskAxB\" types for a small performance gain in SIMD compatible code paths. This function will be removed in a consequent release.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool4(int mask) => MaxMath.bool4.FromBitmask(mask);

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> from the first 8 bits of an <see cref="int"/>.     </summary>
        [Obsolete("Because of the implementation of native SIMD register boolean masks, this function was implemented for them, too, which is not possible due to overloads of a function not considering the return type. Please use either bool8.FromBitmask() or even the corresponding method for \"maskAxB\" types for a small performance gain in SIMD compatible code paths. This function will be removed in a consequent release.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool8(int mask) => MaxMath.bool8.FromBitmask(mask);

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> from the first 16 bits of an <see cref="int"/>.     </summary>
        [Obsolete("Because of the implementation of native SIMD register boolean masks, this function was implemented for them, too, which is not possible due to overloads of a function not considering the return type. Please use either bool16.FromBitmask() or even the corresponding method for \"maskAxB\" types for a small performance gain in SIMD compatible code paths. This function will be removed in a consequent release.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool16(int mask) => MaxMath.bool16.FromBitmask(mask);

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> from the bits of an <see cref="int"/>.     </summary>
        [Obsolete("Because of the implementation of native SIMD register boolean masks, this function was implemented for them, too, which is not possible due to overloads of a function not considering the return type. Please use either bool32.FromBitmask() or even the corresponding method for \"maskAxB\" types for a small performance gain in SIMD compatible code paths. This function will be removed in a consequent release.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool32(int mask) => MaxMath.bool32.FromBitmask(mask);
    }
}