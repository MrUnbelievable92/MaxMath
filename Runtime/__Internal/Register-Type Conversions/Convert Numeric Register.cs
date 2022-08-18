using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class RegisterConversion
    {
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 ToV256<T>(T input)
            where T : unmanaged
        {
            if (sizeof(T) == sizeof(v256))
            {
                return *(v256*)&input;
            }
            else
            {
                v256 r;
                if (Avx.IsAvxSupported)
                {
                    r = Avx.mm256_undefined_si256();
                }
                *(v128*)&r = *(v128*)&input;
                *((long*)&r + 2) = *((long*)&input + 2);
            
                return r;
            }
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ToV128<T>(T input)
            where T : unmanaged
        {
            v128 r;
            if (Avx.IsAvxSupported)
            {
                r = Avx.undefined_si128();
            }

            if (sizeof(T) == sizeof(v128))
            {
                return *(v128*)&input;
            }
            else if (sizeof(T) == 12)
            {
                *(long*)&r = *(long*)&input;
                *((int*)&r + 2) = *((int*)&input + 2);
            }
            else if (sizeof(T) == 8)
            {
                *(long*)&r = *(long*)&input;
            }
            else if (sizeof(T) == 6)
            {
                *(int*)&r = *(int*)&input;
                *((short*)&r + 2) = *((short*)&input + 2);
            }
            else if (sizeof(T) == 4)
            {
                *(int*)&r = *(int*)&input;
            }
            else if (sizeof(T) == 3)
            {
                *(short*)&r = *(short*)&input;
                *((byte*)&r + 2) = *((byte*)&input + 2);
            }
            else if (sizeof(T) == 2)
            {
                *(short*)&r = *(short*)&input;
            }
            else
            {
                *(long*)&r = *(long*)&input;
                *((long*)&r + 1) = *((long*)&input + 1);
            }
                    
            return r;
        }
        

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T ToType<T>(v256 input)
            where T : unmanaged
        {
            if (sizeof(T) == sizeof(v256))
            {
                return *(T*)&input;
            }
            else
            {
                T r;
                *(v128*)&r = *(v128*)&input;
                *((long*)&r + 2) = *((long*)&input + 2);
            
                return r;
            }
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T ToType<T>(v128 input)
            where T : unmanaged
        {
            T r;

            if (sizeof(T) == sizeof(v128))
            {
                return *(T*)&input;
            }
            else if (sizeof(T) == 12)
            {
                *(long*)&r = input.SLong0;
                *((int*)&r + 2) = input.SInt2;
            }
            else if (sizeof(T) == 8)
            {
                *(long*)&r = input.SLong0;
            }
            else if (sizeof(T) == 6)
            {
                *(int*)&r = input.SInt0;
                *((short*)&r + 2) = input.SShort2;
            }
            else if (sizeof(T) == 4)
            {
                *(int*)&r = input.SInt0;
            }
            else if (sizeof(T) == 3)
            {
                *(short*)&r = input.SShort0;
                *((byte*)&r + 2) = input.Byte2;
            }
            else if (sizeof(T) == 2)
            {
                *(short*)&r = input.SShort0;
            } 
            else
            {
                *(long*)&r = input.SLong0;
                *((long*)&r + 1) = input.SLong1;
            }

            return r;
        }
    }
}
