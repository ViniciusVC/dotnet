
Imports Funcoes

Partial Class cad_clientes

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
        Try
            Dim oCargos As New cargos
            ddlCargo.DataTextField = "cargo"
            ddlCargo.DataValueField = "cod_cargo"

            ddlCargo.DataSource = oCargos.Listar
            ddlCargo.DataBind()
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Sub LimpaCampos()

        txtcod_cli.Text = Nothing
        txtempresa.Text = Nothing
        txtnome.Text = Nothing
        ddlCargo.SelectedValue = Nothing
        txtendereco.Text = Nothing
        txtcidade.Text = Nothing
        txttelefone.Text = Nothing

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
        Dim oClientes As New clientes
        oClientes.Excluir(Me.Identificacao)
    End Sub

    Sub Gravar()

        Dim oClientes As New clientes

        Dim ds As New dsClientes
        Dim drClientes As dsClientes.ClientesRow = ds.Clientes.NewClientesRow

        drClientes.cod_cli = txtcod_cli.Text
        drClientes.empresa = txtempresa.Text
        drClientes.nome = txtnome.Text
        drClientes.cod_cargo = ddlCargo.SelectedValue
        drClientes.endereco = txtendereco.Text
        drClientes.cidade = txtcidade.Text
        drClientes.telefone = txttelefone.Text

        If Me.Status = "I" Then
            oClientes.Inserir(drClientes)
        ElseIf Me.Status = "A" Then
            oClientes.Alterar(drClientes)
        End If

        Me.Identificacao = txtcod_cli.Text

        Consulta()

        lblMenssagem.Text = "Informações salvas com sucesso!"
    End Sub

    Sub CoordenaCampos()
        txtcod_cli.Enabled = False
        txtempresa.Enabled = False
        txtnome.Enabled = False
        ddlCargo.Enabled = False
        txtendereco.Enabled = False
        txtcidade.Enabled = False
        txttelefone.Enabled = False

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

                txtcod_cli.Enabled = True
                txtempresa.Enabled = True
                txtnome.Enabled = True
                ddlCargo.Enabled = True
                txtendereco.Enabled = True
                txtcidade.Enabled = True
                txttelefone.Enabled = True

                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True
                LimpaCampos()

            Case "A" ' Alterando

                lblStatus.Text = "Alteração"

                txtcod_cli.Enabled = True
                txtempresa.Enabled = True
                txtnome.Enabled = True
                ddlCargo.Enabled = True
                txtendereco.Enabled = True
                txtcidade.Enabled = True
                txttelefone.Enabled = True

                ibtnSalvar.Visible = True
                ibtnDesfazer.Visible = True

        End Select
    End Sub

    Sub CarregaRegistro()
        Dim oClientes As New clientes

        Dim ds As New dsClientes
        Dim drCliente As dsClientes.ClientesRow = ds.Clientes.NewClientesRow

        drCliente.cod_cli = Me.Identificacao

        If oClientes.Localizar(drCliente) Then
            txtcod_cli.Text = drCliente.cod_cli
            txtempresa.Text = drCliente.empresa
            txtnome.Text = drCliente.nome
            ddlCargo.SelectedValue = drCliente.cod_cargo
            txtendereco.Text = drCliente.endereco
            txtcidade.Text = drCliente.cidade
            txttelefone.Text = drCliente.telefone
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




