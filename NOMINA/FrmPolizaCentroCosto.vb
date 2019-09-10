Imports System.Threading
Imports C1.Win.C1FlexGrid

Public Class FrmPolizaCentroCosto
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim dt As New DataTable
    Dim msj As String
    Dim dtMes As New DataTable
    Dim dt_guarda As New DataTable
    Dim dt_cuentas As New DataTable
    Dim centro As String
    Dim new_centro As String
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim empresa = FrmInicio.empresa
    Dim dt_desc As New DataTable
    Dim dt_haber As New DataTable
    Dim filas As Integer
    Dim dt_fin As New DataTable
    Dim dt_fin_c As New DataTable
    Dim dt_provis As New DataTable
    Dim dt_sin_centro As New DataTable

    Private Sub FrmPoliza15_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(a - 20, Me.Size.Width)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
    End Sub

    Private Sub Combo_box_Mes()
        Dim mes As Integer
        mes = Date.Now.Month
        scr = "SELECT MES, NUMERO FROM MES"
        cs.consultas(scr, dtMes, msj)
        Cbmes.DataSource = dtMes
        Cbmes.DisplayMember = "MES"
        Cbmes.ValueMember = "NUMERO"
        Cbmes.SelectedIndex = mes - 2
        crea_tabla()
    End Sub

    Private Sub crea_tabla()
        dt_guarda.Columns.Add("cuenta")
        dt_guarda.Columns.Add("monto")
        dt_guarda.Columns.Add("nombre")
        dt_guarda.Columns.Add("centro_costo")
        dt_guarda.Columns.Add("descripcion")
        dt_guarda.Columns.Add("anio")
        dt_guarda.Columns.Add("mes")
        dt_cuentas.AcceptChanges()
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        scr = "SELECT CODIGO FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO IN ('A','S') AND CENTRO =''"
        If cs.consultas(scr, dt_sin_centro, msj) Then
            Dim cod_s As String = ""
            If dt_sin_centro.Rows.Count > 0 Then
                For i = 0 To dt_sin_centro.Rows.Count - 1
                    cod_s = cod_s & "," & dt_sin_centro.Rows(i)("codigo")
                Next
                MsgBox("estos codigos no tiene centro de costo '" & cod_s & "'", MsgBoxStyle.Information)
            End If
        End If
        Dim cant As Integer = 0
        scr = "select count(1) from poli_centro where anio = '" & Format(DatAnio.Value, "yyyy") & "' and mes = '" & Cbmes.SelectedValue & "'"
        If cs.csescalar(cant, scr, msj) Then
            If cant > 0 Then
                BtGuardar.Visible = False
            Else
                BtGuardar.Visible = True
            End If
        End If
        dt_guarda.Clear()
        mes = Cbmes.SelectedValue
        anio = Format(DatAnio.Value, "yyyy")
        Dim dtr_g() As DataRow
        scr = "SELECT sum(ORDINARIO)as ORD,sum(ASUETO)as ASU,SUM(VACACIONES) AS VACAS,sum(HORAS+horas_n) as HORAS,sum(ANTICIPO)as ANTI,sum(A.BONIFICACION+bon_prod)as BONIF,sum(IGSS)as IGSS,sum(ISR)as ISR, SUM(OTROS_DESC)AS DESCU  FROM TB_NOMINA AS A" &
          " WHERE ANIO = " & anio & " AND mes = " & mes
        cs.consultas(scr, dt_haber, msj)
        scr = "SELECT * FROM CUENTAS1"
        cs.consultas(scr, dt_cuentas, msj)

        scr = "select * from CUENTAS where TIPO_CUENTA = 01 order by CUENTAS"
        cs.consultas(scr, dt_desc, msj)

        scr = "select sum(ORDINARIO+asueto+VACACIONES)* 0.08333 AS AGUINALDO,sum(ORDINARIO+asueto+VACACIONES)* 0.08333 AS BONO14, " &
                " sum (ORDINARIO+asueto+HORAS+horas_n+VACACIONES)*0.097220057 AS INDEM, sum(ORDINARIO+asueto+HORAS+VACACIONES)*0.1267 AS PATRONAL" &
                " from TB_NOMINA where anio = " & anio & " AND mes = " & mes
        cs.consultas(scr, dt_provis, msj)

        scr = "select sum(ORDINARIO+asueto)as ORD, sum(HORAS+horas_n) as EXTRA, sum(ORDINARIO+asueto+VACACIONES)* 0.08333 AS AGUINALDO, SUM(VACACIONES) AS VACAS, sum(ORDINARIO+asueto+HORAS+horas_n+VACACIONES)*0.097220057 AS INDEM, " &
                "sum(ORDINARIO+asueto+HORAS+horas_n+VACACIONES)*0.1267 AS PATRONAL, sum(ORDINARIO+asueto+VACACIONES)* 0.08333 AS BONO14, SUM(tb_nomina.BONIFICACION+bon_prod) AS BONIF," &
                " RIGHT('000' + CAST(tb_nomina.centro_costo AS VARCHAR), 3)as CENTRO_COSTO, tb_empleado.EMP_PAGA, TB_CENTROS.CODIGO, TB_CENTROS.CENTRO, TB_CENTROS.TIPO_RUBRO,TB_empleado.CENTRO as centro1  " &
                " from tb_nomina left join TB_deptos_empresa on TB_DEPTOS_EMPRESA.COD_DEPAR = DEPART " &
                " left join TB_CENTROS on TB_CENTROS.CENTRO = TB_DEPTOS_EMPRESA.CENTRO_DE_COSTO " &
                " left join TB_EMPLEADO on tb_nomina.CODIGO = TB_EMPLEADO.CODIGO" &
                  " where anio = " & anio & " And mes = " & mes & "and cod_depart  <> 40" &
                " GROUP BY tb_nomina.CENTRO_COSTO,tb_empleado.EMP_PAGA,TB_CENTROS.CODIGO,TB_CENTROS.CENTRO,TIPO_RUBRO,TB_empleado.CENTRO"
        cs.consultas(scr, dt, msj)
        For i = 0 To dt.Rows.Count - 1
            If dt.Rows(i)("emp_paga") = "1" And dt.Rows(i)("centro1") = "04" Then
                dtr_g = dt_cuentas.Select("EMP_PAGA =02 and depto =02")

            ElseIf dt.Rows(i)("emp_paga") = "2" And dt.Rows(i)("centro1") = "04" Then
                dtr_g = dt_cuentas.Select("EMP_PAGA =02 and depto =01")
            Else
                dtr_g = dt_cuentas.Select("EMP_PAGA =" & dt.Rows(i)("EMP_PAGA") & " and depto =" & dt.Rows(i)("centro1"))
            End If

            If dtr_g.Length > 0 Then
                For j = 1 To 8
                    Dim dtr As DataRow = dt_guarda.NewRow
                    dtr("ANIO") = Format(DatAnio.Value, "yyyy")
                    dtr("MES") = Cbmes.SelectedValue
                    dtr("centro_costo") = dt.Rows(i)("centro_costo")
                    dtr("cuenta") = dtr_g(0)(j + 1)
                    dtr("monto") = dt.Rows(i)(j - 1)
                    dtr("descripcion") = dt_desc.Rows(j - 1)("nombre")
                    dt_guarda.Rows.Add(dtr)
                    dt_guarda.AcceptChanges()
                Next
            Else
                MsgBox(dt.Rows(i)("EMP_PAGA") & "=" & dt.Rows(i)("centro1"))
                Exit Sub
            End If
        Next
        scr = "select sum(ORDINARIO+asueto)as ORD, sum(HORAS+horas_n) as EXTRA, sum(ORDINARIO+asueto+VACACIONES)* 0.08333 AS AGUINALDO, SUM(VACACIONES) AS VACAS, sum(ORDINARIO+asueto+HORAS+horas_n+VACACIONES)*0.097220057 AS INDEM, " &
                "sum(ORDINARIO+asueto+HORAS+horas_n+VACACIONES)*0.1267 AS PATRONAL, sum(ORDINARIO+asueto+VACACIONES)* 0.08333 AS BONO14, SUM(tb_nomina.BONIFICACION+bon_prod) AS BONIF," &
                " RIGHT('000' + CAST(tb_nomina.centro_costo AS VARCHAR), 3)as CENTRO_COSTO, tb_empleado.EMP_PAGA, TB_CENTROS.CODIGO, TB_CENTROS.CENTRO, TB_CENTROS.TIPO_RUBRO,TB_empleado.CENTRO as centro1  " &
                " from tb_nomina left join TB_deptos_empresa on TB_DEPTOS_EMPRESA.COD_DEPAR = DEPART " &
                " left join TB_CENTROS on TB_CENTROS.CENTRO = TB_DEPTOS_EMPRESA.CENTRO_DE_COSTO " &
                " left join TB_EMPLEADO on tb_nomina.CODIGO = TB_EMPLEADO.CODIGO" &
                 " where anio = " & anio & " And mes = " & mes & "and cod_depart =  40" &
                " GROUP BY tb_nomina.CENTRO_COSTO,tb_empleado.EMP_PAGA,TB_CENTROS.CODIGO,TB_CENTROS.CENTRO,TIPO_RUBRO,TB_empleado.CENTRO"
        cs.consultas(scr, dt, msj)
        For i = 0 To dt.Rows.Count - 1
            dtr_g = dt_cuentas.Select("EMP_PAGA =10")
            If dtr_g.Length > 0 Then
                For j = 1 To 8
                    Dim dtr As DataRow = dt_guarda.NewRow
                    dtr("ANIO") = Format(DatAnio.Value, "yyyy")
                    dtr("MES") = Cbmes.SelectedValue
                    dtr("centro_costo") = dt.Rows(i)("centro_costo")
                    dtr("cuenta") = dtr_g(0)(j + 1)
                    dtr("monto") = dt.Rows(i)(j - 1)
                    dtr("descripcion") = dt_desc.Rows(j - 1)("nombre")
                    dt_guarda.Rows.Add(dtr)
                    dt_guarda.AcceptChanges()
                Next
                'End If
            Else
                MsgBox(dt.Rows(i)("EMP_PAGA") & "=" & dt.Rows(i)("centro1"))
                Exit Sub
            End If
        Next


        guarda_reporte()
        llena_fg()
        llena_fg_conta()
    End Sub

    Private Sub guarda_reporte()
        scr = "delete from poli_centro_01 where anio = " & anio & "and mes = " & mes
        If cs.guarda_poliza_01(scr, dt_guarda, msj) Then
        Else
        End If
    End Sub

    Private Sub llena_fg()
        scr = "select sum(monto)as monto ,anio,mes,CENTRO_COSTO,CUENTA,DESCRIPCION from poli_centro_01" & _
               " where anio = " & anio & " And mes = " & mes & _
                "group by CUENTA,anio,mes,CENTRO_COSTO,DESCRIPCION " & _
                "order BY CENTRO_COSTO,CUENTA"
        cs.consultas(scr, dt_fin, msj)
        For i = 0 To dt_fin.Rows.Count - 1
            fg.Rows.Count = dt_fin.Rows.Count + 1
            fg(i + 1, 1) = dt_fin.Rows(i)("cuenta")
            fg(i + 1, 2) = dt_fin.Rows(i)("descripcion")
            fg(i + 1, 3) = dt_fin.Rows(i)("centro_costo")
            fg(i + 1, 4) = dt_fin.Rows(i)("monto")
        Next
    End Sub

    Private Sub llena_fg_conta()
        scr = "select sum(monto)as monto,anio,mes,CUENTA,DESCRIPCION " & _
            " from poli_centro_01" & _
            " where anio = " & anio & " And mes = " & mes & _
            " group by CUENTA,anio,mes,DESCRIPCION" & _
            " order BY cuenta"
        cs.consultas(scr, dt_fin_c, msj)
        For i = 0 To dt_fin_c.Rows.Count - 1
            fg_c.Rows.Count = dt_fin_c.Rows.Count + 12
            fg_c(i + 1, 1) = dt_fin_c.Rows(i)("cuenta")
            fg_c(i + 1, 2) = dt_fin_c.Rows(i)("descripcion")
            fg_c(i + 1, 3) = dt_fin_c.Rows(i)("monto")
        Next
        filas = dt_fin_c.Rows.Count + 1

        Try
            filas = filas + 1
            fg_c(filas, 1) = "1102020001"
            fg_c(filas, 2) = "ANTICIPOS A EMPLEADOS"
            fg_c(filas, 4) = dt_haber.Rows(0)("ANTI")

            fg_c(filas + 1, 1) = "2101010001"
            fg_c(filas + 1, 2) = "SUELDOS POR PAGAR"
            fg_c(filas + 1, 4) = dt_haber.Rows(0)("ORD") + dt_haber.Rows(0)("HORAS") + dt_haber.Rows(0)("VACAS") + dt_haber.Rows(0)("BONIF") + dt_haber.Rows(0)("ASU") - dt_haber.Rows(0)("igss") - dt_haber.Rows(0)("ANTI") - dt_haber.Rows(0)("ISR") - dt_haber.Rows(0)("DESCU")

            fg_c(filas + 2, 1) = "2101010003"
            fg_c(filas + 2, 2) = "PROVISION DE AGUINALDO"
            fg_c(filas + 2, 4) = dt_provis.Rows(0)("aguinaldo")

            fg_c(filas + 3, 1) = "2101010004"
            fg_c(filas + 3, 2) = "PROVISION DE BONO 14"
            fg_c(filas + 3, 4) = dt_provis.Rows(0)("bono14")

            fg_c(filas + 4, 1) = "2101010005"
            fg_c(filas + 4, 2) = "PROVISON DE INDEMNIZACION"
            fg_c(filas + 4, 4) = dt_provis.Rows(0)("indem")

            fg_c(filas + 5, 1) = "2105010001"
            fg_c(filas + 5, 2) = "CUOTA LABORAL IGSS"
            fg_c(filas + 5, 4) = dt_haber.Rows(0)("IGSS")

            fg_c(filas + 6, 1) = "2105010002"
            fg_c(filas + 6, 2) = "CUOTA PATRONAL IGSS"
            fg_c(filas + 6, 4) = dt_provis.Rows(0)("patronal")

            fg_c(filas + 7, 1) = "2102010003"
            fg_c(filas + 7, 2) = "ISR EMPLEADO"
            fg_c(filas + 7, 4) = dt_haber.Rows(0)("ISR")

            fg_c(filas + 8, 1) = "2106010006"
            fg_c(filas + 8, 2) = "OTROS DESCUENTOS"
            fg_c(filas + 8, 4) = dt_haber.Rows(0)("DESCU")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.FileSystem.DeleteFile("C:\Plan_rep\poliza_nomina.xls", FileIO.UIOption.AllDialogs, _
               FileIO.RecycleOption.SendToRecycleBin, _
               FileIO.UICancelOption.DoNothing)
        Catch
        End Try
        If C1DockingTab1.SelectedIndex = 0 Then
            Try
                fg.SaveExcel("C:\Plan_rep\" & "poliza_nomina.xls", FileFlags.IncludeFixedCells, FileFlags.IncludeMergedRanges + FileFlags.AsDisplayed)
                Dim pathPDF As String = "C:\Plan_rep\poliza_nomina.xls"
                Process.Start(pathPDF)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                fg_c.SaveExcel("C:\Plan_rep\" & "poliza_nomina.xls", FileFlags.IncludeFixedCells, FileFlags.IncludeMergedRanges + FileFlags.AsDisplayed)
                Dim pathPDF As String = "C:\Plan_rep\poliza_nomina.xls"
                Process.Start(pathPDF)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        If cs.guarda_poliza(dt_fin, msj) Then
            MsgBox("poliza Guardada!", MsgBoxStyle.Information)
            BtGuardar.Visible = False
        Else
            MsgBox("Ocurrio un problema, no se guardo la poliza", MsgBoxStyle.Information)
        End If
    End Sub
End Class