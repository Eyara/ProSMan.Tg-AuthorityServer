using Microsoft.EntityFrameworkCore;
using ProSMan.Telegram.Infrastructure.Map;
using ProSMan.Telegram.Model;

namespace ProSMan.Telegram.Infrastructure
{
	public class TelegramContext : DbContext
	{
		public TelegramContext(DbContextOptions<TelegramContext> options) : base(options) { }

		public DbSet<Client> Clients { get; set; }
		public DbSet<ClientCode> ClientCodes { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new ClientConfiguration());
			builder.ApplyConfiguration(new ClientCodeConfiguration());
		}
	}
}
