using System;

namespace TakeAway.Libs.Contracts
{
	public class ProvisionTakeAwayResponse
	{
		public Guid Id { get; set; }
		public string TakeAwayName { get; set; }
		public ProvisionTakeAwayStatus Status { get; set; }
	}
}