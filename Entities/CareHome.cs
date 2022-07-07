﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class CareHome
	{
		[Key]
		public int ID { get; set; }
		public string CareHomeId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string ContactPerson { get; set; }
		public string Email { get; set; }
	}
}
