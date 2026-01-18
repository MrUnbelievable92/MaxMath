using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte shuffleByte2_Managed(byte2 a, byte2 b, math.ShuffleComponent x)
        {
            switch (x)
            {
                case math.ShuffleComponent.LeftX:  return a.x;
                case math.ShuffleComponent.LeftY:  return a.y;
                case math.ShuffleComponent.RightX: return b.x;
                case math.ShuffleComponent.RightY: return b.y;

                default: throw new ArgumentException("Invalid shuffle component.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte shuffleByte3_Managed(byte3 a, byte3 b, math.ShuffleComponent x)
        {
            switch (x)
            {
                case math.ShuffleComponent.LeftX:  return a.x;
                case math.ShuffleComponent.LeftY:  return a.y;
                case math.ShuffleComponent.LeftZ:  return a.z;
                case math.ShuffleComponent.RightX: return b.x;
                case math.ShuffleComponent.RightY: return b.y;
                case math.ShuffleComponent.RightZ: return b.z;

                default: throw new ArgumentException("Invalid shuffle component.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte shuffleByte4_Managed(byte4 a, byte4 b, math.ShuffleComponent x)
        {
            switch (x)
            {
                case math.ShuffleComponent.LeftX:  return a.x;
                case math.ShuffleComponent.LeftY:  return a.y;
                case math.ShuffleComponent.LeftZ:  return a.z;
                case math.ShuffleComponent.LeftW:  return a.w;
                case math.ShuffleComponent.RightX: return b.x;
                case math.ShuffleComponent.RightY: return b.y;
                case math.ShuffleComponent.RightZ: return b.z;
                case math.ShuffleComponent.RightW: return b.w;

                default: throw new ArgumentException("Invalid shuffle component.");
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte2"/>s into a <see cref="byte"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte shuffle(byte2 a, byte2 b, math.ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightW);

                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte2((byte)x, 0)).Byte0;
            }
            else
            {
                return shuffleByte2_Managed(a, b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte2"/>s into a <see cref="MaxMath.byte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 shuffle(byte2 a, byte2 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.RightW);

                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte2((byte)x, (byte)y));
            }
            else
            {
                return new byte2(shuffleByte2_Managed(a, b, x),
                                 shuffleByte2_Managed(a, b, y));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte2"/>s into a <see cref="MaxMath.byte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 shuffle(byte2 a, byte2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.RightW);

                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte4((byte)x, (byte)y, (byte)z, 0));
            }
            else
            {
                return new byte3(shuffleByte2_Managed(a, b, x),
                                 shuffleByte2_Managed(a, b, y),
                                 shuffleByte2_Managed(a, b, z));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte2"/>s into a <see cref="MaxMath.byte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 shuffle(byte2 a, byte2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)w, (byte)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)w, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)w, (byte)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)w, (byte)math.ShuffleComponent.RightW);

                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte4((byte)x, (byte)y, (byte)z, (byte)w));
            }
            else
            {
                return new byte4(shuffleByte2_Managed(a, b, x),
                                 shuffleByte2_Managed(a, b, y),
                                 shuffleByte2_Managed(a, b, z),
                                 shuffleByte2_Managed(a, b, w));
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte3"/>s into a <see cref="byte"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte shuffle(byte3 a, byte3 b, math.ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightW);

                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte2((byte)x, 0)).Byte0;
            }
            else
            {
                return shuffleByte3_Managed(a, b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte3"/>s into a <see cref="MaxMath.byte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 shuffle(byte3 a, byte3 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.RightW);

                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte2((byte)x, (byte)y));
            }
            else
            {
                return new byte2(shuffleByte3_Managed(a, b, x),
                                 shuffleByte3_Managed(a, b, y));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte3"/>s into a <see cref="MaxMath.byte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 shuffle(byte3 a, byte3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.RightW);

                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte4((byte)x, (byte)y, (byte)z, 0));
            }
            else
            {
                return new byte3(shuffleByte3_Managed(a, b, x),
                                 shuffleByte3_Managed(a, b, y),
                                 shuffleByte3_Managed(a, b, z));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte3"/>s into a <see cref="MaxMath.byte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 shuffle(byte3 a, byte3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)z, (byte)math.ShuffleComponent.RightW);
