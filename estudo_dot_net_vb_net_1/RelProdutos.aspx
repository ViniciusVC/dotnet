<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RelProdutos.aspx.vb" Inherits="RelProdutos" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Relatorio por:
    <asp:TextBox ID="txtBusca" runat="server"></asp:TextBox>
    <asp:Button ID="butgerar" runat="server" OnClick="butgerar_Click" Text="Gerar Relatorio" /><br />
    <br />
    <br />
    <rsweb:ReportViewer iD="ReportViewerProdutos" runat="server" width="641px">
    </rsweb:ReportViewer>
    <br />
    &nbsp;<asp:Label ID="lblError" runat="server" Text="Label"></asp:Label><br />
</asp:Content>

