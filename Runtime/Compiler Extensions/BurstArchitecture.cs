//#define TESTING

using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

// PLEASE NOTE that "return Sse2.IsSse2Supported || Arm.Neon.IsNeonSupported;" DOES NOT WORK with Burst.
// Don't ever change this and also don't code review this

namespace MaxMath.Intrinsics
{
    public static class BurstArchitecture
    {
        public static bool IsBurstCompiled
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
            #if TESTING
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
            #else
                return constexpr.IS_CONST(69_420);
            #endif
            }
        }

        public static bool IsX86Win64Supported
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

        public static bool IsSIMDSupported
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

        public static bool IsVectorShiftSupported
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

        public static bool IsTableLookupSupported
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

        public static bool IsAbs32Supported
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

        public static bool IsAbs64Supported
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

        public static bool IsPopcntSupported
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

        public static bool IsFMASupported
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

        public static bool IsBlendSupported
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

        public static bool IsCMP64Supported
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

        public static bool IsMul32Supported
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

        public static bool IsMul8Supported
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

        public static bool IsInsertExtractSupported
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

        public static bool IsMinMaxSupported
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

        public static bool IsVectorShift16Supported
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

        public static bool IsVectorShift8Supported
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

        public static bool IsShiftRightArithmetic64Supported
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
