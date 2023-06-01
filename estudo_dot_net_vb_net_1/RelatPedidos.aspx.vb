Imports Microsoft.Reporting.WebForms
Imports System.Data

Partial Class RelatPedidos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Try

                Dim oPedidos As New pedidos 'Declara objeto produto

                Dim ds As New dsPedidos 'Cria um objeto DataSetProduto

                Dim dt As DataTable = oPedidos.RelatorioPedidos() 'Declara 

                If dt.Rows.Count > 0 Then

                    Dim auxReport As LocalReport = ReportViewer1.LocalReport
                    auxReport.ReportPath = "relats/Rpedidos.rdlc"

                    Dim auxDataSourcePedidos As New ReportDataSource()
                    auxDataSourcePedidos.Name = "dsPedidos_Pedidos"
                    auxDataSourcePedidos.Value = dt
                    auxReport.DataSources.Add(auxDataSourcePedidos)
                End If

            Catch ex As Exception
                'lblError.Text = ex.ToString
            End Try
        End If
    End Sub

End Class
