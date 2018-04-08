using System;
using System.Collections.Generic;

namespace TakeAway.Libs.Contracts
{
	public class ProvisionTakeAwayRequest
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string CousingType { get; set; }
		public IEnumerable<string> Menu { get; set; }
	}
}