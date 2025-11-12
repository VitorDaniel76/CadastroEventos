using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroEventos.Models
{
    public class Evento
    {
        public string NomeEvento { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public string Local { get; set; }

        public double CustoParticipante { get; set; }

        public int NumeroParticipantes { get; set; }

        public double ValorTotal
        {
            get
            {
                double total = CustoParticipante * NumeroParticipantes;
                return total;
            }
        }
    }
}
