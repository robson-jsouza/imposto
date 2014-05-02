<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="EditarImposto.aspx.cs" Inherits="AutoImposto.Home.Editar.EditarImposto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HomeContent" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div>Editar Imposto:</div>
            <div>
                <asp:DropDownList OnSelectedIndexChanged="impostosEditar_SelectedIndexChanged" AutoPostBack="true" runat="server" ID="impostosEditar">
                </asp:DropDownList> 
            </div>
            <asp:Panel runat="server" ID="labelImpostosEditar" Visible="false">
                <div>Nome:<asp:TextBox runat="server" ID="nome" Visible="false" /></div>
                <div>
                    <asp:Button Text="Editar" ID="btnEditarImposto" OnClick="btnEditarImposto_Click" runat="server" />
                    <asp:Button Text="Excluir" ID="btnExcluirImposto" OnClick="btnExcluirImposto_Click" runat="server" />
                </div>
            </asp:Panel>
            <%= this.mensagem %>
            <div>
                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Home/Home.aspx" Text="Voltar" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
