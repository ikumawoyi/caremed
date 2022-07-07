using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
	public interface IAgencyService
	{
      
        IEnumerable<Agency> GetAll();
        Agency GetById(int id);
        Agency Create(Agency agency);
        void Update(Agency agency);
        void Delete(int id);
    }

	public class AgencyService : IAgencyService
	{
		private readonly DataContext _context;

		public AgencyService(DataContext context)
		{
			_context = context;
		}
		public Agency Create(Agency agency)
		{
			_context.Agencies.Add(agency);
			_context.SaveChanges();
			return agency;
		}

		public void Delete(int id)
		{
			var agency = _context.Agencies.Find(id);
			if (agency != null)
			{
				_context.Agencies.Remove(agency);
				_context.SaveChanges();
			}
		}

		public IEnumerable<Agency> GetAll()
		{
			return _context.Agencies;
		}

		public Agency GetById(int id)
		{
			var agency = _context.Agencies.Find(id);
			return agency;
		}

		public void Update(Agency agency)
		{
			var dBagency = _context.Agencies.Find(agency.Id);
			if (dBagency != null)
			{
				dBagency.Email = agency.Email;
				dBagency.Address = agency.Address;
				dBagency.AgencyId = agency.AgencyId;
				dBagency.AgencyName = agency.AgencyName;
				dBagency.ContractNumber = agency.ContractNumber;
				dBagency.PhoneNumber = agency.PhoneNumber;
				dBagency.Staff = agency.Staff;
				dBagency.WeeklyWorkingHours = agency.WeeklyWorkingHours;
			}
			_context.Update(agency);
			_context.SaveChanges();
		}
	}
}
