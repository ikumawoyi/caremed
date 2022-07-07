using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApi.Helpers.Enum;

namespace WebApi.Entities
{
	public class CallLogs
	{
		public int Id { get; set; }
		public CallType CallTypes { get; set; }
		public string CallPurpose { get; set; }
		public string CallOutcome { get; set; }
		public DateTime CallTime { get; set; }
	}
}
