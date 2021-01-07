using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>        Returns a bool indicating for a half whether it is an infinite floating point value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(half h)
        {
            return (h.value & 0x7FFF) == 0x7C00;
        }

        /// <summary>        Returns a bool indicating for a half whether it is a finite floating point value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(half h)
        {
            return (h.value & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a bool indicating for a half whether it is a NaN (not a number) floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(half h)
        {
            return (h.value & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a bool2 indicating for each component of a half2 whether it is an infinite floating point value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinf(half2 h)
        {
            return (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a bool2 indicating for each component of a half2 whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isfinite(half2 h)
        {
            return (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a bool2 indicating for each component of a half2 whether it is a NaN (not a number) floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isnan(half2 h)
        {
            return (asushort(h) & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a bool3 indicating for each component of a half3 whether it is an infinite floating point value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinf(half3 h)
        {
            return (asushort(h) & 0x7FFF) == 0x7C00;
        }
        
        ///<summary>        Returns a bool3 indicating for each component of a half3 whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isfinite(half3 h)
        {
            return (asushort(h) & 0x7FFF) < 0x7C00;
        }
        
        ///<summary>        Returns a bool3 indicating for each component of a half3 whether it is a NaN (not a number) floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isnan(half3 h)
        {
            return (asushort(h) & 0x7FFF) > 0x7C00;
        }

        
        ///<summary>        Returns a bool4 indicating for each component of a half4 whether it is an infinite floating point value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinf(half4 h)
        {
            return (asushort(h) & 0x7FFF) == 0x7C00;
        }
        
        ///<summary>        Returns a bool4 indicating for each component of a half4 whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isfinite(half4 h)
        {
            return (asushort(h) & 0x7FFF) < 0x7C00;
        }
        
        ///<summary>        Returns a bool4 indicating for each component of a half4 whether it is a NaN (not a number) floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isnan(half4 h)
        {
            return (asushort(h) & 0x7FFF) > 0x7C00;
        }

        
        ///<summary>        Returns a bool8 indicating for each component of a half8 whether it is an infinite floating point value.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinf(half8 h)
        {
            return (asushort(h) & 0x7FFF) == 0x7C00;
        }
        
        ///<summary>        Returns a bool8 indicating for each component of a half8 whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isfinite(half8 h)
        {
            return (asushort(h) & 0x7FFF) < 0x7C00;
        }
        
        ///<summary>        Returns a bool8 indicating for each component of a half8 whether it is a NaN (not a number) floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isnan(half8 h)
        {
            return (asushort(h) & 0x7FFF) > 0x7C00;
        }
    }
}