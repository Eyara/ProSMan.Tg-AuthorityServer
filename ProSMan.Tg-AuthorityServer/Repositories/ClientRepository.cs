using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProSMan.Telegram.AuthorityServer.Entity;
using ProSMan.Telegram.DTO.Entity;
using ProSMan.Telegram.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace ProSMan.Telegram.AuthorityServer.Repositories
{
	public class ClientRepository: IClientRepository
	{
		private readonly TelegramContext _context;
		private readonly IMapper _mapper;

		public ClientRepository(
			TelegramContext context,
			IMapper mapper
		)
		{
			_context = context;
			_mapper = mapper;
		}

		public Task<ClientDTO> GetByIdAsync(string id)
		{
			return _context.Clients
				.ProjectTo<ClientDTO>(_mapper.ConfigurationProvider)
				.FirstOrDefaultAsync(c => c.Id == id, new CancellationToken());
		}
	}
}
