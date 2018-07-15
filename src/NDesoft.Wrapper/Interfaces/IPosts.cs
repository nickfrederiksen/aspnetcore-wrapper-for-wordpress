using NDesoft.Wrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NDesoft.Wrapper.Interfaces
{
public interface IPosts
{
	Task<IEnumerable<PostModel>> GetPosts(int currentPage = 1, int? pageSize = default, CancellationToken cancellationToken = default);
}
}
