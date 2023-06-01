
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="cad_itens.aspx.vb" Inherits="cad_itens" title="Cadastro de itens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    &nbsp;<asp:Label ID="lblMenssagem" runat="server"></asp:Label>&nbsp;
    <br />
    <br />
    <table border="0" class="tablecentro" style="width: 80%">
        <tr>
            <td colspan="2" class="tablecentroTH">Cadastro de Itens</td>
        </tr>
        <tr>
            <td align="right"></td>
            <td align="left">
                <asp:Label ID="lblStatus" runat="server" Font-Bold="True"></asp:Label></td>
        </tr>

        <tr>
            <td align="right">
                Pedido</td>
            <td align="left"><asp:TextBox ID="txtcod_ped" runat="server" Width="50px"></asp:TextBox>
                <asp:HyperLink ID="hplPedido" runat="server">Ver Pedido</asp:HyperLink></td>
        </tr>

        <tr>
            <td align="right">
                Produto</td>
            <td align="left"><asp:TextBox ID="txtProduto" runat="server" Width="300px"></asp:TextBox>
		            <asp:ImageButton ID="ibtnPesquisar" runat="server" SkinID="Img_Pesq" CausesValidation="False" OnClick="ibtnPesquisar_Click" />

	    </td>
        </tr>
           <tr runat="server" id="linhapesq" visible="false">
            <td align="right">&nbsp;</td>
            <td align="left">
                <asp:GridView ID="grdProdutos" runat="server" AutoGenerateColumns="False" DataKeyNames="cod_prod,produto,preco_unit" OnSelectedIndexChanged="grdProdutos_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Theme1/Images/selecionar.gif"
                            ShowSelectButton="True" />
                        <asp:BoundField DataField="cod_prod" HeaderText="C&#243;digo" />
                        <asp:BoundField DataField="produto" HeaderText="Nome" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right">
                Preço Unitário</td>
            <td align="left"><asp:TextBox ID="txtpreco_unit" runat="server" Width="100px"></asp:TextBox>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpreco_unit"
                    ErrorMessage="Preenchimento de Preço obrigatório.">*</asp:RequiredFieldValidator><asp:CompareValidator
                        ID="CompareValidator1" runat="server" ControlToValidate="txtpreco_unit" ErrorMessage="Preço inválido."
                        Operator="DataTypeCheck" Type="Double">?</asp:CompareValidator>
	    </td>
        </tr>

        <tr>
            <td align="right">
                Quantidade</td>
            <td align="left"><asp:TextBox ID="txtquant" runat="server" Width="50px"></asp:TextBox>
                <asp:ImageButton ID="ibtnAtualiza" runat="server" ImageUrl="~/App_Themes/Theme1/Images/atualizar.gif" OnClick="ibtnAtualiza_Click" />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtquant"
                    ErrorMessage="Preenchimento de Quantidade obrigatório.">*</asp:RequiredFieldValidator><asp:CompareValidator
                        ID="CompareValidator2" runat="server" ControlToValidate="txtquant" ErrorMessage="Quantidade inválida."
                        Operator="DataTypeCheck" Type="Integer">?</asp:CompareValidator>
	    </td>
        </tr>
        <tr>
            <td align="right">
                SubTotal</td>
            <td align="left">
                <asp:TextBox ID="txtSubTotal" runat="server" Width="100px"></asp:TextBox></td>
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
    &nbsp; &nbsp; Registros:
    <asp:Label ID="lblRegistros" runat="server"></asp:Label><br />
    <br />
    <asp:GridView ID="GridViewItens" runat="server" DataKeyNames="cod_ped,cod_prod" OnSelectedIndexChanged="GridViewItens_SelectedIndexChanged"
        Width="550px">
        <Columns>
            <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Theme1/Images/selecionar.gif"
                ShowSelectButton="True" />
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
    &nbsp; &nbsp;&nbsp;&nbsp;<br />
    <asp:Label ID="lblTotal" runat="server"></asp:Label><br />
    <br />
    <asp:Label ID="lblerror" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label><br />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" />
    <br />
    <br />
    <br />
</asp:Content>



