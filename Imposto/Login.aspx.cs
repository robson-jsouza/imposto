using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoImposto.Usuarios;
using AutoImposto.Empresas;

namespace AutoImposto
{
    public partial class _Default : Page
    {
        public string msgerro;

        protected void Page_Load(object sender, EventArgs e)
        {
               
        } 

        protected void btnCadastraUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(this.nome.Text, this.email.Text, this.senha.Text);
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.Inserir(usuario);
            criaSessao(usuario);
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void login_Click(object sender, EventArgs e)
        {
            
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            Usuario usuario = usuarioDAO.verificaLogin(this.emaillogin.Text, this.senhalogin.Text);
            if (usuarioDAO.logado)
            {
                criaSessao(usuario);
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                this.msgerro = "Usuário ou senha Inválido";
                this.erro.Visible = true;
            };
        }

        private void criaSessao(Usuario usuario)
        {
            Session["usuario"] = usuario;
        }
    }
}