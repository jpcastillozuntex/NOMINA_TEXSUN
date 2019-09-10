Public Class FrmEliminaFaltasinMarca
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim dtmes As New DataTable
    Dim dt As New DataTable
    Dim dt_dept As New DataTable
    Dim dt_cod As New DataTable
    Dim dt_mont As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim empresa As Integer = 1
    Dim f As String = "yyyy-MM-dd"
    Dim fila As Integer

    Private Sub FrmBonifciacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        fg.Rows(0).Height = 31
        fg.Rows.Count = 1
        Consultar()
    End Sub

    Private Sub Consultar()
        dt_cod.Rows.Clear()
        scr = "select a.*, nombre,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO from TB_FALTA AS A" &
                " LEFT JOIN TB_EMPLEADO AS B ON A.CODIGO = B.CODIGO " &
                " where fecha between (select inicio from TB_CICLO_NOMINA where estado = 'A') and (select fin from TB_CICLO_NOMINA where estado = 'A')"

        If cs.consultas(scr, dt_cod, msj) Then
            fg.Rows.Count = dt_cod.Rows.Count + 1
            For i = 0 To dt_cod.Rows.Count - 1
                fg(i + 1, 1) = dt_cod.Rows(i)("CODIGO")
                fg(i + 1, 2) = dt_cod.Rows(i)("FECHA")
                fg(i + 1, 3) = dt_cod.Rows(i)("NOMBRE") & " " & dt_cod.Rows(i)("SEGUNDO_NOMBRE") & " " & dt_cod.Rows(i)("APELLIDO") & " " & dt_cod.Rows(i)("SEGUNDO_APELLIDO")
                'fg(i + 1, 4) = dt_cod.Rows(i)("HORAS")
            Next
        End If
    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles fg.Click
        fila = fg.RowSel
        If fg(fila, 5) = True Then
            scr = "delete from TB_FALTA where codigo = " & fg(fila, 1) & " and fecha = '" & fg(fila, 2) & "'"
            If cs.eliminar(scr, msj) Then
                MsgBox("! Permiso Eliminado¡")
                Consultar()
            Else
            End If
        End If
    End Sub

End Class