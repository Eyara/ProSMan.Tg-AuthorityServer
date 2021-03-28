using Grpc.Core;
using MediatR;
using ProSMan.Telegram.AuthorityServer.Entity;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TelegramAuth;

namespace ProSMan.Telegram.AuthorityServer.Application.ClientCode.Commands.GetOrInsertCommand
{
	public class GetOrInsertHandler : IRequestHandler<GetOrInsertCommand, TelegramAuthReply>
	{
		private IApplicationClientCodeRepository _clientCodeRepository { get; set; }

		public GetOrInsertHandler(
			IApplicationClientCodeRepository clientCodeRepository)
		{
			_clientCodeRepository = clientCodeRepository;
		}

		public async Task<TelegramAuthReply> Handle(GetOrInsertCommand request, CancellationToken cancellationToken)
		{
			var clientId = request.CallContext.RequestHeaders
				.First(h => h.Key.Equals("client-id"))?.Value;

			Guid applicationClientId;
			bool isValidUserId = Guid.TryParse(request.Request.ApplicationClientId, out applicationClientId);

			if (!isValidUserId)
			{
				throw new RpcException(new Status(StatusCode.InvalidArgument, "Application client id should be guid"));
			}

			var clientCode = await _clientCodeRepository.GetOrInsertAsync(applicationClientId, request.Request.UserName);

			return new TelegramAuthReply
			{
				Code = clientCode.Code,
				UserName = clientCode.UserName
			};
		}
	}
}