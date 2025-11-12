namespace CadastroEventos.Views;
using System.Text.Json;
using CadastroEventos.Models;

[QueryProperty(nameof(EventoJson), "eventoJson")]
public partial class EventoCadastrado : ContentPage
{
	private Evento _evento;
	public string EventoJson
	{
		set
		{
			_evento = JsonSerializer.Deserialize<Evento>(Uri.UnescapeDataString(value));
			BindingContext = _evento;
		}
	}
	public EventoCadastrado()
	{
		InitializeComponent();

		
	}
}