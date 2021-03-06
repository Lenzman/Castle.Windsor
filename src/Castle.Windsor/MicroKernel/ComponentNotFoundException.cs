// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.MicroKernel
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	///   Exception threw when a request for a component
	///   cannot be satisfied because the component does not
	///   exist in the container
	/// </summary>
	[Serializable]
	public class ComponentNotFoundException : Exception
	{
		public Type Service { get; private set; }
		public string Name { get; private set; }

		/// <summary>
		///   Initializes a new instance of the
		///   <see cref = "ComponentNotFoundException" />
		///   class.
		/// </summary>
		/// <param name = "name">The name.</param>
		public ComponentNotFoundException(String name) :
			this(name, String.Format("No component for key {0} was found", name))
		{
		}

		/// <summary>
		///   Initializes a new instance of the
		///   <see cref = "ComponentNotFoundException" />
		///   class.
		/// </summary>
		/// <param name = "name">The name.</param>
		/// <param name = "message">Exception message.</param>
		public ComponentNotFoundException(string name, string message)
			: base(message)
		{
			Name = name;
		}

		/// <summary>
		///   Initializes a new instance of the
		///   <see cref = "ComponentNotFoundException" />
		///   class.
		/// </summary>
		/// <param name = "service">The service.</param>
		/// <param name = "message">Exception message.</param>
		public ComponentNotFoundException(Type service, string message)
			: base(message)
		{
			Service = service;
		}

		/// <summary>
		///   Initializes a new instance of the
		///   <see cref = "ComponentNotFoundException" />
		///   class.
		/// </summary>
		/// <param name = "service">The service.</param>
		public ComponentNotFoundException(Type service) :
			this(service, String.Format("No component for supporting the service {0} was found", service.FullName))
		{
		}

#if (!SILVERLIGHT)
		/// <summary>
		///   Initializes a new instance of the
		///   <see cref = "ComponentNotFoundException" />
		///   class.
		/// </summary>
		/// <param name = "info">The object that holds the serialized object data.</param>
		/// <param name = "context">The contextual information about the source or destination.</param>
		public ComponentNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
#endif
	}
}