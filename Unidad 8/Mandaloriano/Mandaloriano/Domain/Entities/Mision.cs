namespace Domain.Entities
{
    public class Mision
    {

        private int _id;
        private string _titulo;
        private string _descripcion;
        private int _recompensa;

        public Mision(int id, string titulo, string descripcion, int recompensa)
        {

            _id = id;
            _titulo = titulo;
            _descripcion = descripcion;
            _recompensa = recompensa;

        }

        public int Id { 
            
            get { return _id; }
            set { _id = value; }

        }

        public string Titulo
        {

            get { return _titulo; }
            set { _titulo = value; }

        }

        public string Descripcion
        {

            get { return _descripcion; }
            set { _descripcion = value; }

        }

        public int Recompensa
        {

            get { return _recompensa; }
            set { _recompensa = value; }

        }

    }
}
