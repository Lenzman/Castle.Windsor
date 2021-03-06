﻿// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
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

namespace Castle.Windsor.Diagnostics
{
	using System;
	using System.Linq;

	using Castle.MicroKernel;

	public class TrackedComponentsDiagnostic : ITrackedComponentsDiagnostic
#if !SILVERLIGHT
	                                           , IDisposable
	{
		private readonly ITrackedComponentsPerformanceCounter counter;

		public TrackedComponentsDiagnostic(ITrackedComponentsPerformanceCounter counter)
		{
			this.counter = counter;
		}
#else
		{
#endif

		public ILookup<IHandler, object> Inspect()
		{
			var @event = TrackedInstancesRequested;
			if (@event == null)
			{
				return null;
			}
			var args = new TrackedInstancesEventArgs();
			@event(this, args);

			return args.Items.ToLookup(k => k.Handler, b => b.Instance);
		}

#if !SILVERLIGHT
		public void DecrementTrackedInstancesCount()
		{
			counter.DecrementTrackedInstancesCount();
		}

		public void IncrementTrackedInstancesCount()
		{
			counter.IncrementTrackedInstancesCount();
		}
#endif

		public event EventHandler<TrackedInstancesEventArgs> TrackedInstancesRequested;

#if !SILVERLIGHT
		public void Dispose()
		{
			var disposableCounter = counter as IDisposable;
			if (disposableCounter != null)
			{
				disposableCounter.Dispose();
			}
		}
#endif
	}
}