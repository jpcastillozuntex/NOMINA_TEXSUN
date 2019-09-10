Public Class Clsconexion


    Public Function AbrirConexion(ByVal mensaje As String)
        SqlConexion.ConnectionString = "Data Source=192.9.200.3\TEXSUN;Initial Catalog=NOMINA;User ID=nominas;Password=Nominor_0"

        Try
            SqlConexion.Open()
            mensaje = "Base de datos Abierta"
            Return True
        Catch ex As Exception
            mensaje = "Error al abrir Base de Datos" & ex.Message
            Return True
        End Try
    End Function

    Public Sub CerrarConexion()
        Try
            SqlConexion.Close()
        Catch
            Err.Clear()
        End Try
    End Sub


    Public Function AbrirConNoc(ByVal mensaje As String)
        Try
            SqlConConfi.Open()
            mensaje = "Base de datos Abierta"
            Return True
        Catch ex As Exception
            mensaje = "Error al abrir Base de Datos" & ex.Message
            Return True
        End Try
    End Function

    Public Sub CerrarConNoc()
        Try
            SqlConConfi.Close()
        Catch
            Err.Clear()
        End Try
    End Sub


End Class