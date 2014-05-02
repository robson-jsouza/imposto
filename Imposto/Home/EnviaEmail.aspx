<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="EnviaEmail.aspx.cs" Inherits="AutoImposto.Home.EnviaEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HomeContent" runat="server">
    <div>
        <div>
            Selecione a Empresa:
            <asp:HyperLink NavigateUrl="~/Home/CadastroEmpresa.aspx" Text="(+)" runat="server" />
            <div>
                <asp:Label runat="server" ID="labelempresa" Visible="false">
                    <asp:DropDownList ID="escolheEmpresa" runat="server" OnSelectedIndexChanged="escolheEmpresa_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></asp:Label>
                <asp:Label runat="server" ID="semEmpresa" Visible="false" Text="Não possui empresas cadastradas" />
            </div>
        </div>
        <asp:CheckBox Text="Utilizar Cco Padrão" runat="server" ID="checkCcoPadrao" Visible="false" Checked="true" />
        <div>
            <div>
                Selecione a data de Referencia: 
            <asp:CheckBox Text="Sem Data de Referência" AutoPostBack="true" OnCheckedChanged="semDataReferencia_CheckedChanged" runat="server" ID="semDataReferencia" />
            </div>
            Mês:
            <asp:DropDownList runat="server" ID="escolheMesReferencia">
                <asp:ListItem Text="Janeiro" Value="01" />
                <asp:ListItem Text="Fevereiro" Value="02" />
                <asp:ListItem Text="Março" Value="03" />
                <asp:ListItem Text="Abril" Value="04" />
                <asp:ListItem Text="Maio" Value="05" />
                <asp:ListItem Text="Junho" Value="06" />
                <asp:ListItem Text="Julho" Value="07" />
                <asp:ListItem Text="Agosto" Value="08" />
                <asp:ListItem Text="Setembro" Value="09" />
                <asp:ListItem Text="Outubro" Value="10" />
                <asp:ListItem Text="Novembro" Value="11" />
                <asp:ListItem Text="Dezembro" Value="12" />
            </asp:DropDownList>
            Ano:
            <asp:DropDownList ID="escolheAnoReferencia" runat="server"></asp:DropDownList>
        </div>
        <div>
            <div>
                Selecione a data de Vencimento: 
                <asp:CheckBox Text="Sem data de Vencimento" ID="semDataVencimento" runat="server" AutoPostBack="true" OnCheckedChanged="semDataVencimento_CheckedChanged" />
            </div>
            Dia:
            <asp:DropDownList ID="escolheDiaVencimento" runat="server"></asp:DropDownList>
            Mês:
            <asp:DropDownList runat="server" ID="escolheMesVencimento">
                <asp:ListItem Text="Janeiro" Value="01" />
                <asp:ListItem Text="Fevereiro" Value="02" />
                <asp:ListItem Text="Março" Value="03" />
                <asp:ListItem Text="Abril" Value="04" />
                <asp:ListItem Text="Maio" Value="05" />
                <asp:ListItem Text="Junho" Value="06" />
                <asp:ListItem Text="Julho" Value="07" />
                <asp:ListItem Text="Agosto" Value="08" />
                <asp:ListItem Text="Setembro" Value="09" />
                <asp:ListItem Text="Outubro" Value="10" />
                <asp:ListItem Text="Novembro" Value="11" />
                <asp:ListItem Text="Dezembro" Value="12" />
            </asp:DropDownList>
            Ano:
            <asp:DropDownList ID="escolheAnoVencimento" runat="server"></asp:DropDownList>
        </div>
        <div>
            Escolha o Imposto:
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Home/CadastroImposto.aspx" Text="(+)" runat="server" />
            <div>
                <asp:CheckBoxList ID="escolheImposto" runat="server" Visible="false"></asp:CheckBoxList>
                <asp:Label ID="semImpostos" Text="Não possuem impostos cadastrados" runat="server" Visible="false" />
            </div>
        </div>
        <asp:Button Text="Gerar Email" runat="server" ID="montarEmail" OnClick="montarEmail_Click" />
        <div>
            <asp:Label ID="cadastreEmail" Text="Cadastre uma Empresa para Gerar o Email" runat="server" Visible="false" />
        </div>
        <asp:Label ID="cadastreImposto" Text="Cadastre um Imposto para Gerar o Email" runat="server" Visible="false" />
        <asp:Label ID="selecioneUmImposto" Text="Selecione Imposto para Gerar o Email" runat="server" Visible="false" />
        <asp:Label ID="linkEnviarEmail" runat="server" Visible="false">
        <a href="<%= mensagemParaEnvio %>">Clique aqui para Enviar!</a>
        <div>Para: <%= emailPreview %></div>
        <div>Cco: <%= ccoPreview %></div>
        <div>Cco padrão: <%= ccoPadraoPreview %></div>
        <div>Assunto: <%= assuntoPreview %></div>
        <div>Conteúdo:<%= conteudoPreview %></div>
        </asp:Label>
    </div>
    <div>
        <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Home/Home.aspx" Text="Voltar" runat="server" />
    </div>
</asp:Content>
