Imports System.Data
Imports Funcoes

Partial Class cad_pedidos

    Inherits System.Web.UI.Page

#Region "Propriedades"

    Public Property Identificacao() As String
        Get
            Return ViewState("Identificacao")
        End Get
        Set(ByVal value As String)
            ViewState("Identificacao") = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return ViewState("Status")
        End Get
        Set(ByVal value As String)
            ViewState("Status") = value
        End Set
    End Property

    Public Property Cod_Cliente() As String
        Get
            Return ViewState("Cod_Cliente")
        End Get
        Set(ByVal value As String)
            ViewState("Cod_Cliente") = value
        End Set
    End Property

#End Region

#Region "Subs"

    Sub CarregaItens()
        Dim oItens As New itens

        Dim ds As New dsItens
        Dim drItens As dsItens.ItensRow = ds.Itens.NewItensRow

        drItens.cod_ped = Me.Identificacao

        Dim dt As DataTable = oItens.Consultar(drItens)

        lblRegistros.Text = "(" & dt.Rows.Count & ")"

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.NewRow
            dr("subtotal") = dt.Compute("sum(subtotal)", "")
            dr("quant") = dt.Compute("sum(quant)", "")
            dt.Rows.Add(dr)

            GridViewItens.DataSource = dt
            GridViewItens.DataBind()
            GridViewItens.Rows(GridViewItens.Rows.Count - 1).Font.Bold = True
        Else
            GridViewItens.DataSource = Nothing
            GridViewItens.DataBind()
        End If
    End Sub

    Sub CarregaVendedor()
        Dim oVend As New vendedor
        ddlVendedor.DataTextField = "pri_nome"
        ddlVendedor.DataValueField = "cod_vend"
        ddlVendedor.DataSource = oVend.Listar
        ddlVendedor.Items.Insert(0, "")
        ddlVendedor.DataBind()
    End Sub

    Sub LimpaCampos()

        txtcod_ped.Text = Nothing
        txtCliente.Text = Nothing
        Me.Cod_Cliente = Nothing
        ddlVendedor.SelectedValue = Nothing
        txtentreg_nm.Text = Nothing
        txtentreg_end.Text = Nothing
        txtentreg_cid.Text = Nothing
        txtdatapedido.Text = Nothing

        lblRegistros.Text = "(0)"
        GridViewItens.DataSource = Nothing
        GridViewItens.DataBind()
    End Sub

    Sub Inclusao()
        Me.Status = "I"
        CoordenaCampos()
    End Sub

    Sub Alteracao()
        Me.Status = "A"
        CoordenaCampos()
    End Sub

    Sub Consulta()
        Me.Status = "C"
        CoordenaCampos()
    End Sub

    Sub Exclusao()
        Dim oPedidos As New pedidos
        oPedidos.Excluir(Me.Identificacao)
    End Sub

    Sub Gravar()
        Dim oPedido As New pedidos
        Dim ds As New dsPedidos
        Dim drPedido As dsPedidos.PedidosRow = ds.Pedidos.NewPedidosRow

        drPedido.cod_cli = Me.Cod_Cliente
        drPedido.cod_vend = ddlVendedor.SelectedValue
        drPedido.entreg_nm = txtentreg_nm.Text
        drPedido.entreg_end = txtentreg_end.Text
        drPedido.entreg_cid = txtentreg_cid.Text
        drPedido.datapedido = txtdatapedido.Text

        If Me.Status = "I" Then
            oPedido.Inserir(drPedido)
            Me.Identificacao = drPedido.cod_ped
            txtcod_ped.Text = drPedido.cod_ped
        ElseIf Me.Status = "A" Then
            drPedido.cod_ped = Me.Identificacao
            oPedido.Alterar(drPedido)
        End If

        Consulta()

        lblMenssagem.Text = "Informações salvas com sucesso!"
    End Sub

    Sub CoordenaCampos()

        txtcod_ped.Enabled = False
        txtCliente.Enabled = False
        ddlVendedor.Enabled = False
        txtentreg_nm.Enabled = False
        txtentreg_end.Enabled = False
        txtentreg_cid.Enabled = False
        txtdatapedido.Enabled = False

        ibtnPesquisar.Visible = False
        ibtnAddItens.Visible = False
        ibtnNovo.Visible = False
        ibtnEditar.Visible = False
        ibtnSalvar.Visible = False
        ibtnDesfazer.Visible = False
        ibtnExcluir.Visible = False
        lblMenssagem.Text = ""

        Select Case Me.Status

            Case "C" ' Consultando

                lblStatus.Text = "Consulta"

                ibtnNovo.Visible = True
                ibtnEditar.Visible = True
                ibtnExcluir.Visible = True
                ibtnAddItens.Visible = True

            Case "I" ' Incluindo 

                lblStatus.Text = "Inclusão"

                txtcod_ped.Enabled = False

                txtCliente.Enabled = True
                ddlVendedor.Enabled = True
                txtentreg_nm.Enabled = True
                txtentreg_end.Enabled = True
                txtentreg_cid.Enabled = True
                txtdatapedido.Enabled = True

                ibtnPesquisar.Visible = True
                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
                LimpaCampos()

            Case "A" ' Alterando

                lblStatus.Text = "Alteração"

                txtcod_ped.Enabled = False

                txtCliente.Enabled = True
                ddlVendedor.Enabled = True
                txtentreg_nm.Enabled = True
                txtentreg_end.Enabled = True
                txtentreg_cid.Enabled = True
                txtdatapedido.Enabled = True

                ibtnPesquisar.Visible = True
                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
        End Select
    End Sub

    Sub CarregaRegistro()

        Dim oPedidos As New pedidos

        Dim ds As New dsPedidos
        Dim drPedido As dsPedidos.PedidosRow = ds.Pedidos.NewPedidosRow

        drPedido.cod_ped = Me.Identificacao

        If oPedidos.Localizar(drPedido) Then

            txtcod_ped.Text = drPedido.cod_ped
            Me.Cod_Cliente = drPedido.cod_cli
            txtCliente.Text = drPedido.nomecliente
            ddlVendedor.SelectedValue = drPedido.cod_vend
            txtentreg_nm.Text = drPedido.entreg_nm
            txtentreg_end.Text = drPedido.entreg_end
            txtentreg_cid.Text = drPedido.entreg_cid
            txtdatapedido.Text = drPedido.datapedido.ToShortDateString

            CarregaItens()
        End If
    End Sub

