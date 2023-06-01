Partial Class cad_vendedor

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

    Sub CarregaCargos()
        Dim oCargos As New cargos
        ddlCargo.DataTextField = "cargo"
        ddlCargo.DataValueField = "cod_cargo"

        ddlCargo.DataSource = oCargos.Listar
        ddlCargo.DataBind()
    End Sub

    Sub LimpaCampos()
        txtcod_vend.Text = Nothing
        txtsobrenome.Text = Nothing
        txtpri_nome.Text = Nothing
        ddlCargo.SelectedValue = Nothing
        txtendereco.Text = Nothing
        txtcidade.Text = Nothing
        txttelefone.Text = Nothing
        txtobs.Text = Nothing
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
        Dim oVend As New vendedor
        oVend.Excluir(Me.Identificacao)
    End Sub

    Sub Gravar()
        Dim oVendedor As New vendedor
        Dim ds As New dsVendedor
        Dim drVendedor As dsVendedor.VendedorRow = ds.Vendedor.NewVendedorRow

        drVendedor.cod_vend = txtcod_vend.Text
        drVendedor.sobrenome = txtsobrenome.Text
        drVendedor.pri_nome = txtpri_nome.Text
        drVendedor.cod_cargo = ddlCargo.SelectedValue
        drVendedor.endereco = txtendereco.Text
        drVendedor.cidade = txtcidade.Text
        drVendedor.telefone = txttelefone.Text
        drVendedor.obs = txtobs.Text

        If Me.Status = "I" Then

            txtcod_vend.Text = oVendedor.Inserir(drVendedor)
            Me.Identificacao = drVendedor.cod_vend
            txtcod_vend.Text = drVendedor.cod_vend
        ElseIf Me.Status = "A" Then
            drVendedor.cod_vend = Me.Identificacao
            txtcod_vend.Text = oVendedor.Atualizar(drVendedor)
        End If

        Consulta()
        lblMenssagem.Text = "Informações salvas com sucesso!"
    End Sub

    Sub CoordenaCampos()
        txtcod_vend.Enabled = False
        txtsobrenome.Enabled = False
        txtpri_nome.Enabled = False
        ddlCargo.Enabled = False
        txtendereco.Enabled = False
        txtcidade.Enabled = False
        txttelefone.Enabled = False
        txtobs.Enabled = False

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

                txtcod_vend.Enabled = False

                txtsobrenome.Enabled = True
                txtpri_nome.Enabled = True
                ddlCargo.Enabled = True
                txtendereco.Enabled = True
                txtcidade.Enabled = True
                txttelefone.Enabled = True
                txtobs.Enabled = True

                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
                LimpaCampos()

            Case "A" ' Alterando

                lblStatus.Text = "Alteração"

                txtcod_vend.Enabled = False

                txtsobrenome.Enabled = True
                txtpri_nome.Enabled = True
                ddlCargo.Enabled = True
                txtendereco.Enabled = True
                txtcidade.Enabled = True
                txttelefone.Enabled = True
                txtobs.Enabled = True

                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
        End Select
    End Sub

    Sub CarregaRegistro()
        Dim oVendedor As New vendedor

        Dim ds As New dsVendedor
        Dim drVendedor As dsVendedor.VendedorRow = ds.Vendedor.NewVendedorRow

        drVendedor.cod_vend = Me.Identificacao

        If oVendedor.Localizar(drVendedor) Then

            txtcod_vend.Text = drVendedor.cod_vend
            txtsobrenome.Text = drVendedor.sobrenome
            txtpri_nome.Text = drVendedor.pri_nome
            ddlCargo.SelectedValue = drVendedor.cod_cargo
            txtendereco.Text = drVendedor.endereco
            txtcidade.Text = drVendedor.cidade
            txttelefone.Text = drVendedor.telefone
            txtobs.Text = drVendedor.obs
        End If
    End Sub
#End Region

#Region "Eventos Página "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                Me.Identificacao = Request.QueryString("id")

                ibtnDesfazer.Attributes.Add("onclick", _
                "Javascript: return confirm('Deseja realmente desfazer a operação?')")

                ibtnExcluir.Attributes.Add("onclick", _
                "Javascript: return confirm('Confirma a exclusão?')")

                CarregaCargos()

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




