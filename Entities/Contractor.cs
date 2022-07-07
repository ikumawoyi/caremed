using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class Contractor
	{
		public int Id { get; set; }
		public string ContractorCompany { get; set; }
		public string ContractorName { get; set; }
		public string ContractorCallNumber { get; set; }
		public string ContractorPurposeOfVisit { get; set; }
	}
}
