Imports System.Data

Partial Class pesq_cliente
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
        Try
            Dim oClientes As New clientes

            Dim ds As New dsClientes
            Dim drCliente As dsClientes.ClientesRow = ds.Clientes.NewClientesRow

            drCliente.nome = txtPesquisa.Text

            Dim dt As DataTable = oClientes.Consultar(drCliente)

            lblRegistros.Text = "Registros: " + dt.Rows.Count.ToString

            Me.DataTablePesquisa = dt

            CarregaGridView()

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Sub CarregaGridView()
        Try
            DataTablePesquisa.DefaultView.Sort = Me.OrdemPesquisa
            GridViewPesquisa.DataSource = DataTablePesquisa.DefaultView
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

    Protected Sub btnPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            CarregaPesquisa()
        Catch ex As Exception
            lblError.Text = ex.Message.ToString
        End Try
    End Sub
End Class
