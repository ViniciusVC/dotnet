<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="pesq_pedidos.aspx.vb" Inherits="pesq_pedidos" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnPesquisar" GroupingText="Pedidos por Período"
        Height="50px" Width="400px">
        <table width="350" cellpadding="5">
            <tr>
                <td align="right" style="width: 44px">
                    de</td>
                <td align="left">
                    <asp:TextBox ID="txtPesquisa" runat="server" Width="100px"></asp:TextBox>
                    <asp:Image ID="imgCalend1" runat="server" ImageUrl="~/App_Themes/Theme1/Images/Calendar.png" />
                    &nbsp;
                        <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                            ControlExtender="mePesquisa"
                            ControlToValidate="txtPesquisa" 
                            IsValidEmpty="False" 
                            EmptyValueMessage="Data inicial vazia!"
                            InvalidValueMessage="Data inicial inválida!" 
                            TooltipMessage="Data inicial">
                        </cc1:MaskedEditValidator>
               </td>
            </tr>
            <tr>
                <td align="right" style="width: 44px">
                    até</td>
                <td align="left">
                    <asp:TextBox ID="txtPesquisa2" runat="server" Width="100px"></asp:TextBox>&nbsp;<asp:Image
                        ID="imgCalend2" runat="server" ImageUrl="~/App_Themes/Theme1/Images/Calendar.png" />
                    &nbsp;<cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server" ControlExtender="mePesquisa2"
                        ControlToValidate="txtPesquisa2" EmptyValueMessage="Data final vazia!" InvalidValueMessage="Data final inválida!"
                        IsValidEmpty="False" TooltipMessage="Data final"></cc1:MaskedEditValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 44px">
                </td>
                <td align="left" style="width: 239px">
                    <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgCalend1"
        TargetControlID="txtPesquisa">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgCalend2"
        TargetControlID="txtPesquisa2">
    </cc1:CalendarExtender>
    &nbsp; &nbsp;
    
    <cc1:MaskedEditExtender ID="mePesquisa" runat="server" 
    Mask="99/99/9999" 
    MaskType="Date"
    TargetControlID="txtPesquisa" 
    ErrorTooltipEnabled="true" 
    OnFocusCssClass="MaskedEditFocus"
    OnInvalidCssClass="MaskedEditError" />
    
    <cc1:MaskedEditExtender ID="mePesquisa2" runat="server" 
    Mask="99/99/9999" 
    MaskType="Date"
    TargetControlID="txtPesquisa2" 
    ErrorTooltipEnabled="true" 
    OnFocusCssClass="MaskedEditFocus"
    OnInvalidCssClass="MaskedEditError" />
    
    &nbsp;<br />
    &nbsp;&nbsp;<br />
    <asp:Label ID="lblRegistros" runat="server"></asp:Label><br />
    <br />
    <asp:GridView ID="GridViewPesquisa" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" Width="600px">
        <Columns>
            <asp:HyperLinkField HeaderText="C&#243;digo" SortExpression="cod_ped" DataTextField="cod_ped"
                DataNavigateUrlFormatString="cad_pedidos.aspx?id={0}" DataNavigateUrlFields="cod_ped">
            </asp:HyperLinkField>
            <asp:BoundField DataField="nomecliente" SortExpression="nomecliente" HeaderText="Cliente">
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="empresacliente" SortExpression="empresacliente" HeaderText="Empresa">
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HtmlEncode="False" DataFormatString="{0:d}" DataField="datapedido"
                SortExpression="datapedido" HeaderText="Data"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="False"></asp:Label><br />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
    <br />
</asp:Content>
