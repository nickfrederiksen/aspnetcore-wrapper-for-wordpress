using NDesoft.Wrapper.Interfaces.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NDesoft.Wrapper.Helpers
{
	public class RequestManager : IRequestManager
	{
		public static readonly HttpClient httpClient = new HttpClient();
		private readonly string baseUrl;
		private readonly IUrlParameterHelper urlParameterHelper;

		public RequestManager(string baseUrl, IUrlParameterHelper urlParameterHelper)
		{
			this.baseUrl = baseUrl;
			this.urlParameterHelper = urlParameterHelper;
		}

		public virtual async Task<TResult> Get<TResult>(string url, CancellationToken cancellationToken, object parameters = default)
		{
			var fullUrl = this.GetFullUrl(url, parameters);

			var response = await httpClient.GetAsync(fullUrl, cancellationToken).ConfigureAwait(false);
			response.EnsureSuccessStatusCode();

			var bodyContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

			var result = JsonConvert.DeserializeObject<TResult>(bodyContent);
			return result;
		}

		protected virtual string GetFullUrl(string url, object parameters = default)
		{
			var parameterString = this.urlParameterHelper.ConvertToUrlParameters(parameters);
			return $"{baseUrl}{url}{parameterString}";
		}
	}
}
