## Known Issues

- `half8/16` `==` and `!=` operators don't conform to the IEEE 754 standard (compliant with Unity.Mathematics... for now... *hint*)
- scalar and vector `half` conversion operators and related functions differ from the slightly incorrect Unity.Mathematics implementation. Specifically, if a `float` or `double` value is converted to a `half`, and if the value to be converted is exactly halfway between two adjacent representable `half` values, Unity's implementation rounds up while this library's implementation truncates, which matches the hardware default rounding direction when converting a `double` to a `float`. The same behavior occurs when converting any integer type to `half` values, because Unity.Mathematics does not implement an optimized integer to `half` conversion operator/function but rather first converts the integer to a `float` implicitly, before casting to `half` 
- `bool` vectors generated from operations on non-`(s)byte` vectors do not generate the most optimal machine code possible, partly due to an LLVM performance regression, partly due to other compiler related difficulties 
- `float8` `min()` and `max()` functions don't handle NaNs the same way Unity.Mathematics does
- LLVM, in many cases, generates very poor code for all vectors with small fields (16 bit and below). This can be fixed by, for instance, `byte16` only having two `ulong`s as fields and exposing the individual `byte`s as properties. This is API breaking, since you cannot take the address of properties, affecting unsafe pointer code; `in`, and `ref` code referencing those fields can be fixed with those fields becoming `ref` properties, while `out` used on those fields may only be used if the vector is already initialized. This will have to be changed for much better performance but this change is reserved for version 3.0

## Fixes

- Fixed managed fallback of `roundto[all integer types]` for `float`, `double` and `quadruple` arguments for values near 0
- Fixed SIMD `div` and `rem` for Unity.Mathematics integer vector types
- Fixed float8 `!=` comparison if compiling for AVX(2)
- Fixed `toboolsafe` for `double4` and all signed integer vector types
- Fixed SSE2 fallback for converting a `quarter` vector to any integer vector
- Fixed software implemented floating point conversion from wider types to narrower types sometimes not rounding to the nearest representable value
- Fixed `int`, `long` and `Int128` `minmag` and `maxmag` always- (`minmag`) or never (`maxmag`) returning the respective `MinValue`, if either argument is equal to `MinValue`

## Additions

- Added scoped registry support
- Added `half16`, `quarter16` and `quarter32` due to more and more `quarter` and `half` function overloads having been implemented that are faster when not casting to a `float` scalar/vector
- Added `bits_select(a, b, c)` for each scalar- and vector integer type. This performs the same operation as `select`, just for each bit, and thus takes in a `c` that is of the same type as `a` and `b`
- Added `cand` for each vector integer type. These reduce vectors to a scalar integer of that type by applying bitwise AND operations between each element
- Added `reverse` to reverse the element order in a vector of any type
- Added a `shuffle` overload for all vector types that does not take a `Unity.Mathematics.ShuffleComponent` as an argument. The second parameter is a vector with the same amount of not necessarily identical elements as the first parameter, holding the indices pointing to elements in the first parameter, determining the order of elements in the returned vector. Example: `shuffle(new int4(9, 99, 999, 9999), new byte4(0, 3, 3, 2); // result: int4(9, 9999, 9999, 999)`
- Added `mulwide` for scalar and vector integer types, which performs full precision multiplication and returns the respective low and high halves of the result as `out` parameters of the same type as the input parameters
- Added `floortoint`, `ceiltoint` and `trunctoint` for all combinations of floating point types (input parameter) and integer types (return type). `trunctoint` wraps default floating point to integer casting, while offering an optional `Promise` parameter when `quarter`, `half` or `quadruple` are involved
- Added `tohalfunsafe`, converting any other scalar or vector type to a `half` scalar or vector type, utilizing faster and smaller code paths via a `Promise` parameter
- Added `tofloatunsafe` and `todoubleunsafe` with `quarter`, `half` and `quadruple` parameter types, utilizing faster and smaller code paths via a `Promise` parameter
- Added the "trivial" `quadruple` overloads `lerp`, `unlerp`, `remap`, `clamp`, `saturate`, `dot`, `frac`, `sign`, `modf`, `length`, `lengthsq`, `distance`, `distancesq`, `smoothstep`, `step`, `avg`, `fastrcp`, `div`, `divrem`, `dad`, `dsub`, `addsaturated`, `subsaturated`, `mulsaturated`, `divsaturated`, `tobytesaturated`, `tosbytesaturated`, `toushortsaturated`, `toshortsaturated`, `touintsaturated`, `tointsaturated`, `toulongsaturated`, `tolongsaturated`, `touint128saturated`, `toint128saturated`, `toquartersaturated`, `tohalfsaturated`, `tofloatsaturated`, `todoublesaturated`, `ceilmultiple`, `truncmultiple`, `roundmultiple`, `floormultiple`, `reversebytes`, `negate`, `maxmag`, `minmag`, `minmaxmag`, `minmax`, `angledelta`, `angledeltasgn`, `angledeltadeg`, `angledeltasgndeg`, `smoothlerp`, `pingpong`, `repeat`, `tobool`, `toboolsafe`, `toquarterunsafe`, `tohalfunsafe`, `toquadruple`, `toquadruplesafe`, `exp2` (integer parameters)
Missing `quadruple` overloads are: `tan`, `tanh`, `atan`, `atan2`, `cos`, `cosh`, `acos`, `sin`, `sinh`, `asin`, `sincos`, `asinh`, `acosh`, `atanh`, `pow`, `exp`, `exp2`, `exp10`, `log`, `log2`, `log10`, `erf`, `erfc`, `gamma`, `hypot`

