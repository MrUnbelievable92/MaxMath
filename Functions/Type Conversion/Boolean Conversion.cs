using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Converts a bool value to its byte representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte touint8safe(bool a)
        {
            return (byte)math.clamp((uint)*(byte*)&a, 0u, 1u);
        }

        /// <summary>       Converts a bool value to its ushort representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort touint16safe(bool a)
        {
            return (ushort)math.clamp((uint)*(byte*)&a, 0u, 1u);
        }

        /// <summary>       Converts a bool value to its uint representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint touint32safe(bool a)
        {
            return math.clamp((uint)*(byte*)&a, 0u, 1u);
        }

        /// <summary>       Converts a bool value to its ulong representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong touint64safe(bool a)
        {
            return math.clamp((ulong)*(byte*)&a, 0u, 1u);
        }


        /// <summary>       Converts a bool value to its sbyte representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte toint8safe(bool a)
        {
            return (sbyte)math.clamp((uint)*(byte*)&a, 0u, 1u);
        }

        /// <summary>       Converts a bool value to its short representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short toint16safe(bool a)
        {
            return (short)math.clamp((uint)*(byte*)&a, 0u, 1u);
        }

        /// <summary>       Converts a bool value to its int representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int toint32safe(bool a)
        {
            return (int)math.clamp((uint)*(byte*)&a, 0u, 1u);
        }

        /// <summary>       Converts a bool value to its long representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long toint64safe(bool a)
        {
            return (long)math.clamp((ulong)*(byte*)&a, 0u, 1u);
        }

        /// <summary>       Converts a bool value to its half representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half tof16safe(bool a)
        {
            return new half(*(byte*)&a * new half(1f).value);
        }

        /// <summary>       Converts a bool value to its float representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tof32safe(bool a)
        {
            return math.asfloat(*(byte*)&a * math.asuint(1f));
        }

        /// <summary>       Converts a bool value to its double representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double tof64safe(bool a)
        {
            return math.asdouble(*(byte*)&a * math.asulong(1d));
        }


        /// <summary>       Converts a byte value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(byte a)
        {
            return a != 0;
        }

        /// <summary>       Converts a short value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(ushort a)
        {
            return a != 0;
        }

        /// <summary>       Converts a uint value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(uint a)
        {
            return a != 0;
        }

        /// <summary>       Converts a ulong value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(ulong a)
        {
            return a != 0;
        }


        /// <summary>       Converts an sbyte value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(sbyte a)
        {
            return a != 0;
        }

        /// <summary>       Converts a short value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(short a)
        {
            return a != 0;
        }
        /// <summary>       Converts an int value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static bool toboolsafe(int a)
        {
            return a != 0;
        }

        /// <summary>       Converts a long value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(long a)
        {
            return a != 0;
        }


        /// <summary>       Converts a half value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(half a)
        {
            return a != (half)0f;
        }

        /// <summary>       Converts a float value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(float a)
        {
            return a != 0f;
        }

        /// <summary>       Converts a double value to its bool representation. The underlying value is being clamped to the interval [0,1].        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool toboolsafe(double a)
        {
            return a != 0d;
        }
    }
}