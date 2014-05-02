using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AutoImposto.Usuarios;

namespace AutoImposto.CCOs
{
    public class CcoDAO : ICco
    {
        private SqlConnection conexao = new Conexao.Connect().getConexao();

        public bool Inserir(Cco cco)
        {
            string inserir = "INSERT INTO Cco(Email,CodUsuario) VALUES (@cco, @codusuario)";
            SqlCommand comando = new SqlCommand(inserir, this.conexao);
            comando.Parameters.Add(new SqlParameter("@cco", cco.Email));
            comando.Parameters.Add(new SqlParameter("@codusuario", cco.CodUsuario));
            if (comando.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Deletar(Cco cco)
        {
            throw new NotImplementedException();
        }

        public bool Atualizar(Cco cco)
        {
            string atualizar = "UPDATE Cco SET Email = @email WHERE codUsuario = @codusuario";
            SqlCommand comando = new SqlCommand(atualizar, this.conexao);
            comando.Parameters.Add(new SqlParameter("@email", cco.Email));
            comando.Parameters.Add(new SqlParameter("@codusuario", cco.CodUsuario));
            if (comando.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getCco(int CodUsuario)
        {
            string select = "SELECT * FROM Cco WHERE codUsuario = @codusuario";
            SqlCommand comando = new SqlCommand(select, this.conexao);
            comando.Parameters.Add(new SqlParameter("@codusuario",CodUsuario));
            SqlDataReader dr;
            dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                return dr["Email"].ToString();
            }
            else
            {
                return "";
            }
        }

        public bool verificaInserirOuAtualizar(Cco cco)
        {
            string select = "SELECT count(*) FROM Cco WHERE codUsuario = @codusuario";
            SqlCommand comando = new SqlCommand(select, this.conexao);
            comando.Parameters.Add(new SqlParameter("@codusuario", cco.CodUsuario));
            bool valido = false;
            if ((int)comando.ExecuteScalar() > 0)
            {
                if (Atualizar(cco))
                {
                    valido = true;
                }
            }
            else if (Inserir(cco))
            {
                valido = true;
            }
            else
            {
                valido = false;
            }
            return valido;
        }
    }
}