using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoImposto.Impostos;
using AutoImposto.Usuarios;

namespace AutoImposto.Home
{
    public partial class CadastroImposto : Session
    {
        public string mensagem;

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected void btnCadastraImposto_Click(object sender, EventArgs e)
        {
            Imposto imposto = new Imposto(this.nome.Text, this.user.Id);
            ImpostoDAO impostoDAO = new ImpostoDAO();
            if (impostoDAO.Inserir(imposto))
            {
                this.nome.Text = string.Empty;
                this.mensagem = "Imposto Cadastrado com Sucesso";
            }
        }
    }
}