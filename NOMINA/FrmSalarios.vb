Imports C1.Win.C1FlexGrid

Public Class FrmSalarios
    Dim cs As New ClsConsultas
    Dim fec_inicio As Date
    Dim fec_fin As Date
    Dim strsql As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width

    Dim empresa As Integer = 1
    Dim dt As New DataTable
    Dim msj As String

    Private Sub FrmLibroSalarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim preci_naranja As CellStyle = fg.Styles.Add("titulos")
        preci_naranja.Font = New Font(Font, FontStyle.Bold)
        preci_naranja.ForeColor = Color.Black
        preci_naranja.BackColor = Color.Azure

        fg.Rows(0).Visible = False
        Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        fg.Rows(1).Height = 25
        fg.Rows.Count = 1
    End Sub

    Private Sub BtCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCalcular.Click
        fg.Rows.Count = 1
        Dim anio As Integer = Format(Datanio.Value, "yyyy")
        Dim anio_1 As Integer = Format(Datanio.Value, "yyyy") - 1
        fec_inicio = anio & "-01-01"
        fec_fin = anio_1 & "-01-01"
        strsql = "SELECT B.NOMBRE+' '+SEGUNDO_NOMBRE+' '+APELLIDO AS NOMBRE,B.NIT,SUM(ORDINARIO+ASUETO) AS ORDINARIO,SUM(HORAS) AS HORAS,SUM(A.BONIFICACION) AS BONIF,isnull(C.MONTO,0)+isnull(E.MTO_AGUINALDO,0) AS AGUINALDO,sum(VACACIONES)+ISNULL(E.MTO_VACACIONES,0)AS VACAS,'0'AS COMISI,'0'AS PROPI," & _
