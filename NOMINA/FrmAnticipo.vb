
Public Class FrmAnticipo
    Dim consulta As New ClsConsultas
    Dim mensaje As String
    Dim dt As New DataTable
    Dim f As Integer
    Public num_anticipo As Integer
    Public codigo As String
    'Dim empresa = 1
    Public nombre As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim empresa = FrmInicio.CbEmpresa.SelectedValue
    
    Private Sub FrmAnticipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fg.Rows(0).Height = 25
        Me.Top = a / 2 - (537 / 2)
        Me.Left = l / 2 - (991 / 2)
        fg.Rows.Count = 1
    End Sub

    Private Sub busca()
        For i = 2 To fg.Rows.Count
            fg.SetCellStyle(i - 1, 6, fg.Styles("FirstCustomStyle"))
            fg(i - 1, 1) = Nothing
            fg(i - 1, 2) = Nothing
            fg(i - 1, 3) = Nothing
            fg(i - 1, 4) = Nothing
            fg(i - 1, 5) = Nothing
            fg(i - 1, 6) = Nothing
            fg(i - 1, 7) = Nothing
        Next
        dt.Clear()
        If consulta.detdesc(empresa, Txtcodigo.Text, dt, mensaje) = True Then
            fg.Rows.Count = dt.Rows.Count + 1
            Dim cont As Integer = dt.Rows.Count
            For i = 0 To cont - 1
                fg(i + 1, 1) = dt.Rows(i)("num_anticipo")
                fg(i + 1, 2) = dt.Rows(i)("nombre") & " " & dt.Rows(i)("segundo_nombre") & " " & dt.Rows(i)("apellido")
                fg(i + 1, 3) = dt.Rows(i)("num_cuotas")
                fg(i + 1, 4) = dt.Rows(i)("fec_anticipo")
                fg(i + 1, 5) = dt.Rows(i)("num_documento")
                fg(i + 1, 6) = dt.Rows(i)("total_anticipo")
                fg(i + 1, 7) = dt.Rows(i)("saldo")
                If dt.Rows(i)("saldo") Is DBNull.Value Then
                    fg(i + 1, 7) = 0
                End If
                fg(i + 1, 8) = dt.Rows(i)("descripcion")
                If fg(i + 1, 7) > 0 Then
                    fg.SetCellStyle(i + 1, 7, fg.Styles("CustomStyle1"))
                End If
            Next
        End If
    End Sub

    Public Sub fg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fg.DoubleClick
        f = fg.RowSel
        num_anticipo = fg(f, 1)
        nombre = fg(f, 2)
        Dim scr As String = "select * from tb_det_anticipo where num_anticipo = " & num_anticipo
        Dim table As New DataTable
        If consulta.consultas(scr, table, mensaje) = True Then
            If table.Rows.Count > 0 Then
                FrmDetanticipo.Show()
            End If
        Else
            MsgBox("SIN DATELLE")
        End If
    End Sub

    Private Sub Txtcodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcodigo.LostFocus
        Dim nombre As String = ""
        Dim scp As String = "select isnull(' '+nombre,'')+isnull(' '+apellido,'')+isnull(' '+segundo_apellido,'') from tb_empleado where codigo_empresa = " & empresa & " and codigo = " & Txtcodigo.Text
        If consulta.csescalar(nombre, scp, mensaje) = True Then
            Lb1.Text = nombre
        End If
    End Sub

    Private Sub Txtcodigo_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles Txtcodigo.TextChanged
        busca()
    End Sub

    Private Sub Txtnombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txtnombre.TextChanged

    End Sub


End Class