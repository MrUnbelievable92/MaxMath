namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Specifies a shuffle component.  </summary>
        public enum ShuffleComponent : byte
        {
            /// <summary>   Specified the x component of the left vector.   </summary>
            LeftX,
            /// <summary>   Specified the y component of the left vector.   </summary>
            LeftY,
            /// <summary>   Specified the z component of the left vector.   </summary>
            LeftZ,
            /// <summary>   Specified the w component of the left vector.   </summary>
            LeftW,
    
            /// <summary>   Specified the x component of the right vector.  </summary>
            RightX,
            /// <summary>   Specified the y component of the right vector.  </summary>
            RightY,
            /// <summary>   Specified the z component of the right vector.  </summary>
            RightZ,
            /// <summary>   Specified the w component of the right vector.  </summary>
            RightW
        };
    }
}