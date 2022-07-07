using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class SocialWorker : TenantBase
	{
		public int Id { get; set; }
		public string SocialWorkerName { get; set; }
		public string SocialWorkerPhoneNumber { get; set; }
		public string SocialWorkerEmail { get; set; }
	}
}
