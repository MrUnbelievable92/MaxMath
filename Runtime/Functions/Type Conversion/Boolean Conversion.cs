using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="UInt128"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 touint128safe(bool a)
        {
            a = *(byte*)&a != 0;

            return *(byte*)&a;
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="Int128"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 toint128safe(bool a)
        {
            a = *(byte*)&a != 0;

            return *(byte*)&a;
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="byte"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobytesafe(bool a)
        {
            a = *(byte*)&a != 0;

            return *(byte*)&a;
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ushort"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushortsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="uint"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touintsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ulong"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulongsafe(bool a)
        {
            return tobytesafe(a);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="sbyte"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbytesafe(bool a)
        {
            a = *(byte*)&a != 0;

            return *(sbyte*)&a;
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="short"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshortsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="int"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int tointsafe(bool a)
        {
            return tobytesafe(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="long"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolongsafe(bool a)
        {
            return tobytesafe(a);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="quarter"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquartersafe(bool a)
        {
            return new quarter((byte)(-tosbytesafe(a) & ((quarter)1f).value));
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="half"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalfsafe(bool a)
        {
            return new half { value = (ushort)(-tosbytesafe(a) & ((half)1f).value) };
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="float"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloatsafe(bool a)
        {
            return math.asfloat(-tosbytesafe(a) & math.asint(1f));
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="double"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todoublesafe(bool a)
        {
            return math.asdouble(-(long)toulongsafe(a) & math.aslong(1d));
        }


        /// <summary>       Converts a <see cref="byte"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(byte a)
        {
            return a != 0;
        }

        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(ushort a)
        {
            return a != 0;
        }

        /// <summary>       Converts a <see cref="uint"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(uint a)
        {
            return a != 0;
        }

        /// <summary>       Converts a <see cref="ulong"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(ulong a)
        {
            return a != 0;
        }


        /// <summary>       Converts an <see cref="sbyte"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(sbyte a)
        {
            return a != 0;
        }

        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(short a)
        {
            return a != 0;
        }
        /// <summary>       Converts an <see cref="int"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static bool toboolsafe(int a)
        {
            return a != 0;
        }

        /// <summary>       Converts a <see cref="long"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(long a)
        {
            return a != 0;
        }


        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(quarter a)
        {
            return a != (quarter)0f;
        }

        /// <summary>       Converts a <see cref="half"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(half a)
        {
            return (float)a != 0f;
        }

        /// <summary>       Converts a <see cref="float"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(float a)
        {
            return a != 0f;
        }

        /// <summary>       Converts a <see cref="double"/> to its <see cref="bool"/> representation. The underlying value is being clamped to the interval [0,1].       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(double a)
        {
            return a != 0d;
        }
    }
}