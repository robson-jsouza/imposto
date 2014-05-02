<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="CadastroCco.aspx.cs" Inherits="AutoImposto.Home.CadastrarCco" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HomeContent" runat="server">
    <div>Cadastrar Cco Padrão:</div>
    <div>
        Email:<asp:TextBox runat="server" ID="email" />
    </div>
    <div>
        <asp:Button Text="Cadastrar" ID="cadastrarCco" OnClick="cadastrarCco_Click" runat="server" />
    </div>
    <%= mensagem %>
    <div><asp:HyperLink ID="HyperLink1" NavigateUrl="~/Home/Home.aspx" Text="Voltar" runat="server" /></div>
</asp:Content>
