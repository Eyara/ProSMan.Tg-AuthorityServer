using System;
using System.Collections.Generic;

namespace ProSMan.Telegram.Model
{
	public class ApplicationClient
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<ClientPermission> ClientPermissions { get; set; }
		public virtual ICollection<ApplicationClientCode> ApplicationClientCodes { get; set; }
	}
}
