using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 intpow(UInt128 x, ulong n)
        {
            if (Constant.IsConstantExpression(x))
            {
                if (x == 0) return 0;
                if (x == 1) return 1;
                //if (x == 2) return (UInt128)1 << (int)n;
            }

            if (Constant.IsConstantExpression(n))
            {
                switch (n)
                {
                    case 0:   { return 1; }
                             
                    case 1:   { return x; }
                    case 2:   { return square(x); }
                    case 3:   { return square(x) * x; }
                    case 4:   { UInt128 x2 = square(x); return square(x2); }
                    case 5:   { UInt128 x2 = square(x); return square(x2) * x; }
                    case 6:   { UInt128 x2 = square(x); return square(x2) * x2; }
                    case 7:   { UInt128 x2 = square(x); return square(x2) * (x * x2); }
                    case 8:   { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4); }
                    case 9:   { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * x; }
                    case 10:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * x2; }
                    case 11:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * (x * x2); }
                    case 12:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * x4; }
                    case 13:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * (x * x4); }
                    case 14:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * (x2 * x4); }
                    case 15:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * ((x * x2) * x4); }
                    case 16:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8); }
                    case 17:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * x; }
                    case 18:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * x2; }
                    case 19:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x * x2); }
                    case 20:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * x4; }
                    case 21:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x * x4); }
                    case 22:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x2 * x4); }
                    case 23:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * ((x * x2) * x4); }
                    case 24:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * x8; }
                    case 25:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x * x8); }
                    case 26:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x2 * x8); }
                    case 27:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * ((x * x2) * x8); }
                    case 28:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x4 * x8); }
                    case 29:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * ((x * x4) * x8); }
                    case 30:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * ((x2 * x4) * x8); }
                    case 31:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * ((x * x2) * (x4 * x8)); }
                    case 32:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16); }
                    case 33:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * x; }
                    case 34:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * x2; }
                    case 35:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x * x2); }
                    case 36:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * x4; }
                    case 37:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x * x4); }
                    case 38:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x2 * x4); }
                    case 39:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x2) * x4); }
                    case 40:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * x8; }
                    case 41:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x * x8); }
                    case 42:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x2 * x8); }
                    case 43:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x2) * x8); }
                    case 44:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x4 * x8); }
                    case 45:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x4) * x8); }
                    case 46:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x2 * x4) * x8); }
                    case 47:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (((x * x2) * x4) * x8); }
                    case 48:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * x16; }
                    case 49:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x * x16); }
                    case 50:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x2 * x16); }
                    case 51:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x2) * x16); }
                    case 52:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x4 * x16); }
                    case 53:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x4) * x16); }
                    case 54:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x2 * x4) * x16); }
                    case 55:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (((x * x2) * x4) * x16); }
                    case 56:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x8 * x16); }
                    case 57:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x8) * x16); }
                    case 58:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x2 * x8) * x16); }
                    case 59:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (((x * x2) * x8) * x16); }
                    case 60:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x4 * x8) * x16); }
                    case 61:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (((x * x4) * x8) * x16); }
                    case 62:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (((x2 * x4) * x8) * x16); }
                    case 63:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((((x * x2) * x4) * x8) * x16); }
                    case 64:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32); }
                    case 65:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x; }
                    case 66:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x2; }
                    case 67:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x * x2); }
                    case 68:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x4; }
                    case 69:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x * x4); }
                    case 70:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x2 * x4); }
                    case 71:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x2) * x4); }
                    case 72:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x8; }
                    case 73:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x * x8); }
                    case 74:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x2 * x8); }
                    case 75:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x2) * x8); }
                    case 76:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x4 * x8); }
                    case 77:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x4) * x8); }
                    case 78:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x2 * x4) * x8); }
                    case 79:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (((x * x2) * x4) * x8); }
                    case 80:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x16; }
                    case 81:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x * x16); }
                    case 82:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x2 * x16); }
                    case 83:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x2) * x16); }
                    case 84:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x4 * x16); }
                    case 85:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x4) * x16); }
                    case 86:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x2 * x4) * x16); }
                    case 87:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (((x * x2) * x4) * x16); }
                    case 88:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x8 * x16); }
                    case 89:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x8) * x16); }
                    case 90:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x2 * x8) * x16); }
                    case 91:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (((x * x2) * x8) * x16); }
                    case 92:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x4 * x8) * x16); }
                    case 93:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (((x * x4) * x8) * x16); }
                    case 94:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (((x2 * x4) * x8) * x16); }
                    case 95:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((((x * x2) * x4) * x8) * x16); }
                    case 96:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x32; }
                    case 97:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * x); }
                    case 98:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * x2); }
                    case 99:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x * x2)); }
                    case 100: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * x4); }
                    case 101: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x * x4)); }
                    case 102: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x2 * x4)); }
                    case 103: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x2) * x4)); }
                    case 104: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * x8); }
                    case 105: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x * x8)); }
                    case 106: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x2 * x8)); }
                    case 107: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x2) * x8)); }
                    case 108: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x4 * x8)); }
                    case 109: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x4) * x8)); }
                    case 110: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x2 * x4) * x8)); }
                    case 111: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (((x * x2) * x4) * x8)); }
                    case 112: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * x16); }
                    case 113: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x * x16)); }
                    case 114: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x2 * x16)); }
                    case 115: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x2) * x16)); }
                    case 116: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x4 * x16)); }
                    case 117: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x4) * x16)); }
                    case 118: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x2 * x4) * x16)); }
                    case 119: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (((x * x2) * x4) * x16)); }
                    case 120: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x8 * x16)); }
                    case 121: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x8) * x16)); }
                    case 122: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x2 * x8) * x16)); }
                    case 123: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (((x * x2) * x8) * x16)); }
                    case 124: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x4 * x8) * x16)); }
                    case 125: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (((x * x4) * x8) * x16)); }
                    case 126: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }
                    case 127: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }
                    case 128: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); UInt128 x64 = square(x32); return square(x64); }

                    default: break;
                }
            }

            UInt128 y = isdivisible(n, 2) ? 1 : x;
            x = square(x);
            n >>= 1;
            if (Hint.Unlikely(n == 0))
            {
                return y;
            }

            while (true)
            {
                if (!isdivisible(n, 2))
                {
                    y *= x;
                }

                n >>= 1;

                if (Hint.Unlikely(n == 0))
                {
                    return y;
                }

                x = square(x);
            }
        }
        
        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 intpow(Int128 x, ulong n)
        {
            return (Int128)intpow((UInt128)x, n);
        }


        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intpow(long x, ulong n)
        {
            if (Constant.IsConstantExpression(x))
            {
                switch (x)
                {
                    case 0: return 0;
                    case 1: return 1;
                    //case 2: return 1L << (int)n;

                    default: break;
                }
            }

            if (Constant.IsConstantExpression(n))
            {
                switch (n)
                {
                    case 0:  { return 1; }
                             
                    case 1:  { return x; }
                    case 2:  { return x * x; }
                    case 3:  { return x * x * x; }
                    case 4:  { long x2 = x * x; return x2 * x2; }
                    case 5:  { long x2 = x * x; return x * (x2 * x2); }
                    case 6:  { long x2 = x * x; return x2 * (x2 * x2); }
                    case 7:  { long x2 = x * x; return (x * x2) * (x2 * x2); }
                    case 8:  { long x2 = x * x; long x4 = x2 * x2; return x4 * x4; }
                    case 9:  { long x2 = x * x; long x4 = x2 * x2; return x * (x4 * x4); }
                    case 10: { long x2 = x * x; long x4 = x2 * x2; return x2 * (x4 * x4); }
                    case 11: { long x2 = x * x; long x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                    case 12: { long x2 = x * x; long x4 = x2 * x2; return x4 * (x4 * x4); }
                    case 13: { long x2 = x * x; long x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                    case 14: { long x2 = x * x; long x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                    case 15: { long x2 = x * x; long x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                    case 16: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return x8 * x8; }
                    case 17: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return x * (x8 * x8); }
                    case 18: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return x2 * (x8 * x8); }
                    case 19: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                    case 20: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return x4 * (x8 * x8); }
                    case 21: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                    case 22: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                    case 23: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                    case 24: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return x8 * (x8 * x8); }
                    case 25: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                    case 26: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                    case 27: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                    case 28: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                    case 29: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                    case 30: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                    case 31: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                    case 32: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x16 * x16; }
                    case 33: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x * (x16 * x16); }
                    case 34: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x2 * (x16 * x16); }
                    case 35: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x * x2) * (x16 * x16); }
                    case 36: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x4 * (x16 * x16); }
                    case 37: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x * x4) * (x16 * x16); }
                    case 38: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x2 * x4) * (x16 * x16); }
                    case 39: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x2) * x4) * (x16 * x16); }
                    case 40: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x8 * (x16 * x16); }
                    case 41: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x * x8) * (x16 * x16); }
                    case 42: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x2 * x8) * (x16 * x16); }
                    case 43: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x2) * x8) * (x16 * x16); }
                    case 44: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x4 * x8) * (x16 * x16); }
                    case 45: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x4) * x8) * (x16 * x16); }
                    case 46: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x2 * x4) * x8) * (x16 * x16); }
                    case 47: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (((x * x2) * x4) * x8) * (x16 * x16); }
                    case 48: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x16 * (x16 * x16); }
                    case 49: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x * x16) * (x16 * x16); }
                    case 50: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x2 * x16) * (x16 * x16); }
                    case 51: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x2) * x16) * (x16 * x16); }
                    case 52: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x4 * x16) * (x16 * x16); }
                    case 53: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x4) * x16) * (x16 * x16); }
                    case 54: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x2 * x4) * x16) * (x16 * x16); }
                    case 55: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (((x * x2) * x4) * x16) * (x16 * x16); }
                    case 56: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x8 * x16) * (x16 * x16); }
                    case 57: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x8) * x16) * (x16 * x16); }
                    case 58: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x2 * x8) * x16) * (x16 * x16); }
                    case 59: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (((x * x2) * x8) * x16) * (x16 * x16); }
                    case 60: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x4 * x8) * x16) * (x16 * x16); }
                    case 61: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (((x * x4) * x8) * x16) * (x16 * x16); }
                    case 62: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (((x2 * x4) * x8) * x16) * (x16 * x16); }
                    case 63: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((((x * x2) * x4) * x8) * x16) * (x16 * x16); }
                    case 64: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; long x32 = x16 * x16; return x32 * x32; }

                    default: break;
                }
            }

            long y = isdivisible(n, 2) ? 1 : x;
            x *= x;
            n >>= 1;
            if (Hint.Unlikely(n == 0))
            {
                return y;
            }

            while (true)
            {
                if (!isdivisible(n, 2))
                {
                    y *= x;
                }

                n >>= 1;
                
                if (Hint.Unlikely(n == 0))
                {
                    return y;
                }

                x *= x;
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intpow(long2 x, ulong2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (long2)shl(1L, n);
                }

                if (Constant.IsConstantExpression(n) && n.x == n.y)
                {
                    switch (n.x)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { long2 x2 = x * x; return x2 * x2; }
                        case 5:  { long2 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { long2 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { long2 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { long2 x2 = x * x; long2 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { long2 x2 = x * x; long2 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { long2 x2 = x * x; long2 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { long2 x2 = x * x; long2 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { long2 x2 = x * x; long2 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { long2 x2 = x * x; long2 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { long2 x2 = x * x; long2 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { long2 x2 = x * x; long2 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return x8 * x8; }
                        case 17: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return x * (x8 * x8); }
                        case 18: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return x2 * (x8 * x8); }
                        case 19: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                        case 20: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return x4 * (x8 * x8); }
                        case 21: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                        case 22: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                        case 23: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                        case 24: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return x8 * (x8 * x8); }
                        case 25: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                        case 26: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                        case 27: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                        case 28: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                        case 29: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                        case 30: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                        case 31: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                        case 32: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return x16 * x16; }
                        case 33: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return x * (x16 * x16); }
                        case 34: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return x2 * (x16 * x16); }
                        case 35: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (x * x2) * (x16 * x16); }
                        case 36: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return x4 * (x16 * x16); }
                        case 37: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (x * x4) * (x16 * x16); }
                        case 38: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (x2 * x4) * (x16 * x16); }
                        case 39: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((x * x2) * x4) * (x16 * x16); }
                        case 40: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return x8 * (x16 * x16); }
                        case 41: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (x * x8) * (x16 * x16); }
                        case 42: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (x2 * x8) * (x16 * x16); }
                        case 43: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((x * x2) * x8) * (x16 * x16); }
                        case 44: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (x4 * x8) * (x16 * x16); }
                        case 45: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((x * x4) * x8) * (x16 * x16); }
                        case 46: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((x2 * x4) * x8) * (x16 * x16); }
                        case 47: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (((x * x2) * x4) * x8) * (x16 * x16); }
                        case 48: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return x16 * (x16 * x16); }
                        case 49: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (x * x16) * (x16 * x16); }
                        case 50: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (x2 * x16) * (x16 * x16); }
                        case 51: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((x * x2) * x16) * (x16 * x16); }
                        case 52: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (x4 * x16) * (x16 * x16); }
                        case 53: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((x * x4) * x16) * (x16 * x16); }
                        case 54: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((x2 * x4) * x16) * (x16 * x16); }
                        case 55: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (((x * x2) * x4) * x16) * (x16 * x16); }
                        case 56: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (x8 * x16) * (x16 * x16); }
                        case 57: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((x * x8) * x16) * (x16 * x16); }
                        case 58: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((x2 * x8) * x16) * (x16 * x16); }
                        case 59: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (((x * x2) * x8) * x16) * (x16 * x16); }
                        case 60: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((x4 * x8) * x16) * (x16 * x16); }
                        case 61: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (((x * x4) * x8) * x16) * (x16 * x16); }
                        case 62: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return (((x2 * x4) * x8) * x16) * (x16 * x16); }
                        case 63: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; return ((((x * x2) * x4) * x8) * x16) * (x16 * x16); }
                        case 64: { long2 x2 = x * x; long2 x4 = x2 * x2; long2 x8 = x4 * x4; long2 x16 = x8 * x8; long2 x32 = x16 * x16; return x32 * x32; }
                        
                        default: break;
                    }
                }

                v128 ZERO = Sse2.setzero_si128();
                v128 ONE = new long2(1);

                v128 y = Mask.BlendV(ONE, x, Operator.equals_mask_long(ONE, Sse2.and_si128(n, ONE)));
                n >>= 1;
                v128 doneMask = Operator.equals_mask_long(ZERO, n);
                v128 result = Sse2.and_si128(y, doneMask);

                if (Hint.Likely(bitmask32(2 * sizeof(long)) != Sse2.movemask_epi8(doneMask)))
                {
                    x = Operator.mul_long(x, x);
                }
                else
                {
                    return result;
                }

                while (true)
                {
                    v128 y_times_x = Operator.mul_long(y, x);
                    y = Mask.BlendV(y, y_times_x, Operator.equals_mask_long(ONE, Sse2.and_si128(n, ONE)));

                    n >>= 1;
                    
                    v128 n_is_zero = Operator.equals_mask_long(ZERO, n);
                    result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(bitmask32(2 * sizeof(long)) == Sse2.movemask_epi8(doneMask)))
                    {
                        return result;
                    }

                    x = Operator.mul_long(x, x);
                }
            }
            else
            {
                return new long2(intpow(x.x, n.x), intpow(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intpow(long3 x, ulong3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (long3)shl(1L, n);
                }

                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { long3 x2 = x * x; return x2 * x2; }
                        case 5:  { long3 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { long3 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { long3 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { long3 x2 = x * x; long3 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { long3 x2 = x * x; long3 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { long3 x2 = x * x; long3 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { long3 x2 = x * x; long3 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { long3 x2 = x * x; long3 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { long3 x2 = x * x; long3 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { long3 x2 = x * x; long3 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { long3 x2 = x * x; long3 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return x8 * x8; }
                        case 17: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return x * (x8 * x8); }
                        case 18: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return x2 * (x8 * x8); }
                        case 19: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                        case 20: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return x4 * (x8 * x8); }
                        case 21: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                        case 22: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                        case 23: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                        case 24: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return x8 * (x8 * x8); }
                        case 25: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                        case 26: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                        case 27: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                        case 28: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                        case 29: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                        case 30: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                        case 31: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                        case 32: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return x16 * x16; }
                        case 33: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return x * (x16 * x16); }
                        case 34: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return x2 * (x16 * x16); }
                        case 35: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (x * x2) * (x16 * x16); }
                        case 36: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return x4 * (x16 * x16); }
                        case 37: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (x * x4) * (x16 * x16); }
                        case 38: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (x2 * x4) * (x16 * x16); }
                        case 39: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((x * x2) * x4) * (x16 * x16); }
                        case 40: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return x8 * (x16 * x16); }
                        case 41: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (x * x8) * (x16 * x16); }
                        case 42: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (x2 * x8) * (x16 * x16); }
                        case 43: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((x * x2) * x8) * (x16 * x16); }
                        case 44: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (x4 * x8) * (x16 * x16); }
                        case 45: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((x * x4) * x8) * (x16 * x16); }
                        case 46: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((x2 * x4) * x8) * (x16 * x16); }
                        case 47: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (((x * x2) * x4) * x8) * (x16 * x16); }
                        case 48: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return x16 * (x16 * x16); }
                        case 49: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (x * x16) * (x16 * x16); }
                        case 50: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (x2 * x16) * (x16 * x16); }
                        case 51: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((x * x2) * x16) * (x16 * x16); }
                        case 52: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (x4 * x16) * (x16 * x16); }
                        case 53: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((x * x4) * x16) * (x16 * x16); }
                        case 54: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((x2 * x4) * x16) * (x16 * x16); }
                        case 55: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (((x * x2) * x4) * x16) * (x16 * x16); }
                        case 56: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (x8 * x16) * (x16 * x16); }
                        case 57: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((x * x8) * x16) * (x16 * x16); }
                        case 58: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((x2 * x8) * x16) * (x16 * x16); }
                        case 59: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (((x * x2) * x8) * x16) * (x16 * x16); }
                        case 60: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((x4 * x8) * x16) * (x16 * x16); }
                        case 61: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (((x * x4) * x8) * x16) * (x16 * x16); }
                        case 62: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return (((x2 * x4) * x8) * x16) * (x16 * x16); }
                        case 63: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; return ((((x * x2) * x4) * x8) * x16) * (x16 * x16); }
                        case 64: { long3 x2 = x * x; long3 x4 = x2 * x2; long3 x8 = x4 * x4; long3 x16 = x8 * x8; long3 x32 = x16 * x16; return x32 * x32; }

                        default: break;
                    }
                }

                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ONE = new long3(1);
                
                v256 y = Avx2.mm256_blendv_epi8(ONE, x, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(n, ONE)));
                n >>= 1;
                v256 doneMask = Avx2.mm256_cmpeq_epi64(ZERO, n);
                v256 result = Avx2.mm256_and_si256(y, doneMask);
                
                if (Hint.Likely(bitmask32(3 * sizeof(long)) != (bitmask32(3 * sizeof(long)) & Avx2.mm256_movemask_epi8(doneMask))))
                {
                    x = Operator.mul_long(x, x);
                }
                else
                {
                    return result;
                }

                while (true)
                {
                    v256 y_times_x = Operator.mul_long(y, x);
                    y = Avx2.mm256_blendv_epi8(y, y_times_x, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(n, ONE)));

                    n >>= 1;

                    v256 n_is_zero = Avx2.mm256_cmpeq_epi64(ZERO, n);
                    result = Avx2.mm256_blendv_epi8(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(bitmask32(3 * sizeof(long)) == (bitmask32(3 * sizeof(long)) & Avx2.mm256_movemask_epi8(doneMask))))
                    {
                        return result;
                    }

                    x = Operator.mul_long(x, x);
                }
            }
            else
            {
                return new long3(intpow(x.xy, n.xy), intpow(x.z, n.z));
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intpow(long4 x, ulong4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (long4)shl(1L, n);
                }

                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { long4 x2 = x * x; return x2 * x2; }
                        case 5:  { long4 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { long4 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { long4 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { long4 x2 = x * x; long4 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { long4 x2 = x * x; long4 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { long4 x2 = x * x; long4 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { long4 x2 = x * x; long4 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { long4 x2 = x * x; long4 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { long4 x2 = x * x; long4 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { long4 x2 = x * x; long4 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { long4 x2 = x * x; long4 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return x8 * x8; }
                        case 17: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return x * (x8 * x8); }
                        case 18: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return x2 * (x8 * x8); }
                        case 19: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                        case 20: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return x4 * (x8 * x8); }
                        case 21: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                        case 22: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                        case 23: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                        case 24: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return x8 * (x8 * x8); }
                        case 25: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                        case 26: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                        case 27: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                        case 28: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                        case 29: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                        case 30: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                        case 31: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                        case 32: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return x16 * x16; }
                        case 33: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return x * (x16 * x16); }
                        case 34: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return x2 * (x16 * x16); }
                        case 35: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (x * x2) * (x16 * x16); }
                        case 36: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return x4 * (x16 * x16); }
                        case 37: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (x * x4) * (x16 * x16); }
                        case 38: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (x2 * x4) * (x16 * x16); }
                        case 39: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((x * x2) * x4) * (x16 * x16); }
                        case 40: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return x8 * (x16 * x16); }
                        case 41: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (x * x8) * (x16 * x16); }
                        case 42: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (x2 * x8) * (x16 * x16); }
                        case 43: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((x * x2) * x8) * (x16 * x16); }
                        case 44: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (x4 * x8) * (x16 * x16); }
                        case 45: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((x * x4) * x8) * (x16 * x16); }
                        case 46: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((x2 * x4) * x8) * (x16 * x16); }
                        case 47: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (((x * x2) * x4) * x8) * (x16 * x16); }
                        case 48: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return x16 * (x16 * x16); }
                        case 49: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (x * x16) * (x16 * x16); }
                        case 50: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (x2 * x16) * (x16 * x16); }
                        case 51: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((x * x2) * x16) * (x16 * x16); }
                        case 52: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (x4 * x16) * (x16 * x16); }
                        case 53: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((x * x4) * x16) * (x16 * x16); }
                        case 54: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((x2 * x4) * x16) * (x16 * x16); }
                        case 55: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (((x * x2) * x4) * x16) * (x16 * x16); }
                        case 56: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (x8 * x16) * (x16 * x16); }
                        case 57: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((x * x8) * x16) * (x16 * x16); }
                        case 58: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((x2 * x8) * x16) * (x16 * x16); }
                        case 59: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (((x * x2) * x8) * x16) * (x16 * x16); }
                        case 60: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((x4 * x8) * x16) * (x16 * x16); }
                        case 61: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (((x * x4) * x8) * x16) * (x16 * x16); }
                        case 62: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return (((x2 * x4) * x8) * x16) * (x16 * x16); }
                        case 63: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; return ((((x * x2) * x4) * x8) * x16) * (x16 * x16); }
                        case 64: { long4 x2 = x * x; long4 x4 = x2 * x2; long4 x8 = x4 * x4; long4 x16 = x8 * x8; long4 x32 = x16 * x16; return x32 * x32; }

                        default: break;
                    }
                }

                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ONE = new long4(1);
                
                v256 y = Avx2.mm256_blendv_epi8(ONE, x, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(n, ONE)));
                n >>= 1;
                v256 doneMask = Avx2.mm256_cmpeq_epi64(ZERO, n);
                v256 result = Avx2.mm256_and_si256(y, doneMask);
                
                if (Hint.Likely(-1 != Avx2.mm256_movemask_epi8(doneMask)))
                {
                    x = Operator.mul_long(x, x);
                }
                else
                {
                    return result;
                }

                while (true)
                {
                    v256 y_times_x = Operator.mul_long(y, x);
                    y = Avx2.mm256_blendv_epi8(y, y_times_x, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(n, ONE)));

                    n >>= 1;

                    v256 n_is_zero = Avx2.mm256_cmpeq_epi64(ZERO, n);
                    result = Avx2.mm256_blendv_epi8(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(-1 == Avx2.mm256_movemask_epi8(doneMask)))
                    {
                        return result;
                    }

                    x = Operator.mul_long(x, x);
                }
            }
            else
            {
                return new long4(intpow(x.xy, n.xy), intpow(x.zw, n.zw));
            }
        }


        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intpow(ulong x, ulong n)
        {
            return (ulong)intpow((long)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intpow(ulong2 x, ulong2 n)
        {
            return (ulong2)intpow((long2)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intpow(ulong3 x, ulong3 n)
        {
            return (ulong3)intpow((long3)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intpow(ulong4 x, ulong4 n)
        {
            return (ulong4)intpow((long4)x, n);
        }


        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intpow(int x, uint n)
        {
            if (Constant.IsConstantExpression(x))
            {
                switch (x)
                {
                    case 0: return 0;
                    case 1: return 1;
                    //case 2: return 1 << (int)n;

                    default: break;
                }
            }

            if (Constant.IsConstantExpression(n))
            {
                switch (n)
                {
                    case 0:  { return 1; }
                             
                    case 1:  { return x; }
                    case 2:  { return x * x; }
                    case 3:  { return x * x * x; }
                    case 4:  { int x2 = x * x; return x2 * x2; }
                    case 5:  { int x2 = x * x; return x * (x2 * x2); }
                    case 6:  { int x2 = x * x; return x2 * (x2 * x2); }
                    case 7:  { int x2 = x * x; return (x * x2) * (x2 * x2); }
                    case 8:  { int x2 = x * x; int x4 = x2 * x2; return x4 * x4; }
                    case 9:  { int x2 = x * x; int x4 = x2 * x2; return x * (x4 * x4); }
                    case 10: { int x2 = x * x; int x4 = x2 * x2; return x2 * (x4 * x4); }
                    case 11: { int x2 = x * x; int x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                    case 12: { int x2 = x * x; int x4 = x2 * x2; return x4 * (x4 * x4); }
                    case 13: { int x2 = x * x; int x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                    case 14: { int x2 = x * x; int x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                    case 15: { int x2 = x * x; int x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                    case 16: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return x8 * x8; }
                    case 17: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return x * (x8 * x8); }
                    case 18: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return x2 * (x8 * x8); }
                    case 19: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                    case 20: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return x4 * (x8 * x8); }
                    case 21: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                    case 22: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                    case 23: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                    case 24: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return x8 * (x8 * x8); }
                    case 25: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                    case 26: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                    case 27: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                    case 28: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                    case 29: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                    case 30: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                    case 31: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                    case 32: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; int x16 = x8 * x8; return x16 * x16; }

                    default: break;
                }
            }

            int y = isdivisible(n, 2) ? 1 : x;
            x *= x;
            n >>= 1;
            if (Hint.Unlikely(n == 0))
            {
                return y;
            }

            while (true)
            {
                if (!isdivisible(n, 2))
                {
                    y *= x;
                }
            
                n >>= 1;
            
                if (Hint.Unlikely(n == 0))
                {
                    return y;
                }
            
                x *= x;
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intpow(int2 x, uint2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (int2)shl(1, n);
                }

                if (Constant.IsConstantExpression(n) && n.x == n.y)
                {
                    switch (n.x)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { int2 x2 = x * x; return x2 * x2; }
                        case 5:  { int2 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { int2 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { int2 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { int2 x2 = x * x; int2 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { int2 x2 = x * x; int2 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { int2 x2 = x * x; int2 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { int2 x2 = x * x; int2 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { int2 x2 = x * x; int2 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { int2 x2 = x * x; int2 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { int2 x2 = x * x; int2 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { int2 x2 = x * x; int2 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return x8 * x8; }
                        case 17: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return x * (x8 * x8); }
                        case 18: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return x2 * (x8 * x8); }
                        case 19: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                        case 20: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return x4 * (x8 * x8); }
                        case 21: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                        case 22: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                        case 23: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                        case 24: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return x8 * (x8 * x8); }
                        case 25: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                        case 26: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                        case 27: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                        case 28: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                        case 29: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                        case 30: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                        case 31: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                        case 32: { int2 x2 = x * x; int2 x4 = x2 * x2; int2 x8 = x4 * x4; int2 x16 = x8 * x8; return x16 * x16; }
                    
                        default: break;
                    }
                }

                v128 ZERO = Sse2.setzero_si128();
                v128 ONE = new v128(1);
                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _n = UnityMathematicsLink.Tov128(n);

                v128 y = Mask.BlendV(ONE, _x, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(_n, ONE)));
                _n = Sse2.srli_epi32(_n, 1);
                v128 doneMask = Sse2.cmpeq_epi32(ZERO, _n);
                v128 result = Sse2.and_si128(y, doneMask);
                
                if (Hint.Likely(-1 != doneMask.SLong0))
                {
                    _x = Operator.mul_int(_x, _x);
                }
                else
                {
                    return *(int2*)&result;
                }

                while (true)
                {
                    v128 y_times_x = Operator.mul_int(y, _x);
                    y = Mask.BlendV(y, y_times_x, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(ONE, _n)));

                    _n = Sse2.srli_epi32(_n, 1);

                    v128 n_is_zero = Sse2.cmpeq_epi32(ZERO, _n);
                    result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(-1 == doneMask.SLong0))
                    {
                        return *(int2*)&result;
                    }

                    _x = Operator.mul_int(_x, _x);
                }
            }
            else
            {
                return new int2(intpow(x.x, n.x), intpow(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intpow(int3 x, uint3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (int3)shl(1, n);
                }

                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { int3 x2 = x * x; return x2 * x2; }
                        case 5:  { int3 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { int3 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { int3 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { int3 x2 = x * x; int3 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { int3 x2 = x * x; int3 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { int3 x2 = x * x; int3 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { int3 x2 = x * x; int3 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { int3 x2 = x * x; int3 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { int3 x2 = x * x; int3 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { int3 x2 = x * x; int3 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { int3 x2 = x * x; int3 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return x8 * x8; }
                        case 17: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return x * (x8 * x8); }
                        case 18: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return x2 * (x8 * x8); }
                        case 19: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                        case 20: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return x4 * (x8 * x8); }
                        case 21: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                        case 22: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                        case 23: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                        case 24: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return x8 * (x8 * x8); }
                        case 25: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                        case 26: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                        case 27: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                        case 28: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                        case 29: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                        case 30: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                        case 31: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                        case 32: { int3 x2 = x * x; int3 x4 = x2 * x2; int3 x8 = x4 * x4; int3 x16 = x8 * x8; return x16 * x16; }
                    
                        default: break;
                    }
                }

                v128 ZERO = Sse2.setzero_si128();
                v128 ONE = new v128(1);
                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _n = UnityMathematicsLink.Tov128(n);

                v128 y = Mask.BlendV(ONE, _x, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(_n, ONE)));
                _n = Sse2.srli_epi32(_n, 1);
                v128 doneMask = Sse2.cmpeq_epi32(ZERO, _n);
                v128 result = Sse2.and_si128(y, doneMask);
                
                if (Hint.Likely(bitmask32(3 * sizeof(int)) != (bitmask32(3 * sizeof(int)) & Sse2.movemask_epi8(doneMask))))
                {
                    _x = Operator.mul_int(_x, _x);
                }
                else
                {
                    return *(int3*)&result;
                }
                
                while (true)
                {
                    v128 y_times_x = Operator.mul_int(y, _x);
                    y = Mask.BlendV(y, y_times_x, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(ONE, _n)));

                    _n = Sse2.srli_epi32(_n, 1);

                    v128 n_is_zero = Sse2.cmpeq_epi32(ZERO, _n);
                    result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(bitmask32(3 * sizeof(int)) == (bitmask32(3 * sizeof(int)) & Sse2.movemask_epi8(doneMask))))
                    {
                        return *(int3*)&result;
                    }

                    _x = Operator.mul_int(_x, _x);
                }
            }
            else
            {
                return new int3(intpow(x.x, n.x), intpow(x.y, n.y), intpow(x.z, n.z));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intpow(int4 x, uint4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (int4)shl(1, n);
                }

                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { int4 x2 = x * x; return x2 * x2; }
                        case 5:  { int4 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { int4 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { int4 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { int4 x2 = x * x; int4 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { int4 x2 = x * x; int4 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { int4 x2 = x * x; int4 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { int4 x2 = x * x; int4 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { int4 x2 = x * x; int4 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { int4 x2 = x * x; int4 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { int4 x2 = x * x; int4 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { int4 x2 = x * x; int4 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return x8 * x8; }
                        case 17: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return x * (x8 * x8); }
                        case 18: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return x2 * (x8 * x8); }
                        case 19: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                        case 20: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return x4 * (x8 * x8); }
                        case 21: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                        case 22: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                        case 23: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                        case 24: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return x8 * (x8 * x8); }
                        case 25: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                        case 26: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                        case 27: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                        case 28: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                        case 29: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                        case 30: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                        case 31: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                        case 32: { int4 x2 = x * x; int4 x4 = x2 * x2; int4 x8 = x4 * x4; int4 x16 = x8 * x8; return x16 * x16; }
                    
                        default: break;
                    }
                }

                v128 ZERO = Sse2.setzero_si128();
                v128 ONE = new v128(1);
                v128 _x = UnityMathematicsLink.Tov128(x);
                v128 _n = UnityMathematicsLink.Tov128(n);

                v128 y = Mask.BlendV(ONE, _x, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(_n, ONE)));
                _n = Sse2.srli_epi32(_n, 1);
                v128 doneMask = Sse2.cmpeq_epi32(ZERO, _n);
                v128 result = Sse2.and_si128(y, doneMask);
                
                if (Hint.Likely(bitmask32(4 * sizeof(int)) != Sse2.movemask_epi8(doneMask)))
                {
                    _x = Operator.mul_int(_x, _x);
                }
                else
                {
                    return *(int4*)&result;
                }
                
                while (true)
                {
                    v128 y_times_x = Operator.mul_int(y, _x);
                    y = Mask.BlendV(y, y_times_x, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(ONE, _n)));

                    _n = Sse2.srli_epi32(_n, 1);

                    v128 n_is_zero = Sse2.cmpeq_epi32(ZERO, _n);
                    result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(bitmask32(4 * sizeof(int)) == Sse2.movemask_epi8(doneMask)))
                    {
                        return *(int4*)&result;
                    }

                    _x = Operator.mul_int(_x, _x);
                }
            }
            else
            {
                return new int4(intpow(x.x, n.x), intpow(x.y, n.y), intpow(x.z, n.z), intpow(x.w, n.w));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intpow(int8 x, uint8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (all(x == 0)) return 0;
                    if (all(x == 1)) return 1;
                    //if (all(x == 2)) return (int8)shl(1, n);
                }

                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x0)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { int8 x2 = x * x; return x2 * x2; }
                        case 5:  { int8 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { int8 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { int8 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { int8 x2 = x * x; int8 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { int8 x2 = x * x; int8 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { int8 x2 = x * x; int8 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { int8 x2 = x * x; int8 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { int8 x2 = x * x; int8 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { int8 x2 = x * x; int8 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { int8 x2 = x * x; int8 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { int8 x2 = x * x; int8 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return x8 * x8; }
                        case 17: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return x * (x8 * x8); }
                        case 18: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return x2 * (x8 * x8); }
                        case 19: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                        case 20: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return x4 * (x8 * x8); }
                        case 21: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                        case 22: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                        case 23: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                        case 24: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return x8 * (x8 * x8); }
                        case 25: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                        case 26: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                        case 27: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                        case 28: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                        case 29: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                        case 30: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                        case 31: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                        case 32: { int8 x2 = x * x; int8 x4 = x2 * x2; int8 x8 = x4 * x4; int8 x16 = x8 * x8; return x16 * x16; }
                    
                        default: break;
                    }
                }

                v256 ZERO = Avx.mm256_setzero_si256();
                v256 ONE = new int8(1);
                
                v256 y = Avx2.mm256_blendv_epi8(ONE, x, Avx2.mm256_cmpeq_epi32(ONE, Avx2.mm256_and_si256(n, ONE)));
                n >>= 1;
                v256 doneMask = Avx2.mm256_cmpeq_epi32(ZERO, n);
                v256 result = Avx2.mm256_and_si256(y, doneMask);
                
                if (Hint.Likely(-1 != Avx2.mm256_movemask_epi8(doneMask)))
                {
                    x *= x;
                }
                else
                {
                    return result;
                }

                while (true)
                {
                    v256 y_times_x = y * x;
                    y = Avx2.mm256_blendv_epi8(y, y_times_x, Avx2.mm256_cmpeq_epi32(ONE, Avx2.mm256_and_si256(n, ONE)));

                    n >>= 1;

                    v256 n_is_zero = Avx2.mm256_cmpeq_epi32(ZERO, n);
                    result = Avx2.mm256_blendv_epi8(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(-1 == Avx2.mm256_movemask_epi8(doneMask)))
                    {
                        return result;
                    }

                    x *= x;
                }
            }
            else
            {
                return new int8(intpow(x.v4_0, n.v4_0), intpow(x.v4_4, n.v4_4));
            }
        }
        

        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intpow(uint x, uint n)
        {
            return (uint)intpow((int)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intpow(uint2 x, uint2 n)
        {
            return (uint2)intpow((int2)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intpow(uint3 x, uint3 n)
        {
            return (uint3)intpow((int3)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intpow(uint4 x, uint4 n)
        {
            return (uint4)intpow((int4)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intpow(uint8 x, uint8 n)
        {
            return (uint8)intpow((int8)x, n);
        }


        // <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intpow(short x, uint n)
        {
            return (int)intpow((int)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intpow(short2 x, ushort2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (short2)shl(1, n);
                }

                if (Constant.IsConstantExpression(n) && n.x == n.y)
                {
                    switch (n.x)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { short2 x2 = x * x; return x2 * x2; }
                        case 5:  { short2 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { short2 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { short2 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { short2 x2 = x * x; short2 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { short2 x2 = x * x; short2 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { short2 x2 = x * x; short2 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { short2 x2 = x * x; short2 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { short2 x2 = x * x; short2 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { short2 x2 = x * x; short2 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { short2 x2 = x * x; short2 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { short2 x2 = x * x; short2 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { short2 x2 = x * x; short2 x4 = x2 * x2; short2 x8 = x4 * x4; return x8 * x8; }
            
                        default: break;
                    }
                }

                v128 ZERO = Sse2.setzero_si128();
                short2 ONE = new short2(1);

                v128 y = Mask.BlendV(ONE, x, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(n, ONE)));
                n >>= 1;
                v128 doneMask = Sse2.cmpeq_epi16(ZERO, x);
                v128 result = Sse2.and_si128(y, doneMask);
                
                if (Hint.Likely(-1 != doneMask.SInt0))
                {
                    x *= x;
                }
                else
                {
                    return result;
                }

                while (true)
                {
                    v128 y_times_x = y * x;
                    y = Mask.BlendV(y, y_times_x, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(ONE, n)));

                    n >>= 1;

                    v128 n_is_zero = Sse2.cmpeq_epi16(ZERO, n);
                    result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(-1 == doneMask.SInt0))
                    {
                        return result;
                    }

                    x *= x;
                }
            }
            else
            {
                return new short2((short)intpow((int)x.x, n.x), (short)intpow((int)x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intpow(short3 x, ushort3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (short3)shl(1, n);
                }

                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { short3 x2 = x * x; return x2 * x2; }
                        case 5:  { short3 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { short3 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { short3 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { short3 x2 = x * x; short3 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { short3 x2 = x * x; short3 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { short3 x2 = x * x; short3 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { short3 x2 = x * x; short3 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { short3 x2 = x * x; short3 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { short3 x2 = x * x; short3 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { short3 x2 = x * x; short3 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { short3 x2 = x * x; short3 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { short3 x2 = x * x; short3 x4 = x2 * x2; short3 x8 = x4 * x4; return x8 * x8; }
            
                        default: break;
                    }
                }

                v128 ZERO = Sse2.setzero_si128();
                short3 ONE = new short3(1);

                v128 y = Mask.BlendV(ONE, x, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(n, ONE)));
                n >>= 1;
                v128 doneMask = Sse2.cmpeq_epi16(ZERO, x);
                v128 result = Sse2.and_si128(y, doneMask);
                
                if (Hint.Likely(bitmask32(3 * sizeof(short)) != (bitmask32(3 * sizeof(short)) & Sse2.movemask_epi8(doneMask))))
                {
                    x *= x;
                }
                else
                {
                    return result;
                }
                
                while (true)
                {
                    v128 y_times_x = y * x;
                    y = Mask.BlendV(y, y_times_x, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(ONE, n)));

                    n >>= 1;

                    v128 n_is_zero = Sse2.cmpeq_epi16(ZERO, n);
                    result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(bitmask32(3 * sizeof(short)) == (bitmask32(3 * sizeof(short)) & Sse2.movemask_epi8(doneMask))))
                    {
                        return result;
                    }

                    x *= x;
                }
            }
            else
            {
                return new short3((short)intpow((int)x.x, n.x), (short)intpow((int)x.y, n.y), (short)intpow((int)x.z, n.z));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intpow(short4 x, ushort4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (short4)shl(1, n);
                }

                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { short4 x2 = x * x; return x2 * x2; }
                        case 5:  { short4 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { short4 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { short4 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { short4 x2 = x * x; short4 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { short4 x2 = x * x; short4 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { short4 x2 = x * x; short4 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { short4 x2 = x * x; short4 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { short4 x2 = x * x; short4 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { short4 x2 = x * x; short4 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { short4 x2 = x * x; short4 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { short4 x2 = x * x; short4 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { short4 x2 = x * x; short4 x4 = x2 * x2; short4 x8 = x4 * x4; return x8 * x8; }
            
                        default: break;
                    }
                }

                v128 ZERO = Sse2.setzero_si128();
                short4 ONE = new short4(1);

                v128 y = Mask.BlendV(ONE, x, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(n, ONE)));
                n >>= 1;
                v128 doneMask = Sse2.cmpeq_epi16(ZERO, x);
                v128 result = Sse2.and_si128(y, doneMask);
                
                if (Hint.Likely(-1 != doneMask.SLong0))
                {
                    x *= x;
                }
                else
                {
                    return result;
                }
                
                while (true)
                {
                    v128 y_times_x = y * x;
                    y = Mask.BlendV(y, y_times_x, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(ONE, n)));

                    n >>= 1;

                    v128 n_is_zero = Sse2.cmpeq_epi16(ZERO, n);
                    result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(-1 == doneMask.SLong0))
                    {
                        return result;
                    }

                    x *= x;
                }
            }
            else
            {
                return new short4((short)intpow((int)x.x, n.x), (short)intpow((int)x.y, n.y), (short)intpow((int)x.z, n.z), (short)intpow((int)x.w, n.w));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intpow(short8 x, ushort8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (all(x == 0)) return 0;
                    if (all(x == 1)) return 1;
                    //if (all(x == 2)) return (short8)shl(1, n);
                }

                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x0)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { short8 x2 = x * x; return x2 * x2; }
                        case 5:  { short8 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { short8 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { short8 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { short8 x2 = x * x; short8 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { short8 x2 = x * x; short8 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { short8 x2 = x * x; short8 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { short8 x2 = x * x; short8 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { short8 x2 = x * x; short8 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { short8 x2 = x * x; short8 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { short8 x2 = x * x; short8 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { short8 x2 = x * x; short8 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { short8 x2 = x * x; short8 x4 = x2 * x2; short8 x8 = x4 * x4; return x8 * x8; }
            
                        default: break;
                    }
                }

                v128 ZERO = Sse2.setzero_si128();
                short8 ONE = new short8(1);

                v128 y = Mask.BlendV(ONE, x, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(n, ONE)));
                n >>= 1;
                v128 doneMask = Sse2.cmpeq_epi16(ZERO, x);
                v128 result = Sse2.and_si128(y, doneMask);
                
                if (Hint.Likely(bitmask32(8 * sizeof(short)) != Sse2.movemask_epi8(doneMask)))
                {
                    x *= x;
                }
                else
                {
                    return result;
                }
                
                while (true)
                {
                    v128 y_times_x = y * x;
                    y = Mask.BlendV(y, y_times_x, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(ONE, n)));

                    n >>= 1;

                    v128 n_is_zero = Sse2.cmpeq_epi16(ZERO, n);
                    result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(bitmask32(8 * sizeof(short)) == Sse2.movemask_epi8(doneMask)))
                    {
                        return result;
                    }

                    x *= x;
                }
            }
            else
            {
                return new short8((short)intpow((int)x.x0, n.x0), 
                                  (short)intpow((int)x.x1, n.x1), 
                                  (short)intpow((int)x.x2, n.x2),
                                  (short)intpow((int)x.x3, n.x3),
                                  (short)intpow((int)x.x4, n.x4),
                                  (short)intpow((int)x.x5, n.x5),
                                  (short)intpow((int)x.x6, n.x6),
                                  (short)intpow((int)x.x7, n.x7));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intpow(short16 x, ushort16 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (all(x == 0)) return 0;
                    if (all(x == 1)) return 1;
                    //if (all(x == 2)) return (short16)shl(1, n);
                }

                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x0)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { short16 x2 = x * x; return x2 * x2; }
                        case 5:  { short16 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { short16 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { short16 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { short16 x2 = x * x; short16 x4 = x2 * x2; return x4 * x4; }
                        case 9:  { short16 x2 = x * x; short16 x4 = x2 * x2; return x * (x4 * x4); }
                        case 10: { short16 x2 = x * x; short16 x4 = x2 * x2; return x2 * (x4 * x4); }
                        case 11: { short16 x2 = x * x; short16 x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                        case 12: { short16 x2 = x * x; short16 x4 = x2 * x2; return x4 * (x4 * x4); }
                        case 13: { short16 x2 = x * x; short16 x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                        case 14: { short16 x2 = x * x; short16 x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                        case 15: { short16 x2 = x * x; short16 x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                        case 16: { short16 x2 = x * x; short16 x4 = x2 * x2; short16 x8 = x4 * x4; return x8 * x8; }
            
                        default: break;
                    }
                }

                v256 ZERO = Avx.mm256_setzero_si256();
                short16 ONE = new short16(1);

                v256 y = Avx2.mm256_blendv_epi8(ONE, x, Avx2.mm256_cmpeq_epi16(ONE, Avx2.mm256_and_si256(n, ONE)));
                n >>= 1;
                v256 doneMask = Avx2.mm256_cmpeq_epi16(ZERO, x);
                v256 result = Avx2.mm256_and_si256(y, doneMask);
                
                if (Hint.Likely(-1 != Avx2.mm256_movemask_epi8(doneMask)))
                {
                    x *= x;
                }
                else
                {
                    return result;
                }

                while (true)
                {
                    v256 y_times_x = y * x;
                    y = Avx2.mm256_blendv_epi8(y, y_times_x, Avx2.mm256_cmpeq_epi16(ONE, Avx2.mm256_and_si256(ONE, n)));

                    n >>= 1;

                    v256 n_is_zero = Avx2.mm256_cmpeq_epi16(ZERO, n);
                    result = Avx2.mm256_blendv_epi8(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(-1 == Avx2.mm256_movemask_epi8(doneMask)))
                    {
                        return result;
                    }

                    x *= x;
                }
            }
            else
            {
                return new short16(intpow(x.v8_0, n.v8_0), intpow(x.v8_8, n.v8_8));
            }
        }
        

        // <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intpow(ushort x, uint n)
        {
            return (uint)intpow((uint)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intpow(ushort2 x, ushort2 n)
        {
            return (ushort2)intpow((short2)x, n);
        }

        /// <summary>       Computes <paramref name="x"/> to the power of <paramref name="n"/> for each corresponding component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intpow(ushort3 x, ushort3 n)
        {
            return (ushort3)intpow((short3)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intpow(ushort4 x, ushort4 n)
        {
            return (ushort4)intpow((short4)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intpow(ushort8 x, ushort8 n)
        {
            return (ushort8)intpow((short8)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intpow(ushort16 x, ushort16 n)
        {
            return (ushort16)intpow((short16)x, n);
        }


        // <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intpow(sbyte x, uint n)
        {
            return (int)intpow((int)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intpow(sbyte2 x, byte2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (sbyte2)shl(1, n);
                }

                return (sbyte2)intpow((short2)x, (ushort2)n);
            }
            else
            {
                return new sbyte2((sbyte)intpow((int)x.x, n.x), (sbyte)intpow((int)x.y, n.y));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intpow(sbyte3 x, byte3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (sbyte3)shl(1, n);
                }

                return (sbyte3)intpow((short3)x, (ushort3)n);
            }
            else
            {
                return new sbyte3((sbyte)intpow((int)x.x, n.x), (sbyte)intpow((int)x.y, n.y), (sbyte)intpow((int)x.z, n.z));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intpow(sbyte4 x, byte4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (math.all(x == 0)) return 0;
                    if (math.all(x == 1)) return 1;
                    //if (math.all(x == 2)) return (sbyte4)shl(1, n);
                }

                return (sbyte4)intpow((short4)x, (ushort4)n);
            }
            else
            {
                return new sbyte4((sbyte)intpow((int)x.x, n.x), (sbyte)intpow((int)x.y, n.y), (sbyte)intpow((int)x.z, n.z), (sbyte)intpow((int)x.w, n.w));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intpow(sbyte8 x, byte8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (all(x == 0)) return 0;
                    if (all(x == 1)) return 1;
                    //if (all(x == 2)) return (sbyte8)shl(1, n);
                }

                return (sbyte8)intpow((short8)x, (ushort8)n);
            }
            else
            {
                return new sbyte8((sbyte)intpow((int)x.x0, n.x0),
                                  (sbyte)intpow((int)x.x1, n.x1),
                                  (sbyte)intpow((int)x.x2, n.x2),
                                  (sbyte)intpow((int)x.x3, n.x3),
                                  (sbyte)intpow((int)x.x4, n.x4),
                                  (sbyte)intpow((int)x.x5, n.x5),
                                  (sbyte)intpow((int)x.x6, n.x6),
                                  (sbyte)intpow((int)x.x7, n.x7));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intpow(sbyte16 x, byte16 n)
        {
            if (Constant.IsConstantExpression(x))
            {
                if (all(x == 0)) return 0;
                if (all(x == 1)) return 1;
                //if (all(x == 2)) return (sbyte16)shl(1, n);
            }

            if (Avx2.IsAvx2Supported)
            {
                return (sbyte16)intpow((short16)x, (ushort16)n);
            }
            else if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x0)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { sbyte16 x2 = x * x; return x2 * x2; }
                        case 5:  { sbyte16 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { sbyte16 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { sbyte16 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { sbyte16 x2 = x * x; sbyte16 x4 = x2 * x2; return x4 * x4; }

                        default: break;
                    }
                }

                v128 ZERO = Sse2.setzero_si128();
                sbyte16 ONE = new sbyte16(1);

                v128 y = Mask.BlendV(ONE, x, Sse2.cmpeq_epi8(ONE, Sse2.and_si128(n, ONE)));
                n >>= 1;
                v128 doneMask = Sse2.cmpeq_epi8(ZERO, x);
                v128 result = Sse2.and_si128(y, doneMask);
                
                if (Hint.Likely(bitmask32(16 * sizeof(sbyte)) != Sse2.movemask_epi8(doneMask)))
                {
                    x *= x;
                }
                else
                {
                    return result;
                }
                
                while (true)
                {
                    v128 y_times_x = y * x;
                    y = Mask.BlendV(y, y_times_x, Sse2.cmpeq_epi8(ONE, Sse2.and_si128(ONE, n)));

                    n >>= 1;

                    v128 n_is_zero = Sse2.cmpeq_epi8(ZERO, n);
                    result = Mask.BlendV(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                    doneMask = n_is_zero;

                    if (Hint.Unlikely(bitmask32(16 * sizeof(sbyte)) == Sse2.movemask_epi8(doneMask)))
                    {
                        return result;
                    }

                    x *= x;
                }
            }
            else
            {
                return new sbyte16((sbyte)intpow((int)x.x0,  n.x0),
                                   (sbyte)intpow((int)x.x1,  n.x1),
                                   (sbyte)intpow((int)x.x2,  n.x2),
                                   (sbyte)intpow((int)x.x3,  n.x3),
                                   (sbyte)intpow((int)x.x4,  n.x4),
                                   (sbyte)intpow((int)x.x5,  n.x5),
                                   (sbyte)intpow((int)x.x6,  n.x6),
                                   (sbyte)intpow((int)x.x7,  n.x7),
                                   (sbyte)intpow((int)x.x8,  n.x8),
                                   (sbyte)intpow((int)x.x9,  n.x9),
                                   (sbyte)intpow((int)x.x10, n.x10),
                                   (sbyte)intpow((int)x.x11, n.x11),
                                   (sbyte)intpow((int)x.x12, n.x12),
                                   (sbyte)intpow((int)x.x13, n.x13),
                                   (sbyte)intpow((int)x.x14, n.x14),
                                   (sbyte)intpow((int)x.x15, n.x15));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intpow(sbyte32 x, byte32 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(x))
                {
                    if (all(x == 0)) return 0;
                    if (all(x == 1)) return 1;
                    //if (all(x == 2)) return (sbyte32)shl(1, n);
                }

                if (Constant.IsConstantExpression(n) && all_eq(n))
                {
                    switch (n.x0)
                    {
                        case 0:  { return 1; }
                         
                        case 1:  { return x; }
                        case 2:  { return x * x; }
                        case 3:  { return x * x * x; }
                        case 4:  { sbyte32 x2 = x * x; return x2 * x2; }
                        case 5:  { sbyte32 x2 = x * x; return x * (x2 * x2); }
                        case 6:  { sbyte32 x2 = x * x; return x2 * (x2 * x2); }
                        case 7:  { sbyte32 x2 = x * x; return (x * x2) * (x2 * x2); }
                        case 8:  { sbyte32 x2 = x * x; sbyte32 x4 = x2 * x2; return x4 * x4; }

                        default: break;
                    }
                }

                v256 ZERO = Avx.mm256_setzero_si256();
                sbyte32 ONE = new sbyte32(1);

                v256 y = Avx2.mm256_blendv_epi8(ONE, x, Avx2.mm256_cmpeq_epi8(ONE, Avx2.mm256_and_si256(n, ONE)));
                n >>= 1;
                v256 doneMask = Avx2.mm256_cmpeq_epi8(ZERO, x);
                v256 result = Avx2.mm256_and_si256(y, doneMask);
                
                if (Hint.Likely(-1 != Avx2.mm256_movemask_epi8(doneMask)))
                {
                    x *= x;
                }
                else
                {
                    return result;
                }

                while (true)
                {
                    v256 y_times_x = y * x;
                    y = Avx2.mm256_blendv_epi8(y, y_times_x, Avx2.mm256_cmpeq_epi8(ONE, Avx2.mm256_and_si256(ONE, n)));

                    n >>= 1;

                    v256 n_is_zero = Avx2.mm256_cmpeq_epi8(ZERO, n);
                    result = Avx2.mm256_blendv_epi8(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                    doneMask = n_is_zero;


                    if (Hint.Unlikely(-1 == Avx2.mm256_movemask_epi8(doneMask)))
                    {
                        return result;
                    }

                    x *= x;
                }
            }
            else
            {
                return new sbyte32(intpow(x.v16_0, n.v16_0), intpow(x.v16_16, n.v16_16));
            }
        }
        

        // <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intpow(byte x, uint n)
        {
            return intpow((uint)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intpow(byte2 x, byte2 n)
        {
            return (byte2)intpow((ushort2)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intpow(byte3 x, byte3 n)
        {
            return (byte3)intpow((ushort3)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intpow(byte4 x, byte4 n)
        {
            return (byte4)intpow((ushort4)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intpow(byte8 x, byte8 n)
        {
            return (byte8)intpow((ushort8)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intpow(byte16 x, byte16 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (byte16)intpow((ushort16)x, n);
            }
            else
            {
                return (byte16)intpow((sbyte16)x, n);
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intpow(byte32 x, byte32 n)
        {
            return (byte32)intpow((sbyte32)x, n);
        }
    }
}