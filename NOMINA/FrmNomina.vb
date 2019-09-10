Imports System.IO
Imports System.Text

Public Class FrmNomina
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
    'Dim empresa As Integer = 1
    Dim dtMarcas As New DataTable
    Dim dt_codigo As New DataTable
    Dim dt_dias_ord As New DataTable
    Dim dt_sueldos As New DataTable
    Dim log As New StringBuilder
    Dim fec_inic_h As Date
    Dim fec_fin_h As Date
    Dim fec_inic_h2 As Date
    Dim fec_fin_h2 As Date
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue

    Private Sub Frm_Pre_nomina_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
        CbCiclo.SelectedIndex = 0
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
        fec_inic_h2 = CDate(Format(anio_h & "-" & mes_h & "-" & 11))
        fec_fin_h2 = CDate(Format(anio_h & "-" & mes_h & "-" & 25))
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

    Private Sub procesos()
        fechas_Horas()
        scr = "EXECUTE PRE_A_NOMINA @ANIO = " & anio & ",@MES = " & mes & ",@QUINCENA = " & ciclo & ",@EMPRESA = " & empresa '& ", @INICIO = '" & fecha_inic & "', @FINAL ='" & fecha_fin & "'"
        If cs.procedure(scr, msj) Then
        End If
        scr = "execute IGSS_NOM @empresa = " & empresa & ", @ANIO = " & anio & ",@MES = " & mes & " ,@QUINCENA = " & ciclo
        If cs.procedure(scr, msj) Then
        End If
        If ciclo = 1 Then
            scr = "EXECUTE HORAS_NOMINA @EMPRESA = " & empresa & ", @ANIO = " & anio & ",@MES = " & mes & ",@QUINCENA = " & ciclo & " , @INICIO = '" & fec_inic_h & "', @FINAL ='" & fec_fin_h & "'"
            If cs.procedure(scr, msj) Then
            End If
        ElseIf ciclo = 2 Then
            scr = "EXECUTE HORAS_NOMINA @EMPRESA = " & empresa & ", @ANIO = " & anio & ",@MES = " & mes & ",@QUINCENA = " & ciclo & " , @INICIO = '" & fec_inic_h2 & "', @FINAL ='" & fec_fin_h2 & "'"
            If cs.procedure(scr, msj) Then
            End If
            scr = "EXECUTE HORAS_NOMINA_GEN @EMPRESA = " & empresa & ", @ANIO = " & anio & ",@MES = " & mes & ",@QUINCENA = " & ciclo & " , @INICIO = '" & fec_inic_h & "', @FINAL ='" & fec_fin_h2 & "'"
            If cs.procedure(scr, msj) Then
            End If
        End If
        scr = "EXECUTE ANTICIPO_NOMINA @ANIO = " & anio & ", @MES = " & mes & ", @QUINCENA = " & ciclo & ", @EMPRESA =" & empresa
        If cs.procedure(scr, msj) Then
        End If
        scr = "EXECUTE ISR @ANIO = " & anio & ", @MES = " & mes & ", @QUINCENA = " & ciclo & ", @EMPRESA =" & empresa
        If cs.procedure(scr, msj) Then
        End If
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        Dim datos As Integer
        fechas()
        scr = "SELECT COUNT(1) FROM TB_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo
        cs.csescalar(datos, scr, msj)
        If datos > 0 Then
            REPORTE()
        Else
            scr = "SELECT * FROM TB_CICLO_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & " AND COD_EMPRESA = " & empresa
            If cs.consultas(scr, dt, msj) Then
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0)("ESTADO") = "A" Then
                        procesos()
                        REPORTE()
                    Else
                        mensajes.Text = "CICLO CERRADO !!"
                    End If
                Else
                    mensajes.Text = "CICLO NO EXISTE!!"
                End If
            End If

        End If

    End Sub

    Private Sub REPORTE()
        Dim fec_temp As Date = fecha_inic
        Try
            Cursor = Cursors.WaitCursor
            cr.Load("C:\Plan_rep\nomina.flxr", "nomina")
            cr.DataSource.ConnectionString = cs.con

            Dim per As String = "Del " & fecha_inic & " Al " & fecha_fin
            cr.DataSource.RecordSource = " SELECT B.NOMBRE,B.SEGUNDO_NOMBRE, B.APELLIDO,B.SEGUNDO_APELLIDO,C.NOMBRE AS NOMBRE_DEPAR, A.*, '" & per & "' as periodo FROM TB_NOMINA AS A" &
                                         " LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND A.COD_EMPRESA = B.CODIGO_EMPRESA" &
                                         " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON A.DEPART = C.COD_DEPAR " &
                                         " WHERE anio = " & anio & " And mes = " & mes & " And QUINCENA = " & ciclo

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

    Private Sub mensajes_Click(sender As System.Object, e As System.EventArgs) Handles mensajes.Click

    End Sub
End Class