## Improvements

- Added `(u)long` vector `/`, `%` and `divrem` overloads for `(s)byte`, `(u)short` and `(u)int` divisors, with a latency of ~5 fewer cycles and while using 4 fewer instructions
- Optimized `(u)long` and `(U)Int128` `insqrt` algorithms by replacing a loop based algorithm with straight line code. For 64-bit integers, this implementation is up to two times faster. For 128-bit integers it is up to 14 times faster, yet a little slower if the argument is below ~2^57. These `intsqrt` versions can now be constant-evaluated at compile time. If the global compilation option for `OptimizeFor` is set to `OptimizeFor.Size`, the much smaller loop based algorithm is chosen at compile time.
- Optimized `(s)byte` vector `square` and `myByteVector_0 * myByteVector_0` when compiling for x86 with SSE4 or higher, having derived and implemented a novel 8-bit integer-square algorithm due to the lack of a native SIMD 8 bit multiplication instruction on x86. The implementation of the algorithm has a latency of 5 or 6 cycles instead of the 8 or 9 cycles (CPU specific) associated with generalized 8 bit integer multiplication implemented in software, at the cost of 17 (highly parallel) instructions and 4 constants instead of 6 instructions and 1 constant, and is thus only used if `COMPILATION_OPTIONS.OPTIMIZE_FOR` is set to `OptimizeFor.Performance`. Most notably, this algorithm reduces the latency of `(s)byte` `intpow`, since squaring is part of its loop
- Optimized vector `(s)byte` `intsqrt`, having derived and implemented a novel 8-bit integer-square-root algorithm, reducing the latency by 2 to 5 (unsigned) - or 5 to 8 cycles (signed), respectively, and removing up to 8 instructions, except for non 16/32-element `(s)byte` vectors, where a respecive 9 or 4 instructions (unsigned), or 7 or 2 instructions (signed) were added instead. The previously implemented algorithm is selected for those vectors if the global compilation option for `OptimizeFor` is set to `OptimizeFor.Size` 
- Optimized vector `[]` operator to avoid repeated memory reads and writes when multiple scalar values are sequentially assigned to non-constant indices of a vector
- Optimized `count` for `bool2` and `bool4` inputs when compiling for an architecture that supports SIMD
- Optimized scalar fallback- and vectorized versions of `bits_depositparallel` and `bits_extractparallel` by utilizing a O(log2(n)) algorithm over the previously implemented O(n) algorithm, where n is the bit-width of the respective scalar datatype. Additionally, this algorithm is ~50x to ~100x faster when `mask` is constant
- Reduced latency, code size and constant data for `(U)Int128` `bits_depositparallel` by varying (but substantial) amounts if compiling for X86.BMI2 (= AVX2) by utilizing the 64-bit hardware-supported variants, analogous to how `bits_extractparallel` has already been implemented for `(U)Int128`
- Reduced latency (up to 1 cycle), code size (up to 2 instructions) and constant data (up to 48 bytes) of most vector constructors that combine multiple vectors together, if compiling for ARM or x86.SSE4 or higher 
- Reduced latency vector `(u)long` `%` operator by 9 to 11 cycles and removed 15 instructions if only the remainder is used; using the `/` operator in the same context or using `divrem` results in 8 fewer instructions instead
- Reduced latency of `int8` `/` and `%` operators by 3 cycles and removed at least 2 instructions
- Reduced latency of vector `Divider<(u)int>` initialization by 3 to 4 cycles and removed 3 or 5 instructions
- Reduced latency of vector `double` to `(u)long` conversion by 2 cycles if compiling for AVX2
- Reduced latency of scalar `quarter` to `float` and `double` conversion by 4 cycles and removed 7 instructions. If compiling for BMI2 (i.e. AVX2), 3 further instructions are replaced by 2 instructions with the same latency, saving another 1 byte in code size
- Reduced latency of vector `quarter` to `float` and `double` conversion by up to 3 cycles and removed up to 2 instructions
- Reduced latency of scalar- and vector software implemented narrowing floating point to floating point type conversion by up to 3 cycles and removed up to 4 instructions
- Reduced latency of scalar signed integer `isinrange` by 1 cycle or more when used as a flag (jump/conditional move)
- Reduced latency of `byte` vector division by 4 cycles
- Reduced latency of `sbyte` vector division by 6 cycles
- Reduced latency of scalar- and vector `lcm` functions by 3 cycles
- Reduced latency of scalar- and vector `truncmultiple` functions by 3 cycles
- Reduced latency of scalar- and vector `floormultiple` functions by 3 cycles
- Reduced latency of scalar `quarter`, `half` and `quadruple` `trunc` functions by 1 or 2 cycles
- Reduced latency of `(s)byte` and `(u)short` vector type conversion to `half` vectors by 4 (`(u)short`) and 6 (`(s)byte`) cycles, respectively, at the cost of up to 13 additional instructions
- Reduced latency of scalar- and vector `float` and `double` `pow` functions if the exponent is an integer type. This new overload utilizes the loop based multiply-square algorithm and noticably outperforms Unity's straight line code without compromising on precision
- Reduced latency of scalar- and vector integer `sign` functions as follows: All scalar overloads by 1 cycle; For vectors: If compiling for ARM and when using types with bit width less than or equal to 32 bits by 1 cycle. If compiling for X86 and when using 64 bit integer vectors by 1 cycle. Removed 1 instruction for all vector overloads, Added 1 instruction for all scalar overloads
- `toquarterunsafe` scalar/vector overloads with `half`, `float` and `double` arguments now perform optimizations based on previously unused `Promise` parameters
- Added an optional `Promise` parameter to `[INTEGER TYPE] truncto[INTEGER TYPE]([FLOATING POINT TYPE] x)` overloads with scalar/vector `quarter`, `half` and `quadruple` parameters
- Added an optional `Promise` parameter to `(U)Int128` `intsqrt`
- Added an optional `Promise` parameter to vector `(s)byte` `square`
- Added an optional `Promise` parameter to all `sign` overloads
- Added support for compile-time evaluation of `gcd` and `lcm` in Burst compiled code when compile-time constant arguments are provided
- Dividing a `(U)Int128` by 0 no longer causes a hard crash in x64 Windows DEBUG builds (most importantly the Unity Editor), throwing a `DivideByZeroException` instead. Release builds still crash by design
- Improved `GetHashCode` for `bool8/16/32` to avoid hash collisions entirely
- Improved precision of `pow` when the exponent `y` is constant
- Removed forced inlining for (very) large functions (`comb`, `gamma`, `erf(c)`) while still generating hand optimized SIMD code
- Reduced size of the 128-bit integer division DLL "asm128" containing 972 bytes of native x86-64 code from 11kB down to 3.5kB. A further removal of ~250 bytes (using ordinals instead of function names) has been attempted unsuccessfully
- Added SSE2 fallback for `shuffle(x, y, ShuffleComponent(s))`
- Added SSE2 fallback for `byte8/16` `all_eq`
- Added AVX2 -> AVX fallback for `~`, `^`, `&`, `|` operators as well as `andnot` for vector types wider than 128 bits
- Improved usability of `Divider<T>` by only exposing a single constructor which requires a `T` argument, making use of the compile time `typeof(T)` `==` and `!=` evaluation now supported by Unity.Burst 1.8.26

