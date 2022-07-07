using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
	public class Tenant
	{
		public int Id { get; set; }
		public int TenantId { get; set; }
		public string Name { get; set; }
		public string FlatNumber { get; set; }
		public string DateOfBirth { get; set; }
		public string SocialWorker { get; set; }
		public string HospitalAppointment { get; set; }
		public string ParentOrGuardian { get; set; }
		public string Calendar { get; set; }
		public string GP { get; set; }
		public string Medication { get; set; }
		public string Fund { get; set; }
		public string Expenses { get; set; }
		public string Activity { get; set; }
		public string Diagnosis { get; set; }
		public string Documents { get; set; }


		public ICollection<SocialWorker> SocialWorkers { get; set; }
		public ICollection<MedicalAppointment> MedicalAppointments { get; set; }
		public ICollection<Behavior> Behaviors { get; set; }
		public ICollection<Bank> Banks { get; set; }
		public ICollection<Guardian> Guardians { get; set; }
		public ICollection<Staff> Staffs { get; set; }
	}
}
