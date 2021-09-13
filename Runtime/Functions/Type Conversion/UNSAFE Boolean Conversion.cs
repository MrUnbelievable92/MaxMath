using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a <see cref="bool"/> to its <see cref="UInt128"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 touint128(bool a)
        { 
            return tobyte(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="Int128"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 toint128(bool a)
        { 
            return tobyte(a);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="byte"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tobyte(bool a)
        { 
Assert.IsSafeBoolean(a);

            return *(byte*)&a;
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ushort"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort toushort(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="uint"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touint(bool a)
        { 
            return (uint)toint(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="ulong"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong toulong(bool a)
        { 
            return tobyte(a);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="sbyte"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte tosbyte(bool a)
        { 
Assert.IsSafeBoolean(a);

            return *(sbyte*)&a;
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="short"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toshort(bool a)
        {
            return tobyte(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="int"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 1)]
        public static int toint(bool a)
        { 
            return tobyte(a);
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="long"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long tolong(bool a)
        { 
            return tobyte(a);
        }


        /// <summary>       Converts a <see cref="bool"/> to its <see cref="quarter"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter toquarter(bool a)
        {
            return new quarter((byte)(-tosbyte(a) & ((quarter)1f).value));
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="half"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tohalf(bool a)
        { 
            return new half { value = (ushort)(-tosbyte(a) & ((half)1f).value) };
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="float"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tofloat(bool a)
        { 
            return math.asfloat(-tosbyte(a) & math.asint(1f));
        }

        /// <summary>       Converts a <see cref="bool"/> to its <see cref="double"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double todouble(bool a)
        { 
            return math.asdouble(-(long)toulong(a) & math.aslong(1d));
        }


        /// <summary>       Converts a <see cref="byte"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(byte a)
        { 
Assert.IsBetween(a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(ushort a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }
        /// <summary>       Converts a <see cref="uint"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(uint a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts a <see cref="ulong"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(ulong a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }


        /// <summary>       Converts an <see cref="sbyte"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(sbyte a)
        { 
Assert.IsBetween(a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts a <see cref="short"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(short a)
        { 
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }
        /// <summary>       Converts an <see cref="int"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static bool tobool(int a)
        { 
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts a <see cref="long"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(long a)
        {
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }


        /// <summary>       Converts a <see cref="quarter"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(quarter a)
        {
Assert.IsTrue(a.value == ((quarter)1f).value || a.value == 0 || a.value == 1 << 7);

            return a.value == ((quarter)1f).value;
        }

        /// <summary>       Converts a <see cref="half"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(half a)
        {
Assert.IsTrue(a.value == ((half)1f).value || a.value == 0 || a.value == 1 << 15);

            return a.value == ((half)1f).value;
        }

        /// <summary>       Converts a <see cref="float"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(float a)
        {
Assert.IsTrue(a == 1f || a == 0f);

            return math.asint(a) == math.asint(1f);
        }

        /// <summary>       Converts a <see cref="double"/> to its <see cref="bool"/> representation. The underlying value is expected to be either 0 or 1.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(double a)
        {
Assert.IsTrue(a == 1d || a == 0d);

            return math.aslong(a) == math.aslong(1d);
        }
    }
}