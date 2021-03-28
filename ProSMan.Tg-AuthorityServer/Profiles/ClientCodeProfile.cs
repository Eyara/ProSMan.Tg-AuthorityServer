using AutoMapper;
using ProSMan.Telegram.DTO.Entity;
using ProSMan.Telegram.Model;

namespace ProSMan.Telegram.AuthorityServer.Profiles
{
	public class ClientCodeProfile : Profile
	{
		public ClientCodeProfile()
		{
			CreateMap<ClientCode, ClientCodeDTO>();
		}
	}
}
