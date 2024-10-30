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
}