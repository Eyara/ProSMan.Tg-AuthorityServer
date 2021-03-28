using Grpc.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using ProSMan.Telegram.AuthorityServer.Application.ClientCode.Commands.GetOrInsertCommand;
using System.Threading.Tasks;
using TelegramAuth;

namespace ProSMan.Tg_AuthorityServer
{
	public class TelegramAuthService : TelegramAuthorizer.TelegramAuthorizerBase
	{
		private readonly ILogger<TelegramAuthService> _logger;
		private readonly IMediator _mediator;


		public TelegramAuthService(
			ILogger<TelegramAuthService> logger,
			IMediator mediator
		)
		{
			_logger = logger;
			_mediator = mediator;
		}

		public override async Task<TelegramAuthReply> GetTelegramCode(TelegramAuthRequest request, ServerCallContext context)
		{
			return await _mediator.Send(new GetOrInsertCommand(request, context));
		}
	}
}
