using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Models;
using EjercicioCRUDMvvm.Services;
using EjercicioCRUDMvvm.Views;
using System.Collections.ObjectModel;

namespace EjercicioCRUDMvvm.ViewModels
{
    public partial class EstudianteMainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Estudiante> estudianteCollection = new ObservableCollection<Estudiante>();

        private readonly EstudianteService _estudianteService;

        public EstudianteMainPageViewModel()
        {
            _estudianteService = new EstudianteService();
        }

        /// <summary>
        /// Obtiene el listado de Estudiantes
        /// </summary>
        public void GetAll()
        {
            var getAll = _estudianteService.GetAll();

            if (getAll?.Count > 0)
            {
                EstudianteCollection.Clear();
                foreach (var estudiante in getAll)
                {
                    EstudianteCollection.Add(estudiante);
                }
            }
        }

        /// <summary>
        /// Redirecciona al formulario de Estudiantes
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task GoToAddEstudiantesPage()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new AddEstudiantePage());
        }

        /// <summary>
        /// Selecciona el registro para editar o eliminar
        /// </summary>
        /// <param name="estudiante">Objeto a editar o eliminar</param>
        /// <returns>Actualizar: Nos lleva al formulario de Empleado, Eliminar: Elimina el registro</returns>
        [RelayCommand]
        private async Task SelectEstudiante(Estudiante estudiante)
        {
            try
            {
                string res = await App.Current!.MainPage!.DisplayActionSheet("Operación", "Cancelar", null, "Actualizar", "Eliminar");

                switch (res)
                {
                    case "Actualizar":
                        await App.Current.MainPage.Navigation.PushAsync(new AddEstudiantePage(estudiante));
                        break;
                    case "Eliminar":
                        bool respuesta = await App.Current!.MainPage!.DisplayAlert("Eliminar Estudiante", "¿Desea eliminar el estudiante?", "Si", "No");

                        if (respuesta)
                        {
                            int del = _estudianteService.Delete(estudiante);
                            if (del > 0)
                            {
                                EstudianteCollection.Remove(estudiante);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        /// <summary>
        /// Método personalizado para construir alertas
        /// </summary>
        /// <param name="Tipo">Tipo de Alerta</param>
        /// <param name="Mensaje">Mensaje de Alerta</param>
        private void Alerta(String Tipo, String Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Tipo, Mensaje, "Aceptar"));
        }
    }
}
