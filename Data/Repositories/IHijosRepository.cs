using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entity.Entities;

namespace Data.Repositories
{
    public interface IHijosRepository
    {
        public IEnumerable<Hijo> GetHijos();
        public Hijo GetHijoById(int id);
        public IEnumerable<Hijo> GetHijoByIdPersonal(int id);
        public bool AddHijo(Hijo hijo);
        public bool UpdateHijo(int id, Hijo hijo);
        public bool DeleteHijo (int id);

    }
}
