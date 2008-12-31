// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Pipeline.Interceptors
{
	using System;
	using Configuration;
	using Sinks;

	public class EndpointInterceptor :
		ConsumesInterceptorBase<EndpointInterceptor>
	{
		protected override Type InterfaceType
		{
			get { return typeof (Consumes<>.All); }
		}

		protected virtual UnsubscribeAction Connect<TMessage>(IInterceptorContext context, IEndpoint endpoint) where TMessage : class
		{
			MessageRouterConfigurator routerConfigurator = MessageRouterConfigurator.For(context.Pipeline);

			return routerConfigurator.FindOrCreate<TMessage>().Connect(new EndpointMessageSink<TMessage>(endpoint));
		}
	}
}