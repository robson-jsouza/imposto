<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AutoImposto._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="CadastroLogin">
    <div>Faça o login:</div>
    <div>Email:<asp:TextBox runat="server" ID="emaillogin" CssClass="featured" /></div>
    <div>Senha:<asp:TextBox runat="server" ID="senhalogin" TextMode="Password" /></div>
    <asp:Button Text="Login" ID="login" runat="server" OnClick="login_Click" />

    <asp:Panel ID="erro" runat="server" Visible="false">
        <%= this.msgerro %>
    </asp:Panel>

    <div>Cadastro:</div>
    <div>Nome:<asp:TextBox runat="server" ID="nome" /></div>
    <div>Email:<asp:TextBox runat="server" ID="email" /></div>
    <div>Senha:<asp:TextBox runat="server" ID="senha" TextMode="Password" /></div>
    <div>
        <asp:Button Text="Enviar" ID="btnCadastraUsuario" runat="server" OnClick="btnCadastraUsuario_Click" />
    </div>
</asp:Content>


