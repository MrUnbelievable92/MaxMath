using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a bool value to its byte representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte touint8(bool a)
        { 
Assert.IsSafeBoolean(a);

            return *(byte*)&a;
        }

        /// <summary>       Converts a bool value to its ushort representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort touint16(bool a)
        {
            return touint8(a);
        }

        /// <summary>       Converts a bool value to its uint representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touint32(bool a)
        { 
            return (uint)toint32(a);
        }

        /// <summary>       Converts a bool value to its ulong representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong touint64(bool a)
        { 
            return touint8(a);
        }


        /// <summary>       Converts a bool value to its sbyte representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte toint8(bool a)
        { 
Assert.IsSafeBoolean(a);

            return *(sbyte*)&a;
        }

        /// <summary>       Converts a bool value to its short representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toint16(bool a)
        {
            return touint8(a);
        }

        /// <summary>       Converts a bool value to its int representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 1)]
        public static int toint32(bool a)
        { 
            return touint8(a);
        }

        /// <summary>       Converts a bool value to its long representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long toint64(bool a)
        { 
            return touint8(a);
        }

        /// <summary>       Converts a bool value to its half representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tof16(bool a)
        { 
            ushort backingField = (ushort)(touint8(a) * new half(1f).value);

            return *(half*)&backingField;
        }

        /// <summary>       Converts a bool value to its float representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tof32(bool a)
        { 
            return math.asfloat(touint8(a) * math.asuint(1f));
        }

        /// <summary>       Converts a bool value to its double representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double tof64(bool a)
        { 
            return math.asdouble(touint8(a) * math.asulong(1d));
        }


        /// <summary>       Converts a byte value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(byte a)
        { 
Assert.IsBetween(a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts a short value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(ushort a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }
        /// <summary>       Converts a uint value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(uint a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts a ulong value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(ulong a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }


        /// <summary>       Converts an sbyte value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(sbyte a)
        { 
Assert.IsBetween(a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts a short value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(short a)
        { 
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }
        /// <summary>       Converts an int value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static bool tobool(int a)
        { 
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary>       Converts a long value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(long a)
        {
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }


        /// <summary>       Converts a half value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(half a)
        {
Assert.IsTrue(a.value == new half(1f).value || a.value == 0 || a.value == 1 << 15);

            return a.value == ((half)1f).value;
        }

        /// <summary>       Converts a float value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(float a)
        {
Assert.IsTrue(a == 1f || a == 0f);

            return math.asint(a) == math.asint(1f);
        }

        /// <summary>       Converts a double value to its bool representation. The underlying value is expected to be either 0 or 1.        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool tobool(double a)
        {
Assert.IsTrue(a == 1d || a == 0d);

            return math.aslong(a) == math.aslong(1d);
        }
    }
}