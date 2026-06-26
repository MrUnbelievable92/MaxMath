using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Unity's up axis (0, 1, 0).  </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Obsolete("This method exists as a static property and will be removed in a subsequent release.")]
        public static float3 up() => new float3(0f, 1f, 0f);

        /// <summary>   Unity's down axis (0, -1, 0).   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Obsolete("This method exists as a static property and will be removed in a subsequent release.")]
        public static float3 down() => new float3(0f, -1f, 0f);

        /// <summary>   Unity's forward axis (0, 0, 1).     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Obsolete("This method exists as a static property and will be removed in a subsequent release.")]
        public static float3 forward() => new float3(0f, 0f, 1f);

        /// <summary>   Unity's back axis (0, 0, -1).   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Obsolete("This method exists as a static property and will be removed in a subsequent release.")]
        public static float3 back() => new float3(0f, 0f, -1f);

        /// <summary>   Unity's left axis (-1, 0, 0).   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Obsolete("This method exists as a static property and will be removed in a subsequent release.")]
        public static float3 left() => new float3(-1f, 0f, 0f);

        /// <summary>   Unity's right axis (1, 0, 0).   </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [System.Obsolete("This method exists as a static property and will be removed in a subsequent release.")]
        public static float3 right() => new float3(1f, 0f, 0f);
    }
}
