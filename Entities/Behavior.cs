using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApi.Helpers.Enum;

namespace WebApi.Entities
{
	public class Behavior : TenantBase
	{
		public int Id { get; set; }
		public BehaviorType BehaviorType { get; set; }
		public string LikelyTrigger { get; set; }
		public string StaffInvolvement { get; set; }
		public bool AnyInjury { get; set; }
		public string FirstAidApplication { get; set; }
		public string Location { get; set; }
		public DateTime IncidentTime { get; set; }

	}
}
