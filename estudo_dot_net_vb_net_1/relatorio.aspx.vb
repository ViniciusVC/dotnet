Imports Microsoft.Reporting.WebForms
Imports System.Data

Partial Class relatorio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim oClientes As New clientes

                Dim ds As New dsClientes
                Dim drCliente As dsClientes.ClientesRow = ds.Clientes.NewClientesRow
                drCliente.nome = ""

                Dim dt As DataTable = oClientes.Consultar(drCliente)

                If dt.Rows.Count > 0 Then

                    Dim auxReport As LocalReport = ReportViewer1.LocalReport
                    auxReport.ReportPath = "relats/rclientes.rdlc"

                    Dim auxDataSourceClientes As New ReportDataSource()
                    auxDataSourceClientes.Name = "dsClientes_Clientes"
                    auxDataSourceClientes.Value = dt

                    auxReport.DataSources.Add(auxDataSourceClientes)
                End If

            Catch ex As Exception
                lblError.Text = ex.ToString
            End Try
        End If
    End Sub
End Class
