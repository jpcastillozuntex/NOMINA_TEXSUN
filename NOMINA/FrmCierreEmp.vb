Imports C1.Win.C1FlexGrid

Public Class FrmCierreEmp
    Dim f As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim g As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim msj As String
    Dim empresa As String = 1
    Dim cs As New ClsConsultas
    Dim resulta As Boolean
    Dim scr As String
    Dim anio As Integer
    Dim anioantes As Integer
    Dim dias_habi As Integer
    Dim fecha As Date
    Dim dt_liquidacion As New DataTable

    Private Sub BtCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCalcular.Click
        Try
            anio = Format(DatFecha.Value, "yyyy")
            anioantes = anio - 1
            fecha = DatFecha.Value
            scr = "Delete From TB_LIQUIDACION_TOTAL"
            cs.delete(scr, msj)
            scr = "INSERT INTO TB_LIQUIDACION_TOTAL (COD_EMPLEADO, COD_EMPRESA,FEC_LIQUIDACION) SELECT CODIGO, CODIGO_EMPRESA,'" & Format(DatFecha.Value, "yyyy-MM-dd") & "' FROM TB_EMPLEADO WHERE estado_empleado IN ('A','S')"
            If cs.insert(scr, msj) = True Then
            End If
            scr = "EXECUTE INDEMNIZACION_PRUEBA_EXE @fecha = '" & Format(DatFecha.Value, "yyyy-MM-dd") & "', @empresa = " & empresa
            If cs.procedure(scr, msj) Then
                scr = "EXECUTE BONO14_BAJA_TOTAL_EXE @fec = '" & Format(DatFecha.Value, "yyyy-MM-dd") & "', @empresa = " & empresa
                If cs.procedure(scr, msj) Then
                    scr = "EXECUTE AGUINALDO_BAJA_TOTAL_EXE @fec = '" & Format(DatFecha.Value, "yyyy-MM-dd") & "', @empresa = " & empresa
                    If cs.procedure(scr, msj) Then
                        scr = "EXECUTE [VACAS_BAJA_TOTAL_EXE] @fec = '" & Format(DatFecha.Value, "yyyy-MM-dd") & "', @empresa = " & empresa
                        If cs.procedure(scr, msj) Then

                        Else
                            MsgBox(msj)
                        End If
                    Else
                        MsgBox(msj)
                    End If
                Else
                    MsgBox(msj)
                End If
            Else
                MsgBox(msj)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Close()
        End Try
        llena_flex()
    End Sub

    Function indemnizacion() As Boolean
        scr = "EXECUTE INDEMNIZACION_TOTAL_EXE @fec = '2015-01-06', @empresa = 1"
        If cs.procedure(scr, msj) Then
            resulta = True
        Else
            resulta = False
        End If
        Return resulta
    End Function

    Private Sub llena_flex()
        scr = "Select b.nombre,b.SEGUNDO_NOMBRE,b.APELLIDO,apellido,sueldo_base,b.fec_alta, a.* from tb_liquidacion_total as a" &
                " left join TB_EMPLEADO as b on a.cod_empleado = b.CODIGO" &
                " where cod_empresa = '1'"

        cs.consultas(scr, dt_liquidacion, msj)
        fg.Rows.Count = dt_liquidacion.Rows.Count + 2
        For i = 0 To dt_liquidacion.Rows.Count - 1
            fg(i + 1, 1) = dt_liquidacion.Rows(i)("cod_empleado")
            fg(i + 1, 2) = dt_liquidacion.Rows(i)("nombre") & " " & dt_liquidacion.Rows(i)("segundo_nombre") & " " & dt_liquidacion.Rows(i)("apellido")
            fg(i + 1, 3) = dt_liquidacion.Rows(i)("sueldo_base")
            fg(i + 1, 4) = dt_liquidacion.Rows(i)("fec_alta")
            fg(i + 1, 5) = dt_liquidacion.Rows(i)("fec_liquidacion")
            fg(i + 1, 6) = dt_liquidacion.Rows(i)("mto_vacaciones")
            fg(i + 1, 7) = dt_liquidacion.Rows(i)("mto_AGUINALDO")
            fg(i + 1, 8) = dt_liquidacion.Rows(i)("mto_BONO14")
            fg(i + 1, 9) = dt_liquidacion.Rows(i)("mto_INDEMNIZACION")
            fg(i + 1, 12) = fg(i + 1, 6) + fg(i + 1, 7) + fg(i + 1, 8) + fg(i + 1, 9)
        Next
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.FileSystem.DeleteFile("C:\Plan_rep\indemnizacion.xls", FileIO.UIOption.AllDialogs,
               FileIO.RecycleOption.SendToRecycleBin,
               FileIO.UICancelOption.DoNothing)
        Catch
        End Try
        Try
            fg.SaveExcel("C:\Plan_rep\" & "indemnizacion.xls", FileFlags.IncludeFixedCells)
            Dim pathPDF As String = "C:\Plan_rep\indemnizacion.xls"
            Process.Start(pathPDF)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmCierreEmp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fg.Rows(0).Height = 30
    End Sub
End Class
