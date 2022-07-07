using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
	public class Enum
	{
		public enum CallType
		{
			Incoming,
			Outgoing
		}

		public enum BehaviorType
		{
			Incoming,
			Outgoing
		}

		public enum LeaveType
		{
			Incoming,
			Outgoing
		}

		public enum ApprovalStatus
		{
			Approved,
			Declined,
			Pending
		}

		public enum AppointmentType
		{
			Incoming,
			Outgoing
		}

		public enum ShiftPattern
		{
			Incoming,
			Outgoing
		}
	}
}
