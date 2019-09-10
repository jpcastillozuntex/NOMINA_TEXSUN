Imports System.IO
Imports System.Text
Imports C1.Win.FlexReport
Public Class FrmCierreNomina
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim dtmes As New DataTable
    Dim dt_estado As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim fecha_inic As Date
    Dim fecha_fin As Date
    Dim scr2 As String
    Dim scr3 As String
    Dim scr4 As String
    Dim anio_a As Integer
    Dim mes2 As Integer
    Dim mes_a As Integer
    Dim ciclo_a As Integer
    'Dim empresa As Integer = 1
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    Dim dt_sin_centro_b As New DataTable
    
    Private Sub Frm_Pre_nomina_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
        CbCiclo.SelectedIndex = 0
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
            mes2 = mes
            anio2 = anio
        End If
        If ciclo = "1" Then
            fecha_inic = CDate(Format(anio & "-" & mes & "-" & 1))
            fecha_fin = CDate(Format(anio & "-" & mes & "-" & 15))
        ElseIf ciclo = "2" Then
            fecha_inic = CDate(Format(anio & "-" & mes & "-" & 16))
            fec_temp = CDate(Format(anio2 & "-" & mes2 + 1 & "-" & 1))
            fecha_fin = fec_temp.AddDays(-1)
        End If
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtCierra.Click
        fechas()
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbCiclo.Text
        Dim datos As Integer
        scr = "SELECT COUNT(1) FROM TB_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & "AND COD_EMPRESA = " & empresa
        cs.csescalar(datos, scr, msj)
        cambio_ciclo()
        If datos > 0 Then
            scr = "SELECT * FROM TB_CICLO_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & "AND COD_EMPRESA = " & empresa
            cs.consultas(scr, dt_estado, msj)
            If dt_estado.Rows(0)("estado") = "C" Then
                REPORTE()
            Else
                scr = "UPDATE TB_CICLO_NOMINA SET FECHA = '" & Format(Today, "yyyy-MM-dd") & "', ESTADO = 'C' WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & " AND COD_EMPRESA = " & empresa
                scr2 = "UPDATE TB_NOMINA SET FECHA = '" & Format(Today, "yyyy-MM-dd") & "' WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & " AND COD_EMPRESA = " & empresa
                scr3 = "UPDATE TB_DET_ANTICIPO SET ESTADO = 'A' WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & " AND ESTADO ='P'"
                scr4 = "UPDATE TB_CICLO_NOMINA SET ESTADO = 'A' WHERE ANIO = " & anio_a & " AND MES = " & mes_a & " AND QUINCENA = " & ciclo_a & " AND COD_EMPRESA = " & empresa
                If cs.cierra_nomina(scr, scr2, scr3, scr4, msj) Then
                    MsgBox("NOMINA CERRADA!!")
                    REPORTE()
                Else
                    mensajes.Text = msj
                End If
            End If
        Else
            mensajes.Text = "NO SE PUEDE CERRAR ESTE CICLO.. SIN DATOS!!!!"
        End If
        scr = "select * from TB_EMPLEADO where centro = ''"
        Dim cos As String = ""
        If cs.consultas(scr, dt_sin_centro_b, msj) Then
            For i = 0 To dt_sin_centro_b.Rows.Count - 1
                cos = cos & "," & dt_sin_centro_b.Rows(i)("codigo")
            Next
            cs.enviar_correo(cos)
        End If
    End Sub

    Private Sub cambio_ciclo()
        mes_a = mes
        If ciclo = 1 Then
            ciclo_a = 2
        ElseIf ciclo = 2 Then
            ciclo_a = 1
        End If
        If ciclo_a = 1 Then
            mes_a = mes + 1
        ElseIf ciclo = 1 And mes = 13 Then
            mes_a = 1
        End If
        If mes = 1 And ciclo = 1 Then
            anio_a = anio + 1
        Else
            anio_a = anio
        End If
    End Sub

    Private Sub REPORTE()
        Dim fec_temp As Date = fecha_inic
        Dim dt_emp_paga As New DataTable
        Dim totales As String = ""
        Dim nombres As String = ""
        scr = "SELECT C.NOMBRE, SUM(ORDINARIO+VACACIONES+ASUETO+HORAS+isnull(HORAS_N,0)+A.BONIFICACION+BON_PROD)-SUM(ANTICIPO+IGSS+OTROS_DESC+ISR) AS TOTAL FROM TB_NOMINA AS A" &
                " LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO " &
                " LEFT JOIN TB_EMP_PAGA AS C ON B.EMP_PAGA = C.CODIGO" &
                " WHERE anio = " & anio & " And mes = " & mes & " And QUINCENA = " & ciclo &
                " GROUP BY C.NOMBRE"
        If cs.consultas(scr, dt_emp_paga, msj) Then
            For i = 0 To dt_emp_paga.Rows.Count - 1
                totales = totales & dt_emp_paga.Rows(i)("total") & Chr(10)
                nombres = nombres & dt_emp_paga.Rows(i)("NOMBRE") & Chr(10)
            Next
        Else
            MsgBox(msj)
        End If
        Try
            Cursor = Cursors.WaitCursor
            cr.Load("C:\Plan_rep\nomina.flxr", "cierre_nomina")
            cr.DataSource.ConnectionString = cs.con
            cr.DataSource.RecordSource = "SELECT count(1)as numero,C.NOMBRE AS NOMBRE_DEPAR,B.CODIGO_EMPRESA,SUM(ORDINARIO) AS ORDINARIO,SUM(VACACIONES)AS VACACIONES,SUM(ASUETO)AS ASUETO," &
                            " SUM(HORAS_NOC)AS HORAS_NOC,SUM(HORAS_MAT)AS HORAS_MAT,SUM(HORAS)AS HORAS,SUM(isnull(HORAS_N,0))AS HORAS_N,SUM(A.BONIFICACION+BON_PROD)AS BONIFICACION,SUM(ANTICIPO)AS ANTICIPO,SUM(IGSS)AS IGSS,SUM(OTROS_DESC)AS OTROS_DESC,SUM(ISR) AS ISR FROM TB_NOMINA AS A " &
                            " LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND A.COD_EMPRESA = B.CODIGO_EMPRESA " &
                            " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON A.DEPART = C.COD_DEPAR  WHERE anio = " & anio & " And mes = " & mes & " And QUINCENA = " & ciclo & " AND COD_EMPRESA =  " & empresa &
                            " GROUP BY C.NOMBRE,B.CODIGO_EMPRESA "
            Dim periodo As TextField = DirectCast(cr.Fields("periodo"), TextField)
            periodo.Text = "Del " & fecha_inic & " Al " & fecha_fin
            Dim totles As TextField = DirectCast(cr.Fields("totales_emp"), TextField)
            totles.Text = totales
            Dim nombs As TextField = DirectCast(cr.Fields("nombres"), TextField)
            nombs.Text = nombres
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
        ''''''''''''''''''''''''==================
        Cbmes.SelectedIndex = mes - 1
    End Sub

End Class