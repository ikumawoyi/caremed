using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class Agency : StaffBase
	{
		public int Id { get; set; }
		public int AgencyId { get; set; }
		public string AgencyName { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public string ContractNumber { get; set; }
		public string Email { get; set; }

		public ICollection<WeeklyWorkingHour> WeeklyWorkingHours { get; set; }
	}
}
