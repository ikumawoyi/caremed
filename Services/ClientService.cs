using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
	public interface IClientService
	{

		IEnumerable<Client> GetAll();
		Client GetById(int id);
		CareHome GetById(string id);
		Client Create(Client client);
		Task Update(Client client);
		//int GiveMedication(Client client);
		Medication CreateMedication(Medication medication);
		IEnumerable<CareHome> GetClientHome();
		IEnumerable<Medication> GetClientMedication(int id);
		void Delete(int id);
	}
	public class ClientService : IClientService
	{
		private readonly DataContext _context;

		public ClientService(DataContext context)
		{
			_context = context;
		}

		public string GenerateID(string name)
		{
			Guid guid = Guid.NewGuid();
			string id = string.Concat(guid.ToString(), name);
			return id;
		}


		public Client Create(Client client)
		{
			var id = GenerateID(client.Name);
			client.ClientId = id;
			_context.Clients.Add(client);
			_context.SaveChanges();
			return client;
		}

		public void Delete(int id)
		{
			var client = _context.Clients.Find(id);
			if (client != null)
			{
				_context.Clients.Remove(client);
				_context.SaveChanges();
			}
		}

		public IEnumerable<Client> GetAll()
		{
			return _context.Clients;
		}

		public Client GetById(int id)
		{
			var client = _context.Clients.Find(id);
			return client;
		}

		public CareHome GetById(string id)
		{
			var careHome = _context.CareHomes.FirstOrDefault(v => v.CareHomeId == id);
			return careHome;
		}

		public async Task Update(Client client)
		{
			var dbclient = new Client();
			dbclient = _context.Clients.First(g => g.ID == client.ID);
			_context.Entry(dbclient).CurrentValues.SetValues(client);
			await _context.SaveChangesAsync();

		}

		public IEnumerable<Medication> GetClientMedication(int id)
		{
			var client = GetById(id);
			return _context.Medications.Where(x => x.ClientID == client.ClientId);
		}

		public Medication CreateMedication(Medication medication)
		{
			var clientid = int.Parse(medication.ClientID);
			var client = _context.Clients.Find(clientid);
			var id = GenerateID(medication.Name);
			medication.MedicationID = id;
			medication.ClientID = client.ClientId;
			_context.Medications.Add(medication);
			_context.SaveChanges();
			return medication;
		}

		public IEnumerable<CareHome> GetClientHome()
		{
			return _context.CareHomes;
		}
	}
}

