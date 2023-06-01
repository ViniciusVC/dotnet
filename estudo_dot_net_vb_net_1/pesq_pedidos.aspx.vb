Imports System.Data

Partial Class pesq_pedidos
    Inherits System.Web.UI.Page

    Public Property DataTablePesquisa() As DataTable
        Get
            Return ViewState("DataTablePesquisa")
        End Get
        Set(ByVal value As DataTable)
            ViewState("DataTablePesquisa") = value
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

    Sub CarregaPesquisa()
        Dim oPedidos As New pedidos
        Dim dt As DataTable = oPedidos.consultar(txtPesquisa.Text, txtPesquisa2.Text)

        lblRegistros.Text = "Registros: " + dt.Rows.Count.ToString

        Me.DataTablePesquisa = dt

        CarregaGridView()
    End Sub

    Sub CarregaGridView()
        DataTablePesquisa.DefaultView.Sort = Me.OrdemPesquisa
        GridViewPesquisa.DataSource = DataTablePesquisa.DefaultView
        GridViewPesquisa.DataBind()
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

    Protected Sub btnPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Try
            CarregaPesquisa()
        Catch ex As Exception
            lblError.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim dtIni As DateTime = "1" + "/" + Today.Month.ToString + "/" + Today.Year.ToString
            Dim dtFim As DateTime = dtIni.AddMonths(1).AddDays(-1)

            txtPesquisa.Text = dtIni
            txtPesquisa2.Text = dtFim

        End If
    End Sub
End Class
