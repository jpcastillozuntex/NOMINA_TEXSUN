Public Class FrmDetanticipo
    Dim codigo As String = FrmAnticipo.num_anticipo
    Dim consulta As New ClsConsultas
    Dim nombre As String = FrmAnticipo.nombre
    Dim dt As New DataTable
    Dim msj As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width

    Private Sub FrmDetanticipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - (455 / 2)
        Me.Left = l / 2 - (827 / 2)
        Dim script As String = "select * from tb_det_anticipo where num_anticipo = " & codigo
        If consulta.consultas(script, dt, msj) = False Then
            MsgBox("NO SE PUEDE MOSTRAR DETALLE")
        Else
            Txtnombre.Text = nombre
            Dim cont As Integer = dt.Rows.Count
            fg.Rows.Count = dt.Rows.Count + 1
            For i = 0 To cont - 1
                fg(i + 1, 1) = dt.Rows(i)("num_anticipo")
                fg(i + 1, 2) = dt.Rows(i)("numero_cuota")
                fg(i + 1, 3) = dt.Rows(i)("monto_cuota")
                fg(i + 1, 4) = dt.Rows(i)("ANIO")
                fg(i + 1, 5) = dt.Rows(i)("MES")
                fg(i + 1, 6) = dt.Rows(i)("QUINCENA")
                fg(i + 1, 7) = dt.Rows(i)("estado")
                If fg(i + 1, 7) = "P" Then
                    fg.SetCellStyle(i + 1, 7, fg.Styles("CustomStyle1"))
                ElseIf fg(i + 1, 7) = "A" Then
                    fg.SetCellStyle(i + 1, 7, fg.Styles("CustomStyle2"))
                End If
            Next
        End If
    End Sub
End Class