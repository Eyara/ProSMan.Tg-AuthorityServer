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
		private IClientCodeRepository _clientCodeRepository { get; set; }

		public GetOrInsertHandler(
			IClientCodeRepository clientCodeRepository)
		{
			_clientCodeRepository = clientCodeRepository;
		}

		public async Task<TelegramAuthReply> Handle(GetOrInsertCommand request, CancellationToken cancellationToken)
		{
			var clientId = request.CallContext.RequestHeaders
				.First(h => h.Key.Equals("client-id"))?.Value;

			Guid userId;
			bool isValidUserId = Guid.TryParse(request.Request.UserId, out userId);

			if (!isValidUserId)
			{
				throw new RpcException(new Status(StatusCode.InvalidArgument, "UserId should be guid"));
			}

			var clientCode = await _clientCodeRepository.GetOrInsertAsync(clientId, userId);

			return new TelegramAuthReply
			{
				Code = Convert.ToInt32(clientCode.Code),
				UserId = request.Request.UserId
			};
		}
	}
}