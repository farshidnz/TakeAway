using System.Threading.Tasks;
using Amazon.SQS.Model;
using Newtonsoft.Json;
using TakeAway.Libs.Contracts;

namespace TakeAway.Libs.Queue.Impl
{
	public class IntoOueue : IIntoQueue
	{
		private readonly IIntoSqs _intoSqsClient;

		public IntoOueue(IIntoSqs intoSqsClient)
		{
			_intoSqsClient = intoSqsClient;
		}

		public async Task SendMessageAsync(ProvisionTakeAwayRequest request)
		{
			var mapped = MessageBuilder(request);
			await _intoSqsClient.SendMessageAsync(mapped);
		}

		private static SendMessageRequest MessageBuilder(ProvisionTakeAwayRequest request)
		{
			return new SendMessageRequest
			{
				QueueUrl = null, //TODO
				MessageBody = JsonConvert.SerializeObject(request)
			};
		}
	}
}