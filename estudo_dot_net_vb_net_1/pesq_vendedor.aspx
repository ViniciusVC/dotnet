<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="pesq_vendedor.aspx.vb" Inherits="pesq_vend" title="Pesquisa de Vendedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="lblRegistros" runat="server"></asp:Label><br />
    <br />
    <asp:GridView ID="GridViewPesquisa" runat="server" Width="550px" AllowSorting="True" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="cod_vend" DataNavigateUrlFormatString="cad_vendedor.aspx?id={0}"
                DataTextField="cod_vend" HeaderText="C&#243;digo" SortExpression="cod_vend" />
            <asp:BoundField DataField="pri_nome" HeaderText="Nome" SortExpression="pri_nome" />
            <asp:BoundField DataField="sobrenome" HeaderText="Sobrenome" SortExpression="sobrenome" />
            <asp:BoundField DataField="cidade" HeaderText="Cidade" SortExpression="cidade" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label><br />
    <br />
</asp:Content>

