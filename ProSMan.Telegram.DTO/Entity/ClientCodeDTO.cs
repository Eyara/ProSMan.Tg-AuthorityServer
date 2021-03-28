using System;

namespace ProSMan.Telegram.DTO.Entity
{
	public class ClientCodeDTO
	{
		public string Code { get; set; }
		public Guid UserId { get; set; }

		public string ClientId { get; set; }
	}
}
