using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Models;
using EjercicioCRUDMvvm.Services;

namespace EjercicioCRUDMvvm.ViewModels
{
    public partial class AddEstudiantePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string identidad;

        [ObservableProperty]
        private string fechaNacimiento;

        [ObservableProperty]
        private string fechaIngreso;

        [ObservableProperty]
        private string direccion;

        [ObservableProperty]
        private string nombrePadre;

        [ObservableProperty]
        private string nombreMadre;

        private readonly EstudianteService _estudianteService;

        public AddEstudiantePageViewModel()
        {
            _estudianteService = new EstudianteService();
        }

        public AddEstudiantePageViewModel(Estudiante estudiante)
        {
            Nombre = estudiante.Nombre;
            Identidad = estudiante.Identidad;
            FechaNacimiento = estudiante.FechaNacimiento;
            FechaIngreso = estudiante.FechaNacimiento;
            Direccion = estudiante.Direccion;
            NombrePadre = estudiante.NombrePadre;
            NombreMadre = estudiante.NombreMadre;
            Id = estudiante.Id;
            _estudianteService = new EstudianteService();
        }

        /// <summary>
        /// Agrega o actualiza un registro
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Estudiante estudiante = new Estudiante
                {
                    Nombre = Nombre,
                    //Email = Email,
                    Direccion = Direccion,
                    Id = Id
                };

                if (Validar(estudiante))
                {
                    if (Id == 0)
                    {
                        _estudianteService.Insert(estudiante);
                    }
                    else
                    {
                        _estudianteService.Update(estudiante);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        /// <summary>
        /// Valida que los campos no esten vacíos
        /// </summary>
        /// <param name="Estudiante">Objeto a validar</param>
        /// <returns></returns>
        private bool Validar(Estudiante estudiante)
        {
            try
            {
                if (estudiante.Nombre == null || estudiante.Nombre == "")
                {
                    Alerta("ADVERTENCIA", "Escriba el nombre completo");
                    return false;
                }
                /*else if (Empleado.Email == null || Empleado.Email == "")
                {
                    Alerta("ADVERTENCIA", "Escriba el correo electrónico");
                    return false;
                }*/
                else if (estudiante.Direccion == null || estudiante.Direccion == "")
                {
                    Alerta("ADVERTENCIA", "Escriba la dirección");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
                return false;
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
