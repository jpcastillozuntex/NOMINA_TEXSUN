Imports C1.Win.C1FlexGrid

Public Class FrmhorasCliente
    Dim cs As New ClsConsultas
    Dim dt As New DataTable
    Dim msj As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width


    Private Sub FrmhorasCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        fg(0, 1) = "Codigo Empleado"
        fg(0, 2) = "Codigo Empresa"
        fg(0, 3) = "Fecha"
        fg(0, 4) = "Horas"
        fg(0, 5) = "Departamento"
        fg(0, 6) = "Hora"
        fg(0, 7) = "Minutos"

    End Sub

    Private Sub BtConsultar_Click(sender As Object, e As EventArgs) Handles BtConsultar.Click

        Dim scr = "Select a.*, b.COD_DEPART," &
                    " FLOOR(horas) As hora," &
                    " a.horas-FLOOR(horas) As minutos" &
                    " from TB_HORAS_EXTRAS As a" &
                    " left join tb_empleado As b On a.COD_EMPLEADO = b.CODIGO" &
                    " where FECHA between '" & DatInicio.Value & "' and '" & datFin.Value & "'"

        If cs.consultas(scr, dt, msj) Then
            fg.Rows.Count = dt.Rows.Count + 1
            For i = 0 To dt.Rows.Count - 1
                fg(i + 1, 1) = dt.Rows(i)("cod_empleado")
                fg(i + 1, 2) = dt.Rows(i)("cod_empresa")
                fg(i + 1, 3) = dt.Rows(i)("fecha")
                fg(i + 1, 4) = dt.Rows(i)("horas")
                fg(i + 1, 5) = dt.Rows(i)("cod_depart")
                fg(i + 1, 6) = dt.Rows(i)("hora")
                fg(i + 1, 7) = dt.Rows(i)("minutos")
            Next
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            My.Computer.FileSystem.DeleteFile("C:\Plan_rep\repRh.xls", FileIO.UIOption.AllDialogs,
               FileIO.RecycleOption.SendToRecycleBin,
               FileIO.UICancelOption.DoNothing)
        Catch
        End Try

        fg.SaveGrid("C:\Plan_rep\" & "repRh.xls", C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells)
        Dim pathPDF As String = "C:\Plan_rep\repRh.xls"
        Process.Start(pathPDF)

    End Sub
End Class