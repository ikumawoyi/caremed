using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class Medication 
	{
		public int ID { get; set; }
		public string ClientID { get; set; }
		public string MedicationID { get; set; }
		public string Name { get; set; }
		public string Manufacturer { get; set; }
		public string Strength { get; set; }
		public string Form { get; set; }
		public string Email { get; set; }
		public int CountOfRemainder { get; set; }
		public int CountOfSupply { get; set; }
		public int Duration { get; set; }
		public int Dose { get; set; }
		public DateTime TimeGiven { get; set; }
		public bool IsGiven { get; set; }
	}
}
