using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoImposto.Impostos;
using AutoImposto.Usuarios;

namespace AutoImposto.Home.Editar
{
    public partial class EditarImposto : Session
    {
        public string mensagem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                carregaImposto();
            }
        }

        private void carregaImposto()
        {
            ImpostoDAO impostoDAO = new ImpostoDAO();
            ListItem l = new ListItem("Selecione");
            l.Selected = true;
            impostosEditar.Items.Add(l);
            foreach (var item in impostoDAO.ListaImpostos(this.user.Id))
            {
                string listItemText = item.Nome;
                string listItemValue = item.Nome;
                impostosEditar.Items.Add(new ListItem(listItemText, listItemValue));
            }
        }

        protected void impostosEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.impostosEditar.SelectedValue != "Selecione")
            {
                ImpostoDAO impostoDAO = new ImpostoDAO();

                this.labelImpostosEditar.Visible = true;
                this.nome.Visible = true;
                this.nome.Text = impostosEditar.SelectedItem.ToString();
            }
            else
            {
                this.labelImpostosEditar.Visible = false;
                this.nome.Visible = false;
            }
        }

        protected void btnEditarImposto_Click(object sender, EventArgs e)
        {
            ImpostoDAO impostoDAO = new ImpostoDAO();
            int idImpostoSelecionada = impostoDAO.getIdImposto(impostosEditar.SelectedValue, this.user.Id.ToString());
            Imposto imposto = new Imposto(this.nome.Text, this.user.Id, idImpostoSelecionada);

            if (impostoDAO.Atualizar(imposto))
            {
                this.mensagem = "Imposto Alterada com Sucesso";
                this.impostosEditar.Items.Clear();
                carregaImposto();
                this.labelImpostosEditar.Visible = false;
            }

        }

        protected void btnExcluirImposto_Click(object sender, EventArgs e)
        {
            ImpostoDAO impostoDAO = new ImpostoDAO();
            int idImpostoSelecionada = impostoDAO.getIdImposto(impostosEditar.SelectedValue, this.user.Id.ToString());
            Imposto imposto = new Imposto(this.nome.Text, this.user.Id, idImpostoSelecionada);
            if (impostoDAO.Deletar(imposto))
            {
                this.mensagem = "Imposto Deletada com Sucesso";
                this.impostosEditar.Items.Clear();
                carregaImposto();
                this.labelImpostosEditar.Visible = false;
            }
        }

    }

}