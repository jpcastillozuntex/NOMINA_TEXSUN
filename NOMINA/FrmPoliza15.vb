Imports C1.Win.C1FlexGrid

Public Class FrmPoliza15
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim dt As New DataTable
    Dim msj As String
    Dim dtMes As New DataTable
    Dim dt_totales As New DataTable
    ' Dim dt_EmpPaga As New DataTable
    Dim dt_haber As New DataTable
    Dim centro As String
    Dim new_centro As String
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim empresa = FrmInicio.empresa
    Dim dt_centros As New DataTable

    Private Sub FrmPoliza15_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        Combo_box_Mes()
        CbCiclo.SelectedIndex = 0
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
    End Sub

    Private Sub BtConsultar_Click(sender As System.Object, e As System.EventArgs) Handles BtConsultar.Click
        dt_totales.Clear()
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbCiclo.Text
        Dim filas As Integer
        Dim prov_agui As Double = 0
        Dim prov_boni As Double = 0
        Dim prov_inde As Double = 0
        Dim prov_igss_p As Double = 0
        Dim prov_igss_e As Double = 0
        scr = "delete from tb_poliza"
        If cs.procedure(scr, msj) Then
            scr = "INSERT INTO TB_POLIZA SELECT C.CENTRO_DE_COSTO,sum(ORDINARIO)as ORD,sum(ASUETO)as ASU,SUM(VACACIONES) AS VACAS,sum(HORAS) as HORAS,sum(ANTICIPO)as ANTI,sum(A.BONIFICACION)as BONIF,sum(IGSS)as IGSS,sum(ISR)as ISR, SUM(OTROS_DESC)AS DESCU,D.CUENTAS,D.TIPO_CUENTA,D.NOMBRE  FROM TB_NOMINA AS A" & _
                      " LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND CODIGO_EMPRESA = 1" & _
                      " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON A.DEPART = C.COD_DEPAR " & _
                      " LEFT JOIN CUENTAS AS D ON C.TIPO_CUENTA = D.TIPO_CUENTA" & _
                      " WHERE ANIO =  " & anio & " AND mes =  " & mes & " and QUINCENA = " & ciclo & " and b.EMP_PAGA =1 " & _
                      " group by c.CENTRO_DE_COSTO,D.CUENTAS,D.TIPO_CUENTA,D.NOMBRE"
            cs.procedure(scr, msj)
            scr = "INSERT INTO TB_POLIZA SELECT SUBSTRING(C.CENTRO_DE_COSTO,0,3)+'04'AS CENTRO_DE_COSTO,sum(ORDINARIO)as ORD,sum(ASUETO)as ASU,SUM(VACACIONES) AS VACAS,sum(HORAS) as HORAS,sum(ANTICIPO)as ANTI,sum(A.BONIFICACION)as BONIF,sum(IGSS)as IGSS,sum(ISR)as ISR, SUM(OTROS_DESC)AS DESCU,D.CUENTAS,D.TIPO_CUENTA,D.NOMBRE  FROM TB_NOMINA AS A" & _
               " LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND CODIGO_EMPRESA = 1" & _
                " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON A.DEPART = C.COD_DEPAR " & _
                " LEFT JOIN CUENTAS AS D ON C.TIPO_CUENTA = D.TIPO_CUENTA" & _
                " WHERE ANIO =  " & anio & " AND mes =  " & mes & " and QUINCENA = " & ciclo & " and b.EMP_PAGA = 2" & _
                " group by c.CENTRO_DE_COSTO,D.CUENTAS,D.TIPO_CUENTA,D.NOMBRE"
            cs.procedure(scr, msj)
            scr = "INSERT INTO TB_POLIZA SELECT SUBSTRING(C.CENTRO_DE_COSTO,0,3)+'06'AS CENTRO_DE_COSTO,sum(ORDINARIO)as ORD,sum(ASUETO)as ASU,SUM(VACACIONES) AS VACAS,sum(HORAS) as HORAS,sum(ANTICIPO)as ANTI,sum(A.BONIFICACION)as BONIF,sum(IGSS)as IGSS,sum(ISR)as ISR, SUM(OTROS_DESC)AS DESCU,D.CUENTAS,D.TIPO_CUENTA,D.NOMBRE  FROM TB_NOMINA AS A" & _
                        " LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO AND CODIGO_EMPRESA = 1" & _
                        " LEFT JOIN TB_DEPTOS_EMPRESA AS C ON A.DEPART = C.COD_DEPAR " & _
                        " LEFT JOIN CUENTAS AS D ON C.TIPO_CUENTA = D.TIPO_CUENTA" & _
                        " WHERE ANIO =  " & anio & " AND mes =  " & mes & " and QUINCENA = " & ciclo & " and b.EMP_PAGA = 3" & _
                        " group by c.CENTRO_DE_COSTO,D.CUENTAS,D.TIPO_CUENTA,D.NOMBRE"
            cs.procedure(scr, msj)

            scr = "SELECT sum(ORDINARIO)as ORD,sum(ASUETO)as ASU,SUM(VACACIONES) AS VACAS,sum(HORAS) as HORAS,sum(ANTICIPO)as ANTI,sum(A.BONIFICACION)as BONIF,sum(IGSS)as IGSS,sum(ISR)as ISR, SUM(OTROS_DESC)AS DESCU  FROM TB_NOMINA AS A" & _
                    " WHERE ANIO = " & anio & " AND mes = " & mes & " and QUINCENA = " & ciclo
            cs.consultas(scr, dt_haber, msj)

            scr = "select centro_de_costo,sum(ord) as ord,sum(asu)as asu,sum(VACAS) as vacas, sum (horas) as horas,sum(anti)as anti,sum(bonif)as bonif,sum(igss)as igss,sum(isr)as isr,sum(descu)as descu,cuentas,TIPO_CUENTA,NOMBRE from TB_POLIZA " & _
                    " group by CENTRO_DE_COSTO,NOMBRE,CUENTAS,TIPO_CUENTA " & _
                    " order by CENTRO_DE_COSTO,CUENTAS "
            cs.consultas(scr, dt_totales, msj)

            filas = dt_totales.Rows.Count
            fg.Rows.Count = dt_totales.Rows.Count + dt_haber.Rows.Count + 9
            For j = 0 To dt_totales.Rows.Count - 1
                fg(j + 1, 1) = dt_totales.Rows(j)("centro_de_costo") & dt_totales.Rows(j)("tipo_cuenta") & dt_totales.Rows(j)("cuentas")
                fg(j + 1, 2) = dt_totales.Rows(j)("NOMBRE")
                If dt_totales.Rows(j)("CUENTAS") = "0001" Then
                    fg.SetCellStyle(j + 1, 1, "FONDO")
                    fg.SetCellStyle(j + 1, 2, "FONDO")
                    fg.SetCellStyle(j + 1, 3, "FONDO")
                    fg.SetCellStyle(j + 1, 4, "FONDO")
                    fg(j + 1, 3) = dt_totales.Rows(j)("ORD") + dt_totales.Rows(j)("ASU")
                ElseIf dt_totales.Rows(j)("CUENTAS") = "0002" Then
                    fg(j + 1, 3) = dt_totales.Rows(j)("HORAS")
                ElseIf dt_totales.Rows(j)("CUENTAS") = "0003" Then
                    fg(j + 1, 3) = (dt_totales.Rows(j)("ORD") + dt_totales.Rows(j)("ASU")) * 0.08333
                    prov_agui = prov_agui + ((dt_totales.Rows(j)("ORD") + dt_totales.Rows(j)("ASU")) * 0.08333)
                ElseIf dt_totales.Rows(j)("CUENTAS") = "0004" Then
                    fg(j + 1, 3) = dt_totales.Rows(j)("VACAS")
                ElseIf dt_totales.Rows(j)("CUENTAS") = "0005" Then
                    fg(j + 1, 3) = (dt_totales.Rows(j)("ORD") + dt_totales.Rows(j)("ASU") + dt_totales.Rows(j)("HORAS")) * 0.097220057
                    prov_inde = prov_inde + ((dt_totales.Rows(j)("ORD") + dt_totales.Rows(j)("ASU") + dt_totales.Rows(j)("HORAS")) * 0.097220057)
                ElseIf dt_totales.Rows(j)("CUENTAS") = "0006" Then
                    fg(j + 1, 3) = (dt_totales.Rows(j)("ORD") + dt_totales.Rows(j)("HORAS") + dt_totales.Rows(j)("VACAS") + dt_totales.Rows(j)("asu")) * 0.1267
                    prov_igss_p = prov_igss_p + ((dt_totales.Rows(j)("ORD") + dt_totales.Rows(j)("HORAS") + dt_totales.Rows(j)("VACAS") + dt_totales.Rows(j)("asu")) * 0.1267)
                ElseIf dt_totales.Rows(j)("CUENTAS") = "0007" Then
                    fg(j + 1, 3) = (dt_totales.Rows(j)("ORD") + dt_totales.Rows(j)("ASU")) * 0.08333
                    prov_boni = prov_boni + ((dt_totales.Rows(j)("ORD") + dt_totales.Rows(j)("ASU")) * 0.08333)
                ElseIf dt_totales.Rows(j)("CUENTAS") = "0008" Then
                    fg(j + 1, 3) = dt_totales.Rows(j)("BONIF")
                End If
            Next
            Try
                filas = filas + 1
                fg(filas, 1) = "1102020001"
                fg(filas, 2) = "ANTICIPOS A EMPLEADOS"
                fg(filas, 4) = dt_haber.Rows(0)("ANTI")

                fg(filas + 1, 1) = "2101010001"
                fg(filas + 1, 2) = "SUELDOS POR PAGAR"
                fg(filas + 1, 4) = dt_haber.Rows(0)("ORD") + dt_haber.Rows(0)("HORAS") + dt_haber.Rows(0)("VACAS") + dt_haber.Rows(0)("BONIF") + dt_haber.Rows(0)("ASU") - dt_haber.Rows(0)("igss") - dt_haber.Rows(0)("ANTI") - dt_haber.Rows(0)("ISR") - dt_haber.Rows(0)("DESCU")

                fg(filas + 2, 1) = "2101010003"
                fg(filas + 2, 2) = "PROVISION DE AGUINALDO"
                fg(filas + 2, 4) = prov_agui

                fg(filas + 3, 1) = "2101010004"
                fg(filas + 3, 2) = "PROVISION DE BONO 14"
                fg(filas + 3, 4) = prov_boni

                fg(filas + 4, 1) = "2101010005"
                fg(filas + 4, 2) = "PROVISON DE INDEMNIZACION"
                fg(filas + 4, 4) = prov_inde

                fg(filas + 5, 1) = "2105010001"
                fg(filas + 5, 2) = "CUOTA LABORAL IGSS"
                fg(filas + 5, 4) = dt_haber.Rows(0)("IGSS")

                fg(filas + 6, 1) = "2105010002"
                fg(filas + 6, 2) = "CUOTA PATRONAL IGSS"
                fg(filas + 6, 4) = prov_igss_p

                fg(filas + 7, 1) = "2102010003"
                fg(filas + 7, 2) = "ISR EMPLEADO"
                fg(filas + 7, 4) = dt_haber.Rows(0)("ISR")

                fg(filas + 8, 1) = "2106010006"
                fg(filas + 8, 2) = "OTROS DESCUENTOS"
                fg(filas + 8, 4) = dt_haber.Rows(0)("DESCU")
            Catch
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.FileSystem.DeleteFile("C:\Plan_rep\poliza_nomina.xls", FileIO.UIOption.AllDialogs, _
               FileIO.RecycleOption.SendToRecycleBin, _
               FileIO.UICancelOption.DoNothing)
        Catch
        End Try
        Try
            fg.SaveExcel("C:\Plan_rep\" & "poliza_nomina.xls", FileFlags.IncludeFixedCells, FileFlags.IncludeMergedRanges + FileFlags.AsDisplayed)
            Dim pathPDF As String = "C:\Plan_rep\poliza_nomina.xls"
            Process.Start(pathPDF)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class