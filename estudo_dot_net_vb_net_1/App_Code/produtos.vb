Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Public Class produtos

    Public Function Localizar(ByRef dr As dsProdutos.ProdutosRow) As Boolean

        Dim lRetorno As Boolean = False
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_prod,produto,preco_unit,estoque " & _
                                    "from produtos " & _
                                    "where cod_prod = @cod_prod "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_prod", DbType.String, dr.cod_prod)

        Dim ds As New dsProdutos
        db.LoadDataSet(oCmd, ds, "produtos")

        If ds.Produtos.Rows.Count > 0 Then
            dr = ds.Produtos.Rows(0)
            lRetorno = True
        End If

        Return lRetorno
    End Function

    Public Function Consultar(ByVal dr As dsProdutos.ProdutosRow) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_prod,produto,preco_unit,estoque " & _
                                    "from produtos " & _
                                    "where produto like @produto"

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "produto", DbType.String, "%" + dr.produto + "%")

        Return db.ExecuteDataSet(oCmd).Tables(0)
    End Function

    Public Function Inserir(ByRef dr As dsProdutos.ProdutosRow) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Insert into Produtos (cod_prod,produto,preco_unit,estoque) " & _
        "values (@cod_prod,@produto,@preco_unit,@estoque)"

        dr.cod_prod = Me.ProxCod

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_prod", DbType.String, dr.cod_prod)
        db.AddInParameter(oCmd, "produto", DbType.String, dr.produto)
        db.AddInParameter(oCmd, "preco_unit", DbType.Decimal, dr.preco_unit)
        db.AddInParameter(oCmd, "estoque", DbType.Decimal, dr.estoque)

        Return db.ExecuteNonQuery(oCmd)
    End Function

    Public Function Alterar(ByVal dr As dsProdutos.ProdutosRow) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Update Produtos set " & _
                                   "produto = @produto," & _
                                    "preco_unit = @preco_unit," & _
                                    "estoque = @estoque " & _
                                    "where cod_prod = @cod_prod "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_prod", DbType.String, dr.cod_prod)
        db.AddInParameter(oCmd, "produto", DbType.String, dr.produto)
        db.AddInParameter(oCmd, "preco_unit", DbType.Decimal, dr.preco_unit)
        db.AddInParameter(oCmd, "estoque", DbType.Decimal, dr.estoque)

        Return db.ExecuteNonQuery(oCmd)
    End Function

    Public Function AtualizaEstoque(ByVal dr As dsProdutos.ProdutosRow) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Update Produtos set " & _
                                    "estoque = @estoque " & _
                                    "where cod_prod = @cod_prod "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_prod", DbType.String, dr.cod_prod)
        db.AddInParameter(oCmd, "estoque", DbType.Decimal, dr.estoque)

        Return db.ExecuteNonQuery(oCmd)
    End Function

    Public Sub Excluir(ByVal Cod As String)
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Delete from Produtos where cod_prod = @cod_prod"

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_prod", DbType.String, Cod)

        db.ExecuteNonQuery(oCmd)

    End Sub

    Protected Friend Function ProxCod() As String
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim query As String = "Select max(cod_prod) as MAIOR from produtos"
        Dim oCmd As DbCommand = db.GetSqlStringCommand(query)
        Dim maior As Integer = db.ExecuteScalar(oCmd) + 1

        Return maior.ToString.PadLeft(6, "0")
    End Function

End Class



