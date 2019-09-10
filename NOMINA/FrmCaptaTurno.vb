Imports System.Globalization
Imports System.Text
Imports System.IO

Public Class FrmCaptaTurno
    Dim scr As String
    Dim msj As String
    Dim cs As New ClsConsultas
    'Dim dt As New DataTable
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim fecha_inic As Date
    Dim fecha_fin As Date
    'Dim fecha_tem As Date
    Dim mes2 As Integer
    Dim dias As Integer
    Dim dtTurnos As New DataTable
    Dim fecha_inic_temp As Date
    Dim dtcodigos As New DataTable
    Dim dt_ciclo As New DataTable
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    'Dim empresa As Integer = 1
    Dim dtf As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim CarpetaLog As String = "\Log_marcas\"
    Dim log As New StringBuilder
    Dim RutaDir As String = "c:"
    Dim ass As String
    Dim fec_inic_guarda As Date
    Dim fec_inic_temp As Date
    Dim fec_cons As Date
    Dim dtMes As New DataTable


    Private Sub FrmCaptaTurno_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l - 20, a - 40)
        Me.Top = a - (a - 40 / 2)
        Me.Left = l - (l - 20 / 2)
        CbCiclo.SelectedIndex = 0
        fg.Rows(0).Height = 35
        fg.Rows.Count = 1
        BtGuardar.Visible = False
        BtRegresar.Visible = False
        crea_dt()
        Combo_box_Mes()
        Cbmes.SelectedIndex = Format(Today, "MM") - 1
    End Sub

    Private Sub Combo_box_Mes()
        scr = "SELECT MES, NUMERO FROM MES"
        cs.consultas(scr, dtMes, msj)
        Cbmes.DataSource = dtMes
        Cbmes.DisplayMember = "MES"
        Cbmes.ValueMember = "NUMERO"
    End Sub

    Private Sub fechas()
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
        fecha_inic_temp = fecha_inic
        fec_inic_guarda = fecha_inic
        dias = (fecha_fin - fecha_inic).TotalDays
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        fechas()
        fec_cons = fecha_inic
        ingresa_turno_mat()
        consultas()
        scr = "SELECT * FROM TB_CICLO_NOMINA WHERE MES = " & mes & " AND ANIO = " & anio & " AND QUINCENA = " & CbCiclo.Text
        cs.consultas(scr, dt_ciclo, msj)

        For i = 0 To dias
            fg(0, i + 3) = fec_cons.ToString("dddd", New CultureInfo("es-ES")) & Chr(10) & Format(fec_cons, "dd")
            fec_cons = fec_cons.AddDays(1)
        Next
        BtGuardar.Visible = True
        BtRegresar.Visible = True
        DatAnio.Enabled = False
        Cbmes.Enabled = False
        CbCiclo.Enabled = False
        Try
            If dt_ciclo.Rows(0)("ESTADO") = "C" Then
                fg.AllowEditing = False
                BtGuardar.Visible = False
            Else
                fg.AllowEditing = True
                BtGuardar.Visible = True
            End If
        Catch
            fg.AllowEditing = True
            BtGuardar.Visible = True
        End Try
    End Sub

    Private Sub ingresa_turno_mat()
        fec_inic_temp = fecha_inic
        scr = " SELECT DISTINCT(CODIGO),nombre,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO = 'A' AND COD_DEPART = '15' AND CODIGO_EMPRESA = " & empresa
        cs.consultas(scr, dtcodigos, msj)
        For i = 0 To dtcodigos.Rows.Count - 1
            For j = 0 To dias
                Dim dtr As DataRow = dtf.NewRow
                dtr("codigo") = dtcodigos.Rows(i)("codigo")
                dtr("fecha") = Format(fec_inic_temp, "yyyy-MM-dd")
                dtr("turno") = "MAT"
                dtf.Rows.Add(dtr)
                dtf.AcceptChanges()
                fec_inic_temp = fec_inic_temp.AddDays(1)
            Next
            fec_inic_temp = fecha_inic
        Next
        If cs.ingresa_turno(dtf, msj) Then
            ' MsgBox("DATOS GUARDADOS")
        Else
            'MsgBox(msj)
        End If
        'prueba()
    End Sub

    Private Sub consultas()

        scr = " SELECT A.CODIGO,A.NOMBRE,A.SEGUNDO_NOMBRE,A.APELLIDO,A.SEGUNDO_APELLIDO,B.FECHA,B.TURNO from TB_EMPLEADO AS A " & _
                " LEFT JOIN TB_TURNO_SER AS B ON A.CODIGO = B.CODIGO " & _
                " where COD_DEPART = '15' and ESTADO_EMPLEADO = 'A'" & _
                " and FECHA between '" & fecha_inic & "' and '" & fecha_fin & "' AND CODIGO_EMPRESA =" & empresa
        cs.consultas(scr, dtTurnos, msj)
        fg.Rows.Count = dtcodigos.Rows.Count + 1
        For i = 0 To dtcodigos.Rows.Count - 1
            fg(i + 1, 1) = dtcodigos.Rows(i)("codigo")
            fg(i + 1, 2) = dtcodigos.Rows(i)("nombre") & " " & dtcodigos.Rows(i)("segundo_nombre") & " " & dtcodigos.Rows(i)("apellido") & " " & dtcodigos.Rows(i)("segundo_apellido")
            For j = 0 To dias
                Dim dd As DataRow()
                Dim ddr As DataRow
                dd = dtTurnos.Select("fecha = '" & fecha_inic_temp & "' AND CODIGO = '" & dtcodigos.Rows(i)("CODIGO") & "'")
                For Each ddr In dd
                    fg(i + 1, j + 3) = ddr("turno")
                Next
                fecha_inic_temp = fecha_inic_temp.AddDays(1)
            Next
            fecha_inic_temp = fecha_inic
        Next
    End Sub

    Private Sub BtRegresar_Click(sender As System.Object, e As System.EventArgs) Handles BtRegresar.Click
        BtGuardar.Visible = False
        BtRegresar.Visible = False
        DatAnio.Enabled = True
        Cbmes.Enabled = True
        CbCiclo.Enabled = True
        limpia()
    End Sub

    Private Sub limpia()
        dtf.Clear()
        dtTurnos.Clear()
        dtcodigos.Clear()
        dt_ciclo.Clear()
        For i = 0 To 18
            For j = 0 To fg.Rows.Count - 1
                fg(j, i) = Nothing
            Next
        Next
        fg(0, 1) = "CODIGO"
        fg(0, 2) = "NOMBRE"
        fg.Rows.Count = 1
    End Sub

    Private Sub crea_dt()
        dtf.Columns.Add("codigo")
        dtf.Columns.Add("fecha")
        dtf.Columns.Add("turno")
        dtf.AcceptChanges()
    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        dtf.Clear()
        For i = 1 To fg.Rows.Count - 1
            For j = 3 To 18
                Dim dtr As DataRow = dtf.NewRow
                dtr("codigo") = fg(i, 1)
                dtr("fecha") = Format(fec_inic_guarda, "yyyy-MM-dd")
                dtr("turno") = fg(i, j)
                dtf.Rows.Add(dtr)
                dtf.AcceptChanges()
                fec_inic_guarda = fec_inic_guarda.AddDays(1)
            Next
            fec_inic_guarda = fecha_inic
        Next
        If cs.actualiza_turno(dtf, msj) Then
            MsgBox("DATOS GUARDADOS")
        Else
            MsgBox(msj)
        End If
        'prueba()
    End Sub

    '  Private Sub prueba()
    '     AbrirLog()
    '     For i = 0 To dtf.Rows.Count - 1
    '         If dtf.Rows(i)("codigo") Is Nothing Or dtf.Rows(i)("fecha") Is Nothing Or dtf.Rows(i)("turno") Is Nothing Then
    '         Else
    '             ass = dtf.Rows(i)("codigo") & "," & dtf.Rows(i)("fecha") & "," & dtf.Rows(i)("turno")
    '             GrabarLog(ass)
    '         End If
    '     Next
    '    CerrarLog()
    '  End Sub


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
            Dim Escritor As TextWriter = New StreamWriter(RutaDir & CarpetaLog & "c:\Plan_rep\Log_table.Log", True)
            Escritor.WriteLine(log.ToString)
            Escritor.Close()
        Catch ex As Exception
            EventLog.WriteEntry("MonitorServicio", "Error: " & ex.Message.ToString)
        End Try
    End Sub

    Private Sub fg_Click(sender As System.Object, e As System.EventArgs) Handles fg.RowValidated
        Try
            For i = 1 To fg.Rows.Count - 1
                For j = 3 To 18
                    If fg(i, j) <> "MAT" Then
                        fg.SetCellStyle(i, j, "cambia")
                    End If
                Next
            Next
        Catch
        End Try
    End Sub

End Class
