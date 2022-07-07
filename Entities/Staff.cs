using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApi.Helpers.Enum;

namespace WebApi.Entities
{
	public class Staff : TenantBase
	{
		public int Id { get; set; }
		public int StaffId { get; set; }
		public string Name { get; set; }
		public string Agency { get; set; }
		public ShiftPattern ShiftPattern { get; set; }
		public string KeyClient { get; set; }
		public string OtherSkill { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }


		public ICollection<MedicalAppointment> MedicalAppointments { get; set; }
		public ICollection<DailyActivity> DailyActivities { get; set; }
		public ICollection<Agency> Agencies { get; set; }
		public ICollection<LeaveRequest> LeaveRequests { get; set; }
		public ICollection<WeeklyWorkingHour> WeeklyWorkingHours { get; set; }
	}
}
