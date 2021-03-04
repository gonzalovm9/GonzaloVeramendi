using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public interface IHijosService
    {
        public IEnumerable<Hijo> GetHijos();
        public Hijo GetHijoById(int id);
        public bool AddHijo(Hijo hijo);
        public bool UpdateHijo(int id, Hijo hijo);
        public bool DeleteHijo(int id);
        public IEnumerable<Hijo> GetHijoByIdPersonal(int id);
    }
}
