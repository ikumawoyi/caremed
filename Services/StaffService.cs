using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
	public interface IStaffService
	{
		IEnumerable<Staff> GetAll();
		Staff GetById(int id);
		Staff Create(Staff staff);
		void Update(Staff staff);
		void Delete(int id);
	}


	public class StaffService : IStaffService
	{
		private readonly DataContext _context;

		public StaffService(DataContext context)
		{
			_context = context;
		}
		public Staff Create(Staff staff)
		{
			_context.Staffs.Add(staff);
			_context.SaveChanges();
			return staff;
		}

		public void Delete(int id)
		{
			var staff = _context.Staffs.Find(id);
			if (staff != null)
			{
				_context.Remove(staff);
				_context.SaveChanges();
			}
		}

		public IEnumerable<Staff> GetAll()
		{
			return _context.Staffs;
		}

		public Staff GetById(int id)
		{
			var staff = _context.Staffs.Find(id);
			return staff;
		}

		public void Update(Staff staff)
		{
			var dBstaff = _context.Staffs.Find(staff.Id);
			if (dBstaff != null)
			{
				dBstaff.Name = staff.Name;
				dBstaff.Email = staff.Email;
				dBstaff.KeyClient = staff.KeyClient;
				dBstaff.PhoneNumber = staff.PhoneNumber;
				dBstaff.Agency = staff.Agency;
				dBstaff.OtherSkill = staff.OtherSkill;
				dBstaff.ShiftPattern = staff.ShiftPattern;
				dBstaff.MedicalAppointments = staff.MedicalAppointments;
				dBstaff.LeaveRequests = staff.LeaveRequests;
				dBstaff.WeeklyWorkingHours = staff.WeeklyWorkingHours;
				dBstaff.Tenant = staff.Tenant;
				dBstaff.DailyActivities = staff.DailyActivities;
			}
			_context.Update(staff);
			_context.SaveChanges();
		}
	}
}
