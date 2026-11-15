using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ResumoHospedagemPage : ContentPage
{
    public ResumoHospedagemPage(ContratacaoHospedagem contratacao)
    {
        InitializeComponent();

        // Exibe os dados nos componentes visuais
        lblQuarto.Text = $"Suíte: {contratacao.QuartoSelecionado.Descricao}";
        lblAdultos.Text = $"Hóspedes (Adultos): {contratacao.QuantidadeAdultos}";
        lblCriancas.Text = $"Hóspedes (Crianças): {contratacao.QuantidadeCriancas}";
        lblCheckIn.Text = $"Check-in: {contratacao.DataCheckIn:dd/MM/yyyy}";
        lblCheckOut.Text = $"Check-out: {contratacao.DataCheckOut:dd/MM/yyyy}";
        lblDias.Text = $"Dias de Estadia: {contratacao.DuracaoEstadia}";
        lblValorTotal.Text = $"R$ {contratacao.ValorTotal:F2}";
    }

    private void Button_Voltar_Clicked(object sender, EventArgs e)
    {
        // Retorna para a página anterior
        Navigation.PopAsync();
    }
}
