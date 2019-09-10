Public Class FrmPermisos
    Dim cs As New ClsConsultas
    Dim sal As String
    Dim ent As String
    Dim f As String = "yyy-MM-dd"
    Dim y As String = "dd-MM-yyyy"
    Dim h As String = "H:mm"
    Dim msj As String
    Dim dt As New DataTable
    Dim Lt As New DataTable
    Dim horas As TimeSpan
    Dim doble As Double
    Dim scr As String
    Dim dtNombre As New DataTable
    Dim empresa As Integer = FrmInicio.empresa
    'Dim empresa As Integer = 1


    Private Sub FrmPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DatSalida.Format = DateTimePickerFormat.Time
        DatSalida.ShowUpDown = True
        Datent.Format = DateTimePickerFormat.Time
        Datent.ShowUpDown = True
        scr = "select * from TB_CATPERMISO"
        Try
            cs.consultas(scr, Lt, msj)
            CbMotivo.DataSource = Lt
            CbMotivo.DisplayMember = "DESCRIPCION"
            CbMotivo.ValueMember = "COD_PERMISO"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub Btguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btguardar.Click
        Dim ff As String = "yyyy-MM-dd H:mm"
        If Txtcod.Text Is Nothing Or TxtHoras.Text Is Nothing Then
        Else
            Dim sale As String = Format(DatSalida.Value, h).ToString
            Dim entra As String = Format(Datent.Value, h).ToString
            Dim fecha As String = Format(Datfec.Value, y).ToString
            Dim fecha2 As String = Format(Datfec.Value, f).ToString
            sal = sale
            Dim salida As String = Format(sal, ff)
            ent = entra
            Dim scr As String = "select COUNT(1) from tb_permiso where cod_empresa = " & empresa & " and CODIGO = " & Txtcod.Text & " and fecha ='" & fecha2 & "'"
            Dim script As String = "insert into tb_permiso (CODIGO,COD_EMPRESA,FECHA,HORA_SALIDA,HORA_ENTRADA,HORAS,COMENTARIOS,COD_PERMISO) values (" & _
                Txtcod.Text & "," & empresa & ",'" & fecha & "','" & sal & "','" & ent & "','" & TxtHoras.Text & "','" & TxtComent.Text & "'," & CbMotivo.SelectedValue & ")"
            If cs.permiso(script, scr, msj) = True Then
                MsgBox("DATOS GUARDADOS")
            Else
                MsgBox(msj)
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHoras.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtcod_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtcod.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtHoras_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtHoras.GotFocus

    End Sub

    Private Sub Txtcod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Txtcod_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txtcod.LostFocus
        LbNombre.Text = ""
        Dim scp As String = "select nombre, segundo_nombre, apellido, segundo_apellido,marca from tb_empleado where codigo_empresa = " & empresa & " and codigo = " & Txtcod.Text
        If cs.consultas(scp, dtNombre, msj) = True Then
            If dtNombre.Rows(0)("marca") = "S" Then
                LbNombre.BackColor = Color.White
                LbNombre.Text = dtNombre.Rows(0)("nombre") & " " & dtNombre.Rows(0)("segundo_nombre")
                LbApellido.Text = dtNombre.Rows(0)("apellido") & " " & dtNombre.Rows(0)("segundo_apellido")
            ElseIf dtNombre.Rows(0)("marca") = "N" Then
                LbApellido.Text = ""
                LbNombre.Text = "ESTE EMPLEADO NO MARCA"
                LbNombre.BackColor = Color.Yellow
            End If
        Else
            LbNombre.Text = "CODIGO NO EXISTE"
            LbApellido.Text = ""
            LbNombre.BackColor = Color.Red
            Txtcod.Focus()
        End If

    End Sub


    Private Sub Datent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Datent.LostFocus
        horas = Datent.Value.Subtract(DatSalida.Value)
        'TxtHoras.Text = horas.ToString
        'doble = Convert.ToDouble(horas)
        doble = horas.TotalHours
        TxtHoras.Text = Format(doble, "00.00")
    End Sub

    Private Sub Txtcod_TextChanged_2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtcod.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Datfec.Focus()
        End If
    End Sub

End Class