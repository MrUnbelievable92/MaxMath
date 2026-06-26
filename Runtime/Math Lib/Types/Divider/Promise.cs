using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static MaxMath.math;
using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        /// <summary>   Promise that neither signed divisor is equal to the smallest representable integer of its type.  </summary>
        public const Promise PROMISE_NOT_MIN_VALUE  = Promise.Unsafe0;
        /// <summary>   Promise that neither divisor is equal to 1 or -1.  </summary>
        public const Promise PROMISE_NOT_ONE        = Promise.Unsafe1;
        /// <summary>   Promise that each divisors absolute value is a power of 2.  </summary>
        public const Promise PROMISE_POW2           = Promise.Unsafe2;
        /// <summary>   Promise that neither divisors absolute value is a power of 2.  </summary>
        public const Promise PROMISE_NOT_POW2       = Promise.Unsafe3;
        /// <summary>   Promise that each divisor is greater than 0.  </summary>
        public const Promise PROMISE_POSITIVE       = Promise.ZeroOrGreater;
        /// <summary>   Promise that each divisor is less than 0.  </summary>
        public const Promise PROMISE_NEGATIVE       = Promise.ZeroOrLess;
        /// <summary>   Promise that all divisors are equal to each other.  </summary>
        public const Promise PROMISE_SAME_VALUE     = Promise.NonZero;
        /// <summary>   Promise that each divisors absolute value is representable as an integer 1 bit smaller than its type.  </summary>
        public const Promise PROMISE_LZCNT_NOT_0    = Promise.NoOverflow;


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct DividerPromise
        {
            private Promise _promises;

            internal readonly bool NotOne      => Promises(PROMISE_NOT_ONE)       || NotPow2;
            internal readonly bool NotPow2     => Promises(PROMISE_NOT_POW2);
            internal readonly bool Pow2        => Promises(PROMISE_POW2);
            internal readonly bool NotMinValue => Promises(PROMISE_NOT_MIN_VALUE) || NotPow2;
            internal readonly bool Positive    => Promises(PROMISE_POSITIVE)      || LZCNTnot0;
            internal readonly bool Negative    => Promises(PROMISE_NEGATIVE);
            internal readonly bool SameValue   => Promises(PROMISE_SAME_VALUE);
            internal readonly bool LZCNTnot0   => Promises(PROMISE_LZCNT_NOT_0);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal DividerPromise(T d, Signedness sign, int elementSize)
            {
                switch (elementSize)
                {
                    case sizeof(byte):
                    {
                        switch (sizeof(T))
                        {
                            case 1  * sizeof(byte): this = sign == Signedness.Signed ? constcheck_i8(d.Reinterpret<T, sbyte>())
                                                                                     : constcheck_u8(d.Reinterpret<T, byte>());
                                return;
                            case 2  * sizeof(byte):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi8(d.Reinterpret<T, sbyte2>(), 2)
                                                                     : constcheck_epu8(d.Reinterpret<T, byte2>(), 2);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i8(d.Reinterpret<T, sbyte2>()[0])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte2>()[1])
                                                                     : constcheck_u8(d.Reinterpret<T, byte2>()[0])
                                                                       & constcheck_u8(d.Reinterpret<T, byte2>()[1]);
                                }

                                return;
                            }
                            case 3  * sizeof(byte):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi8(d.Reinterpret<T, sbyte3>(), 3)
                                                                     : constcheck_epu8(d.Reinterpret<T, byte3>(), 3);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i8(d.Reinterpret<T, sbyte3>()[0])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte3>()[1])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte3>()[2])
                                                                     : constcheck_u8(d.Reinterpret<T, byte3>()[0])
                                                                       & constcheck_u8(d.Reinterpret<T, byte3>()[1])
                                                                       & constcheck_u8(d.Reinterpret<T, byte3>()[2]);
                                }

                                return;
                            }
                            case 4  * sizeof(byte):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi8(d.Reinterpret<T, sbyte4>(), 4)
                                                                     : constcheck_epu8(d.Reinterpret<T, byte4>(), 4);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i8(d.Reinterpret<T, sbyte4>()[0])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte4>()[1])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte4>()[2])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte4>()[3])
                                                                     : constcheck_u8(d.Reinterpret<T, byte4>()[0])
                                                                       & constcheck_u8(d.Reinterpret<T, byte4>()[1])
                                                                       & constcheck_u8(d.Reinterpret<T, byte4>()[2])
                                                                       & constcheck_u8(d.Reinterpret<T, byte4>()[3]);
                                }

                                return;
                            }
                            case 8  * sizeof(byte):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi8(d.Reinterpret<T, sbyte8>(), 8)
                                                                     : constcheck_epu8(d.Reinterpret<T, byte8>(), 8);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i8(d.Reinterpret<T, sbyte8>()[0])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte8>()[1])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte8>()[2])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte8>()[3])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte8>()[4])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte8>()[5])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte8>()[6])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte8>()[7])
                                                                     : constcheck_u8(d.Reinterpret<T, byte8>()[0])
                                                                       & constcheck_u8(d.Reinterpret<T, byte8>()[1])
                                                                       & constcheck_u8(d.Reinterpret<T, byte8>()[2])
                                                                       & constcheck_u8(d.Reinterpret<T, byte8>()[3])
                                                                       & constcheck_u8(d.Reinterpret<T, byte8>()[4])
                                                                       & constcheck_u8(d.Reinterpret<T, byte8>()[5])
                                                                       & constcheck_u8(d.Reinterpret<T, byte8>()[6])
                                                                       & constcheck_u8(d.Reinterpret<T, byte8>()[7]);
                                }

                                return;
                            }
                            case 16  * sizeof(byte):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi8(d.Reinterpret<T, sbyte16>(), 16)
                                                                     : constcheck_epu8(d.Reinterpret<T, byte16>(), 16);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i8(d.Reinterpret<T, sbyte16>()[0])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[1])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[2])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[3])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[4])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[5])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[6])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[7])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[8])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[9])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[10])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[11])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[12])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[13])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[14])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte16>()[15])
                                                                     : constcheck_u8(d.Reinterpret<T, byte16>()[0])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[1])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[2])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[3])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[4])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[5])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[6])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[7])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[8])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[9])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[10])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[11])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[12])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[13])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[14])
                                                                       & constcheck_u8(d.Reinterpret<T, byte16>()[15]);
                                }

                                return;
                            }
                            case 32  * sizeof(byte):
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    this = sign == Signedness.Signed ? mm256_constcheck_epi8(d.Reinterpret<T, sbyte32>())
                                                                     : mm256_constcheck_epu8(d.Reinterpret<T, byte32>());
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i8(d.Reinterpret<T, sbyte32>()[0])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[1])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[2])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[3])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[4])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[5])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[6])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[7])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[8])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[9])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[10])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[11])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[12])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[13])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[14])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[15])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[16])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[17])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[18])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[19])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[20])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[21])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[22])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[23])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[24])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[25])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[26])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[27])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[28])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[29])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[30])
                                                                       & constcheck_i8(d.Reinterpret<T, sbyte32>()[31])
                                                                     : constcheck_u8(d.Reinterpret<T, byte32>()[0])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[1])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[2])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[3])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[4])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[5])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[6])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[7])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[8])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[9])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[10])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[11])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[12])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[13])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[14])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[15])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[16])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[17])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[18])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[19])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[20])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[21])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[22])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[23])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[24])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[25])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[26])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[27])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[28])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[29])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[30])
                                                                       & constcheck_u8(d.Reinterpret<T, byte32>()[31]);
                                }

                                return;
                            }

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(ushort):
                    {
                        switch (sizeof(T))
                        {
                            case 1  * sizeof(ushort): this = sign == Signedness.Signed ? constcheck_i16(d.Reinterpret<T, short>())
                                                                                       : constcheck_u16(d.Reinterpret<T, ushort>());
                                return;
                            case 2  * sizeof(ushort):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi16(d.Reinterpret<T, short2>(), 2)
                                                                     : constcheck_epu16(d.Reinterpret<T, ushort2>(), 2);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i16(d.Reinterpret<T, short2>()[0])
                                                                       & constcheck_i16(d.Reinterpret<T, short2>()[1])
                                                                     : constcheck_u16(d.Reinterpret<T, ushort2>()[0])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort2>()[1]);
                                }

                                return;
                            }
                            case 3  * sizeof(ushort):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi16(d.Reinterpret<T, short3>(), 3)
                                                                     : constcheck_epu16(d.Reinterpret<T, ushort3>(), 3);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i16(d.Reinterpret<T, short3>()[0])
                                                                       & constcheck_i16(d.Reinterpret<T, short3>()[1])
                                                                       & constcheck_i16(d.Reinterpret<T, short3>()[2])
                                                                     : constcheck_u16(d.Reinterpret<T, ushort3>()[0])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort3>()[1])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort3>()[2]);
                                }

                                return;
                            }
                            case 4  * sizeof(ushort):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi16(d.Reinterpret<T, short4>(), 4)
                                                                     : constcheck_epu16(d.Reinterpret<T, ushort4>(), 4);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i16(d.Reinterpret<T, short4>()[0])
                                                                       & constcheck_i16(d.Reinterpret<T, short4>()[1])
                                                                       & constcheck_i16(d.Reinterpret<T, short4>()[2])
                                                                       & constcheck_i16(d.Reinterpret<T, short4>()[3])
                                                                     : constcheck_u16(d.Reinterpret<T, ushort4>()[0])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort4>()[1])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort4>()[2])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort4>()[3]);
                                }

                                return;
                            }
                            case 8  * sizeof(ushort):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi16(d.Reinterpret<T, short8>(), 8)
                                                                     : constcheck_epu16(d.Reinterpret<T, ushort8>(), 8);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i16(d.Reinterpret<T, short8>()[0])
                                                                       & constcheck_i16(d.Reinterpret<T, short8>()[1])
                                                                       & constcheck_i16(d.Reinterpret<T, short8>()[2])
                                                                       & constcheck_i16(d.Reinterpret<T, short8>()[3])
                                                                       & constcheck_i16(d.Reinterpret<T, short8>()[4])
                                                                       & constcheck_i16(d.Reinterpret<T, short8>()[5])
                                                                       & constcheck_i16(d.Reinterpret<T, short8>()[6])
                                                                       & constcheck_i16(d.Reinterpret<T, short8>()[7])
                                                                     : constcheck_u16(d.Reinterpret<T, ushort8>()[0])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort8>()[1])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort8>()[2])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort8>()[3])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort8>()[4])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort8>()[5])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort8>()[6])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort8>()[7]);
                                }

                                return;
                            }
                            case 16  * sizeof(ushort):
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    this = sign == Signedness.Signed ? mm256_constcheck_epi16(d.Reinterpret<T, short16>())
                                                                     : mm256_constcheck_epu16(d.Reinterpret<T, ushort16>());
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i16(d.Reinterpret<T, short16>()[0])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[1])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[2])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[3])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[4])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[5])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[6])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[7])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[8])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[9])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[10])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[11])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[12])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[13])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[14])
                                                                       & constcheck_i16(d.Reinterpret<T, short16>()[15])
                                                                     : constcheck_u16(d.Reinterpret<T, ushort16>()[0])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[1])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[2])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[3])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[4])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[5])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[6])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[7])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[8])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[9])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[10])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[11])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[12])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[13])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[14])
                                                                       & constcheck_u16(d.Reinterpret<T, ushort16>()[15]);
                                }

                                return;
                            }

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(uint):
                    {
                        switch (sizeof(T))
                        {
                            case 1  * sizeof(uint): this = sign == Signedness.Signed ? constcheck_i32(d.Reinterpret<T, int>())
                                                                                     : constcheck_u32(d.Reinterpret<T, uint>());
                                return;
                            case 2  * sizeof(uint):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi32(d.Reinterpret<T, int2>(), 2)
                                                                     : constcheck_epu32(d.Reinterpret<T, uint2>(), 2);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i32(d.Reinterpret<T, int2>()[0])
                                                                       & constcheck_i32(d.Reinterpret<T, int2>()[1])
                                                                     : constcheck_u32(d.Reinterpret<T, uint2>()[0])
                                                                       & constcheck_u32(d.Reinterpret<T, uint2>()[1]);
                                }

                                return;
                            }
                            case 3  * sizeof(uint):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi32(d.Reinterpret<T, int3>(), 3)
                                                                     : constcheck_epu32(d.Reinterpret<T, uint3>(), 3);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i32(d.Reinterpret<T, int3>()[0])
                                                                       & constcheck_i32(d.Reinterpret<T, int3>()[1])
                                                                       & constcheck_i32(d.Reinterpret<T, int3>()[2])
                                                                     : constcheck_u32(d.Reinterpret<T, uint3>()[0])
                                                                       & constcheck_u32(d.Reinterpret<T, uint3>()[1])
                                                                       & constcheck_u32(d.Reinterpret<T, uint3>()[2]);
                                }

                                return;
                            }
                            case 4  * sizeof(uint):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi32(d.Reinterpret<T, int4>(), 4)
                                                                     : constcheck_epu32(d.Reinterpret<T, uint4>(), 4);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i32(d.Reinterpret<T, int4>()[0])
                                                                       & constcheck_i32(d.Reinterpret<T, int4>()[1])
                                                                       & constcheck_i32(d.Reinterpret<T, int4>()[2])
                                                                       & constcheck_i32(d.Reinterpret<T, int4>()[3])
                                                                     : constcheck_u32(d.Reinterpret<T, uint4>()[0])
                                                                       & constcheck_u32(d.Reinterpret<T, uint4>()[1])
                                                                       & constcheck_u32(d.Reinterpret<T, uint4>()[2])
                                                                       & constcheck_u32(d.Reinterpret<T, uint4>()[3]);
                                }

                                return;
                            }
                            case 8  * sizeof(uint):
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    this = sign == Signedness.Signed ? mm256_constcheck_epi32(d.Reinterpret<T, int8>())
                                                                     : mm256_constcheck_epu32(d.Reinterpret<T, uint8>());
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i32(d.Reinterpret<T, int8>()[0])
                                                                       & constcheck_i32(d.Reinterpret<T, int8>()[1])
                                                                       & constcheck_i32(d.Reinterpret<T, int8>()[2])
                                                                       & constcheck_i32(d.Reinterpret<T, int8>()[3])
                                                                       & constcheck_i32(d.Reinterpret<T, int8>()[4])
                                                                       & constcheck_i32(d.Reinterpret<T, int8>()[5])
                                                                       & constcheck_i32(d.Reinterpret<T, int8>()[6])
                                                                       & constcheck_i32(d.Reinterpret<T, int8>()[7])
                                                                     : constcheck_u32(d.Reinterpret<T, uint8>()[0])
                                                                       & constcheck_u32(d.Reinterpret<T, uint8>()[1])
                                                                       & constcheck_u32(d.Reinterpret<T, uint8>()[2])
                                                                       & constcheck_u32(d.Reinterpret<T, uint8>()[3])
                                                                       & constcheck_u32(d.Reinterpret<T, uint8>()[4])
                                                                       & constcheck_u32(d.Reinterpret<T, uint8>()[5])
                                                                       & constcheck_u32(d.Reinterpret<T, uint8>()[6])
                                                                       & constcheck_u32(d.Reinterpret<T, uint8>()[7]);
                                }

                                return;
                            }

                            default: throw Assert.Unreachable();
                        }
                    }
                    case sizeof(ulong):
                    {
                        switch (sizeof(T))
                        {
                            case 1  * sizeof(ulong): this = sign == Signedness.Signed ? constcheck_i64(d.Reinterpret<T, long>())
                                                                                      : constcheck_u64(d.Reinterpret<T, ulong>());
                                return;
                            case 2  * sizeof(ulong):
                            {
                                if (BurstArchitecture.IsSIMDSupported)
                                {
                                    this = sign == Signedness.Signed ? constcheck_epi64(d.Reinterpret<T, long2>())
                                                                     : constcheck_epu64(d.Reinterpret<T, ulong2>());
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i64(d.Reinterpret<T, long2>()[0])
                                                                       & constcheck_i64(d.Reinterpret<T, long2>()[1])
                                                                     : constcheck_u64(d.Reinterpret<T, ulong2>()[0])
                                                                       & constcheck_u64(d.Reinterpret<T, ulong2>()[1]);
                                }

                                return;
                            }
                            case 3  * sizeof(ulong):
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    this = sign == Signedness.Signed ? mm256_constcheck_epi64(d.Reinterpret<T, long3>(), 3)
                                                                     : mm256_constcheck_epu64(d.Reinterpret<T, ulong3>(), 3);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i64(d.Reinterpret<T, long3>()[0])
                                                                       & constcheck_i64(d.Reinterpret<T, long3>()[1])
                                                                       & constcheck_i64(d.Reinterpret<T, long3>()[2])
                                                                     : constcheck_u64(d.Reinterpret<T, ulong3>()[0])
                                                                       & constcheck_u64(d.Reinterpret<T, ulong3>()[1])
                                                                       & constcheck_u64(d.Reinterpret<T, ulong3>()[2]);
                                }

                                return;
                            }
                            case 4  * sizeof(ulong):
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    this = sign == Signedness.Signed ? mm256_constcheck_epi64(d.Reinterpret<T, long4>(), 4)
                                                                     : mm256_constcheck_epu64(d.Reinterpret<T, ulong4>(), 4);
                                    return;
                                }
                                else
                                {
                                    this = sign == Signedness.Signed ? constcheck_i64(d.Reinterpret<T, long4>()[0])
                                                                       & constcheck_i64(d.Reinterpret<T, long4>()[1])
                                                                       & constcheck_i64(d.Reinterpret<T, long4>()[2])
                                                                       & constcheck_i64(d.Reinterpret<T, long4>()[3])
                                                                     : constcheck_u64(d.Reinterpret<T, ulong4>()[0])
                                                                       & constcheck_u64(d.Reinterpret<T, ulong4>()[1])
                                                                       & constcheck_u64(d.Reinterpret<T, ulong4>()[2])
                                                                       & constcheck_u64(d.Reinterpret<T, ulong4>()[3]);
                                }

                                return;
                            }

                            default: throw Assert.Unreachable();
                        }
                    }
                    case 16:
                    {
                        switch (sizeof(T))
                        {
                            case 1 * 16: this = sign == Signedness.Signed
                                              ? constcheck_i128(d.Reinterpret<T, Int128>())
                                              : constcheck_u128(d.Reinterpret<T, UInt128>());
                                              return;

                            default: throw Assert.Unreachable();
                        }
                    }

                    default: throw Assert.Unreachable();
                }
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator DividerPromise(Promise p) => new DividerPromise{ _promises = p };

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator Promise(DividerPromise p) => p._promises;


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Promise operator & (DividerPromise lhs, Promise rhs)
            {
                if (constexpr.IS_CONST(lhs)
                 && constexpr.IS_CONST(rhs))
                {
                    return (Promise)lhs & rhs;
                }
                else
                {
                    return Promise.Nothing;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Promise operator | (DividerPromise lhs, Promise rhs)
            {
                if (constexpr.IS_CONST(lhs))
                {
                    if (constexpr.IS_CONST(rhs))
                    {
                        return (Promise)lhs | rhs;
                    }
                    else
                    {
                        return lhs;
                    }
                }
                else if (constexpr.IS_CONST(rhs))
                {
                    return rhs;
                }
                else
                {
                    return Promise.Nothing;
                }
            }


            // Necessary, because _promises could be loaded from RAM and would deterministically throw
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private readonly bool Promises(Promise p)
            {
                return constexpr.IS_CONST(_promises) && _promises.Promises(p);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_u8(byte d)
            {
                return (constexpr.IS_TRUE(d != 1)     ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.IS_TRUE(ispow2(d))  ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.IS_TRUE(!ispow2(d)) ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.IS_TRUE(d < 1 << 7) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_u16(ushort d)
            {
                return (constexpr.IS_TRUE(d != 1)      ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.IS_TRUE(ispow2(d))   ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.IS_TRUE(!ispow2(d))  ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.IS_TRUE(d < 1 << 15) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_u32(uint d)
            {
                return (constexpr.IS_TRUE(d != 1)       ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.IS_TRUE(ispow2(d))    ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.IS_TRUE(!ispow2(d))   ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.IS_TRUE(d < 1u << 31) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_u64(ulong d)
            {
                return (constexpr.IS_TRUE(d != 1)        ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.IS_TRUE(ispow2(d))     ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.IS_TRUE(!ispow2(d))    ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.IS_TRUE(d < 1ul << 63) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_u128(UInt128 d)
            {
                return (constexpr.IS_TRUE(d != 1)                ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.IS_TRUE(ispow2(d))             ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.IS_TRUE(!ispow2(d))            ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.IS_TRUE(d < (UInt128)1 << 127) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing);
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_i8(sbyte d)
            {
                return (constexpr.IS_TRUE(d != sbyte.MinValue)   ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.IS_TRUE(d != 1 && d != -1)     ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.IS_TRUE(ispow2((byte)abs(d)))  ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.IS_TRUE(!ispow2((byte)abs(d))) ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.IS_TRUE(d >= 0)                ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.IS_TRUE(d <= 0)                ? PROMISE_NEGATIVE                         : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_i16(short d)
            {
                return (constexpr.IS_TRUE(d != short.MinValue)     ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.IS_TRUE(d != 1 && d != -1)       ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.IS_TRUE(ispow2((ushort)abs(d)))  ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.IS_TRUE(!ispow2((ushort)abs(d))) ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.IS_TRUE(d >= 0)                  ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.IS_TRUE(d <= 0)                  ? PROMISE_NEGATIVE                         : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_i32(int d)
            {
                return (constexpr.IS_TRUE(d != int.MinValue)     ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.IS_TRUE(d != 1 && d != -1)     ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.IS_TRUE(ispow2((uint)abs(d)))  ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.IS_TRUE(!ispow2((uint)abs(d))) ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.IS_TRUE(d >= 0)                ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.IS_TRUE(d <= 0)                ? PROMISE_NEGATIVE                         : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_i64(long d)
            {
                return (constexpr.IS_TRUE(d != long.MinValue)     ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.IS_TRUE(d != 1 && d != -1)      ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.IS_TRUE(ispow2((ulong)abs(d)))  ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.IS_TRUE(!ispow2((ulong)abs(d))) ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.IS_TRUE(d >= 0)                 ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.IS_TRUE(d <= 0)                 ? PROMISE_NEGATIVE                         : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_i128(Int128 d)
            {
                return (constexpr.IS_TRUE(d != MaxMath.Int128.MinValue)     ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.IS_TRUE(d != 1 && d != -1)        ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.IS_TRUE(ispow2((UInt128)abs(d)))  ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.IS_TRUE(!ispow2((UInt128)abs(d))) ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.IS_TRUE(d >= 0)                   ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.IS_TRUE(d <= 0)                   ? PROMISE_NEGATIVE                         : Promise.Nothing);
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_epu8(v128 d, byte elements = 16)
            {
                return (constexpr.ALL_NEQ_EPU8(d, 1, elements)     ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPU8(d, elements)       ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPU8(d, elements)      ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.ALL_LT_EPU8(d, 1 << 7, elements) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPU8(d, elements)       ? PROMISE_SAME_VALUE  : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_epu16(v128 d, byte elements = 8)
            {
                return (constexpr.ALL_NEQ_EPU16(d, 1, elements)      ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPU16(d, elements)        ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPU16(d, elements)       ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.ALL_LT_EPU16(d, 1 << 15, elements) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPU16(d, elements)        ? PROMISE_SAME_VALUE  : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_epu32(v128 d, byte elements = 4)
            {
                return (constexpr.ALL_NEQ_EPU32(d, 1, elements)       ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPU32(d, elements)         ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPU32(d, elements)        ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.ALL_LT_EPU32(d, 1u << 31, elements) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPU32(d, elements)         ? PROMISE_SAME_VALUE  : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_epu64(v128 d)
            {
                return (constexpr.ALL_NEQ_EPU64(d, 1)        ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPU64(d)          ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPU64(d)         ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.ALL_LT_EPU64(d, 1ul << 63) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPU64(d)          ? PROMISE_SAME_VALUE  : Promise.Nothing);
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_epi8(v128 d, byte elements = 16)
            {
                return (constexpr.ALL_NEQ_EPI8(d, sbyte.MinValue, elements)                               ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.ALL_NEQ_EPI8(d, 1, elements) && constexpr.ALL_NEQ_EPI8(d, -1, elements) ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPI8(d, elements)                                              ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPI8(d, elements)                                             ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.ALL_GE_EPI8(d, 0, elements)                                             ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.ALL_LE_EPI8(d, 0, elements)                                             ? PROMISE_NEGATIVE                         : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPI8(d, elements)                                              ? PROMISE_SAME_VALUE                       : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_epi16(v128 d, byte elements = 8)
            {
                return (constexpr.ALL_NEQ_EPI16(d, short.MinValue, elements)                                ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.ALL_NEQ_EPI16(d, 1, elements) && constexpr.ALL_NEQ_EPI16(d, -1, elements) ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPI16(d, elements)                                               ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPI16(d, elements)                                              ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.ALL_GE_EPI16(d, 0, elements)                                              ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.ALL_LE_EPI16(d, 0, elements)                                              ? PROMISE_NEGATIVE                         : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPI16(d, elements)                                               ? PROMISE_SAME_VALUE                       : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_epi32(v128 d, byte elements = 4)
            {
                return (constexpr.ALL_NEQ_EPI32(d, int.MinValue, elements)                                  ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.ALL_NEQ_EPI32(d, 1, elements) && constexpr.ALL_NEQ_EPI32(d, -1, elements) ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPI32(d, elements)                                               ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPI32(d, elements)                                              ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.ALL_GE_EPI32(d, 0, elements)                                              ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.ALL_LE_EPI32(d, 0, elements)                                              ? PROMISE_NEGATIVE                         : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPI32(d, elements)                                               ? PROMISE_SAME_VALUE                       : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise constcheck_epi64(v128 d)
            {
                return (constexpr.ALL_NEQ_EPI64(d, long.MinValue)                       ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.ALL_NEQ_EPI64(d, 1) && constexpr.ALL_NEQ_EPI64(d, -1) ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPI64(d)                                     ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPI64(d)                                    ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.ALL_GE_EPI64(d, 0)                                    ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.ALL_LE_EPI64(d, 0)                                    ? PROMISE_NEGATIVE                         : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPI64(d)                                     ? PROMISE_SAME_VALUE                       : Promise.Nothing);
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise mm256_constcheck_epu8(v256 d)
            {
                return (constexpr.ALL_NEQ_EPU8(d, 1)     ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPU8(d)       ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPU8(d)      ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.ALL_LT_EPU8(d, 1 << 7) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPU8(d)       ? PROMISE_SAME_VALUE  : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise mm256_constcheck_epu16(v256 d)
            {
                return (constexpr.ALL_NEQ_EPU16(d, 1)      ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPU16(d)        ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPU16(d)       ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.ALL_LT_EPU16(d, 1 << 15) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPU16(d)        ? PROMISE_SAME_VALUE  : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise mm256_constcheck_epu32(v256 d)
            {
                return (constexpr.ALL_NEQ_EPU32(d, 1)       ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPU32(d)         ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPU32(d)        ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.ALL_LT_EPU32(d, 1u << 31) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPU32(d)         ? PROMISE_SAME_VALUE  : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise mm256_constcheck_epu64(v256 d, byte elements = 4)
            {
                return (constexpr.ALL_NEQ_EPU64(d, 1, elements)        ? PROMISE_NOT_ONE     : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPU64(d, elements)          ? PROMISE_POW2        : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPU64(d, elements)         ? PROMISE_NOT_POW2    : Promise.Nothing)
                     | (constexpr.ALL_LT_EPU64(d, 1ul << 63, elements) ? PROMISE_LZCNT_NOT_0 : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPU64(d, elements)          ? PROMISE_SAME_VALUE  : Promise.Nothing);
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise mm256_constcheck_epi8(v256 d)
            {
                return (constexpr.ALL_NEQ_EPI8(d, sbyte.MinValue)                     ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.ALL_NEQ_EPI8(d, 1) && constexpr.ALL_NEQ_EPI8(d, -1) ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPI8(d)                                    ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPI8(d)                                   ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.ALL_GE_EPI8(d, 0)                                   ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.ALL_LE_EPI8(d, 0)                                   ? PROMISE_NEGATIVE                         : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPI8(d)                                    ? PROMISE_SAME_VALUE                       : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise mm256_constcheck_epi16(v256 d)
            {
                return (constexpr.ALL_NEQ_EPI16(d, short.MinValue)                      ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.ALL_NEQ_EPI16(d, 1) && constexpr.ALL_NEQ_EPI16(d, -1) ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPI16(d)                                     ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPI16(d)                                    ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.ALL_GE_EPI16(d, 0)                                    ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.ALL_LE_EPI16(d, 0)                                    ? PROMISE_NEGATIVE                         : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPI16(d)                                     ? PROMISE_SAME_VALUE                       : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise mm256_constcheck_epi32(v256 d)
            {
                return (constexpr.ALL_NEQ_EPI32(d, int.MinValue)                        ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.ALL_NEQ_EPI32(d, 1) && constexpr.ALL_NEQ_EPI32(d, -1) ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPI32(d)                                     ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPI32(d)                                    ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.ALL_GE_EPI32(d, 0)                                    ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.ALL_LE_EPI32(d, 0)                                    ? PROMISE_NEGATIVE                         : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPI32(d)                                     ? PROMISE_SAME_VALUE                       : Promise.Nothing);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static DividerPromise mm256_constcheck_epi64(v256 d, byte elements = 4)
            {
                return (constexpr.ALL_NEQ_EPI64(d, long.MinValue, elements)                                 ? PROMISE_NOT_MIN_VALUE                    : Promise.Nothing)
                     | (constexpr.ALL_NEQ_EPI64(d, 1, elements) && constexpr.ALL_NEQ_EPI64(d, -1, elements) ? PROMISE_NOT_ONE                          : Promise.Nothing)
                     | (constexpr.ALL_POW2_EPI64(d, elements)                                               ? PROMISE_POW2                             : Promise.Nothing)
                     | (constexpr.NONE_POW2_EPI64(d, elements)                                              ? PROMISE_NOT_POW2                         : Promise.Nothing)
                     | (constexpr.ALL_GE_EPI64(d, 0, elements)                                              ? (PROMISE_POSITIVE | PROMISE_LZCNT_NOT_0) : Promise.Nothing)
                     | (constexpr.ALL_LE_EPI64(d, 0, elements)                                              ? PROMISE_NEGATIVE                         : Promise.Nothing)
                     | (constexpr.ALL_SAME_EPI64(d, elements)                                               ? PROMISE_SAME_VALUE                       : Promise.Nothing);
            }

            public override readonly string ToString()
            {
                return $"NotOne : {NotOne}\r\n" +
                       $"NotPow2 : {NotPow2}\r\n" +
                       $"Pow2 : {Pow2}\r\n" +
                       $"NotMinValue : {NotMinValue}\r\n" +
                       $"Positive : {Positive}\r\n" +
                       $"Negative : {Negative}\r\n" +
                       $"SameValue : {SameValue}\r\n" +
                       $"LZCNTnot0 : {LZCNTnot0}";
            }
        }
    }
}
