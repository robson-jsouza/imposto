using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoImposto.Empresas;
using AutoImposto.Usuarios;

namespace AutoImposto.Home
{
    public partial class CadastroEmpresa : Session
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        public string mensagem;

        protected void btnCadastraEmpresa_Click(object sender, EventArgs e)
        {
            Empresa empresa = new Empresa(this.nome.Text, this.email.Text, this.cco.Text, this.user.Id);
            EmpresaDAO empresaDAO = new EmpresaDAO();
            if (empresaDAO.Inserir(empresa))
            {
                this.mensagem = "Empresa cadastrada com sucesso";
                this.nome.Text = string.Empty;
                this.email.Text = string.Empty;
                this.cco.Text = string.Empty;
            }

        }

        protected void adicionarCopiaOculta_CheckedChanged(object sender, EventArgs e)
        {
            if (this.adicionarCopiaOculta.Checked)
            {
                this.exibeCco.Visible = true;
            }
            else
            {
                this.cco.Text = string.Empty;
                this.exibeCco.Visible = false;
            }
        }
    }
}