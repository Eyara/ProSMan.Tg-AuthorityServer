using System;
using System.ComponentModel.DataAnnotations;

namespace ProSMan.Telegram.Model
{
	public class ApplicationClientCode
	{
		[MaxLength(25)]
		public string Code { get; set; }
		[MaxLength(50)]
		public string UserName { get; set; }

		[MaxLength(20)]
		public Guid ApplicationClientId { get; set; }

		public virtual ApplicationClient ApplicationClient { get; set; }
	}
}
