using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class MainPage : ContentPage
{
    // Lista de quartos disponíveis para o Picker
    List<Quarto> lista_quartos = new List<Quarto>
    {
        new Quarto
        {
            Descricao = "Suíte Luxo",
            ValorDiariaAdulto = 110.0m,
            ValorDiariaCrianca = 55.0m
        },
        new Quarto
        {
            Descricao = "Suíte Single",
            ValorDiariaAdulto = 80.0m,
            ValorDiariaCrianca = 40.0m
        },
        new Quarto
        {
            Descricao = "Suíte Casal",
            ValorDiariaAdulto = 100.0m,
            ValorDiariaCrianca = 50.0m
        },
        new Quarto
        {
            Descricao = "Suíte Família",
            ValorDiariaAdulto = 150.0m,
            ValorDiariaCrianca = 75.0m
        }
    };

    public MainPage()
    {
        InitializeComponent();

        // Popula o Picker com a lista de quartos
        pickerQuarto.ItemsSource = lista_quartos;

        // Define a data mínima de check-in como hoje
        dtpCheckIn.MinimumDate = DateTime.Now;
        // Define a data máxima de check-in para daqui a 1 ano
        dtpCheckIn.MaximumDate = DateTime.Now.AddYears(1);

        // Define a data mínima de check-out (pelo menos 1 dia após o check-in)
        dtpCheckOut.MinimumDate = DateTime.Now.AddDays(1);
        dtpCheckOut.MaximumDate = DateTime.Now.AddYears(1).AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Valida se o quarto foi selecionado
            if (pickerQuarto.SelectedItem == null)
            {
                await DisplayAlert("Aviso", "Por favor, selecione uma suíte.", "OK");
                return;
            }

            // Cria o objeto de contratação com os dados preenchidos na tela
            ContratacaoHospedagem contratacao = new ContratacaoHospedagem
            {
                QuartoSelecionado = (Quarto)pickerQuarto.SelectedItem,
                QuantidadeAdultos = (int)stpAdultos.Value,
                QuantidadeCriancas = (int)stpCriancas.Value,
                DataCheckIn = dtpCheckIn.Date,
                DataCheckOut = dtpCheckOut.Date
            };

            // Validação de datas
            if (contratacao.DuracaoEstadia <= 0)
            {
                await DisplayAlert("Erro", "A data de Check-out deve ser posterior à data de Check-in.", "OK");
                return;
            }

            // Navega para a página de resumo enviando os dados da contratação
            await Navigation.PushAsync(new ResumoHospedagemPage(contratacao));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpCheckIn_DateSelected(object sender, DateChangedEventArgs e)
    {
        // Garante que o Check-out seja sempre pelo menos 1 dia depois do novo Check-in
        DateTime dataSelecionada = e.NewDate;
        dtpCheckOut.MinimumDate = dataSelecionada.AddDays(1);
        dtpCheckOut.Date = dataSelecionada.AddDays(1);
    }

    private void stpAdultos_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // Evento disparado ao alterar o stepper de adultos, caso queira algum tratamento extra
    }

    private void stpCriancas_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // Evento disparado ao alterar o stepper de crianças
    }
}

