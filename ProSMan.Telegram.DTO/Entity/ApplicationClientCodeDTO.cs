using System;

namespace ProSMan.Telegram.DTO.Entity
{
	public class ApplicationClientCodeDTO
	{
		public string Code { get; set; }
		public string UserName { get; set; }

		public Guid ApplicationClientId { get; set; }
	}
}
