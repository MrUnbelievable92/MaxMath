using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

[assembly: AssemblyTitle("MaxMath")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MaxMath")]
[assembly: AssemblyCopyright("Copyright © 2020 - 2026 Maximilian Kalimon")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: AssemblyVersion("3.1")]
[assembly: AssemblyFileVersion("3.1")]
[assembly: AssemblyInformationalVersion("3.1 Release")]

// Style
[assembly: SuppressMessage("Style", "IDE1006: Naming Styles", Justification = "Unity.Mathematics API consistency")]
[assembly: SuppressMessage("Style", "IDE0034: Simplify 'default' expression", Justification = "Coding Guidelines")]
[assembly: SuppressMessage("Style", "IDE0066: Use 'switch' expression", Justification = "Coding Guidelines")]
[assembly: SuppressMessage("Style", "IDE0090: Simplify 'new' expression", Justification = "Compatibility with C#8 or less")]
[assembly: SuppressMessage("Style", "IDE0180: Use tuple to swap values", Justification = "Preference to avoid tuples")]

// Compilation
[assembly: InternalsVisibleTo("MaxMath.Tests")]
[assembly: CompilationRelaxationsAttribute(CompilationRelaxations.NoStringInterning)]