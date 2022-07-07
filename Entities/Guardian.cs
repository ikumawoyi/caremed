using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class Guardian : TenantBase
	{
		public int Id { get; set; }
		public string ParentFirstName { get; set; }
		public string ParentLastName { get; set; }
		public string ParentEmail { get; set; }
		public string ParentPhoneNumber { get; set; }
		public string HomeAddress { get; set; }
		public string Relationship { get; set; }
	}
}
