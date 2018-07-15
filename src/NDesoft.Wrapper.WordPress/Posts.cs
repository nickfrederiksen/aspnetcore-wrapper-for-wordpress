using AutoMapper;
using NDesoft.Wrapper.Interfaces;
using NDesoft.Wrapper.Interfaces.Helpers;
using NDesoft.Wrapper.Models;
using NDesoft.Wrapper.WordPress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NDesoft.Wrapper.WordPress
{
	public class Posts : IPosts
	{
		private const string BaseUrl = "/wp/v2/posts";
		private readonly IRequestManager requestManager;

		public Posts(IRequestManager requestManager)
		{
			this.requestManager = requestManager;
		}

		public async Task<IEnumerable<PostModel>> GetPosts(int currentPage = 1, int? pageSize = null, CancellationToken cancellationToken = default)
		{
			var parameters = new
			{
				page = currentPage,
				per_page = pageSize
			};

			var response = await requestManager.Get<IEnumerable<Post>>(BaseUrl, cancellationToken, parameters).ConfigureAwait(false);

			return Mapper.Map<IEnumerable<PostModel>>(response);
		}
	}
}
