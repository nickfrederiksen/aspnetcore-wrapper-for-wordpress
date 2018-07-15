using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NDesoft.Wrapper.Interfaces.Helpers
{
	public interface IRequestManager
	{
		Task<TResult> Get<TResult>(string url, CancellationToken cancellationToken, object parameters = default);
	}
}
