Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Public Class clientes

    Public Function Listar() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_ped,nome,empresa,datapedido " & _
        "from pedidos inner join clientes on clientes.cod_cli = pedidos.cod_cli " & _
        "where pedidos.datapedido = @data"

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "data", DbType.Date, Now.Date)

        Return db.ExecuteDataSet(oCmd).Tables(0)

    End Function

    Public Function Localizar(ByRef dr As dsClientes.ClientesRow) As Boolean

        Dim lRetorno As Boolean = False
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_cli,nome,empresa,endereco,cidade,telefone, cod_cargo " & _
                                    "from clientes " + _
                                    "where cod_cli = @cod_cli "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_cli", DbType.String, dr.cod_cli)

        Dim ds As New dsClientes
        db.LoadDataSet(oCmd, ds, "clientes")

        If ds.Clientes.Rows.Count > 0 Then
            dr = ds.Clientes.Rows(0)
            lRetorno = True
        End If

        Return lRetorno
    End Function

    Public Function Consultar(ByVal ds As dsClientes.ClientesRow) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "select cod_cli,nome,empresa,endereco,cidade,telefone,cod_cargo " & _
                                    "from clientes " & _
                                    "where nome like @nome "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "nome", DbType.String, "%" + ds.nome + "%")

        Return db.ExecuteDataSet(oCmd).Tables(0)
    End Function

    Public Function Inserir(ByVal dr As dsClientes.ClientesRow) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Insert into clientes (cod_cli,empresa,nome,cod_cargo,endereco,cidade,telefone) " & _
        "values (@cod_cli,@empresa,@nome,@cod_cargo,@endereco,@cidade,@telefone)"

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_cli", DbType.String, dr.cod_cli)
        db.AddInParameter(oCmd, "empresa", DbType.String, dr.empresa)
        db.AddInParameter(oCmd, "nome", DbType.String, dr.nome)
        db.AddInParameter(oCmd, "cod_cargo", DbType.String, dr.cod_cargo)
        db.AddInParameter(oCmd, "endereco", DbType.String, dr.endereco)
        db.AddInParameter(oCmd, "cidade", DbType.String, dr.cidade)
        db.AddInParameter(oCmd, "telefone", DbType.String, dr.telefone)

        Return db.ExecuteNonQuery(oCmd)
    End Function

    Public Function Alterar(ByVal dr As dsClientes.ClientesRow) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Update Clientes set " & _
                                    "empresa = @empresa," & _
                                    "nome = @nome," & _
                                    "cod_cargo = @cod_cargo," & _
                                    "endereco = @endereco," & _
                                    "cidade = @cidade," & _
                                    "telefone = @telefone " & _
                                    "where cod_cli = @cod_cli "

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_cli", DbType.String, dr.cod_cli)
        db.AddInParameter(oCmd, "empresa", DbType.String, dr.empresa)
        db.AddInParameter(oCmd, "nome", DbType.String, dr.nome)
        db.AddInParameter(oCmd, "cod_cargo", DbType.String, dr.cod_cargo)
        db.AddInParameter(oCmd, "endereco", DbType.String, dr.endereco)
        db.AddInParameter(oCmd, "cidade", DbType.String, dr.cidade)
        db.AddInParameter(oCmd, "telefone", DbType.String, dr.telefone)

        Return db.ExecuteNonQuery(oCmd)
    End Function

    Public Function Excluir(ByVal Cod As String) As String
        Dim db As Database = DatabaseFactory.CreateDatabase

        Const sSqlExpr As String = "Delete from Clientes where cod_cli = @cod_cli"

        Dim oCmd As DbCommand = db.GetSqlStringCommand(sSqlExpr)
        db.AddInParameter(oCmd, "cod_cli", DbType.String, Cod)

        Return db.ExecuteNonQuery(oCmd)
    End Function
End Class



