using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApi.Helpers.Enum;

namespace WebApi.Entities
{
	public class LeaveRequest : StaffBase
	{
		public int Id { get; set; }
		public string StaffName { get; set; }
		public LeaveType LeaveType { get; set; }
		public string LeaveReason { get; set; }
		public ApprovalStatus ApprovalStatus { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
	}
}
