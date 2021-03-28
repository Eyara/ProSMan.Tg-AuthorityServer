using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProSMan.Telegram.Model;

namespace ProSMan.Telegram.Infrastructure.Map
{
	public class ClientPermissionConfiguration : IEntityTypeConfiguration<ClientPermission>
	{
		public void Configure(EntityTypeBuilder<ClientPermission> builder)
		{
			builder.HasKey(x => new
			{
				x.ApplicationClientId,
				x.ClientId
			});

			builder.HasOne(x => x.ApplicationClient)
				.WithMany(client => client.ClientPermissions)
				.HasForeignKey(x => x.ApplicationClientId);

			builder.HasOne(x => x.Client)
				.WithMany(client => client.ClientPermissions)
				.HasForeignKey(x => x.ClientId);
		}
	}
}
