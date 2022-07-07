using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class TenantBase
	{
		public int TenantId { get; set; }
		public Tenant Tenant { get; set; }
	}
}
