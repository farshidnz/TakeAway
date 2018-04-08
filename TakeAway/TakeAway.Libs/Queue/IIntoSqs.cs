using System.Threading.Tasks;
using Amazon.SQS.Model;

namespace TakeAway.Libs.Queue
{
	public interface IIntoSqs
	{
		Task<SendMessageResponse> SendMessageAsync(SendMessageRequest mapped);
	}
}