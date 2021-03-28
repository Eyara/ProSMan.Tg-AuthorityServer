using System;
using System.ComponentModel.DataAnnotations;

namespace ProSMan.Telegram.Model
{
	public class ClientCode
	{
		[MaxLength(50)]
		public string Code { get; set; }
		public Guid UserId { get; set; }

		[MaxLength(20)]
		public string ClientId { get; set; }

		public virtual Client Client { get; set; }
	}
}
