using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutoImposto.Impostos
{
    public class ImpostoDAO : IImposto
    {
        private SqlConnection conexao = new Conexao.Connect().getConexao();

        List<Imposto> listaImpostos = new List<Imposto>();

        public bool Inserir(Imposto imposto)
        {
            string insert = "INSERT INTO Imposto(Nome,CodUsuario) VALUES (@nome,@codusuario)";
            SqlCommand comando = new SqlCommand(insert, this.conexao);
            comando.Parameters.Add(new SqlParameter("@nome", imposto.Nome));
            comando.Parameters.Add(new SqlParameter("@codusuario", imposto.CodUsuario));
            if (comando.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Deletar(Imposto imposto)
        {
            string delete = "DELETE FROM Imposto WHERE codUsuario = @codUsuario AND Id = @Id AND Nome = @nome ";
            SqlCommand comando = new SqlCommand(delete, this.conexao);
            comando.Parameters.Add(new SqlParameter("@codUsuario", imposto.CodUsuario));
            comando.Parameters.Add(new SqlParameter("@Id", imposto.Id));
            comando.Parameters.Add(new SqlParameter("@nome", imposto.Nome));
            if (comando.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Atualizar(Imposto imposto)
        {
            string atualizar = "UPDATE Imposto SET Nome = @nome WHERE Id = @id AND codUsuario = @idUsuario ";
            SqlCommand comando = new SqlCommand(atualizar, this.conexao);
            comando.Parameters.Add(new SqlParameter("@id", imposto.Id));
            comando.Parameters.Add(new SqlParameter("@nome", imposto.Nome));
            comando.Parameters.Add(new SqlParameter("@idUsuario", imposto.CodUsuario));
            if (comando.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Imposto> ListaImpostos(int Id)
        {
            string select = "SELECT * FROM Imposto WHERE CodUsuario = @codUsuario";
            SqlCommand comando = new SqlCommand(select, this.conexao);
            comando.Parameters.Add(new SqlParameter("@codUsuario", Id));
            SqlDataReader dr;
            dr = comando.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Imposto imposto = new Imposto(dr["Nome"].ToString(), Id, Convert.ToInt32(dr["Id"]));
                    this.listaImpostos.Add(imposto);
                }
            }
            return this.listaImpostos;

        }

        public int getIdImposto(string nome, string codUsuario)
        {
            string select = "SELECT id FROM imposto WHERE Nome = @nome AND codUsuario = @codUsuario";
            SqlCommand comando = new SqlCommand(select, this.conexao);
            comando.Parameters.Add(new SqlParameter("@nome", nome));
            comando.Parameters.Add(new SqlParameter("@codUsuario", codUsuario));
            SqlDataReader dr;
            dr = comando.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                int idImposto = Convert.ToInt32(dr["Id"]);
                dr.Close();
                return idImposto;

            }
            else
            {
                return 0;
            }
        }
    }
}