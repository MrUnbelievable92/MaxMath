namespace MaxMath.Intrinsics
{
    public enum TernaryOperation : byte
	{
		/// <summary>       0     </summary>
		OxOO,

		/// <summary>       ~(A | (B | C))     </summary>
		OxO1,

		/// <summary>       C & ~(B | A)     </summary>
		OxO2,

		/// <summary>       ~(B | A)     </summary>
		OxO3,

		/// <summary>       B & ~(A | C)     </summary>
		OxO4,

		/// <summary>       ~(C | A)     </summary>
		OxO5,

		/// <summary>       ~A & (B ^ C)     </summary>
		OxO6,

		/// <summary>       ~(A | (B & C))     </summary>
		OxO7,

		/// <summary>       (~A & B) & C     </summary>
		OxO8,

		/// <summary>       ~(A | (B ^ C))     </summary>
		OxO9,

		/// <summary>       C & ~A     </summary>
		OxOA,

		/// <summary>       ~A & (~B | C)     </summary>
		OxOB,

		/// <summary>       B & ~A     </summary>
		OxOC,

		/// <summary>       ~A & (B | ~C)     </summary>
		OxOD,

		/// <summary>       ~A & (B | C)     </summary>
		OxOE,

		/// <summary>       ~A     </summary>
		OxOF,

		/// <summary>       A & ~(B | C)     </summary>
		Ox1O,

		/// <summary>       ~(C | B)     </summary>
		Ox11,

		/// <summary>       ~B & (A ^ C)     </summary>
		Ox12,

		/// <summary>       ~(B | (A & C))     </summary>
		Ox13,

		/// <summary>       ~C & (A ^ B)     </summary>
		Ox14,

		/// <summary>       ~(C | (B & A))     </summary>
		Ox15,

		/// <summary>       A ? ~(B | C) : (B ^ C)     </summary>
		Ox16,

		/// <summary>       ~(B | C) | (~A & (B ^ C))     </summary>
		Ox17,

		/// <summary>       (A ^ B) & (A ^ C)     </summary>
		Ox18,

		/// <summary>       ~(A & B) & (B ^ ~C)     </summary>
		Ox19,

		/// <summary>       ~(A & B) & (A ^ C)     </summary>
		Ox1A,

		/// <summary>       C ? ~A : ~B     </summary>
		Ox1B,

		/// <summary>       ~(A & C) & (A ^ B)     </summary>
		Ox1C,

		/// <summary>       B ? ~A : ~C     </summary>
		Ox1D,

		/// <summary>       A ^ (B | C)     </summary>
		Ox1E,

		/// <summary>       ~(A & (B | C))     </summary>
		Ox1F,

		/// <summary>       (~B & A) & C     </summary>
		Ox2O,

		/// <summary>       ~(B | (A ^ C))     </summary>
		Ox21,

		/// <summary>       C & ~B     </summary>
		Ox22,

		/// <summary>       ~B & (~A | C)     </summary>
		Ox23,

		/// <summary>       (A ^ B) & (B ^ C)     </summary>
		Ox24,

		/// <summary>       ~(A & B) & (A ^ ~C)     </summary>
		Ox25,

		/// <summary>       ~(A & B) & (B ^ C)     </summary>
		Ox26,

		/// <summary>       C ? ~B : ~A     </summary>
		Ox27,

		/// <summary>       C & (B ^ A)     </summary>
		Ox28,

		/// <summary>       C ? (B ^ A) : ~(B | A)     </summary>
		Ox29,

		/// <summary>       C & ~(B & A)     </summary>
		Ox2A,

		/// <summary>       C ? ~(B & A) : ~(B | A)     </summary>
		Ox2B,

		/// <summary>       (B | C) & (A ^ B)     </summary>
		Ox2C,

		/// <summary>       A ^ (B | ~C)     </summary>
		Ox2D,

		/// <summary>       (B | C) ^ (A & B)     </summary>
		Ox2E,

		/// <summary>       (~B & C) | ~A     </summary>
		Ox2F,

		/// <summary>       A & ~B     </summary>
		Ox3O,

		/// <summary>       ~B & (A | ~C)     </summary>
		Ox31,

		/// <summary>       ~B & (A | C)     </summary>
		Ox32,

		/// <summary>       ~B     </summary>
		Ox33,

		/// <summary>       ~(B & C) & (A ^ B)     </summary>
		Ox34,

		/// <summary>       A ? ~B : ~C     </summary>
		Ox35,

		/// <summary>       B ^ (A | C)     </summary>
		Ox36,

		/// <summary>       ~(B & (A | C))     </summary>
		Ox37,

		/// <summary>       (A | C) & (A ^ B)     </summary>
		Ox38,

		/// <summary>       B ^ (A | ~C)     </summary>
		Ox39,

		/// <summary>       A ? ~B : C     </summary>
		Ox3A,

		/// <summary>       (~A & C) | ~B     </summary>
		Ox3B,

		/// <summary>       B ^ A     </summary>
		Ox3C,

		/// <summary>       (A ^ B) | ~(A | C)     </summary>
		Ox3D,

		/// <summary>       (~A & C) | (A ^ B)     </summary>
		Ox3E,

		/// <summary>       ~(B & A)     </summary>
		Ox3F,

		/// <summary>       (~C & A) & B     </summary>
		Ox4O,

		/// <summary>       ~(C | (B ^ A))     </summary>
		Ox41,

		/// <summary>       (A ^ C) & (B ^ C)     </summary>
		Ox42,

		/// <summary>       ~(A & C) & (A ^ ~B)     </summary>
		Ox43,

		/// <summary>       B & ~C     </summary>
		Ox44,

		/// <summary>       ~C & (~A | B)     </summary>
		Ox45,

		/// <summary>       ~(A & C) & (B ^ C)     </summary>
		Ox46,

		/// <summary>       B ? ~C : ~A     </summary>
		Ox47,

		/// <summary>       B & (A ^ C)     </summary>
		Ox48,

		/// <summary>       B ? (A ^ C) : ~(A | C)     </summary>
		Ox49,

		/// <summary>       (B | C) & (A ^ C)     </summary>
		Ox4A,

		/// <summary>       A ^ (~B | C)     </summary>
		Ox4B,

		/// <summary>       B & ~(A & C)     </summary>
		Ox4C,

		/// <summary>       B ? ~(A & C) : ~(A | C)     </summary>
		Ox4D,

		/// <summary>       C ? ~A : B     </summary>
		Ox4E,

		/// <summary>       (~C & B) | ~A     </summary>
		Ox4F,

		/// <summary>       A & ~C     </summary>
		Ox5O,

		/// <summary>       ~C & (A | ~B)     </summary>
		Ox51,

		/// <summary>       ~(B & C) & (A ^ C)     </summary>
		Ox52,

		/// <summary>       A ? ~C : ~B     </summary>
		Ox53,

		/// <summary>       ~C & (A | B)     </summary>
		Ox54,

		/// <summary>       ~C     </summary>
		Ox55,

		/// <summary>       C ^ (B | A)     </summary>
		Ox56,

		/// <summary>       ~(C & (B | A))     </summary>
		Ox57,

		/// <summary>       (A | B) & (A ^ C)     </summary>
		Ox58,

		/// <summary>       C ^ (A | ~B)     </summary>
		Ox59,

		/// <summary>       C ^ A     </summary>
		Ox5A,

		/// <summary>       (A ^ C) | ~(A | B)     </summary>
		Ox5B,

		/// <summary>       A ? ~C : B     </summary>
		Ox5C,

		/// <summary>       (~A & B) | ~C     </summary>
		Ox5D,

		/// <summary>       (~C & B) | (A ^ C)     </summary>
		Ox5E,

		/// <summary>       ~(C & A)     </summary>
		Ox5F,

		/// <summary>       A & (B ^ C)     </summary>
		Ox6O,

		/// <summary>       A ? (B ^ C) : ~(B | C)     </summary>
		Ox61,

		/// <summary>       (A | C) & (B ^ C)     </summary>
		Ox62,

		/// <summary>       B ^ (~A | C)     </summary>
		Ox63,

		/// <summary>       (A | B) & (B ^ C)     </summary>
		Ox64,

		/// <summary>       C ^ (~A | B)     </summary>
		Ox65,

		/// <summary>       C ^ B     </summary>
		Ox66,

		/// <summary>       (B ^ C) | ~(A | B)     </summary>
		Ox67,

		/// <summary>       A ? (B ^ C) : (B & C)     </summary>
		Ox68,

		/// <summary>       ~(A ^ (B ^ C))     </summary>
		Ox69,

		/// <summary>       C ^ (B & A)     </summary>
		Ox6A,

		/// <summary>       (~A & C) | (~A ^ (B ^ C))     </summary>
		Ox6B,

		/// <summary>       B ^ (A & C)     </summary>
		Ox6C,

		/// <summary>       (~A & B) | (~A ^ (B ^ C))     </summary>
		Ox6D,

		/// <summary>       (~A & B) | (B ^ C)     </summary>
		Ox6E,

		/// <summary>       (B ^ C) | ~A     </summary>
		Ox6F,

		/// <summary>       A & ~(B & C)     </summary>
		Ox7O,

		/// <summary>       ~(B | C) | (A & (B ^ C))     </summary>
		Ox71,

		/// <summary>       C ? ~B : A     </summary>
		Ox72,

		/// <summary>       (~C & A) | ~B     </summary>
		Ox73,

		/// <summary>       B ? ~C : A     </summary>
		Ox74,

		/// <summary>       (~B & A) | ~C     </summary>
		Ox75,

		/// <summary>       (~B & A) | (B ^ C)     </summary>
		Ox76,

		/// <summary>       ~(C & B)     </summary>
		Ox77,

		/// <summary>       A ^ (B & C)     </summary>
		Ox78,

		/// <summary>       (~B & A) | (~B ^ (A ^ C))     </summary>
		Ox79,

		/// <summary>       (~B & A) | (A ^ C)     </summary>
		Ox7A,

		/// <summary>       (A ^ C) | ~B     </summary>
		Ox7B,

		/// <summary>       (~C & A) | (A ^ B)     </summary>
		Ox7C,

		/// <summary>       (A ^ B) | ~C     </summary>
		Ox7D,

		/// <summary>       (A ^ B) | (A ^ C)     </summary>
		Ox7E,

		/// <summary>       ~(A & B) & C)     </summary>
		Ox7F,

		/// <summary>       A & (B & C)     </summary>
		Ox8O,

		/// <summary>       ~(A ^ C) & (A ^ ~B)     </summary>
		Ox81,

		/// <summary>       C & ~(B ^ A)     </summary>
		Ox82,

		/// <summary>       ~(A ^ B) & (~A | C)     </summary>
		Ox83,

		/// <summary>       B & ~(A ^ C)     </summary>
		Ox84,

		/// <summary>       ~(A ^ C) & (B | ~C)     </summary>
		Ox85,

		/// <summary>       (B | C) & (C ^ (A ^ B))     </summary>
		Ox86,

		/// <summary>       ~(A ^ (B & C))     </summary>
		Ox87,

		/// <summary>       C & B     </summary>
		Ox88,

		/// <summary>       ~(B ^ C) & (~A | B)     </summary>
		Ox89,

		/// <summary>       ~(~B & A) & C     </summary>
		Ox8A,

		/// <summary>       B ? C : ~A     </summary>
		Ox8B,

		/// <summary>       ~(~C & A) & B     </summary>
		Ox8C,

		/// <summary>       C ? B : ~A     </summary>
		Ox8D,

		/// <summary>       (B & C) | (~A & (B ^ C))     </summary>
		Ox8E,

		/// <summary>       (B & C) | ~A     </summary>
		Ox8F,

		/// <summary>       A & ~(B ^ C)     </summary>
		Ox9O,

		/// <summary>       ~(B ^ C) & (A | ~B)     </summary>
		Ox91,

		/// <summary>       (A | C) & (C ^ (A ^ B))     </summary>
		Ox92,

		/// <summary>       ~(B ^ (A & C))     </summary>
		Ox93,

		/// <summary>       (A | B) & (B ^ (A ^ C))     </summary>
		Ox94,

		/// <summary>       ~(C ^ (B & A))     </summary>
		Ox95,

		/// <summary>       A ^ (B ^ C)     </summary>
		Ox96,

		/// <summary>       A ? ~(B ^ C) : ~(B & C)     </summary>
		Ox97,

		/// <summary>       ~(B ^ C) & (A | B)     </summary>
		Ox98,

		/// <summary>       ~(C ^ B)     </summary>
		Ox99,

		/// <summary>       (~B & A) ^ C     </summary>
		Ox9A,

		/// <summary>       (~A & C) | (B ^ ~C)     </summary>
		Ox9B,

		/// <summary>       (~C & A) ^ B     </summary>
		Ox9C,

		/// <summary>       (~A & B) | (B ^ ~C)     </summary>
		Ox9D,

		/// <summary>       (B & C) | (C ^ (A ^ B))     </summary>
		Ox9E,

		/// <summary>       ~(A & (B ^ C))     </summary>
		Ox9F,

		/// <summary>       C & A     </summary>
		OxAO,

		/// <summary>       ~(A ^ C) & (A | ~B)     </summary>
		OxA1,

		/// <summary>       ~(~A & B) & C     </summary>
		OxA2,

		/// <summary>       A ? C : ~B     </summary>
		OxA3,

		/// <summary>       ~(A ^ C) & (A | B)     </summary>
		OxA4,

		/// <summary>       ~(C ^ A)     </summary>
		OxA5,

		/// <summary>       (~A & B) ^ C     </summary>
		OxA6,

		/// <summary>       (~B & C) | (A ^ ~C)     </summary>
		OxA7,

		/// <summary>       C & (A | B)     </summary>
		OxA8,

		/// <summary>       ~(C ^ (B | A))     </summary>
		OxA9,

		/// <summary>       C     </summary>
		OxAA,

		/// <summary>       C | ~(B | A)     </summary>
		OxAB,

		/// <summary>       A ? C : B     </summary>
		OxAC,

		/// <summary>       (B & C) | (A ^ ~C)     </summary>
		OxAD,

		/// <summary>       (~A & B) | C     </summary>
		OxAE,

		/// <summary>       C | ~A     </summary>
		OxAF,

		/// <summary>       ~(~C & B) & A     </summary>
		OxBO,

		/// <summary>       C ? A : ~B     </summary>
		OxB1,

		/// <summary>       B ? (A & C) : (A | C)     </summary>
		OxB2,

		/// <summary>       (A & C) | ~B     </summary>
		OxB3,

		/// <summary>       (~C & B) ^ A     </summary>
		OxB4,

		/// <summary>       (~B & A) | (A ^ ~C)     </summary>
		OxB5,

		/// <summary>       (A & C) | (C ^ (A ^ B))     </summary>
		OxB6,

		/// <summary>       ~(B & (A ^ C))     </summary>
		OxB7,

		/// <summary>       B ? C : A     </summary>
		OxB8,

		/// <summary>       (A & C) | (B ^ ~C)     </summary>
		OxB9,

		/// <summary>       (~B & A) | C     </summary>
		OxBA,

		/// <summary>       C | ~B     </summary>
		OxBB,

		/// <summary>       (A & C) | (A ^ B)     </summary>
		OxBC,

		/// <summary>       (A ^ B) | (A ^ ~C)     </summary>
		OxBD,

		/// <summary>       C | (B ^ A)     </summary>
		OxBE,

		/// <summary>       C | ~(B & A)     </summary>
		OxBF,

		/// <summary>       B & A     </summary>
		OxCO,

		/// <summary>       ~(A ^ B) & (A | ~C)     </summary>
		OxC1,

		/// <summary>       ~(A ^ B) & (A | C)     </summary>
		OxC2,

		/// <summary>       ~(B ^ A)     </summary>
		OxC3,

		/// <summary>       ~(~A & C) & B     </summary>
		OxC4,

		/// <summary>       A ? B : ~C     </summary>
		OxC5,

		/// <summary>       (~A & C) ^ B     </summary>
		OxC6,

		/// <summary>       (~C & B) | (A ^ ~B)     </summary>
		OxC7,

		/// <summary>       B & (A | C)     </summary>
		OxC8,

		/// <summary>       ~(B ^ (A | C))     </summary>
		OxC9,

		/// <summary>       A ? B : C     </summary>
		OxCA,

		/// <summary>       (B & C) | (A ^ ~B)     </summary>
		OxCB,

		/// <summary>       B     </summary>
		OxCC,

		/// <summary>       B | ~(A | C)     </summary>
		OxCD,

		/// <summary>       (~A & C) | B     </summary>
		OxCE,

		/// <summary>       B | ~A     </summary>
		OxCF,

		/// <summary>       ~(~B & C) & A     </summary>
		OxDO,

		/// <summary>       ~(B | C) | (A & B)     </summary>
		OxD1,

		/// <summary>       (~B & C) ^ A     </summary>
		OxD2,

		/// <summary>       (~C & A) | (A ^ ~B)     </summary>
		OxD3,

		/// <summary>       (B & ~C) | (A & ~(B ^ C))     </summary>
		OxD4,

		/// <summary>       (A & B) | ~C     </summary>
		OxD5,

		/// <summary>       (A & B) | (B ^ (A ^ C))     </summary>
		OxD6,

		/// <summary>       ~(C & (B ^ A))     </summary>
		OxD7,

		/// <summary>       C ? B : A     </summary>
		OxD8,

		/// <summary>       (A & B) | (B ^ ~C)     </summary>
		OxD9,

		/// <summary>       (A & B) | (A ^ C)     </summary>
		OxDA,

		/// <summary>       (A ^ C) | (A ^ ~B)     </summary>
		OxDB,

		/// <summary>       (~C & A) | B     </summary>
		OxDC,

		/// <summary>       B | ~C     </summary>
		OxDD,

		/// <summary>       B | (A ^ C)     </summary>
		OxDE,

		/// <summary>       B | ~(A & C)     </summary>
		OxDF,

		/// <summary>       A & (B | C)     </summary>
		OxEO,

		/// <summary>       ~(A ^ (B | C))     </summary>
		OxE1,

		/// <summary>       B ? A : C     </summary>
		OxE2,

		/// <summary>       (A & C) | (A ^ ~B)     </summary>
		OxE3,

		/// <summary>       C ? A : B     </summary>
		OxE4,

		/// <summary>       (A & B) | (A ^ ~C)     </summary>
		OxE5,

		/// <summary>       (A & B) | (B ^ C)     </summary>
		OxE6,

		/// <summary>       (B ^ C) | (A ^ ~B)     </summary>
		OxE7,

		/// <summary>       (B & C) | (A & (B ^ C))     </summary>
		OxE8,

		/// <summary>       (A & B) | (B ^ (A ^ ~C))     </summary>
		OxE9,

		/// <summary>       C | (B & A)     </summary>
		OxEA,

		/// <summary>       C | ~(B ^ A)     </summary>
		OxEB,

		/// <summary>       B | (A & C)     </summary>
		OxEC,

		/// <summary>       B | ~(A ^ C)     </summary>
		OxED,

		/// <summary>       C | B     </summary>
		OxEE,

		/// <summary>       B | (~A | C)     </summary>
		OxEF,

		/// <summary>       A     </summary>
		OxFO,

		/// <summary>       A | ~(B | C)     </summary>
		OxF1,

		/// <summary>       (~B & C) | A     </summary>
		OxF2,

		/// <summary>       A | ~B     </summary>
		OxF3,

		/// <summary>       (~C & B) | A     </summary>
		OxF4,

		/// <summary>       A | ~C     </summary>
		OxF5,

		/// <summary>       A | (B ^ C)     </summary>
		OxF6,

		/// <summary>       A | ~(B & C)     </summary>
		OxF7,

		/// <summary>       A | (B & C)     </summary>
		OxF8,

		/// <summary>       A | ~(B ^ C)     </summary>
		OxF9,

		/// <summary>       C | A     </summary>
		OxFA,

		/// <summary>       A | (~B | C)     </summary>
		OxFB,

		/// <summary>       B | A     </summary>
		OxFC,

		/// <summary>       A | (B | ~C)     </summary>
		OxFD,

		/// <summary>       A | (B | C)     </summary>
		OxFE,

		/// <summary>       1     </summary>
		OxFF
	}
}
