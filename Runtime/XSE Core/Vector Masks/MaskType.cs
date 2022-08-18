namespace MaxMath.Intrinsics
{
    public enum MaskType : byte
    {
        /// <summary>  SSE/AVX Standard  </summary>
        AllOnes,

        /// <summary>  X86 Scalar Standard  </summary>
        One,

        /// <summary>  Minimum blendv Requirement  </summary>
        /// <remarks>  This is most useful for blendv type instructions and is a high performance option. 
        ///            Thus, the bit content of bits other than that of the sign bit is undefined  </remarks>
        SignBit
    }
}
