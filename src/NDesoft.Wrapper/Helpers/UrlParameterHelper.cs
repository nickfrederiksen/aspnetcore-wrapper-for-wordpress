using NDesoft.Wrapper.Interfaces.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NDesoft.Wrapper.Helpers
{
	public class UrlParameterHelper : IUrlParameterHelper
	{
		public string ConvertToUrlParameters(object parameters)
		{
			if (parameters == default)
			{
				return string.Empty;
			}

			var type = parameters.GetType();
			var properties = type.GetProperties();
			var urlBuilder = new StringBuilder();

			if (properties.Any())
			{
				urlBuilder.Append("?");
				string joinedParams = GetParameterString(parameters, properties);
				urlBuilder.Append(joinedParams);
			}

			return urlBuilder.ToString();
		}

		private static string GetParameterString(object parameters, PropertyInfo[] properties)
		{
			var urlParams = new List<string>(properties.Count());
			foreach (var property in properties)
			{
				var value = property.GetValue(parameters);
				if (value != null)
				{
					var stringValue = value.ToString();
					if (string.IsNullOrWhiteSpace(stringValue) == false)
					{
						var encodedValue = HttpUtility.UrlEncode(stringValue);
						var urlParam = $"{property.Name}={encodedValue}";
						urlParams.Add(urlParam);
					}
				}
			}

			var parameterString = string.Join("&", urlParams.ToArray());
			return parameterString;
		}
	}
}
