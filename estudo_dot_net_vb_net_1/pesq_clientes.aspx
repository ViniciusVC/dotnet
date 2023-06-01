<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="pesq_clientes.aspx.vb" Inherits="pesq_cliente" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnPesquisar" GroupingText="Digite o nome do Cliente"
        Height="50px" Width="281px">
        <asp:TextBox ID="txtPesquisa" runat="server"></asp:TextBox>
        <asp:Button ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" Text="Pesquisar" /></asp:Panel>
    &nbsp;&nbsp;<br />
    <asp:Label ID="lblRegistros" runat="server"></asp:Label><br />
    <br />
    <asp:GridView ID="GridViewPesquisa" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" Width="600px">
        <Columns>
<asp:HyperLinkField HeaderText="C&#243;digo" SortExpression="cod_cli" DataTextField="cod_cli" DataNavigateUrlFormatString="cad_clientes.aspx?id={0}" DataNavigateUrlFields="cod_cli"></asp:HyperLinkField>
<asp:BoundField DataField="empresa" SortExpression="empresa" HeaderText="Empresa">
<ItemStyle HorizontalAlign="Left"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="nome" SortExpression="nome" HeaderText="Respons&#225;vel"></asp:BoundField>
<asp:BoundField DataField="cidade" SortExpression="cidade" HeaderText="Cidade"></asp:BoundField>
</Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label><br />
    <br />
</asp:Content>

