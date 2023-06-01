Partial Class cad_itens
    Inherits System.Web.UI.Page

#Region "Propriedades"
    Public Property Cod_Pedido() As String
        Get
            Return ViewState("Cod_Pedido")
        End Get
        Set(ByVal value As String)
            ViewState("Cod_Pedido") = value
        End Set
    End Property

    Public Property Cod_Produto() As String
        Get
            Return ViewState("Cod_Produto")
        End Get
        Set(ByVal value As String)
            ViewState("Cod_Produto") = value
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

    Public Property Quant_Old() As Integer
        Get
            Return ViewState("Quant_Old")
        End Get
        Set(ByVal value As Integer)
            ViewState("Quant_Old") = value
        End Set
    End Property
#End Region

#Region "Subs"

    Sub CarregaItens()
        Dim oItem As New itens
        Dim ds As New dsItens
        Dim drItem As dsItens.ItensRow = ds.Itens.NewItensRow

        drItem.cod_ped = Me.Cod_Pedido

        Dim dt As DataTable = oItem.Consultar(drItem)

        lblRegistros.Text = "(" & dt.Rows.Count & ")"

        If dt.Rows.Count > 0 Then
            lblTotal.Text = "Total do Pedido: " + _
                        Format(dt.Compute("sum(subtotal)", ""), "c")
        End If

        GridViewItens.SelectedIndex = -1
        GridViewItens.DataSource = dt
        GridViewItens.DataBind()
    End Sub

    Sub LimpaCampos()
        txtProduto.Text = Nothing
        Me.Cod_Produto = Nothing
        txtpreco_unit.Text = Nothing
        txtquant.Text = Nothing
        txtSubTotal.Text = Nothing

        LimpaGridviewProdutos()
    End Sub

    Sub Inclusao()
        Me.Status = "I"
        CoordenaCampos()
    End Sub

    Sub Alteracao()
        Me.Status = "A"
        Me.Quant_Old = txtquant.Text
        CoordenaCampos()
    End Sub

    Sub Consulta()
        Me.Status = "C"
        CoordenaCampos()
    End Sub

    Sub Exclusao()
        Dim oItem As New itens
        Dim ds As New dsItens
        Dim drItem As dsItens.ItensRow = ds.Itens.NewItensRow

        drItem.cod_ped = Me.Cod_Pedido
        drItem.cod_prod = Me.Cod_Produto

        oItem.Excluir(drItem)
        Inclusao()

        lblMenssagem.Text = "Informações Exclluídas com sucesso!"
    End Sub

    Sub Gravar()
        Dim oItem As New itens
        Dim ds As New dsItens
        Dim dr As dsItens.ItensRow = ds.Itens.NewItensRow

        dr.cod_ped = Me.Cod_Pedido
        dr.cod_prod = Me.Cod_Produto
        dr.preco_unit = txtpreco_unit.Text
        dr.quant = txtquant.Text

        If Me.Status = "I" Then
            oItem.Inserir(dr)
        ElseIf Me.Status = "A" Then
            oItem.Alterar(dr, Me.Quant_Old)
        End If

        Consulta()

        lblMenssagem.Text = "Informações salvas com sucesso!"
    End Sub

    Sub CoordenaCampos()

        txtcod_ped.Enabled = False
        txtProduto.Enabled = False
        txtpreco_unit.Enabled = False
        txtquant.Enabled = False
        txtSubTotal.Enabled = False
        ibtnPesquisar.Visible = False
        ibtnAtualiza.Visible = False
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

            Case "I" ' Incluindo 
                lblStatus.Text = "Inclusão"
                txtProduto.Enabled = True
                txtquant.Enabled = True
                ibtnAtualiza.Visible = True
                ibtnPesquisar.Visible = True
                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
                LimpaCampos()

            Case "A" ' Alterando
                lblStatus.Text = "Alteração"
                txtquant.Enabled = True
                ibtnAtualiza.Visible = True
                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
        End Select
    End Sub

    Sub CarregaRegistro()
        Try
            Dim oItens As New itens
            Dim dt As DataTable = oItens.Listar(Me.Cod_Pedido, Me.Cod_Produto)

            If dt.Rows.Count > 0 Then
                txtcod_ped.Text = dt.Rows(0).Item("cod_ped").ToString
                Me.Cod_Produto = dt.Rows(0).Item("cod_prod").ToString
                txtProduto.Text = dt.Rows(0).Item("produto").ToString
                txtpreco_unit.Text = dt.Rows(0).Item("preco_unit").ToString
                txtquant.Text = dt.Rows(0).Item("quant").ToString
                txtSubTotal.Text = dt.Rows(0).Item("subtotal").ToString
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Sub LimpaGridviewProdutos()
        grdProdutos.SelectedIndex = -1
        grdProdutos.DataSource = Nothing
        grdProdutos.DataBind()
        linhapesq.Visible = False
    End Sub

#End Region

#Region "Eventos Página "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Me.Cod_Pedido = Request.QueryString("id")
                txtcod_ped.Text = Me.Cod_Pedido
                hplPedido.NavigateUrl = "cad_pedidos.aspx?id=" & Me.Cod_Pedido

                ibtnDesfazer.Attributes.Add("onclick", _
                "Javascript: return confirm('Deseja realmente desfazer a operação?')")

                ibtnExcluir.Attributes.Add("onclick", _
                "Javascript: return confirm('Confirma a exclusão?')")

                If Not Me.Cod_Pedido Is Nothing Then
                    CarregaRegistro()
                    CarregaItens()
                    Consulta()
                Else
                    Response.Redirect("pesq_pedidos.aspx")
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
                CarregaItens()
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
            CarregaItens()

            lblMenssagem.Text = "Exclusão realizada com sucesso!"
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub ibtnDesfazer_Click(ByVal sender As Object, _
            ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnDesfazer.Click
        Try
            LimpaCampos()
            CarregaRegistro()
            CarregaItens()
            Consulta()
            lblMenssagem.Text = "Operação Desfeita."
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub GridViewItens_SelectedIndexChanged(ByVal sender As Object, _
                                                        ByVal e As System.EventArgs)
        Try
            Me.Cod_Produto = GridViewItens.SelectedDataKey.Item("cod_prod")
            Me.Cod_Pedido = GridViewItens.SelectedDataKey.Item("cod_ped")

            CarregaRegistro()
            Consulta()
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub ibtnPesquisar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Try

            linhapesq.Visible = True

            Dim oProd As New produtos
            Dim ds As New dsProdutos
            Dim dr As dsProdutos.ProdutosRow = ds.Produtos.NewProdutosRow

            dr.produto = txtProduto.Text

            grdProdutos.SelectedIndex = -1
            grdProdutos.DataSource = oProd.Consultar(dr)
            grdProdutos.DataBind()

        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub grdProdutos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            txtProduto.Text = grdProdutos.SelectedDataKey.Item("produto").ToString.ToUpper
            Me.Cod_Produto = grdProdutos.SelectedDataKey.Item("cod_prod").ToString.ToUpper

            txtpreco_unit.Text = grdProdutos.SelectedDataKey.Item("preco_unit").ToString

            If txtquant.Text <> Nothing Then
                txtSubTotal.Text = txtpreco_unit.Text * txtquant.Text
            End If

            LimpaGridviewProdutos()
        Catch ex As Exception
            lblerror.Text = ex.Message
        End Try
    End Sub

    Protected Sub ibtnAtualiza_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        If txtquant.Text <> Nothing And txtpreco_unit.Text <> Nothing Then
            txtSubTotal.Text = txtpreco_unit.Text * txtquant.Text
        End If
    End Sub

#End Region

End Class




