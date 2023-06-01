Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Public Class vendedor

    Protected Friend Function ProxCod() As String
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim query As String = "Select max(cod_cargo) as MAIOR from vendedor"
        Dim oCmd As DbCommand = db.GetSqlStringCommand(query)
        Dim maior As Integer = db.ExecuteScalar(oCmd) + 1

        Return maior.ToString.PadLeft(6, "0")
    End Function

    Public Function Listar() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_vend,sobrenome,pri_nome,cidade " & _
        "from vendedor "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)

        Return db.ExecuteDataSet(oCmd).Tables(0)

    End Function

    Public Function Localizar(ByRef dr As dsVendedor.VendedorRow) As Boolean

        Dim lRetorno As Boolean = False

        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_vend,sobrenome,pri_nome,cidade,cidade,cod_cargo,endereco,telefone,obs " & _
                                    "from Vendedor " & _
                                    "where cod_vend = @cod_vend "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_vend", DbType.String, dr.cod_vend)

        Dim ds As New dsVendedor
        db.LoadDataSet(oCmd, ds, "Vendedor")

        If ds.Vendedor.Rows.Count > 0 Then
            dr = ds.Vendedor.Rows(0)
            lRetorno = True
        End If

        Return lRetorno
    End Function

    Public Function Consultar(ByVal dr As dsVendedor.VendedorRow) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_vend,sobrenome,pri_nome,cidade,cod_cargo,endereco,telefone,obs " & _
        "from vendedor " & _
        "where pri_nome like @pri_nome"

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "pri_nome", DbType.String, "%" + dr.pri_nome + "%")

        Return db.ExecuteDataSet(oCmd).Tables(0)
    End Function

    Public Function Inserir(ByRef dr As dsVendedor.VendedorRow) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Insert into vendedor (cod_vend,sobrenome,pri_nome,cod_cargo,endereco,cidade,telefone,obs) " & _
        "values (@cod_vend,@sobrenome,@pri_nome,@cod_cargo,@endereco,@cidade,@telefone,@obs)"

        dr.cod_vend = Me.ProxCod

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_vend", DbType.String, dr.cod_vend)
        db.AddInParameter(oCmd, "sobrenome", DbType.String, dr.sobrenome)
        db.AddInParameter(oCmd, "pri_nome", DbType.String, dr.pri_nome)
        db.AddInParameter(oCmd, "cod_cargo", DbType.String, dr.cod_cargo)
        db.AddInParameter(oCmd, "endereco", DbType.String, dr.endereco)
        db.AddInParameter(oCmd, "cidade", DbType.String, dr.cidade)
        db.AddInParameter(oCmd, "telefone", DbType.String, dr.telefone)
        db.AddInParameter(oCmd, "obs", DbType.String, dr.obs)

        Return db.ExecuteNonQuery(oCmd)
    End Function


    Public Function Atualizar(ByVal dr As dsVendedor.VendedorRow) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Update Vendedor set " & _
                                    "sobrenome = @sobrenome, " & _
                                    "pri_nome = @pri_nome, " & _
                                    "cod_cargo = @cod_cargo," & _
                                    "endereco = @endereco, " & _
                                    "cidade = @cidade, " & _
                                    "telefone = @telefone, " & _
                                    "obs = @obs " & _
                                    "where cod_vend = @cod_vend "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_vend", DbType.String, dr.cod_vend)
        db.AddInParameter(oCmd, "sobrenome", DbType.String, dr.sobrenome)
        db.AddInParameter(oCmd, "pri_nome", DbType.String, dr.pri_nome)
        db.AddInParameter(oCmd, "cod_cargo", DbType.String, dr.cod_cargo)
        db.AddInParameter(oCmd, "endereco", DbType.String, dr.endereco)
        db.AddInParameter(oCmd, "cidade", DbType.String, dr.cidade)
        db.AddInParameter(oCmd, "telefone", DbType.String, dr.telefone)
        db.AddInParameter(oCmd, "obs", DbType.String, dr.obs)

        Return db.ExecuteNonQuery(oCmd)
    End Function

    Public Sub Excluir(ByVal Cod As String)
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Delete from Vendedor where cod_vend = @cod_vend"

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_vend", DbType.String, Cod)

        db.ExecuteNonQuery(oCmd)
    End Sub

End Class



