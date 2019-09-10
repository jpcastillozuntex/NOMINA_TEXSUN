Imports System.Globalization
Imports System.Text
Imports System.IO
Public Class FrmCreacionCiclos
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim dt As New DataTable
    Dim empresa = FrmInicio.empresa
    Dim dia_cierre = FrmInicio.DIA_CIERRE
    Dim cierre = FrmInicio.CIERRE
    Dim mes As Integer
    Dim quincena As String
    Dim dia_1 As Integer
    Dim anio As Integer
    Dim fec_ini As Date
    Dim fec_fin As Date
    Dim dt_N_ciclo As New DataTable
    Dim log As New StringBuilder
    Dim d As String = "yyyy-MM-dd"
    Dim dt_ciclo As New DataTable
    Dim cont As Integer
    Dim ciclo As Integer


    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        dt_N_ciclo.Clear()
        anio = Format(DatAnio.Value, "yyyy")
        scr = "SELECT * FROM TB_CICLO_NOMINA WHERE ANIO = " & anio
        If cs.consultas(scr, dt, msj) = True Then
            llena_fg()
        Else
            If cierre = 8 Then
                fec_ini = CDate(anio & "-01-01")
                quincena = 1
                For i = 0 To 7
                    dia_1 = fec_ini.DayOfWeek
                    If dia_1 = dia_cierre Then
                        Exit For
                    End If
                    fec_ini = fec_ini.AddDays(1)
                Next
                For i = 0 To 53
                    Dim dtr As DataRow = dt_N_ciclo.NewRow
                    anio = Format(fec_ini, "yyyy")
                    mes = Format(fec_ini, "MM")
                    dia_1 = Format(fec_ini, "dd")
                    fec_ini = CDate(anio & "-" & mes & "-" & dia_1)
                    fec_fin = fec_ini.AddDays(7)
                    dtr("ANIO") = anio
                    dtr("MES") = mes
                    dtr("QUINCENA") = quincena
                    dtr("ESTADO") = "P"
                    dtr("COD_EMPRESA") = empresa
                    dtr("FECHA") = Nothing
                    dtr("INICIO") = Format(fec_ini.AddDays(1), d)
                    dtr("FIN") = Format(fec_fin, d)
                    dt_N_ciclo.Rows.Add(dtr)
                    dt_N_ciclo.AcceptChanges()
                    fec_ini = fec_ini.AddDays(7)
                    quincena = quincena + 1
                    If Format(fec_ini, "yyyy") > anio Then
                        Exit For
                    End If
                Next
            ElseIf cierre = 15 Then
                fec_ini = CDate(anio & "-01-01")
                scr = "SELECT * FROM TB_CICLO_NOMINA WHERE QUINCENA IN (SELECT MAX(QUINCENA) FROM TB_CICLO_NOMINA_1 WHERE ANIO = " & anio & " ) AND ANIO = 2015"
                If cs.consultas(scr, dt_ciclo, msj) Then
                    fec_ini = CDate(dt_ciclo.Rows(0)("fin")).AddDays(1)
                Else
                    For i = 0 To 7
                        dia_1 = fec_ini.DayOfWeek
                        If dia_1 = dia_cierre Then
                            Exit For
                        End If
                        fec_ini = fec_ini.AddDays(1)
                    Next
                End If
                quincena = 1
                For i = 0 To 28
                    Dim dtr As DataRow = dt_N_ciclo.NewRow
                    anio = Format(fec_ini, "yyyy")
                    mes = Format(fec_ini, "MM")
                    dia_1 = Format(fec_ini, "dd")
                    fec_ini = CDate(anio & "-" & mes & "-" & dia_1)
                    fec_fin = fec_ini.AddDays(14)
                    dtr("ANIO") = anio
                    dtr("MES") = mes
                    dtr("QUINCENA") = quincena
                    dtr("ESTADO") = "P"
                    dtr("COD_EMPRESA") = empresa
                    dtr("FECHA") = Nothing
                    dtr("INICIO") = Format(fec_ini.AddDays(1), d)
                    dtr("FIN") = Format(fec_fin, d)
                    dt_N_ciclo.Rows.Add(dtr)
                    dt_N_ciclo.AcceptChanges()
                    fec_ini = fec_ini.AddDays(14)
                    quincena = quincena + 1
                    If Format(fec_ini, "yyyy") > anio Then
                        Exit For
                    End If
                Next
            ElseIf cierre = 152 Then
                Dim cantidad As Integer
                scr = "SELECT COUNT(1) FROM TB_CICLO_NOMINA WHERE ANIO = " & anio
                If cantidad > 0 Then
                Else
                    cs.csescalar(cantidad, scr, msj)
                    cont = 1
                    anio = Format(DatAnio.Value, "yyyy")
                    mes = 1
                    ciclo = 1
                    For i = 0 To 23
                        cont = cont + 1
                        Dim dtr As DataRow = dt_N_ciclo.NewRow
                        dtr("ANIO") = anio
                        dtr("MES") = mes
                        dtr("QUINCENA") = ciclo
                        dtr("ESTADO") = "P"
                        dtr("COD_EMPRESA") = empresa
                        dtr("FECHA") = Nothing
                        If ciclo = 2 Then
                            dtr("INICIO") = CDate(anio & "-" & mes & "- " & 16)
                            dtr("FIN") = CDate(anio & "-" & mes & "-" & "1").AddMonths(1).AddDays(-1)
                        ElseIf ciclo = 1 Then
                            dtr("INICIO") = CDate(anio & "-" & mes & "- " & 1)
                            dtr("FIN") = CDate(anio & "-" & mes & "- " & 15)
                        End If
                        dt_N_ciclo.Rows.Add(dtr)
                        dt_N_ciclo.AcceptChanges()
                        If ciclo = 1 Then
                            ciclo = 2
                        ElseIf ciclo = 2 Then
                            ciclo = 1
                        End If
                        If ciclo = 1 Then
                            mes = mes + 1
                        End If
                        If mes > 12 Then
                            mes = 1
                        End If

                        If mes = 1 And ciclo = 1 Then
                            anio = anio + 1
                        End If
                    Next
                End If
                If cs.guarda_ciclonomina(dt_N_ciclo, msj) Then
                    MsgBox("Datos guardados!!")
                    llena_fg()
                End If
            Else
                MsgBox("DEBE DE LLENAR EL FORMULARIO DE PARAMETROS")
            End If
        End If


    End Sub

    Private Sub llena_fg()
        fg.Rows.Count = dt.Rows.Count + 1
        For I = 0 To dt.Rows.Count - 1
            fg(I + 1, 1) = dt.Rows(I)("ANIO")
            fg(I + 1, 2) = dt.Rows(I)("MES")
            fg(I + 1, 3) = dt.Rows(I)("QUINCENA")
            fg(I + 1, 4) = dt.Rows(I)("ESTADO")
            fg(I + 1, 5) = dt.Rows(I)("COD_EMPRESA")
            fg(I + 1, 6) = dt.Rows(I)("FECHA")
            fg(I + 1, 7) = dt.Rows(I)("INICIO")
            fg(I + 1, 8) = dt.Rows(I)("FIN")
        Next
    End Sub

    Private Sub creatabla()
        dt_N_ciclo.Columns.Add("ANIO")
        dt_N_ciclo.Columns.Add("MES")
        dt_N_ciclo.Columns.Add("QUINCENA")
        dt_N_ciclo.Columns.Add("ESTADO")
        dt_N_ciclo.Columns.Add("COD_EMPRESA")
        dt_N_ciclo.Columns.Add("FECHA")
        dt_N_ciclo.Columns.Add("INICIO")
        dt_N_ciclo.Columns.Add("FIN")

    End Sub

    Private Sub limpia()
        For i = 1 To fg.Rows.Count - 1
            fg(i, 1) = Nothing
            fg(i, 2) = Nothing
            fg(i, 3) = Nothing
            fg(i, 4) = Nothing
            fg(i, 5) = Nothing
            fg(i, 6) = Nothing
            fg(i, 7) = Nothing
            fg(i, 8) = Nothing
        Next
    End Sub

    Private Sub FrmCreacionCiclos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fg.Rows(0).Height = 26
        fg.Rows.Count = 1
        creatabla()
        If cierre = 15 Then
            'DatFecha.Visible = True
        ElseIf dia_cierre = 152 Then
            'DatFecha.Visible = False
        ElseIf dia_cierre = 15 Then
            'DatFecha.Visible = False
        End If
    End Sub

    Private Sub prueba()
        Dim ass As String
        AbrirLog()
        For i = 0 To dt_N_ciclo.Rows.Count - 1
            ass = dt_N_ciclo.Rows(i)("ANIO") & "," & dt_N_ciclo.Rows(i)("MES") & "," & dt_N_ciclo.Rows(i)("QUINCENA") & "," & dt_N_ciclo.Rows(i)("ESTADO") & "," & dt_N_ciclo.Rows(i)("FECHA") & "," & dt_N_ciclo.Rows(i)("INICIO") & "," & dt_N_ciclo.Rows(i)("FIN")
            GrabarLog(ass)
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
            If File.Exists("c:\Plan_rep\Log_table.log") Then
                My.Computer.FileSystem.DeleteFile("c:\Plan_rep\Log_table.log")
            End If
            Dim Escritor As TextWriter = New StreamWriter("c:\Plan_rep\Log_table.Log", True)
            Escritor.WriteLine(log.ToString)
            Escritor.Close()
        Catch ex As Exception
            EventLog.WriteEntry("MonitorServicio", "Error: " & ex.Message.ToString)
        End Try
    End Sub
End Class