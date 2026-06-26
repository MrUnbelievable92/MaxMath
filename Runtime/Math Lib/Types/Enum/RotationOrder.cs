namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>   Extrinsic rotation order. Specifies in which order rotations around the principal axes (x, y and z) are to be applied.  </summary>
        public enum RotationOrder : byte
        {
            /// <summary>   Extrinsic rotation around the x axis, then around the y axis and finally around the z axis.    </summary>
            XYZ,
            /// <summary>   Extrinsic rotation around the x axis, then around the z axis and finally around the y axis.    </summary>
            XZY,
            /// <summary>   Extrinsic rotation around the y axis, then around the x axis and finally around the z axis.    </summary>
            YXZ,
            /// <summary>   Extrinsic rotation around the y axis, then around the z axis and finally around the x axis.    </summary>
            YZX,
            /// <summary>   Extrinsic rotation around the z axis, then around the x axis and finally around the y axis.    </summary>
            ZXY,
            /// <summary>   Extrinsic rotation around the z axis, then around the y axis and finally around the x axis.    </summary>
            ZYX,
            /// <summary>   Unity default rotation order. Extrinsic Rotation around the z axis, then around the x axis and finally around the y axis.   </summary>
            Default = ZXY
        };
    }
}