using EjercicioCRUDMvvm.Models;
using EjercicioCRUDMvvm.ViewModels;

namespace EjercicioCRUDMvvm.Views;

public partial class AddEstudiantePage : ContentPage
{
    private AddEstudiantePageViewModel _viewModel;
    public AddEstudiantePage()
    {
        InitializeComponent();
        _viewModel = new AddEstudiantePageViewModel();
        this.BindingContext = _viewModel;
    }

    public AddEstudiantePage(Estudiante estudiante)
    {
        InitializeComponent();
        _viewModel = new AddEstudiantePageViewModel(estudiante);
        this.BindingContext = _viewModel;
    }
}