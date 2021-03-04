using Data.Repositories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class PersonalServiceImpl : IPersonalService
    {
        private readonly IPersonalRepository _personalRepository;
        public PersonalServiceImpl(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }

        public IEnumerable<Personal> GetPersonal()
        {
            return _personalRepository.GetPersonal();
        }

        public bool AddPersonal(Personal personal)
        {
            return _personalRepository.AddPersonal(personal);
        }

        public bool DeletePersonal(int id)
        {
            return _personalRepository.DeletePersonal(id);
        }

        public Personal GetPersonalById(int id)
        {
            return _personalRepository.GetPersonalById(id);
        }

        public bool UpdatePersonal(int id, Personal personal)
        {
            return _personalRepository.UpdatePersonal(id, personal);
        }
    }
}
