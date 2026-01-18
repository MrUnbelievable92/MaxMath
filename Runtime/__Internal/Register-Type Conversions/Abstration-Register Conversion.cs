using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class RegisterConversion
    {
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToRegister128<T>(T input)
            where T : unmanaged
        {
            v128 result;
            if (Avx.IsAvxSupported)
            {
                result = X86.Avx.undefined_si128();
            }
            else
            {
                result = Uninitialized<v128>.Create();
            }

            switch (sizeof(T))
            {
                case 16:
                {
                    return input.Reinterpret<T, v128>();
                }
                case 12:
                {
                    result.ULong0 = input.GetField<T, ulong>(0);
                    result.UInt2 = input.GetField<T, uint>(2);

                    return result;
                }
                case 8:
                {
                    result.ULong0 = input.GetField<T, ulong>(0);

                    return result;
                }
                case 6:
                {
                    result.UInt0 = input.GetField<T, uint>(0);
                    result.UShort2 = input.GetField<T, ushort>(2);

                    return result;
                }
                case 4:
                {
                    result.UInt0 = input.GetField<T, uint>(0);

                    return result;
                }
                case 3:
                {
                    result.UShort0 = input.GetField<T, ushort>(0);
                    result.Byte2 = input.GetField<T, byte>(2);

                    return result;
                }
                case 2:
                {
                    result.UShort0 = input.GetField<T, ushort>(0);

                    return result;
                }
                default:
                {
                    throw Assert.Unreachable();
                }
            }
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 ToRegister256<T>(T input)
            where T : unmanaged
        {
            v256 result;
            if (Avx.IsAvxSupported)
            {
                result = X86.Avx.mm256_undefined_si256();
            }
            else
            {
                result = Uninitialized<v256>.Create();
            }

            switch (sizeof(T))
            {
                case 32:
                {
                    return input.Reinterpret<T, v256>();
                }
                case 24:
                {
                    result.Lo128 = input.GetField<T, v128>(0);
                    result.ULong2 = input.GetField<T, ulong>(2);

                    return result;
                }
                default:
                {
                    throw Assert.Unreachable();
                }
            }
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T ToAbstraction128<T>(v128 input)
            where T : unmanaged
        {
            T result = Uninitialized<T>.Create();

            switch (sizeof(T))
            {
                case 16:
                {
                    return input.Reinterpret<v128, T>();
                }
                case 12:
                {
                    result.SetField<T, ulong>(input.ULong0, 0);
                    result.SetField<T, uint>(input.UInt2, 2);

                    return result;
                }
                case 8:
                {
                    result.SetField<T, ulong>(input.ULong0, 0);

                    return result;
                }
                case 6:
                {
                    result.SetField<T, uint>(input.UInt0, 0);
                    result.SetField<T, ushort>(input.UShort2, 2);

                    return result;
                }
                case 4:
                {
                    result.SetField<T, uint>(input.UInt0, 0);

                    return result;
                }
                case 3:
                {
                    result.SetField<T, ushort>(input.UShort0, 0);
                    result.SetField<T, byte>(input.Byte2, 2);

                    return result;
                }
                case 2:
                {
                    result.SetField<T, ushort>(input.UShort0, 0);

                    return result;
                }
                default:
                {
                    throw Assert.Unreachable();
                }
            }
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T ToAbstraction256<T>(v256 input)
            where T : unmanaged
        {
            T result = Uninitialized<T>.Create();

            switch (sizeof(T))
            {
                case 32:
                {
                    return input.Reinterpret<v256, T>();
                }
                case 24:
                {
                    result.SetField<T, v128>(input.Lo128, 0);
                    result.SetField<T, ulong>(input.ULong2, 2);

                    return result;
                }
                default:
                {
                    throw Assert.Unreachable();
                }
            }
        }
    }
}
