Public Class FrmFormatoLibroSal
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim msj As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width

    Private Sub FrmFormatoLibroSal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l - 20, a - 40)
        Me.Top = a - (a - 40 / 2)
        Me.Left = l - (l - 20 / 2)
    End Sub

    Private Sub Btimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btimprimir.Click
        If TxtDesde.Text = "" Or Txthasta.Text = "" Or TxtDesde.Text > Txthasta.Text Then
            MsgBox("INGRESE INTERVALOS DE IMPRESION")
        Else
            scr = " delete from TEMP_NUM;" & _
                    " declare @conta as integer = " & TxtDesde.Text & "-1" & _
                    " WHILE @conta + 1  <= " & Txthasta.Text & _
                    " begin" & _
                    " set @conta = @conta + 1" & _
                    " insert into TEMP_NUM values (@conta)" & _
                    " End"
            If cs.procedure(scr, msj) Then
            Else
                MsgBox(msj)
            End If

            Cursor = Cursors.WaitCursor
            Try
                rp.Load("C:\Plan_rep\nomina.flxr", "libro_sal_encabezado")
                rp.DataSource.ConnectionString = cs.con
                rp.DataSource.RecordSource = "select * from TEMP_NUM"
                rp.Render()
                Fv.DocumentSource = rp

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Txtmonto_Changed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDesde.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub txthasta_changed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txthasta.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

End Class