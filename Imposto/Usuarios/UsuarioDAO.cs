using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AutoImposto.Conexao;

namespace AutoImposto.Usuarios
{
    public class UsuarioDAO : IUsuario
    {
        private SqlConnection conexao = new Conexao.Connect().getConexao();
        public int id;
        public bool logado;

        public void Inserir(Usuario usuario)
        {
            string insert = "INSERT INTO Usuario(Nome,Email,Senha) VALUES (@nome,@email,@senha)";
            SqlCommand comando = new SqlCommand(insert, this.conexao);
            comando.Parameters.Add(new SqlParameter("@nome", usuario.Nome));
            comando.Parameters.Add(new SqlParameter("@email", usuario.Email));
            comando.Parameters.Add(new SqlParameter("@Senha", usuario.Senha));
            comando.ExecuteNonQuery();
            usuario.Id = getId(usuario);
        }

        public int getId(Usuario usuario)
        {
            string select = "SELECT * FROM Usuario WHERE Email = @email";
            SqlCommand comando = new SqlCommand(select, this.conexao);
            comando.Parameters.Add(new SqlParameter("@email", usuario.Email));
            SqlDataReader dr;
            dr = comando.ExecuteReader();

            int valor = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    valor = Convert.ToInt32(dr["Id"]);
                }
                this.id = valor;
                return valor;
            }
            else
            {
                return valor;
            }
        }

        public void Deletar(int Id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Receber(int Id)
        {
        }

        public Usuario verificaLogin(string email, string senha)
        {
            string select = "SELECT * FROM Usuario WHERE Email = @email AND Senha = @senha";
            SqlCommand comando = new SqlCommand(select, this.conexao);
            SqlDataReader dr;
            comando.Parameters.Add(new SqlParameter("@email", email));
            comando.Parameters.Add(new SqlParameter("@senha", senha));
            dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                Usuario usuario = new Usuario();
                if (dr.Read())
                {
                    usuario = new Usuario((int)dr["id"],(string)dr["nome"], (string)dr["email"],(string)dr["senha"]);
                }
                this.logado = true;
                return usuario;
            }
            else
            {
                Usuario usuario = new Usuario();
                return usuario;
            }

        }

        //public List<string> Listar()
        //{
        //    SqlCommand comando = new SqlCommand(this.select, this.conexao);
        //    SqlDataReader dr;
        //    dr = comando.ExecuteReader();

        //    List<string> algo = new List<string>();
        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            algo.Add(
        //            dr["Id"].ToString() + " - "
        //            + dr["Nome"].ToString() + " "
        //            + dr["Email"].ToString() + " "
        //            + dr["Senha"].ToString());
        //        }
        //    }
        //    return algo;


        //}
    }
}