<html>
  <head>
    <title></title>
    <meta content="">
    <style></style>
  </head>
  <body>
  <!--
  <a href="bitcoin:bc1qa52kjh0nnpjrggq9gft8knjpvhs8v2fnkewkdc?label=Donation%20Test&amp;amount=0.00001">bc1qa52kjh0nnpjrggq9gft8knjpvhs8v2fnkewkdc</a>
  -->
  <a href="bitcoin:bc1qa52kjh0nnpjrggq9gft8knjpvhs8v2fnkewkdc">bc1qa52kjh0nnpjrggq9gft8knjpvhs8v2fnkewkdc</a>
  </body>
</html>

# MaxMath
MaxMath is the most powerful and extensive SIMD math library available to Unity developers. Built on top of Unity.Mathematics and utilizing Unity.Burst, it introduces the following key features:

- **Support For All Primitive Data Types:** MaxMath adds support for `(s)byte`, `(u)short`, and `(u)long` vectors and matrices. These data types come with optimized overloads for all functions in Unity.Mathematics. Additionally, specialized `Random8/16/32/64/128` types are available for efficient pseudo-random number generation.
- **Wider Vectors With Full Hardware Support:** Vector types are expanded to 256 bits, enabling types like `byte32`, `short16`, `int8`, and `float8`. This allows you to leverage the full potential of SIMD computation.
- **Many Additional Functions:** MaxMath includes a massive library of mathematical functions not found in Unity.Mathematics, with about five times as many highly optimized functions at your disposal. Each function is fully documented with XML annotations. A full list is provided further below.
- **Exotic Data Types:** MaxMath introduces data types such as `(U)Int128` (scalar only), 128-bit `quadruple` precision floats (scalar only), and 8-bit `quarter` precision floats (in both scalar and vector forms). Additionally, `Divider<T>` offers highly optimized integer division operations, extending and outperforming specialized libraries like libdivide.
- **Written Entirely With Hardware Intrinsics:** MaxMath guarantees optimal performance by utilizing specialized CPU instructions for both ARM and x86 ISAs, while abstracting these complexities away from the user entirely.
- **Extends The Burst Compiler:** MaxMath integrates deeply with Unity.Burst and LLVM, leveraging `Unity.Burst.CompilerServices.Constant.IsConstantExpression<T>()` to include code typically only found in optimizing compilers. This functionality allows MaxMath to choose more optimized code paths at compile time, and users can influence this behavior via the optional `Promise` enum parameter available in many functions.
- **Easy To Use:** MaxMath is just as easy to use as Unity.Mathematics. It supports features like `implicit` and `explicit` type conversions, making it seamless for you to use if you expect typical C# behavior of primitive types.
- **Extensive Test Coverage:** MaxMath is backed by 250,000 lines of unit tests for its 400,000 lines of code, as well as `DEBUG` only runtime checks where appropriate, together ensuring it is _production ready_.


# How To Use This Library

![alt text](https://i.imgur.com/0Bpr1Mo.png)

## New Types

### Integer
<details><summary>(S)Byte</summary>
  
![alt text](https://i.imgur.com/LwxZifi.png)

</details>

<details><summary>(U)Short</summary>
  
![alt text](https://i.imgur.com/yE5o3RH.png)

</details>

<details><summary>(U)Int</summary>
  
![alt text](https://i.imgur.com/XNzK5iS.png)

</details>

<details><summary>(U)Long</summary>
  
![alt text](https://i.imgur.com/D0WUfrU.png)

</details>

### Floating Point

<details><summary>Float</summary>
  
![alt text](https://i.imgur.com/4lSuEfU.png)

</details>

<details><summary>Half</summary>
  
![alt text](https://i.imgur.com/Vk0jQCh.png)

</details>

<details><summary>Quarter (8-bit 1.3.4.-3 IEEE 754 floating point)</summary>
  
![alt text](https://i.imgur.com/yRbyPGK.png)

</details>

### Random Number Generators

<details><summary>XOR-Shift</summary>
  
![alt text](https://i.imgur.com/2tYbxk0.png)

</details>

## New Functions


<details><summary>Miscellaneous</summary>
  
![alt text](https://i.imgur.com/AhLKvAb.png)

</details>


<details><summary>Arithmetic</summary>

![alt text](https://i.imgur.com/YU2dSj5.png)

![alt text](https://i.imgur.com/r1f44Va.png)

![alt text](https://i.imgur.com/JUbYL6J.png)

![alt text](https://i.imgur.com/KDvHC11.png)

![alt text](https://i.imgur.com/WoDaxIU.png)

![alt text](https://i.imgur.com/3XJYuqw.png)

</details>


<details><summary>Bitwise Operations</summary>

![alt text](https://i.imgur.com/FDnjd0F.png)

![alt text](https://i.imgur.com/z0MtnUs.png)

![alt text](https://i.imgur.com/knaC0q4.png)

![alt text](https://i.imgur.com/QwP5AWu.png)

</details>


<details><summary>Vector Operations</summary>

![alt text](https://i.imgur.com/uG3k5Re.png)

![alt text](https://i.imgur.com/tGIhgcr.png)

![alt text](https://i.imgur.com/UeUvlii.png)

![alt text](https://i.imgur.com/pGU76Lu.png)

</details>


<details><summary>Interpolation and Geometry</summary>

![alt text](https://i.imgur.com/S6zfZ5O.png)

![alt text](https://i.imgur.com/6txRQQe.png)

![alt text](https://i.imgur.com/N0pgppX.png)

</details>


<details><summary>Type Conversion</summary>

![alt text](https://i.imgur.com/q1uEpb2.png)

</details>


# What Kind Of Performance To Expect

![alt text](https://i.imgur.com/Bi79n4Q.jpg)

### Highlights

- Division and modulo operations of (s)byte and (u)short vectors _by_ _other_ _vectors_ are implemented as either a long division algorithm ((s)byte32, (s)byte16 and (s)byte8 if not compiling for Avx2) or reciprocal multiplication after converting the vectors to float vectors (up to (s)byte8, all (u)short vectors) - it is very fast and, of course, 100% accurate!

- This library uses Wojciech Mula's SIMD population count algorithm. You can count the amount of set bits of a contiguous block of memory very efficiently using either the (s)byte32 (Avx2) or (s)byte16 (Ssse3) type

### Notes

- It is recommended, just like with Unity.Mathematics, to use vector types that use up an entire SIMD register (128 and 256 bits, respectively). LLVM has a very hard time optimizing code which does not follow this recommendation

# How To Install This Library

Disclaimer: I firmly believe in open source - being able to copy/modify/understand other people's code is great :)
I also want people to be able to step through code with a debugger.
For these reasons I usually don't distribute DLLs.

- Download the package and unzip it into your "LocalPackages" folder, which is located at the root folder of your Unity project (where your "Assets" folder resides at).
- Start up Unity. Usually Unity detects new packages and will generate .meta files for you.
- In case that doesn't work, open up the package manager from within Unity and click on the '+' symbol at the upper left corner of the window, further clicking on "Add package from disk..." - "Add package from git URL" should also work.

![alt text](https://i.imgur.com/QcqF96e.png)

- Locate the library's "package.json" file
- DONE! 
