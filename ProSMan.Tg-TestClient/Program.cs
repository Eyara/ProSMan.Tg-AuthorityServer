using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;
using TelegramAuth;

namespace ProSMan.Tg_TestClient
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var channel = GrpcChannel.ForAddress("https://localhost:5001");
			var client = new TelegramAuthorizer.TelegramAuthorizerClient(channel);

			var headers = new Metadata();
			headers.Add("client-id", "prosman-web");
			headers.Add("client-secret", "fdce154b-30d3-43d4-9dc2-9f98b4975d6f");

			var reply = await client.GetTelegramCodeAsync(
							  new TelegramAuthRequest
							  {
								  ApplicationClientId = "fdce154b-30d3-43d4-9dc2-9f98b4975d6f",
								  UserName = "UserTest"
							  }, headers);

			Console.WriteLine(reply);
		}
	}
}
