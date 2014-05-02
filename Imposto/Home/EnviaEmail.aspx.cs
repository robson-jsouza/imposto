using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AutoImposto.CCOs;
using AutoImposto.Empresas;
using AutoImposto.Impostos;
using AutoImposto.Usuarios;

namespace AutoImposto.Home
{
    public partial class EnviaEmail : Session
    {
        public string mensagemParaEnvio;
        public string assuntoPreview;
        public string conteudoPreview;
        public string emailPreview;
        public string ccoPreview;
        public string ccoPadraoPreview;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                preencheCampoEmpresa();
                preencheCampoImposto();
                preencheCampoDias();
                preencheCampoAno();
                hasCcoPadrao();
            }
        }

        protected void montarEmail_Click(object sender, EventArgs e)
        {
            int qtdSelecoes = 0;
            foreach (ListItem item in this.escolheImposto.Items)
            {
                if (item.Selected)
                {
                    qtdSelecoes += 1;
                }
            }
            if (qtdSelecoes > 0)
            {
                this.selecioneUmImposto.Visible = false;
                this.linkEnviarEmail.Visible = true;
                StringBuilder mensagemCompleta = new StringBuilder();
                mensagemCompleta.Append("mailto:");
                mensagemCompleta.Append(geraEmail());
                if (geraCco() != "" || geraCcoPadrao() != "")
                {
                    mensagemCompleta.Append("&bcc=");
                    if (geraCco() != "")
                    {
                        mensagemCompleta.Append(geraCco() + ";");
                    }
                    if (geraCcoPadrao() != "")
                    {
                        mensagemCompleta.Append(geraCcoPadrao() + ";");
                    }
                }
                mensagemCompleta.Append("?subject=");
                mensagemCompleta.Append(geraAssunto());
                mensagemCompleta.Append("&amp;body=");
                mensagemCompleta.Append(geraConteudo());

                this.mensagemParaEnvio = mensagemCompleta.ToString();
            }
            else
            {
                this.linkEnviarEmail.Visible = false;
                this.selecioneUmImposto.Visible = true;
            }
        }

        protected void semDataReferencia_CheckedChanged(object sender, EventArgs e)
        {
            this.linkEnviarEmail.Visible = false;
            if (this.semDataReferencia.Checked == true)
            {
                this.escolheMesReferencia.Enabled = false;
                this.escolheAnoReferencia.Enabled = false;
            }
            else
            {
                this.escolheMesReferencia.Enabled = true;
                this.escolheAnoReferencia.Enabled = true;
            }
        }

        protected void semDataVencimento_CheckedChanged(object sender, EventArgs e)
        {
            this.linkEnviarEmail.Visible = false;
            if (this.semDataVencimento.Checked == true)
            {
                this.escolheAnoVencimento.Enabled = false;
                this.escolheDiaVencimento.Enabled = false;
                this.escolheMesVencimento.Enabled = false;
            }
            else
            {
                this.escolheAnoVencimento.Enabled = true;
                this.escolheDiaVencimento.Enabled = true;
                this.escolheMesVencimento.Enabled = true;
            }
        }

        protected void escolheEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            Empresa empresa = empresaDAO.getEmpresa(this.user.Id, Convert.ToInt32(escolheEmpresa.SelectedValue));

            this.linkEnviarEmail.Visible = false;
        }

        private void preencheCampoEmpresa()
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            List<Empresa> listaEmpresa = empresaDAO.ListaEmpresas(this.user.Id);
            if (listaEmpresa != null)
            {
                this.labelempresa.Visible = true;
                foreach (var item in listaEmpresa)
                {
                    string listItemText = item.Nome;
                    string listItemValue = item.Id.ToString();
                    escolheEmpresa.Items.Add(new ListItem(listItemText, listItemValue));
                }
            }

            else
            {
                this.semEmpresa.Visible = true;
                this.cadastreEmail.Visible = true;
                this.montarEmail.Visible = false;
            }
        }

        private void preencheCampoImposto()
        {
            ImpostoDAO impostoDAO = new ImpostoDAO();
            List<Imposto> listaImpostos = impostoDAO.ListaImpostos(this.user.Id);
            if (listaImpostos.Count > 0)
            {
                foreach (var item in listaImpostos)
                {
                    string listItemText = item.Nome;
                    escolheImposto.Items.Add(new ListItem(listItemText, listItemText));
                }
                this.escolheImposto.Visible = true;
            }
            else
            {
                this.semImpostos.Visible = true;
                this.cadastreImposto.Visible = true;
                this.montarEmail.Visible = false;
            }
        }

        private void preencheCampoDias()
        {
            for (int i = 1; i <= 31; i++)
            {
                if (i > 0 && i < 10)
                {
                    escolheDiaVencimento.Items.Add(new ListItem("0" + i.ToString()));
                }
                else
                {
                    escolheDiaVencimento.Items.Add(new ListItem(i.ToString()));
                }
            }
        }

        private void preencheCampoAno()
        {
            for (int i = 2010; i <= 2017; i++)
            {
                if (i == 2014)
                {
                    escolheAnoVencimento.Items.Add(new ListItem(i.ToString()));
                    escolheAnoVencimento.Items.FindByValue("2014").Selected = true;

                    escolheAnoReferencia.Items.Add(new ListItem(i.ToString()));
                    escolheAnoReferencia.Items.FindByValue("2014").Selected = true;
                }

                else
                {
                    escolheAnoReferencia.Items.Add(new ListItem(i.ToString()));
                    escolheAnoVencimento.Items.Add(new ListItem(i.ToString()));
                }

            }
        }

        private string geraEmail()
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            Empresa empresa = empresaDAO.getEmpresa(this.user.Id, Convert.ToInt32(escolheEmpresa.SelectedValue));

            this.emailPreview = empresa.Email;
            return empresa.Email;
        }

        private string geraCco()
        {
            EmpresaDAO empresaDAO = new EmpresaDAO();
            Empresa empresa = empresaDAO.getEmpresa(this.user.Id, Convert.ToInt32(escolheEmpresa.SelectedValue));
            if (empresa.Cco != "")
            {
                this.ccoPreview = empresa.Cco;
            }
            return empresa.Cco;
        }

        private string geraCcoPadrao()
        {
            CcoDAO ccoDAO = new CcoDAO();
            string ccoPadrao = ccoDAO.getCco(this.user.Id);
            if (ccoPadrao == "" || this.checkCcoPadrao.Checked == false)
            {
                return "";
            }
            else
            {
                this.ccoPadraoPreview = ccoPadrao;
                return ccoPadrao;
            }
        }

        private string geraAssunto()
        {
            StringBuilder assunto = new StringBuilder();
            assunto.Append("Guia de ");
            List<ListItem> selected = escolheImposto.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            for (int i = 0; i < selected.Count; i++)
            {
                int contador = selected.Count - i;
                if (contador == 1)
                {
                    assunto.Append(selected[i]);
                }
                else if (contador > 1)
                {
                    assunto.Append(selected[i] + ", ");
                }
            }
            if (this.semDataReferencia.Checked != true)
            {
                assunto.Append(" ref. ");
                assunto.Append(escolheMesReferencia.SelectedValue + "/");
                assunto.Append(escolheAnoReferencia.SelectedValue);
            }
            assunto.Append(" [" + escolheEmpresa.SelectedItem + "]");
            this.assuntoPreview = assunto.ToString();
            return assunto.ToString();
        }

        private string geraConteudo()
        {
            StringBuilder conteudo = new StringBuilder();
            List<ListItem> selected = escolheImposto.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            conteudo.Append(geraMensagemHoras());
            conteudo.Append("Segue anexo a guia de ");
            for (int i = 0; i < selected.Count; i++)
            {
                int contador = selected.Count - i;
                if (contador == 1)
                {
                    conteudo.Append(selected[i]);
                }
                else if (contador == 2)
                {
                    conteudo.Append(selected[i] + " e ");
                }

                else if (contador > 2)
                {
                    conteudo.Append(selected[i] + ", ");
                }
            }
            if (this.semDataReferencia.Checked != true)
            {
                conteudo.Append(" referente o mês de ");
                conteudo.Append(escolheMesReferencia.SelectedItem + "/");
                conteudo.Append(escolheAnoReferencia.SelectedValue);
            }

            if (this.semDataVencimento.Checked != true)
            {
                conteudo.Append(" com vencimento para ");
                conteudo.Append(escolheDiaVencimento.SelectedValue + " de ");
                conteudo.Append(escolheMesVencimento.SelectedItem + " de ");
                conteudo.Append(escolheAnoVencimento.SelectedValue);
            }
            conteudo.Append(".");
            conteudo.Append(" Favor confirmar o recebimento do e-mail.");

            this.conteudoPreview = conteudo.ToString();
            return conteudo.ToString();
        }

        private string geraMensagemHoras()
        {
            int horas = Convert.ToInt32(DateTime.Now.Hour);
            if (horas > 5 && horas < 13)
            {
                return "Bom dia,";
            }
            else
            {
                return "Boa tarde,";
            }
        }

        private void hasCcoPadrao()
        {
            CcoDAO ccoDAO = new CcoDAO();
            string hasCco = ccoDAO.getCco(user.Id);
            if (hasCco != "")
            {
                this.checkCcoPadrao.Visible = true;
            }
        }

    }
}