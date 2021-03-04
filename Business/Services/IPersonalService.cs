using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public interface IPersonalService
    {
        public IEnumerable<Personal> GetPersonal();
        public Personal GetPersonalById(int id);
        public bool AddPersonal(Personal personal);
        public bool UpdatePersonal(int id, Personal personal);
        public bool DeletePersonal(int id);
    }
}
