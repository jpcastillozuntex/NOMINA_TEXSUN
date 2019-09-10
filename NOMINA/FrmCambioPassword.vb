Public Class FrmCambioPassword
    Dim foto = FrmInicio.foto_U
    Dim usuario = FrmInicio.nombre
    Dim pass_ant = FrmInicio.TextBox1.Text
    Dim scr As String
    Dim cs As New ClsConsultas
    Dim msj As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width


    Private Sub FrmCambioPassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - (Me.Height / 2)
        Me.Left = l / 2 - (Me.Width / 2)
        LbNombre.Text = usuario
        Redimensionarfoto(foto)
        Pbfoto.Image = foto
        TxtPanterior.Text = pass_ant
        TxtPnuevo2.Enabled = False
        Btguardar.Enabled = False
    End Sub

    Private Sub TxtPanterior_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPnuevo1.TextChanged
        If TxtPnuevo1.Text.Length < 6 Then
            TxtPnuevo1.BackColor = Color.Yellow
            TxtPnuevo2.Enabled = False
        Else
            TxtPnuevo1.BackColor = Color.LightGreen
            TxtPnuevo2.Enabled = True
        End If
    End Sub

    Private Function Redimensionarfoto(ByRef imagen As Image) As Image
        Dim BitMap As New Bitmap(imagen)
        imagen = Nothing
        imagen = BitMap.GetThumbnailImage(251, 233, Nothing, IntPtr.Zero)
        Return imagen
    End Function

    Private Sub TxtPnuevo2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPnuevo2.TextChanged
        If TxtPnuevo2.Text <> TxtPnuevo1.Text Then
            TxtPnuevo2.BackColor = Color.Yellow
            Btguardar.Enabled = False
        Else
            TxtPnuevo2.BackColor = Color.LightGreen
            Btguardar.Enabled = True
        End If
    End Sub


    Private Sub Btguardar_Click(sender As System.Object, e As System.EventArgs) Handles Btguardar.Click
        If TxtPnuevo1.Text <> TxtPnuevo2.Text Then
            mensajes.Text = "deben de coincidir las dos casillas de password nuevo"
        Else
            scr = "UPDATE TB_USUARIO SET PASSWORD ='" & TxtPnuevo1.Text & "' WHERE PASSWORD ='" & pass_ant & "'"
            If cs.procedure(scr, msj) Then
                MsgBox("PASSWORD ACTUALIZADO")
            End If
        End If
    End Sub

    Private Sub mensajes_Click(sender As System.Object, e As System.EventArgs) Handles mensajes.Click

    End Sub
End Class