#End Region

#Region "Eventos Página "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Identificacao = Request.QueryString("id")

                ibtnDesfazer.Attributes.Add("onclick", _
                "Javascript: return confirm('Deseja realmente desfazer a operação?')")

                ibtnExcluir.Attributes.Add("onclick", _
                "Javascript: return confirm('Confirma a exclusão?')")

                CarregaVendedor()

                If Not Identificacao Is Nothing Then
                    CarregaRegistro()
                    Consulta()
                Else
                    Inclusao()
                End If
            End If
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub ibtnNovo_Click(ByVal sender As Object, _
            ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnNovo.Click
        Try
            Inclusao()
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub ibtnEditar_Click(ByVal sender As Object, _
            ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnEditar.Click
        Try
            Alteracao()
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub ibtnSalvar_Click(ByVal sender As Object, _
            ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnSalvar.Click
        Try
            If IsValid Then
                Gravar()
            End If
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub ibtnExcluir_Click(ByVal sender As Object, _
            ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnExcluir.Click
        Try

            Exclusao()
            LimpaCampos()
            Inclusao()
            Me.Identificacao = Nothing

            lblMenssagem.Text = "Exclusão realizada com sucesso!"

        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub ibtnDesfazer_Click(ByVal sender As Object, _
            ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnDesfazer.Click
        Try
            If Not Me.Identificacao Is Nothing Then
                CarregaRegistro()
                Consulta()
            Else
                LimpaCampos()
            End If

            lblMenssagem.Text = "Operação Desfeita."

        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub ibtnPesquisar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnPesquisar.Click
        Try
            linhapesq.Visible = True

            Dim oCli As New clientes
            grdClientes.SelectedIndex = -1

            Dim ds As New dsClientes
            Dim dr As dsClientes.ClientesRow = ds.Clientes.NewClientesRow

            dr.cod_cli = txtCliente.Text

            grdClientes.DataSource = oCli.Consultar(dr)
            grdClientes.DataBind()

        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub grdClientes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            txtCliente.Text = grdClientes.SelectedDataKey.Item("nome").ToString.ToUpper
            Me.Cod_Cliente = grdClientes.SelectedDataKey.Item("cod_cli").ToString.ToUpper

            grdClientes.SelectedIndex = -1
            grdClientes.DataSource = Nothing
            grdClientes.DataBind()

            linhapesq.Visible = False

        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub ibtnAddItens_Click(ByVal sender As Object, _
                        ByVal e As System.Web.UI.ImageClickEventArgs)

        Response.Redirect("cad_itens.aspx?id=" + Me.Identificacao)

    End Sub

#End Region


End Class




