Public Class FrmHorasExtras
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim scr As String
    Dim msj As String
    Dim cs As New ClsConsultas
    Dim dtMes As New DataTable
    Dim dt_rep_horas As New DataTable
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim fecha_inic As Date
    Dim fecha_fin As Date
    Dim mes2 As Integer
    Dim dtCodigo As New DataTable
    Dim dt_horas As New DataTable
    Dim dt_codigo_gen As New DataTable
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue

    Private Sub FrmMarcas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l - 20, a - 40)
        Me.Top = a - (a - 40 / 2)
        Me.Left = l - (l - 20 / 2)
        Combo_box_Mes()
        CbCiclo.SelectedIndex = 0
        crea_table()
        'DatAnio.MinDate = Today.AddDays(-1)
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

    End Sub

    Private Sub CbCiclo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CbCiclo.SelectedIndexChanged
        If CbCiclo.Text = "2" Then
            GroupBox1.Enabled = True
        ElseIf CbCiclo.Text = "1" Then
            RbSerigrafia.Checked = True
            GroupBox1.Enabled = False
        End If
    End Sub



    Private Sub reporte_serigrafia()
        Dim fec_temp As Date = fecha_inic
        dt_rep_horas.Clear()
        Try
            Cursor = Cursors.WaitCursor
            cr.Load("C:\Plan_rep\nomina.xml", "horas_serigrafia")
            For i = 1 To 16
                cr.Fields("f" & i).Text = Format(fec_temp, "dddd") & Chr(10) & Format(fec_temp, "dd")
                fec_temp = fec_temp.AddDays(1)
            Next
            cr.Fields("periodo").Text = "Del " & fecha_inic & " Al " & fecha_fin
            llena_dt_horas()
            cr.DataSource.ConnectionString = cs.con
            cr.DataSource.Recordset = dt_rep_horas
            cr.Render()
            pp.Document = cr
            pp.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
        'prueba_()
    End Sub

    Private Function consultas() As Boolean
        Dim resuta As Boolean = False
        Try
            scr = "SELECT DISTINCT(CODIGO) FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO = 'A' AND COD_DEPART in ('15','40') AND CODIGO_EMPRESA = '" & empresa & "' ORDER BY CODIGO ASC"
            Try
                If cs.consultas(scr, dtCodigo, msj) Then
                    scr = "SELECT DISTINCT(CODIGO) FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO = 'A' AND COD_DEPART not in('15','40') AND CODIGO_EMPRESA = '" & empresa & "' ORDER BY CODIGO ASC"
                    If cs.consultas(scr, dt_codigo_gen, msj) Then

                        scr = "SELECT CODIGO, A.NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO, COD_DEPART,B.FECHA,B.HORAS,C.NOMBRE AS DEPART from TB_EMPLEADO AS A" & _
                              " LEFT JOIN TB_HORAS_EXTRAS AS B ON A.CODIGO = B.COD_EMPLEADO AND B.FECHA BETWEEN '" & fecha_inic & "' AND '" & fecha_fin & "'" & _
                                "LEFT JOIN TB_DEPTOS_EMPRESA AS C ON A.COD_DEPART = C.COD_DEPAR"
                        cs.consultas(scr, dt_horas, msj)
                        resuta = True
                    End If
                End If
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        Return resuta
    End Function

    Private Sub crea_table()
        dt_rep_horas.Columns.Add("CODIGO")
        dt_rep_horas.Columns.Add("NOMBRE")
        dt_rep_horas.Columns.Add("SECCION")
        dt_rep_horas.Columns.Add("D1")
        dt_rep_horas.Columns.Add("D2")
        dt_rep_horas.Columns.Add("D3")
        dt_rep_horas.Columns.Add("D4")
        dt_rep_horas.Columns.Add("D5")
        dt_rep_horas.Columns.Add("D6")
        dt_rep_horas.Columns.Add("D7")
        dt_rep_horas.Columns.Add("D8")
        dt_rep_horas.Columns.Add("D9")
        dt_rep_horas.Columns.Add("D10")
        dt_rep_horas.Columns.Add("D11")
        dt_rep_horas.Columns.Add("D12")
        dt_rep_horas.Columns.Add("D13")
        dt_rep_horas.Columns.Add("D14")
        dt_rep_horas.Columns.Add("D15")
        dt_rep_horas.Columns.Add("D16")
        dt_rep_horas.Columns.Add("D17")
        dt_rep_horas.Columns.Add("D18")
        dt_rep_horas.Columns.Add("D19")
        dt_rep_horas.Columns.Add("D20")
        dt_rep_horas.Columns.Add("D21")
        dt_rep_horas.Columns.Add("D22")
        dt_rep_horas.Columns.Add("D23")
        dt_rep_horas.Columns.Add("D24")
        dt_rep_horas.Columns.Add("D25")
        dt_rep_horas.Columns.Add("D26")
        dt_rep_horas.Columns.Add("D27")
        dt_rep_horas.Columns.Add("D28")
        dt_rep_horas.Columns.Add("D29")
        dt_rep_horas.Columns.Add("D30")
        dt_rep_horas.Columns.Add("D31")
        dt_rep_horas.Columns.Add("TOTAL")
        dt_rep_horas.AcceptChanges()
    End Sub

    Private Sub Combo_box_Mes()
        Dim mes As Integer
        mes = Date.Now.Month
        scr = "SELECT MES, NUMERO FROM MES"
        cs.consultas(scr, dtMes, msj)
        Cbmes.DataSource = dtMes
        Cbmes.SelectedIndex = mes - 1
        Cbmes.DisplayMember = "MES"
        Cbmes.ValueMember = "NUMERO"
    End Sub

    Private Sub fechas2()
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
        fecha_inic = CDate(Format(anio2 & "-" & mes2 & "-" & 26))
        fecha_fin = CDate(Format(anio & "-" & mes & "-" & 25))
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        dt_rep_horas.Clear()
        If RbSerigrafia.Checked = True Then
            fechas()
            If consultas() Then
                llena_dt_horas()
                reporte_serigrafia()
            End If
        ElseIf RbGeneral.Checked = True Then
            fechas2()
            If consultas() = True Then
                llena_dt_horas_gen()
                reporte_horas_gen()
            End If
        End If
    End Sub

    Private Sub llena_dt_horas_gen()
        Dim fec_tem As Date = fecha_inic
        Dim dd As DataRow()
        Dim dtr As DataRow
        Dim cont As Integer = 1
        Dim h As Integer
        Dim min_s() As String
        Dim min As Integer
        Dim h_t As Integer
        Dim min_t As Integer
        Dim min_h As Integer
        Dim min_tt As Integer
        For I = 0 To dt_codigo_gen.Rows.Count - 1
            h = 0
            min = 0
            min_t = 0
            dd = dt_horas.Select("CODIGO = " & dt_codigo_gen.Rows(I)("codigo"))
            Dim dt_r As DataRow = dt_rep_horas.NewRow
            dt_r("CODIGO") = dd(0)("CODIGO")
            dt_r("SECCION") = dd(0)("DEPART")
            dt_r("NOMBRE") = dd(0)("NOMBRE") & " " & dd(0)("SEGUNDO_NOMBRE") & " " & dd(0)("APELLIDO") & " " & dd(0)("SEGUNDO_APELLIDO")
            For Each dtr In dd
                If dtr("fecha") IsNot DBNull.Value Then
                    For M = 1 To 31
                        If dtr("fecha") = fec_tem Then
                            dt_r("d" & cont) = dtr("horas")
                            h = CInt(Int(dtr("horas")))
                            min_s = dtr("horas").ToString.Split(".")
                            min = min_s(1)
                        End If
                        fec_tem = fec_tem.AddDays(1)
                        cont = cont + 1
                    Next
                End If
                cont = 1
                fec_tem = fecha_inic
                h_t = h_t + h
                min_t = min_t + min
            Next
            min_h = CInt(Fix(min_t / 60))
            h_t = h_t + min_h
            min_tt = min_t - (min_h * 60)
            dt_r("total") = h_t & ":" & Format(min_tt, "00")
            dt_rep_horas.Rows.Add(dt_r)
            dt_rep_horas.AcceptChanges()
            min_t = 0
            h_t = 0
        Next
    End Sub

    Private Sub llena_dt_horas()
        Dim fec_tem As Date = fecha_inic
        Dim dd As DataRow()
        Dim dtr As DataRow
        Dim cont As Integer = 1
        Dim h As Integer
        Dim min_s() As String
        Dim min As Integer
        Dim h_t As Integer
        Dim min_t As Integer
        Dim min_h As Integer
        Dim min_tt As Integer
        For I = 0 To dtCodigo.Rows.Count - 1
            h = 0
            min = 0
            min_t = 0
            dd = dt_horas.Select("CODIGO = " & dtCodigo.Rows(I)("codigo"))
            Dim dt_r As DataRow = dt_rep_horas.NewRow
            dt_r("CODIGO") = dd(0)("CODIGO")
            dt_r("SECCION") = dd(0)("DEPART")
            dt_r("NOMBRE") = dd(0)("NOMBRE") & " " & dd(0)("SEGUNDO_NOMBRE") & " " & dd(0)("APELLIDO") & " " & dd(0)("SEGUNDO_APELLIDO")
            For Each dtr In dd
                If dtr("fecha") IsNot DBNull.Value Then
                    For M = 1 To 16
                        If dtr("fecha") = fec_tem Then
                            dt_r("d" & cont) = dtr("horas")
                            h = CInt(Int(dtr("horas")))
                            min_s = dtr("horas").ToString.Split(".")
                            min = min_s(1)
                        End If
                        fec_tem = fec_tem.AddDays(1)
                        cont = cont + 1
                    Next
                End If
                cont = 1
                fec_tem = fecha_inic
                cont = 1
                fec_tem = fecha_inic
                h_t = h_t + h
                min_t = min_t + min
            Next
            min_h = CInt(Fix(min_t / 60))
            h_t = h_t + min_h
            min_tt = min_t - (min_h * 60)
            dt_r("total") = h_t & ":" & Format(min_tt, "00")
            dt_rep_horas.Rows.Add(dt_r)
            dt_rep_horas.AcceptChanges()
            min_t = 0
            h_t = 0
            min_tt = 0
        Next
    End Sub

    Private Sub reporte_horas_gen()
        Dim fec_temp As Date = fecha_inic
        Try
            Cursor = Cursors.WaitCursor
            cr.Load("C:\Plan_rep\nomina.xml", "horas_nomina")
            For i = 1 To 31
                cr.Fields("f" & i).Text = Format(fec_temp, "ddd") & Chr(10) & Format(fec_temp, "dd")
                fec_temp = fec_temp.AddDays(1)
            Next
            cr.Fields("periodo").Text = "Del " & fecha_inic & " Al " & fecha_fin
            cr.DataSource.ConnectionString = cs.con
            cr.DataSource.Recordset = dt_rep_horas
            cr.Render()
            pp.Document = cr
            pp.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

End Class
