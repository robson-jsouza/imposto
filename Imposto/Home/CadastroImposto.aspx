<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="CadastroImposto.aspx.cs" Inherits="AutoImposto.Home.CadastroImposto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HomeContent" runat="server">
    <div>Cadastro de Imposto:</div>
    <div>Nome:<asp:TextBox runat="server" ID="nome" /></div>
    <div>
        <asp:Button Text="Cadastrar" ID="btnCadastraImposto" runat="server" OnClick="btnCadastraImposto_Click" />
    </div>
    <div><%= this.mensagem %></div>
    <div>
        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Home/Home.aspx" Text="Voltar" runat="server" />
    </div>
</asp:Content>
