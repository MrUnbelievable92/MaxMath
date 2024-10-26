using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

// PLEASE NOTE that "return Sse2.IsSse2Supported || Arm.Neon.IsNeonSupported;" DOES NOT WORK with Burst.
// Don't ever change this and also don't code review this

namespace MaxMath
{
    internal static class Architecture
    {
        internal static bool IsBurstCompiled
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                //return constexpr.IS_CONST(1);

                if (Sse2.IsSse2Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsX86Win64Supported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (UNITY_EDITOR_64 && UNITY_EDITOR_WIN) || (UNITY_64 && UNITY_STANDALONE_WIN)
                if (Sse2.IsSse2Supported)
                {
                    return true;
                }
#endif
                return false;
            }
        }

        internal static bool IsSIMDSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsVectorShiftSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsTableLookupSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsAbs32Supported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsAbs64Supported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsPopcntSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Popcnt.IsPopcntSupported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsFMASupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsBlendSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsCMP64Supported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse4_2.IsSse42Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsMul32Supported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsInsertExtractSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsMinMaxSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return true;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal static bool IsVectorShift16Supported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                //if (Avx512.IsAvx512Supported)
                //{
                //    return true;
                //}
                if (Arm.Neon.IsNeonSupported)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
