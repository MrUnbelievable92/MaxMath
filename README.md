# MaxMath
A C# SIMD math library for use with Unity only, supplementary to Unity.Mathematics using Unity.Burst. 

It adds (s)byte, (u)short and (u)long SIMD vectors and matrices to the ones already provided by Unity.Mathematics. 
Almost all functions present in Unity.Mathematics have been transcribed to work with the new vector and matrix types in addition to many useful functions having been added.

Note: 
- C Sharp Dev Tools (a repository of mine) is required. Unit tests for this library are included in this repository.
- There are currently no fallback procedures regarding support for platforms without AVX2 apart from the managed C# software implementations. Thus, for the most part, AVX2 is required if used with Burst. (Work in progress)


# How To Use This Library

![alt text](https://i.imgur.com/0Bpr1Mo.png)

## New Functions (fully documented)

### Misc
![alt text](https://i.imgur.com/AhLKvAb.png)

### Arithmetic

![alt text](https://i.imgur.com/cmeTWQS.png)

![alt text](https://i.imgur.com/r1f44Va.png)

![alt text](https://i.imgur.com/JUbYL6J.png)

![alt text](https://i.imgur.com/eC06KYl.png)

![alt text](https://i.imgur.com/WoDaxIU.png)

![alt text](https://i.imgur.com/3XJYuqw.png)

### Bitwise

![alt text](https://i.imgur.com/FDnjd0F.png)

![alt text](https://i.imgur.com/z0MtnUs.png)

![alt text](https://i.imgur.com/knaC0q4.png)

![alt text](https://i.imgur.com/QwP5AWu.png)

### Vector Operations

![alt text](https://i.imgur.com/Hu1eBqY.png)

![alt text](https://i.imgur.com/YgMr5AA.png)

![alt text](https://i.imgur.com/pGU76Lu.png)

### Interpolation and Geometry

![alt text](https://i.imgur.com/S6zfZ5O.png)

![alt text](https://i.imgur.com/6txRQQe.png)

![alt text](https://i.imgur.com/N0pgppX.png)

### Type Conversion

![alt text](https://i.imgur.com/q1uEpb2.png)

# What Kind Of Performance To Expect

![alt text](https://i.imgur.com/Bi79n4Q.jpg)

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
