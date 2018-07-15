using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NDesoft.Web.Models;
using NDesoft.Wrapper.Interfaces;

namespace NDesoft.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IClient client;

		public HomeController(IClient client)
		{
			this.client = client;
		}

		public async Task<IActionResult> Index(CancellationToken cancellationToken)
		{
			var posts = await this.client.Posts.GetPosts(1, 5, cancellationToken).ConfigureAwait(false);
			return View(posts);
		}
	}
}
