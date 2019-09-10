Imports System.IO
Imports System.Text
Imports System.Threading
Imports C1.Win.FlexReport

Public Class Frm_Pre_nomina
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim dtmes As New DataTable
    Dim dt As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim mes2 As Integer
    Dim fecha_inic As Date
    Dim fecha_fin As Date
    ' Dim empresa As Integer = 1
    Dim dtMarcas As New DataTable
    Dim dt_codigo As New DataTable
    Dim dt_dias_ord As New DataTable
    Dim dt_sueldos As New DataTable
    Dim dt_suspens As New DataTable
    Dim dt_asuetos As New DataTable
    Dim log As New StringBuilder
    Dim fec_inic_h As Date
    Dim fec_fin_h As Date
    Dim fec_inic_h2 As Date
    Dim fec_fin_h2 As Date
    Dim fec_inic_h3 As Date

    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue

    Private Sub Frm_Pre_nomina_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
        CbCiclo.SelectedIndex = 0
        crea_tabla()
    End Sub

    Private Sub fechas_Horas()
        Dim anio_h As Integer
        Dim anio2_H As Integer
        Dim mes_h As Integer
        Dim mes2_h As Integer
        anio_h = Format(DatAnio.Value, "yyyy")
        mes_h = Cbmes.SelectedValue
        If mes_h = 1 Then
            mes2_h = 12
            anio2_H = anio - 1
        Else
            mes2_h = mes - 1
            anio2_H = anio
        End If
        fec_inic_h = CDate(Format(anio2_H & "-" & mes2_h & "-" & 26))
        fec_fin_h = CDate(Format(anio_h & "-" & mes_h & "-" & 10))

        fec_inic_h2 = CDate(Format(anio_h & "-" & mes2_h & "-" & 11))
        ''''''modificar por fecha de cierre horas extras
        fec_fin_h2 = CDate(Format(anio_h & "-" & mes_h & "-" & 25))
        'fec_fin_h2 = CDate(Format(anio_h & "-" & mes_h & "-" & 24))
        fec_inic_h3 = CDate(Format(anio_h & "-" & mes_h & "-" & 11))
    End Sub

    Private Sub crea_tabla()
        dt_dias_ord.Columns.Add("CODIGO")
        dt_dias_ord.Columns.Add("EMPRESA")
        dt_dias_ord.Columns.Add("DIAS_T")
        dt_dias_ord.Columns.Add("DIAS")
        dt_dias_ord.Columns.Add("ANIO")
        dt_dias_ord.Columns.Add("MES")
        dt_dias_ord.Columns.Add("CICLO")
        dt_dias_ord.AcceptChanges()
    End Sub

    Private Sub fechas()
        Dim anio2 As Integer
        Dim fec_temp As Date
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbCiclo.Text
        If mes = 12 Then
            mes2 = 1
            anio2 = anio + 1
        Else
            mes2 = mes + 1
            anio2 = anio
        End If
        If ciclo = "1" Then
            fecha_inic = CDate(Format(anio & "-" & mes & "-" & 1))
            fecha_fin = CDate(Format(anio & "-" & mes & "-" & 15))
        ElseIf ciclo = "2" Then
            fecha_inic = CDate(Format(anio & "-" & mes & "-" & 16))
            fec_temp = CDate(Format(anio2 & "-" & mes2 & "-" & 1))
            fecha_fin = fec_temp.AddDays(-1)
        End If
    End Sub

    Private Sub Procesos()
        Dim anio_a As Integer
        Dim mes_a As Integer
        Dim crs As String = """'15'" & ",'40'"""
        fechas_Horas()
        scr = "SELECT fecha_asueto,COD_EMPLEADO FROM TB_ASUETO WHERE FECHA_ASUETO BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "' GROUP BY COD_EMPLEADO,fecha_asueto"
        cs.consultas(scr, dt_asuetos, msj)
        scr = "DELETE FROM TB_PRE_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo
        cs.procedure(scr, msj)
        scr = "EXECUTE CODIGOS_ALTA  @ANIO = " & anio & " , @MES = " & mes & ", @QUINCENA = " & ciclo & ", @EMPRESA = " &
                empresa & ",@FEC_INIC= '" & fecha_inic & "',@FEC_FIN= '" & fecha_fin & "'"
        If cs.procedure(scr, msj) Then
            scr = "select A.CODIGO,COD_DEPART,B.FECHA from TB_EMPLEADO AS A " & _
                    " LEFT JOIN TB_MARCA_FINAL AS B ON  A.CODIGO = B.CODIGO AND A.CODIGO_EMPRESA = B.EMPRESA AND FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "' " & _
                    " where CODIGO_EMPRESA = " & empresa & " and fec_alta <= '" & fecha_fin & "'  " &
                    "and fec_baja >= '" & fecha_inic & "' and estado_empleado in ('A','S') AND A.MARCA = 'S'"
            If cs.consultas(scr, dtMarcas, msj) Then
                dias_marcas()
                If ciclo = 1 Then
                    scr = " EXECUTE HORAS_EXT_SER @ANIO = " & anio &
                           ", @MES = " & mes &
                           ", @QUINCENA = " & ciclo &
                           ", @EMPRESA = " & empresa &
                           ", @FEC_INIC = '" & fec_inic_h &
                           "', @FEC_FIN = '" & fec_fin_h &
                           "', @DEPART = '15'"
                    cs.procedure(scr, msj)
                    scr = " EXECUTE HORAS_EXT_4x4 @ANIO = " & anio &
                    ", @MES = " & mes &
                    ", @QUINCENA = " & ciclo &
                    ", @EMPRESA = " & empresa &
                    ", @FEC_INIC = '" & fec_inic_h &
                    "', @FEC_FIN = '" & fec_fin_h &
                    "', @DEPART = '40'"
                    cs.procedure(scr, msj)
                ElseIf ciclo = 2 Then
                    scr = " EXECUTE HORAS_EXT_SER @ANIO = " & anio &
                           ", @MES = " & mes &
                           ", @QUINCENA = " & ciclo &
                           ", @EMPRESA = " & empresa &
                           ", @FEC_INIC = '" & fec_inic_h3 &
                           "', @FEC_FIN = '" & fec_fin_h2 &
                           "', @DEPART = '15'"
                    cs.procedure(scr, msj)
                    scr = " EXECUTE HORAS_EXT_GEN @ANIO = " & anio &
                            ", @MES = " & mes &
                            ", @QUINCENA = " & ciclo &
                            ", @EMPRESA = " & empresa &
                            ", @FEC_INIC = '" & fec_inic_h &
                            "', @FEC_FIN = '" & fec_fin_h2 &
                            "', @DEPART = " & "'15,40'"
                    cs.procedure(scr, msj)
                    scr = " EXECUTE HORAS_EXT_4x4 @ANIO = " & anio &
                            ", @MES = " & mes &
                            ", @QUINCENA = " & ciclo &
                            ", @EMPRESA = " & empresa &
                            ", @FEC_INIC = '" & fec_inic_h3 &
                            "', @FEC_FIN = '" & fec_fin_h2 &
                            "', @DEPART = '40'"
                    cs.procedure(scr, msj)
                End If
            End If
            scr = "EXECUTE BON_LEY @ANIO = " & anio & ",@MES = " & mes & " ,@QUINCENA =" & ciclo & " ,@EMPRESA =" & empresa
            If cs.procedure(scr, msj) Then
            End If
            scr = "EXECUTE BON_PROD @ANIO = " & anio & ",@MES = " & mes & " ,@QUINCENA =" & ciclo & " ,@EMPRESA =" & empresa
            If cs.procedure(scr, msj) Then
            End If
        End If
        If mes > 1 Then
            mes_a = mes - 1
        ElseIf mes = 1 Then
            mes_a = 12
        End If
        If mes = 1 And ciclo = 1 Then
            anio_a = anio_a = anio - 1
        Else
            anio_a = anio
        End If
        scr = "EXECUTE ASUETOS_PRENOMI @FEC_INIC = '" & fecha_inic & "' ,@FEC_FIN = '" & fecha_fin & "', @anio = " & anio & ",@MES = " & mes & " ,@QUINCENA =" & ciclo & " ,@EMPRESA =" & empresa & _
        ", @ANIO_A = " & anio_a & ",@MES_A = " & mes_a
        If cs.procedure(scr, msj) Then
        End If
        scr = "EXECUTE VACAS_PRE_NOM @INICIO = '" & fecha_inic & "' ,@FINAL = '" & fecha_fin & "', @anio = " & anio & ",@MES = " & mes & " ,@QUINCENA =" & ciclo & " ,@EMPRESA =" & empresa
        If cs.procedure(scr, msj) Then
        End If
        scr = "EXECUTE DESCUENTOS  @anio = " & anio & ",@MES = " & mes & " ,@QUINCENA =" & ciclo & " ,@EMPRESA =" & empresa & ", @INICIO  = '" & fecha_inic & "', @FINAL = '" & fecha_fin & "'"
        If cs.procedure(scr, msj) Then
        End If
        scr = "EXECUTE AJUSTES  @anio = " & anio & ",@MES = " & mes & " ,@QUINCENA =" & ciclo & " ,@EMPRESA =" & empresa & ", @INICIO  = '" & fecha_inic & "', @FINAL = '" & fecha_fin & "'"
        If cs.procedure(scr, msj) Then
        End If

    End Sub

    Private Sub dias_marcas()
        scr = "SELECT SUELDO_BASE/30 as SUELDO_DIARIO,CODIGO  FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO in ('A','S')"
        cs.consultas(scr, dt_sueldos, msj)
        dt_dias_ord.Clear()
        Dim dias As Integer
        Dim dt_faltas_marca As New DataTable
        Dim dt_permisos As New DataTable
        Dim dt_vacas As New DataTable
        Dim sueldo_diario As Double
        Dim tot_day As Integer
        Dim fec_temp As Date = fecha_inic
        Dim dia As Integer
        Dim dias_m() As DataRow
        Dim permisos() As DataRow
        Dim dtr_vacas() As DataRow
        Dim dias_desc As Integer
        Dim dtr_sus() As DataRow
        Dim dtr_asueto() As DataRow
        Dim sus As String = ""
        scr = "SELECT A.*,B.ESTADO_EMPLEADO FROM TB_SUSPENSION AS A INNER JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND B.ESTADO_EMPLEADO  IN ('S','A') WHERE FEC_FIN > '" & fecha_inic & "'"
        cs.consultas(scr, dt_suspens, msj)
        scr = "SELECT * FROM TB_VACAC WHERE FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "' "
        cs.consultas(scr, dt_vacas, msj)
        scr = "SELECT * FROM TB_PERMISO WHERE FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "' "
        cs.consultas(scr, dt_permisos, msj)
        scr = "SELECT * FROM TB_FALTAS_MARCA WHERE FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "' "
        cs.consultas(scr, dt_faltas_marca, msj)
        scr = "SELECT ANIO,MES,QUINCENA,A.CODIGO,COD_EMPRESA,ESTADO_EMPLEADO,FEC_ALTA from TB_PRE_NOMINA AS A" & _
               " INNER JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND A.COD_EMPRESA = B.CODIGO_EMPRESA AND B.MARCA = 'S'" & _
               " WHERE anio = " & anio & " And mes = " & mes & " And QUINCENA = " & ciclo & " And COD_EMPRESA =  " & empresa
        If cs.consultas(scr, dt_codigo, msj) Then
            Dim dd() As DataRow
            For i = 0 To dt_codigo.Rows.Count - 1
                'If dt_codigo.Rows(i)("codigo") = 398 Then
                'MsgBox("")
                'End If
                dias = 0
                fec_temp = fecha_inic
                Dim day_mes As Integer
                tot_day = DateDiff(DateInterval.Day, fecha_inic, fecha_fin)
                If tot_day = 13 Then
                    tot_day = tot_day + 1
                ElseIf tot_day = 12 Then
                    tot_day = tot_day + 2
                End If
                For j = 0 To tot_day
                    dd = dtMarcas.Select("codigo =  " & dt_codigo.Rows(i)("codigo") & " and fecha = '" & fec_temp & "'")
                    dia = fec_temp.DayOfWeek
                    day_mes = fec_temp.Day
                    ''''''============================== VERIFICA FECHA DE INICIO DE SUSPENSION
                    dtr_sus = dt_suspens.Select("codigo=" & dt_codigo.Rows(i)("codigo") & " and fec_inic <='" & fec_temp & "' and fec_fin >='" & fec_temp & "'")
                    sus = ""
                    If dtr_sus.Length > 0 Then
                        If dtr_sus(0)("fec_inic") <= fec_temp And dtr_sus(0)("fec_fin") >= fec_temp Then
                            sus = "no"
                        Else
                            sus = "si"
                        End If
                    Else
                        sus = "si"
                    End If
                    ''=================SI ES FIN DE SEMANA AGREGA EL DIA
                    If dia = "6" And sus = "si" And fec_temp > dt_codigo.Rows(i)("fec_alta") And day_mes < 31 Or dia = "0" And sus = "si" And fec_temp > dt_codigo.Rows(i)("fec_alta") And day_mes < 31 Or fec_temp >= Today And sus = "si" And day_mes < 31 Then
                        dias = dias + 1
                        fec_temp = fec_temp.AddDays(1)
                        Continue For
                    End If
                    If dd.Length > 0 Then
                        '==========VERIFICA SI HAY MARCACIONES EN VACACIONES 
                        Dim dtrr() As DataRow
                        dtrr = dt_vacas.Select("codigo = " & dt_codigo.Rows(i)("codigo") & " and fecha = '" & fec_temp & "'")
                        If dtrr.Length > 0 Then
                        ElseIf dtrr.Length = 0 Then
                            dias = dias + 1
                        End If
                        ''''''''''''''''''''''''''''''verifica si hay marcas en asueto y descuenta un dia ya que se paga hora extra el dia comleto
                        dtr_asueto = dt_asuetos.Select("cod_empleado = " & dt_codigo.Rows(i)("codigo") & "and fecha_asueto ='" & fec_temp & "'")
                        If dtr_asueto.Length > 0 Then
                            dias = dias - 1
                        End If
                    Else
                        '====================SI NO HAY MARCAS REVISA SI HAY PERMISOS
                        permisos = dt_permisos.Select("codigo = " & dt_codigo.Rows(i)("codigo") & "and fecha = '" & fec_temp & "'")
                        If permisos.Length > 0 Then
                            dias = dias + 1
                        End If
                    End If
                    fec_temp = fec_temp.AddDays(1)
                Next
                If dias = 16 Then
                    dias = 15
                    ' ElseIf dias = 14 And mes = 2 And ciclo = 2 Then
                    '    dias = 15
                End If

                '''' SI EXISTEN VACACIONES EN FECHAS FUTURAS LAS RESTA DEL DIARIO
                dtr_vacas = dt_vacas.Select("codigo = " & dt_codigo.Rows(i)("codigo") & " and fecha >= '" & Today & "'")
                dias = dias - dtr_vacas.Length
                Dim dtr_s() As DataRow
                ''''''''''''''''''  DIAS DE ASUETO
                'Dim dtr_asuet() As DataRow
                'dtr_asuet = dt_asuetos.Select("cod_empleado =" & dt_codigo.Rows(i)("codigo"))
                'If dtr_asuet.Length > 0 Then
                '    dias = dias - dtr_asuet.Length
                'End If
                ''''' VERIFICA SI HAY DIAS DE DESCUENTO
                dias_m = dt_faltas_marca.Select("codigo =" & dt_codigo.Rows(i)("codigo"))
                dias_desc = dias_m.Length
                dtr_s = dt_sueldos.Select("codigo = " & dt_codigo.Rows(i)("codigo"))
                sueldo_diario = dtr_s(0)("SUELDO_DIARIO") * (dias - dias_desc)
                dias = dias - dias_desc
                Dim dtrf As DataRow = dt_dias_ord.NewRow
                dtrf("CODIGO") = dt_codigo.Rows(i)("codigo")
                dtrf("EMPRESA") = empresa
                dtrf("DIAS_T") = dias
                If sueldo_diario > dtr_s(0)("SUELDO_DIARIO") * 15 Then
                    sueldo_diario = dtr_s(0)("SUELDO_DIARIO") * 15
                End If
                dtrf("DIAS") = sueldo_diario
                dtrf("ANIO") = anio
                dtrf("MES") = mes
                dtrf("CICLO") = ciclo
                dt_dias_ord.Rows.Add(dtrf)
                dt_dias_ord.AcceptChanges()
            Next
        End If
        dias_sin_marca()
        Try
            cs.horas_nom(dt_dias_ord, msj)
        Catch
        End Try
    End Sub

    Private Sub dias_sin_marca()
        Dim dias_antes_alta As Integer
        Dim fecha_temporal As Date
        Dim dt_emp_s_Marca As New DataTable
        Dim dt_faltas As New DataTable
        Dim dt_vacas As New DataTable
        Dim val_dia As Double
        Dim dias() As DataRow
        Dim dias_vac() As DataRow
        Dim dias_asueto() As DataRow
        Dim dias_desc As Integer
        scr = "SELECT * FROM TB_VACAC WHERE FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "' "
        cs.consultas(scr, dt_vacas, msj)
        scr = "SELECT * FROM TB_FALTA WHERE FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "' "
        cs.consultas(scr, dt_faltas, msj)
        scr = "SELECT A.CODIGO,B.SUELDO_BASE,FEC_ALTA FROM TB_PRE_NOMINA AS A" & _
              " INNER JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND B.MARCA = 'N'" & _
              " WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & " AND A.COD_EMPRESA = " & empresa
        If cs.consultas(scr, dt_emp_s_Marca, msj) Then
            For I = 0 To dt_emp_s_Marca.Rows.Count - 1
                ''''''================DESCUENTA DIAS SI ALTA ES MAYOR A FECHA DE INICIO
                fecha_temporal = fecha_inic
                dias_antes_alta = 0
                If dt_emp_s_Marca.Rows(I)("fec_alta") > fecha_temporal Then
                    ' If dt_emp_s_Marca.Rows(I)("codigo") = 606 Then
                    'MsgBox(dt_emp_s_Marca.Rows(I)("codigo"))
                    'End If
                    For j = 0 To 14
                        If dt_emp_s_Marca.Rows(I)("fec_alta") > fecha_temporal Then
                            dias_antes_alta = dias_antes_alta + 1
                        Else
                            Exit For
                        End If
                        fecha_temporal = fecha_temporal.AddDays(1)
                    Next
                End If
        '''''''''''''''DESCUENTA DIAS SI HAY VACACIONES
        dias_asueto = dt_asuetos.Select("COD_EMPLEADO = " & dt_emp_s_Marca.Rows(I)("CODIGO"))

        ''''=======================================================================
        val_dia = dt_emp_s_Marca.Rows(I)("SUELDO_BASE") / 30
        dias = dt_faltas.Select("codigo =" & dt_emp_s_Marca.Rows(I)("codigo"))
        dias_vac = dt_vacas.Select("codigo =" & dt_emp_s_Marca.Rows(I)("codigo"))
        dias_desc = dias.Length + dias_vac.Length + dias_antes_alta + dias_asueto.Length
        Dim dtrf As DataRow = dt_dias_ord.NewRow
        dtrf("CODIGO") = dt_emp_s_Marca.Rows(I)("codigo")
        dtrf("EMPRESA") = empresa
        dtrf("DIAS_T") = 15 - dias_desc
        If dias_desc >= 15 Then
            dtrf("DIAS") = 0
        Else
            dtrf("DIAS") = dt_emp_s_Marca.Rows(I)("sueldo_base") / 2 - (val_dia * dias_desc)
        End If
        dtrf("ANIO") = anio
        dtrf("MES") = mes
        dtrf("CICLO") = ciclo
        dt_dias_ord.Rows.Add(dtrf)
        dt_dias_ord.AcceptChanges()
            Next
        End If
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        envia_correo()
        Dim datos As Integer
        fechas()
        scr = "SELECT * FROM TB_CICLO_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & " AND COD_EMPRESA = " & empresa
        If cs.consultas(scr, dt, msj) Then
            scr = "SELECT COUNT(1) FROM TB_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo
            cs.csescalar(datos, scr, msj)
            If datos > 0 Then
                mensajes.Text = "YA SE CORRIO NOMINA!!!"
                REPORTE()
            Else
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("ESTADO") = "A" Then
                        Procesos()
                        REPORTE()
                        mensajes.Text = ""
                    Else
                        mensajes.Text = "CICLO CERRADO !!"
                    End If
                Else
                    mensajes.Text = "CICLO NO EXISTE!!"
                End If
            End If
        End If
    End Sub

    Private Sub envia_correo()
        Dim codigo As String = ""
        Dim valor As Integer
        scr = "SELECT COUNT(1) FROM TB_PRE_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & " AND COD_EMPRESA = " & empresa
        cs.csescalar(valor, scr, msj)
        If valor < 1 Then
            scr = "SELECT * FROM TB_SUSPENSION  AS A LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND A.COD_EMPRESA = B.CODIGO_EMPRESA " & _
                 " WHERE FEC_FIN BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "' "
            If cs.consultas(scr, dt, msj) Then
                For i = 0 To dt.Rows.Count - 1
                    codigo = codigo & dt.Rows(i)("codigo") & Chr(9) & dt.Rows(i)("nombre") & " " & dt.Rows(i)("segundo_nombre") & Chr(10)
                Next
                If cs.enviar_correo(codigo) Then
                End If
            End If
        End If
    End Sub

    Private Sub REPORTE()
        Dim fec_temp As Date = fecha_inic
        Try
            Cursor = Cursors.WaitCursor
            cr.Load("C:\Plan_rep\nomina.flxr", "pre_nomina")
            cr.DataSource.ConnectionString = cs.con
            cr.DataSource.RecordSource = " SELECT B.NOMBRE,B.SEGUNDO_NOMBRE, B.APELLIDO,B.SEGUNDO_APELLIDO,C.NOMBRE AS NOMBRE_DEPAR, A.* FROM TB_PRE_NOMINA AS A" &
                                         " LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND A.COD_EMPRESA = B.CODIGO_EMPRESA" &
                                         " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON A.DEPART = C.COD_DEPAR " &
                                         " WHERE anio = " & anio & " And mes = " & mes & " And QUINCENA = " & ciclo
            Dim perio As TextField = DirectCast(cr.Fields("periodo"), TextField)
            perio.Text = "Del " & fecha_inic & " Al " & fecha_fin

            cr.Render()
            Fv.DocumentSource = cr

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Combo_box_Mes()
        Dim mes As Integer
        mes = Date.Now.Month
        scr = "SELECT MES, NUMERO FROM MES"
        cs.consultas(scr, dtmes, msj)
        Cbmes.DataSource = dtmes
        Cbmes.DisplayMember = "MES"
        Cbmes.ValueMember = "NUMERO"
        Cbmes.SelectedIndex = mes - 1
    End Sub

    Private Sub prueba_()
        Dim prueba As String
        AbrirLog()
        For i = 0 To dt_dias_ord.Rows.Count - 1
            prueba = dt_dias_ord.Rows(i)("codigo") & "," &
            dt_dias_ord.Rows(i)("empresa") & "," &
            dt_dias_ord.Rows(i)("dias") & "," &
            dt_dias_ord.Rows(i)("anio") & "," &
            dt_dias_ord.Rows(i)("mes") & "," &
            dt_dias_ord.Rows(i)("ciclo")
            GrabarLog(prueba)
        Next
        CerrarLog()
    End Sub

    Private Sub GrabarLog(ByVal script As String)
        Dim Texto As String = String.Concat(script)
        log.AppendLine(Texto)
    End Sub

    Private Sub AbrirLog()
        log = New StringBuilder
    End Sub

    Private Sub CerrarLog()
        Try
            If File.Exists("c:\Log_marcas\Log_table.log") Then
                My.Computer.FileSystem.DeleteFile("c:\Log_marcas\Log_table.log")
            End If
            Dim Escritor As TextWriter = New StreamWriter("c:\Log_marcas\Log_table.log", True)
            Escritor.WriteLine(log.ToString)
            Escritor.Close()
        Catch ex As Exception
            EventLog.WriteEntry("MonitorServicio", "Error: " & ex.Message.ToString)
        End Try
    End Sub


End Class