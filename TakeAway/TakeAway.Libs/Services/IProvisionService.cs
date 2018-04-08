using System.Threading.Tasks;
using TakeAway.Libs.Contracts;

namespace TakeAway.Libs.Services
{
    public interface IProvisionService
    {
	    Task<ProvisionTakeAwayResponse> SendPrivisionRequestion(ProvisionTakeAwayRequest request);
    }
}