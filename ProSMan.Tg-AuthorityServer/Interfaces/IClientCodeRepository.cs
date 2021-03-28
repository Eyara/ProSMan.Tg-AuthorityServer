using ProSMan.Telegram.DTO.Entity;
using System;
using System.Threading.Tasks;

namespace ProSMan.Telegram.AuthorityServer.Entity
{
	public interface IClientCodeRepository
	{
		Task<ClientCodeDTO> GetOrInsertAsync(string clientId, Guid userId);
	}
}
