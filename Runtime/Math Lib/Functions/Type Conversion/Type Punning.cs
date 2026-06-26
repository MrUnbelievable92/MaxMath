using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the bit pattern of an <see cref="byte"/> as a <see cref="MaxMath.quarter"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter asquarter(sbyte x)
        {
            return *(quarter*)&x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte2"/> as a <see cref="MaxMath.quarter2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 asquarter(sbyte2 x)
        {
            return *(quarter2*)&x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte3"/> as a <see cref="MaxMath.quarter3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 asquarter(sbyte3 x)
        {
            return *(quarter3*)&x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte4"/> as a <see cref="MaxMath.quarter4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 asquarter(sbyte4 x)
        {
            return *(quarter4*)&x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte8"/> as a <see cref="MaxMath.quarter8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 asquarter(sbyte8 x)
        {
            return *(quarter8*)&x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte16"/> as a <see cref="MaxMath.quarter16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 asquarter(sbyte16 x)
        {
            return *(quarter16*)&x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte32"/> as a <see cref="MaxMath.quarter32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 asquarter(sbyte32 x)
        {
            return *(quarter32*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="byte"/> as a <see cref="MaxMath.quarter"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter asquarter(byte x)
        {
            return *(quarter*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte2"/> as a <see cref="MaxMath.quarter2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 asquarter(byte2 x)
        {
            return *(quarter2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte3"/> as a <see cref="MaxMath.quarter3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 asquarter(byte3 x)
        {
            return *(quarter3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte4"/> as a <see cref="MaxMath.quarter4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 asquarter(byte4 x)
        {
            return *(quarter4*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte8"/> as a <see cref="MaxMath.quarter8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 asquarter(byte8 x)
        {
            return *(quarter8*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte16"/> as a <see cref="MaxMath.quarter16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 asquarter(byte16 x)
        {
            return *(quarter16*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte32"/> as a <see cref="MaxMath.quarter32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 asquarter(byte32 x)
        {
            return *(quarter32*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="byte"/> as an <see cref="sbyte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte assbyte(byte x)
        {
            return (sbyte)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte2"/> as an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 assbyte(byte2 x)
        {
            return (sbyte2)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte3"/> as an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 assbyte(byte3 x)
        {
            return (sbyte3)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte4"/> as an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 assbyte(byte4 x)
        {
            return (sbyte4)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte8"/> as an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 assbyte(byte8 x)
        {
            return (sbyte8)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte16"/> as an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 assbyte(byte16 x)
        {
            return (sbyte16)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.byte32"/> as an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 assbyte(byte32 x)
        {
            return (sbyte32)x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter"/> as an <see cref="sbyte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte assbyte(quarter x)
        {
            return (sbyte)x.value;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter2"/> as an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 assbyte(quarter2 x)
        {
            return *(sbyte2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter3"/> as an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 assbyte(quarter3 x)
        {
            return *(sbyte3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter4"/> as an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 assbyte(quarter4 x)
        {
            return *(sbyte4*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter8"/> as an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 assbyte(quarter8 x)
        {
            return *(sbyte8*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter16"/> as an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 assbyte(quarter16 x)
        {
            return *(sbyte16*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter32"/> as an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 assbyte(quarter32 x)
        {
            return *(sbyte32*)&x;
        }


        /// <summary>       Returns the bit pattern of an <see cref="sbyte"/> as a <see cref="byte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte asbyte(sbyte x)
        {
            return (byte)x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte2"/> as a <see cref="MaxMath.byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 asbyte(sbyte2 x)
        {
            return (byte2)x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte3"/> as a <see cref="MaxMath.byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 asbyte(sbyte3 x)
        {
            return (byte3)x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte4"/> as a <see cref="MaxMath.byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 asbyte(sbyte4 x)
        {
            return (byte4)x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte8"/> as a <see cref="MaxMath.byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 asbyte(sbyte8 x)
        {
            return (byte8)x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte16"/> as a <see cref="MaxMath.byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 asbyte(sbyte16 x)
        {
            return (byte16)x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.sbyte32"/> as a <see cref="MaxMath.byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 asbyte(sbyte32 x)
        {
            return (byte32)x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter"/> as a <see cref="byte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte asbyte(quarter x)
        {
            return x.value;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter2"/> as a <see cref="MaxMath.byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 asbyte(quarter2 x)
        {
            return *(byte2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter3"/> as a <see cref="MaxMath.byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 asbyte(quarter3 x)
        {
            return *(byte3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter4"/> as a <see cref="MaxMath.byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 asbyte(quarter4 x)
        {
            return *(byte4*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter8"/> as a <see cref="MaxMath.byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 asbyte(quarter8 x)
        {
            return *(byte8*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter16"/> as a <see cref="MaxMath.byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 asbyte(quarter16 x)
        {
            return *(byte16*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.quarter32"/> as a <see cref="MaxMath.byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 asbyte(quarter32 x)
        {
            return *(byte32*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="short"/> as a <see cref="MaxMath.half"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half ashalf(short x)
        {
            return *(half*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.short2"/> as a <see cref="MaxMath.half2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 ashalf(short2 x)
        {
            return *(half2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.short3"/> as a <see cref="MaxMath.half3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 ashalf(short3 x)
        {
            return *(half3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.short4"/> as a <see cref="MaxMath.half4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 ashalf(short4 x)
        {
            return *(half4*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.short8"/> as a <see cref="MaxMath.half8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 ashalf(short8 x)
        {
            return *(half8*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.short16"/> as a <see cref="MaxMath.half16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 ashalf(short16 x)
        {
            return *(half16*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="ushort"/> as a <see cref="MaxMath.half"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half ashalf(ushort x)
        {
            return *(half*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ushort2"/> as a <see cref="MaxMath.half2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 ashalf(ushort2 x)
        {
            return *(half2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ushort3"/> as a <see cref="MaxMath.half3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 ashalf(ushort3 x)
        {
            return *(half3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ushort4"/> as a <see cref="MaxMath.half4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 ashalf(ushort4 x)
        {
            return *(half4*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ushort8"/> as a <see cref="MaxMath.half8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 ashalf(ushort8 x)
        {
            return *(half8*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ushort16"/> as a <see cref="MaxMath.half16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 ashalf(ushort16 x)
        {
            return *(half16*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="ushort"/> as a <see cref="short"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short asshort(ushort x)
        {
            return (short)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ushort2"/> as a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 asshort(ushort2 x)
        {
            return (short2)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ushort3"/> as a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 asshort(ushort3 x)
        {
            return (short3)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ushort4"/> as a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 asshort(ushort4 x)
        {
            return (short4)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ushort8"/> as a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 asshort(ushort8 x)
        {
            return (short8)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ushort16"/> as a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 asshort(ushort16 x)
        {
            return (short16)x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half"/> as a <see cref="short"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short asshort(half x)
        {
            return (short)x.value;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half2"/> as a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 asshort(half2 x)
        {
            return *(short2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half3"/> as a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 asshort(half3 x)
        {
            return *(short3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half4"/> as a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 asshort(half4 x)
        {
            return *(short4*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half8"/> as a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 asshort(half8 x)
        {
            return *(short8*)&x;
        }
        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half16"/> as a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 asshort(half16 x)
        {
            return *(short16*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="short"/> as a <see cref="ushort"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort asushort(short x)
        {
            return (ushort)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.short2"/> as a <see cref="MaxMath.ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 asushort(short2 x)
        {
            return (ushort2)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.short3"/> as a <see cref="MaxMath.ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 asushort(short3 x)
        {
            return (ushort3)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.short4"/> as a <see cref="MaxMath.ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 asushort(short4 x)
        {
            return (ushort4)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.short8"/> as a <see cref="MaxMath.ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 asushort(short8 x)
        {
            return (ushort8)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.short16"/> as a <see cref="MaxMath.ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 asushort(short16 x)
        {
            return (ushort16)x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half"/> as a <see cref="ushort"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort asushort(half x)
        {
            return x.value;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half2"/> as a <see cref="MaxMath.ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 asushort(half2 x)
        {
            return *(ushort2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half3"/> as a <see cref="MaxMath.ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 asushort(half3 x)
        {
            return *(ushort3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half4"/> as a <see cref="MaxMath.ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 asushort(half4 x)
        {
            return *(ushort4*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half8"/> as a <see cref="MaxMath.ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 asushort(half8 x)
        {
            return *(ushort8*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.half16"/> as a <see cref="MaxMath.ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 asushort(half16 x)
        {
            return *(ushort16*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="uint"/> as an <see cref="int"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int asint(uint x)
        {
            return (int)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.uint2"/> as an <see cref="MaxMath.int2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 asint(uint2 x)
        {
            return (int2)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.uint3"/> as an <see cref="MaxMath.int3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 asint(uint3 x)
        {
            return (int3)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.uint4"/> as an <see cref="MaxMath.int4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 asint(uint4 x)
        {
            return (int4)x;
        }
        
        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.uint8"/> as an <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 asint(uint8 x)
        {
            return (int8)x;
        }

        
        /// <summary>       Returns the bit pattern of a <see cref="float"/> as an <see cref="int"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int asint(float x)
        {
            return *(int*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.float2"/> as an <see cref="MaxMath.int2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 asint(float2 x)
        {
            return *(int2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.float3"/> as an <see cref="MaxMath.int3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 asint(float3 x)
        {
            return *(int3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.float4"/> as an <see cref="MaxMath.int4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 asint(float4 x)
        {
            return *(int4*)&x;
        }
        
        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.float8"/> as an <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 asint(float8 x)
        {
            return *(int8*)&x;
        }


        /// <summary>       Returns the bit pattern of an <see cref="int"/> as a <see cref="uint"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint asuint(int x)
        {
            return (uint)x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.int2"/> as a <see cref="MaxMath.uint2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 asuint(int2 x)
        {
            return (uint2)x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.int3"/> as a <see cref="MaxMath.uint3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 asuint(int3 x)
        {
            return (uint3)x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.int4"/> as a <see cref="MaxMath.uint4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 asuint(int4 x)
        {
            return (uint4)x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.int8"/> as a <see cref="MaxMath.uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 asuint(int8 x)
        {
            return (uint8)x;
        }

        
        /// <summary>       Returns the bit pattern of a <see cref="float"/> as a <see cref="uint"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint asuint(float x)
        {
            return *(uint*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.float2"/> as a <see cref="MaxMath.uint2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 asuint(float2 x)
        {
            return *(uint2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.float3"/> as a <see cref="MaxMath.uint3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 asuint(float3 x)
        {
            return *(uint3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.float4"/> as a <see cref="MaxMath.uint4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 asuint(float4 x)
        {
            return *(uint4*)&x;
        }
        
        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.float8"/> as a <see cref="MaxMath.uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 asuint(float8 x)
        {
            return *(uint8*)&x;
        }


        /// <summary>       Returns the bit pattern of an <see cref="int"/> as a <see cref="float"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float asfloat(int x)
        {
            return *(float*)&x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.int2"/> as a <see cref="MaxMath.float2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 asfloat(int2 x)
        {
            return *(float2*)&x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.int3"/> as a <see cref="MaxMath.float3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 asfloat(int3 x)
        {
            return *(float3*)&x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.int4"/> as a <see cref="MaxMath.float4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 asfloat(int4 x)
        {
            return *(float4*)&x;
        }

        /// <summary>       Returns the bit pattern of an <see cref="MaxMath.int8"/> as a <see cref="MaxMath.float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 asfloat(int8 x)
        {
            return *(float8*)&x;
        }

        
        /// <summary>       Returns the bit pattern of a <see cref="uint"/> as a <see cref="float"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float asfloat(uint x)
        {
            return *(float*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.uint2"/> as a <see cref="MaxMath.float2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 asfloat(uint2 x)
        {
            return *(float2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.uint3"/> as a <see cref="MaxMath.float3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 asfloat(uint3 x)
        {
            return *(float3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.uint4"/> as a <see cref="MaxMath.float4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 asfloat(uint4 x)
        {
            return *(float4*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.uint8"/> as a <see cref="MaxMath.float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 asfloat(uint8 x)
        {
            return *(float8*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="ulong"/> as a <see cref="long"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long aslong(ulong x)
        {
            return (long)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ulong2"/> as a <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 aslong(ulong2 x)
        {
            return (long2)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ulong3"/> as a <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 aslong(ulong3 x)
        {
            return (long3)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ulong4"/> as a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 aslong(ulong4 x)
        {
            return (long4)x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="double"/> as a <see cref="long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long aslong(double x)
        {
            return *(long*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.double2"/> as a <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 aslong(double2 x)
        {
            return *(long2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.double3"/> as a <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 aslong(double3 x)
        {
            return *(long3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.double4"/> as a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 aslong(double4 x)
        {
            return *(long4*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="long"/> as a <see cref="ulong"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong asulong(long x)
        {
            return (ulong)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.long2"/> as a <see cref="MaxMath.ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 asulong(long2 x)
        {
            return (ulong2)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.long3"/> as a <see cref="MaxMath.ulong3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 asulong(long3 x)
        {
            return (ulong3)x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.long4"/> as a <see cref="MaxMath.ulong4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 asulong(long4 x)
        {
            return (ulong4)x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="double"/> as a <see cref="ulong"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong asulong(double x)
        {
            return *(ulong*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.double2"/> as a <see cref="MaxMath.ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 asulong(double2 x)
        {
            return *(ulong2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.double3"/> as a <see cref="MaxMath.ulong3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 asulong(double3 x)
        {
            return *(ulong3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.double4"/> as a <see cref="MaxMath.ulong4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 asulong(double4 x)
        {
            return *(ulong4*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="long"/> as a <see cref="double"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double asdouble(long x)
        {
            return *(double*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.long2"/> as a <see cref="MaxMath.double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 asdouble(long2 x)
        {
            return *(double2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.long3"/> as a <see cref="MaxMath.double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 asdouble(long3 x)
        {
            return *(double3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.long4"/> as a <see cref="MaxMath.double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 asdouble(long4 x)
        {
            return *(double4*)&x;
        }


        /// <summary>       Returns the bit pattern of a <see cref="ulong"/> as a <see cref="double"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double asdouble(ulong x)
        {
            return *(double*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ulong2"/> as a <see cref="MaxMath.double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 asdouble(ulong2 x)
        {
            return *(double2*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ulong3"/> as a <see cref="MaxMath.double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 asdouble(ulong3 x)
        {
            return *(double3*)&x;
        }

        /// <summary>       Returns the bit pattern of a <see cref="MaxMath.ulong4"/> as a <see cref="MaxMath.double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 asdouble(ulong4 x)
        {
            return *(double4*)&x;
        }
    }
}