Imports System.Data

Partial Class pesq_cargo
    Inherits System.Web.UI.Page

    Public Property DatasetPesquisa() As DataSet
        Get
            Return ViewState("DatasetPesquisa")
        End Get
        Set(ByVal value As DataSet)
            ViewState("DatasetPesquisa") = value
        End Set
    End Property

    Public Property OrdemPesquisa() As String
        Get
            Return ViewState("OrdemPesquisa")
        End Get
        Set(ByVal value As String)
            ViewState("OrdemPesquisa") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                CarregaPesquisa()
            Catch ex As Exception
                lblError.Text = ex.Message.ToString
            End Try
        End If
    End Sub

    Sub CarregaPesquisa()
        Try
            Dim oCargos As New cargos
            Dim dtCargos As DataTable

            dtCargos = oCargos.Listar

            lblRegistros.Text = "Registros: " + dtCargos.Rows.Count.ToString

            Me.DatasetPesquisa = dtCargos.DataSet

            CarregaGridView()

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Sub CarregaGridView()
        Try
            Me.DatasetPesquisa.Tables(0).DefaultView.Sort = Me.OrdemPesquisa
            GridViewPesquisa.DataSource = Me.DatasetPesquisa.Tables(0).DefaultView
            GridViewPesquisa.DataBind()

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Protected Sub GridViewPesquisa_PageIndexChanging(ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridViewPesquisa.PageIndexChanging
        Try
            GridViewPesquisa.PageIndex = e.NewPageIndex
            CarregaGridView()
        Catch ex As Exception
            lblError.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub GridViewPesquisa_Sorting(ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridViewPesquisa.Sorting
        Try
            Me.OrdemPesquisa = e.SortExpression
            CarregaGridView()
        Catch ex As Exception
            lblError.Text = ex.Message.ToString
        End Try
    End Sub

End Class
