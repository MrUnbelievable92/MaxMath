using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    internal static class HalfExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsZero(this half h)
        {
            return (h.value & 0x7FFFu) == 0u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsNotZero(this half h)
        {
            return (h.value & 0x7FFFu) != 0u;
        }
    }
}