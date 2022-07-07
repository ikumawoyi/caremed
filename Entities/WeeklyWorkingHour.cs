using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class WeeklyWorkingHour : StaffBase
	{
		public int Id { get; set; }
		public string NumberOfHours { get; set; }
		public string Amount { get; set; }

		public int AgencyId { get; set; }
		public Agency Agency { get; set; }
	}
}
