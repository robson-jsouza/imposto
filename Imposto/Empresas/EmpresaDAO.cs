using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutoImposto.Empresas
{
    public class EmpresaDAO : IEmpresa
    {
        private SqlConnection conexao = new Conexao.Connect().getConexao();
        public Empresa empresa { get; set; }
        public List<Empresa> listaEmpresas = new List<Empresa>();

        public bool Inserir(Empresa empresa)
        {
            string insert = "INSERT INTO Empresa(Nome,Email,Cco,CodUsuario) VALUES (@nome,@email,@Cco,@codusuario)";
            SqlCommand comando = new SqlCommand(insert, this.conexao);
            comando.Parameters.Add(new SqlParameter("@nome", empresa.Nome));
            comando.Parameters.Add(new SqlParameter("@email", empresa.Email));
            comando.Parameters.Add(new SqlParameter("@Cco", empresa.Cco));
            comando.Parameters.Add(new SqlParameter("@codusuario", empresa.CodUsuario));
            if (comando.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Deletar(Empresa empresa)
        {
            string delete = "DELETE FROM Empresa WHERE codUsuario = @codUsuario AND Id = @Id AND Email = @email ";
            SqlCommand comando = new SqlCommand(delete, this.conexao);
            comando.Parameters.Add(new SqlParameter("@codUsuario", empresa.CodUsuario));
            comando.Parameters.Add(new SqlParameter("@Id", empresa.Id));
            comando.Parameters.Add(new SqlParameter("@email", empresa.Email));
            if (comando.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Atualizar(Empresa empresa)
        {
            string atualizar = "UPDATE Empresa SET Nome = @nome, Email = @email, Cco = @cco WHERE Id = @id AND codUsuario = @idUsuario ";
            SqlCommand comando = new SqlCommand(atualizar, this.conexao);
            comando.Parameters.Add(new SqlParameter("@id", empresa.Id));
            comando.Parameters.Add(new SqlParameter("@nome", empresa.Nome));
            comando.Parameters.Add(new SqlParameter("@email", empresa.Email));
            comando.Parameters.Add(new SqlParameter("@cco", empresa.Cco));
            comando.Parameters.Add(new SqlParameter("@idUsuario", empresa.CodUsuario));
            if (comando.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Empresa> ListaEmpresas(int Id)
        {
            string select = "SELECT * FROM Empresa WHERE CodUsuario = @codUsuario";
            SqlCommand comando = new SqlCommand(select, this.conexao);
            comando.Parameters.Add(new SqlParameter("@codUsuario", Id));
            SqlDataReader dr;
            dr = comando.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Empresa empresa = new Empresa(dr["Nome"].ToString(), dr["Email"].ToString(), Id, dr["Cco"].ToString(), Convert.ToInt32(dr["Id"]));
                    this.listaEmpresas.Add(empresa);
                }
                dr.Close();
                return this.listaEmpresas;
            }
            else
            {
                dr.Close();
                return null;
            }

        }

        public Empresa getEmpresa(int codUsuario, int Id)
        {
            string select = "SELECT * FROM Empresa WHERE CodUsuario = @codUsuario and Id = @id";
            SqlCommand comando = new SqlCommand(select, this.conexao);
            comando.Parameters.Add(new SqlParameter("@codUsuario", codUsuario));
            comando.Parameters.Add(new SqlParameter("@Id", Id));
            SqlDataReader dr;
            dr = comando.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                Empresa empresa = new Empresa(dr["Nome"].ToString(), dr["Email"].ToString(), codUsuario, dr["Cco"].ToString(), Convert.ToInt32(dr["Id"]));
                dr.Close();
                return empresa;
            }
            else
            {
                dr.Close();
                return null;
            }

        }

        public int getIdEmpresa(string email, string codUsuario)
        {
            string select = "SELECT id FROM empresa WHERE Email = @email and codUsuario = @codUsuario";
            SqlCommand comando = new SqlCommand(select, this.conexao);
            comando.Parameters.Add(new SqlParameter("@email", email));
            comando.Parameters.Add(new SqlParameter("@codUsuario", codUsuario));
            SqlDataReader dr;
            dr = comando.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                int idEmpresa = Convert.ToInt32(dr["Id"]);
                dr.Close();
                return idEmpresa;

            }
            else
            {
                dr.Close();
                return 0;
            }
        }
    }
}