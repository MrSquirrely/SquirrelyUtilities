﻿using System;
using System.Reflection;
using System.Runtime.Loader;
namespace SquirrelyUtilities {
    internal class PluginLoader : AssemblyLoadContext {

        private readonly AssemblyDependencyResolver _resolver;

        public PluginLoader(string pluginPath) => _resolver = new AssemblyDependencyResolver(pluginPath);

        protected override Assembly Load(AssemblyName assemblyName) {
            string assemblyPath = _resolver.ResolveAssemblyToPath(assemblyName);
            return assemblyPath != null ? LoadFromAssemblyPath(assemblyPath) : null;
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName) {
            string libraryPath = _resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            return libraryPath != null ? LoadUnmanagedDllFromPath(libraryPath) : IntPtr.Zero;
        }

    }
}
