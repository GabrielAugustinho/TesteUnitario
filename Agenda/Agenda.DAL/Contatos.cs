using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Agenda.Domain;
using Dapper;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;
        SqlConnection _conn;

        public Contatos()
        {
            _strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            _conn = new SqlConnection(_strCon);
        }

        public void Adicionar(Contato contato)
        {
            using (var con = new SqlConnection(_strCon))
            {
                con.Execute("insert into Contato (Id, Nome) values (@Id, @Nome)", contato);
            }
        }

        public Contato Obter(Guid id)
        {
            Contato contato;
            using (var con = new SqlConnection(_strCon))
            {
                contato = con.QueryFirst<Contato>("select Id, Nome from Contato where Id = @Id", new { Id = id });
            }
            return contato;
        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strCon))
            {
                // Dapper substitui toda a conexão a mão.
                contatos = con.Query<Contato>("select Id, Nome from Contato;").ToList();

                //con.Open();

                //var sql = String.Format("select Id, Nome from Contato;");

                //var cmd = new SqlCommand(sql, con);

                //var sqlDataReader = cmd.ExecuteReader();
                //while (sqlDataReader.Read())
                //{
                //    var contato = new Contato()
                //    {
                //        Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                //        Nome = sqlDataReader["Nome"].ToString()
                //    };
                //    contatos.Add(contato);
                //}
            }

            return contatos;
        }
    }
}
