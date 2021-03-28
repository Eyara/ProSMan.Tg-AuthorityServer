using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProSMan.Telegram.AuthorityServer.Entity;
using ProSMan.Telegram.DTO.Entity;
using ProSMan.Telegram.Infrastructure;
using ProSMan.Telegram.Model;
using System;
using System.Threading.Tasks;

namespace ProSMan.Telegram.AuthorityServer.Repositories
{
	public class ClientCodeRepository: IClientCodeRepository
	{
		private readonly TelegramContext _context;
		private readonly IMapper _mapper;
		private readonly Random _random;

		public ClientCodeRepository(
			TelegramContext context,
			IMapper mapper
		)
		{
			_context = context;
			_mapper = mapper;
			_random = new Random();
		}

		public async Task<ClientCodeDTO> GetOrInsertAsync(string clientId, Guid userId)
		{

			var existingClientCode = await _context.ClientCodes
				.FirstOrDefaultAsync(c => c.ClientId == clientId && c.UserId == userId);

			if (existingClientCode == null)
			{
				var generatedCode = _random.Next(100000, 999999);
				var newClientCode = new ClientCode
				{
					ClientId = clientId,
					UserId = userId,
					Code = generatedCode.ToString()
				};

				_context.ClientCodes.Add(newClientCode);
				await _context.SaveChangesAsync();

				return _mapper.Map<ClientCodeDTO>(newClientCode);
			}

			return _mapper.Map<ClientCodeDTO>(existingClientCode);
		}
	}
}
