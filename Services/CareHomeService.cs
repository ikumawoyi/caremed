using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{

    public interface ICareHomeService
    {

        IEnumerable<CareHome> GetAll();
        CareHome GetById(int id);
        CareHome Create(CareHome careHome);
        Task Update(CareHome careHome);
        void Delete(int id);
    }
	public class CareHomeService : ICareHomeService
	{
		private readonly DataContext _context;

		public CareHomeService(DataContext context)
		{
			_context = context;
		}

		public string GenerateID(string name)
		{
			Guid guid = Guid.NewGuid();
			string id = string.Concat(guid.ToString(), name);
			return id;
		}


		public CareHome Create(CareHome careHome)
		{
			var id = GenerateID(careHome.Name);
			careHome.CareHomeId = id;
			_context.CareHomes.Add(careHome);
			_context.SaveChanges();
			return careHome;
		}

		public void Delete(int id)
		{
			var careHome = _context.CareHomes.Find(id);
			if (careHome != null)
			{
				_context.CareHomes.Remove(careHome);
				_context.SaveChanges();
			}
		}

		public IEnumerable<CareHome> GetAll()
		{
			return _context.CareHomes;
		}

		public CareHome GetById(int id)
		{
			var careHome = _context.CareHomes.Find(id);
			return careHome;
		}

		public async Task Update(CareHome careHome)
		{
			var dbcarehome = new CareHome();
			 dbcarehome = _context.CareHomes.First(g => g.ID == careHome.ID);
			_context.Entry(dbcarehome).CurrentValues.SetValues(careHome);
			await _context.SaveChangesAsync();

		}
	}
}
