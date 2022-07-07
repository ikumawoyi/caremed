using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class Complaint
	{
		public int Id { get; set; }
		public string ComplaintSource { get; set; }
		public string StaffHandling { get; set; }
		public DateTime ComplaintDate { get; set; }
	}
}
