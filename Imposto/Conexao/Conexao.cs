using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutoImposto.Conexao
{
    public class Connect
    {
        private SqlConnection criaConexao()
        {
            string strcon = System.Configuration.ConfigurationManager.ConnectionStrings["Conexao"].ConnectionString;

            SqlConnection conexao = new SqlConnection(strcon);
            conexao.Open();
            return conexao;
        }

        public SqlConnection getConexao() 
        {
            return criaConexao();
        }
    }
}