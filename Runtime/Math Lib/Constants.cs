namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   The mathematical constant e also known as Euler's number. Approximately 2.72. This is a f64/double precision constant.   </summary>
        public const double E_DBL = 2.71828182845904523536;

        /// <summary>   The base 2 logarithm of e. Approximately 1.44. This is a f64/double precision constant.   </summary>
        public const double LOG2E_DBL = 1.44269504088896340736;

        /// <summary>   The base 10 logarithm of e. Approximately 0.43. This is a f64/double precision constant.   </summary>
        public const double LOG10E_DBL = 0.434294481903251827651;

        /// <summary>   The natural logarithm of 2. Approximately 0.69. This is a f64/double precision constant.   </summary>
        public const double LN2_DBL = 0.693147180559945309417;

        /// <summary>   The natural logarithm of 10. Approximately 2.30. This is a f64/double precision constant.   </summary>
        public const double LN10_DBL = 2.30258509299404568402;

        /// <summary>   The mathematical constant pi. Approximately 3.14. This is a f64/double precision constant.   </summary>
        public const double PI_DBL = 3.14159265358979323846;

        /// <summary>   The mathematical constant (2 * pi). Approximately 6.28. This is a f64/double precision constant. Also known as <see cref="TAU_DBL"/>.   </summary>
        public const double PI2_DBL = PI_DBL * 2.0;

        /// <summary>   The mathematical constant (pi / 2). Approximately 1.57. This is a f64/double precision constant.   </summary>
        public const double PIHALF_DBL = PI_DBL * 0.5;

        /// <summary>   The mathematical constant tau. Approximately 6.28. This is a f64/double precision constant. Also known as <see cref="PI2_DBL"/>.   </summary>
        public const double TAU_DBL = PI2_DBL;

        /// <summary>   The conversion constant used to convert radians to degrees. Multiply the radian value by this constant to get degrees. Multiplying by this constant is equivalent to using <see cref="math.degrees(double)"/>.   </summary>
        public const double TODEGREES_DBL = 57.29577951308232;

        /// <summary>   The conversion constant used to convert degrees to radians. Multiply the degree value by this constant to get radians. Multiplying by this constant is equivalent to using <see cref="math.radians(double)"/>.   </summary>
        public const double TORADIANS_DBL = 0.017453292519943296;

        /// <summary>   The square root 2. Approximately 1.41. This is a f64/double precision constant.   </summary>
        public const double SQRT2_DBL = 1.41421356237309504880;

        /// <summary>   The difference between 1.0 and the next representable f64/double precision number. Beware: This value is different from System.Double.Epsilon, which is the smallest, positive, denormalized f64/double.   </summary>
        public const double EPSILON_DBL = 2.22044604925031308085e-16;

        /// <summary>   Double precision constant for positive infinity.   </summary>
        public const double INFINITY_DBL = double.PositiveInfinity;

        /// <summary>   
        /// Double precision constant for Not a Number.
        ///
        /// NAN_DBL is considered unordered, which means all comparisons involving it are false except for not equal (operator !=).
        /// As a consequence, NAN_DBL == NAN_DBL is false but NAN_DBL != NAN_DBL is <see langword="true"/>.
        ///
        /// Additionally, there are multiple bit representations for Not a Number, so if you must test if your value
        /// is NAN_DBL, use <see cref="math.isnan()"/>.
        /// </summary>
        public const double NAN_DBL = double.NaN;

        /// <summary>   The smallest positive normal number representable in a float.   </summary>
        public const float FLT_MIN_NORMAL = 1.175494351e-38F;

        /// <summary>   The smallest positive normal number representable in a double. This is a f64/double precision constant.   </summary>
        public const double DBL_MIN_NORMAL = 2.2250738585072014e-308;

        /// <summary>   The mathematical constant e also known as Euler's number. Approximately 2.72.   </summary>
        public const float E = (float)E_DBL;

        /// <summary>   The base 2 logarithm of e. Approximately 1.44.   </summary>
        public const float LOG2E = (float)LOG2E_DBL;

        /// <summary>   The base 10 logarithm of e. Approximately 0.43.   </summary>
        public const float LOG10E = (float)LOG10E_DBL;

        /// <summary>   The natural logarithm of 2. Approximately 0.69.   </summary>
        public const float LN2 = (float)LN2_DBL;

        /// <summary>   The natural logarithm of 10. Approximately 2.30.   </summary>
        public const float LN10 = (float)LN10_DBL;

        /// <summary>   The mathematical constant pi. Approximately 3.14.   </summary>
        public const float PI = (float)PI_DBL;

        /// <summary>   The mathematical constant (2 * pi). Approximately 6.28. Also known as <see cref="TAU"/>.   </summary>
        public const float PI2 = (float)PI2_DBL;

        /// <summary>   The mathematical constant (pi / 2). Approximately 1.57.   </summary>
        public const float PIHALF = (float)PIHALF_DBL;

        /// <summary>   The mathematical constant tau. Approximately 6.28. Also known as <see cref="PI2"/>.   </summary>
        public const float TAU = (float)PI2_DBL;

        /// <summary>   The conversion constant used to convert radians to degrees. Multiply the radian value by this constant to get degrees. Multiplying by this constant is equivalent to using <see cref="math.degrees(float)"/>.</summary>
        public const float TODEGREES = (float)TODEGREES_DBL;

        /// <summary>   he conversion constant used to convert degrees to radians. Multiply the degree value by this constant to get radians. Multiplying by this constant is equivalent to using <see cref="math.radians(float)"/>.</summary>
        public const float TORADIANS = (float)TORADIANS_DBL;

        /// <summary>   The square root 2. Approximately 1.41.   </summary>
        public const float SQRT2 = (float)SQRT2_DBL;

        /// <summary>   
        /// The difference between 1.0f and the next representable f32/single precision number.
        ///
        /// Beware:
        /// This value is different from System.Single.Epsilon, which is the smallest, positive, denormalized f32/single.
        /// </summary>
        public const float EPSILON = 1.1920928955078125e-7f;

        /// <summary>   
        /// Single precision constant for positive infinity.
        /// </summary>
        public const float INFINITY = float.PositiveInfinity;

        /// <summary>   
        /// Single precision constant for Not a Number.
        ///
        /// NAN is considered unordered, which means all comparisons involving it are false except for not equal (operator !=).
        /// As a consequence, NAN == NAN is false but NAN != NAN is <see langword="true"/>.
        ///
        /// Additionally, there are multiple bit representations for Not a Number, so if you must test if your value
        /// is NAN, use <see cref="math.isnan()"/>.
        /// </summary>
        public const float NAN = float.NaN;


        /// <summary>   
        /// Quadruple precision constant for Not a Number.
        ///
        /// NAN_QUAD is considered unordered, which means all comparisons involving it are false except for not equal (operator !=).
        /// As a consequence, NAN_QUAD == NAN_QUAD is false but NAN_QUAD != NAN_QUAD is <see langword="true"/>.
        ///
        /// Additionally, there are multiple bit representations for Not a Number, so if you must test if your value
        /// is NAN_QUAD, use isnan().
        ///    </summary>
        public static quadruple NAN_QUAD => MaxMath.quadruple.NaN;

        /// <summary>          Quadruple precision constant for positive infinity.         </summary>
        public static quadruple INFINITY_QUAD => MaxMath.quadruple.PositiveInfinity;

        /// <summary>   
        /// The difference between 1.0 and the next representable f128/quadruple precision number.
        ///
        /// Beware:
        /// This value is different from quadruple.Epsilon, which is the smallest, positive, denormalized f128/quadruple.
        ///    </summary>
        public static quadruple EPSILON_QUAD => new quadruple(0ul, 0x3F8F_0000_0000_0000);

        /// <summary>          The smallest positive normal number representable in a quadruple. This is a f128/quadruple precision constant.         </summary>
        public static quadruple QUAD_MIN_NORMAL => new quadruple(0ul, 1ul << MaxMath.quadruple.MANTISSA_BITS_HI64);

        /// <summary>          The mathematical constant e also known as Euler's number. Approximately 2.72. This is a f128/quadruple precision constant.         </summary>
        public static quadruple E_QUAD => new quadruple(0x9535_5FB8_AC40_4E7A, 0x4000_5BF0_A8B1_4576);

        /// <summary>          The natural logarithm of 10. Approximately 2.30. This is a f128/quadruple precision constant.         </summary>
        public static quadruple LN10_QUAD => new quadruple(0x582D_D4AD_AC57_05A6, 0x4000_26BB_1BBB_5551);

        /// <summary>          The natural logarithm of 2. Approximately 0.69. This is a f128/quadruple precision constant.         </summary>
        public static quadruple LN2_QUAD => new quadruple(0xF357_93C7_6730_07E6, 0x3FFE_62E4_2FEF_A39E);

        /// <summary>          The base 10 logarithm of e. Approximately 0.43. This is a f128/quadruple precision constant.         </summary>
        public static quadruple LOG10E_QUAD => new quadruple(0xE32A_6AB7_555F_5A68, 0x3FFD_BCB7_B152_6E50);

        /// <summary>          The base 2 logarithm of e. Approximately 1.44. This is a f128/quadruple precision constant.         </summary>
        public static quadruple LOG2E_QUAD => new quadruple(0xE177_7D0F_FDA0_D23A, 0x3FFF_7154_7652_B82F);

        /// <summary>          The mathematical constant pi. Approximately 3.14. This is a f128/quadruple precision constant.         </summary>
        public static quadruple PI_QUAD => new quadruple(0x8469_898C_C517_01B8, 0x4000_921F_B544_42D1);

        /// <summary>          The square root 2. Approximately 1.41. Approximately 6.28. This is a f128/quadruple precision constant.         </summary>
        public static quadruple SQRT2_QUAD => new quadruple(0xC908_B2FB_1366_EA95, 0x3FFF_6A09_E667_F3BC);

        /// <summary>          The mathematical constant tau. Approximately 6.28. Also known as <see cref="PI2_QUAD"/>. This is a f128/quadruple precision constant.         </summary>
        public static quadruple TAU_QUAD => new quadruple(0x8469_898C_C517_01B8, 0x4001_921F_B544_42D1);

        /// <summary>          The mathematical constant (2 * pi). Approximately 6.28. Also known as <see cref="TAU_QUAD"/>. This is a f128/quadruple precision constant.         </summary>
        public static quadruple PI2_QUAD => new quadruple(0x8469_898C_C517_01B8, 0x4001_921F_B544_42D1);

        /// <summary>          The mathematical constant (pi / 2). Approximately 1.57. This is a f128/quadruple precision constant.         </summary>
        public static quadruple PIHALF_QUAD => new quadruple(0x8469_898C_C517_01B8, 0x3FFF_921F_B544_42D1);

        /// <summary>          The mathematical constant phi also known as the golden ratio. Approximately 1.61. This is a f128/quadruple precision constant.         </summary>
        public static quadruple PHI_QUAD => new quadruple(0x7C15_F39C_C060_5CEE, 0x3FFF_9E37_79B9_7F4A);

        /// <summary>          The square root 3. Approximately 1.73. This is a f128/quadruple precision constant.       </summary>
        public static quadruple SQRT3_QUAD => new quadruple(0xA73B_2574_2D70_78B8, 0x3FFF_BB67_AE85_84CA);

        /// <summary>          The square root 5. Approximately 2.23. This is a f128/quadruple precision constant.       </summary>
        public static quadruple SQRT5_QUAD => new quadruple(0x7C15_F39C_C060_5CEE, 0x4000_1E37_79B9_7F4A);

        /// <summary>          The cube root of 2. Approximately 1.26. This is a f128/quadruple precision constant.         </summary>
        public static quadruple CBRT2_QUAD => new quadruple(0xAE22_3DDA_B715_BE25, 0x3FFF_428A_2F98_D728);

        /// <summary>          The cube root of 3. Approximately 1.44. This is a f128/quadruple precision constant.         </summary>
        public static quadruple CBRT3_QUAD => new quadruple(0x65CD_DE7F_16C5_6E32, 0x3FFF_7137_4491_23EF);

        /// <summary>          The cube root of 4. Approximately 1.58. This is a f128/quadruple precision constant.         </summary>
        public static quadruple CBRT4_QUAD => new quadruple(0xC82B_0599_9AB4_3DC5, 0x3FFF_965F_EA53_D6E3);

        /// <summary>          The inverse cube root of 2. Approximately 0.79. This is a f128/quadruple precision constant.         </summary>
        public static quadruple RCBRT2_QUAD => new quadruple(0xC82B_0599_9AB4_3DC4, 0x3FFE_965F_EA53_D6E3);

        /// <summary>          The inverse cube root of 4. Approximately 0.62. This is a f128/quadruple precision constant.         </summary>
        public static quadruple RCBRT4_QUAD => new quadruple(0xAE22_3DDA_B715_BE26, 0x3FFE_428A_2F98_D728);

        /// <summary>   
        /// The conversion constant used to convert radians to degrees. Multiply the radian value by this constant to get degrees.
        /// <remarks>   Multiplying by this constant is equivalent to using <see cref="math.degrees(quadruple)"/>.   </remarks>
        ///    </summary>
        public static quadruple TODEGREES_QUAD => new quadruple(0x7B86_152E_A6FE_81A4, 0x4004_CA5D_C1A6_3C1F);

        /// <summary>   
        /// The conversion constant used to convert degrees to radians. Multiply the degree value by this constant to get radians.
        /// <remarks>Multiplying by this constant is equivalent to using <see cref="math.radians(quadruple)"/>.</remarks>
        ///    </summary>
        public static quadruple TORADIANS_QUAD => new quadruple(0x915C_1D8B_ECDD_290A, 0x3FF9_1DF4_6A25_29D3);


        /// <summary>          The mathematical constant phi also known as the golden ratio. Approximately 1.61. This is a f64/double precision constant.         </summary>
        public const double PHI_DBL = 1.61803398874989484820d;

        /// <summary>          The square root 3. Approximately 1.73. This is a f64/double precision constant.       </summary>
        public const double SQRT3_DBL = 1.73205080756887729352d;

        /// <summary>          The square root 5. Approximately 2.23. This is a f64/double precision constant.       </summary>
        public const double SQRT5_DBL = 2.23606797749978969640d;

        /// <summary>          The cube root of 2. Approximately 1.26. This is a f64/double precision constant.         </summary>
        public const double CBRT2_DBL = 1.25992104989487316476d;

        /// <summary>          The cube root of 3. Approximately 1.44. This is a f64/double precision constant.         </summary>
        public const double CBRT3_DBL = 1.44224957030740838232d;

        /// <summary>          The cube root of 4. Approximately 1.58. This is a f64/double precision constant.         </summary>
        public const double CBRT4_DBL = 1.58740105196819947475d;

        /// <summary>          The inverse cube root of 2. Approximately 0.79. This is a f64/double precision constant.         </summary>
        public const double RCBRT2_DBL = 0.79370052598409973737d;

        /// <summary>          The inverse cube root of 4. Approximately 0.62. This is a f64/double precision constant.         </summary>
        public const double RCBRT4_DBL = 0.62996052494743658238d;

        /// <summary>          The mathematical constant phi also known as the golden ratio. Approximately 1.61.         </summary>
        public const float PHI = 1.61803398f;

        /// <summary>          The square root of 3. Approximately 1.73.         </summary>
        public const float SQRT3 = 1.73205080f;

        /// <summary>          The square root of 5. Approximately 2.23.         </summary>
        public const float SQRT5 = 2.23606797f;

        /// <summary>          The cube root of 2. Approximately 1.26.         </summary>
        public const float CBRT2 = 1.25992104f;

        /// <summary>          The cube root of 3. Approximately 1.44.         </summary>
        public const float CBRT3 = 1.44224957f;

        /// <summary>          The cube root of 4. Approximately 1.58.         </summary>
        public const float CBRT4 = 1.58740105f;

        /// <summary>          The inverse cube root of 2. Approximately 0.79.         </summary>
        public const float RCBRT2 = 0.79370052f;

        /// <summary>          The inverse cube root of 4. Approximately 0.62.         </summary>
        public const float RCBRT4 = 0.62996052f;
    }
}