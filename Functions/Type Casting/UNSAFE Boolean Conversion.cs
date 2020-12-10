using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary> UNSAFE (not clamped to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cvt_uint8(bool a)
        { 
Assert.IsBetween<byte>(*(byte*)&a, 0, 1);

            return *(byte*)&a;
        }

        /// <summary> UNSAFE (not clamped to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cvt_uint16(bool a)
        {
            return cvt_uint8(a);
        }

        /// <summary> UNSAFE (not clamped to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cvt_uint32(bool a)
        { 
            return (uint)cvt_int32(a);
        }

        /// <summary> UNSAFE (not clamped to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cvt_uint64(bool a)
        { 
            return cvt_uint8(a);
        }


        /// <summary> UNSAFE (not clamped to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cvt_int8(bool a)
        { 
Assert.IsBetween<sbyte>(*(sbyte*)&a, 0, 1);

            return *(sbyte*)&a;
        }

        /// <summary> UNSAFE (not clamped to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cvt_int16(bool a)
        {
            return cvt_uint8(a);
        }

        /// <summary> UNSAFE (not clamped to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(0, 1)]
        public static int cvt_int32(bool a)
        { 
            return cvt_uint8(a);
        }

        /// <summary> UNSAFE (not clamped to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cvt_int64(bool a)
        { 
            return cvt_uint8(a);
        }

        /// <summary> UNSAFE (not clamped to [0f, 1f]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half cvt_f16(bool a)
        { 
            ushort backingField = (ushort)(cvt_uint8(a) * new half(1f).value);

            return *(half*)&backingField;
        }

        /// <summary> UNSAFE (not clamped to [0f, 1f]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cvt_f32(bool a)
        { 
            return math.asfloat(cvt_uint8(a) * math.asuint(1f));
        }

        /// <summary> UNSAFE (not clamped to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cvt_f64(bool a)
        { 
            return math.asdouble(cvt_uint8(a) * math.asulong(1d));
        }


        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(byte a)
        { 
Assert.IsBetween(a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(ushort a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }
        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(uint a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(ulong a)
        { 
Assert.IsBetween((byte)a, 0, 1);

            return *(bool*)&a;
        }


        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(sbyte a)
        { 
Assert.IsBetween(a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(short a)
        { 
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }
        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static bool cvt_boolean([AssumeRange(0, 1)] int a)
        { 
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }

        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(long a)
        {
Assert.IsBetween((sbyte)a, 0, 1);

            return *(bool*)&a;
        }


        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(half a)
        {
Assert.IsTrue(a.value == new half(1f).value || a.value == 0);

            return a.value == new half(1f).value;
        }

        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(float a)
        {
Assert.IsTrue(a == 1f || a == 0f);

            return math.asint(a) == math.asint(1f);
        }

        /// <summary> UNSAFE (not clamping a to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(double a)
        {
Assert.IsTrue(a == 1d || a == 0d);

            return math.aslong(a) == math.aslong(1d);
        }
    }
}