using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProSMan.Telegram.Model
{
	public class Client
	{
		[MaxLength(20)]
		public string Id { get; set; }
		public Guid Secret { get; set; }

		public virtual ICollection<ClientCode> ClientCodes { get; set; }
	}
}
