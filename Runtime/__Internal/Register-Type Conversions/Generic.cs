using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    unsafe internal static partial class RegisterConversion
    {
        internal class Generic
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static v128 ToV128<T>(T value, uint elementSize)
                where T : unmanaged
            {
                switch (elementSize)
                {
                    case sizeof(byte):
                    {
                        switch (sizeof(T))
                        {
                            case 16 * sizeof(byte): return *(byte16*)&value;
                            case  8 * sizeof(byte): return *(byte8*)&value;
                            case  4 * sizeof(byte): return *(byte4*)&value;
                            case  3 * sizeof(byte): return *(byte3*)&value;
                            case  2 * sizeof(byte): return *(byte2*)&value;

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(short):
                    {
                        switch (sizeof(T))
                        {
                            case 8 * sizeof(short): return *(short8*)&value;
                            case 4 * sizeof(short): return *(short4*)&value;
                            case 3 * sizeof(short): return *(short3*)&value;
                            case 2 * sizeof(short): return *(short2*)&value;

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(int):
                    {
                        switch (sizeof(T))
                        {
                            case 4 * sizeof(int): return RegisterConversion.ToV128(*(int4*)&value);
                            case 3 * sizeof(int): return RegisterConversion.ToV128(*(int3*)&value);
                            case 2 * sizeof(int): return RegisterConversion.ToV128(*(int2*)&value);

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(long):
                    {
                        switch (sizeof(T))
                        {
                            case 2 * sizeof(long): return *(long2*)&value;

                            default: throw Assert.Unreachable();
                        }
                    }

                    default: throw Assert.Unreachable();
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static v256 ToV256<T>(T value, uint elementSize)
                where T : unmanaged
            {
                switch (elementSize)
                {
                    case sizeof(byte):
                    {
                        switch (sizeof(T))
                        {
                            case 32 * sizeof(byte): return *(byte32*)&value;

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(short):
                    {
                        switch (sizeof(T))
                        {
                            case 16 * sizeof(short): return *(short16*)&value;

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(int):
                    {
                        switch (sizeof(T))
                        {
                            case 8 * sizeof(int): return *(int8*)&value;

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(long):
                    {
                        switch (sizeof(T))
                        {
                            case 4 * sizeof(long): return *(long4*)&value;
                            case 3 * sizeof(long): return *(long3*)&value;

                            default: throw Assert.Unreachable();
                        }
                    }

                    default: throw Assert.Unreachable();
                }
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static T FromV128<T>(v128 value, uint elementSize)
                where T : unmanaged
            {
                switch (elementSize)
                {
                    case sizeof(byte):
                    {
                        switch (sizeof(T))
                        {
                            case 16 * sizeof(byte): return ((byte16)value).Reinterpret<byte16, T>();
                            case  8 * sizeof(byte): return  ((byte8)value).Reinterpret<byte8,  T>();
                            case  4 * sizeof(byte): return  ((byte4)value).Reinterpret<byte4,  T>();
                            case  3 * sizeof(byte): return  ((byte3)value).Reinterpret<byte3,  T>();
                            case  2 * sizeof(byte): return  ((byte2)value).Reinterpret<byte2,  T>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(short):
                    {
                        switch (sizeof(T))
                        {
                            case 8 * sizeof(short): return ((short8)value).Reinterpret<short8, T>();
                            case 4 * sizeof(short): return ((short4)value).Reinterpret<short4, T>();
                            case 3 * sizeof(short): return ((short3)value).Reinterpret<short3, T>();
                            case 2 * sizeof(short): return ((short2)value).Reinterpret<short2, T>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(int):
                    {
                        switch (sizeof(T))
                        {
                            case 4 * sizeof(int): return RegisterConversion.ToInt4(value).Reinterpret<int4, T>();
                            case 3 * sizeof(int): return RegisterConversion.ToInt3(value).Reinterpret<int3, T>();
                            case 2 * sizeof(int): return RegisterConversion.ToInt2(value).Reinterpret<int2, T>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(long):
                    {
                        switch (sizeof(T))
                        {
                            case 2 * sizeof(long): return ((long2)value).Reinterpret<long2, T>();

                            default: throw Assert.Unreachable();
                        }
                    }

                    default: throw Assert.Unreachable();
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static T FromV256<T>(v256 value, uint elementSize)
                where T : unmanaged
            {
                switch (elementSize)
                {
                    case sizeof(byte):
                    {
                        switch (sizeof(T))
                        {
                            case 32 * sizeof(byte): return ((byte32)value).Reinterpret<byte32, T>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(short):
                    {
                        switch (sizeof(T))
                        {
                            case 16 * sizeof(short): return ((short16)value).Reinterpret<short16, T>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(int):
                    {
                        switch (sizeof(T))
                        {
                            case 8 * sizeof(int): return ((int8)value).Reinterpret<int8, T>();

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(long):
                    {
                        switch (sizeof(T))
                        {
                            case 4 * sizeof(long): return ((long4)value).Reinterpret<long4, T>();
                            case 3 * sizeof(long): return ((long3)value).Reinterpret<long3, T>();

                            default: throw Assert.Unreachable();
                        }
                    }

                    default: throw Assert.Unreachable();
                }
            }
        }
    }
}
