using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProSMan.Telegram.Model;

namespace ProSMan.Telegram.Infrastructure.Map
{
	public class ClientConfiguration : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasMany(x => x.ClientCodes)
				.WithOne(x => x.Client);
		}
	}
}
