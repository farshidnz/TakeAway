using System.Threading.Tasks;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace TakeAway.Libs.Queue.Impl
{
    public class IntoSqs : IIntoSqs
    {
        private readonly IAmazonSQS _sqsClient;

        public IntoSqs(IAmazonSQS sqsClient)
        {
            _sqsClient = sqsClient;
        }

        public async Task<SendMessageResponse> SendMessageAsync(SendMessageRequest mapped)
        {
            //TODO : Retry
            var response = await _sqsClient.SendMessageAsync(mapped);
            return response;
        }
    }
}