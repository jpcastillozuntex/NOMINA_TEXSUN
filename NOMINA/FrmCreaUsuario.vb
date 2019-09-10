Public Class FrmCreaUsuario
    Dim cs As New ClsConsultas
    Dim dt As New DataTable
    Dim mensaje As String
    Dim y As String = "yyyy-MM-dd"
    Dim fec As Date
    Dim scr As String
    Dim msj As String
    Dim dt_cod As New DataTable
    Dim dt_perfil As New DataTable
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim estado As String
    Dim cont As Integer
    Dim imagen As Image
    Dim dt_dats As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    Dim stmBLOBData As IO.MemoryStream

    Private Sub Frmnuevoanticipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - (537 / 2)
        Me.Left = l / 2 - (752 / 2)
        crea_dt()
        Combo_perfil()
        CbEstado.SelectedIndex = 0
    End Sub

    Private Sub crea_dt()
        dt.Columns.Add("usuario")
        dt.Columns.Add("nombre")
        dt.Columns.Add("password")
        dt.Columns.Add("desc_rol")
        dt.Columns.Add("estado")
        dt.Columns.Add("cod_idrol")
        dt.Columns.Add("fecha")
        dt.AcceptChanges()
    End Sub
    
    Private Sub Combo_perfil()
        scr = "SELECT IDROL,ROL_DESCRIPCION FROM TC_ROL"
        cs.consultas(scr, dt_perfil, msj)
        Cbperfil.DataSource = dt_perfil
        Cbperfil.SelectedIndex = mes - 1
        Cbperfil.DisplayMember = "ROL_DESCRIPCION"
        Cbperfil.ValueMember = "IDROL"
    End Sub

    Private Sub BtGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGuardar.Click
        dt.Clear()
        If TxtUsuario.Text = Nothing Or TxtNombre.Text = Nothing Or TxtPass.Text = Nothing Or TxtConfPass.Text <> TxtPass.Text Then
            mensajes.Text = "FALTAN DATOS..!!"
        Else
            Dim dtr As DataRow = dt.NewRow
            dtr("usuario") = TxtUsuario.Text
            dtr("nombre") = TxtNombre.Text
            dtr("password") = TxtPass.Text
            dtr("desc_rol") = Cbperfil.Text
            dtr("estado") = CbEstado.Text
            dtr("cod_idrol") = Cbperfil.SelectedValue
            dtr("fecha") = Format(DatFecha.Value, y)
            dt.Rows.Add(dtr)
            dt.AcceptChanges()
            Dim stmBLOBData As New IO.MemoryStream
            Try
                picture1.Image.Save(stmBLOBData, Imaging.ImageFormat.Png)
            Catch
            End Try
            If cs.usuario(dt, stmBLOBData, mensaje) = True Then
                MsgBox("DATOS GUARDADOS")
                limpia()
            Else
                MsgBox(mensaje)
            End If
        End If
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
            picture1.Image = Image.FromFile(openFileDialog1.FileName)
            Try
                imagen = picture1.Image
                If imagen.Height > 75 Or imagen.Width > 75 Then
                    imagen = RedimensionarImagen(imagen)
                End If
                picture1.Image = imagen
            Catch ex As Exception
                MsgBox("No se pudo cargar la imagen " & Chr(13) & Chr(10) & MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Function RedimensionarImagen(ByVal Imagen As Image) As Image
        Dim BitMap As New Bitmap(Imagen)
        Imagen = Nothing
        Imagen = BitMap.GetThumbnailImage(232, 227, Nothing, IntPtr.Zero)
        Return Imagen
    End Function

    Private Sub limpia()
        TxtNombre.Text = Nothing
        TxtPass.Text = Nothing
        TxtConfPass.Text = Nothing
        DatFecha.Value = Today
        CbEstado.SelectedIndex = 0
        Cbperfil.SelectedIndex = 0
        picture1.Image = Nothing
        TxtConfPass.BackColor = Color.White
    End Sub

    Private Sub TxtUsuario_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtUsuario.TextChanged
        scr = "SELECT * FROM TB_USUARIO WHERE USUARIO = '" & TxtUsuario.Text & "'"
        If cs.consultas(scr, dt_dats, msj) Then
            TxtNombre.Text = dt_dats.Rows(0)("NOMBRE_USUARIO")
            TxtPass.Text = dt_dats.Rows(0)("PASSWORD")
            TxtConfPass.Text = dt_dats.Rows(0)("PASSWORD")
            Cbperfil.Text = dt_dats.Rows(0)("DESC_ROL")
            CbEstado.Text = dt_dats.Rows(0)("ESTADO")
            DatFecha.Value = dt_dats.Rows(0)("FECHA")
            Dim image As Image
            Try
                Dim bytBLOBData() As Byte = dt_dats.Rows(0)("FOTO")
                stmBLOBData = New IO.MemoryStream(bytBLOBData)
                image = Image.FromStream(stmBLOBData)
                RedimensionarImagen(image)
                picture1.Image = image
            Catch ex As Exception
            End Try
        Else
            limpia()
        End If
    End Sub

    Private Sub TxtConfPass_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtConfPass.TextChanged
        If TxtPass.Text = TxtConfPass.Text Then
            TxtConfPass.BackColor = Color.Green
        Else
            TxtConfPass.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub TxtPass_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPass.TextChanged
        If TxtPass.Text = TxtConfPass.Text Then
            TxtConfPass.BackColor = Color.Green
        ElseIf TxtPass.Text <> TxtConfPass.Text And TxtConfPass.Text <> "" Then
            TxtConfPass.BackColor = Color.Yellow
        End If
    End Sub
End Class