using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App10_Vagas.Modelos;
using App10_Vagas.Banco;

namespace App10_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MinhasVagasCadastradas : ContentPage
    {
        List<Vaga> Lista { get; set; }

        public MinhasVagasCadastradas()
        {
            InitializeComponent();
            ConsultarVagas();
        }

        private void ConsultarVagas()
        {
            Database database = new Database();
            Lista = database.Consultar();
            ListaVagas.ItemsSource = database.Consultar();

            lblCount.Text = Lista.Count.ToString() + " Vagas encontradas";
        }

        public void EditarAction(object sender, EventArgs args)
        {
            Label lblEditar = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];
            Vaga vaga = tapGest.CommandParameter as Vaga;
            Navigation.PushAsync(new EditarVaga(vaga));
        }

        public void ExcluirAction(object sender, EventArgs args)
        {
            Label lblExcluir = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblExcluir.GestureRecognizers[0];
            Vaga vaga = tapGest.CommandParameter as Vaga;            

            Database database = new Database();
            database.Exclusao(vaga);
            ConsultarVagas();
        }

        public void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.Contains(args.NewTextValue)).ToList();
        }

    }
}