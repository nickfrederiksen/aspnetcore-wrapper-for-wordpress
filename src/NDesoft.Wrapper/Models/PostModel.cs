using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDesoft.Wrapper.Models
{
public class PostModel
{
	public string Id { get; set; }

	public DateTime Date { get; set; }

	public DateTime Modified { get; set; }

	public string Slug { get; set; }

	public string Title { get; set; }

	public string Content { get; set; }

	public string Excerpt { get; set; }

	public string AuthorId { get; set; }

	public string FeaturedMediaId { get; set; }

	public bool IsSticky { get; set; }

	public IEnumerable<string> CategoryIds { get; set; }

	public IEnumerable<string> TagIds { get; set; }
}
}
