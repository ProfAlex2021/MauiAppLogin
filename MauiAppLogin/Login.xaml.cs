namespace MauiAppLogin;

public partial class Login : ContentPage
{
	List<Usuario> lista;
	public Login()
	{
		InitializeComponent();

		lista = new List<Usuario>();

		lista.Add(
			new Usuario()
			{
				Nome = "jose",
				Senha = "123"
			}
		);

		lista.Add(
			new Usuario()
			{
				Nome = "maria",
				Senha = "321"
			}
		);
	}

    private async void btnEntrar_Clicked(object sender, EventArgs e)
    {
		try
		{
			var usuarioDigitado = new Usuario() { Nome = txtUsuario.Text, Senha = txtSenha.Text };

			bool valido = lista.Any(u => usuarioDigitado.Nome.Equals(u.Nome) && usuarioDigitado.Senha.Equals(u.Senha));

			if (valido)
			{
				await SecureStorage.Default.SetAsync("usuarioValido", usuarioDigitado.Nome);
				App.Current.MainPage = new AppShell();
			}
			else
			{
				throw new Exception("Usuário e/ou senha inválidos");
			}
		}
		catch (Exception ex)
		{
			await DisplayAlert("Erro de exceção", ex.Message, "Fechar");
		}
    }
}