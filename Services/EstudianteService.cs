using EjercicioCRUDMvvm.Models;
using SQLite;

namespace EjercicioCRUDMvvm.Services
{
    public class EstudianteService
    {
        private readonly SQLiteConnection _dbConnection;

        public EstudianteService()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Instituto.db3");
                _dbConnection = new SQLiteConnection(dbPath);
                _dbConnection.CreateTable<Estudiante>();

            } catch (Exception ex)
            {
                // Handle the exception (e.g., log it or display an error message)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public List<Estudiante> GetAll()
        {
            var res = _dbConnection.Table<Estudiante>().ToList();
            return res;
        }

        public int Insert(Estudiante estudiante)
        {
            return _dbConnection.Insert(estudiante);
        }

        public int Update(Estudiante estudiante)
        {
            return _dbConnection.Update(estudiante);
        }

        public int Delete(Estudiante estudiante)
        {
            return _dbConnection.Delete(estudiante);
        }
    }
}
