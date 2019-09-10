Imports System.Text
Imports System.IO

Public Class FrmMarcajes
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim scr As String
    Dim msj As String
    Dim cs As New ClsConsultas
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim fecha_inic As Date
    Dim fecha_fin As Date
    Dim fecha_tem As Date
    Dim mes2 As Integer
    Dim dias As Integer
    Dim prueba As String
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    Dim dtmarca As New DataTable
    Dim dtcodigo_g As New DataTable
    Dim dtturno As New DataTable
    Dim dtcodigo As New DataTable
    Dim dtcodigo_4x4 As New DataTable
    Dim dtMes As New DataTable
    Dim diasem As Date
    Dim log As New StringBuilder
    Dim dthoras As New DataTable
    Dim dtMarcaFin As New DataTable
    Dim dt_horas As New DataTable
    Dim dt_rep_marcas As New DataTable
    Dim dtMarcas As New DataTable
    Dim dt_asueto As New DataTable

    Private Sub FrmHorasExtras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l - 20, a - 40)
        Me.Top = a - (a - 40 / 2)
        Me.Left = l - (l - 20 / 2)
        Combo_box_Mes()
        CbCiclo.SelectedIndex = 0
        crea_table()
        PrgBar.Visible = False
    End Sub

    Private Sub Combo_box_Mes()
        Dim mes As Integer
        mes = Date.Now.Month
        scr = "SELECT MES, NUMERO FROM MES"
        cs.consultas(scr, dtMes, msj)
        Cbmes.DataSource = dtMes
        Cbmes.DisplayMember = "MES"
        Cbmes.ValueMember = "NUMERO"
        Cbmes.SelectedIndex = mes - 1
    End Sub

    Private Sub Fechas()
        Dim anio2 As Integer
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbCiclo.Text
        If mes = 1 Then
            mes2 = 12
            anio2 = anio - 1
        Else
            mes2 = mes - 1
            anio2 = anio
        End If
        If ciclo = "1" Then
            fecha_inic = CDate(Format(anio2 & "-" & mes2 & "-" & 26))
            fecha_fin = CDate(Format(anio & "-" & mes & "-" & 10))
        ElseIf ciclo = "2" Then
            fecha_inic = CDate(Format(anio & "-" & mes & "-" & 11))
            fecha_fin = CDate(Format(anio & "-" & mes & "-" & 25))
        End If
        dias = (fecha_fin - fecha_inic).TotalDays
    End Sub

    Private Function Consultas() As Boolean
        Dim resuta As Boolean = False
        Try
            scr = "SELECT COD_EMPLEADO,FECHA_ASUETO FROM TB_ASUETO WHERE FECHA_ASUETO BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "' GROUP BY COD_EMPLEADO,FECHA_ASUETO"
            cs.consultas(scr, dt_asueto, msj)
        Catch
        End Try


        Try
            scr = "SELECT DISTINCT(CODIGO),COD_DEPART,HORAS_EX FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO in ('A','S') AND COD_DEPART = '15' AND CODIGO_EMPRESA = '" & empresa & "' ORDER BY CODIGO ASC"
            If cs.consultas(scr, dtcodigo, msj) Then
                scr = "SELECT DISTINCT(CODIGO),COD_DEPART,HORAS_EX FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO in ('A','S') AND CODIGO_EMPRESA = '" & empresa & "' ORDER BY CODIGO ASC"
                If cs.consultas(scr, dtcodigo_g, msj) Then
                    Try
                        scr = "SELECT A.CODIGO,CODIGO_RELOJ,B.FECHA,B.HORA,A.COD_DEPART FROM TB_EMPLEADO AS A " &
                                " LEFT JOIN TB_MARCA AS B ON A.CODIGO_RELOJ = B.CODIGO AND B.FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin.AddDays(1) & "' " &
                                " WHERE A.ESTADO_EMPLEADO  in ('A','S') AND CODIGO_EMPRESA = '" & empresa & "'"
                        If cs.consultas(scr, dtmarca, msj) Then
                            scr = "SELECT * FROM TB_TURNO_SER WHERE FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "'"
                            Try
                                If cs.consultas(scr, dtturno, msj) Then
                                    resuta = True
                                End If
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
        Return resuta
    End Function

    Private Sub Crea_table()
        dthoras.Columns.Add("codigo_empleado")
        dthoras.Columns.Add("codigo_empresa")
        dthoras.Columns.Add("horas")
        dthoras.Columns.Add("fecha")
        dthoras.AcceptChanges()

        dtMarcaFin.Columns.Add("CODIGO")
        dtMarcaFin.Columns.Add("EMPRESA")
        dtMarcaFin.Columns.Add("FECHA")
        dtMarcaFin.Columns.Add("ENTRADA")
        dtMarcaFin.Columns.Add("SALIDA")
        dtMarcaFin.AcceptChanges()

        dt_rep_marcas.Columns.Add("CODIGO")
        dt_rep_marcas.Columns.Add("NOMBRE")
        dt_rep_marcas.Columns.Add("DEPARTAMENTO")
        dt_rep_marcas.Columns.Add("D1")
        dt_rep_marcas.Columns.Add("D2")
        dt_rep_marcas.Columns.Add("D3")
        dt_rep_marcas.Columns.Add("D4")
        dt_rep_marcas.Columns.Add("D5")
        dt_rep_marcas.Columns.Add("D6")
        dt_rep_marcas.Columns.Add("D7")
        dt_rep_marcas.Columns.Add("D8")
        dt_rep_marcas.Columns.Add("D9")
        dt_rep_marcas.Columns.Add("D10")
        dt_rep_marcas.Columns.Add("D11")
        dt_rep_marcas.Columns.Add("D12")
        dt_rep_marcas.Columns.Add("D13")
        dt_rep_marcas.Columns.Add("D14")
        dt_rep_marcas.Columns.Add("D15")
        dt_rep_marcas.Columns.Add("D16")
        dt_rep_marcas.AcceptChanges()
    End Sub

    Private Sub Marcas_noc()
        Dim minuto As Integer
        Dim totalmin As Integer
        Dim hfinal As Double
        Dim hor_ent As Integer
        Dim min_ent As Integer
        Dim fec_sal As Date
        Dim numdia As Integer
        'Dim entero As Integer
        Dim hour As String = "HH"
        Dim min As String = "mm"
        Dim dia As String = "DD"
        ' Dim partes()
        Dim extra As Integer
        Dim tiempo As Integer
        Dim strDouble As String
        Dim fec_tem As Date
        Dim fec_tem_ent As Date
        Dim strHora As String = ""
        Dim horas As String
        Dim minutos As Double
        For I = 0 To dtcodigo.Rows.Count - 1
            Dim dd As DataRow()
            Dim dtr As DataRow
            '||||||||||||||||||||||||||||||||||||||| -------SELECCIONA DIAS DE LA QUINCENA A PAGAR-----
            dd = dtturno.Select("codigo =" & dtcodigo.Rows(I)("codigo"), "fecha asc ")
            For Each dtr In dd
                Dim ddm As DataRow()
                Dim dds As DataRow()
                fec_sal = dtr("fecha")
                '|||||||||||||||||||||||||||||||||||----------SELECCION MARCAS DEL DIA------
                ddm = dtmarca.Select("codigo = ' " & dtr("codigo") & "' and COD_DEPART = 15 and fecha = '" & dtr("fecha") & "'and hora > '07:30'", "fecha asc ")
                dds = dtmarca.Select("codigo = ' " & dtr("codigo") & "' and COD_DEPART = 15 and fecha = '" & fec_sal.AddDays(1) & "' and hora < '07:29'", "fecha asc ")
                Dim dtt As DataRow
                Dim dts As DataRow
                '  If dtcodigo.Rows(I)("codigo") = 7018 Then
                'MsgBox(dtcodigo.Rows(I)("codigo"))
                ' End If
                If dtr("turno") = "NOC" Then
                    If ddm.Length > 0 Then
                        diasem = dtr("fecha")
                        numdia = diasem.DayOfWeek
                        '=======================================
                        '====================================== ENTRADA
                        If dds.Length > 0 Then
                            dtt = dds(dds.Length - 1)
                            fec_tem = CDate(dtt("fecha") & " " & dtt("hora"))
                            tiempo = Format(fec_tem, hour)
                            minuto = Format(fec_tem, min)
                        Else
                            tiempo = Nothing
                            minuto = Nothing
                        End If
                        '==================================================================
                        '==================================================================SALIDA ==========================
                        dts = ddm(0)
                        fec_tem_ent = CDate(dts("fecha") & " " & dts("hora"))
                        hor_ent = Format(fec_tem_ent, hour)
                        min_ent = Format(fec_tem_ent, min) '||||||||||||||||||||||||||||||||||||| ------VALIDA QUE TURNO ES -----------
                    Else
                        Continue For
                    End If
                    '|==================================================================================================|
                    '|==================    GUARDA MARCAS ENTRADAS Y SALIDAS TURNO MATUTINO=============================|
                    Dim dt_marcas As DataRow = dtMarcaFin.NewRow
                    dt_marcas("codigo") = dtcodigo.Rows(I)("codigo")
                    dt_marcas("empresa") = empresa
                    dt_marcas("fecha") = Format(dtr("fecha"), "yyyy-MM-dd")
                    dt_marcas("entrada") = Format(hor_ent, "00") & ":" & Format(min_ent, "00")
                    dt_marcas("salida") = Format(tiempo, "00") & ":" & Format(minuto, "00")
                    dtMarcaFin.Rows.Add(dt_marcas)
                    dtMarcaFin.AcceptChanges()
                    '==================================VALIDA QUE DIA DE LA SEMAN PARA HACER EL CALCULO DE HORAS Y OBTENER MARCAS====
                    '================================================================================================================
                    If minuto > 0 Or tiempo > 0 Then
                        totalmin = tiempo * 60 + minuto
                        extra = totalmin - 60
                        hfinal = extra / 60
                        hfinal = extra / 60
                        If extra > 0 Then
                            strDouble = hfinal
                            horas = Trim(Math.Floor(extra / 60))
                            minutos = Trim(extra Mod 60)
                            strHora = horas & "." & Format(minutos, "00")
                        End If

                        If strHora = "" Then
                        Else
                            If dtcodigo.Rows(I)("HORAS_EX") = "S" Then
                                '  If hfinal >= 0.5 Then
                                Dim registro As DataRow = dthoras.NewRow()
                                registro("codigo_empleado") = dtcodigo.Rows(I)("codigo")
                                registro("codigo_empresa") = empresa
                                If strHora Is Nothing Then
                                    strHora = 0
                                End If
                                registro("horas") = strHora 'hfinal
                                registro("fecha") = Format(dtr("fecha"), "yyyy-MM-dd")
                                dthoras.Rows.Add(registro)
                            End If
                        End If
                        strHora = "0"
                        minutos = 0
                        horas = 0
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        PrgBar.Visible = True
        PrgBar.Value = 0
        dtMarcaFin.Clear()
        dthoras.Clear()
        Dim minuto As Integer
        Dim totalmin As Integer
        Dim hfinal As Double
        Dim hor_ent As Integer
        Dim min_ent As Integer
        Dim entrada As Integer
        Dim numdia As Integer
        ' Dim entero As Integer
        Dim hour As String = "HH"
        Dim min As String = "mm"
        Dim dia As String = "DD"
        '   Dim partes()
        Dim extra As Integer
        Dim tiempo As Integer
        Dim strDouble As String
        Dim fec_tem As Date
        Dim fec_tem_ent As Date
        Dim pgr_as As Integer
        Dim dr_asueto() As DataRow
        Dim StrHora As String
        Dim horas As String
        Dim minutos As Double
        fechas()
        If consultas() = False Then
        Else
            PrgBar.Value = 10
            pgr_as = dtcodigo.Rows.Count
            For I = 0 To dtcodigo.Rows.Count - 1
                Dim dd As DataRow()
                Dim dtr As DataRow
                If I < pgr_as / 3 Then
                    PrgBar.Value = 15
                ElseIf I > pgr_as / 3 And I < pgr_as / 3 * 2 Then
                    PrgBar.Value = 25
                ElseIf I > pgr_as / 3 * 2 Then
                End If
                '||||||||||||||||||||||||||||||||||||||| -------SELECCIONA DIAS DE LA QUINCENA A PAGAR-----
                dd = dtturno.Select("codigo =" & dtcodigo.Rows(I)("codigo"), "fecha asc ")
                PrgBar.Value = 10
                For Each dtr In dd
                    Dim ddm As DataRow()
                    '|||||||||||||||||||||||||||||||||||----------SELECCION MARCAS DEL DIA------
                    '|==================================================================================================|
                    '|==================    GUARDA MARCAS ENTRADAS Y SALIDAS TURNO MATUTINO=============================|
                    If dtr("turno") = "MAT" Then
                        ddm = dtmarca.Select("codigo = ' " & dtr("codigo") & "' and fecha = '" & dtr("fecha") & "'and hora > '06:20'", "fecha asc ")
                        '  If dtcodigo.Rows(I)("codigo") = 7293 Then
                        'MsgBox("")
                        'dtcodigo.Rows(I)("codigo")
                        'End If
                        'ddm = dtmarca.Select("codigo = ' " & dtr("codigo") & "' and fecha = '" & dtr("fecha") & "'", "fecha asc ")
                        If ddm.Length > 0 Then
                            diasem = dtr("fecha")
                            numdia = diasem.DayOfWeek
                            Dim dtt As DataRow
                            Dim dts As DataRow
                            dtt = ddm(ddm.Length - 1)
                            fec_tem = CDate(dtt("fecha") & " " & dtt("hora"))
                            tiempo = Format(fec_tem, hour)
                            minuto = Format(fec_tem, min)
                            dts = ddm(0)
                            fec_tem_ent = CDate(dts("fecha") & " " & dts("hora"))
                            hor_ent = Format(fec_tem_ent, hour)
                            min_ent = Format(fec_tem_ent, min)
                            '||||||||||||||||||||||||||||||||||||| ------VALIDA QUE TURNO ES -----------
                        Else
                            Continue For
                        End If
                        Dim dt_marcas As DataRow = dtMarcaFin.NewRow
                        dt_marcas("codigo") = dtcodigo.Rows(I)("codigo")
                        dt_marcas("fecha") = Format(dtr("fecha"), "yyyy-MM-dd")
                        dt_marcas("EMPRESA") = empresa
                        dt_marcas("entrada") = Format(hor_ent, "00") & ":" & Format(min_ent, "00")
                        dt_marcas("salida") = Format(tiempo, "00") & ":" & Format(minuto, "00")
                        dtMarcaFin.Rows.Add(dt_marcas)
                        dtMarcaFin.AcceptChanges()
                        '''''''''''''''''''''''''''''''''''''VALIDA SI LA FECHA ES ASUETO PARA PAGAR HORAS EXTRAS TODO EL DIA
                        'MsgBox(dt_asueto.Rows.Count)
                        dr_asueto = dt_asueto.Select("cod_empleado=" & dtr("codigo") & "and fecha_asueto ='" & dtr("fecha") & "'")
                        If dr_asueto.Length > 0 Then
                            numdia = 6
                        End If
                        '||||||||||||||||||||-------VALIDA QUE DIA DE LA SEMAN PARA HACER EL CALCULO DE HORAS Y OBTENER MARCAS-----------
                        If (numdia = "1" Or numdia = "2" Or numdia = "3" Or numdia = "4") Then
                            totalmin = tiempo * 60 + minuto
                            extra = totalmin - 1020
                            hfinal = extra / 60
                            If extra > 0 Then
                                strDouble = hfinal
                                horas = Trim(Math.Floor(extra / 60))
                                minutos = Trim(extra Mod 60)
                                StrHora = horas & "." & Format(minutos, "00")
                            Else
                                StrHora = "0"
                            End If
                            If StrHora = "" Then
                            Else
                                If dtcodigo.Rows(I)("HORAS_EX") = "S" Then
                                    Dim registro As DataRow = dthoras.NewRow()
                                    registro("codigo_empleado") = dtcodigo.Rows(I)("codigo")
                                    registro("codigo_empresa") = empresa
                                    registro("horas") = StrHora
                                    registro("fecha") = Format(dtr("fecha"), "yyyy-MM-dd")
                                    dthoras.Rows.Add(registro)
                                End If
                            End If
                            StrHora = "0"
                            minutos = 0
                            horas = 0
                        ElseIf (numdia = "5") Then
                            totalmin = tiempo * 60 + minuto
                            extra = totalmin - 960
                            hfinal = extra / 60
                            If extra > 0 Then
                                strDouble = hfinal
                                horas = Trim(Math.Floor(extra / 60))
                                minutos = Trim(extra Mod 60)
                                StrHora = horas & "." & Format(minutos, "00")
                            Else
                                StrHora = 0
                            End If
                            If StrHora = "" Then
                            Else
                                If dtcodigo.Rows(I)("HORAS_EX") = "S" Then
                                    Dim registro As DataRow = dthoras.NewRow()
                                    registro("codigo_empleado") = dtcodigo.Rows(I)("codigo")
                                    registro("codigo_empresa") = empresa
                                    registro("horas") = StrHora 'hfinal
                                    registro("fecha") = Format(dtr("fecha"), "yyyy-MM-dd")
                                    dthoras.Rows.Add(registro)
                                End If
                            End If
                            StrHora = "0"
                            minutos = 0
                            horas = 0
                        ElseIf (numdia = "6" Or numdia = "7") Then
                            entrada = hor_ent * 60 + min_ent
                            totalmin = tiempo * 60 + minuto
                            extra = totalmin - entrada
                            hfinal = extra / 60
                            strDouble = hfinal
                            horas = Trim(Math.Floor(extra / 60))
                            minutos = Trim(extra Mod 60)
                            StrHora = horas & "." & Format(minutos, "00")
                            If StrHora = "" Then
                            Else
                                If dtcodigo.Rows(I)("HORAS_EX") = "S" Then
                                    Dim registro As DataRow = dthoras.NewRow()
                                    registro("codigo_empleado") = dtcodigo.Rows(I)("codigo")
                                    registro("codigo_empresa") = empresa
                                    registro("horas") = StrHora ' hfinal
                                    registro("fecha") = Format(dtr("fecha"), "yyyy-MM-dd")
                                    dthoras.Rows.Add(registro)
                                End If
                            End If
                            StrHora = "0"
                            minutos = 0
                            horas = 0
                        End If
                    End If
                Next
            Next
        End If
        PrgBar.Value = 60
        calcula_horas_general()
        PrgBar.Value = 70
        Try
            If cs.guarda_horas(dthoras, fecha_inic, fecha_fin, msj) Then
            Else
                MsgBox(msj)
            End If
            If cs.guarda_marcas(dtMarcaFin, msj) Then
            Else
                MsgBox(msj)
            End If
        Catch ex As Exception
        End Try
        PrgBar.Value = 80
        reporte_marcas()
        PrgBar.Value = 90
        PrgBar.Value = 100
        PrgBar.Visible = False
    End Sub

    Private Sub calcula_horas_general()
        Dim minuto As Integer
        Dim totalmin As Integer
        Dim hfinal As Double
        Dim hor_ent As Integer
        Dim min_ent As Integer
        Dim entrada As Integer
        Dim numdia As Integer
        Dim entero As Integer
        Dim hour As String = "HH"
        Dim min As String = "mm"
        Dim dia As String = "DD"
        Dim partes()
        Dim extra As Integer
        Dim tiempo As Integer
        Dim strDouble As String
        Dim fec_tem As Date
        Dim fec_tem_ent As Date
        Dim dr_asueto() As DataRow
        Dim StrHora As String = ""
        Dim horas As String
        Dim minutos As Double
        fechas()
        If consultas() = False Then
        Else
            Dim SDRCOD() As DataRow
            SDRCOD = dtcodigo_g.Select("COD_DEPART <> '15'and cod_depart<> '40'")
            For Each dtr_cod In SDRCOD
                fec_tem = fecha_inic
                '  Dim dtr As DataRow
                Dim ddm As DataRow()
                For j = 0 To dias
                    '|||||||||||||||||||||||||||||||||||----------SELECCION MARCAS DEL DIA------
                    ddm = dtmarca.Select("codigo = ' " & dtr_cod("codigo") & "' and fecha ='" & Format(fec_tem, "yyyy-MM-dd") & "'", "hora asc ")
                    If dtr_cod("codigo") = 7293 Then
                        MsgBox(dtr_cod("codigo"))
                    End If
                    If ddm.Length > 0 Then
                        diasem = fec_tem
                        numdia = diasem.DayOfWeek
                        Dim dtt As DataRow
                        Dim dts As DataRow
                        dtt = ddm(ddm.Length - 1)
                        fec_tem = CDate(dtt("fecha") & " " & dtt("hora"))
                        tiempo = Format(fec_tem, hour)
                        minuto = Format(fec_tem, min)
                        dts = ddm(0)
                        fec_tem_ent = CDate(dts("fecha") & " " & dts("hora"))
                        hor_ent = Format(fec_tem_ent, hour)
                        min_ent = Format(fec_tem_ent, min)
                        '||||||||||||||||||||||||||||||||||||| ------VALIDA QUE TURNO ES --------
                    Else
                        fec_tem = fec_tem.AddDays(1)
                        Continue For
                    End If
                    '|==================================================================================================|
                    '|==================    GUARDA MARCAS ENTRADAS Y SALIDAS TURNO MATUTINO=============================|
                    Dim dt_marcas As DataRow = dtMarcaFin.NewRow
                    dt_marcas("codigo") = dtr_cod("codigo")
                    dt_marcas("fecha") = Format(fec_tem, "yyyy-MM-dd")
                    dt_marcas("EMPRESA") = empresa
                    dt_marcas("entrada") = Format(hor_ent, "00") & ":" & Format(min_ent, "00")
                    dt_marcas("salida") = Format(tiempo, "00") & ":" & Format(minuto, "00")
                    dtMarcaFin.Rows.Add(dt_marcas)
                    dtMarcaFin.AcceptChanges()

                    '''''''''''''''''''''''''''''''''''''VALIDA SI LA FECHA ES ASUETO PARA PAGAR HORAS EXTRAS TODO EL DIA
                    dr_asueto = dt_asueto.Select("cod_empleado= " & dtr_cod("codigo") & "and fecha_asueto ='" & Format(fec_tem, "yyyy-MM-dd") & "'")
                    If dr_asueto.Length > 0 Then
                        numdia = 6
                    End If
                    '||||||||||||||||||||-------VALIDA QUE DIA DE LA SEMAN PARA HACER EL CALCULO DE HORAS Y OBTENER MARCAS-----------

                    If (numdia = "1" Or numdia = "2" Or numdia = "3" Or numdia = "4") Then
                        entero = 0
                        totalmin = tiempo * 60 + minuto
                        extra = totalmin - 980
                        hfinal = extra / 60
                        If extra > 0 Then
                            strDouble = hfinal

                            horas = Trim(Math.Floor(extra / 60))
                            minutos = Trim(extra Mod 60)
                            StrHora = horas & "." & Format(minutos, "00")
                        End If
                        If StrHora = "" Then
                        Else
                            If dtr_cod("HORAS_EX") = "S" Then
                                'If hfinal >= 0.5 Then
                                Dim registro As DataRow = dthoras.NewRow()
                                registro("codigo_empleado") = dtr_cod("codigo")
                                registro("codigo_empresa") = empresa
                                registro("horas") = StrHora
                                registro("fecha") = Format(fec_tem, "yyyy-MM-dd")
                                dthoras.Rows.Add(registro)
                            End If
                        End If
                        StrHora = "0"
                        minutos = 0
                        horas = 0
                    ElseIf (numdia = "5") Then
                        totalmin = tiempo * 60 + minuto
                        extra = totalmin - 970
                        hfinal = extra / 60
                        If extra > 0 Then
                            strDouble = hfinal
                            horas = Trim(Math.Floor(extra / 60))
                            minutos = Trim(extra Mod 60)
                            StrHora = horas & "." & Format(minutos, "00")
                        End If
                        If StrHora = "" Then
                        Else
                            If dtr_cod("HORAS_EX") = "S" Then
                                'If hfinal >= 0.5 Then
                                Dim registro As DataRow = dthoras.NewRow()
                                registro("codigo_empleado") = dtr_cod("codigo")
                                registro("codigo_empresa") = empresa
                                registro("horas") = StrHora
                                registro("fecha") = Format(fec_tem, "yyyy-MM-dd")
                                dthoras.Rows.Add(registro)
                                'Else
                                'End If
                            End If
                        End If
                        StrHora = "0"
                        minutos = 0
                        horas = 0
                    ElseIf (numdia = "6" Or numdia = "7") Then
                        entrada = hor_ent * 60 + min_ent
                        totalmin = tiempo * 60 + minuto
                        extra = totalmin - entrada
                        hfinal = extra / 60
                        strDouble = hfinal
                        partes = strDouble.Split(".")
                        strDouble = hfinal

                        horas = Trim(Math.Floor(extra / 60))
                        minutos = Trim(extra Mod 60)
                        StrHora = horas & "." & Format(minutos, "00")

                        If StrHora = "" Then
                        Else
                            If dtr_cod("HORAS_EX") = "S" Then
                                'If hfinal >= 0.5 Then
                                Dim registro As DataRow = dthoras.NewRow()
                                registro("codigo_empleado") = dtr_cod("codigo")
                                registro("codigo_empresa") = empresa
                                registro("horas") = StrHora ' hfinal
                                registro("fecha") = Format(fec_tem, "yyyy-MM-dd")
                                dthoras.Rows.Add(registro)
                            End If
                        End If
                        StrHora = "0"
                        minutos = 0
                        horas = 0
                    End If
                    fec_tem = fec_tem.AddDays(1)
                Next
            Next
            Marcas_noc()
            Cuatro_x_cuatro()
        End If
        Try
            If cs.guarda_horas(dthoras, fecha_inic, fecha_fin, msj) Then
            Else
                MsgBox(msj)
            End If
            If cs.guarda_marcas(dtMarcaFin, msj) Then
            Else
                MsgBox(msj)
            End If
        Catch ex As Exception
        End Try
        reporte_marcas()
    End Sub


    Private Sub Cuatro_x_cuatro()
        Dim entrada As Integer
        Dim dr_asueto() As DataRow
        Dim minuto As Integer
        Dim totalmin As Integer
        Dim hfinal As Double
        Dim hor_ent As Integer
        Dim min_ent As Integer
        Dim numdia As Integer
        Dim entero As Integer
        Dim hour As String = "HH"
        Dim min As String = "mm"
        Dim dia As String = "DD"
        Dim extra As Integer
        Dim tiempo As Integer
        Dim strDouble As String
        Dim fec_tem As Date
        Dim fec_tem_ent As Date
        Dim StrHora As String = ""
        Dim horas As String
        Dim minutos As Double
        Dim SDRCOD() As DataRow
        SDRCOD = dtcodigo_g.Select("COD_DEPART = '40'")
        For Each dtr_cod In SDRCOD
            fec_tem = fecha_inic
            Dim ddm As DataRow()
            For j = 0 To dias
                '|||||||||||||||||||||||||||||||||||----------SELECCION MARCAS DEL DIA------
                ddm = dtmarca.Select("codigo = ' " & dtr_cod("codigo") & "' and fecha ='" & Format(fec_tem, "yyyy-MM-dd") & "'", "hora asc ")
                If ddm.Length > 0 Then
                    diasem = fec_tem
                    numdia = diasem.DayOfWeek
                    Dim dtt As DataRow
                    Dim dts As DataRow
                    dtt = ddm(ddm.Length - 1)
                    fec_tem = CDate(dtt("fecha") & " " & dtt("hora"))
                    tiempo = Format(fec_tem, hour)
                    minuto = Format(fec_tem, min)
                    dts = ddm(0)
                    fec_tem_ent = CDate(dts("fecha") & " " & dts("hora"))
                    hor_ent = Format(fec_tem_ent, hour)
                    min_ent = Format(fec_tem_ent, min)
                Else
                    fec_tem = fec_tem.AddDays(1)
                    Continue For
                End If

                '|==================================================================================================|
                '|==================    GUARDA MARCAS ENTRADAS Y SALIDAS TURNO MATUTINO=============================|
                Dim dt_marcas As DataRow = dtMarcaFin.NewRow
                dt_marcas("codigo") = dtr_cod("codigo")
                dt_marcas("fecha") = Format(fec_tem, "yyyy-MM-dd")
                dt_marcas("EMPRESA") = empresa
                dt_marcas("entrada") = Format(hor_ent, "00") & ":" & Format(min_ent, "00")
                dt_marcas("salida") = Format(tiempo, "00") & ":" & Format(minuto, "00")
                dtMarcaFin.Rows.Add(dt_marcas)
                dtMarcaFin.AcceptChanges()
                '||||||||||||||||||||-------VALIDA QUE DIA DE LA SEMAN PARA HACER EL CALCULO DE HORAS Y OBTENER MARCAS-----------
                dr_asueto = dt_asueto.Select("cod_empleado= " & dtr_cod("codigo") & "and fecha_asueto ='" & Format(fec_tem, "yyyy-MM-dd") & "'")
                If dr_asueto.Length > 0 Then
                    entrada = hor_ent * 60 + min_ent
                    entero = 0
                    totalmin = tiempo * 60 + minuto
                    extra = totalmin - entrada
                    hfinal = extra / 60
                    If extra > 0 Then
                        strDouble = hfinal
                        horas = Trim(Math.Floor(extra / 60))
                        minutos = Trim(extra Mod 60)
                        StrHora = horas & "." & Format(minutos, "00")
                    End If
                    If StrHora = "" Or StrHora = "0" Then
                    Else
                        Dim registro As DataRow = dthoras.NewRow()
                        registro("codigo_empleado") = dtr_cod("codigo")
                        registro("codigo_empresa") = empresa
                        registro("horas") = StrHora
                        registro("fecha") = Format(fec_tem, "yyyy-MM-dd")
                        dthoras.Rows.Add(registro)
                    End If
                    StrHora = "0"
                    minutos = 0
                    horas = 0

                Else
                    entero = 0
                    totalmin = tiempo * 60 + minuto
                    extra = totalmin - 1020
                    hfinal = extra / 60
                    If extra > 0 Then
                        strDouble = hfinal
                        horas = Trim(Math.Floor(extra / 60))
                        minutos = Trim(extra Mod 60)
                        StrHora = horas & "." & Format(minutos, "00")
                    End If
                    If StrHora = "" Or StrHora = "0" Then
                    Else
                        Dim registro As DataRow = dthoras.NewRow()
                        registro("codigo_empleado") = dtr_cod("codigo")
                        registro("codigo_empresa") = empresa
                        registro("horas") = StrHora
                        registro("fecha") = Format(fec_tem, "yyyy-MM-dd")
                        dthoras.Rows.Add(registro)
                    End If
                    StrHora = "0"
                    minutos = 0
                    horas = 0
                End If
                fec_tem = fec_tem.AddDays(1)
            Next
        Next
    End Sub

    Private Sub reporte_marcas()
        Dim fec_temp As Date = fecha_inic
        dt_rep_marcas.Clear()
        Try
            Cursor = Cursors.WaitCursor
            cr.Load("C:\Plan_rep\nomina.xml", "marcas")
            For i = 1 To 16
                cr.Fields("f" & i).Text = Format(fec_temp, "dddd") & Chr(10) & Format(fec_temp, "dd")
                fec_temp = fec_temp.AddDays(1)
            Next
            cr.Fields("periodo").Text = "Del " & fecha_inic & " Al " & fecha_fin
            llena_dt_marcas()
            cr.DataSource.ConnectionString = cs.con
            cr.DataSource.Recordset = dt_rep_marcas
            cr.Render()
            pp.Document = cr
            pp.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub llena_dt_marcas()
        Dim fec_tem As Date = fecha_inic
        Dim dd As DataRow()
        Dim dtr As DataRow
        Dim cont As Integer = 1
        Dim entrada As String
        Dim salida As String
        scr = "SELECT A.CODIGO, A.NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO, COD_DEPART,B.FECHA,B.ENTRADA,B.SALIDA ,C.NOMBRE AS DEPARTAMENTO from TB_EMPLEADO AS A " & _
                       " LEFT JOIN TB_MARCA_FINAL AS B ON A.CODIGO = B.CODIGO AND B.FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "'" & _
                       " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON A.COD_DEPART = C.COD_DEPAR "
        cs.consultas(scr, dtMarcas, msj)
        For I = 0 To dtcodigo_g.Rows.Count - 1
            dd = dtMarcas.Select("CODIGO = " & dtcodigo_g.Rows(I)("codigo"))
            Dim dt_r As DataRow = dt_rep_marcas.NewRow
            dt_r("CODIGO") = dd(0)("CODIGO")
            dt_r("NOMBRE") = dd(0)("NOMBRE") & " " & dd(0)("SEGUNDO_NOMBRE") & " " & dd(0)("APELLIDO") & " " & dd(0)("SEGUNDO_APELLIDO")
            dt_r("DEPARTAMENTO") = dd(0)("DEPARTAMENTO")
            For Each dtr In dd
                If dtr("fecha") IsNot DBNull.Value Then
                    For M = 1 To 16
                        If dtr("fecha") = fec_tem Then
                            If dtr("entrada") = "00:00" Then
                                entrada = "    "
                            Else
                                entrada = dtr("entrada")
                            End If
                            If dtr("salida") = "00:00" Then
                                salida = "    "
                            Else
                                salida = dtr("salida")
                            End If
                            dt_r("d" & cont) = entrada & "-" & salida
                        End If
                        fec_tem = fec_tem.AddDays(1)
                        cont = cont + 1
                    Next
                End If
                cont = 1
                fec_tem = fecha_inic
            Next
            dt_rep_marcas.Rows.Add(dt_r)
            dt_rep_marcas.AcceptChanges()
        Next
        'prueba_()
    End Sub

    Private Sub prueba_()
        AbrirLog()
        For i = 0 To dt_rep_marcas.Rows.Count - 1
            prueba = dt_rep_marcas.Rows(i)("codigo") & "," &
            dt_rep_marcas.Rows(i)("nombre") & "," &
            dt_rep_marcas.Rows(i)("departamento") & "," &
            dt_rep_marcas.Rows(i)("D1") & "," &
            dt_rep_marcas.Rows(i)("D2") & "," &
            dt_rep_marcas.Rows(i)("D3") & "," &
            dt_rep_marcas.Rows(i)("D4") & "," &
            dt_rep_marcas.Rows(i)("D5") & "," &
            dt_rep_marcas.Rows(i)("D6") & "," &
            dt_rep_marcas.Rows(i)("D7") & "," &
            dt_rep_marcas.Rows(i)("D8") & "," &
            dt_rep_marcas.Rows(i)("D9") & "," &
            dt_rep_marcas.Rows(i)("D10") & "," &
            dt_rep_marcas.Rows(i)("D11") & "," &
            dt_rep_marcas.Rows(i)("D12") & "," &
            dt_rep_marcas.Rows(i)("D13") & "," &
            dt_rep_marcas.Rows(i)("D14") & "," &
            dt_rep_marcas.Rows(i)("D15")
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

    Private Sub Cbmes_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cbmes.SelectedIndexChanged

    End Sub
End Class