" ISNULL(D.MONTO_BONO,0)+ isnull(E.MTO_BONO14,0) AS BONO,'0'AS VIATICOS,'0'AS GASTOS,'0'AS DIETAS,'0'AS GRATIFIC,'0'REMUNERA,'0'AS PRESTAC," & _
" SUm(IGSS)as IGSS,'0' AS OTROS,'0'AS INDEM_MUER,E.MTO_INDEMNIZACION AS INDEM,'0'AS REM_DIPLO,'0' AS REPRESENTA,'0'AS DONACIONES,'0'ENT_ESTADO,'0'AS SEGURO,SUM(A.ISR) AS ISR,b.fec_alta" & _
" FROM TB_NOMINA AS A" & _
" LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO" & _
" left join TB_AGUINALDO as C on A.CODIGO = C.COD_EMPLEADO AND C.CICLO = '" & anio_1 & "-" & anio & "'" & _
" left join TB_BONO14 as D on A.CODIGO = D.COD_EMPLEADO AND D.CICLO = '" & anio_1 & "-" & anio & "'" & _
" LEFT JOIN TB_LIQUIDACION AS E ON A.CODIGO =E.COD_EMPLEADO" & _
" WHERE ANIO = " & anio & _
" GROUP BY A.CODIGO,B.NIT,NOMBRE,SEGUNDO_NOMBRE,APELLIDO,C.MONTO,d.MONTO_BONO,E.MTO_AGUINALDO,E.MTO_BONO14,E.MTO_INDEMNIZACION,E.MTO_VACACIONES,b.fec_alta"
        If cs.consultas(strsql, dt, msj) Then
            fg.Rows.Count = dt.Rows.Count + 2
            LLENA()
            Dim rg As CellRange = fg.GetCellRange(1, 1, 1, 29)
            rg.Style = fg.Styles("titulos")
            For i = 0 To dt.Rows.Count - 1
                fg(i + 2, 1) = dt.Rows(i)("nombre")
                fg(i + 2, 2) = dt.Rows(i)("nit")
                fg(i + 2, 3) = dt.Rows(i)("ORDINARIO")
                fg(i + 2, 4) = dt.Rows(i)("HORAS")
                fg(i + 2, 5) = dt.Rows(i)("BONIF")
                fg(i + 2, 6) = dt.Rows(i)("VACAS")
                fg(i + 2, 7) = dt.Rows(i)("COMISi")
                fg(i + 2, 8) = dt.Rows(i)("PROPI")
                fg(i + 2, 9) = dt.Rows(i)("AGUINALDO")
                fg(i + 2, 10) = dt.Rows(i)("BONO")
                fg(i + 2, 11) = dt.Rows(i)("VIATICOS")
                fg(i + 2, 12) = dt.Rows(i)("GASTOS")
                fg(i + 2, 13) = dt.Rows(i)("DIETAS")
                fg(i + 2, 14) = dt.Rows(i)("GRATIFIC")
                fg(i + 2, 15) = dt.Rows(i)("REMUNERA")
                fg(i + 2, 16) = dt.Rows(i)("PRESTAC")
                fg(i + 2, 17) = dt.Rows(i)("IGSS")
                fg(i + 2, 18) = dt.Rows(i)("OTROS")
                fg(i + 2, 19) = dt.Rows(i)("INDEM_MUER")
                fg(i + 2, 20) = dt.Rows(i)("INDEM")
                fg(i + 2, 21) = dt.Rows(i)("REM_DIPLO")
                fg(i + 2, 22) = dt.Rows(i)("REPRESENTA")
                fg(i + 2, 23) = dt.Rows(i)("AGUINALDO")
                fg(i + 2, 24) = dt.Rows(i)("BONO")
                fg(i + 2, 25) = dt.Rows(i)("DONACIONES")
                fg(i + 2, 26) = dt.Rows(i)("ENT_ESTADO")
                fg(i + 2, 27) = dt.Rows(i)("IGSS")
                fg(i + 2, 28) = dt.Rows(i)("SEGURO")
                fg(i + 2, 29) = dt.Rows(i)("ISR")
                fg(i + 2, 30) = dt.Rows(i)("fec_alta")
            Next
        End If
    End Sub

    Private Sub Txtdesde_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub LLENA()
        fg(1, 1) = "NOMBRE"
        fg(1, 2) = "NIT empleado"
        fg(1, 3) = "Sueldos"
        fg(1, 4) = "Horas Extras"
        fg(1, 5) = "Bono Decreto 37-2001"
        fg(1, 6) = "Vacaciones"
        fg(1, 7) = "Comisiones"
        fg(1, 8) = "Propinas"
        fg(1, 9) = "Aguinaldo"
        fg(1, 10) = "Bono Anual de trabajadores (14)"
        fg(1, 11) = "Viáticos"
        fg(1, 12) = "Gasto de representación"
        fg(1, 13) = "Dietas"
        fg(1, 14) = "Gratificaciones"
        fg(1, 15) = "Remuneraciones"
        fg(1, 16) = "Prestaciones"
        fg(1, 17) = "IGSS"
        fg(1, 18) = "Otros"
        fg(1, 19) = "Indemnizaciones o pensiones por causa de muerte"
        fg(1, 20) = "Indemnizaciones por tiempo servido"
        fg(1, 21) = "Remuneraciones de los diplomáticos"
        fg(1, 22) = "Gastos de representación y viáticos comprobables"
        fg(1, 23) = "Aguinaldo"
        fg(1, 24) = "Bono Anual de trabajadores (14)"
        fg(1, 25) = "Donaciones a Universidades"
        fg(1, 26) = "Entidades del Estado"
        fg(1, 27) = "Cuotas IGSS  y Otros planes de seguridad social"
        fg(1, 28) = "Seguro de vida	Otras Donaciones (Con limite 5% sobre Rentas Brutas) "
        fg(1, 29) = "Isr"
        fg(1, 30) = "Fecha Alta"
    End Sub
    Private Sub Txthasta_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.FileSystem.DeleteFile("C:\Plan_rep\isr.csv", FileIO.UIOption.AllDialogs, _
               FileIO.RecycleOption.SendToRecycleBin, _
               FileIO.UICancelOption.DoNothing)
        Catch
        End Try
        Try
            fg.SaveExcel("C:\Plan_rep\" & "isr.csv", FileFlags.IncludeFixedCells, FileFlags.IncludeMergedRanges + FileFlags.AsDisplayed)
            Dim pathPDF As String = "C:\Plan_rep\isr.csv"
            Process.Start(pathPDF)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class