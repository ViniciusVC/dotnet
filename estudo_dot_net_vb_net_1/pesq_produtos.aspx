<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="pesq_produtos.aspx.vb" Inherits="pesq_prod" title="Pesquisa de Produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnPesquisar" GroupingText="Digite o nome do Produto"
        Height="50px" Width="281px">
        <asp:TextBox ID="txtPesquisa" runat="server"></asp:TextBox>
        <asp:Button ID="btnPesquisar" runat="server" OnClick="btnPesquisar_Click" Text="Pesquisar" /></asp:Panel>
    &nbsp;&nbsp;<br />
    <asp:Label ID="lblRegistros" runat="server"></asp:Label><br />
    <br />
    <asp:GridView ID="GridViewPesquisa" runat="server" AllowPaging="True"
        AutoGenerateColumns="False" AllowSorting="True" Width="600px">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="cod_prod" DataNavigateUrlFormatString="cad_produtos.aspx?id={0}"
                DataTextField="cod_prod" HeaderText="C&#243;digo" SortExpression="cod_prod" />
            <asp:BoundField DataField="produto" HeaderText="Produto" SortExpression="produto">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="preco_unit" DataFormatString="{0:c}" HeaderText="Pre&#231;o"
                HtmlEncode="False" SortExpression="preco_unit" />
            <asp:BoundField DataField="estoque" HeaderText="Estoque" SortExpression="estoque" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label><br />
    <br />
</asp:Content>

