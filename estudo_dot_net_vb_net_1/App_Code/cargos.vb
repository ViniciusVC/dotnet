Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Public Class cargos

    Public Function Listar() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_cargo,cargo from cargos"

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)

        Return db.ExecuteDataSet(oCmd).Tables(0)
    End Function

    Public Function Localizar(ByRef dr As DsCargos.CargosRow) As Boolean

        Dim lRetorno As Boolean = False
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_cargo,cargo from cargos where cod_cargo = @cod_cargo"

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_cargo", DbType.String, dr.cod_cargo)

        Dim ds As New DsCargos
        db.LoadDataSet(oCmd, ds, "cargos")

        If ds.Cargos.Rows.Count > 0 Then
            dr = ds.Cargos.Rows(0)
            lRetorno = True
        End If

        Return lRetorno
    End Function


    Public Function Consultar(ByVal ds As DsCargos.CargosRow) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_cargo,cargo from cargos where cargo like @cod_cargo"
        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)

        db.AddInParameter(oCmd, "cod_cargo", DbType.String, "%" + ds.cargo + "%")

        Return db.ExecuteDataSet(oCmd).Tables(0)
    End Function

    Public Function Inserir(ByRef dr As DsCargos.CargosRow) As String

        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Insert into Cargos (cod_cargo,cargo) values (@cod_cargo,@cargo)"

        dr.cod_cargo = Me.ProxCod()

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_cargo", DbType.String, dr.cod_cargo)
        db.AddInParameter(oCmd, "cargo", DbType.String, dr.cargo)

        Return db.ExecuteNonQuery(oCmd)
    End Function

    Public Function Atualizar(ByVal ds As DsCargos.CargosRow) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Update Cargos set " & _
        "cargo = @cargo where cod_cargo = @cod_cargo "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cargo", DbType.String, ds.cargo)
        db.AddInParameter(oCmd, "cod_cargo", DbType.String, ds.cod_cargo)

        Return db.ExecuteNonQuery(oCmd)
    End Function

    Protected Friend Function ProxCod() As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Dim query As String = "Select max(cod_cargo) as MAIOR from cargos"
        Dim oCmd As DbCommand = db.GetSqlStringCommand(query)
        Dim maior As Integer = db.ExecuteScalar(oCmd) + 1

        Return maior.ToString.PadLeft(2, "0")
    End Function

    Public Function Excluir(ByVal Cod As String)
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Delete from Cargos where cod_cargo = @cod_cargo"
        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_cargo", DbType.String, Cod)

        Return db.ExecuteNonQuery(oCmd)
    End Function

End Class


