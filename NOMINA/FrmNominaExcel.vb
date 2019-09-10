Imports C1.Win.C1FlexGrid

Public Class FrmNominaExcel

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

        fg(0, 1) = "codigo"
        fg(0, 2) = "nombre"
        fg(0, 3) = "depto"
        fg(0, 4) = "ordnario"
        fg(0, 5) = "vacaciones"
        fg(0, 6) = "asueto"
        fg(0, 7) = "horas"
        fg(0, 8) = "horas N."
        fg(0, 9) = "anticipo"
        fg(0, 10) = "bonif"
        fg(0, 11) = "igss"
        fg(0, 12) = "ot. desc"
        fg(0, 13) = "isr"
        fg(0, 14) = "dias"
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
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbCiclo.Text

        scr = "SELECT a.*,b.nombre,b.segundo_nombre, b.apellido,c.nombre as departamento FROM TB_NOMINA as a " & _
                " left join tb_empleado as b on a.codigo = b.codigo" & _
                " left join TB_DEPTOS_EMPRESA as c on b.cod_depart = c.cod_depar  WHERE ANIO = " & anio & " AND MES = " & mes & " AND QUINCENA = " & ciclo & ""
        If cs.consultas(scr, dt, msj) Then
            fg.Rows.Count = dt.Rows.Count + 1
            For i = 0 To dt.Rows.Count - 1
                fg(i + 1, 1) = dt.Rows(i)("codigo")
                fg(i + 1, 2) = dt.Rows(i)("nombre") & " " & dt.Rows(i)("segundo_nombre") & " " & dt.Rows(i)("apellido")
                fg(i + 1, 3) = dt.Rows(i)("departamento")
                fg(i + 1, 4) = dt.Rows(i)("ordinario")
                fg(i + 1, 5) = dt.Rows(i)("vacaciones")
                fg(i + 1, 6) = dt.Rows(i)("asueto")
                fg(i + 1, 7) = dt.Rows(i)("horas")
                fg(i + 1, 8) = dt.Rows(i)("horas_n")
                fg(i + 1, 9) = dt.Rows(i)("anticipo")
                fg(i + 1, 10) = dt.Rows(i)("bonificacion") + dt.Rows(i)("bon_prod")
                fg(i + 1, 11) = dt.Rows(i)("igss")
                fg(i + 1, 12) = dt.Rows(i)("otros_desc")
                fg(i + 1, 13) = dt.Rows(i)("isr")
                fg(i + 1, 14) = dt.Rows(i)("dias")
            Next
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            My.Computer.FileSystem.DeleteFile("C:\Plan_rep\poliza_nomina.xls", FileIO.UIOption.AllDialogs, _
               FileIO.RecycleOption.SendToRecycleBin, _
               FileIO.UICancelOption.DoNothing)
        Catch
        End Try
        '   Try
        '       fg.SaveExcel("C:\Plan_rep\" & "poliza_nomina.xls", C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells)
        '       Dim pathPDF As String = "C:\Plan_rep\poliza_nomina.xls"
        '       Process.Start(pathPDF)
        '   Catch ex As Exception
        '       MsgBox(ex.Message)
        '   End Try
        '
        fg.SaveGrid("C:\Plan_rep\" & "poliza_nomina.xls", FileFormatEnum.Excel, FileFlags.IncludeFixedCells)
        Dim pathPDF As String = "C:\Plan_rep\poliza_nomina.xls"
        Process.Start(pathPDF)

    End Sub

End Class