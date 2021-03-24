using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extractlowest(int x)
        {
            return (int)bits_extractlowest((uint)x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_resetlowest(int x)
        {
            return (int)bits_resetlowest((uint)x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_masktolowest(int x)
        {
            return (int)bits_masktolowest((uint)x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extract(int x, int index, int length)
        {
            return (int)bits_extract((uint)x, index, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_zerohigh(int x, int startIndex)
        {
            return (int)bits_zerohigh((uint)x, startIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_depositparallel(int x, int mask)
        {
            return (int)bits_depositparallel((uint)x, (uint)mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extractparallel(int x, int mask)
        {
            return (int)bits_extractparallel((uint)x, (uint)mask);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extractlowest(long x)
        {
            return (long)bits_extractlowest((ulong)x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_resetlowest(long x)
        {
            return (long)bits_resetlowest((ulong)x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_masktolowest(long x)
        {
            return (long)bits_masktolowest((ulong)x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extract(long x, int index, int length)
        {
            return (long)bits_extract((ulong)x, index, length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_zerohigh(long x, int startIndex)
        {
            return (long)bits_zerohigh((ulong)x, startIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_depositparallel(long x, long mask)
        {
            return (long)bits_depositparallel((ulong)x, (ulong)mask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extractparallel(long x, long mask)
        {
            return (long)bits_extractparallel((ulong)x, (ulong)mask);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_extractlowest(uint x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsi_u32(x);
            }
            else
            {
                return x & (uint)-(int)x;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_resetlowest(uint x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsr_u32(x);
            }
            else
            {
                return x & (x - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_masktolowest(uint x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsmsk_u32(x);
            }
            else
            {
                return x ^ (x - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_extract(uint x, int index, int length)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.bextr_u32(x, (uint)index, (uint)length);
            }
            else
            {
                return (x >> index) & ((1u << length) - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_zerohigh(uint x, int startIndex)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.bzhi_u32(x, (uint)startIndex);
            }
            else
            {
                return andnot(x, uint.MaxValue << startIndex);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_depositparallel(uint x, uint mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pdep_u32(x, mask);
            }
            else
            {
                uint result = 0;

                for (uint i = 1; mask != 0; i += i)
                {
                    if ((x & i) != 0)
                    {
                        result |= bits_extractlowest(mask);
                    }
                    else { }

                    mask = bits_resetlowest(mask);
                }

                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_extractparallel(uint x, uint mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pext_u32(x, mask);
            }
            else
            {
                uint result = 0;

                for (uint i = 1; mask != 0; i += i)
                {
                    if ((x & bits_extractlowest(mask)) != 0)
                    {
                        result |= i;
                    }
                    else { }

                    mask = bits_resetlowest(mask);
                }
                return result;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_extractlowest(ulong x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsi_u64(x);
            }
            else
            {
                return x & (ulong)-(long)x;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_resetlowest(ulong x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsr_u64(x);
            }
            else
            {
                return x & (x - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_masktolowest(ulong x)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.blsmsk_u64(x);
            }
            else
            {
                return x ^ (x - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_extract(ulong x, int index, int length)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return Bmi1.bextr_u64(x, (uint)index, (uint)length);
            }
            else
            {
                return (x >> index) & ((1ul << length) - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_zerohigh(ulong x, int startIndex)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.bzhi_u64(x, (uint)startIndex);
            }
            else
            {
                return andnot(x, ulong.MaxValue << startIndex);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_depositparallel(ulong x, ulong mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pdep_u64(x, mask);
            }
            else
            {
                ulong result = 0;

                for (ulong i = 1; mask != 0; i += i)
                {
                    if ((x & i) != 0)
                    {
                        result |= bits_extractlowest(mask);
                    }
                    else { }

                    mask = bits_resetlowest(mask);
                }

                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_extractparallel(ulong x, ulong mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pext_u64(x, mask);
            }
            else
            {
                ulong result = 0;

                for (ulong i = 1; mask != 0; i += i)
                {
                    if ((x & bits_extractlowest(mask)) != 0)
                    { 
                        result |= i;
                    }
                    else { }

                    mask = bits_resetlowest(mask);
                }
                return result;
            }
        }
    }
}