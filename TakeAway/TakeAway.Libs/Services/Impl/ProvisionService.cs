using System;
using System.Threading.Tasks;
using TakeAway.Libs.Contracts;
using TakeAway.Libs.Queue;

namespace TakeAway.Libs.Services.Impl
{
    public class ProvisionService : IProvisionService
    {
        private readonly IIntoQueue _clientIntoQueue;

        public ProvisionService(IIntoQueue clientIntoQueue)
        {
            _clientIntoQueue = clientIntoQueue;
        }

        public async Task<ProvisionTakeAwayResponse> SendPrivisionRequestion(ProvisionTakeAwayRequest request)
        {
            await _clientIntoQueue.SendMessageAsync(request);
            return new ProvisionTakeAwayResponse
            {
                Id = request.Id,
                Status = ProvisionTakeAwayStatus.Unprocessed,
                TakeAwayName = request.Name
            };
        }
    }
}