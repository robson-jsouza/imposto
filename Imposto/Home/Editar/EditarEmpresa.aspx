<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="EditarEmpresa.aspx.cs" Inherits="AutoImposto.Home.Editar.EditarEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="HomeContent" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div>Editar Empresa:</div>
            <div>
                <asp:DropDownList OnSelectedIndexChanged="empresasEditar_SelectedIndexChanged" AutoPostBack="true" runat="server" ID="empresasEditar">
                </asp:DropDownList>
            </div>
            <asp:Panel runat="server" ID="labelEmpresasEditar" Visible="false">
                <div>Nome:<asp:TextBox runat="server" ID="nome" Visible="false" /></div>
                <div>Email:<asp:TextBox runat="server" ID="email" /></div>
                <asp:CheckBox Text="Adicionar Cópia Oculta" runat="server" AutoPostBack="true" ID="adicionarCopiaOculta" OnCheckedChanged="adicionarCopiaOculta_CheckedChanged" />
                <asp:PlaceHolder runat="server" ID="exibeCco" Visible="false">
                    <div>Cco: <asp:TextBox runat="server" ID="cco" /></div>
                </asp:PlaceHolder>
                <div>
                    <asp:Button Text="Editar" ID="btnEditarEmpresa" OnClick="btnEditarEmpresa_Click" runat="server" />
                    <asp:Button Text="Excluir" ID="btnExcluirEmpresa" OnClick="btnExcluirEmpresa_Click" runat="server" />
                </div>
            </asp:Panel>
            <%= this.mensagem %>
            <div>
                <asp:HyperLink NavigateUrl="~/Home/Home.aspx" Text="Voltar" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
