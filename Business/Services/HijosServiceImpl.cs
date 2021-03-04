using Data.Repositories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class HijosServiceImpl : IHijosService
    {
        private readonly IHijosRepository _hijosRepository;
        public HijosServiceImpl(IHijosRepository hijoRepository)
        {
            _hijosRepository = hijoRepository;
        }

        public Hijo GetHijoById(int id)
        {
            return _hijosRepository.GetHijoById(id);
        }

        public IEnumerable<Hijo> GetHijoByIdPersonal(int id)
        {
            return _hijosRepository.GetHijoByIdPersonal(id);
        }

        public IEnumerable<Hijo> GetHijos()
        {
            return _hijosRepository.GetHijos();
        }

        public bool AddHijo(Hijo hijo)
        {
            return _hijosRepository.AddHijo(hijo);
        }

        public bool DeleteHijo(int id)
        {
            return _hijosRepository.DeleteHijo(id);
        }

        public bool UpdateHijo(int id, Hijo hijo)
        {
            return _hijosRepository.UpdateHijo(id, hijo);
        }
    }
}
