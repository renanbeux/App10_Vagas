﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App10_Vagas.Banco;
using App10_Vagas.Modelos;

namespace App10_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarVaga : ContentPage
	{
        private Vaga vaga { get; set; }

		public EditarVaga(Vaga vaga)
		{
			InitializeComponent();

            this.vaga = vaga;
            NomeVaga.Text = vaga.NomeVaga;
            Empresa.Text = vaga.Empresa;
            Quantidade.Text = vaga.Quantidade.ToString();
            Cidade.Text = vaga.Cidade;
            Salario.Text = vaga.Salario.ToString();
            Descricao.Text = vaga.Descricao;
            TipoContratacao.IsToggled = (vaga.TipoContratacao == "CLT") ? false : true;
            Telefone.Text = vaga.Telefone;
            Email.Text = vaga.Email;
		}

        public void SalvarAction(object sender, EventArgs args)
        {
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
            database.Atualizacao(vaga);

            // Volta a pagina
            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());
        }
	}
}