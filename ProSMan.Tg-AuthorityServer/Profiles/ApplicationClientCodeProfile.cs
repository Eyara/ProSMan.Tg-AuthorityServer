using AutoMapper;
using ProSMan.Telegram.DTO.Entity;
using ProSMan.Telegram.Model;

namespace ProSMan.Telegram.AuthorityServer.Profiles
{
	public class ApplicationClientCodeProfile : Profile
	{
		public ApplicationClientCodeProfile()
		{
			CreateMap<ApplicationClientCode, ApplicationClientCodeDTO>()
				.ReverseMap()
				.ForMember(dest => dest.ApplicationClient, opts => opts.Ignore());
		}
	}
}
