namespace jmailaT2S2A.Views;

public partial class vLogin : ContentPage
{
    string[] users = { "Carlos", "Ana", "Jose" };
    string[] pass = { "carlos123", "ana123", "jose123" };

    public vLogin()
	{
		InitializeComponent();
        
    }
    

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string usuario = txtUsuario.Text?.Trim();
        string clave = txtClave.Text?.Trim();

        if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
        {
            await DisplayAlert("Error", "Por favor llena todos los campos", "OK");
            return;
        }

        for (int i = 0; i < users.Length; i++)
        {
            if (usuario.Equals(users[i], StringComparison.OrdinalIgnoreCase) && clave == pass[i])
            {
                await DisplayAlert("Bienvenido", $"Hola {users[i]}", "Continuar");

                // Abrir ventana vSistemas y enviar usuario como parámetro
                await Navigation.PushAsync(new vSistemas(users[i]));
                return;
            }
        }

        await DisplayAlert("Acceso denegado", "Usuario o contraseña incorrectos", "OK");
    }
}
