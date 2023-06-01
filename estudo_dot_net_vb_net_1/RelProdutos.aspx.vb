Imports Microsoft.Reporting.WebForms
Imports System.Data

Partial Class RelProdutos
    Inherits System.Web.UI.Page

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'If Not IsPostBack Then
        '    Try
        '        Dim oProdutos As New produtos 'Declara objeto produto

        '        Dim ds As New dsProdutos 'Cria um objeto DataSetProduto
        '        Dim drProdutos As dsProdutos.ProdutosRow = ds.Produtos.NewProdutosRow

        '        drProdutos.produto = "" 'Busca por qualquer produto dentro do relatório

        '        Dim dt As DataTable = oProdutos.Consultar(drProdutos) 'Declara 

        '        If dt.Rows.Count > 0 Then

        '            Dim auxReport As LocalReport = ReportViewerProdutos.LocalReport
        '            auxReport.ReportPath = "relats/Rprodutos.rdlc"

        '            Dim auxDataSourceProdutos As New ReportDataSource()
        '            auxDataSourceProdutos.Name = "dsProdutos_Produtos"
        '            auxDataSourceProdutos.Value = dt
        '            auxReport.DataSources.Add(auxDataSourceProdutos)
        '        End If

        '    Catch ex As Exception
        '        lblError.Text = ex.ToString
        '    End Try
        'End If
    End Sub

    Protected Sub butgerar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        'If Not IsPostBack Then
        Try
            Dim oProdutos As New produtos 'Declara objeto produto

            Dim ds As New dsProdutos 'Cria um objeto DataSetProduto
            Dim drProdutos As dsProdutos.ProdutosRow = ds.Produtos.NewProdutosRow

            drProdutos.produto = txtBusca.Text  'Busca por qualquer produto dentro do relatório

            Dim dt As DataTable = oProdutos.Consultar(drProdutos) 'Declara 

            If dt.Rows.Count > 0 Then

                Dim auxReport As LocalReport = ReportViewerProdutos.LocalReport
                auxReport.ReportPath = "relats/Rprodutos.rdlc"

                Dim auxDataSourceProdutos As New ReportDataSource()
                auxDataSourceProdutos.Name = "dsProdutos_Produtos"
                auxDataSourceProdutos.Value = dt
                auxReport.DataSources.Add(auxDataSourceProdutos)
            End If

        Catch ex As Exception
            lblError.Text = ex.ToString
        End Try
        ' End If


    End Sub
End Class
