using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
	public interface IMedicationService
	{

		IEnumerable<Medication> GetAll();
		Medication GetById(int id);
		Medication Create(Medication medication);
		Task Update(Medication medication);
		Task GiveMedication(Medication medication);
		void Delete(int id);
	}
	public class MedicationService : IMedicationService
	{
		private readonly DataContext _context;

		public MedicationService(DataContext context)
		{
			_context = context;
		}

		public string GenerateID(string name)
		{
			Guid guid = Guid.NewGuid();
			string id = string.Concat(guid.ToString(), name);
			return id;
		}


		public Medication Create(Medication medication)
		{
			var id = GenerateID(medication.Name);

			medication.MedicationID = id;
			_context.Medications.Add(medication);
			_context.SaveChanges();
			return medication;
		}

		public void Delete(int id)
		{
			var medication = _context.Medications.Find(id);
			if (medication != null)
			{
				_context.Medications.Remove(medication);
				_context.SaveChanges();
			}
		}

		public IEnumerable<Medication> GetAll()
		{
			return _context.Medications;
		}

		public Medication GetById(int id)
		{
			var medication = _context.Medications.Find(id);
			return medication;
		}

		public async Task Update(Medication medication)
		{
			Medication dBmedication = _context.Medications.Find(medication.ID);
			if (dBmedication != null)
			{
				var currentRemainder = dBmedication.CountOfRemainder - medication.Dose;
				dBmedication.Dose = medication.Dose;
				dBmedication.IsGiven = medication.IsGiven;
				dBmedication.TimeGiven = DateTime.Now;
				dBmedication.CountOfRemainder = currentRemainder;
				dBmedication.CountOfSupply = currentRemainder;
				_context.Update(dBmedication);

				const string accountSid = "AC163f8878ba8a2e63987571141a375780";
				const string authToken = "937cbf434782ee760705845e699ba3a5";
				TwilioClient.Init(accountSid, authToken);

				var to = new PhoneNumber("+447405017464");
				var from = new PhoneNumber("+441904935073");
				var call = CallResource.Create(to, from,
					url: new Uri("http://demo.twilio.com/docs/voice.xml"));
				Console.WriteLine(call.Sid);

			}
			await _context.SaveChangesAsync();
		}

		//GiveMedication to be used later
		public async Task GiveMedication(Medication medication)
		{
			var dBclientMedication = _context.Medications.Find(medication.ID);

			if (dBclientMedication != null)
			{
				var actualRemainder = dBclientMedication.CountOfRemainder - dBclientMedication.Dose;
				dBclientMedication.CountOfRemainder = actualRemainder;
				dBclientMedication.CountOfSupply = dBclientMedication.CountOfRemainder;
				dBclientMedication.IsGiven = true;
				dBclientMedication.TimeGiven = DateTime.Now;
				_context.Update(dBclientMedication);
			}
			await _context.SaveChangesAsync();
		}
	}
}
