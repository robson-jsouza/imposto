<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Home/Home.Master" CodeBehind="CadastroEmpresa.aspx.cs" Inherits="AutoImposto.Home.CadastroEmpresa" %>


<asp:Content ID="Content2" ContentPlaceHolderID="HomeContent" runat="server">
    <div>Cadastro de Empresa:</div>
    <div>Nome:<asp:TextBox runat="server" ID="nome" /></div>
    <div>Email:<asp:TextBox runat="server" ID="email" /></div>
    <asp:CheckBox Text="Adicionar Cópia Oculta" runat="server" AutoPostBack="true" ID="adicionarCopiaOculta" OnCheckedChanged="adicionarCopiaOculta_CheckedChanged" />
    <asp:PlaceHolder runat="server" ID="exibeCco" Visible="false">
        <div>Cco:
            <asp:TextBox runat="server" ID="cco" /></div>
    </asp:PlaceHolder>
    <div>
        <asp:Button Text="Cadastrar" ID="btnCadastraEmpresa" runat="server" OnClick="btnCadastraEmpresa_Click" />
    </div>
    <div><%= this.mensagem %></div>
    <div>
        teste
        <asp:HyperLink NavigateUrl="~/Home/Home.aspx" Text="Voltar" runat="server" />
    </div>
</asp:Content>
