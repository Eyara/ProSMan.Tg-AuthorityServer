using Microsoft.EntityFrameworkCore;
using ProSMan.Telegram.Infrastructure.Map;
using ProSMan.Telegram.Model;

namespace ProSMan.Telegram.Infrastructure
{
	public class TelegramContext : DbContext
	{
		public TelegramContext(DbContextOptions<TelegramContext> options) : base(options) { }

		public DbSet<Client> Clients { get; set; }
		public DbSet<ClientPermission> ClientPermissions { get; set; }
		public DbSet<ApplicationClient> ApplicationClients { get; set; }
		public DbSet<ApplicationClientCode> ApplicationClientCodes { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new ClientConfiguration());
			builder.ApplyConfiguration(new ClientPermissionConfiguration());
			builder.ApplyConfiguration(new ApplicationClientConfiguration());
			builder.ApplyConfiguration(new ApplicationClientCodeConfiguration());
		}
	}
}
