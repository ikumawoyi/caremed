using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class Bank : TenantBase
	{
		public int Id { get; set; }
		public string Balance { get; set; }
		public string MoneyIn { get; set; }
		public string MoneyOut { get; set; }
		public string PurposeOfSpending { get; set; }
		public DateTime DateOfSpending { get; set; }
	}
}
