# MaxMath
A C# SIMD math library for use with Unity only, supplementary to Unity.Mathematics using Unity.Burst. 

It adds (s)byte, (u)short and (u)long SIMD vectors and matrices to the ones already provided by Unity.Mathematics. 
Almost all functions present in Unity.Mathematics have been transcribed to work with the new vector and matrix types in addition to many useful functions having been added.

Note: 
- C Sharp Dev Tools (a repository of mine) is required. Unit tests for this library are included in this repository.
- There are currently no fallback procedures regarding support for platforms without AVX2 apart from the managed C# software implementations. Thus, for the most part, AVX2 is required if used with Burst. (Work in progress) 

UPDATE: Fallback procedures from 'AVX2' -> 'SSE4' -> 'SSE2' -> 'platform independent' with major performance optimizations have been completed. There are currently bugs related to the Burst compiler, which prevent me from releasing the updated library with the promise that these updates will work. I will upload the updates as 'version 2.0.0' as soon as Burst 1.5 is out of preview.


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

![alt text](https://i.imgur.com/cmeTWQS.png)

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