Assert.AreNotEqual((byte)w, (byte)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)w, (byte)math.ShuffleComponent.RightW);

                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte4((byte)x, (byte)y, (byte)z, (byte)w));
            }
            else
            {
                return new byte4(shuffleByte3_Managed(a, b, x),
                                 shuffleByte3_Managed(a, b, y),
                                 shuffleByte3_Managed(a, b, z),
                                 shuffleByte3_Managed(a, b, w));
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte4"/>s into a <see cref="byte"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte shuffle(byte4 a, byte4 b, math.ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte2((byte)x, 0)).Byte0;
            }
            else
            {
                return shuffleByte4_Managed(a, b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte4"/>s into a <see cref="MaxMath.byte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 shuffle(byte4 a, byte4 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte2((byte)x, (byte)y));
            }
            else
            {
                return new byte2(shuffleByte4_Managed(a, b, x),
                                 shuffleByte4_Managed(a, b, y));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte4"/>s into a <see cref="MaxMath.byte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 shuffle(byte4 a, byte4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte4((byte)x, (byte)y, (byte)z, 0));
            }
            else
            {
                return new byte3(shuffleByte4_Managed(a, b, x),
                                 shuffleByte4_Managed(a, b, y),
                                 shuffleByte4_Managed(a, b, z));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte4"/>s into a <see cref="MaxMath.byte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 shuffle(byte4 a, byte4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte4((byte)x, (byte)y, (byte)z, (byte)w));
            }
            else
            {
                return new byte4(shuffleByte4_Managed(a, b, x),
                                 shuffleByte4_Managed(a, b, y),
                                 shuffleByte4_Managed(a, b, z),
                                 shuffleByte4_Managed(a, b, w));
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte2"/>s into an <see cref="sbyte"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte shuffle(sbyte2 a, sbyte2 b, math.ShuffleComponent x)
        {
            return (sbyte)shuffle((byte2)a, (byte2)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte2"/>s into an <see cref="MaxMath.sbyte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 shuffle(sbyte2 a, sbyte2 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return (sbyte2)shuffle((byte2)a, (byte2)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte2"/>s into an <see cref="MaxMath.sbyte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 shuffle(sbyte2 a, sbyte2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return (sbyte3)shuffle((byte2)a, (byte2)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte2"/>s into an <see cref="MaxMath.sbyte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 shuffle(sbyte2 a, sbyte2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return (sbyte4)shuffle((byte2)a, (byte2)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte3"/>s into an <see cref="sbyte"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte shuffle(sbyte3 a, sbyte3 b, math.ShuffleComponent x)
        {
            return (sbyte)shuffle((byte3)a, (byte3)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte3"/>s into an <see cref="MaxMath.sbyte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 shuffle(sbyte3 a, sbyte3 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return (sbyte2)shuffle((byte3)a, (byte3)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte3"/>s into an <see cref="MaxMath.sbyte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 shuffle(sbyte3 a, sbyte3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return (sbyte3)shuffle((byte3)a, (byte3)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte3"/>s into an <see cref="MaxMath.sbyte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 shuffle(sbyte3 a, sbyte3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return (sbyte4)shuffle((byte3)a, (byte3)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte4"/>s into an <see cref="sbyte"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte shuffle(sbyte4 a, sbyte4 b, math.ShuffleComponent x)
        {
            return (sbyte)shuffle((byte4)a, (byte4)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte4"/>s into an <see cref="MaxMath.sbyte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 shuffle(sbyte4 a, sbyte4 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return (sbyte2)shuffle((byte4)a, (byte4)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte4"/>s into an <see cref="MaxMath.sbyte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 shuffle(sbyte4 a, sbyte4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return (sbyte3)shuffle((byte4)a, (byte4)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte4"/>s into an <see cref="MaxMath.sbyte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 shuffle(sbyte4 a, sbyte4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return (sbyte4)shuffle((byte4)a, (byte4)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter2"/>s into a <see cref="MaxMath.quarter"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter shuffle(quarter2 a, quarter2 b, math.ShuffleComponent x)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter2"/>s into a <see cref="MaxMath.quarter2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 shuffle(quarter2 a, quarter2 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter2"/>s into a <see cref="MaxMath.quarter3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 shuffle(quarter2 a, quarter2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter2"/>s into a <see cref="MaxMath.quarter4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 shuffle(quarter2 a, quarter2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter3"/>s into a <see cref="MaxMath.quarter"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter shuffle(quarter3 a, quarter3 b, math.ShuffleComponent x)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter3"/>s into a <see cref="MaxMath.quarter2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 shuffle(quarter3 a, quarter3 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter3"/>s into a <see cref="MaxMath.quarter3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 shuffle(quarter3 a, quarter3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter3"/>s into a <see cref="MaxMath.quarter4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 shuffle(quarter3 a, quarter3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter4"/>s into a <see cref="MaxMath.quarter"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter shuffle(quarter4 a, quarter4 b, math.ShuffleComponent x)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter4"/>s into a <see cref="MaxMath.quarter2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 shuffle(quarter4 a, quarter4 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter4"/>s into a <see cref="MaxMath.quarter3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 shuffle(quarter4 a, quarter4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter4"/>s into a <see cref="MaxMath.quarter4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 shuffle(quarter4 a, quarter4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z, w));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort shuffleUShort2_Managed(ushort2 a, ushort2 b, math.ShuffleComponent x)
        {
            switch (x)
            {
                case math.ShuffleComponent.LeftX:  return a.x;
                case math.ShuffleComponent.LeftY:  return a.y;
                case math.ShuffleComponent.RightX: return b.x;
                case math.ShuffleComponent.RightY: return b.y;

                default: throw new ArgumentException("Invalid shuffle component.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort shuffleUShort3_Managed(ushort3 a, ushort3 b, math.ShuffleComponent x)
        {
            switch (x)
            {
                case math.ShuffleComponent.LeftX:  return a.x;
                case math.ShuffleComponent.LeftY:  return a.y;
                case math.ShuffleComponent.LeftZ:  return a.z;
                case math.ShuffleComponent.RightX: return b.x;
                case math.ShuffleComponent.RightY: return b.y;
                case math.ShuffleComponent.RightZ: return b.z;

                default: throw new ArgumentException("Invalid shuffle component.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort shuffleUShort4_Managed(ushort4 a, ushort4 b, math.ShuffleComponent x)
        {
            switch (x)
            {
                case math.ShuffleComponent.LeftX:  return a.x;
                case math.ShuffleComponent.LeftY:  return a.y;
                case math.ShuffleComponent.LeftZ:  return a.z;
                case math.ShuffleComponent.LeftW:  return a.w;
                case math.ShuffleComponent.RightX: return b.x;
                case math.ShuffleComponent.RightY: return b.y;
                case math.ShuffleComponent.RightZ: return b.z;
                case math.ShuffleComponent.RightW: return b.w;

                default: throw new ArgumentException("Invalid shuffle component");
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort2"/>s into a <see cref="ushort"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort shuffle(ushort2 a, ushort2 b, math.ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightW);

                byte4 shuffleMask = new byte4((byte)x, 0, 0, 0);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask).UShort0;
            }
            else
            {
                return shuffleUShort2_Managed(a, b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort2"/>s into a <see cref="MaxMath.ushort2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 shuffle(ushort2 a, ushort2 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.RightW);

                byte4 shuffleMask = new byte4((byte)x, (byte)y, 0, 0);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask);
            }
            else
            {
                return new ushort2(shuffleUShort2_Managed(a, b, x),
                                   shuffleUShort2_Managed(a, b, y));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort2"/>s into a <see cref="MaxMath.ushort3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 shuffle(ushort2 a, ushort2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.RightW);

                byte4 shuffleMask = new byte4((byte)x, (byte)y, (byte)z, 0);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask);
            }
            else
            {
                return new ushort3(shuffleUShort2_Managed(a, b, x),
                                   shuffleUShort2_Managed(a, b, y),
                                   shuffleUShort2_Managed(a, b, z));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort2"/>s into a <see cref="MaxMath.ushort4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 shuffle(ushort2 a, ushort2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)w, (ushort)math.ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)w, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)w, (ushort)math.ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)w, (ushort)math.ShuffleComponent.RightW);

                byte4 shuffleMask = new byte4((byte)x, (byte)y, (byte)z, (byte)w);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask);
            }
            else
            {
                return new ushort4(shuffleUShort2_Managed(a, b, x),
                                   shuffleUShort2_Managed(a, b, y),
                                   shuffleUShort2_Managed(a, b, z),
                                   shuffleUShort2_Managed(a, b, w));
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort3"/>s into a <see cref="ushort"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort shuffle(ushort3 a, ushort3 b, math.ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightW);

                byte4 shuffleMask = new byte4((byte)x, 0, 0, 0);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask).UShort0;
            }
            else
            {
                return shuffleUShort3_Managed(a, b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort3"/>s into a <see cref="MaxMath.ushort2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 shuffle(ushort3 a, ushort3 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.RightW);

                byte4 shuffleMask = new byte4((byte)x, (byte)y, 0, 0);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask);
            }
            else
            {
                return new ushort2(shuffleUShort3_Managed(a, b, x),
                                   shuffleUShort3_Managed(a, b, y));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort3"/>s into a <see cref="MaxMath.ushort3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 shuffle(ushort3 a, ushort3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.RightW);

                byte4 shuffleMask = new byte4((byte)x, (byte)y, (byte)z, 0);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask);
            }
            else
            {
                return new ushort3(shuffleUShort3_Managed(a, b, x),
                                   shuffleUShort3_Managed(a, b, y),
                                   shuffleUShort3_Managed(a, b, z));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort3"/>s into a <see cref="MaxMath.ushort4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 shuffle(ushort3 a, ushort3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)z, (ushort)math.ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)w, (ushort)math.ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)w, (ushort)math.ShuffleComponent.RightW);

                byte4 shuffleMask = new byte4((byte)x, (byte)y, (byte)z, (byte)w);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask);
            }
            else
            {
                return new ushort4(shuffleUShort3_Managed(a, b, x),
                                   shuffleUShort3_Managed(a, b, y),
                                   shuffleUShort3_Managed(a, b, z),
                                   shuffleUShort3_Managed(a, b, w));
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort4"/>s into a <see cref="ushort"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort shuffle(ushort4 a, ushort4 b, math.ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                byte4 shuffleMask = new byte4((byte)x, 0, 0, 0);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask).UShort0;
            }
            else
            {
                return shuffleUShort4_Managed(a, b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort4"/>s into a <see cref="MaxMath.ushort2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 shuffle(ushort4 a, ushort4 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                byte4 shuffleMask = new byte4((byte)x, (byte)y, 0, 0);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask);
            }
            else
            {
                return new ushort2(shuffleUShort4_Managed(a, b, x),
                                   shuffleUShort4_Managed(a, b, y));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort4"/>s into a <see cref="MaxMath.ushort3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 shuffle(ushort4 a, ushort4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                byte4 shuffleMask = new byte4((byte)x, (byte)y, (byte)z, 0);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask);
            }
            else
            {
                return new ushort3(shuffleUShort4_Managed(a, b, x),
                                   shuffleUShort4_Managed(a, b, y),
                                   shuffleUShort4_Managed(a, b, z));
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort4"/>s into a <see cref="MaxMath.ushort4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 shuffle(ushort4 a, ushort4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                byte4 shuffleMask = new byte4((byte)x, (byte)y, (byte)z, (byte)w);
                shuffleMask = Xse.add_epi8(shuffleMask, shuffleMask);
                byte8 newShuffleMask = Xse.unpacklo_epi8(shuffleMask, shuffleMask);
                newShuffleMask += new v128(0, 1, 0, 1, 0, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0);

                return Xse.shuffle_epi8(Xse.unpacklo_epi64(a, b), newShuffleMask);
            }
            else
            {
                return new ushort4(shuffleUShort4_Managed(a, b, x),
                                   shuffleUShort4_Managed(a, b, y),
                                   shuffleUShort4_Managed(a, b, z),
                                   shuffleUShort4_Managed(a, b, w));
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short2"/>s into a <see cref="short"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short shuffle(short2 a, short2 b, math.ShuffleComponent x)
        {
            return (short)shuffle((ushort2)a, (ushort2)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short2"/>s into a <see cref="MaxMath.short2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 shuffle(short2 a, short2 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return (short2)shuffle((ushort2)a, (ushort2)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short2"/>s into a <see cref="MaxMath.short3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 shuffle(short2 a, short2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return (short3)shuffle((ushort2)a, (ushort2)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short2"/>s into a <see cref="MaxMath.short4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 shuffle(short2 a, short2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return (short4)shuffle((ushort2)a, (ushort2)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short3"/>s into a <see cref="short"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short shuffle(short3 a, short3 b, math.ShuffleComponent x)
        {
            return (short)shuffle((ushort3)a, (ushort3)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short3"/>s into a <see cref="MaxMath.short2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 shuffle(short3 a, short3 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return (short2)shuffle((ushort3)a, (ushort3)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short3"/>s into a <see cref="MaxMath.short3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 shuffle(short3 a, short3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return (short3)shuffle((ushort3)a, (ushort3)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short3"/>s into a <see cref="MaxMath.short4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 shuffle(short3 a, short3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return (short4)shuffle((ushort3)a, (ushort3)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short4"/>s into a <see cref="short"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short shuffle(short4 a, short4 b, math.ShuffleComponent x)
        {
            return (short)shuffle((ushort4)a, (ushort4)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short4"/>s into a <see cref="MaxMath.short2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 shuffle(short4 a, short4 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return (short2)shuffle((ushort4)a, (ushort4)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short4"/>s into a <see cref="MaxMath.short3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 shuffle(short4 a, short4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return (short3)shuffle((ushort4)a, (ushort4)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short4"/>s into a <see cref="MaxMath.short4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 shuffle(short4 a, short4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return (short4)shuffle((ushort4)a, (ushort4)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half2"/>s into a <see cref="half"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half shuffle(half2 a, half2 b, math.ShuffleComponent x)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half2"/>s into a <see cref="half2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 shuffle(half2 a, half2 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half2"/>s into a <see cref="half3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 shuffle(half2 a, half2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half2"/>s into a <see cref="half4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 shuffle(half2 a, half2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half3"/>s into a <see cref="half"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half shuffle(half3 a, half3 b, math.ShuffleComponent x)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half3"/>s into a <see cref="half2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 shuffle(half3 a, half3 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half3"/>s into a <see cref="half3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 shuffle(half3 a, half3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half3"/>s into a <see cref="half4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 shuffle(half3 a, half3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half4"/>s into a <see cref="half"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half shuffle(half4 a, half4 b, math.ShuffleComponent x)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half4"/>s into a <see cref="half2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 shuffle(half4 a, half4 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half4"/>s into a <see cref="half3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 shuffle(half4 a, half4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="half4"/>s into a <see cref="half4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 shuffle(half4 a, half4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong2"/>s into a <see cref="ulong"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong shuffle(ulong2 a, ulong2 b, math.ShuffleComponent x)
        {
            return math.asulong(math.shuffle(asdouble(a), asdouble(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong2"/>s into a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shuffle(ulong2 a, ulong2 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return asulong(math.shuffle(asdouble(a), asdouble(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong2"/>s into a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shuffle(ulong2 a, ulong2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return asulong(math.shuffle(asdouble(a), asdouble(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong2"/>s into a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shuffle(ulong2 a, ulong2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return asulong(math.shuffle(asdouble(a), asdouble(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong3"/>s into a <see cref="ulong"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong shuffle(ulong3 a, ulong3 b, math.ShuffleComponent x)
        {
            return math.asulong(math.shuffle(asdouble(a), asdouble(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong3"/>s into a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shuffle(ulong3 a, ulong3 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return asulong(math.shuffle(asdouble(a), asdouble(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong3"/>s into a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shuffle(ulong3 a, ulong3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return asulong(math.shuffle(asdouble(a), asdouble(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong3"/>s into a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shuffle(ulong3 a, ulong3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return asulong(math.shuffle(asdouble(a), asdouble(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong4"/>s into a <see cref="ulong"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong shuffle(ulong4 a, ulong4 b, math.ShuffleComponent x)
        {
            return math.asulong(math.shuffle(asdouble(a), asdouble(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong4"/>s into a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shuffle(ulong4 a, ulong4 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return asulong(math.shuffle(asdouble(a), asdouble(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong4"/>s into a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shuffle(ulong4 a, ulong4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return asulong(math.shuffle(asdouble(a), asdouble(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong4"/>s into a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shuffle(ulong4 a, ulong4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return asulong(math.shuffle(asdouble(a), asdouble(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long2"/>s into a <see cref="long"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long shuffle(long2 a, long2 b, math.ShuffleComponent x)
        {
            return (long)shuffle((ulong2)a, (ulong2)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long2"/>s into a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shuffle(long2 a, long2 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return (long2)shuffle((ulong2)a, (ulong2)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long2"/>s into a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shuffle(long2 a, long2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return (long3)shuffle((ulong2)a, (ulong2)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long2"/>s into a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shuffle(long2 a, long2 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return (long4)shuffle((ulong2)a, (ulong2)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long3"/>s into a <see cref="long"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long shuffle(long3 a, long3 b, math.ShuffleComponent x)
        {
            return (long)shuffle((ulong3)a, (ulong3)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long3"/>s into a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shuffle(long3 a, long3 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return (long2)shuffle((ulong3)a, (ulong3)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long3"/>s into a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shuffle(long3 a, long3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return (long3)shuffle((ulong3)a, (ulong3)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long3"/>s into a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shuffle(long3 a, long3 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return (long4)shuffle((ulong3)a, (ulong3)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long4"/>s into a <see cref="long"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long shuffle(long4 a, long4 b, math.ShuffleComponent x)
        {
            return (long)shuffle((ulong4)a, (ulong4)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long4"/>s into a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shuffle(long4 a, long4 b, math.ShuffleComponent x, math.ShuffleComponent y)
        {
            return (long2)shuffle((ulong4)a, (ulong4)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long4"/>s into a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shuffle(long4 a, long4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z)
        {
            return (long3)shuffle((ulong4)a, (ulong4)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long4"/>s into a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shuffle(long4 a, long4 b, math.ShuffleComponent x, math.ShuffleComponent y, math.ShuffleComponent z, math.ShuffleComponent w)
        {
            return (long4)shuffle((ulong4)a, (ulong4)b, x, y, z, w);
        }
    }
}