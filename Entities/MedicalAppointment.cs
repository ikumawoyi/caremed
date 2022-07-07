using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApi.Helpers.Enum;

namespace WebApi.Entities
{
	public class MedicalAppointment : TenantBase
	{
		public int Id { get; set; }
		public AppointmentType AppointmentType { get; set; }
		public string HospitalLocation { get; set; }
		public string SupportedStaff { get; set; }
		public string AppointmentOutcome { get; set; }
	}
}
