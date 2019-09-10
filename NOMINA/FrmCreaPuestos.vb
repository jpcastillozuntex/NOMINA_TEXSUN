Public Class FrmCreaPuestos
    Dim scr As String
    Dim cs As New ClsConsultas
    Dim dt As New DataTable
    Dim msj As String
    Dim dt_t As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.Bounds.Height
    Dim l As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim fila As Integer
    Dim row As Integer

    Private Sub FrmGuardaMedidas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fg.Rows(0).Height = 30
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        llena_fg()

        dt_t.Columns.Add("CODIGO")
        dt_t.Columns.Add("NOMBRE_PUESTO")
        dt_t.Columns.Add("DESCRIPCION")
        dt_t.AcceptChanges()

    End Sub

    Private Sub llena_fg()
        limpia()
        scr = "SELECT * FROM TB_PUESTOS"
        cs.consultas(scr, dt, msj)
        fg.Rows.Count = dt.Rows.Count + 3
        For i = 0 To dt.Rows.Count - 1
            fg(i + 1, 1) = dt.Rows(i)("CODIGO")
            fg(i + 1, 2) = dt.Rows(i)("NOMBRE_PUESTO")
            fg(i + 1, 3) = dt.Rows(i)("DESCRIPCION")
        Next
    End Sub

    Private Sub limpia()
        For i = 1 To fg.Rows.Count - 1
            fg(i, 1) = Nothing
            fg(i, 2) = Nothing
            fg(i, 3) = Nothing
        Next
    End Sub

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        dt_t.Clear()
        For i = 1 To fg.Rows.Count - 1
            If fg(i, 1) Is Nothing Or fg(i, 2) Is Nothing Then
            Else
                Dim dtr As DataRow = dt_t.NewRow
                dtr("CODIGO") = fg(i, 1)
                dtr("NOMBRE_PUESTO") = fg(i, 2)
                dtr("DESCRIPCION") = fg(i, 3)
                dt_t.Rows.Add(dtr)
                dt_t.AcceptChanges()
            End If
        Next
        cs.guarda_puestos(dt_t, msj)
        llena_fg()
    End Sub


    Private Sub fg_Click(sender As System.Object, e As System.EventArgs) Handles fg.Click
        fila = fg.RowSel
        row = fg.ColSel
        If fila < 0 Or fg(fila, 1) Is Nothing Or row <> 4 Then
        Else
            Try
                scr = "DELETE FROM TB_PUESTOS WHERE CODIGO = '" & fg(fila, 1) & "'"
                If cs.procedure(scr, msj) Then
                    llena_fg()
                Else
                    MsgBox(msj)
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

End Class