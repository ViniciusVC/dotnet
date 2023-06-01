Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports System.Transactions

Public Class itens

    Public Function Listar(ByVal cod_ped As String, ByVal cod_prod As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select a.*, a.preco_unit * a.quant as subtotal,  b.produto as produto from itens a " & _
        "left join produtos b on a.cod_prod = b.cod_prod where a.cod_ped = @cod and a.cod_prod = @cod_prod "


        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod", DbType.String, cod_ped)
        db.AddInParameter(oCmd, "cod_prod", DbType.String, cod_prod)

        Return db.ExecuteDataSet(oCmd).Tables(0)
    End Function

    Public Function Consultar(ByVal dr As dsItens.ItensRow) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select a.*, a.preco_unit * a.quant as subtotal, b.produto as produto from itens a " & _
                                    "left join produtos b on a.cod_prod = b.cod_prod " + _
                                    "where a.cod_ped = @cod "


        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod", DbType.String, dr.cod_ped)

        Return db.ExecuteDataSet(oCmd).Tables(0)
    End Function

    Public Sub Inserir(ByVal drItem As dsItens.ItensRow)
        Dim db As Database = DatabaseFactory.CreateDatabase

        Using Transacao As New TransactionScope
            'PROCURA PRODUTO NO ESTOQUE
            Dim oProd As New produtos
            Dim ds As New dsProdutos
            Dim drProduto As dsProdutos.ProdutosRow = ds.Produtos.NewProdutosRow

            drProduto.cod_prod = drItem.cod_prod

            If oProd.Localizar(drProduto) Then

                'ATUALIZA ESTOQUE
                Dim PosicaoAtualEstoque As Integer = drProduto.estoque
                Dim NovaPosicaEstoque As Integer = PosicaoAtualEstoque - drItem.quant

                drProduto.estoque = NovaPosicaEstoque
                oProd.AtualizaEstoque(drProduto)

                'INSERE OS ITENS
                Const sSqlExpr As String = "Insert into Itens (cod_ped,cod_prod,preco_unit,quant) " & _
                       "values (@cod_ped,@cod_prod,@preco_unit,@quant)"

                Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
                db.AddInParameter(oCmd, "cod_ped", DbType.String, drItem.cod_ped)
                db.AddInParameter(oCmd, "cod_prod", DbType.String, drItem.cod_prod)
                db.AddInParameter(oCmd, "preco_unit", DbType.Decimal, drItem.preco_unit)
                db.AddInParameter(oCmd, "quant", DbType.Decimal, drItem.quant)

                db.ExecuteNonQuery(oCmd)
            End If

            Transacao.Complete()
        End Using
    End Sub

    Public Sub Alterar(ByVal drItem As dsItens.ItensRow, ByVal Quant_Old As Integer)

        Dim db As Database = DatabaseFactory.CreateDatabase

        Using Transacao As New TransactionScope

            'PROCURA PRODUTO NO ESTOQUE
            Dim oProd As New produtos
            Dim ds As New dsProdutos
            Dim drProduto As dsProdutos.ProdutosRow = ds.Produtos.NewProdutosRow

            drProduto.cod_prod = drItem.cod_prod

            If oProd.Localizar(drProduto) Then

                Dim PosicaoAtualEstoque As Integer = drProduto.estoque

                ' Verifico a diferença do estava antes (me.Quant_old) na quantidade para atualizar o estoque
                Dim Diferenca As Integer = Quant_Old - drItem.quant
                Dim NovaPosicaEstoque As Integer = PosicaoAtualEstoque + Diferenca

                'ATUALIZA ESTOQUE
                drProduto.estoque = NovaPosicaEstoque
                oProd.AtualizaEstoque(drProduto)

                'ATUALIZA OS ITENS
                Const sSqlExpr As String = "Update Itens set " & _
                                            "preco_unit = @preco_unit," & _
                                            "quant = @quant " & _
                                            "where cod_prod = @cod_prod and cod_ped = @cod_ped"

                Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
                db.AddInParameter(oCmd, "cod_ped", DbType.String, drItem.cod_ped)
                db.AddInParameter(oCmd, "cod_prod", DbType.String, drItem.cod_prod)
                db.AddInParameter(oCmd, "preco_unit", DbType.Decimal, drItem.preco_unit)
                db.AddInParameter(oCmd, "quant", DbType.Decimal, drItem.quant)

                db.ExecuteNonQuery(oCmd)
            End If

            Transacao.Complete()
        End Using
    End Sub

    Public Sub Excluir(ByVal drItem As dsItens.ItensRow)

        Dim db As Database = DatabaseFactory.CreateDatabase

        Using Transacao As New TransactionScope

            'PROCURA PRODUTO NO ESTOQUE
            Dim oProd As New produtos
            Dim ds As New dsProdutos
            Dim drProduto As dsProdutos.ProdutosRow = ds.Produtos.NewProdutosRow

            drProduto.cod_prod = drItem.cod_prod

            If oProd.Localizar(drProduto) > 0 Then

                Dim PosicaoAtualEstoque As Integer = drProduto.estoque
                Dim NovaPosicaEstoque As Integer = PosicaoAtualEstoque + drItem.quant

                'ATUALIZA ESTOQUE
                drProduto.estoque = NovaPosicaEstoque
                oProd.AtualizaEstoque(drProduto)

                'ATUALIZA OS ITENS
                Const sSqlExpr As String = "Delete from Itens where cod_prod = @cod_prod and cod_ped = @cod_ped"

                Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
                db.AddInParameter(oCmd, "cod_ped", DbType.String, drItem.cod_ped)
                db.AddInParameter(oCmd, "cod_prod", DbType.String, drItem.cod_prod)

                db.ExecuteNonQuery(oCmd)
            End If

            Transacao.Complete()
        End Using
    End Sub

End Class



