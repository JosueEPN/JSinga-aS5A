using JSingañaS5A.Models;

namespace JSingañaS5A.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.PersonRepo.AddNewPerson(txtNombre.Text);
        lblStatus.Text = App.PersonRepo.StatusMessage;



    }

    private void Mostrar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";

        List<Persona> people = App.PersonRepo.GetAllPeople();
        Listapersonas.ItemsSource = people;

    }


    private void btnViewActualizar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        int personId = (int)button.CommandParameter;

        // Navega a la vista de actualización, pasando el ID de la persona
        Navigation.PushAsync(new Actualizar(personId));
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        int personId = (int)button.CommandParameter;

        // Llama al método para eliminar la persona
        App.PersonRepo.DeletePerson(personId);
        // Actualiza el mensaje de estado
        DisplayAlert("Resultado", App.PersonRepo.StatusMessage, "OK");

        // Recarga la lista de personas para reflejar el cambio
        Listapersonas.ItemsSource = App.PersonRepo.GetAllPeople();
    }
}