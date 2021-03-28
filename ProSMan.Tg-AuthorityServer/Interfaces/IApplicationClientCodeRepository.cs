using ProSMan.Telegram.DTO.Entity;
using System;
using System.Threading.Tasks;

namespace ProSMan.Telegram.AuthorityServer.Entity
{
	public interface IApplicationClientCodeRepository
	{
		Task<ApplicationClientCodeDTO> GetOrInsertAsync(Guid applicationClientId, string userName);
	}
}
