using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDesoft.Wrapper.Interfaces.Helpers
{
	public interface IUrlParameterHelper
	{
		string ConvertToUrlParameters(object parameters);
	}
}
