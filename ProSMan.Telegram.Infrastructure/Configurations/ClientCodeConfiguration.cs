using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProSMan.Telegram.Model;

namespace ProSMan.Telegram.Infrastructure.Map
{
	public class ClientCodeConfiguration : IEntityTypeConfiguration<ClientCode>
	{
		public void Configure(EntityTypeBuilder<ClientCode> builder)
		{
			builder.HasKey(x => new
			{
				x.ClientId,
				x.UserId
			});

			builder.HasOne(x => x.Client)
				.WithMany(client => client.ClientCodes)
				.HasForeignKey(x => x.ClientId);
		}
	}
}
