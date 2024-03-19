using EjercicioCRUDMvvm.ViewModels;

namespace EjercicioCRUDMvvm.Views; 

public partial class EstudianteMainPage : ContentPage
{
    private EstudianteMainPageViewModel _viewModel;
    public EstudianteMainPage()
    {
        InitializeComponent();
        _viewModel = new EstudianteMainPageViewModel();
        this.BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetAll();
    }
}