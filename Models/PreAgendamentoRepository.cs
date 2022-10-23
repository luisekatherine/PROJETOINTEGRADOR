using System.Reflection.Metadata;
using System.Data;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using MySqlConnector;

namespace PROJETOINTEGRADOR.Models{

    public class PreAgendamentoRepository
    {
        private const string DadosConexao = "Database=projetointegrador; Data Source=localhost; User Id=root;";

        public void TestarConexao()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Oba! O banco de dados está funcionando!");
            Conexao.Close();
        }

        public void Inserir(PreAgendamento agenda)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "INSERT INTO agendamentos(Nome, Telefone, Destino, DataDesejada, Passaporte) VALUES (@Nome, @Telefone, @Destino, @DataDesejada, @Passaporte)"; 
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Nome", agenda.Nome);
            Comando.Parameters.AddWithValue("@Telefone", agenda.Telefone); 
            Comando.Parameters.AddWithValue("@Destino", agenda.Destino);
            Comando.Parameters.AddWithValue("@DataDesejada", agenda.DataDesejada);
            Comando.Parameters.AddWithValue("@Passaporte", agenda.Passaporte);
            Comando.ExecuteNonQuery();
            Conexao.Close();
            }

        public List<PreAgendamento> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            string Query = "SELECT * FROM agendamentos"; 
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();
            List<PreAgendamento> ListaAgendamento = new List<PreAgendamento>();
            
            while(Reader.Read())
            {
                PreAgendamento agendamentos = new PreAgendamento();

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    agendamentos.Nome = Reader.GetString("Nome"); 
                if(!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
                    agendamentos.Telefone = Reader.GetString("Telefone");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Destino")))
                    agendamentos.Destino = Reader.GetString("Destino");
                if(!Reader.IsDBNull(Reader.GetOrdinal("DataDesejada")))
                    agendamentos.DataDesejada = Reader.GetDateTime("DataDesejada");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Passaporte")))
                    agendamentos.Passaporte = Reader.GetString("Passaporte");
                    

            ListaAgendamento.Add(agendamentos);
            
            }
            Conexao.Close(); 
            return ListaAgendamento;
            }
    }


}