using System.Threading.Tasks;
using TakeAway.Libs.Contracts;

namespace TakeAway.Libs.Queue
{
	public interface IIntoQueue
	{
		Task SendMessageAsync(ProvisionTakeAwayRequest request);
	}
}