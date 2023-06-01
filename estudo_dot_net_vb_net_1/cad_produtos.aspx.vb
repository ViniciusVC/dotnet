Partial Class cad_produtos

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

#End Region

#Region "Subs"

    Sub LimpaCampos()

        txtcod_prod.Text = Nothing
        txtproduto.Text = Nothing
        txtpreco_unit.Text = Nothing
        txtestoque.Text = Nothing

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
        Dim oProdutos As New produtos
        oProdutos.Excluir(Me.Identificacao)
    End Sub

    Sub Gravar()

        Dim oProdutos As New produtos
        Dim ds As New dsProdutos
        Dim drProdutos As dsProdutos.ProdutosRow = ds.Produtos.NewProdutosRow

        drProdutos.produto = txtproduto.Text
        drProdutos.preco_unit = txtpreco_unit.Text
        drProdutos.estoque = txtestoque.Text

        If Me.Status = "I" Then

            oProdutos.Inserir(drProdutos)

            Me.Identificacao = drProdutos.cod_prod
            txtcod_prod.Text = drProdutos.cod_prod

        ElseIf Me.Status = "A" Then

            drProdutos.cod_prod = Me.Identificacao
            oProdutos.Alterar(drProdutos)
        End If

        Consulta()
        lblMenssagem.Text = "Informações salvas com sucesso!"
    End Sub

    Sub CoordenaCampos()
        txtcod_prod.Enabled = False
        txtproduto.Enabled = False
        txtpreco_unit.Enabled = False
        txtestoque.Enabled = False

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

                txtcod_prod.Enabled = False
                txtproduto.Enabled = True
                txtpreco_unit.Enabled = True
                txtestoque.Enabled = True

                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
                LimpaCampos()

            Case "A" ' Alterando

                lblStatus.Text = "Alteração"

                txtcod_prod.Enabled = False

                txtproduto.Enabled = True
                txtpreco_unit.Enabled = True
                txtestoque.Enabled = True

                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
        End Select
    End Sub

    Sub CarregaRegistro()
        Dim oProduto As New produtos

        Dim ds As New dsProdutos
        Dim drProduto As dsProdutos.ProdutosRow = ds.Produtos.NewProdutosRow

        drProduto.cod_prod = Me.Identificacao

        If oProduto.Localizar(drProduto) Then
            txtcod_prod.Text = drProduto.cod_prod
            txtproduto.Text = drProduto.produto
            txtpreco_unit.Text = drProduto.preco_unit
            txtestoque.Text = drProduto.estoque
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

#End Region

End Class




