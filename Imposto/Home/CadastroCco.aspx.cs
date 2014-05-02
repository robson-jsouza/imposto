using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoImposto.Usuarios;
using AutoImposto.CCOs;

namespace AutoImposto.Home
{
    public partial class CadastrarCco : Session
    {
        protected string mensagem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaCampoCco();
            }
        }

        protected void cadastrarCco_Click(object sender, EventArgs e)
        {
            Cco cco = new Cco(this.email.Text,this.user.Id);
            CcoDAO ccoDAO = new CcoDAO();
            if (ccoDAO.verificaInserirOuAtualizar(cco))
            {
                this.mensagem = "O email de cópia oculta padrão foi cadastrado";
            }
        }

        public void carregaCampoCco()
        {
            CcoDAO ccoDAO = new CcoDAO();
            string emailCco = ccoDAO.getCco(user.Id);
            if (emailCco != "")
            {
                this.email.Text = emailCco;
            }
        }
    }
}