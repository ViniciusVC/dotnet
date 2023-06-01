
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="cad_vendedor.aspx.vb" Inherits="cad_vendedor" title="Cadastro de vendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="lblMenssagem" runat="server"></asp:Label>&nbsp;
    <br />
    <br />
    <table border="0" class="tablecentro" style="width: 80%">
        <tr>
            <td colspan="2" class="tablecentroTH">Cadastro de Vendedor</td>
        </tr>
        <tr>
            <td align="right"></td>
            <td align="left">
                <asp:Label ID="lblStatus" runat="server" Font-Bold="True"></asp:Label></td>
        </tr>

        <tr>
            <td align="right">
                Código</td>
            <td align="left"><asp:TextBox ID="txtcod_vend" runat="server" Width="50px"></asp:TextBox>&nbsp;
	    </td>
        </tr>
        <tr>
            <td align="right">
                Nome</td>
            <td align="left">
                <asp:TextBox ID="txtpri_nome" runat="server" Width="200px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpri_nome"
                    ErrorMessage="Preenchimento de pri_nome obrigatório.">*</asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td align="right">
                Sobrenome</td>
            <td align="left"><asp:TextBox ID="txtsobrenome" runat="server" Width="200px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsobrenome"
                    ErrorMessage="Preenchimento de sobrenome obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
        </tr>

        <tr>
            <td align="right">
                Cargo</td>
            <td align="left">
                <asp:DropDownList ID="ddlCargo" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCargo"
                    ErrorMessage="Preenchimento Cargo obrigatório." SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td align="right">
                Endereço</td>
            <td align="left"><asp:TextBox ID="txtendereco" runat="server" Width="300px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtendereco"
                    ErrorMessage="Preenchimento de endereco obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
        </tr>

        <tr>
            <td align="right">
                Cidade</td>
            <td align="left"><asp:TextBox ID="txtcidade" runat="server" Width="200px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcidade"
                    ErrorMessage="Preenchimento de cidade obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
        </tr>

        <tr>
            <td align="right">
                Telefone</td>
            <td align="left"><asp:TextBox ID="txttelefone" runat="server" Width="100px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txttelefone"
                    ErrorMessage="Preenchimento de telefone obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
        </tr>

        <tr>
            <td align="right" valign="top">
                Obs</td>
            <td align="left"><asp:TextBox ID="txtobs" runat="server" Columns="40" Rows="6" TextMode="MultiLine"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtobs"
                    ErrorMessage="Preenchimento de obs obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
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
    <br />
</asp:Content>



