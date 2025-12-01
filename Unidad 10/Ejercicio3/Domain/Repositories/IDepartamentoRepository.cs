using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IDepartamentoRepository
    {
        public List<Departamento> getDepartamentos();
        public int deleteDepartamento(int id);
        public int crearDepartamento(Departamento departamentoNuevo);
        public int actualizarDepartamento(int idDepartamento, Departamento departamentoActualizado);
        public Departamento getDepartamentoById(int id);

    }
}