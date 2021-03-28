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
	public class ApplicationClientCodeRepository: IApplicationClientCodeRepository
	{
		private readonly TelegramContext _context;
		private readonly IMapper _mapper;
		private readonly Random _random;

		public ApplicationClientCodeRepository(
			TelegramContext context,
			IMapper mapper
		)
		{
			_context = context;
			_mapper = mapper;
			_random = new Random();
		}

		public async Task<ApplicationClientCodeDTO> GetOrInsertAsync(Guid applicationClientId, string userName)
		{

			var existingCode = await _context.ApplicationClientCodes
				.FirstOrDefaultAsync(c => c.ApplicationClientId == applicationClientId && c.UserName == userName);

			if (existingCode == null)
			{
				// TODO: add settings for code length
				var generatedCode = _random.Next(100000, 999999);
				var newCode = new ApplicationClientCode
				{
					ApplicationClientId = applicationClientId,
					UserName = userName,
					Code = generatedCode.ToString()
				};

				_context.ApplicationClientCodes.Add(newCode);
				await _context.SaveChangesAsync();

				return _mapper.Map<ApplicationClientCodeDTO>(newCode);
			}

			return _mapper.Map<ApplicationClientCodeDTO>(existingCode);
		}
	}
}
