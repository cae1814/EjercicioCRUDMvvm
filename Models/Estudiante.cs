using SQLite;

namespace EjercicioCRUDMvvm.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identidad { get; set; }
        public string FechaNacimiento { get; set; }
        public string FechaIngreso { get; set; }
        public string Direccion { get; set; }
        public string NombrePadre { get; set; }
        public string NombreMadre { get; set; }

    }
}
