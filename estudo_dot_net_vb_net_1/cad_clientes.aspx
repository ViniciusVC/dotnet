
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="cad_clientes.aspx.vb" Inherits="cad_clientes" title="Cadastro de clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="lblMenssagem" runat="server"></asp:Label>&nbsp;
    <br />
    <br />
    <table border="0" class="tablecentro" style="width: 80%">
        <tr>
            <td colspan="2" class="tablecentroTH">Cadastro de Clientes</td>
        </tr>
        <tr>
            <td align="right"></td>
            <td align="left">
                <asp:Label ID="lblStatus" runat="server" Font-Bold="True"></asp:Label></td>
        </tr>

        <tr>
            <td align="right">
                Código</td>
            <td align="left"><asp:TextBox ID="txtcod_cli" runat="server" Width="60px" MaxLength="5"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcod_cli"
                    ErrorMessage="Preenchimento de cod_cli obrigatório.">*</asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td align="right">
                Empresa</td>
            <td align="left"><asp:TextBox ID="txtempresa" runat="server" Width="300px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtempresa"
                    ErrorMessage="Preenchimento de empresa obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
        </tr>

        <tr>
            <td align="right">
                Nome</td>
            <td align="left"><asp:TextBox ID="txtnome" runat="server" Width="300px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnome"
                    ErrorMessage="Preenchimento de nome obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
        </tr>

        <tr>
            <td align="right">
                Cargo</td>
            <td align="left"><asp:DropDownList ID="ddlCargo" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCargo"
                    ErrorMessage="Preenchimento Cargo obrigatório." SetFocusOnError="True">*</asp:RequiredFieldValidator>
	    </td>
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
            <td align="left"><asp:TextBox ID="txttelefone" runat="server" Width="100px"></asp:TextBox>&nbsp;
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



