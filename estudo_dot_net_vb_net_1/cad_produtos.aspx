
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="cad_produtos.aspx.vb" Inherits="cad_produtos" title="Cadastro de produtos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="lblMenssagem" runat="server"></asp:Label>&nbsp;
    <br />
    <br />
    <table border="0" class="tablecentro" style="width: 80%">
        <tr>
            <td colspan="2" class="tablecentroTH">Cadastro de Produtos</td>
        </tr>
        <tr>
            <td align="right"></td>
            <td align="left">
                <asp:Label ID="lblStatus" runat="server" Font-Bold="True"></asp:Label></td>
        </tr>

        <tr>
            <td align="right">
                Código</td>
            <td align="left"><asp:TextBox ID="txtcod_prod" runat="server" Width="60px"></asp:TextBox></td>
        </tr>

        <tr>
            <td align="right">
                Produto</td>
            <td align="left"><asp:TextBox ID="txtproduto" runat="server" Width="300px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtproduto"
                    ErrorMessage="Preenchimento de produto obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
        </tr>

        <tr>
            <td align="right" style="height: 28px">
                Preço</td>
            <td align="left" style="height: 28px"><asp:TextBox ID="txtpreco_unit" runat="server" Width="80px"></asp:TextBox>
                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                    ControlExtender="MaskedEditExtender1"
                    ControlToValidate="txtpreco_unit" 
                    IsValidEmpty="False" 
                    EmptyValueMessage="Preço obrigatório!" 
                    TooltipMessage ="Preencha com o preço."
                    />
                    
            </td>
        </tr>

        <tr>
            <td align="right">
                Estoque</td>
            <td align="left"><asp:TextBox ID="txtestoque" runat="server" Width="50px"></asp:TextBox>&nbsp;
                <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                    ControlExtender="MaskedEditExtender2"
                    ControlToValidate="txtestoque" 
                    IsValidEmpty="False" 
                    EmptyValueMessage="Estoque obrigatório!" 
                    TooltipMessage ="Preencha com o estoque."
                    /></td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
    </table>
       <br />
  <table border="0" width="80%">
        <tr>
            <td>
                <asp:ImageButton ID="ibtnNovo" runat="server" SkinID="NewImageButton" CausesValidation="False" />
                <asp:ImageButton ID="ibtnEditar" runat="server" SkinID="EditImageButton" CausesValidation="False" />
                <asp:ImageButton ID="ibtnSalvar" runat="server" SkinID="SalvarImageButton" />
                <asp:ImageButton ID="ibtnDesfazer" runat="server" SkinID="DesfazerImageButton" CausesValidation="False" Visible="False" />
                <asp:ImageButton ID="ibtnExcluir" runat="server" SkinID="ExcImageButton" CausesValidation="False" /></td>
        </tr>
    </table>
    <br />
    <asp:Label ID="lblerror" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label><br />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
    <br />
    <br />
    
    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
        TargetControlID="txtpreco_unit"
        DisplayMoney="Left"
        InputDirection="RightToLeft"
        Mask="9,999.99"
        MaskType="Number"
        MessageValidatorTip="true" />
    
    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
        TargetControlID="txtestoque"
        InputDirection="RightToLeft"
        Mask="999"
        MaskType="Number"
        MessageValidatorTip="true" />
    
    &nbsp;
    <br />
</asp:Content>



