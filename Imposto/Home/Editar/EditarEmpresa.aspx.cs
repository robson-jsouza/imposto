using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoImposto.Empresas;
using AutoImposto.Usuarios;

namespace AutoImposto.Home.Editar
{
    public partial class EditarEmpresa : Session
    {

        public string mensagem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                carregaEmpresa();
            }
        }

        private void carregaEmpresa()
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            ListItem l = new ListItem("Selecione");
            l.Selected = true;
            empresasEditar.Items.Add(l);
            List<Empresa> lista = empresaDAO.ListaEmpresas(this.user.Id);
            if (lista != null)
            {
                foreach (var item in lista)
                {
                    string listItemText = item.Nome;
                    string listItemValue = item.Email;
                    empresasEditar.Items.Add(new ListItem(listItemText, listItemValue));
                }
            }

        }

        protected void empresasEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.empresasEditar.SelectedValue != "Selecione")
            {
                hasCopiaOculta();
                EmpresaDAO empresaDAO = new EmpresaDAO();
                this.labelEmpresasEditar.Visible = true;
                this.nome.Visible = true;
                this.nome.Text = empresasEditar.SelectedItem.ToString();
                this.email.Text = empresasEditar.SelectedValue;

            }
            else
            {
                this.labelEmpresasEditar.Visible = false;
                this.nome.Visible = false;
            }
        }

        protected void btnEditarEmpresa_Click(object sender, EventArgs e)
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            int idEmpresaSelecionada = empresaDAO.getIdEmpresa(empresasEditar.SelectedValue, this.user.Id.ToString());
            Empresa empresa = new Empresa(this.nome.Text, this.email.Text, this.user.Id, this.cco.Text, idEmpresaSelecionada);

            if (empresaDAO.Atualizar(empresa))
            {
                this.mensagem = "Empresa Alterada com Sucesso";
                this.empresasEditar.Items.Clear();
                carregaEmpresa();
                this.labelEmpresasEditar.Visible = false;
            }

        }

        protected void btnExcluirEmpresa_Click(object sender, EventArgs e)
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            int idEmpresaSelecionada = empresaDAO.getIdEmpresa(empresasEditar.SelectedValue, this.user.Id.ToString());
            Empresa empresa = new Empresa(this.nome.Text, this.email.Text, this.user.Id, idEmpresaSelecionada);
            if (empresaDAO.Deletar(empresa))
            {
                this.mensagem = "Empresa Deletada com Sucesso";
                this.empresasEditar.Items.Clear();
                carregaEmpresa();
                this.labelEmpresasEditar.Visible = false;
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

        private void hasCopiaOculta()
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            int idEmpresaSelecionada = empresaDAO.getIdEmpresa(empresasEditar.SelectedValue, this.user.Id.ToString());
            Empresa empresa = empresaDAO.getEmpresa(this.user.Id, idEmpresaSelecionada);
            if (empresa.Cco != "")
            {
                this.adicionarCopiaOculta.Checked = true;
                this.exibeCco.Visible = true;
                this.cco.Text = empresaDAO.getEmpresa(this.user.Id, idEmpresaSelecionada).Cco;
            }
            else
            {
                this.adicionarCopiaOculta.Checked = false;
                this.exibeCco.Visible = false;
                this.cco.Text = string.Empty;
            }


        }


    }
}