using System;
using System.Reflection;
using System.Collections.Generic;

namespace ExceptionReporting
{
	/// <summary>
	/// Resolve a view from an assembly (limited to ExceptionReportView and InternalExceptionView)
	/// This flexibility is required in order to load either a WPF or WinForms version of the view class
	/// </summary>
	public class ViewResolver
	{
		private readonly Assembly _assembly;

		///<summary>
		/// Initialise the ViewResolver with an assembly to search
		///</summary>
		///<param name="assembly">the Assembly which contains the desired view</param>
		public ViewResolver(Assembly assembly)
		{
			_assembly = assembly;
		}

		/// <summary>
		/// Resolve an interface to a concrete view class, limited to 2 particular expected 'View' classes in ExceptionReporter
		/// </summary>
		/// <typeparam name="T">The interface type (currenty just IExceptionReportView or IInternalExceptionView)</typeparam>
		/// <returns>An instance of a type that implements the interface (T) in the given assembly (see constructor)</returns>
		public Type Resolve<T>() where T : class
		{
			var viewType = typeof(T);

		    List<AssemblyName> assemblies = new List<AssemblyName>(_assembly.GetReferencedAssemblies());
            assemblies.Add(new AssemblyName (_assembly.FullName));

		    List<Type> matchingTypes = new List<Type>();
            foreach (AssemblyName assemblyName in assemblies)
            {
                if (assemblyName.Name.Contains("ExceptionReporter"))
                {
                    foreach (Type type in Assembly.Load(assemblyName.Name).GetExportedTypes())
                        if (!type.IsInterface && viewType.IsAssignableFrom(type))
                            matchingTypes.Add(type);
                }
            }
			if (matchingTypes.Count == 1)
				return matchingTypes[0];
			
			throw new ApplicationException(string.Format("Unable to resolve single instance of '{0}'", viewType));
		}
	}
}