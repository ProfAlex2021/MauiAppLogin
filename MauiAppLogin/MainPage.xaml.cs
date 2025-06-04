namespace MauiAppLogin
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            btnLogout.Text += " - " + Preferences.Default.Get("usuarioValido", "usuario");
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            Preferences.Default.Remove("usuarioValido");
            App.Current.MainPage = new Login();
        }
    }

}
