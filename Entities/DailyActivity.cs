using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class DailyActivity : StaffBase
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public string SupportedStaff { get; set; }
		public string Outcome { get; set; }
	}
}
