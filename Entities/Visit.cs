using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class Visit
	{
		public int Id { get; set; }
		public string VisitorName { get; set; }
		public string WhomToSee { get; set; }
		public string PurposeOfVisit { get; set; }
		public string VisitorPhoneNumber { get; set; }
		public string VisitorEmail { get; set; }
	}
}
