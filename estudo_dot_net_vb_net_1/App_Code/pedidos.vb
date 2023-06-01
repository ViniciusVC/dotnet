Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Public Class pedidos

    Protected Friend Function ProxCod() As String

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim query As String = "Select max(cod_ped) as MAIOR from pedidos"
        Dim oCmd As DbCommand = db.GetSqlStringCommand(query)
        Dim maior As Integer = db.ExecuteScalar(oCmd) + 1

        Return maior.ToString.PadLeft(6, "0")
    End Function

    Public Function Localizar(ByRef dr As dsPedidos.PedidosRow) As Boolean

        Dim lRetorno As Boolean = False

        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select a.cod_ped,a.cod_cli,a.cod_vend,a.entreg_nm,a.entreg_end,a.entreg_cid,a.datapedido, b.nome as nomecliente, b.empresa as empresacliente from pedidos a " & _
                                    "left join clientes b on a.cod_cli = b.cod_cli " & _
                                    "where a.cod_ped = @cod_ped "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_ped", DbType.String, dr.cod_ped)

        Dim ds As New dsPedidos
        db.LoadDataSet(oCmd, ds, "pedidos")

        If ds.Pedidos.Rows.Count > 0 Then
            dr = ds.Pedidos.Rows(0)
            lRetorno = True
        End If

        Return lRetorno
    End Function

    Public Function consultar(ByVal dataIni As String, ByVal datafim As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select a.cod_ped,a.cod_cli,a.cod_vend,a.entreg_nm,a.entreg_end,a.entreg_cid,a.datapedido, b.nome as nomecliente, b.empresa as empresacliente from pedidos a " & _
                                    "left join clientes b on a.cod_cli = b.cod_cli " & _
                                    "where a.datapedido >= @dataIni and a.datapedido <= @dataFim "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "dataIni", DbType.DateTime, dataIni)
        db.AddInParameter(oCmd, "dataFim", DbType.DateTime, datafim)

        Return db.ExecuteDataSet(oCmd).Tables(0)
    End Function


    Public Function Inserir(ByRef dr As dsPedidos.PedidosRow) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Insert into Pedidos (cod_ped,cod_cli,cod_vend,entreg_nm,entreg_end,entreg_cid,datapedido) " & _
        "values (@cod_ped,@cod_cli,@cod_vend,@entreg_nm,@entreg_end,@entreg_cid,@datapedido)"

        dr.cod_ped = Me.ProxCod

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_ped", DbType.String, dr.cod_ped)
        db.AddInParameter(oCmd, "cod_cli", DbType.String, dr.cod_cli)
        db.AddInParameter(oCmd, "cod_vend", DbType.String, dr.cod_vend)
        db.AddInParameter(oCmd, "entreg_nm", DbType.String, dr.entreg_nm)
        db.AddInParameter(oCmd, "entreg_end", DbType.String, dr.entreg_end)
        db.AddInParameter(oCmd, "entreg_cid", DbType.String, dr.entreg_cid)
        db.AddInParameter(oCmd, "datapedido", DbType.DateTime, dr.datapedido)

        Return db.ExecuteNonQuery(oCmd)
    End Function

    Public Function Alterar(ByRef dr As dsPedidos.PedidosRow) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Update Pedidos set " & _
                                    "cod_cli = @cod_cli," & _
                                    "cod_vend = @cod_vend," & _
                                    "entreg_nm = @entreg_nm," & _
                                    "entreg_end = @entreg_end, " & _
                                    "entreg_cid = @entreg_cid, " & _
                                    "datapedido = @datapedido " & _
                                    "where cod_ped = @cod_ped "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_ped", DbType.String, dr.cod_ped)
        db.AddInParameter(oCmd, "cod_cli", DbType.String, dr.cod_cli)
        db.AddInParameter(oCmd, "cod_vend", DbType.String, dr.cod_vend)
        db.AddInParameter(oCmd, "entreg_nm", DbType.String, dr.entreg_nm)
        db.AddInParameter(oCmd, "entreg_end", DbType.String, dr.entreg_end)
        db.AddInParameter(oCmd, "entreg_cid", DbType.String, dr.entreg_cid)
        db.AddInParameter(oCmd, "datapedido", DbType.DateTime, dr.datapedido)

        Return db.ExecuteNonQuery(oCmd)
    End Function

    Public Function Excluir(ByVal Cod As String)
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Delete from Pedidos where cod_ped = @cod_ped"
        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_ped", DbType.String, Cod)

        Return db.ExecuteNonQuery(oCmd)
    End Function


    Public Function RelatorioPedidos() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select a.cod_ped,a.cod_cli,a.cod_vend, " & _
                                    "b.nome as nomecliente,a.datapedido, " & _
                                    "i.preco_unit,i.quant ,i.cod_prod,p.produto as nomeproduto " & _
                                    "from pedidos a " & _
                                    "left join clientes b on a.cod_cli = b.cod_cli " & _
                                    "left join itens i on i.cod_ped = a.cod_ped " & _
                                    "left join Produtos p on p.cod_prod = i.cod_prod "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)

        Return db.ExecuteDataSet(oCmd).Tables(0)
    End Function


End Class



