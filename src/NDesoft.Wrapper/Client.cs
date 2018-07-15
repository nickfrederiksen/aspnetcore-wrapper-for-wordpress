using NDesoft.Wrapper.Interfaces;
using NDesoft.Wrapper.Interfaces.Helpers;
using System;
using System.Net.Http;

namespace NDesoft.Wrapper
{
	public class Client : IClient
	{
		public Client(
			IRequestManager requestManager,
			IPosts posts)
		{
			this.RequestManager = requestManager;
			Posts = posts;
		}

		protected IRequestManager RequestManager { get; }
		public IPosts Posts { get; }
	}
}
