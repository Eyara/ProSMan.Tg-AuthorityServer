using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProSMan.Telegram.Model;

namespace ProSMan.Telegram.Infrastructure.Map
{
	public class ApplicationClientConfiguration : IEntityTypeConfiguration<ApplicationClient>
	{
		public void Configure(EntityTypeBuilder<ApplicationClient> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasMany(x => x.ApplicationClientCodes)
				.WithOne(x => x.ApplicationClient);

			builder.HasMany(x => x.ClientPermissions)
				.WithOne(x => x.ApplicationClient);
		}
	}
}
