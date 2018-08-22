using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App10_Vagas.Modelos;

namespace App10_Vagas.Banco
{
    class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            
            _conexao = new SQLiteConnection();
        }

        public void Cadastro(Vaga vaga)
        {

        }

        public List<Vaga> Consultar()
        {
            return null;
        }

        public Vaga ObterVagaPorId(int id)
        {
            return null;
        }

        public void Atualizacao(Vaga vaga)
        {

        }

        public void Exclusao(int id)
        {

        }
    }
}
