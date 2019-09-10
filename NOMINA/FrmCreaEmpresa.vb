Imports System.Drawing.Drawing2D

Public Class FrMCreaEmpresa
    Dim Ancho As Single
    Dim Alto As Single
    Dim Porcentaje As Single
    Dim imagen As Image
    Dim scr As String
    Dim cs As New ClsConsultas
    Dim msj As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width

    Private Sub FrMCreaEmpresa_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
    End Sub

    Public Sub BtExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtExaminar.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim result As New DialogResult
        openFileDialog1.InitialDirectory = "Bibliotecas\Imágenes"
        openFileDialog1.Filter = "archivos de imagen (*.jpg)|*.png|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 3
        openFileDialog1.RestoreDirectory = True
        result = openFileDialog1.ShowDialog()
        If (result = DialogResult.OK) Then
            Picture1.Image = Image.FromFile(openFileDialog1.FileName)
            Try
                imagen = Picture1.Image
                If imagen.Height > 75 Or imagen.Width > 75 Then
                    imagen = RedimensionarImagen(imagen)
                End If
                Picture1.Image = imagen
            Catch ex As Exception
                MsgBox("No se pudo cargar la imagen " & Chr(13) & Chr(10) & MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Function RedimensionarImagen(ByVal Imagen As Image) As Image
        Dim BitMap As New Bitmap(Imagen)
        Imagen = Nothing
        Imagen = BitMap.GetThumbnailImage(379, 150, Nothing, IntPtr.Zero)
        Return Imagen
    End Function

    Private Sub BtGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtGuardar.Click
        Dim MemoriaImg As New IO.MemoryStream
        Try
            Picture1.Image.Save(MemoriaImg, Imaging.ImageFormat.Png)
        Catch
        End Try
        If TxtNombre.Text = "" Or TxtDireccion.Text = "" Or TxtTelefono.Text = "" Then
        Else
            scr = "INSERT INTO TB_EMPRESA (CODIGO,NOMBRE_EMPRESA,DIRECCION,TELEFONO,COD_IGSS,FAX,LOGO) VALUES ((SELECT COUNT(1)+1 FROM TB_EMPRESA), '" & _
                     TxtNombre.Text & "','" & TxtDireccion.Text & "','" & TxtTelefono.Text & "','" & TxtIgss.Text & "','" & Txtfax.Text & "',"
            If cs.guarda_empresa(scr, MemoriaImg, TxtNombre.Text, msj) Then
                MsgBox("DATOS GUARDADOS CORRECTAMENTE.")
            Else
                MsgBox(msj)
            End If
        End If
    End Sub
End Class