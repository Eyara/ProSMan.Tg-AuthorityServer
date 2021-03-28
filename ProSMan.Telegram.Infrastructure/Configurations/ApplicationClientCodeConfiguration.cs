using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProSMan.Telegram.Model;

namespace ProSMan.Telegram.Infrastructure.Map
{
	public class ApplicationClientCodeConfiguration : IEntityTypeConfiguration<ApplicationClientCode>
	{
		public void Configure(EntityTypeBuilder<ApplicationClientCode> builder)
		{
			builder.HasKey(x => new
			{
				x.ApplicationClientId,
				x.UserName
			});

			builder.HasOne(x => x.ApplicationClient)
				.WithMany(client => client.ApplicationClientCodes)
				.HasForeignKey(x => x.ApplicationClientId);
		}
	}
}
