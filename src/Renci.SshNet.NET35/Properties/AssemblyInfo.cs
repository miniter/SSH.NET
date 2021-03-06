﻿using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System;

[assembly: AssemblyDescription("SSH.NET is a Secure Shell (SSH) library for .NET, optimized for parallelism.")]
[assembly: AssemblyCompany("Renci")]
[assembly: AssemblyProduct("SSH.NET")]
[assembly: AssemblyCopyright("Copyright © Renci 2010-2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion("2016.1.0")]
[assembly: AssemblyFileVersion("2016.1.0")]
[assembly: AssemblyInformationalVersion("2016.1.0-beta1")]
[assembly: CLSCompliant(false)]

[assembly: AssemblyTitle("SSH.NET .NET 3.5")]
[assembly: Guid("a9698831-4993-469b-81f1-aed4e5379252")]
[assembly: InternalsVisibleTo("Renci.SshNet.Tests.NET35, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f9194e1eb66b7e2575aaee115ee1d27bc100920e7150e43992d6f668f9737de8b9c7ae892b62b8a36dd1d57929ff1541665d101dc476d6e02390846efae7e5186eec409710fdb596e3f83740afef0d4443055937649bc5a773175b61c57615dac0f0fd10f52b52fedf76c17474cc567b3f7a79de95dde842509fb39aaf69c6c2")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]


#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif