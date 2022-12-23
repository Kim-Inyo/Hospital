﻿using Database.Converters;
using Domain.Logic;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ApplicationContext _context;

        public ScheduleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Schedule item)
        {
            _context.Schedules.Add(item.ToModel());
            return true;
        }

        public bool Delete(int id)
        {
            var sched = GetItem(id);
            if (sched == default)
                return false;

            _context.Schedules.Remove(sched.ToModel());
            return true;
        }

        public bool EditSchedule(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Schedule> GetAll()
        {
            return _context.Schedules.Select(s => s.ToDomain());
        }

        public Schedule? GetItem(int id)
        {
            return _context.Schedules.FirstOrDefault(s => s.Id == id)?.ToDomain();
        }

        public IEnumerable<Schedule> GetScheduleOfDoctor(int doctorid)
        {
            return _context.Schedules.Where(s => s.DoctorId == doctorid).Select(s => s.ToDomain());
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(Schedule item)
        {
            _context.Schedules.Update(item.ToModel());
            return true;
        }
    }
}
