<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="relatorio.aspx.vb" Inherits="relatorio" title="Relatórios" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:Label ID="lblError" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label><br />
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="650px">
    </rsweb:ReportViewer>
</asp:Content>

