using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NDesoft.Wrapper;
using NDesoft.Wrapper.Helpers;
using NDesoft.Wrapper.Interfaces;
using NDesoft.Wrapper.Interfaces.Helpers;
using NDesoft.Wrapper.WordPress;
using NDesoft.Wrapper.WordPress.AutomapperSetup;

namespace NDesoft.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			this.SetupAutoMapper(services);
			this.SetupWrappers(services);

			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
		private void SetupAutoMapper(IServiceCollection services)
		{
			services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile(typeof(PostProfile));
			});
		}

		private void SetupWrappers(IServiceCollection services)
		{
			services.AddTransient<IUrlParameterHelper, UrlParameterHelper>();
			var baseUrl = Configuration["WrapperConfig:BaseUrl"];
			services.AddTransient<IRequestManager, RequestManager>((provider) => new RequestManager(baseUrl, provider.GetRequiredService<IUrlParameterHelper>()));
			services.AddTransient<IClient, Client>();

			// Service specifics:
			services.AddTransient<IPosts, Posts>();
		}
	}
}
