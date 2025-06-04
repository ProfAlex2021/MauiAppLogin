
namespace MauiAppLogin
{
    public partial class App : Application
    {
  
        public App()
        {
            InitializeComponent();
            string usuario = Preferences.Default.Get("usuarioValido", "");
            if (usuario.Equals(String.Empty))
            {
                MainPage = new Login();
            }
            else
            {
                MainPage = new AppShell();
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);

            window.Height = 700;
            window.Width = 300;

            return window;
        }
    }

}
