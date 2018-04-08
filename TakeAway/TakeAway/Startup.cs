using System;
using Amazon.SQS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TakeAway.Libs.Queue;
using TakeAway.Libs.Queue.Impl;
using TakeAway.Libs.Services;
using TakeAway.Libs.Services.Impl;

namespace TakeAway
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IHostingEnvironment env)
		{
			Configuration = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables()
				.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			services.AddOptions();


			services.AddSingleton<IIntoQueue, IntoOueue>();
			services.AddSingleton<IIntoSqs, IntoSqs>();
			services.AddSingleton<IProvisionService, ProvisionService>();
			services.AddSingleton(CreatClient);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseBrowserLink();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		private static IAmazonSQS CreatClient(IServiceProvider arg)
		{
			return new AmazonSQSClient();
		}
	}
}