## Changes

- Made the `static` `BurstArchitecture` class and all its members `public`
- Made the `static` `COMPILATION_OPTIONS` class and all its members `public`
- Made the `static` `VectorAssert` class and all its members `public`
- Made the `static` `UnsafeExtensions` class and all its extension methods `public`
- Made the `struct` `Uninitialized<T>` `public`
- Bumped C-Sharp-Dev-Tools dependency to version 1.0.10
- Bumped Unity.Burst dependency to version 1.8.26
- Bumped Unity Editor minimum version to 2021.3

## Fixed Oversights

- Added missing `long4` `div` and `mod` functions
- Added missing `toquarterunsafe` overloads for `(U)Int128`

## Upcoming

- This release is the last one before the next major release, MaxMath 3.0, which will be wrapping Unity.Mathematics, as mentioned previously in the patchnotes for MaxMath 2.9.0. 
The current release represents some major backlog cleanup that was, for the most part, mandatory for MaxMath 3.0.
MaxMath 3.0 will release rather soon, as it will not include any new features, and despite wrapping the entirety of Unity.Mathematics is a lot of work in and of itself.

To maximize performance, version 3.0 will introduce very minor breaking changes to a selective portion of the public API, including: 
- The `maxmath` class will be renamed to `math`. This change makes switching from `Unity.Mathematics` to `MaxMath` trivial with the help of your IDE's find & replace function. Switching to `MaxMath` 3.0 will most likely require removing any reference to `Unity.Mathematics` in your code.
- Any vectors' fields will become `ref` properties. That invalidates `unsafe` pointer syntax on them. The `ref` and `in` keywords used on them will still work, but using `out` of fields of a vector that is not yet inizialized will not.
- Even though all `bool` vectors will be "replaced" with much more performant `mask[BITS]x[ELEMENTS]` `readonly ref struct`s, this change will not impact user code. They are implicitly convertible to and from `bool[ELEMENTS]` and otherwise contain the entire API `bool[ELEMENTS]` expose. Making them `readonly ref struct`s limits them to only being able to be used on the stack as local variables, which avoids potential user errors. It is advised not to declare temporary variables as `bool[ELEMENTS`, since this negates newly implemented optimizations (but does not introduce additional overhead).
- Most `half` type conversions, whether implicit or explicit, will yield different results - these are correct, in contrast to `Unity.Mathematics` implementations.
- `half` `MinValue` and `MaxValue` will be `half`s, not `float`s. This in itself is not a problem, because of implicit conversion. `MinValueAsHalf` and `MaxValueAsHalf` will become obsolete and will therefore be marked as `System.Obsolete` and removed in a subsequent release.
- `half` comparison operators will perform actual IEEE 754 floating point comparisons instead of integer comparisons, which, for instance, returned `false` when comparing 0 to negative 0 or `true` when comparing `NaN` to `NaN`.

More changes might come up during development. All of them will be documented in the 3.0 patchnotes.