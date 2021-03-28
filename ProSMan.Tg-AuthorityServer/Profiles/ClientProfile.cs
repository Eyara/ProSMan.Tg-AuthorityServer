using AutoMapper;
using ProSMan.Telegram.DTO.Entity;
using ProSMan.Telegram.Model;

namespace ProSMan.Telegram.AuthorityServer.Profiles
{
	public class ClientProfile : Profile
	{
		public ClientProfile()
		{
			CreateMap<Client, ClientDTO>()
				.ReverseMap()
				.ForMember(dest => dest.ClientPermissions, opts => opts.Ignore());
		}
	}
}
