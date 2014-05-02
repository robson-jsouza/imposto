<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AutoImposto.Home.Home1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HomeContent" runat="server">
    <div><asp:HyperLink NavigateUrl="~/Home/CadastroEmpresa.aspx" Text="Cadastro de Empresas" runat="server" /></div>
    <div><asp:HyperLink NavigateUrl="~/Home/Editar/EditarEmpresa.aspx" Text="Editar Empresas" runat="server" /></div>
    <div><asp:HyperLink NavigateUrl="~/Home/CadastroImposto.aspx" Text="Cadastro de Impostos" runat="server" /></div>
    <div><asp:HyperLink NavigateUrl="~/Home/Editar/EditarImposto.aspx" Text="Editar Impostos" runat="server" /></div>
    <div><asp:HyperLink NavigateUrl="~/Home/CadastroCco.aspx" Text="Cadastrar/Editar Cópia Oculta Padrão" runat="server" /></div>
    <hr />
    <div><asp:HyperLink NavigateUrl="~/Home/EnviaEmail.aspx" Text="Enviar Email" runat="server" /></div>
</asp:Content>
