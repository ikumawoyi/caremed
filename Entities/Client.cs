using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class Client
	{
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Email { get; set; }


		public string ClientId { get; set; }
		public string CareHomeId { get; set; }


		//public CareHome CareHome { get; set; }
		//public Pharmacy Pharmacy { get; set; }
	}
}
