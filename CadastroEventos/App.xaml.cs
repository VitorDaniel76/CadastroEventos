namespace CadastroEventos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = new()
            {
                Width = 400,
                Height = 600,

                Page = new AppShell()
            };

            return window;
        }
    }
}