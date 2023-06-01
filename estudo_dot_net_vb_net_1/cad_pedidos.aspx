
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="cad_pedidos.aspx.vb" Inherits="cad_pedidos" title="Cadastro de pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="lblMenssagem" runat="server"></asp:Label>&nbsp;
    <br />
    <br />
    <table border="0" class="tablecentro" style="width: 80%">
        <tr>
            <td colspan="2" class="tablecentroTH">Cadastro de Pedido</td>
        </tr>
        <tr>
            <td align="right"></td>
            <td align="left">
                <asp:Label ID="lblStatus" runat="server" Font-Bold="True"></asp:Label></td>
        </tr>

        <tr>
            <td align="right">
                Código</td>
            <td align="left"><asp:TextBox ID="txtcod_ped" runat="server" Width="50px"></asp:TextBox>&nbsp;</td>
        </tr>

        <tr>
            <td align="right">
                Cliente</td>
            <td align="left"><asp:TextBox ID="txtCliente" runat="server" Width="200px"></asp:TextBox>&nbsp;
            <asp:ImageButton ID="ibtnPesquisar" runat="server" SkinID="Img_Pesq" CausesValidation="False" OnClick="ibtnPesquisar_Click" />
	    </td>
        </tr>
        <tr runat="server" id="linhapesq" visible="false">
            <td align="right">&nbsp;</td>
            <td align="left">
                <asp:GridView ID="grdClientes" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_cli,nome" OnSelectedIndexChanged="grdClientes_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Theme1/Images/selecionar.gif"
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="cod_cli" HeaderText="C&#243;digo" />
                        <asp:BoundField DataField="nome" HeaderText="Nome" />
                        <asp:BoundField DataField="empresa" HeaderText="Empresa" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right">
                Vendedor</td>
            <td align="left">
                <asp:DropDownList ID="ddlVendedor" runat="server">
                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="ddlVendedor" ErrorMessage="Preenchimento Cargo obrigatório."
                    SetFocusOnError="True">*</asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td align="right">
                Contato</td>
            <td align="left"><asp:TextBox ID="txtentreg_nm" runat="server" Width="300px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtentreg_nm"
                    ErrorMessage="Preenchimento de entreg_nm obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
        </tr>

        <tr>
            <td align="right">
                Endereço Entrega</td>
            <td align="left"><asp:TextBox ID="txtentreg_end" runat="server" Width="300px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtentreg_end"
                    ErrorMessage="Preenchimento de entreg_end obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
        </tr>

        <tr>
            <td align="right">
                Cidade</td>
            <td align="left"><asp:TextBox ID="txtentreg_cid" runat="server" Width="200px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtentreg_cid"
                    ErrorMessage="Preenchimento de entreg_cid obrigatório.">*</asp:RequiredFieldValidator>
	    </td>
        </tr>

        <tr>
            <td align="right">
                Data do Pedido</td>
            <td align="left"><asp:TextBox ID="txtdatapedido" runat="server" Width="100px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtdatapedido"
                    ErrorMessage="Preenchimento de datapedido obrigatório.">*</asp:RequiredFieldValidator><asp:CompareValidator
                        ID="CompareValidator1" runat="server" ControlToValidate="txtdatapedido" ErrorMessage="Data pedido inválida."
                        Operator="DataTypeCheck" Type="Date">?</asp:CompareValidator></td>
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
    
    
    
    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
    <asp:Label ID="lblerror" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
    &nbsp; &nbsp;
    <asp:Panel ID="Panel1" runat="server" GroupingText="Itens" Height="64px" Width="300px">
        <table cellpadding="5" width="290">
            <tr>
                <td>
                    Registros:
    <asp:Label ID="lblRegistros" runat="server"></asp:Label>&nbsp; &nbsp;<asp:ImageButton ID="ibtnAddItens" runat="server" SkinID="AditemImageButton" OnClick="ibtnAddItens_Click" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <asp:GridView ID="GridViewItens" runat="server" Width="550px">
        <Columns>
            <asp:BoundField DataField="produto" HeaderText="Produto">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="preco_unit" DataFormatString="{0:C}" HeaderText="Pre&#231;o"
                HtmlEncode="False">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="quant" HeaderText="Qtd" />
            <asp:BoundField DataField="subtotal" DataFormatString="{0:C}" HeaderText="SubTotal"
                HtmlEncode="False">
                <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    &nbsp;&nbsp;&nbsp;<br />
    
    
    
    
    <br />
    <br />
</asp:Content>



