namespace JSingañaS5A.Views;

public partial class Actualizar : ContentPage
{
    private int personaId;

    public Actualizar()
    {
        InitializeComponent();
    }
    public Actualizar(int id)
	{
		InitializeComponent();
        personaId = id;
        CargarPersona();
    }

    private void CargarPersona()
    {
        var person = App.PersonRepo.GetPersonById(personaId);
        if (person != null)
        {
            lblNombreActual.Text = person.Name;
        }
    }

  
    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(entryNuevoNombre.Text))
        {
            App.PersonRepo.UpdatePerson(personaId, entryNuevoNombre.Text);
            DisplayAlert("Éxito", App.PersonRepo.StatusMessage, "OK");
            Navigation.PopAsync(); // Regresa a la vista principal
        }
        else
        {
            DisplayAlert("Error", "El nuevo nombre no puede estar vacío.", "OK");
        }
    }
}