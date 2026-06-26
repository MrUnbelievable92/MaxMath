using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

namespace MaxMath
{
    unsafe public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte shuffleByte2_Managed(byte2 a, byte2 b, ShuffleComponent x)
        {
            switch (x)
            {
                case ShuffleComponent.LeftX:  return a.x;
                case ShuffleComponent.LeftY:  return a.y;
                case ShuffleComponent.RightX: return b.x;
                case ShuffleComponent.RightY: return b.y;

                default: throw new ArgumentException("Invalid shuffle component.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte shuffleByte3_Managed(byte3 a, byte3 b, ShuffleComponent x)
        {
            switch (x)
            {
                case ShuffleComponent.LeftX:  return a.x;
                case ShuffleComponent.LeftY:  return a.y;
                case ShuffleComponent.LeftZ:  return a.z;
                case ShuffleComponent.RightX: return b.x;
                case ShuffleComponent.RightY: return b.y;
                case ShuffleComponent.RightZ: return b.z;

                default: throw new ArgumentException("Invalid shuffle component.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte shuffleByte4_Managed(byte4 a, byte4 b, ShuffleComponent x)
        {
            switch (x)
            {
                case ShuffleComponent.LeftX:  return a.x;
                case ShuffleComponent.LeftY:  return a.y;
                case ShuffleComponent.LeftZ:  return a.z;
                case ShuffleComponent.LeftW:  return a.w;
                case ShuffleComponent.RightX: return b.x;
                case ShuffleComponent.RightY: return b.y;
                case ShuffleComponent.RightZ: return b.z;
                case ShuffleComponent.RightW: return b.w;

                default: throw new ArgumentException("Invalid shuffle component.");
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte2"/>s into a <see cref="byte"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte shuffle(byte2 a, byte2 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightW);

                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte2((byte)x, 0)).Byte0;
            }
            else
            {
                return shuffleByte2_Managed(a, b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte2"/>s into a <see cref="MaxMath.byte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 shuffle(byte2 a, byte2 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.RightW);

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
        public static byte3 shuffle(byte2 a, byte2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.RightW);

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
        public static byte4 shuffle(byte2 a, byte2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)w, (byte)ShuffleComponent.LeftZ);
Assert.AreNotEqual((byte)w, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)w, (byte)ShuffleComponent.RightZ);
Assert.AreNotEqual((byte)w, (byte)ShuffleComponent.RightW);

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
        public static byte shuffle(byte3 a, byte3 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightW);

                return Xse.shuffle_epi8(Xse.unpacklo_epi32(a, b), new byte2((byte)x, 0)).Byte0;
            }
            else
            {
                return shuffleByte3_Managed(a, b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.byte3"/>s into a <see cref="MaxMath.byte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 shuffle(byte3 a, byte3 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.RightW);

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
        public static byte3 shuffle(byte3 a, byte3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.RightW);

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
        public static byte4 shuffle(byte3 a, byte3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)x, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)y, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)z, (byte)ShuffleComponent.RightW);
Assert.AreNotEqual((byte)w, (byte)ShuffleComponent.LeftW);
Assert.AreNotEqual((byte)w, (byte)ShuffleComponent.RightW);

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
        public static byte shuffle(byte4 a, byte4 b, ShuffleComponent x)
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
        public static byte2 shuffle(byte4 a, byte4 b, ShuffleComponent x, ShuffleComponent y)
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
        public static byte3 shuffle(byte4 a, byte4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
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
        public static byte4 shuffle(byte4 a, byte4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
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
        public static sbyte shuffle(sbyte2 a, sbyte2 b, ShuffleComponent x)
        {
            return (sbyte)shuffle((byte2)a, (byte2)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte2"/>s into an <see cref="MaxMath.sbyte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 shuffle(sbyte2 a, sbyte2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return (sbyte2)shuffle((byte2)a, (byte2)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte2"/>s into an <see cref="MaxMath.sbyte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 shuffle(sbyte2 a, sbyte2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return (sbyte3)shuffle((byte2)a, (byte2)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte2"/>s into an <see cref="MaxMath.sbyte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 shuffle(sbyte2 a, sbyte2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return (sbyte4)shuffle((byte2)a, (byte2)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte3"/>s into an <see cref="sbyte"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte shuffle(sbyte3 a, sbyte3 b, ShuffleComponent x)
        {
            return (sbyte)shuffle((byte3)a, (byte3)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte3"/>s into an <see cref="MaxMath.sbyte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 shuffle(sbyte3 a, sbyte3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return (sbyte2)shuffle((byte3)a, (byte3)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte3"/>s into an <see cref="MaxMath.sbyte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 shuffle(sbyte3 a, sbyte3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return (sbyte3)shuffle((byte3)a, (byte3)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte3"/>s into an <see cref="MaxMath.sbyte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 shuffle(sbyte3 a, sbyte3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return (sbyte4)shuffle((byte3)a, (byte3)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte4"/>s into an <see cref="sbyte"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte shuffle(sbyte4 a, sbyte4 b, ShuffleComponent x)
        {
            return (sbyte)shuffle((byte4)a, (byte4)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte4"/>s into an <see cref="MaxMath.sbyte2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 shuffle(sbyte4 a, sbyte4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return (sbyte2)shuffle((byte4)a, (byte4)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte4"/>s into an <see cref="MaxMath.sbyte3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 shuffle(sbyte4 a, sbyte4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return (sbyte3)shuffle((byte4)a, (byte4)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.sbyte4"/>s into an <see cref="MaxMath.sbyte4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 shuffle(sbyte4 a, sbyte4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return (sbyte4)shuffle((byte4)a, (byte4)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter2"/>s into a <see cref="MaxMath.quarter"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter shuffle(quarter2 a, quarter2 b, ShuffleComponent x)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter2"/>s into a <see cref="MaxMath.quarter2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 shuffle(quarter2 a, quarter2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter2"/>s into a <see cref="MaxMath.quarter3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 shuffle(quarter2 a, quarter2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter2"/>s into a <see cref="MaxMath.quarter4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 shuffle(quarter2 a, quarter2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter3"/>s into a <see cref="MaxMath.quarter"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter shuffle(quarter3 a, quarter3 b, ShuffleComponent x)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter3"/>s into a <see cref="MaxMath.quarter2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 shuffle(quarter3 a, quarter3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter3"/>s into a <see cref="MaxMath.quarter3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 shuffle(quarter3 a, quarter3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter3"/>s into a <see cref="MaxMath.quarter4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 shuffle(quarter3 a, quarter3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter4"/>s into a <see cref="MaxMath.quarter"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter shuffle(quarter4 a, quarter4 b, ShuffleComponent x)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter4"/>s into a <see cref="MaxMath.quarter2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 shuffle(quarter4 a, quarter4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter4"/>s into a <see cref="MaxMath.quarter3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 shuffle(quarter4 a, quarter4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.quarter4"/>s into a <see cref="MaxMath.quarter4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 shuffle(quarter4 a, quarter4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return asquarter(shuffle(asbyte(a), asbyte(b), x, y, z, w));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort shuffleUShort2_Managed(ushort2 a, ushort2 b, ShuffleComponent x)
        {
            switch (x)
            {
                case ShuffleComponent.LeftX:  return a.x;
                case ShuffleComponent.LeftY:  return a.y;
                case ShuffleComponent.RightX: return b.x;
                case ShuffleComponent.RightY: return b.y;

                default: throw new ArgumentException("Invalid shuffle component.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort shuffleUShort3_Managed(ushort3 a, ushort3 b, ShuffleComponent x)
        {
            switch (x)
            {
                case ShuffleComponent.LeftX:  return a.x;
                case ShuffleComponent.LeftY:  return a.y;
                case ShuffleComponent.LeftZ:  return a.z;
                case ShuffleComponent.RightX: return b.x;
                case ShuffleComponent.RightY: return b.y;
                case ShuffleComponent.RightZ: return b.z;

                default: throw new ArgumentException("Invalid shuffle component.");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort shuffleUShort4_Managed(ushort4 a, ushort4 b, ShuffleComponent x)
        {
            switch (x)
            {
                case ShuffleComponent.LeftX:  return a.x;
                case ShuffleComponent.LeftY:  return a.y;
                case ShuffleComponent.LeftZ:  return a.z;
                case ShuffleComponent.LeftW:  return a.w;
                case ShuffleComponent.RightX: return b.x;
                case ShuffleComponent.RightY: return b.y;
                case ShuffleComponent.RightZ: return b.z;
                case ShuffleComponent.RightW: return b.w;

                default: throw new ArgumentException("Invalid shuffle component");
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ushort2"/>s into a <see cref="ushort"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort shuffle(ushort2 a, ushort2 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightW);

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
        public static ushort2 shuffle(ushort2 a, ushort2 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.RightW);

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
        public static ushort3 shuffle(ushort2 a, ushort2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.RightW);

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
        public static ushort4 shuffle(ushort2 a, ushort2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)w, (ushort)ShuffleComponent.LeftZ);
Assert.AreNotEqual((ushort)w, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)w, (ushort)ShuffleComponent.RightZ);
Assert.AreNotEqual((ushort)w, (ushort)ShuffleComponent.RightW);

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
        public static ushort shuffle(ushort3 a, ushort3 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightW);

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
        public static ushort2 shuffle(ushort3 a, ushort3 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.RightW);

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
        public static ushort3 shuffle(ushort3 a, ushort3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.RightW);

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
        public static ushort4 shuffle(ushort3 a, ushort3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)x, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)y, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)z, (ushort)ShuffleComponent.RightW);
Assert.AreNotEqual((ushort)w, (ushort)ShuffleComponent.LeftW);
Assert.AreNotEqual((ushort)w, (ushort)ShuffleComponent.RightW);

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
        public static ushort shuffle(ushort4 a, ushort4 b, ShuffleComponent x)
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
        public static ushort2 shuffle(ushort4 a, ushort4 b, ShuffleComponent x, ShuffleComponent y)
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
        public static ushort3 shuffle(ushort4 a, ushort4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
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
        public static ushort4 shuffle(ushort4 a, ushort4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
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
        public static short shuffle(short2 a, short2 b, ShuffleComponent x)
        {
            return (short)shuffle((ushort2)a, (ushort2)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short2"/>s into a <see cref="MaxMath.short2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 shuffle(short2 a, short2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return (short2)shuffle((ushort2)a, (ushort2)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short2"/>s into a <see cref="MaxMath.short3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 shuffle(short2 a, short2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return (short3)shuffle((ushort2)a, (ushort2)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short2"/>s into a <see cref="MaxMath.short4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 shuffle(short2 a, short2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return (short4)shuffle((ushort2)a, (ushort2)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short3"/>s into a <see cref="short"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short shuffle(short3 a, short3 b, ShuffleComponent x)
        {
            return (short)shuffle((ushort3)a, (ushort3)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short3"/>s into a <see cref="MaxMath.short2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 shuffle(short3 a, short3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return (short2)shuffle((ushort3)a, (ushort3)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short3"/>s into a <see cref="MaxMath.short3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 shuffle(short3 a, short3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return (short3)shuffle((ushort3)a, (ushort3)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short3"/>s into a <see cref="MaxMath.short4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 shuffle(short3 a, short3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return (short4)shuffle((ushort3)a, (ushort3)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short4"/>s into a <see cref="short"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short shuffle(short4 a, short4 b, ShuffleComponent x)
        {
            return (short)shuffle((ushort4)a, (ushort4)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short4"/>s into a <see cref="MaxMath.short2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 shuffle(short4 a, short4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return (short2)shuffle((ushort4)a, (ushort4)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short4"/>s into a <see cref="MaxMath.short3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 shuffle(short4 a, short4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return (short3)shuffle((ushort4)a, (ushort4)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.short4"/>s into a <see cref="MaxMath.short4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 shuffle(short4 a, short4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return (short4)shuffle((ushort4)a, (ushort4)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half2"/>s into a <see cref="MaxMath.half"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half shuffle(half2 a, half2 b, ShuffleComponent x)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half2"/>s into a <see cref="MaxMath.half2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 shuffle(half2 a, half2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half2"/>s into a <see cref="MaxMath.half3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 shuffle(half2 a, half2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half2"/>s into a <see cref="MaxMath.half4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 shuffle(half2 a, half2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half3"/>s into a <see cref="MaxMath.half"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half shuffle(half3 a, half3 b, ShuffleComponent x)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half3"/>s into a <see cref="MaxMath.half2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 shuffle(half3 a, half3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half3"/>s into a <see cref="MaxMath.half3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 shuffle(half3 a, half3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half3"/>s into a <see cref="MaxMath.half4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 shuffle(half3 a, half3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half4"/>s into a <see cref="MaxMath.half"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half shuffle(half4 a, half4 b, ShuffleComponent x)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half4"/>s into a <see cref="MaxMath.half2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 shuffle(half4 a, half4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half4"/>s into a <see cref="MaxMath.half3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 shuffle(half4 a, half4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.half4"/>s into a <see cref="MaxMath.half4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 shuffle(half4 a, half4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return ashalf(shuffle(asushort(a), asushort(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint2"/>s into a <see cref="uint"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint shuffle(uint2 a, uint2 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint2)a, (Unity.Mathematics.uint2)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint2"/>s into a <see cref="MaxMath.uint2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shuffle(uint2 a, uint2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint2)a, (Unity.Mathematics.uint2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint2"/>s into a <see cref="MaxMath.uint3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shuffle(uint2 a, uint2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint2)a, (Unity.Mathematics.uint2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint2"/>s into a <see cref="MaxMath.uint4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shuffle(uint2 a, uint2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint2)a, (Unity.Mathematics.uint2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }

        
        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint3"/>s into a <see cref="uint"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint shuffle(uint3 a, uint3 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint3)a, (Unity.Mathematics.uint3)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint3"/>s into a <see cref="MaxMath.uint3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shuffle(uint3 a, uint3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint3)a, (Unity.Mathematics.uint3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint3"/>s into a <see cref="MaxMath.uint3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shuffle(uint3 a, uint3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint3)a, (Unity.Mathematics.uint3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint3"/>s into a <see cref="MaxMath.uint4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shuffle(uint3 a, uint3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint3)a, (Unity.Mathematics.uint3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }

        
        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint4"/>s into a <see cref="uint"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint shuffle(uint4 a, uint4 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint4)a, (Unity.Mathematics.uint4)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint4"/>s into a <see cref="MaxMath.uint4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 shuffle(uint4 a, uint4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint4)a, (Unity.Mathematics.uint4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint4"/>s into a <see cref="MaxMath.uint4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 shuffle(uint4 a, uint4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint4)a, (Unity.Mathematics.uint4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.uint4"/>s into a <see cref="MaxMath.uint4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 shuffle(uint4 a, uint4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.uint4)a, (Unity.Mathematics.uint4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int2"/>s into an <see cref="int"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int shuffle(int2 a, int2 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int2)a, (Unity.Mathematics.int2)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int2"/>s into an <see cref="MaxMath.int2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shuffle(int2 a, int2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int2)a, (Unity.Mathematics.int2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int2"/>s into an <see cref="MaxMath.int3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shuffle(int2 a, int2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int2)a, (Unity.Mathematics.int2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int2"/>s into an <see cref="MaxMath.int4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shuffle(int2 a, int2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int2)a, (Unity.Mathematics.int2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }

        
        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int3"/>s into an <see cref="int"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int shuffle(int3 a, int3 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int3)a, (Unity.Mathematics.int3)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int3"/>s into an <see cref="MaxMath.int3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shuffle(int3 a, int3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int3)a, (Unity.Mathematics.int3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int3"/>s into an <see cref="MaxMath.int3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shuffle(int3 a, int3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int3)a, (Unity.Mathematics.int3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int3"/>s into an <see cref="MaxMath.int4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shuffle(int3 a, int3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int3)a, (Unity.Mathematics.int3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }

        
        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int4"/>s into an <see cref="int"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int shuffle(int4 a, int4 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int4)a, (Unity.Mathematics.int4)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int4"/>s into an <see cref="MaxMath.int4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 shuffle(int4 a, int4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int4)a, (Unity.Mathematics.int4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int4"/>s into an <see cref="MaxMath.int4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 shuffle(int4 a, int4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int4)a, (Unity.Mathematics.int4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.int4"/>s into an <see cref="MaxMath.int4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 shuffle(int4 a, int4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.int4)a, (Unity.Mathematics.int4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float2"/>s into a <see cref="float"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float shuffle(float2 a, float2 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float2)a, (Unity.Mathematics.float2)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float2"/>s into a <see cref="MaxMath.float2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 shuffle(float2 a, float2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float2)a, (Unity.Mathematics.float2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float2"/>s into a <see cref="MaxMath.float3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 shuffle(float2 a, float2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float2)a, (Unity.Mathematics.float2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float2"/>s into a <see cref="MaxMath.float4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 shuffle(float2 a, float2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float2)a, (Unity.Mathematics.float2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }

        
        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float3"/>s into a <see cref="float"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float shuffle(float3 a, float3 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float3)a, (Unity.Mathematics.float3)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float3"/>s into a <see cref="MaxMath.float3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 shuffle(float3 a, float3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float3)a, (Unity.Mathematics.float3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float3"/>s into a <see cref="MaxMath.float3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 shuffle(float3 a, float3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float3)a, (Unity.Mathematics.float3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float3"/>s into a <see cref="MaxMath.float4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 shuffle(float3 a, float3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float3)a, (Unity.Mathematics.float3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }

        
        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float4"/>s into a <see cref="float"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float shuffle(float4 a, float4 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float4)a, (Unity.Mathematics.float4)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float4"/>s into a <see cref="MaxMath.float4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 shuffle(float4 a, float4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float4)a, (Unity.Mathematics.float4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float4"/>s into a <see cref="MaxMath.float4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 shuffle(float4 a, float4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float4)a, (Unity.Mathematics.float4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.float4"/>s into a <see cref="MaxMath.float4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 shuffle(float4 a, float4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.float4)a, (Unity.Mathematics.float4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double2"/>s into a <see cref="double"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double shuffle(double2 a, double2 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double2)a, (Unity.Mathematics.double2)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double2"/>s into a <see cref="MaxMath.double2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 shuffle(double2 a, double2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double2)a, (Unity.Mathematics.double2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double2"/>s into a <see cref="MaxMath.double3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 shuffle(double2 a, double2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double2)a, (Unity.Mathematics.double2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double2"/>s into a <see cref="MaxMath.double4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 shuffle(double2 a, double2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double2)a, (Unity.Mathematics.double2)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }

        
        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double3"/>s into a <see cref="double"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double shuffle(double3 a, double3 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double3)a, (Unity.Mathematics.double3)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double3"/>s into a <see cref="MaxMath.double3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 shuffle(double3 a, double3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double3)a, (Unity.Mathematics.double3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double3"/>s into a <see cref="MaxMath.double3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 shuffle(double3 a, double3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double3)a, (Unity.Mathematics.double3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double3"/>s into a <see cref="MaxMath.double4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 shuffle(double3 a, double3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double3)a, (Unity.Mathematics.double3)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }

        
        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double4"/>s into a <see cref="double"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double shuffle(double4 a, double4 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double4)a, (Unity.Mathematics.double4)b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double4"/>s into a <see cref="MaxMath.double4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 shuffle(double4 a, double4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double4)a, (Unity.Mathematics.double4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double4"/>s into a <see cref="MaxMath.double4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 shuffle(double4 a, double4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double4)a, (Unity.Mathematics.double4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.double4"/>s into a <see cref="MaxMath.double4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 shuffle(double4 a, double4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle((Unity.Mathematics.double4)a, (Unity.Mathematics.double4)b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong2"/>s into a <see cref="ulong"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong shuffle(ulong2 a, ulong2 b, ShuffleComponent x)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong2"/>s into a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shuffle(ulong2 a, ulong2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong2"/>s into a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shuffle(ulong2 a, ulong2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong2"/>s into a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shuffle(ulong2 a, ulong2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong3"/>s into a <see cref="ulong"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong shuffle(ulong3 a, ulong3 b, ShuffleComponent x)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong3"/>s into a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shuffle(ulong3 a, ulong3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong3"/>s into a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shuffle(ulong3 a, ulong3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong3"/>s into a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shuffle(ulong3 a, ulong3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong4"/>s into a <see cref="ulong"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong shuffle(ulong4 a, ulong4 b, ShuffleComponent x)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong4"/>s into a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 shuffle(ulong4 a, ulong4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x, y));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong4"/>s into a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 shuffle(ulong4 a, ulong4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x, y, z));
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.ulong4"/>s into a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 shuffle(ulong4 a, ulong4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return asulong(shuffle(asdouble(a), asdouble(b), x, y, z, w));
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long2"/>s into a <see cref="long"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long shuffle(long2 a, long2 b, ShuffleComponent x)
        {
            return (long)shuffle((ulong2)a, (ulong2)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long2"/>s into a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shuffle(long2 a, long2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return (long2)shuffle((ulong2)a, (ulong2)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long2"/>s into a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shuffle(long2 a, long2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return (long3)shuffle((ulong2)a, (ulong2)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long2"/>s into a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shuffle(long2 a, long2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return (long4)shuffle((ulong2)a, (ulong2)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long3"/>s into a <see cref="long"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long shuffle(long3 a, long3 b, ShuffleComponent x)
        {
            return (long)shuffle((ulong3)a, (ulong3)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long3"/>s into a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shuffle(long3 a, long3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return (long2)shuffle((ulong3)a, (ulong3)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long3"/>s into a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shuffle(long3 a, long3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return (long3)shuffle((ulong3)a, (ulong3)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long3"/>s into a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shuffle(long3 a, long3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return (long4)shuffle((ulong3)a, (ulong3)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long4"/>s into a <see cref="long"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long shuffle(long4 a, long4 b, ShuffleComponent x)
        {
            return (long)shuffle((ulong4)a, (ulong4)b, x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long4"/>s into a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 shuffle(long4 a, long4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return (long2)shuffle((ulong4)a, (ulong4)b, x, y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long4"/>s into a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 shuffle(long4 a, long4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return (long3)shuffle((ulong4)a, (ulong4)b, x, y, z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.long4"/>s into a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 shuffle(long4 a, long4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return (long4)shuffle((ulong4)a, (ulong4)b, x, y, z, w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool2 a, bool2 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(bool2 a, bool2 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(bool2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(bool2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool3 a, bool3 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(bool3 a, bool3 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(bool3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(bool3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool4 a, bool4 b, ShuffleComponent x)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(bool4 a, bool4 b, ShuffleComponent x, ShuffleComponent y)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(bool4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z);
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(bool4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            return Unity.Mathematics.math.shuffle(a, b, (Unity.Mathematics.math.ShuffleComponent)x, (Unity.Mathematics.math.ShuffleComponent)y, (Unity.Mathematics.math.ShuffleComponent)z, (Unity.Mathematics.math.ShuffleComponent)w);
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool2 a, bool2 b, ShuffleComponent x) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool2 a, Unity.Mathematics.bool2 b, ShuffleComponent x) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool2 a, Unity.Mathematics.bool2 b, ShuffleComponent x) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(Unity.Mathematics.bool2 a, bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(bool2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(Unity.Mathematics.bool2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(Unity.Mathematics.bool2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(bool2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(Unity.Mathematics.bool2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(Unity.Mathematics.bool2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(bool2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((bool2)a, (bool2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(Unity.Mathematics.bool2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((bool2)a, (bool2)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool3 a, bool3 b, ShuffleComponent x) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool3 a, Unity.Mathematics.bool3 b, ShuffleComponent x) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool3 a, Unity.Mathematics.bool3 b, ShuffleComponent x) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(Unity.Mathematics.bool3 a, bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(bool3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(Unity.Mathematics.bool3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(Unity.Mathematics.bool3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(bool3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(Unity.Mathematics.bool3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(Unity.Mathematics.bool3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(bool3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((bool3)a, (bool3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(Unity.Mathematics.bool3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((bool3)a, (bool3)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool4 a, bool4 b, ShuffleComponent x) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool4 a, Unity.Mathematics.bool4 b, ShuffleComponent x) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool4 a, Unity.Mathematics.bool4 b, ShuffleComponent x) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(Unity.Mathematics.bool4 a, bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(bool4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 shuffle(Unity.Mathematics.bool4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(Unity.Mathematics.bool4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(bool4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 shuffle(Unity.Mathematics.bool4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(Unity.Mathematics.bool4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(bool4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((bool4)a, (bool4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 shuffle(Unity.Mathematics.bool4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((bool4)a, (bool4)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x2 a, mask8x2 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((byte2)(v128)a, (byte2)(v128)b, x));
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(mask8x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((byte2)(v128)a, (byte2)(v128)b, x, y);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(mask8x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((byte2)(v128)a, (byte2)(v128)b, x, y, z);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(mask8x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((byte2)(v128)a, (byte2)(v128)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x3 a, mask8x3 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((byte3)(v128)a, (byte3)(v128)b, x));
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(mask8x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((byte3)(v128)a, (byte3)(v128)b, x, y);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(mask8x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((byte3)(v128)a, (byte3)(v128)b, x, y, z);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(mask8x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((byte3)(v128)a, (byte3)(v128)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x4 a, mask8x4 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((byte4)(v128)a, (byte4)(v128)b, x));
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(mask8x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((byte4)(v128)a, (byte4)(v128)b, x, y);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(mask8x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((byte4)(v128)a, (byte4)(v128)b, x, y, z);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(mask8x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((byte4)(v128)a, (byte4)(v128)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x2 a, mask16x2 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((ushort2)(v128)a, (ushort2)(v128)b, x));
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ushort2)(v128)a, (ushort2)(v128)b, x, y);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ushort2)(v128)a, (ushort2)(v128)b, x, y, z);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ushort2)(v128)a, (ushort2)(v128)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x3 a, mask16x3 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((ushort3)(v128)a, (ushort3)(v128)b, x));
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ushort3)(v128)a, (ushort3)(v128)b, x, y);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ushort3)(v128)a, (ushort3)(v128)b, x, y, z);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ushort3)(v128)a, (ushort3)(v128)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x4 a, mask16x4 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((ushort4)(v128)a, (ushort4)(v128)b, x));
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ushort4)(v128)a, (ushort4)(v128)b, x, y);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ushort4)(v128)a, (ushort4)(v128)b, x, y, z);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ushort4)(v128)a, (ushort4)(v128)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x2 a, mask32x2 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((uint2)(v128)a, (uint2)(v128)b, x));
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((uint2)(v128)a, (uint2)(v128)b, x, y);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((uint2)(v128)a, (uint2)(v128)b, x, y, z);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((uint2)(v128)a, (uint2)(v128)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x3 a, mask32x3 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((uint3)(v128)a, (uint3)(v128)b, x));
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((uint3)(v128)a, (uint3)(v128)b, x, y);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((uint3)(v128)a, (uint3)(v128)b, x, y, z);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((uint3)(v128)a, (uint3)(v128)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x4 a, mask32x4 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((uint4)(v128)a, (uint4)(v128)b, x));
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((uint4)(v128)a, (uint4)(v128)b, x, y);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((uint4)(v128)a, (uint4)(v128)b, x, y, z);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((uint4)(v128)a, (uint4)(v128)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x2 a, mask64x2 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((ulong2)(v128)a, (ulong2)(v128)b, x));
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ulong2)(v128)a, (ulong2)(v128)b, x, y);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v256)shuffle((ulong2)(v128)a, (ulong2)(v128)b, x, y, z);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v256)shuffle((ulong2)(v128)a, (ulong2)(v128)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool2)a, (bool2)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x3 a, mask64x3 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((ulong3)(v256)a, (ulong3)(v256)b, x));
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ulong3)(v256)a, (ulong3)(v256)b, x, y);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v256)shuffle((ulong3)(v256)a, (ulong3)(v256)b, x, y, z);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool3"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v256)shuffle((ulong3)(v256)a, (ulong3)(v256)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool3)a, (bool3)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x4 a, mask64x4 b, ShuffleComponent x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return tobool(shuffle((ulong4)(v256)a, (ulong4)(v256)b, x));
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v128)shuffle((ulong4)(v256)a, (ulong4)(v256)b, x, y);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v256)shuffle((ulong4)(v256)a, (ulong4)(v256)b, x, y, z);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y, z);
            }
        }

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool4"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (v256)shuffle((ulong4)(v256)a, (ulong4)(v256)b, x, y, z, w);
            }
            else
            {
                return shuffle((bool4)a, (bool4)b, x, y, z, w);
            }
        }


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x2 a, bool2 b, ShuffleComponent x) => shuffle((mask8x2)a, (mask8x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x) => shuffle((mask8x2)a, (mask8x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x2 a, mask16x2 b, ShuffleComponent x) => shuffle((mask16x2)a, (mask16x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x2 a, mask32x2 b, ShuffleComponent x) => shuffle((mask32x2)a, (mask32x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x2 a, mask64x2 b, ShuffleComponent x) => shuffle((mask64x2)a, (mask64x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool2 a, mask8x2 b, ShuffleComponent x) => shuffle((mask8x2)a, (mask8x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool2 a, mask8x2 b, ShuffleComponent x) => shuffle((mask8x2)a, (mask8x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x2 a, mask8x2 b, ShuffleComponent x) => shuffle((mask16x2)a, (mask16x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x2 a, mask8x2 b, ShuffleComponent x) => shuffle((mask32x2)a, (mask32x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x2 a, mask8x2 b, ShuffleComponent x) => shuffle((mask64x2)a, (mask64x2)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(mask8x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x2)a, (mask8x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(mask8x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x2)a, (mask8x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask8x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x2)a, (mask16x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask8x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x2)a, (mask32x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask8x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x2)a, (mask64x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(bool2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x2)a, (mask8x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(Unity.Mathematics.bool2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x2)a, (mask8x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x2)a, (mask16x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x2)a, (mask32x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x2)a, (mask64x2)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(mask8x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x2)a, (mask8x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(mask8x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x2)a, (mask8x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask8x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x2)a, (mask16x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask8x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x2)a, (mask32x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask8x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x2)a, (mask64x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(bool2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x2)a, (mask8x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(Unity.Mathematics.bool2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x2)a, (mask8x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x2)a, (mask16x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x2)a, (mask32x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x2)a, (mask64x2)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(mask8x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x2)a, (mask8x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(mask8x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x2)a, (mask8x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask8x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x2)a, (mask16x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask8x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x2)a, (mask32x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask8x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x2)a, (mask64x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(bool2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x2)a, (mask8x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(Unity.Mathematics.bool2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x2)a, (mask8x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x2)a, (mask16x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x2)a, (mask32x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x2 a, mask8x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x2)a, (mask64x2)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x3 a, bool3 b, ShuffleComponent x) => shuffle((mask8x3)a, (mask8x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x) => shuffle((mask8x3)a, (mask8x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x3 a, mask16x3 b, ShuffleComponent x) => shuffle((mask16x3)a, (mask16x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x3 a, mask32x3 b, ShuffleComponent x) => shuffle((mask32x3)a, (mask32x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x3 a, mask64x3 b, ShuffleComponent x) => shuffle((mask64x3)a, (mask64x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool3 a, mask8x3 b, ShuffleComponent x) => shuffle((mask8x3)a, (mask8x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool3 a, mask8x3 b, ShuffleComponent x) => shuffle((mask8x3)a, (mask8x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x3 a, mask8x3 b, ShuffleComponent x) => shuffle((mask16x3)a, (mask16x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x3 a, mask8x3 b, ShuffleComponent x) => shuffle((mask32x3)a, (mask32x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x3 a, mask8x3 b, ShuffleComponent x) => shuffle((mask64x3)a, (mask64x3)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(mask8x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x3)a, (mask8x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(mask8x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x3)a, (mask8x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask8x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x3)a, (mask16x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask8x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x3)a, (mask32x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask8x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x3)a, (mask64x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(bool3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x3)a, (mask8x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(Unity.Mathematics.bool3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x3)a, (mask8x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x3)a, (mask16x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x3)a, (mask32x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x3)a, (mask64x3)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(mask8x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x3)a, (mask8x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(mask8x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x3)a, (mask8x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask8x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x3)a, (mask16x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask8x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x3)a, (mask32x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask8x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x3)a, (mask64x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(bool3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x3)a, (mask8x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(Unity.Mathematics.bool3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x3)a, (mask8x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x3)a, (mask16x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x3)a, (mask32x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x3)a, (mask64x3)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(mask8x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x3)a, (mask8x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(mask8x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x3)a, (mask8x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask8x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x3)a, (mask16x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask8x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x3)a, (mask32x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask8x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x3)a, (mask64x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(bool3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x3)a, (mask8x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(Unity.Mathematics.bool3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x3)a, (mask8x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x3)a, (mask16x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x3)a, (mask32x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x3 a, mask8x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x3)a, (mask64x3)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x4 a, bool4 b, ShuffleComponent x) => shuffle((mask8x4)a, (mask8x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x) => shuffle((mask8x4)a, (mask8x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x4 a, mask16x4 b, ShuffleComponent x) => shuffle((mask16x4)a, (mask16x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x4 a, mask32x4 b, ShuffleComponent x) => shuffle((mask32x4)a, (mask32x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask8x4 a, mask64x4 b, ShuffleComponent x) => shuffle((mask64x4)a, (mask64x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool4 a, mask8x4 b, ShuffleComponent x) => shuffle((mask8x4)a, (mask8x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool4 a, mask8x4 b, ShuffleComponent x) => shuffle((mask8x4)a, (mask8x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x4 a, mask8x4 b, ShuffleComponent x) => shuffle((mask16x4)a, (mask16x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x4 a, mask8x4 b, ShuffleComponent x) => shuffle((mask32x4)a, (mask32x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x4 a, mask8x4 b, ShuffleComponent x) => shuffle((mask64x4)a, (mask64x4)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(mask8x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x4)a, (mask8x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(mask8x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x4)a, (mask8x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask8x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x4)a, (mask16x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask8x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x4)a, (mask32x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask8x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x4)a, (mask64x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(bool4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x4)a, (mask8x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 shuffle(Unity.Mathematics.bool4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask8x4)a, (mask8x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x4)a, (mask16x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x4)a, (mask32x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x4)a, (mask64x4)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(mask8x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x4)a, (mask8x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(mask8x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x4)a, (mask8x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask8x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x4)a, (mask16x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask8x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x4)a, (mask32x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask8x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x4)a, (mask64x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(bool4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x4)a, (mask8x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 shuffle(Unity.Mathematics.bool4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask8x4)a, (mask8x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x4)a, (mask16x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x4)a, (mask32x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x4)a, (mask64x4)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(mask8x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x4)a, (mask8x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(mask8x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x4)a, (mask8x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask8x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x4)a, (mask16x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask8x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x4)a, (mask32x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask8x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x4)a, (mask64x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(bool4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x4)a, (mask8x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 shuffle(Unity.Mathematics.bool4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask8x4)a, (mask8x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x4)a, (mask16x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x4)a, (mask32x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x4 a, mask8x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x4)a, (mask64x4)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x2 a, bool2 b, ShuffleComponent x) => shuffle((mask16x2)a, (mask16x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x) => shuffle((mask16x2)a, (mask16x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x2 a, mask32x2 b, ShuffleComponent x) => shuffle((mask32x2)a, (mask32x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x2 a, mask64x2 b, ShuffleComponent x) => shuffle((mask64x2)a, (mask64x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool2 a, mask16x2 b, ShuffleComponent x) => shuffle((mask16x2)a, (mask16x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool2 a, mask16x2 b, ShuffleComponent x) => shuffle((mask16x2)a, (mask16x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x2 a, mask16x2 b, ShuffleComponent x) => shuffle((mask32x2)a, (mask32x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x2 a, mask16x2 b, ShuffleComponent x) => shuffle((mask64x2)a, (mask64x2)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x2)a, (mask16x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x2)a, (mask16x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask16x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x2)a, (mask32x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask16x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x2)a, (mask64x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(bool2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x2)a, (mask16x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(Unity.Mathematics.bool2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x2)a, (mask16x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x2)a, (mask32x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x2)a, (mask64x2)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x2)a, (mask16x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x2)a, (mask16x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask16x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x2)a, (mask32x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask16x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x2)a, (mask64x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(bool2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x2)a, (mask16x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(Unity.Mathematics.bool2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x2)a, (mask16x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x2)a, (mask32x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x2)a, (mask64x2)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x2)a, (mask16x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x2)a, (mask16x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask16x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x2)a, (mask32x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask16x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x2)a, (mask64x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(bool2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x2)a, (mask16x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(Unity.Mathematics.bool2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x2)a, (mask16x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x2)a, (mask32x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x2 a, mask16x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x2)a, (mask64x2)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x3 a, bool3 b, ShuffleComponent x) => shuffle((mask16x3)a, (mask16x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x) => shuffle((mask16x3)a, (mask16x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x3 a, mask32x3 b, ShuffleComponent x) => shuffle((mask32x3)a, (mask32x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x3 a, mask64x3 b, ShuffleComponent x) => shuffle((mask64x3)a, (mask64x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool3 a, mask16x3 b, ShuffleComponent x) => shuffle((mask16x3)a, (mask16x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool3 a, mask16x3 b, ShuffleComponent x) => shuffle((mask16x3)a, (mask16x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x3 a, mask16x3 b, ShuffleComponent x) => shuffle((mask32x3)a, (mask32x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x3 a, mask16x3 b, ShuffleComponent x) => shuffle((mask64x3)a, (mask64x3)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x3)a, (mask16x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x3)a, (mask16x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask16x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x3)a, (mask32x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask16x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x3)a, (mask64x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(bool3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x3)a, (mask16x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(Unity.Mathematics.bool3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x3)a, (mask16x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x3)a, (mask32x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x3)a, (mask64x3)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x3)a, (mask16x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x3)a, (mask16x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask16x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x3)a, (mask32x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask16x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x3)a, (mask64x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(bool3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x3)a, (mask16x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(Unity.Mathematics.bool3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x3)a, (mask16x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x3)a, (mask32x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x3)a, (mask64x3)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x3)a, (mask16x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x3)a, (mask16x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask16x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x3)a, (mask32x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask16x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x3)a, (mask64x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(bool3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x3)a, (mask16x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(Unity.Mathematics.bool3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x3)a, (mask16x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x3)a, (mask32x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x3 a, mask16x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x3)a, (mask64x3)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x4 a, bool4 b, ShuffleComponent x) => shuffle((mask16x4)a, (mask16x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x) => shuffle((mask16x4)a, (mask16x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x4 a, mask32x4 b, ShuffleComponent x) => shuffle((mask32x4)a, (mask32x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask16x4 a, mask64x4 b, ShuffleComponent x) => shuffle((mask64x4)a, (mask64x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool4 a, mask16x4 b, ShuffleComponent x) => shuffle((mask16x4)a, (mask16x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool4 a, mask16x4 b, ShuffleComponent x) => shuffle((mask16x4)a, (mask16x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x4 a, mask16x4 b, ShuffleComponent x) => shuffle((mask32x4)a, (mask32x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x4 a, mask16x4 b, ShuffleComponent x) => shuffle((mask64x4)a, (mask64x4)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x4)a, (mask16x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(mask16x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x4)a, (mask16x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask16x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x4)a, (mask32x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask16x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x4)a, (mask64x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(bool4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x4)a, (mask16x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 shuffle(Unity.Mathematics.bool4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask16x4)a, (mask16x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x4)a, (mask32x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x4)a, (mask64x4)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x4)a, (mask16x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(mask16x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x4)a, (mask16x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask16x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x4)a, (mask32x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask16x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x4)a, (mask64x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(bool4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x4)a, (mask16x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 shuffle(Unity.Mathematics.bool4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask16x4)a, (mask16x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x4)a, (mask32x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x4)a, (mask64x4)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x4)a, (mask16x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(mask16x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x4)a, (mask16x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask16x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x4)a, (mask32x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask16x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x4)a, (mask64x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(bool4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x4)a, (mask16x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 shuffle(Unity.Mathematics.bool4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask16x4)a, (mask16x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x4)a, (mask32x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x4 a, mask16x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x4)a, (mask64x4)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x2 a, bool2 b, ShuffleComponent x) => shuffle((mask32x2)a, (mask32x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x) => shuffle((mask32x2)a, (mask32x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x2 a, mask64x2 b, ShuffleComponent x) => shuffle((mask64x2)a, (mask64x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool2 a, mask32x2 b, ShuffleComponent x) => shuffle((mask32x2)a, (mask32x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool2 a, mask32x2 b, ShuffleComponent x) => shuffle((mask32x2)a, (mask32x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x2 a, mask32x2 b, ShuffleComponent x) => shuffle((mask64x2)a, (mask64x2)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x2)a, (mask32x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x2)a, (mask32x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask32x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x2)a, (mask64x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(bool2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x2)a, (mask32x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(Unity.Mathematics.bool2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x2)a, (mask32x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x2)a, (mask64x2)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x2)a, (mask32x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x2)a, (mask32x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask32x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x2)a, (mask64x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(bool2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x2)a, (mask32x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(Unity.Mathematics.bool2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x2)a, (mask32x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x2)a, (mask64x2)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x2)a, (mask32x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x2)a, (mask32x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask32x2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x2)a, (mask64x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(bool2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x2)a, (mask32x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(Unity.Mathematics.bool2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x2)a, (mask32x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x2 a, mask32x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x2)a, (mask64x2)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x3 a, bool3 b, ShuffleComponent x) => shuffle((mask32x3)a, (mask32x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x) => shuffle((mask32x3)a, (mask32x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x3 a, mask64x3 b, ShuffleComponent x) => shuffle((mask64x3)a, (mask64x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool3 a, mask32x3 b, ShuffleComponent x) => shuffle((mask32x3)a, (mask32x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool3 a, mask32x3 b, ShuffleComponent x) => shuffle((mask32x3)a, (mask32x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x3 a, mask32x3 b, ShuffleComponent x) => shuffle((mask64x3)a, (mask64x3)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x3)a, (mask32x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x3)a, (mask32x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask32x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x3)a, (mask64x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(bool3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x3)a, (mask32x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(Unity.Mathematics.bool3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x3)a, (mask32x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x3)a, (mask64x3)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x3)a, (mask32x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x3)a, (mask32x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask32x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x3)a, (mask64x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(bool3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x3)a, (mask32x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(Unity.Mathematics.bool3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x3)a, (mask32x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x3)a, (mask64x3)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x3)a, (mask32x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x3)a, (mask32x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask32x3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x3)a, (mask64x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(bool3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x3)a, (mask32x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(Unity.Mathematics.bool3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x3)a, (mask32x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x3 a, mask32x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x3)a, (mask64x3)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x4 a, bool4 b, ShuffleComponent x) => shuffle((mask32x4)a, (mask32x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x) => shuffle((mask32x4)a, (mask32x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask32x4 a, mask64x4 b, ShuffleComponent x) => shuffle((mask64x4)a, (mask64x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool4 a, mask32x4 b, ShuffleComponent x) => shuffle((mask32x4)a, (mask32x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool4 a, mask32x4 b, ShuffleComponent x) => shuffle((mask32x4)a, (mask32x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x4 a, mask32x4 b, ShuffleComponent x) => shuffle((mask64x4)a, (mask64x4)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x4)a, (mask32x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(mask32x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x4)a, (mask32x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask32x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x4)a, (mask64x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(bool4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x4)a, (mask32x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 shuffle(Unity.Mathematics.bool4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask32x4)a, (mask32x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x4)a, (mask64x4)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x4)a, (mask32x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(mask32x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x4)a, (mask32x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask32x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x4)a, (mask64x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(bool4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x4)a, (mask32x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 shuffle(Unity.Mathematics.bool4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask32x4)a, (mask32x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x4)a, (mask64x4)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x4)a, (mask32x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(mask32x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x4)a, (mask32x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask32x4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x4)a, (mask64x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(bool4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x4)a, (mask32x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 shuffle(Unity.Mathematics.bool4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask32x4)a, (mask32x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x4 a, mask32x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x4)a, (mask64x4)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x2 a, bool2 b, ShuffleComponent x) => shuffle((mask64x2)a, (mask64x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x) => shuffle((mask64x2)a, (mask64x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool2 a, mask64x2 b, ShuffleComponent x) => shuffle((mask64x2)a, (mask64x2)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool2 a, mask64x2 b, ShuffleComponent x) => shuffle((mask64x2)a, (mask64x2)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x2)a, (mask64x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x2)a, (mask64x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(bool2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x2)a, (mask64x2)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(Unity.Mathematics.bool2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x2)a, (mask64x2)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x2)a, (mask64x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x2)a, (mask64x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(bool2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x2)a, (mask64x2)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(Unity.Mathematics.bool2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x2)a, (mask64x2)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x2 a, bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x2)a, (mask64x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x2 a, Unity.Mathematics.bool2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x2)a, (mask64x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(bool2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x2)a, (mask64x2)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(Unity.Mathematics.bool2 a, mask64x2 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x2)a, (mask64x2)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x3 a, bool3 b, ShuffleComponent x) => shuffle((mask64x3)a, (mask64x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x) => shuffle((mask64x3)a, (mask64x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool3 a, mask64x3 b, ShuffleComponent x) => shuffle((mask64x3)a, (mask64x3)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool3 a, mask64x3 b, ShuffleComponent x) => shuffle((mask64x3)a, (mask64x3)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x3)a, (mask64x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x3)a, (mask64x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(bool3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x3)a, (mask64x3)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(Unity.Mathematics.bool3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x3)a, (mask64x3)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x3)a, (mask64x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x3)a, (mask64x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(bool3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x3)a, (mask64x3)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(Unity.Mathematics.bool3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x3)a, (mask64x3)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x3 a, bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x3)a, (mask64x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x3 a, Unity.Mathematics.bool3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x3)a, (mask64x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(bool3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x3)a, (mask64x3)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(Unity.Mathematics.bool3 a, mask64x3 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x3)a, (mask64x3)b, x, y, z, w);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x4 a, bool4 b, ShuffleComponent x) => shuffle((mask64x4)a, (mask64x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(mask64x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x) => shuffle((mask64x4)a, (mask64x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(bool4 a, mask64x4 b, ShuffleComponent x) => shuffle((mask64x4)a, (mask64x4)b, x);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="bool"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool shuffle(Unity.Mathematics.bool4 a, mask64x4 b, ShuffleComponent x) => shuffle((mask64x4)a, (mask64x4)b, x);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x4)a, (mask64x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(mask64x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x4)a, (mask64x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(bool4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x4)a, (mask64x4)b, x, y);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 shuffle(Unity.Mathematics.bool4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y) => shuffle((mask64x4)a, (mask64x4)b, x, y);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x4)a, (mask64x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(mask64x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x4)a, (mask64x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(bool4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x4)a, (mask64x4)b, x, y, z);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 shuffle(Unity.Mathematics.bool4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z) => shuffle((mask64x4)a, (mask64x4)b, x, y, z);


        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x4 a, bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x4)a, (mask64x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(mask64x4 a, Unity.Mathematics.bool4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x4)a, (mask64x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(bool4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x4)a, (mask64x4)b, x, y, z, w);

        /// <summary>       Returns the result of specified shuffling of the components from two <see cref="MaxMath.bool2"/>s into a <see cref="MaxMath.bool4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 shuffle(Unity.Mathematics.bool4 a, mask64x4 b, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w) => shuffle((mask64x4)a, (mask64x4)b, x, y, z, w);
    }
}