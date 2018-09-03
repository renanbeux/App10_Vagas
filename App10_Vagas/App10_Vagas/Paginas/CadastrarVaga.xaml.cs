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
	public partial class CadastrarVaga : ContentPage
	{
		public CadastrarVaga()
		{
			InitializeComponent();
		}

        public void SalvarAction(object sender, EventArgs args)
        {
            Vaga vaga = new Vaga();
            vaga.NomeVaga = NomeVaga.Text;
            vaga.Empresa = Empresa.Text;
            vaga.Quantidade = short.Parse(Quantidade.Text);
            vaga.Cidade = Cidade.Text;
            vaga.Salario = double.Parse(Salario.Text);
            vaga.Descricao = Descricao.Text;
            vaga.TipoContratacao = (TipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = Telefone.Text;
            vaga.Email = Email.Text;

            Database database = new Database();
            database.Cadastro(vaga);

            // Volta a pagina
            App.Current.MainPage = new NavigationPage(new ConsultarVagas());
        }

    }
}