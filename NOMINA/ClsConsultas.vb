Imports System.Data.SqlClient

Public Class ClsConsultas
    Inherits Clsconexion

    Dim msj As String
    Dim scr As String
    Public con As String = "Provider=SQLOLEDB.1;Password=Nominor_0;Persist Security Info=True;User ID=nominas;Initial Catalog=nomina;Data Source=192.9.200.3\TEXSUN"
    'Private _guarda_asueto As Boolean

    Public Function Listamenu(ByVal menu As Integer, ByRef idrol As Integer, ByVal dt As DataTable, ByVal msj As String)
        If AbrirConexion(msj) Then
            Dim scr As String = "select a.* from Tc_MENU as a where cod_menu in (select cod_menu from tt_rol_menu where idrol =" & idrol & ")"
            Sqlselect.CommandText = scr
            Adaptador.Fill(dt)
        End If
        Return True
    End Function

    Public Function login(ByVal password As String, ByRef nombre As String, ByRef perfil As Integer, ByRef msj As String, ByRef image As Image)
        Dim result As Boolean = False
        Dim dt As New DataTable
        Dim stmBLOBData As IO.MemoryStream
        Try
            If AbrirConexion(msj) Then
                Sqlselect.CommandText = "select * from tb_usuario"
                Adaptador.Fill(dt)
                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)("password") = password And dt.Rows(i)("estado") = "A" Then
                        nombre = dt.Rows(i)("NOMBRE_USUARIO")
                        perfil = dt.Rows(i)("COD_IDROL")
                        Try
                            Dim bytBLOBData() As Byte = dt.Rows(i)("FOTO")
                            stmBLOBData = New IO.MemoryStream(bytBLOBData)
                            image = Image.FromStream(stmBLOBData)
                        Catch ex As Exception
                        End Try
                        result = True
                        Exit For
                        result = True
                    Else
                        msj = "PASSWORD INCORRECTO O USUARIO NO EXISTE!!"
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
        CerrarConexion()
        Return result
    End Function

    Public Function consultas(ByVal script As String, ByRef tabla As DataTable, ByRef mensaje As String) As Boolean
        tabla.Clear()
        Dim respuesta As Boolean = False
        If AbrirConexion(mensaje) = True Then
            Try
                Sqlselect.CommandText = script
                Adaptador.Fill(tabla)
                If tabla.Rows.Count < 1 Then
                    mensaje = "Sin Registros"
                Else
                    respuesta = True
                End If
            Catch ex As Exception
                mensaje = ex.Message
            End Try
        End If
        CerrarConexion()
        Return respuesta
    End Function
    Public Function consulta_sin_limpiar(ByVal script As String, ByRef tabla As DataTable, ByRef mensaje As String) As Boolean
        Dim respuesta As Boolean = False
        If AbrirConexion(mensaje) = True Then
            Try
                Sqlselect.CommandText = script
                Adaptador.Fill(tabla)
                If tabla.Rows.Count < 1 Then
                    mensaje = "Sin Registros"
                Else
                    respuesta = True
                End If
            Catch ex As Exception
                mensaje = ex.Message
            End Try
        End If
        CerrarConexion()
        Return respuesta
    End Function

    Public Function primeramayus(ByVal str As String)
        Dim st2 As String = MsgBox(Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str))
        Return str
    End Function

    Public Function ValidarIngreso(ByVal User As String, ByVal Password As String, ByRef perfil As Integer, ByRef AlgunMensaje As String)
        Dim resultado As Boolean
        If AbrirConexion(AlgunMensaje) = True Then
            Dim dtDatos As New DataTable
            SqlSelect.CommandText = "SELECT USUARIO, PASSWORD, COD_ROL, ESTADO FROM TB_USUARIO WHERE USUARIO = '" & User & "'"
            Adaptador.Fill(dtDatos)
            If dtDatos.Rows.Count > 0 Then
                If dtDatos.Rows(0)("PASSWORD") = Password Then
                    If dtDatos.Rows(0)("ESTADO") <> "A" Then
                        AlgunMensaje = "El Usuario no esta activo"
                    Else
                        resultado = True
                        perfil = dtDatos.Rows(0)("cod_rol")
                    End If
                Else
                    AlgunMensaje = "password invalido"
                End If
            Else
                AlgunMensaje = "Usuario no Existe"
            End If
        End If
        CerrarConexion()
        Return resultado
    End Function

    Public Function AsignaCodigo(ByRef codigo As String, ByRef empresa As String, ByRef AlgunMensaje As String, ByRef cod_depar As String) As Boolean
        Dim estado As Boolean
        If AbrirConexion(AlgunMensaje) Then
            Dim dtDatos As New DataTable
            If cod_depar <> "15" Then
                Sqlselect.CommandText = "select max(codigo)+1 as codigo from tb_empleado where codigo_empresa= " & empresa & "and codigo < 7000"
            Else
                Sqlselect.CommandText = "select max(codigo)+1 as codigo from tb_empleado where codigo_empresa= " & empresa
            End If
            Adaptador.Fill(dtDatos)
            If dtDatos.Rows(0).IsNull("codigo") Then
                codigo = "1"
                estado = True
            ElseIf dtDatos.Rows.Count > 0 Then
                codigo = dtDatos.Rows(0)("codigo")
                estado = True
            End If
            CerrarConexion()
        End If
            Return estado
    End Function

    Public Function ListaEmpresa(ByRef Dt As DataTable, ByRef AlgunMensaje As String)
        If AbrirConexion(AlgunMensaje) = True Then
            SqlSelect.CommandText = "Select codigo, nombre_empresa From tb_empresa;"
            Adaptador.Fill(Dt)
        End If
        CerrarConexion()
        Return Dt
    End Function

    Public Function InsertaEmpleado(ByRef datos As DataTable, ByRef mensaje As String) As Boolean
        Dim resultado As Boolean
        If AbrirConexion(mensaje) = True Then
            Try
                SqlInsert.CommandText = "Insert into tb_empleado (codigo, Codigo_empresa, cod_depart, nombre, segundo_nombre, apellido, segundo_apellido, dpi, cod_departamento, cod_municipio, telefono, direccion, sexo, estado_civil,nit,cod_pais, fec_alta, fec_baja, fec_nacimiento, frecuencia_pago, codigo_puesto, afiliacion_igss, num_cuenta, estado_empleado, tipo_empleado, apellido_casada, num_hijos, nombre_esposo, tipo_pago, id_foto,sueldo_base,bonificacion,codigo_reloj,marca,turno,af_irtra,horas_ex,emp_paga,locker,centro_costo) values ('" & _
                               datos.Rows(0)("codigo") & "', '" & _
                               datos.Rows(0)("codigo_empresa") & "','" & _
                               datos.Rows(0)("cod_depart") & "','" & _
                               datos.Rows(0)("nombre") & "','" & _
                               datos.Rows(0)("segundo_nombre") & "','" & _
                               datos.Rows(0)("Apellido") & "','" & _
                               datos.Rows(0)("segundo_apellido") & "','" & _
                               datos.Rows(0)("dpi") & "','" & _
                               datos.Rows(0)("cod_departamento") & "','" & _
                               datos.Rows(0)("cod_municipio") & "','" & _
                               datos.Rows(0)("telefono") & "','" & _
                               datos.Rows(0)("direccion") & "','" & _
                               datos.Rows(0)("sexo") & "','" & _
                               datos.Rows(0)("estado_civil") & "','" & _
                               datos.Rows(0)("nit") & "','" & _
                               datos.Rows(0)("cod_pais") & "','" & _
                               datos.Rows(0)("fec_alta") & _
                               "','3000-12-31','" & _
                               datos.Rows(0)("Fec_nacimiento") & "','" & _
                               datos.Rows(0)("frecuencia_pago") & "','" & _
                               datos.Rows(0)("codigo_puesto") & "','" & _
                               datos.Rows(0)("afiliacion_igss") & "','" & _
                               datos.Rows(0)("num_cuenta") & "','" & _
                               "A" & "','" & _
                               datos.Rows(0)("tipo_empleado") & "','" & _
                               datos.Rows(0)("apellido_casada") & "','" & _
                               datos.Rows(0)("num_hijos") & "','" & _
                               datos.Rows(0)("nombre_esposo") & "','" & _
                               datos.Rows(0)("tipo_pago") & "','" & _
                               datos.Rows(0)("id_foto") & "','" & _
                               datos.Rows(0)("sueldo_base") & "','" & _
                               datos.Rows(0)("bonific") & "','" & _
                               datos.Rows(0)("codigo_reloj") & "','" & _
                               datos.Rows(0)("marca") & "','" & _
                               datos.Rows(0)("turno") & "','" & _
                               datos.Rows(0)("af_irtra") & "','" & _
                               datos.Rows(0)("horas_extras") & "','" & _
                               datos.Rows(0)("emp_paga") & "','" & _
                               datos.Rows(0)("locker") & "','" & _
                               datos.Rows(0)("centro_costo") & "')"
                SqlInsert.ExecuteNonQuery()
                resultado = True
            Catch ex As Exception
                mensaje = ex.Message
                resultado = False
            End Try
        End If
        CerrarConexion()
        Return resultado
    End Function

    Public Function BuscaNombre(ByRef buscacodigo As DataTable, ByRef codigo As String, ByRef empresa As String, ByRef Algunmensaje As String)
        buscacodigo.Clear()
        Dim resultado As Boolean
        If AbrirConexion(Algunmensaje) = True Then
            Sqlselect.CommandText = "select codigo,TB_EMPLEADO.nombre,segundo_nombre,apellido,segundo_apellido, b.NOMBRE as nombre_puesto from TB_EMPLEADO " & _
                "left join TB_DEPTOS_EMPRESA as b on TB_EMPLEADo.COD_DEPART = b.COD_DEPAR where codigo = " & codigo
            Adaptador.Fill(buscacodigo)
            If buscacodigo.Rows.Count > 0 Then
                resultado = True
            Else
                Algunmensaje = "Empleado no Existe"
                resultado = False
            End If
        End If
        CerrarConexion()
        Return resultado
    End Function

    Public Function guardarfoto(ByVal codigo As String, ByVal empresa As String, ByVal foto As IO.MemoryStream, ByRef Mensaje As String) As Boolean
        Dim Res As Boolean
        If (AbrirConexion(Mensaje)) Then
            Try
                SqlSelect.CommandText = "Select count(1) from tb_foto where id_foto = " & codigo & "and codigo_empresa =" & empresa
                If SqlSelect.ExecuteScalar > 0 Then
                    SqlUpdate.CommandText = "update Tb_foto set foto = @foto where id_foto=" & codigo & "and codigo_empresa= " & empresa
                    SqlUpdate.Parameters.Add("@foto", SqlDbType.Image)
                    SqlUpdate.Parameters(0).Value = foto.ToArray
                    SqlUpdate.ExecuteNonQuery()
                    SqlUpdate.Parameters.Clear()
                    Res = True
                Else
                    SqlInsert.CommandText = "Insert into Tb_foto (id_foto,codigo_empleado,codigo_empresa,foto)values (" & codigo & "," & codigo & "," & empresa & ", @foto)"
                    SqlInsert.Parameters.Add("@foto", SqlDbType.Image)
                    SqlInsert.Parameters(0).Value = foto.ToArray
                    SqlInsert.ExecuteNonQuery()
                    SqlInsert.Parameters.Clear()
                    Res = True
                    'Mensaje = "Fotografia Guardada"
                End If
            Catch ex As Exception
                Res = False
                Mensaje = ex.Message
            End Try
        End If
        CerrarConexion()
        Return Res
    End Function

    Public Function obtienefoto(ByVal codigo As String, ByVal empresa As String, ByRef stmBLOBData As IO.MemoryStream, ByRef Mensaje As String) As Boolean
        Dim Res As Boolean
        Dim byImagen() As Byte = Nothing
        Dim dtfoto As New DataTable
        If (AbrirConexion(Mensaje)) Then
            Try
                SqlSelect.CommandText = "select foto from tb_foto where codigo_empresa = " & empresa & " and id_foto = " & codigo
                dtfoto = New DataTable
                Adaptador.Fill(dtfoto)
                If dtfoto.Rows.Count < 1 Then
                    Mensaje = "No se tiene foto de este empleado"
                    Res = False
                ElseIf dtfoto.Rows(0)("Foto") IsNot DBNull.Value Then
                    Dim bytBLOBData() As Byte = dtfoto.Rows(0)("Foto")
                    stmBLOBData = New IO.MemoryStream(bytBLOBData)
                    Res = True
                End If
            Catch expSQL As SqlException
                ' MsgBox(expSQL.ToString, MsgBoxStyle.OkOnly, "SQL Exception")
            End Try
        End If
        CerrarConexion()
        Return Res
    End Function

    Public Function updatedatos(ByVal datosrec As DataTable, ByVal codigo As String, ByVal empresa As String, ByRef mensaje As String)
        Dim resultado As Boolean
        If AbrirConexion(mensaje) = True Then
            Try
                SqlUpdate.CommandText = "update tb_empleado set nombre = '" & datosrec.Rows(0)("nombre") & _
                    "', segundo_nombre = '" & datosrec.Rows(0)("segundo_nombre") & _
                    "', apellido = '" & datosrec.Rows(0)("apellido") & _
                    "', segundo_Apellido = '" & datosrec.Rows(0)("segundo_apellido") & _
                    "', dpi = '" & datosrec.Rows(0)("dpi") & _
                    "', telefono = '" & datosrec.Rows(0)("telefono") & _
                    "', direccion = '" & datosrec.Rows(0)("direccion") & _
                    "', estado_civil = '" & datosrec.Rows(0)("estado_civil") & _
                    "', frecuencia_pago = '" & datosrec.Rows(0)("frecuencia_pago") & _
                    "', afiliacion_igss = '" & datosrec.Rows(0)("afiliacion_igss") & _
                    "', num_cuenta = '" & datosrec.Rows(0)("num_cuenta") & _
                    "', apellido_casada = '" & datosrec.Rows(0)("apellido_casada") & _
                    "', nombre_esposo = '" & datosrec.Rows(0)("Nombre_esposo") & _
                    "', num_hijos = '" & datosrec.Rows(0)("num_hijos") & _
                    "', tipo_pago = '" & datosrec.Rows(0)("tipo_pago") & _
                    "', sueldo_base = '" & datosrec.Rows(0)("sueldo_base") & _
                    "', bonificacion = '" & datosrec.Rows(0)("bonificacion") & _
                    "', codigo_reloj = '" & datosrec.Rows(0)("codigo_reloj") & _
                    "', codigo_puesto = '" & datosrec.Rows(0)("codigo_puesto") & _
                    "', cod_depart = '" & datosrec.Rows(0)("cod_depart") & _
                    "', nit = '" & datosrec.Rows(0)("nit") & _
                    "', tipo_empleado = '" & datosrec.Rows(0)("tipo_empleado") & _
                    "', marca = '" & datosrec.Rows(0)("marca") & _
                    "', turno = '" & datosrec.Rows(0)("turno") & _
                    "', af_irtra = '" & datosrec.Rows(0)("af_irtra") & _
                    "', sexo = '" & datosrec.Rows(0)("sexo") & _
                    "', horas_ex = '" & datosrec.Rows(0)("horas_extras") & _
                    "', emp_paga = '" & datosrec.Rows(0)("emp_paga") & _
                    "', locker = '" & datosrec.Rows(0)("locker") & _
                    "', fec_alta = '" & datosrec.Rows(0)("fec_alta") & _
                    "', fec_nacimiento = '" & datosrec.Rows(0)("fec_nacimiento") & _
                    "', centro_costo = '" & datosrec.Rows(0)("centro_costo") & _
                    "', estado_empleado = '" & datosrec.Rows(0)("estado_empleado") & _
                    "', centro = '" & datosrec.Rows(0)("centro") & _
                    "' where codigo = '" & codigo & _
                    "' and codigo_empresa ='" & empresa & "'"
                SqlUpdate.ExecuteNonQuery()
                resultado = True
            Catch ex As Exception
                mensaje = ex.Message
                resultado = False
            End Try
        End If
        CerrarConexion()
        Return resultado
    End Function

    Public Function fnccontrato(ByRef datos As DataTable, ByRef años As DataTable, ByVal codigo As String, ByRef num_empleados As String, ByRef edad_patrono As String, ByVal empresa As String, ByRef mensaje As String) As Boolean
        Dim Contrato As Boolean
        Dim empleados As New DataTable
        Dim edadpatrono As New DataTable
        If AbrirConexion((mensaje)) Then
            SqlSelect.CommandText = "select tb_empleado.nombre,tb_empleado.segundo_nombre,tb_empleado.apellido,tb_empleado.segundo_apellido, tb_pais.nombre_pais, tb_pais.gentilicio,tb_empleado.sexo,tb_empleado.estado_civil,tb_empleado.direccion,tb_empleado.dpi,tb_empleado.fec_alta,tb_empleado.Sueldo_base, tb_departamento.nombre AS nombre_departamento, tb_municipio.nombre_municipio,tb_empresa.Nombre_empresa,GETDATE() as fecha from tb_empleado, tb_pais, tb_departamento, tb_municipio,tb_empresa where tb_pais.codigo_pais = (select cod_pais from tb_empleado where codigo=" & codigo & " and Codigo_empresa=" & empresa & ") and tb_municipio.codigo= (select cod_municipio from tb_empleado where codigo=" & codigo & " and Codigo_empresa=" & empresa & ") " & _
                                    " and TB_MUNICIPIO.cod_departamento = (select cod_departamento from tb_empleado where  codigo=" & codigo & " and Codigo_empresa=" & empresa & ")" & _
                                    " and tb_departamento.codigo_departamento= (select cod_departamento from tb_empleado where  codigo=" & codigo & " and Codigo_empresa=" & empresa & ") and tb_empresa.Codigo= (select codigo_empresa from tb_empleado where codigo= " & codigo & " and Codigo_empresa=" & empresa & " ) and tb_empleado.codigo= " & codigo & " and tb_empleado.Codigo_empresa= " & empresa
            Adaptador.Fill(datos)
            If datos.Rows.Count > 0 Then
                SqlSelect.CommandText = "SELECT DATEDIFF(YEAR, fec_nacimiento, DATEADD(day,1,SYSDATETIME())) AS años FROM tb_empleado where Codigo_empresa = " & empresa & " and codigo = " & codigo & ""
                Adaptador.Fill(años)
                SqlSelect.CommandText = "select COUNT(1) as empleados from tb_empleado where estado_empleado = 'A'"
                Adaptador.Fill(empleados)
                num_empleados = empleados.Rows(0)("empleados")
                SqlSelect.CommandText = "SELECT DATEDIFF(year, '1957-05-02', DATEADD(day,1,SYSDATETIME())) AS años"
                Adaptador.Fill(edadpatrono)
                edad_patrono = edadpatrono.Rows(0)("años")
                Contrato = True
            Else
                Contrato = False
                mensaje = " no existe"
            End If
        End If
        CerrarConexion()
        Return Contrato

    End Function

    Public Function csescalar(ByRef nombre As String, ByRef script As String, ByRef msj As String)
        Dim result As Boolean
        If AbrirConexion(msj) = True Then
            Try
                Sqlselect.CommandText = script
                nombre = Sqlselect.ExecuteScalar
                result = True
            Catch ex As Exception
                msj = ex.Message
                result = False
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Public Sub AutoCompletar(ByRef cb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            Dim strFindStr As String
            Dim i As Integer = cb.SelectedIndex
            If e.KeyChar = Chr(8) Then  'Backspace
                If cb.SelectionStart <= 1 Then
                    cb.SelectionStart = 1
                    ' Exit Sub
                End If
                If cb.SelectionLength = 0 Then
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1)
                Else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1)
                End If
            Else
                If cb.SelectionLength = 0 Then
                    strFindStr = cb.Text & e.KeyChar
                Else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) & e.KeyChar
                End If
            End If
            Dim intIdx As Integer = -1
            ' Search the string in the Combo Box List.
            intIdx = cb.FindString(strFindStr)

            If intIdx <> -1 Then ' String found in the List.
                cb.SelectedText = ""
                cb.SelectedIndex = intIdx
                cb.SelectionStart = strFindStr.Length
                cb.SelectionLength = cb.Text.Length
                e.Handled = True
            Else
                e.Handled = True
            End If
        Catch
        End Try
    End Sub

    Public Function actualiza_turno(ByRef datos As DataTable, ByRef mensaje As String) As Boolean
        Dim result As Boolean = False
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlUpdate.Transaction = Transaccion
            Try
                For i = 0 To datos.Rows.Count - 1
                    SqlUpdate.CommandText = "UPDATE TB_TURNO_SER SET TURNO = '" & datos.Rows(i)("TURNO") & "' WHERE CODIGO = " & datos.Rows(i)("CODIGO") & "AND FECHA = '" & datos.Rows(i)("FECHA") & "'"
                    SqlUpdate.ExecuteNonQuery()
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                mensaje = ex.Message
                result = False
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Function ingresa_turno(dtf As DataTable, msj As String) As Boolean
        Dim result As Boolean = False
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            Try
                For i = 0 To dtf.Rows.Count - 1
                    Try
                        SqlInsert.CommandText = "INSERT INTO TB_TURNO_SER (CODIGO,FECHA,TURNO)VALUES ('" & dtf.Rows(i)("CODIGO") & "', '" & dtf.Rows(i)("FECHA") & "', '" & dtf.Rows(i)("TURNO") & "')"
                        SqlInsert.ExecuteNonQuery()
                    Catch
                    End Try
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Function guarda_horas(ByVal dthoras As DataTable, ByVal fecha_inic As Date, ByVal fecha_fin As Date, ByRef msj As String) As Boolean
        Dim result As Boolean = False
        'Dim afecta As Integer
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlDelete.Transaction = Transaccion
            Try
                SqlDelete.CommandText = "DELETE FROM TB_HORAS_EXTRAS  WHERE FECHA BETWEEN '" & fecha_inic & "' and '" & fecha_fin.AddDays(1) & "'"
                Dim ejecut As Boolean = SqlDelete.ExecuteNonQuery
                For i = 0 To dthoras.Rows.Count - 1
                    SqlInsert.CommandText = "INSERT INTO TB_HORAS_EXTRAS (COD_EMPLEADO,COD_EMPRESA,FECHA,HORAS)VALUES ('" &
                        dthoras.Rows(i)("CODIGO_EMPLEADO") & "', '" &
                        dthoras.Rows(i)("CODIGO_EMPRESA") & "','" &
                        dthoras.Rows(i)("FECHA") & "','" &
                        dthoras.Rows(i)("HORAS") & "')"
                    SqlInsert.ExecuteNonQuery()
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Function guarda_marcas(ByVal dtmarcas As DataTable, ByRef msj As String) As Boolean
        Dim result As Boolean = False
        Dim afecta As Integer
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Try
                For i = 0 To dtmarcas.Rows.Count - 1
                    SqlUpdate.CommandText = "UPDATE TB_MARCA_FINAL SET ENTRADA = '" & dtmarcas.Rows(i)("ENTRADA") & _
                                            "', SALIDA = '" & dtmarcas.Rows(i)("SALIDA") &
                                            "' WHERE CODIGO = '" & dtmarcas.Rows(i)("CODIGO") &
                                            "' AND EMPRESA = '" & dtmarcas.Rows(i)("EMPRESA") & "' " & _
                                            " AND FECHA = '" & dtmarcas.Rows(i)("FECHA") & "'"
                    afecta = SqlUpdate.ExecuteNonQuery
                    If afecta < 1 Then
                        SqlInsert.CommandText = "INSERT INTO TB_MARCA_FINAL (CODIGO,EMPRESA,FECHA,ENTRADA,SALIDA)VALUES ('" & dtmarcas.Rows(i)("CODIGO") & "', '" & dtmarcas.Rows(i)("EMPRESA") & "','" & dtmarcas.Rows(i)("FECHA") & "','" & dtmarcas.Rows(i)("ENTRADA") & "','" & dtmarcas.Rows(i)("SALIDA") & "')"
                        SqlInsert.ExecuteNonQuery()
                    End If
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Public Function gurda_permiso(ByVal dtfinal As DataTable, ByRef msj As String) As Boolean
        Dim result As Boolean = False
        Dim afecta As Integer
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Try
                For i = 0 To dtfinal.Rows.Count - 1
                    SqlUpdate.CommandText = "UPDATE TB_PERMISO SET FECHA = '" & dtfinal.Rows(i)("FECHA") & _
                                            "' WHERE CODIGO = '" & dtfinal.Rows(i)("CODIGO") &
                                            "' AND COD_EMPRESA = '" & dtfinal.Rows(i)("EMPRESA") & "' " & _
                                            " AND FECHA = '" & dtfinal.Rows(i)("FECHA") & "'"
                    afecta = SqlUpdate.ExecuteNonQuery
                    If afecta < 1 Then
                        SqlInsert.CommandText = "INSERT INTO TB_PERMISO (CODIGO,COD_EMPRESA,FECHA,COD_PERMISO,COMENTARIOS)VALUES ('" &
                                                dtfinal.Rows(i)("CODIGO") & "', '" &
                                                dtfinal.Rows(i)("EMPRESA") & "','" &
                                                dtfinal.Rows(i)("FECHA") & "','" &
                                                dtfinal.Rows(i)("COD_PERMISO") & "','" &
                                                dtfinal.Rows(i)("COMENT") & "')"
                        SqlInsert.ExecuteNonQuery()
                    End If
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Public Function gurda_faltas(ByVal fec_inic As String, ByVal fec_fin As String, ByVal dtfinal As DataTable, ByRef msj As String) As Boolean
        Dim result As Boolean = False
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Try

                SqlUpdate.CommandText = "delete from tb_falta where fecha between '" & fec_inic & "' and '" & fec_fin & "' and codigo = " & dtfinal.Rows(0)("CODIGO")
                SqlUpdate.ExecuteNonQuery()

                For i = 0 To dtfinal.Rows.Count - 1
                    SqlInsert.CommandText = "INSERT INTO TB_FALTA (CODIGO,COD_EMPRESA,FECHA,COMENT)VALUES ('" &
                                                dtfinal.Rows(i)("CODIGO") & "', '" &
                                                dtfinal.Rows(i)("EMPRESA") & "','" &
                                                dtfinal.Rows(i)("FECHA") & "','" &
                                                dtfinal.Rows(i)("COMENT") & "')"
                    SqlInsert.ExecuteNonQuery()
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Public Function gurda_faltas_marca(ByVal fec_inic As String, ByVal fec_fin As String, ByVal dtfinal As DataTable, ByRef msj As String, ByRef dt_borra As DataTable) As Boolean
        Dim result As Boolean = False
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlDelete.Transaction = Transaccion
            Try
                SqlDelete.CommandText = "delete from tb_faltas_marca where fecha between '" & fec_inic & "' and '" & fec_fin & "' and codigo = " & dtfinal.Rows(0)("CODIGO")
                SqlDelete.ExecuteNonQuery()
                For i = 0 To dtfinal.Rows.Count - 1
                    SqlInsert.CommandText = "INSERT INTO TB_FALTAS_MARCA (CODIGO,COD_EMPRESA,FECHA,COMENT)VALUES ('" &
                                                dtfinal.Rows(i)("CODIGO") & "', '" &
                                                dtfinal.Rows(i)("EMPRESA") & "','" &
                                                dtfinal.Rows(i)("FECHA") & "','" &
                                                dtfinal.Rows(i)("COMENT") & "')"
                    SqlInsert.ExecuteNonQuery()
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Public Function gurda_vacas(ByVal dtfinal As DataTable, ByRef msj As String, ByRef dt_borra As DataTable) As Boolean
        Dim result As Boolean = False
        Dim cuenta As Integer
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Sqlselect.Transaction = Transaccion
            SqlDelete.Transaction = Transaccion
            Try
                For i = 0 To dt_borra.Rows.Count - 1
                    SqlDelete.CommandText = "DELETE FROM TB_VACAC" &
                                            " WHERE CODIGO = '" & dt_borra.Rows(i)("CODIGO") &
                                            "' AND COD_EMPRESA = '" & dt_borra.Rows(i)("COD_EMPRESA") &
                                            "' AND CICLO = '" & dt_borra.Rows(i)("CICLO") & "'" &
                                            " AND FECHA = '" & dt_borra.Rows(i)("FECHA") & "'"
                    SqlDelete.ExecuteNonQuery()
                Next
                For i = 0 To dtfinal.Rows.Count - 1
                    Sqlselect.CommandText = "select count(1) from tb_vacac where codigo = " & dtfinal.Rows(0)("CODIGO") & " and ciclo = '" & dtfinal.Rows(0)("ciclo") & "'"
                    cuenta = Sqlselect.ExecuteScalar
                    If cuenta < 15 Then
                        SqlInsert.CommandText = "INSERT INTO TB_VACAC (CODIGO,COD_EMPRESA,FECHA,CICLO)VALUES ('" & dtfinal.Rows(i)("CODIGO") & "', '" & dtfinal.Rows(i)("EMPRESA") & "','" & dtfinal.Rows(i)("FECHA") & "','" & dtfinal.Rows(i)("CICLO") & "')"
                        SqlInsert.ExecuteNonQuery()
                    End If
                    If cuenta < 15 Then
                        result = True
                    Else
                        result = False
                        msj = "¡Ya existen 15 dias para este ciclo.!"
                    End If
                Next
                Transaccion.Commit()
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Function suspensiones(ByVal codigo As Integer, ByVal empresa As Integer, ByVal fec_inic As Date, ByVal fec_fin As Date, ByRef msj As String, ByVal com As String) As Boolean
        Dim result As Boolean = False
        Dim permisos As Integer
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Sqlselect.Transaction = Transaccion

            Try
                Sqlselect.CommandText = "select  COUNT(1) from TB_SUSPENSION where FEC_INIC BETWEEN '" & Format(fec_inic, "yyyy-MM-dd") & "' AND ' " & Format(fec_fin, "yyyy-MM-dd") & "' AND CODIGO = " & codigo & "AND COD_EMPRESA = " & empresa
                permisos = Sqlselect.ExecuteScalar
                If permisos < 1 Then
                    SqlInsert.CommandText = "INSERT INTO TB_SUSPENSION(CODIGO,COD_EMPRESA,FEC_INIC,FEC_FIN,COMENTARIOS) VALUES ('" & codigo & "','" & empresa & "','" & Format(fec_inic, "yyyy-MM-dd") & "','" & Format(fec_fin, "yyyy-MM-dd") & "','" & com & "')"
                    SqlInsert.ExecuteNonQuery()

                    SqlUpdate.CommandText = " UPDATE TB_EMPLEADO SET ESTADO_EMPLEADO = 'S' WHERE CODIGO = " & codigo & " AND CODIGO_EMPRESA =  " & empresa
                    SqlUpdate.ExecuteNonQuery()
                    'result = True
                Else
                    msj = "YA EXISTE UNA SUSPENSION ENTRE ESTAS FECHAS !!"
                End If
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()

            End Try
        End If
        CerrarConexion()
            Return result
    End Function

    Function descuento(ByVal codigo As Integer, ByVal empresa As Integer, ByVal fecha As Date, ByVal monto As Double, ByVal cod_desc As String, ByVal com As String) As Boolean
        Dim result As Boolean = False

        If AbrirConexion(msj) Then
            Try
                SqlInsert.CommandText = "INSERT INTO TB_DESCUENTO(CODIGO,COD_EMPRESA,FECHA,MONTO,COD_DESC,COMENT) VALUES ('" & codigo & "','" & empresa & "','" & Format(fecha, "yyyy-MM-dd") & "','" & monto & "','" & cod_desc & "','" & com & " ')"
                SqlInsert.ExecuteNonQuery()
                result = True
            Catch ex As Exception
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Function Ajustes(ByVal codigo As Integer, ByVal empresa As Integer, ByVal fecha As Date, ByVal monto As Double, ByVal com As String) As Boolean
        Dim result As Boolean = False

        If AbrirConexion(msj) Then
            Try
                SqlInsert.CommandText = "INSERT INTO TB_AJUSTES(CODIGO,COD_EMPRESA,FECHA,MONTO,COMENT) VALUES ('" & codigo & "','" & empresa & "','" & Format(fecha, "yyyy-MM-dd") & "','" & monto & "','" & com & " ')"
                SqlInsert.ExecuteNonQuery()
                result = True
            Catch ex As Exception
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Function procedure(scr As String, ByRef msj As String) As Boolean
        Dim resul As Boolean = False
        Try
            If AbrirConexion(msj) Then
                Sqlselect.CommandText = scr
                Sqlselect.ExecuteScalar()
                resul = True
            End If
        Catch ex As Exception
            msj = ex.Message
        End Try
        CerrarConexion()
        Return resul
    End Function

    Function horas_nom(ByVal dt As DataTable, msj As String) As Boolean
        Dim b As Boolean = False
        If AbrirConexion(msj) Then
            Dim transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlUpdate.Transaction = transaccion
            Try
                For I = 0 To dt.Rows.Count - 1
                    SqlUpdate.CommandText = "UPDATE TB_PRE_NOMINA SET  ORDINARIO = '" & dt.Rows(I)("DIAS") & _
                                                 "', DIAS_T = '" & dt.Rows(I)("DIAS_T") & _
                                                 "' WHERE CODIGO = " & dt.Rows(I)("CODIGO") & _
                                                 " AND COD_EMPRESA = " & dt.Rows(I)("EMPRESA") & _
                                                 " AND ANIO = " & dt.Rows(I)("ANIO") & _
                                                 " AND MES = " & dt.Rows(I)("MES") & _
                                                 " AND QUINCENA = " & dt.Rows(I)("CICLO")
                    SqlUpdate.ExecuteNonQuery()
                Next
                transaccion.Commit()
            Catch e As Exception
                b = False
                msj = e.Message
            End Try
        End If
        CerrarConexion()
        Return b
    End Function

    Function actualiza_marcas(ByVal dt As DataTable, msj As String) As Boolean
        Dim b As Boolean = False
        If AbrirConexion(msj) Then
            Dim transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlUpdate.Transaction = transaccion
            Try
                For I = 0 To dt.Rows.Count - 1
                    SqlUpdate.CommandText = "UPDATE TB_MARCA SET  HORA = '" & dt.Rows(I)("HORA_N") & _
                                                 "' WHERE FECHA = '" & dt.Rows(I)("FECHA") & _
                                                 "' AND CODIGO = " & dt.Rows(I)("CODIGO") & _
                                                 " AND HORA = '" & dt.Rows(I)("HORA") & "'"
                    SqlUpdate.ExecuteNonQuery()
                Next
                transaccion.Commit()
                b = True
            Catch e As Exception
                b = False
                msj = e.Message
            End Try
        End If
        CerrarConexion()
        Return b
    End Function




    Public Function anticipo(ByVal Dt As DataTable, ByVal dtt As DataTable, ByRef Mensaje As String) As Boolean
        Dim Resultado As Boolean

        If AbrirConexion(Mensaje) Then
            Dim cont As Integer = Dt.Rows.Count
            Dim I As Integer
            Dim afectados As Integer
            Dim StrQuery As String
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Try
                StrQuery = "insert into tb_anticipo(COD_EMPLEADO,COD_EMPRESA,NUM_CUOTAS,FEC_ANTICIPO,NUM_DOCUMENTO,TOTAL_ANTICIPO,DESCRIPCION) values  (" & _
                     Dt.Rows(0)("codigo") + "," + Dt.Rows(0)("empresa") + "," + Dt.Rows(0)("cuotas") + ",'" + Dt.Rows(0)("fecha") + "','" + Dt.Rows(0)("docu") + "'," + Dt.Rows(0)("monto") + ",'" + Dt.Rows(0)("coment") + "')" & _
                     " SELECT @@IDENTITY AS 'Identity' "
                SqlInsert.CommandText = StrQuery
                afectados = SqlInsert.ExecuteScalar()
                If afectados > 0 Then
                    For I = 0 To dtt.Rows.Count - 1
                        StrQuery = "insert into tb_det_anticipo (num_anticipo,numero_cuota,monto_cuota,anio,mes,quincena,estado) values (" & _
                            afectados & " ," & _
                             dtt.Rows(I)("num_cuota") & "," & _
                             dtt.Rows(I)("monto") + ",'" & _
                             dtt.Rows(I)("anio") & "','" & _
                             dtt.Rows(I)("mes") & "','" & _
                             dtt.Rows(I)("quincena") & "','" & _
                             dtt.Rows(I)("estado") & "')"
                        SqlInsert.CommandText = StrQuery
                        SqlInsert.ExecuteNonQuery()
                    Next
                End If
                Transaccion.Commit()
                Resultado = True
            Catch ex As Exception
                Transaccion.Rollback()
                Resultado = False
                Mensaje = ("se encontro con eror de " + ex.Message)
            End Try
        End If
        CerrarConexion()
        Return Resultado
    End Function


    Public Function guarda_bonif(ByVal dt As DataTable, ByRef msj As String) As Boolean
        Dim result As Boolean = False
        Dim afecta As Integer
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Try
                For i = 0 To dt.Rows.Count - 1
                    SqlUpdate.CommandText = "UPDATE TB_BONIFICACION SET MONTO = '" & dt.Rows(i)("MONTO") & _
                                            "' WHERE CODIGO = '" & dt.Rows(i)("CODIGO") &
                                            "' AND COD_EMPRESA = '" & dt.Rows(i)("EMPRESA") & "' " & _
                                            " AND ANIO = '" & dt.Rows(i)("ANIO") & "'" & _
                                            " AND MES = '" & dt.Rows(i)("MES") & "'" & _
                                            " AND QUINCENA = '" & dt.Rows(i)("CICLO") & "'"
                    afecta = SqlUpdate.ExecuteNonQuery
                    If afecta < 1 Then
                        SqlInsert.CommandText = "INSERT INTO TB_BONIFICACION(CODIGO,COD_EMPRESA,ANIO,MES,QUINCENA,MONTO)VALUES ('" &
                                                dt.Rows(i)("CODIGO") & "', '" &
                                                dt.Rows(i)("EMPRESA") & "','" &
                                                dt.Rows(i)("ANIO") & "','" &
                                                dt.Rows(i)("MES") & "','" &
                                                dt.Rows(i)("CICLO") & "','" &
                                                dt.Rows(i)("MONTO") & "')"
                        SqlInsert.ExecuteNonQuery()
                    End If
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function




    Public Function guarda_isr(ByVal dt As DataTable, ByRef msj As String) As Boolean
        Dim result As Boolean = False

        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Try
                For i = 0 To dt.Rows.Count - 1
                    SqlInsert.CommandText = "INSERT INTO TB_ISR(CODIGO,EMPRESA,ANIO,MES,QUINCENA,MONTO)VALUES ('" &
                                            dt.Rows(i)("CODIGO") & "', '" &
                                            dt.Rows(i)("EMPRESA") & "','" &
                                            dt.Rows(i)("ANIO") & "','" &
                                            dt.Rows(i)("MES") & "','" &
                                            dt.Rows(i)("CICLO") & "','" &
                                            dt.Rows(i)("MONTO") & "')"
                    SqlInsert.ExecuteNonQuery()
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Public Function actualiza_isr(ByVal dt As DataTable, ByRef msj As String) As Boolean
        Dim result As Boolean = False
        Dim afecta As Integer
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion

            Try
                For i = 0 To dt.Rows.Count - 1
                    SqlUpdate.CommandText = "UPDATE TB_ISR SET MONTO = '" & dt.Rows(i)("MONTO") & _
                                           "' WHERE CODIGO = " & dt.Rows(i)("CODIGO") &
                                           " AND ANIO = '" & dt.Rows(i)("ANIO") & "'" & _
                                           " AND MES = '" & dt.Rows(i)("MES") & "'" & _
                                           " AND QUINCENA = '" & dt.Rows(i)("quincena") & "'"
                    afecta = SqlUpdate.ExecuteNonQuery()
                    If afecta < 1 Then
                        SqlInsert.CommandText = "INSERT INTO TB_ISR(CODIGO,EMPRESA,ANIO,MES,QUINCENA,MONTO)VALUES ('" &
                                            dt.Rows(i)("CODIGO") & "', '" &
                                            dt.Rows(i)("EMPRESA") & "','" &
                                            dt.Rows(i)("ANIO") & "','" &
                                            dt.Rows(i)("MES") & "','" &
                                            dt.Rows(i)("quincena") & "','" &
                                            dt.Rows(i)("MONTO") & "')"
                        SqlInsert.ExecuteNonQuery()
                    End If
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Function guarda_asueto(ByVal dt As DataTable, ByRef msj As String) As Boolean
        Dim b As Boolean = False
        If AbrirConexion(msj) Then
            Dim transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = transaccion
            SqlDelete.Transaction = transaccion
            Try
                SqlDelete.CommandText = "DELETE FROM TB_ASUETO WHERE FECHA_ASUETO = '" & dt.Rows(0)("FECHA") & "'"
                SqlDelete.ExecuteNonQuery()
                For I = 0 To dt.Rows.Count - 1
                    SqlInsert.CommandText = "INSERT INTO TB_ASUETO (FECHA_ASUETO,COD_EMPLEADO,COD_EMPRESA) VALUES ('" & dt.Rows(I)("FECHA") & _
                                                     "', '" & dt.Rows(I)("CODIGO") & _
                                                     " ','" & dt.Rows(I)("EMPRESA") & "')"
                    SqlInsert.ExecuteNonQuery()
                Next
                b = True
                transaccion.Commit()
            Catch e As Exception
                msj = e.Message
            End Try
        End If
        CerrarConexion()
        Return b
    End Function

    Public Function ing_vacas(ByVal dt As DataTable, ByVal msj As String) As Boolean
        Dim resultado As Boolean
        Dim StrQuery As String
        Dim cant As Integer
        If AbrirConexion(msj) = True Then
            Dim transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlUpdate.Transaction = transaccion
            SqlInsert.Transaction = transaccion
            Try
                For I = 0 To dt.Rows.Count - 1
                    StrQuery = "update tb_vacaciones set  saldo = '" & dt.Rows(I)("saldo") & "', fecha_calc = '" & dt.Rows(I)("fec_calc") & "' where cod_empresa = " & dt.Rows(I)("empresa") & " and codigo=" & dt.Rows(I)("codigo") & "and ciclo = '" & dt.Rows(I)("ciclo") & "' and estado = 'N'"
                    SqlUpdate.CommandText = StrQuery
                    cant = SqlUpdate.ExecuteNonQuery()
                    If cant < 1 Then
                        StrQuery = "insert into tb_vacaciones(codigo,cod_empresa, fecha_inic,fecha_calc,saldo,ciclo,estado )" & _
                                    " values(" & dt.Rows(I)("codigo") & "," & dt.Rows(I)("empresa") & ",'" & dt.Rows(I)("fec_inic") & "','" & dt.Rows(I)("fec_calc") & "','" & dt.Rows(I)("saldo") & "','" & dt.Rows(I)("ciclo") & "','" & "N" & "')"
                        SqlInsert.CommandText = StrQuery
                        SqlInsert.ExecuteNonQuery()
                    End If
                Next
                transaccion.Commit()
                resultado = True
            Catch ex As Exception
                transaccion.Rollback()
                MsgBox(ex.Message)
                msj = ex.Message
                resultado = False
            End Try
        End If
        CerrarConexion()
        Return resultado
    End Function

    Function cierra_nomina(ByVal scr As String, ByVal scr2 As String, ByVal scr3 As String, ByVal scr4 As String, ByRef msj As String) As Boolean
        Dim resultado As Boolean = False
        If AbrirConexion(msj) = True Then
            Dim transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlUpdate.Transaction = transaccion
            Try
                SqlUpdate.CommandText = scr
                SqlUpdate.ExecuteNonQuery()
                '=================================
                SqlUpdate.CommandText = scr2
                SqlUpdate.ExecuteNonQuery()
                '================================
                SqlUpdate.CommandText = scr3
                SqlUpdate.ExecuteNonQuery()
                '=================================
                SqlUpdate.CommandText = scr4
                SqlUpdate.ExecuteNonQuery()
                transaccion.Commit()
                resultado = True
            Catch ex As Exception
            transaccion.Rollback()
            MsgBox(ex.Message)
            msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return resultado
    End Function

    Public Function delete(ByRef script As String, ByRef mensaje As String) As Boolean
        Dim respuesta As Boolean
        If AbrirConexion(mensaje) = True Then
            Try
                SqlDelete.CommandText = script
                SqlDelete.ExecuteNonQuery()
                respuesta = True
            Catch ex As Exception
                mensaje = ex.Message
            End Try

        Else
            respuesta = False
        End If
        CerrarConexion()
        Return respuesta
    End Function

    Public Function insert(ByVal script As String, ByRef msj As String) As Boolean
        Dim resultado As Boolean
        Dim cant As Integer
        If AbrirConexion(msj) = True Then
            Try
                SqlInsert.CommandText = script
                cant = SqlInsert.ExecuteNonQuery()
                resultado = True
            Catch ex As Exception
                msj = ex.Message
                resultado = False
            End Try
        End If
        CerrarConexion()
        Return resultado
    End Function

    Public Function bono14(ByVal dt As DataTable, ByRef msj As String) As Boolean
        Dim resultado As Boolean = False
        Dim StrQuery As String
        If AbrirConexion(msj) = True Then
            Dim transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlUpdate.Transaction = transaccion
            SqlInsert.Transaction = transaccion
            Try
                For I = 0 To dt.Rows.Count - 1
                    StrQuery = "insert into tb_bono14 values (" & dt.Rows(I)("codigo") & "," & dt.Rows(I)("cod_empresa") & "," & dt.Rows(I)("monto") & ",'" & dt.Rows(I)("ciclo") & "'," & dt.Rows(I)("dias_cal") & ",'" & dt.Rows(I)("fec_alta") & "')"
                    SqlInsert.CommandText = StrQuery
                    SqlInsert.ExecuteNonQuery()
                Next
                transaccion.Commit()
                resultado = True
            Catch ex As Exception
                transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return resultado
    End Function

    Public Function Aguinaldo(ByVal dt As DataTable, ByVal msj As String) As Boolean
        Dim resultado As Boolean = False
        Dim StrQuery As String
        If AbrirConexion(msj) = True Then
            Dim transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlUpdate.Transaction = transaccion
            SqlInsert.Transaction = transaccion
            Try
                For I = 0 To dt.Rows.Count - 1
                    StrQuery = "INSERT INTO TB_AGUINALDO VALUES (" & dt.Rows(I)("codigo") & "," & dt.Rows(I)("cod_empresa") & "," & dt.Rows(I)("monto") & ",'" & dt.Rows(I)("ciclo") & "'," & dt.Rows(I)("dias_cal") & ",'" & dt.Rows(I)("fec_alta") & "')"
                    SqlInsert.CommandText = StrQuery
                    SqlInsert.ExecuteNonQuery()
                Next
                transaccion.Commit()
                resultado = True
            Catch ex As Exception
                transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return resultado
    End Function



    Public Function baja(ByVal scr_insert As String, ByVal scr_vacas As String, ByVal scr_aguin As String, ByVal scr_bono As String, ByVal scr_anticpo As String, ByVal scr_indemni As String, ByVal scr_update As String, ByVal scr_mates As String, ByVal ind As String, ByRef msj As String) As Boolean
        Dim resulta As Boolean = False
        If AbrirConexion(msj) = True Then
            Dim transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlUpdate.Transaction = transaccion
            SqlInsert.Transaction = transaccion
            Try
                SqlInsert.CommandText = scr_insert
                SqlInsert.ExecuteNonQuery()
                '===============================
                SqlUpdate.CommandText = scr_vacas
                SqlUpdate.ExecuteNonQuery()
                '=================================
                SqlUpdate.CommandText = scr_aguin
                SqlUpdate.ExecuteNonQuery()
                '================================
                SqlUpdate.CommandText = scr_bono
                SqlUpdate.ExecuteNonQuery()
                '=================================
                SqlUpdate.CommandText = scr_anticpo
                SqlUpdate.ExecuteNonQuery()
                '==================================
                SqlUpdate.CommandText = scr_mates
                SqlUpdate.ExecuteNonQuery()
                '=================================
                If ind = "S" Then
                    SqlUpdate.CommandText = scr_indemni
                    SqlUpdate.ExecuteNonQuery()
                End If
                '=================================
                SqlUpdate.CommandText = scr_update
                SqlUpdate.ExecuteNonQuery()
                transaccion.Commit()
                resulta = True
            Catch ex As Exception
                transaccion.Rollback()
                MsgBox(ex.Message)
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return resulta
    End Function

    Public Function detdesc(ByVal empresa As String, ByVal codigo As String, ByRef dt As DataTable, ByRef mensaje As String)
        Dim res As Boolean
        If AbrirConexion(mensaje) = True Then
            Try
                Sqlselect.CommandText = "select b.nombre,b.segundo_nombre,b.apellido,TB_ANTICIPO.COD_EMPLEADO,tb_anticipo.num_anticipo,tb_anticipo.num_cuotas,tb_anticipo.fec_anticipo, tb_anticipo.num_documento,tb_anticipo.total_anticipo,tb_anticipo.descripcion," & _
                "(select SUM(monto_cuota)from tb_det_anticipo where estado = 'P' and tb_anticipo.num_anticipo=tb_det_anticipo.num_anticipo)as saldo" & _
                " from tb_anticipo " & _
                " left join tb_empleado as b on b.codigo=tb_anticipo.cod_empleado" & _
                " where tb_anticipo.cod_empleado like '%" + codigo + "%' and tb_anticipo.cod_empresa = " + empresa
                Adaptador.Fill(dt)
                res = True
            Catch ex As Exception
                mensaje = ex.Message
            End Try
        Else
            res = False
        End If
        CerrarConexion()
        Return res
    End Function

    Public Function baja_prueba(ByVal scr_insert As String, ByVal scr_vacas As String, ByVal scr_aguin As String, ByVal scr_bono As String, ByVal scr_anticpo As String, ByVal scr_indemni As String, ByVal scr_mat As String, ByVal ind As String, ByRef msj As String) As Boolean
        Dim resulta As Boolean = False
        If AbrirConexion(msj) = True Then
            Dim transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlUpdate.Transaction = transaccion
            SqlInsert.Transaction = transaccion
            Try
                SqlInsert.CommandText = scr_insert
                SqlInsert.ExecuteNonQuery()
                '===============================
                SqlUpdate.CommandText = scr_vacas
                SqlUpdate.ExecuteNonQuery()
                '=================================
                SqlUpdate.CommandText = scr_aguin
                SqlUpdate.ExecuteNonQuery()
                '================================
                SqlUpdate.CommandText = scr_bono
                SqlUpdate.ExecuteNonQuery()
                '=================================
                SqlUpdate.CommandText = scr_anticpo
                SqlUpdate.ExecuteNonQuery()
                '===========================================
                SqlUpdate.CommandText = scr_mat
                SqlUpdate.ExecuteNonQuery()
                '=================================
                If ind = "S" Then
                    SqlUpdate.CommandText = scr_indemni
                    SqlUpdate.ExecuteNonQuery()
                End If
                transaccion.Commit()
                resulta = True
            Catch ex As Exception
                transaccion.Rollback()
                MsgBox(ex.Message)
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return resulta
    End Function

    Public Function Cambio(ByVal Valor As Double)
        Dim numero(9), fraccion(2), entero, casillas, i, j As Integer
        Dim CienMillo, deci, decim, Millo, centanamil, Unidec, unidecmil, centena As String
        Dim completo As Double
        Dim ResultadoCambio As String
        entero = Int(Valor)
        completo = CDbl(Valor)
        deci = Format((completo - entero), "#.00")
        'El limite fue rebalsado solo se permiten valores menores a 999,999,999
        casillas = CStr(entero).Length
        j = 0
        For i = casillas - 1 To 0 Step -1
            j = j + 1
            numero(j) = CInt(CStr(entero).Substring(i, 1))
        Next i
        For i = (casillas + 1) To 9
            numero(i) = 0
        Next i
        For i = 1 To 2
            fraccion(i) = CInt(CStr(deci).Substring(i, 1))
        Next i
        Unidec = Conver((numero(1)), (numero(2)))
        centena = ConvCent((numero(3)))
        If centena = "Ciento " And Unidec = "" Then
            centena = "Cien "
        End If
        unidecmil = Conver((numero(4)), (numero(5)))
        If unidecmil <> "" Then
            If unidecmil = "Uno" Then
                unidecmil = "Un mil "
            Else
                If numero(4) = 1 Then
                    unidecmil = unidecmil.Substring(0, unidecmil.Length - 1) & " mil "
                Else
                    unidecmil = unidecmil & " mil "
                End If
            End If
        End If
        centanamil = ConvCent((numero(6)))
        If centanamil = "Ciento " And unidecmil = "" Then
            centanamil = "Cien mil "
        Else
            If centanamil <> "" And unidecmil = "" Then
                centanamil = centanamil & " mil "
            End If
        End If
        Millo = Conver((numero(7)), (numero(8)))
        If Millo <> "" Then
            If Millo = "Uno" Then
                Millo = "Un Millon "
            Else
                If numero(7) = 1 Then
                    Millo = Millo.Substring(0, Millo.Length - 1) & " Milloes "
                Else
                    Millo = Millo & " Millones "
                End If
            End If
        End If
        CienMillo = ConvCent((numero(9)))
        If CienMillo = "Ciento " And Millo = "" Then
            CienMillo = "Cien Millones "
        End If
        If deci <> "0" Then
            decim = Conver((fraccion(2)), (fraccion(1)))
            If decim <> "" Then
                decim = " Con " & decim
            End If
        Else
            decim = ""

        End If
        ResultadoCambio = CienMillo & Millo & centanamil & unidecmil & centena & Unidec & decim
        If ResultadoCambio = "" Then
            ResultadoCambio = "Cero"
        End If
        Return ResultadoCambio

    End Function

    Private Function Conver(ByVal ValorUno As Integer, ByVal ValorDos As Integer) As String
        Dim unidad, decena As String
        Dim grupo1 As Integer
        Dim ResConver As String
        grupo1 = CInt(ValorDos & ValorUno)
        Select Case grupo1
            Case 11
                ResConver = "Once "
            Case 12
                ResConver = "Doce"
            Case 13
                ResConver = "Trece"
            Case 14
                ResConver = "Catorce"
            Case 15
                ResConver = "Quince"
            Case Else
                Select Case ValorUno
                    Case 0
                        unidad = ""
                    Case 1
                        unidad = "Uno"
                    Case 2
                        unidad = "Dos"
                    Case 3
                        unidad = "Tres"
                    Case 4
                        unidad = "Cuatro"
                    Case 5
                        unidad = "Cinco"
                    Case 6
                        unidad = "Seis"
                    Case 7
                        unidad = "Siete"
                    Case 8
                        unidad = "Ocho"
                    Case 9
                        unidad = "Nueve"
                    Case Else
                        unidad = ""
                End Select
                Select Case ValorDos
                    Case 0
                        decena = ""
                    Case 1
                        decena = "Diez"
                    Case 2
                        If ValorUno <> 0 Then
                            decena = "Veinti"
                        Else
                            decena = "Veinte "
                        End If
                    Case 3
                        decena = "Treinta"
                    Case 4
                        decena = "Cuarenta"
                    Case 5
                        decena = "Cincuenta"
                    Case 6
                        decena = "Sesenta"
                    Case 7
                        decena = "Setenta"
                    Case 8
                        decena = "Ochenta"
                    Case 9
                        decena = "Noventa"
                    Case Else
                        decena = ""
                End Select
                If ValorUno = 0 Then
                    ResConver = decena & unidad
                Else
                    If ValorDos = 0 Then
                        ResConver = unidad
                    Else
                        If ValorDos = 2 Then
                            ResConver = decena & unidad
                        Else
                            ResConver = decena & " y " & unidad
                        End If
                    End If
                End If
        End Select
        Return ResConver
    End Function

    Private Function ConvCent(ByVal Valor As Integer) As String
        'Diseñado por Victor Hugo Cardenas
        Dim ResConvCent As String
        Select Case Valor
            Case 0
                ResConvCent = ""
            Case 1
                ResConvCent = "Ciento "
            Case 2
                ResConvCent = "Docientos "
            Case 3
                ResConvCent = "Trecientos "
            Case 4
                ResConvCent = "Cuatrocientos "
            Case 5
                ResConvCent = "Quinientos "
            Case 6
                ResConvCent = "Seis cientos "
            Case 7
                ResConvCent = "Setecientos "
            Case 8
                ResConvCent = "Ochocientos "
            Case 9
                ResConvCent = "Novecientos "
            Case Else
                ResConvCent = ""
        End Select
        Return ResConvCent
    End Function

    Public Function guarda_empresa(ByRef scr As String, ByVal MemoriaImg As IO.MemoryStream, ByVal nombre As String, ByRef msj As String) As Boolean
        Dim Res As Boolean = False
        If AbrirConexion(msj) Then
            Try
                Sqlselect.CommandText = "Select count(1) from tb_empresa where nombre_empresa = '" & nombre & "'"
                If Sqlselect.ExecuteScalar > 0 Then
                    SqlUpdate.CommandText = "update Tb_empresa set logo = @foto where nombre_empresa='" & nombre & "'"
                    SqlUpdate.Parameters.Add("@foto", SqlDbType.Image)
                    SqlUpdate.Parameters(0).Value = MemoriaImg.ToArray
                    SqlUpdate.ExecuteNonQuery()
                    SqlUpdate.Parameters.Clear()
                    Res = True
                Else
                    SqlInsert.CommandText = scr & "@foto)"
                    SqlInsert.Parameters.Add("@foto", SqlDbType.Image)
                    SqlInsert.Parameters(0).Value = MemoriaImg.ToArray
                    SqlInsert.ExecuteNonQuery()
                    SqlInsert.Parameters.Clear()
                    Res = True
                End If
            Catch ex As Exception
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return Res
    End Function

    Public Function parametros(ByVal dt As DataTable, ByVal dt_r As DataTable, ByVal msj As String) As Boolean
        Dim resultado As Boolean = False
        Dim StrQuery As String
        Dim l As Integer
        If AbrirConexion(msj) = True Then
            Dim transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlUpdate.Transaction = transaccion
            SqlInsert.Transaction = transaccion
            SqlDelete.Transaction = transaccion
            Try
                StrQuery = "UPDATE TB_PARAMETROS SET IGSS = '" & dt.Rows(0)("IGSS") & _
                 "', HORA_EXTRA = '" & dt.Rows(0)("HORA_EXTRA") & _
                 "', BONIFICACION = '" & dt.Rows(0)("BONIFICACION") & _
                 "', SALARIO_IND = '" & dt.Rows(0)("SALARIO_IND") & _
                 "', SALARIO_DIARIO = '" & dt.Rows(0)("SALARIO_DIARIO") & _
                 "', BON_PROD = '" & dt.Rows(0)("BON_PROD") & _
                 "', JORNADA = '" & dt.Rows(0)("JORNADA") & _
                 "', RELOJES = '" & dt.Rows(0)("RELOJES") & _
                 "', CIERRE = '" & dt.Rows(0)("CIERRE") & _
                 "', DIA_CIERRE = '" & dt.Rows(0)("DIA_CIERRE") & _
                 "', ENTRADA = '" & dt.Rows(0)("ENTRADA") & _
                 "', SALIDA = '" & dt.Rows(0)("SALIDA") & _
                 "', SABADO = '" & dt.Rows(0)("SABADO") & _
                 "', ENT_SABADO = '" & dt.Rows(0)("ENT_SABADO") & _
                 "', SAL_SABADO= '" & dt.Rows(0)("SAL_SABADO") & "' WHERE COD_EMPRESA =" & dt.Rows(0)("COD_EMPRESA")
                SqlUpdate.CommandText = StrQuery
                l = SqlUpdate.ExecuteNonQuery
                If l < 1 Then
                    StrQuery = "INSERT INTO TB_PARAMETROS (COD_EMPRESA,IGSS,HORA_EXTRA,BONIFICACION,SALARIO_IND,SALARIO_DIARIO," & _
                               "BON_PROD,JORNADA,RELOJES,CIERRE,DIA_CIERRE,ENTRADA,SALIDA,SABADO,ENT_SABADO,SAL_SABADO) VALUES ('" & _
                        dt.Rows(0)("COD_EMPRESA") & "','" & dt.Rows(0)("IGSS") & "','" & dt.Rows(0)("HORA_EXTRA") & _
                        "','" & dt.Rows(0)("BONIFICACION") & "','" & dt.Rows(0)("SALARIO_IND") & "','" & dt.Rows(0)("SALARIO_DIARIO") & _
                        "','" & dt.Rows(0)("BON_PROD") & "','" & dt.Rows(0)("JORNADA") & "','" & dt.Rows(0)("RELOJES") & _
                        "','" & dt.Rows(0)("CIERRE") & "','" & dt.Rows(0)("DIA_CIERRE") & "','" & dt.Rows(0)("ENTRADA") & _
                        "','" & dt.Rows(0)("SALIDA") & "','" & dt.Rows(0)("SABADO") & "','" & dt.Rows(0)("ENT_SABADO") & "','" & dt.Rows(0)("SAL_SABADO") & "')"
                    SqlInsert.CommandText = StrQuery
                    SqlInsert.ExecuteNonQuery()
                End If
                SqlDelete.CommandText = "DELETE FROM RELOJES"
                SqlDelete.ExecuteNonQuery()
                For i = 0 To CInt(dt.Rows(0)("RELOJES") - 1)
                    SqlInsert.CommandText = "INSERT INTO RELOJES (IP) VALUES ( '" & dt_r.Rows(i)("IP") & "')"
                    SqlInsert.ExecuteNonQuery()
                Next
                transaccion.Commit()
                resultado = True
            Catch ex As Exception
                transaccion.Rollback()
                MsgBox(ex.Message)
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return resultado
    End Function

    Public Function guarda_deptos(ByVal dt As DataTable, ByRef msj As String) As Boolean
        Dim result As Boolean = False
        Dim afecta As Integer
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Try
                For i = 0 To dt.Rows.Count - 1
                    SqlUpdate.CommandText = "UPDATE TB_DEPTOS_EMPRESA SET NOMBRE = '" & dt.Rows(i)("NOMBRE") & _
                                           "' WHERE COD_DEPAR = '" & dt.Rows(i)("CODIGO") & "'"
                    afecta = SqlUpdate.ExecuteNonQuery
                    If afecta < 1 Then
                        SqlInsert.CommandText = "INSERT INTO TB_DEPTOS_EMPRESA (COD_DEPAR,NOMBRE)VALUES ('" & dt.Rows(i)("CODIGO") & "', '" & dt.Rows(i)("NOMBRE") & "')"
                        SqlInsert.ExecuteNonQuery()
                    End If
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Public Function guarda_puestos(ByVal dt As DataTable, ByRef msj As String) As Boolean
        Dim result As Boolean = False
        Dim afecta As Integer
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Try
                For i = 0 To dt.Rows.Count - 1
                    SqlUpdate.CommandText = "UPDATE TB_PUESTOS SET NOMBRE_PUESTO = '" & dt.Rows(i)("NOMBRE_PUESTO") & "', DESCRIPCION = '" & dt.Rows(i)("DESCRIPCION") & _
                                           "' WHERE CODIGO= '" & dt.Rows(i)("CODIGO") & "'"
                    afecta = SqlUpdate.ExecuteNonQuery
                    If afecta < 1 Then
                        SqlInsert.CommandText = "INSERT INTO TB_PUESTOS (CODIGO,NOMBRE_PUESTO,DESCRIPCION)VALUES ('" & dt.Rows(i)("CODIGO") & "', '" & dt.Rows(i)("NOMBRE_PUESTO") & "','" & dt.Rows(i)("DESCRIPCION") & "' )"
                        SqlInsert.ExecuteNonQuery()
                    End If
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function


    Public Function usuario(ByVal dt As DataTable, ByVal MemoriaImg As IO.MemoryStream, ByRef msj As String) As Boolean
        Dim Res As Boolean = False
        Dim afecta As Integer
        If AbrirConexion(msj) Then
            Try
                'Sqlselect.CommandText = "Select count(1) from tb_usuario where usuario = '" & dt.Rows(0)("usuario") & "'"
                'If Sqlselect.ExecuteScalar > 0 Then
                SqlUpdate.CommandText = "update Tb_usuario set foto = @foto where usuario='" & dt.Rows(0)("usuario") & "'"
                SqlUpdate.Parameters.Add("@foto", SqlDbType.Image)
                SqlUpdate.Parameters(0).Value = MemoriaImg.ToArray
                afecta = SqlUpdate.ExecuteNonQuery()
                SqlUpdate.Parameters.Clear()
                Res = True
                If afecta < 1 Then
                    SqlInsert.CommandText = "insert into tb_usuario (CODIGO,USUARIO,NOMBRE_USUARIO,PASSWORD,DESC_ROL,ESTADO,COD_IDROL,FOTO,FECHA) values(" & _
                        "(select count(1)+1 from tb_usuario),'" & _
                        dt.Rows(0)("USUARIO") & "','" & _
                        dt.Rows(0)("NOMBRE") & "','" & _
                        dt.Rows(0)("PASSWORD") & "','" & _
                        dt.Rows(0)("DESC_ROL") & "','" & _
                        dt.Rows(0)("ESTADO") & "','" & _
                        dt.Rows(0)("COD_IDROL") & "', @FOTO, '" & _
                        dt.Rows(0)("FECHA") & "')"
                    SqlInsert.Parameters.Add("@foto", SqlDbType.Image)
                    SqlInsert.Parameters(0).Value = MemoriaImg.ToArray
                    SqlInsert.ExecuteNonQuery()
                    SqlInsert.Parameters.Clear()
                    Res = True
                End If
            Catch ex As Exception
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return Res
    End Function


    Public Function permiso(ByVal script As String, ByVal scr As String, ByRef Mensaje As String) As Boolean
        Dim Resultado As Boolean
        If AbrirConexion(Mensaje) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlSelect.Transaction = Transaccion
            Try
                SqlSelect.CommandText = scr
                Dim cont As Integer = SqlSelect.ExecuteScalar()
                If cont > 0 Then
                    Mensaje = "YA EXISTE UN PERMISO PARA ESTE DIA"
                Else
                    SqlInsert.CommandText = script
                    SqlInsert.ExecuteNonQuery()
                    Transaccion.Commit()
                    Resultado = True
                End If
            Catch ex As Exception
                Transaccion.Rollback()
                Resultado = False
                Mensaje = ("se encontro con eror de " + ex.Message)
            End Try
        End If
        CerrarConexion()
        Return Resultado
    End Function

    Public Function agregamaterial(ByVal datos As DataTable, ByRef mensaje As String) As Boolean
        Dim resultado As Boolean
        If AbrirConexion(mensaje) = True Then
            Try
                SqlInsert.CommandText = "Insert into tb_materiales_cargados (cod_empleado, Codigo_empresa, nombre_material,fec_carga,monto,comentarios,estado,cantidad) values ('" & datos.Rows(0)("cod_empleado") & "','" & datos.Rows(0)("codigo_empresa") & "','" & datos.Rows(0)("nombre_material") & "','" & datos.Rows(0)("fec_carga") & "','" & datos.Rows(0)("monto") & "','" & datos.Rows(0)("comentarios") & "','" & datos.Rows(0)("estado") & "'," & datos.Rows(0)("cantidad") & ")"
                SqlInsert.ExecuteNonQuery()
                resultado = True
            Catch ex As Exception
                mensaje = ex.Message
                resultado = False
            End Try
        End If
        CerrarConexion()
        Return resultado
    End Function



    Public Function enviar_alerta(ByRef codigo As String) As Boolean
        Dim res As Boolean
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        _SMTP.Credentials = New System.Net.NetworkCredential("ticket.texsun@gmail.com", "Texsun2015")
        _SMTP.Host = "smtp.gmail.com"
        _SMTP.Port = 25
        _SMTP.EnableSsl = True
        _Message.[To].Add("amata@pcs.com.gt")
        _Message.From = New System.Net.Mail.MailAddress("ticket.texsun@gmail.com", "Sistema Nomina", Text.Encoding.UTF8) 'Quien lo envÃ­a
        _Message.Subject = "NUevo ingres" 'Sujeto del e-mail
        _Message.SubjectEncoding = Text.Encoding.UTF8 'Codificacion
        _Message.Body = "Se ha ingresado como empleado nuevo el codigo " & codigo 'contenido del mail
        _Message.BodyEncoding = Text.Encoding.UTF8
        _Message.Priority = Net.Mail.MailPriority.Normal
        _Message.IsBodyHtml = False
        'ENVIO
        Try
            _SMTP.Send(_Message)
            res = True
        Catch ex As System.Net.Mail.SmtpException
        End Try
        Return res
    End Function

    Public Function enviar_correo(ByRef codigo As String) As Boolean
        Dim res As Boolean
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        _SMTP.Credentials = New System.Net.NetworkCredential("ticket.texsun@gmail.com", "Texsun2015")
        _SMTP.Host = "smtp.gmail.com"
        _SMTP.Port = 25
        _SMTP.EnableSsl = True
        _Message.[To].Add("mario.chali@pcs.com.gt") 'Cuenta de Correo al que se le quiere enviar el e-mail
        _Message.[To].Add("personal@pcs.com.gt")
        _Message.[To].Add("personal2@pcs.com.gt")
        _Message.[To].Add("blanca.mundo@pcs.com.gt")
        _Message.From = New System.Net.Mail.MailAddress("ticket.texsun@gmail.com", "Sistema Nomina", Text.Encoding.UTF8) 'Quien lo envÃ­a
        _Message.Subject = "Suspensiones nomina" 'Sujeto del e-mail
        _Message.SubjectEncoding = Text.Encoding.UTF8 'Codificacion
        _Message.Body = "Durante esta quincena se termina suspension para:" & Chr(10) & codigo & Chr(10) & Chr(10) & "Correo automatico, no responder" 'contenido del mail
        _Message.BodyEncoding = Text.Encoding.UTF8
        _Message.Priority = Net.Mail.MailPriority.Normal
        _Message.IsBodyHtml = False
        'ENVIO
        Try
            _SMTP.Send(_Message)
            res = True
        Catch ex As System.Net.Mail.SmtpException
            'MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
        End Try
        Return res
    End Function



    Public Function enviar_correo_cods(ByRef codigo As String) As Boolean
        Dim res As Boolean
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        _SMTP.Credentials = New System.Net.NetworkCredential("ticket.texsun@gmail.com", "Texsun2015")
        _SMTP.Host = "smtp.gmail.com"
        _SMTP.Port = 25
        _SMTP.EnableSsl = True
        _Message.[To].Add("mario.chali@pcs.com.gt") 'Cuenta de Correo al que se le quiere enviar el e-mail
        _Message.From = New System.Net.Mail.MailAddress("ticket.texsun@gmail.com", "Sistema Nomina", Text.Encoding.UTF8) 'Quien lo envÃ­a
        _Message.Subject = "codigos de baja sin centro" 'Sujeto del e-mail
        _Message.SubjectEncoding = Text.Encoding.UTF8 'Codificacion
        _Message.Body = "codigos que estan de baja y no tienen centro asignado:" & Chr(10) & codigo & Chr(10) & Chr(10) & "Correo automatico, no responder" 'contenido del mail
        _Message.BodyEncoding = Text.Encoding.UTF8
        _Message.Priority = Net.Mail.MailPriority.Normal
        _Message.IsBodyHtml = False
        'ENVIO
        Try
            _SMTP.Send(_Message)
            res = True
        Catch ex As System.Net.Mail.SmtpException
            'MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
        End Try
        Return res
    End Function
    Public Function guarda_rol(dt As DataTable, idrol As String, msj As String) As Boolean
        Dim R As Boolean = False
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlDelete.Transaction = Transaccion
            SqlDelete.CommandText = "delete from TT_ROL_MENU where idrol = '" & idrol & "'"
            Try
                SqlDelete.ExecuteNonQuery()

                For i = 0 To dt.Rows.Count - 1
                    SqlInsert.CommandText = "INSERT INTO TT_ROL_MENU (COD_MENU,IDROL) VALUES ('" & dt.Rows(i)("CODMENU") & "', '" & idrol & "')"
                    SqlInsert.ExecuteNonQuery()
                Next
                Transaccion.Commit()
                R = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return R
    End Function

    Function eliminar(scr As String, ByRef mensaje As String) As Boolean
        Dim res As Boolean = False
        If AbrirConexion(mensaje) = True Then
            Try
                SqlDelete.CommandText = scr
                SqlDelete.ExecuteNonQuery()
                res = True
            Catch ex As Exception
                mensaje = ex.Message
            End Try
        End If
        CerrarConexion()
        Return res
    End Function

    Public Function enviar_correo_poliza(ByRef codigo As String) As Boolean
        Dim res As Boolean
        Dim _Message As New System.Net.Mail.MailMessage()
        Dim _SMTP As New System.Net.Mail.SmtpClient
        _SMTP.Credentials = New System.Net.NetworkCredential("ticket.texsun@gmail.com", "Texsun2015")
        _SMTP.Host = "smtp.gmail.com"
        _SMTP.Port = 25
        _SMTP.EnableSsl = True
        _Message.[To].Add("mario.chali@pcs.com.gt") 'Cuenta de Correo al que se le quiere enviar el e-mail
        _Message.From = New System.Net.Mail.MailAddress("ticket.texsun@gmail.com", "Sistema Nomina", Text.Encoding.UTF8) 'Quien lo envÃ­a
        _Message.Subject = "hay empleados que les paga texsun pero estan asigandos a departamentos de jt o zuntez" 'Sujeto del e-mail
        _Message.SubjectEncoding = Text.Encoding.UTF8 'Codificacion
        _Message.Body = "" & Chr(10) & codigo & Chr(10) & Chr(10) & "Correo automatico, no responder" 'contenido del mail
        _Message.BodyEncoding = Text.Encoding.UTF8
        _Message.Priority = Net.Mail.MailPriority.Normal
        _Message.IsBodyHtml = False
        'ENVIO
        Try
            _SMTP.Send(_Message)
            res = True
        Catch ex As System.Net.Mail.SmtpException
            'MessageBox.Show(ex.ToString, "Error!", MessageBoxButtons.OK)
        End Try
        Return res
    End Function


    Public Function guarda_poliza(ByVal dt As DataTable, ByRef msj As String) As Boolean
        Dim result As Boolean = False
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            Try
                For i = 0 To dt.Rows.Count - 1
                    SqlInsert.CommandText = "INSERT INTO POLI_CENTRO (ANIO,MES,CENTRO_COSTO,CUENTA,MONTO)VALUES ('" & _
                                            dt.Rows(i)("ANIO") & "', '" & dt.Rows(i)("MES") & "','" & dt.Rows(i)("CENTRO_COSTO") & "','" & dt.Rows(i)("CUENTA") & "','" & dt.Rows(i)("MONTO") & "')"
                    SqlInsert.ExecuteNonQuery()
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function

    Public Function guarda_poliza_01(ByVal scr As String, ByVal dt As DataTable, ByRef msj As String) As Boolean
        Dim result As Boolean = False
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            SqlUpdate.Transaction = Transaccion
            SqlDelete.Transaction = Transaccion
            Try
                SqlDelete.CommandText = scr
                SqlDelete.ExecuteNonQuery()
                For i = 0 To dt.Rows.Count - 1
                    SqlInsert.CommandText = "INSERT INTO POLI_CENTRO_01 (ANIO,MES,CENTRO_COSTO,CUENTA,MONTO,DESCRIPCION)VALUES ('" & _
                                            dt.Rows(i)("ANIO") & "', '" & dt.Rows(i)("MES") & "','" & dt.Rows(i)("CENTRO_COSTO") & "','" & dt.Rows(i)("CUENTA") & "','" & dt.Rows(i)("MONTO") & "','" & dt.Rows(i)("descripcion") & "')"
                    SqlInsert.ExecuteNonQuery()
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function


    Public Function DESCARGAFOTO(ByRef buscacodigo As DataTable, ByRef Algunmensaje As String)
        buscacodigo.Clear()
        Dim resultado As Boolean
        If AbrirConNoc(Algunmensaje) = True Then
            SqlSel.CommandText = "SELECT codigo,FOTO FROM M_FOTO0 WHERE CODIGO IN (100,101,102,103,104,106,107,111,112,113,114,115,116,117,118,120,121,122,123,124,126,127,128,129,17,20,23,24,34,35,38,45,50,504,506,508,510,512,513,514,515,516,517,53,55,59,60,61,68,69,7,72,73,74,76,78,79,92,94,95,97,98,99) "
            SqlNocAdapter.Fill(buscacodigo)
            If buscacodigo.Rows.Count > 0 Then
                resultado = True
            Else
                Algunmensaje = "Empleado no Existe"
                resultado = False
            End If
        End If
        CerrarConNoc()
        Return resultado
    End Function

    Function guarda_ciclonomina(dt As DataTable, msj As String) As Boolean
        Dim result As Boolean = False
        If AbrirConexion(msj) Then
            Dim Transaccion As SqlClient.SqlTransaction = SqlConexion.BeginTransaction()
            SqlInsert.Transaction = Transaccion
            Try
                For i = 0 To dt.Rows.Count - 1
                    SqlInsert.CommandText = "INSERT INTO TB_CICLO_NOMINA (ANIO,MES,QUINCENA,ESTADO,COD_EMPRESA,INICIO,FIN)VALUES ('" & _
                                            dt.Rows(i)("ANIO") & _
                                            "', '" & dt.Rows(i)("MES") & _
                                            "','" & dt.Rows(i)("QUINCENA") & _
                                            "','" & dt.Rows(i)("ESTADO") & _
                                            "','" & dt.Rows(i)("COD_EMPRESA") & _
                                            "','" & Format(CDate(dt.Rows(i)("INICIO")), "yyyy-MM-dd") & _
                                            "','" & Format(CDate(dt.Rows(i)("FIN")), "yyyy-MM-dd") & "')"
                    SqlInsert.ExecuteNonQuery()
                Next
                Transaccion.Commit()
                result = True
            Catch ex As Exception
                Transaccion.Rollback()
                msj = ex.Message
            End Try
        End If
        CerrarConexion()
        Return result
    End Function




End Class

