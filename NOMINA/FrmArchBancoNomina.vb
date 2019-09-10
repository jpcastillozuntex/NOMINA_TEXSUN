Imports System.IO
Imports System.Text
Public Class FrmArchBancoNomina
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim cs As New ClsConsultas
    Dim empresa = FrmInicio.CbEmpresa.SelectedValue
    Dim msj As String
    Dim CarpetaLog As String = "\Plan_rep\"
    Dim RutaDir As String = "c:"
    Dim Log As StringBuilder
    Dim script As String
    Dim dt As New DataTable
    Dim str As String
    Dim dttotales As New DataTable
    Dim dt_cheques As New DataTable
    Dim dtmes As New DataTable
    Dim dtc As New DataTable
    Dim scr As String
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim datos As Integer

    Private Sub FrmIplanilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CbCiclo.SelectedIndex = 0
        Combo_box_Mes()
        fg.Rows(0).Height = 26
        Me.Top = a / 2 - (686 / 2)
        Me.Left = l / 2 - (951 / 2)
        fg.Rows.Count = 2
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

    Private Sub limpia()
        For i = 1 To fg.Rows.Count - 1
            fg(i, 1) = ""
            fg(i, 2) = ""
            fg(i, 3) = ""
            fg(i, 4) = Nothing
            fg(i, 5) = ""
            fg(i, 6) = ""
        Next
    End Sub


    Private Sub BtDeposito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtConsultar.Click
        Dim total As Decimal = 0
        fg.Rows.Count = 1
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbCiclo.Text
        Try
            scr = "SELECT COUNT(1) FROM TB_NOMINA WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo
            cs.csescalar(datos, scr, msj)
            If datos > 0 Then
                script = " SELECT b.codigo,a.NOMBRE,a.segundo_nombre, a.APELLIDO, a.segundo_apellido,cod_depart, a.NUM_CUENTA,ORDINARIO,VACACIONES,ASUETO,ISNULL (HORAS,0)AS HORAS,ISNULL (HORAS_n,0) AS HORAS_N,B.BON_PROD,b.BONIFICACION,ANTICIPO,IGSS,OTROS_DESC,ISR ,A.NIT  FROM tb_empleado as a, " &
                        " TB_NOMINA as b where a.codigo = b.codigo and ANIO = " & anio & " and mes = " & mes & " and QUINCENA = " & ciclo & " and CODIGO_EMPRESA = " & empresa & " and A.CODIGO_EMPRESA= B.COD_EMPRESA and tipo_pago = 'D' "
                If cs.consultas(script, dt, msj) = True Then
                    AbrirLog()
                    fg.Rows.Count = dt.Rows.Count + 1

                    For i = 0 To dt.Rows.Count - 1
                        total = 0
                        If dt.Rows(i)("cod_depart") = "40" Then
                            total = dt.Rows(i)("ORDINARIO") + dt.Rows(i)("VACACIONES") + dt.Rows(i)("ASUETO") + dt.Rows(i)("HORAS") + dt.Rows(i)("HORAS_n") + dt.Rows(i)("BONIFICACION") - dt.Rows(i)("ANTICIPO") - dt.Rows(i)("IGSS") - dt.Rows(i)("OTROS_DESC") - dt.Rows(i)("ISR")
                            str = dt.Rows(i)("codigo") & ", " & dt.Rows(i)("num_cuenta") & ",  " & dt.Rows(i)("nombre") & " " & dt.Rows(i)("apellido") & " " & dt.Rows(i)("segundo_apellido") & ", " & Chr(9) & Chr(9) & total & "," & Chr(9) & Chr(9) & "pago de Nomina  " & anio & "-" & mes & "-" & ciclo
                            fg(i + 1, 1) = dt.Rows(i)("codigo")
                            fg(i + 1, 2) = dt.Rows(i)("num_cuenta")
                            fg(i + 1, 3) = dt.Rows(i)("nombre") & " " & dt.Rows(i)("segundo_nombre") & " " & dt.Rows(i)("apellido") & " " & dt.Rows(i)("segundo_apellido")
                            fg(i + 1, 4) = total
                            fg(i + 1, 5) = "PAGO NOMINA CICLO " & anio & mes & ciclo
                            fg(i + 1, 6) = "D"
                            GrabarLog(str)
                        Else

                            total = 0
                            total = dt.Rows(i)("ORDINARIO") + dt.Rows(i)("VACACIONES") + dt.Rows(i)("ASUETO") + dt.Rows(i)("HORAS") + dt.Rows(i)("HORAS_n") + dt.Rows(i)("BON_PROD") + dt.Rows(i)("bonificacion") - dt.Rows(i)("ANTICIPO") - dt.Rows(i)("IGSS") - dt.Rows(i)("OTROS_DESC") - dt.Rows(i)("ISR")
                            str = dt.Rows(i)("codigo") & ", " & dt.Rows(i)("num_cuenta") & ",  " & dt.Rows(i)("nombre") & " " & dt.Rows(i)("apellido") & " " & dt.Rows(i)("segundo_apellido") & ", " & Chr(9) & Chr(9) & total & "," & Chr(9) & Chr(9) & "pago de Nomina  " & anio & "-" & mes & "-" & ciclo
                            fg(i + 1, 1) = dt.Rows(i)("codigo")
                            fg(i + 1, 2) = dt.Rows(i)("num_cuenta")
                            fg(i + 1, 3) = dt.Rows(i)("nombre") & " " & dt.Rows(i)("segundo_nombre") & " " & dt.Rows(i)("apellido") & " " & dt.Rows(i)("segundo_apellido")
                            fg(i + 1, 4) = total
                            fg(i + 1, 5) = "PAGO NOMINA CICLO " & anio & mes & ciclo
                            fg(i + 1, 6) = "D"
                            GrabarLog(str)
                        End If
                    Next
                    CerrarLog("DEPOSITO")
                End If
                cheque()
                totales()
            Else
                Txtmensjaes.Text = "Este ciclo aun no tiene datos!!"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub totales()
        scr = "SELECT TIPO_PAGO,SUM(ORDINARIO+VACACIONES+ASUETO+ISNULL (HORAS,0)+ISNULL (HORAS_N,0)+B.BON_PROD+b.BONIFICACION-ANTICIPO-IGSS-OTROS_DESC-ISR) AS TOTAL  FROM TB_EMPLEADO AS A, TB_NOMINA AS B " &
                " WHERE A.CODIGO = B.CODIGO AND ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & " AND CODIGO_EMPRESA = " & empresa & " AND A.CODIGO_EMPRESA= B.COD_EMPRESA AND TIPO_PAGO IN ('C','D')  " &
                " GROUP BY TIPO_PAGO "
        If cs.consultas(scr, dttotales, msj) Then
            If dttotales.Rows(0)("tipo_pago") = "C" Then
                Lbcheque.Text = dttotales.Rows(0)("total")
                Lbdeposito.Text = dttotales.Rows(1)("total")
            Else
                Lbcheque.Text = dttotales.Rows(1)("total")
                Lbdeposito.Text = dttotales.Rows(0)("total")
            End If
        End If
    End Sub

    Private Sub cheque()
        Dim total As Decimal = 0
        Dim fila As Integer
        Try
            script = " SELECT b.codigo,a.dpi,a.NOMBRE,a.segundo_nombre, a.APELLIDO, a.segundo_apellido,a.cod_depart, a.NUM_CUENTA,ORDINARIO,VACACIONES,ASUETO,ISNULL (HORAS,0)AS HORAS,ISNULL (HORAS_N,0) AS HORAS_N,b.BONIFICACION,b.bon_prod,ANTICIPO,IGSS,OTROS_DESC,ISR ,A.NIT  FROM tb_empleado as a, " &
                    " TB_NOMINA as b where a.codigo = b.codigo and ANIO = " & anio & " and mes = " & mes & " and QUINCENA = " & ciclo & " and CODIGO_EMPRESA = 1 and A.CODIGO_EMPRESA= B.COD_EMPRESA and tipo_pago = 'C' "
            If cs.consultas(script, dtc, msj) = True Then
                AbrirLog()
                fila = dt.Rows.Count + 1
                fg.Rows.Count = dtc.Rows.Count + 1 + dt.Rows.Count + 2
                For i = 0 To dtc.Rows.Count - 1
                    total = 0
                    If dtc.Rows(i)("cod_depart") = "40" Then
                        total = dtc.Rows(i)("ORDINARIO") + dtc.Rows(i)("VACACIONES") + dtc.Rows(i)("ASUETO") + dtc.Rows(i)("HORAS") + dtc.Rows(i)("HORAS_n") + dtc.Rows(i)("bonificacion") - dtc.Rows(i)("ANTICIPO") - dtc.Rows(i)("IGSS") - dtc.Rows(i)("OTROS_DESC") - dtc.Rows(i)("ISR")
                        str = dtc.Rows(i)("codigo") & ", " & dtc.Rows(i)("num_cuenta") & ",  " & dtc.Rows(i)("nombre") & " " & dtc.Rows(i)("apellido") & " " & dtc.Rows(i)("segundo_apellido") & ", " & Chr(9) & Chr(9) & total & "," & Chr(9) & Chr(9) & "pago de Nomina  " & anio & "-" & mes & "-" & ciclo
                        fg(i + 1 + fila, 1) = dtc.Rows(i)("codigo")
                        fg(i + 1 + fila, 2) = dtc.Rows(i)("num_cuenta")
                        fg(i + 1 + fila, 3) = dtc.Rows(i)("nombre") & " " & dtc.Rows(i)("segundo_nombre") & " " & dtc.Rows(i)("apellido") & " " & dtc.Rows(i)("segundo_apellido")
                        fg(i + 1 + fila, 4) = total
                        fg(i + 1 + fila, 5) = "PAGO NOMINA CICLO " & anio & mes & ciclo
                        fg(i + 1 + fila, 6) = "C"
                        GrabarLog(str)
                    Else
                        total = 0
                        total = dtc.Rows(i)("ORDINARIO") + dtc.Rows(i)("VACACIONES") + dtc.Rows(i)("ASUETO") + dtc.Rows(i)("HORAS") + dtc.Rows(i)("HORAS_n") + dtc.Rows(i)("BON_PROD") + dtc.Rows(i)("bonificacion") - dtc.Rows(i)("ANTICIPO") - dtc.Rows(i)("IGSS") - dtc.Rows(i)("OTROS_DESC") - dtc.Rows(i)("ISR")
                        str = dtc.Rows(i)("codigo") & ", " & dtc.Rows(i)("num_cuenta") & ", " & dtc.Rows(i)("nombre") & " " & dtc.Rows(i)("apellido") & ",  " & total & "," & dtc.Rows(i)("dpi") & " pago de Nomina " & anio & "-" & mes & "-" & ciclo
                        fg(i + 1 + fila, 1) = dtc.Rows(i)("codigo")
                        fg(i + 1 + fila, 2) = dtc.Rows(i)("num_cuenta")
                        fg(i + 1 + fila, 3) = dtc.Rows(i)("nombre") & " " & dtc.Rows(i)("segundo_nombre") & " " & dtc.Rows(i)("apellido") & " " & dtc.Rows(i)("segundo_apellido")
                        fg(i + 1 + fila, 4) = total
                        fg(i + 1 + fila, 5) = "PAGO NOMINA CICLO " & anio & mes & ciclo
                        fg(i + 1 + fila, 6) = "C"
                        GrabarLog(str)
                    End If
                Next
                CerrarLog("CHEQUE")
            End If
            Txtmensjaes.Text = "se crearon los archivos en: C:\Plan_rep"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GrabarLog(ByVal script As String)
        Dim Texto As String = String.Concat(script)
        Log.AppendLine(Texto)
    End Sub

    Private Sub AbrirLog()
        Log = New StringBuilder
    End Sub

    Private Sub CerrarLog(ByVal archivo As String)
        If File.Exists(RutaDir & CarpetaLog & "NOMINA_" & anio & mes & ciclo & archivo & ".txt") Then
            My.Computer.FileSystem.DeleteFile(RutaDir & CarpetaLog & "NOMINA_" & anio & mes & ciclo & archivo & ".txt")
        End If
        Try
            Dim Escritor As TextWriter = New StreamWriter(RutaDir & CarpetaLog & "NOMINA_" & anio & mes & ciclo & archivo & ".txt", True)
            Escritor.WriteLine(Log.ToString)
            Escritor.Close()
        Catch ex As Exception
            EventLog.WriteEntry("MonitorServicio", "Error: " & ex.Message.ToString)
        End Try
    End Sub

End Class