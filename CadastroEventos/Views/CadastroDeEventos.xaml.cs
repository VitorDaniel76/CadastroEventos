using CadastroEventos.Models;
using System.Text.Json;
namespace CadastroEventos.Views;

public partial class CadastroDeEventos : ContentPage
{
	App PropriedadesApp;
	public CadastroDeEventos()
	{
		InitializeComponent();

		PropriedadesApp = (App)Application.Current;

		dtpck_inicio.MinimumDate = DateTime.Now;
        dtpck_inicio.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_termino.MinimumDate = dtpck_inicio.Date.AddDays(1);
		dtpck_termino.MaximumDate = dtpck_inicio.Date.AddMonths(1);
	}

    private void Dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
		DatePicker datePicker = sender as DatePicker;

		DateTime data_selecionada_inicio = datePicker.Date;

		dtpck_termino.MinimumDate = data_selecionada_inicio.AddDays(1);
		dtpck_termino.MinimumDate = data_selecionada_inicio.AddMonths(1);
    }

    private async void Cadastrar_Clicked(object sender, EventArgs e)
    {
        try
        {
            Evento evento = new Evento()
            {
                NomeEvento = entry_evento.Text,
                DataInicio = dtpck_inicio.Date,
                DataTermino = dtpck_termino.Date,
                Local = entry_local.Text,
                NumeroParticipantes = Convert.ToInt32(stp_participantes.Value)
        
            };

            string custoTexto = entry_custo.Text;

            if (double.TryParse(custoTexto, System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), out double custo))
            {
                evento.CustoParticipante = custo;
            }
            else
            {
                await DisplayAlert("Erro", "Digite um número válido", "Ok");
                return;
            }

            string eventoJson = JsonSerializer.Serialize(evento);

            await Shell.Current.GoToAsync($"{nameof(EventoCadastrado)}?eventoJson={Uri.EscapeDataString(eventoJson)}");
        }
        catch (Exception ex)
        {
           await DisplayAlert("Erro", ex.Message, "Ok");
        }
		
    }
}