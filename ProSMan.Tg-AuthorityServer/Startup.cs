using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProSMan.Telegram.AuthorityServer.Entity;
using ProSMan.Telegram.AuthorityServer.Interceptors;
using ProSMan.Telegram.AuthorityServer.Profiles;
using ProSMan.Telegram.AuthorityServer.Repositories;
using ProSMan.Telegram.Infrastructure;
using System.Linq;
using System.Reflection;

namespace ProSMan.Tg_AuthorityServer
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<TelegramContext>(options =>
			{
				options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"],
						b => b.MigrationsAssembly(typeof(TelegramContext).Assembly.GetName().Name));
			});

			services.AddAutoMapper(typeof(ApplicationClientCodeProfile));
			services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

			services.AddScoped<GrpcAuthInterceptor>();

			services.AddTransient<IClientRepository, ClientRepository>();
			services.AddTransient<IApplicationClientCodeRepository, ApplicationClientCodeRepository>();

			services.AddGrpc(options =>
			{
				options.Interceptors.Add<GrpcAuthInterceptor>();
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			using (var scope = app.ApplicationServices.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<TelegramContext>();
				if (context.Database.GetPendingMigrations().Any())
				{
					context.Database.Migrate();
				}
			}


			mapper.ConfigurationProvider.AssertConfigurationIsValid();

			app.UseRouting();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<TelegramAuthService>();

				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
				});
			});
		}
	}
}
