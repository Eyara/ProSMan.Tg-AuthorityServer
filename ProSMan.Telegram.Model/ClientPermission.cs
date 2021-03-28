using ProSMan.Telegram.Common;
using System;

namespace ProSMan.Telegram.Model
{
	public class ClientPermission
	{
		public string ClientId { get; set; }
		public Guid ApplicationClientId { get; set; }
		public PermissionEnum Permission { get; set; }

		public virtual Client Client { get; set; }
		public virtual ApplicationClient ApplicationClient { get; set; }
	}
}
