using Grpc.Core;
using Grpc.Core.Interceptors;
using ProSMan.Telegram.AuthorityServer.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProSMan.Telegram.AuthorityServer.Interceptors
{
	public class GrpcAuthInterceptor : Interceptor
	{
		private readonly IClientRepository _clientRepository;

		public GrpcAuthInterceptor(
		IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}

		public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
			TRequest request,
			ServerCallContext context,
			UnaryServerMethod<TRequest, TResponse> continuation)
		{
			var clientId = context.RequestHeaders
					.FirstOrDefault(x => x.Key.Equals("client-id"))?.Value;

			var clientSecret = context.RequestHeaders
				.FirstOrDefault(x => x.Key.Equals("client-secret"))?.Value;

			if (clientId == null)
			{
				throw new RpcException(new Status(StatusCode.Unauthenticated, "Client id is empty"));
			}

			var client = await _clientRepository.GetByIdAsync(clientId);

			if (client == null)
			{
				throw new RpcException(new Status(StatusCode.Unauthenticated, "Client id does not exist"));
			}

			if (!clientSecret.Equals(client.Secret.ToString()))
			{
				throw new RpcException(new Status(StatusCode.Unauthenticated, "Client secret is invalid"));
			}

			// TODO add permission check

			return await continuation(request, context);
		}
	}

}
