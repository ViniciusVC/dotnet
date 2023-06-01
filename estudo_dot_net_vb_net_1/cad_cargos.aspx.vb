Partial Class cad_cargos

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
        txtCod_Cargo.Text = Nothing
        txtCargo.Text = Nothing
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
        Dim ocargos As New cargos
        ocargos.Excluir(Me.Identificacao)
    End Sub

    Sub CoordenaCampos()
        txtCod_Cargo.Enabled = False
        txtCargo.Enabled = False

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
                txtCargo.Enabled = True
                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
                LimpaCampos()

            Case "A" ' Alterando
                lblStatus.Text = "Alteração"
                txtCargo.Enabled = True
                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
        End Select
    End Sub

    Sub Gravar()

        Dim oCargos As New cargos

        Dim ds As New DsCargos
        Dim drCargo As DsCargos.CargosRow = ds.Cargos.NewCargosRow

        drCargo.cargo = txtCargo.Text

        If Me.Status = "I" Then
            oCargos.Inserir(drCargo)
            Me.Identificacao = drCargo.cod_cargo
            txtCod_Cargo.Text = drCargo.cod_cargo
        ElseIf Me.Status = "A" Then
            drCargo.cod_cargo = Me.Identificacao
            oCargos.Atualizar(drCargo)
        End If

        Consulta()

        lblMenssagem.Text = "Informações salvas com sucesso!"
    End Sub

    Sub CarregaRegistro()

        Dim cargos As New cargos
        Dim ds As New DsCargos
        Dim drCargo As DsCargos.CargosRow = ds.Cargos.NewCargosRow

        drCargo.cod_cargo = Me.Identificacao

        If cargos.Localizar(drCargo) Then
            txtCod_Cargo.Text = drCargo.cod_cargo
            txtCargo.Text = drCargo.cargo
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
            Me.Identificacao = Nothing

            Inclusao()
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



