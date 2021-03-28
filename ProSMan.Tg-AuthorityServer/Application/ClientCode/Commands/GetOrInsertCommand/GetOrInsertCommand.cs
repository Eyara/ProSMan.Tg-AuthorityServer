using Grpc.Core;
using MediatR;
using TelegramAuth;

namespace ProSMan.Telegram.AuthorityServer.Application.ClientCode.Commands.GetOrInsertCommand
{
	public class GetOrInsertCommand : IRequest<TelegramAuthReply>
	{
		public TelegramAuthRequest Request { get; set; }
		public ServerCallContext CallContext { get; set; }
	}
}
