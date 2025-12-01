using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDepartamentoUC
    {
        public List<Departamento> getDepartamentos();
        public Departamento getDetalleDepartamento(int id);
        public List<Persona> getPersonasEnDepartamento(int id);
        public int crearDepartamento(Departamento departamento);
        public int actualizarDepartamento(int id, Departamento departamento);
        public int eliminarDepartamento(int id);
    }
}