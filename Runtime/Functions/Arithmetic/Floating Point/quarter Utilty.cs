using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="quarter"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(quarter q)
        {
            return (q.value & 0b0111_1111) == 0b0111_0000;
        }

        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="quarter"/> whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(quarter q)
        {
            return (q.value & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool"/> indicating for a <see cref="quarter"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(quarter q)
        {
            return (q.value & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.quarter2"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isinf(quarter2 q)
        {
            return (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.quarter2"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isfinite(quarter2 q)
        {
            return (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="MaxMath.quarter2"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isnan(quarter2 q)
        {
            return (asbyte(q) & 0b111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.quarter3"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isinf(quarter3 q)
        {
            return (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }
        
        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.quarter3"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isfinite(quarter3 q)
        {
            return (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }
        
        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="MaxMath.quarter3"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isnan(quarter3 q)
        {
            return (asbyte(q) & 0b111_1111) > 0b0111_0000;
        }

        
        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.quarter4"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isinf(quarter4 q)
        {
            return (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }
        
        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.quarter4"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isfinite(quarter4 q)
        {
            return (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }
        
        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="MaxMath.quarter4"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isnan(quarter4 q)
        {
            return (asbyte(q) & 0b111_1111) > 0b0111_0000;
        }

        
        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.quarter8"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isinf(quarter8 q)
        {
            return (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }
        
        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.quarter8"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isfinite(quarter8 q)
        {
            return (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }
        
        ///<summary>        Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.quarter8"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isnan(quarter8 q)
        {
            return (asbyte(q) & 0b111_1111) > 0b0111_0000;
        }
    }
}