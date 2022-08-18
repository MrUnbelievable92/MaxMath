using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Clear trailing ones.     </summary>
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint blcfill(uint x)
        {
            return x & (x + 1);
        }
        /// <summary>       Isolate lowest clear bit.     </summary>
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint blci(uint x)
        {
            return x | ~(x + 1);
        }
        /// <summary>       Isolate lowest clear bit and complement.     </summary>
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint blcic(uint x)
        {
            return ~x & (x + 1);
        }
        /// <summary>       Clear trailing zeros.     </summary>
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint blcmsk(uint x)
        {
            return x ^ (x + 1);
        }
        /// <summary>       Set lowest clear bit.     </summary>
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint blcs(uint x)
        {
            return x | (x + 1);
        }
        /// <summary>       Fill from lowest set bit.     </summary>
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint blsfill(uint x)
        {
            return x | (x - 1);
        }
        /// <summary>       Ísolate lowest set bit and complement.     </summary>
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint blsic(uint x)
        {
            return ~x | (x - 1);
        }
        /// <summary>       Mask from traling zeros.     </summary>
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint tzmsk(uint x)
        {
            return ~x & (x - 1);
        }
        /// <summary>       Inverse mask from traling ones.     </summary>
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint t1mskc(uint x)
        {
            return ~x | (x + 1);
        }

        
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong blcfill(ulong x)
        {
            return x & (x + 1);
        }
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong blci(ulong x)
        {
            return x | ~(x + 1);
        }
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong blcic(ulong x)
        {
            return ~x & (x + 1);
        }
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong blcmsk(ulong x)
        {
            return x ^ (x + 1);
        }
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong blcs(ulong x)
        {
            return x | (x + 1);
        }
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong blsfill(ulong x)
        {
            return x | (x - 1);
        }
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong blsic(ulong x)
        {
            return ~x | (x - 1);
        }
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong tzmsk(ulong x)
        {
            return ~x & (x - 1);
        }
        [System.Obsolete("Work in progress. Renaming, documentation and vectorization pending")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong t1mskc(ulong x)
        {
            return ~x | (x + 1);
        }
    }
}
