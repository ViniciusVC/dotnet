<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="pesq_cargos.aspx.vb" Inherits="pesq_cargo" title="Pesquisa de Cargos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="lblRegistros" runat="server"></asp:Label><br />
    <br />
    <asp:GridView ID="GridViewPesquisa" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" Width="300px">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="cod_cargo" DataNavigateUrlFormatString="cad_cargos.aspx?id={0}"
                DataTextField="cod_cargo" HeaderText="C&#243;digo" SortExpression="cod_cargo" />
            <asp:BoundField DataField="cargo" HeaderText="Cargo" SortExpression="cargo" >
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label><br />
    <br />
</asp:Content>

