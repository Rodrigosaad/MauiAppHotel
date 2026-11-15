using MauiAppHotel.Models;

namespace MauiAppHotel.Models
{
    public class ContratacaoHospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        // Propriedade calculada para a quantidade de dias
        public int DuracaoEstadia 
        {
            get => (DataCheckOut - DataCheckIn).Days;
        }

        // Propriedade calculada para o valor total da hospedagem
        public decimal ValorTotal
        {
            get
            {
                decimal valorAdultos = QuantidadeAdultos * QuartoSelecionado.ValorDiariaAdulto;
                decimal valorCriancas = QuantidadeCriancas * QuartoSelecionado.ValorDiariaCrianca;
                
                decimal totalDia = valorAdultos + valorCriancas;
                return totalDia * DuracaoEstadia;
            }
        }
    }
}
