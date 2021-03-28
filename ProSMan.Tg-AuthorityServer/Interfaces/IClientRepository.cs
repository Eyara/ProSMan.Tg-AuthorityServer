using ProSMan.Telegram.DTO.Entity;
using System.Threading.Tasks;

namespace ProSMan.Telegram.AuthorityServer.Entity
{
	public interface IClientRepository
	{
		Task<ClientDTO> GetByIdAsync(string id);
	}
}
