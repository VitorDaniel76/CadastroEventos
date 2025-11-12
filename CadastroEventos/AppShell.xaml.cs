using CadastroEventos.Views;

namespace CadastroEventos
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EventoCadastrado), typeof(EventoCadastrado));
        }
    }
}
