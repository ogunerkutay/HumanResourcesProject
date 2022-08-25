using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DayOffService
{
    public class DayOffService : IDayOffService
    {
        private readonly IDayOffRepository dayOffRepository;

        public DayOffService(IDayOffRepository _dayOffRepository)
        {
            dayOffRepository = _dayOffRepository;
        }

        public void Add(DayOff entity)
        {
            dayOffRepository.Create(entity);
        }

        public void Delete(DayOff entity)
        {
            dayOffRepository.Delete(entity);
        }

        public List<DayOff> GetAll()
        {
            return dayOffRepository.GetAll();
        }

        public DayOff GetById(int id)
        {
            return dayOffRepository.GetById(id);
        }

        public List<DayOff> GetListById(int id)
        {
            return dayOffRepository.GetListFilter(x => x.DayOffID == id);
        }

        public void Update(DayOff entity)
        {
            dayOffRepository.Update(entity);
        }
    }
}
