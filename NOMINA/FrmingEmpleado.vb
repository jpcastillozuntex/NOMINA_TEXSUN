Imports System.Data.SqlClient

Public Class FrmIngEmpleado
    Dim Imagen As Image
    Dim sexo As String
    Dim frecuencia As String
    Dim pago As String
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim cant_exist As Integer
    Dim msj As String
    Dim tb_empresa As New DataTable
    Dim tb_depart As New DataTable
    Dim tb_pais As New DataTable
    Dim tb_estado As New DataTable
    Dim tb_tipo As New DataTable
    Dim tb_puesto As New DataTable
    Dim tb_centro As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim datos As New DataTable
    Dim dt_emp_paga As New DataTable

    Private Sub FrmAgregarPer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        llena_Cbox()
        crea_tabla()
    End Sub

    Private Sub llena_Cbox()
        cb_empresa()
        cb_depart()
        cb_pais()
        cb_tipo()
        cb_puesto()
        cb_empresa_paga()
        cb_centro()
    End Sub

    Private Sub TxtEmpresa_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cs.AsignaCodigo(LbCodigo.Text, TxtEmpresa.SelectedValue, msj, "01")
    End Sub

    Private Sub cb_empresa()
        scr = "SELECT NOMBRE_EMPRESA, CODIGO FROM TB_EMPRESA"
        If cs.consultas(scr, tb_empresa, msj) Then
            TxtEmpresa.DataSource = tb_empresa
            TxtEmpresa.DisplayMember = "nombre_empresa"
            TxtEmpresa.ValueMember = "codigo"
        Else
            MsgBox(msj)
        End If
    End Sub

    Private Sub cb_centro()
        scr = "SELECT * FROM TB_CENTRO_COSTO"
        If cs.consultas(scr, tb_centro, msj) Then
            CbCentoCosto.DataSource = tb_centro
            CbCentoCosto.DisplayMember = "CENTRO_COSTO"
            CbCentoCosto.ValueMember = "CODIGO"
        Else
            MsgBox(msj)
        End If
    End Sub

    Private Sub cb_depart()
        scr = "SELECT NOMBRE,COD_DEPAR FROM TB_DEPTOS_EMPRESA "
        cs.consultas(scr, tb_depart, msj)
        TxtDepar.DataSource = tb_depart
        TxtDepar.DisplayMember = "nombre"
        TxtDepar.ValueMember = "cod_depar"
    End Sub

    Private Sub cb_empresa_paga()
        scr = "SELECT * FROM TB_EMP_PAGA"
        cs.consultas(scr, dt_emp_paga, msj)
        CbEmPaga.DataSource = dt_emp_paga
        CbEmPaga.DisplayMember = "nombre"
        CbEmPaga.ValueMember = "codigo"
        CbEmPaga.SelectedIndex = 0
    End Sub

    Private Sub cb_pais()
        scr = "SELECT CODIGO_PAIS, NOMBRE_PAIS FROM TB_PAIS"
        cs.consultas(scr, tb_pais, msj)
        TxtPais.DataSource = tb_pais
        TxtPais.DisplayMember = "nombre_pais"
        TxtPais.ValueMember = "codigo_pais"
    End Sub


    Private Sub cb_tipo()
        scr = "SELECT NOMBRE_TIPO, CODIGO_TIPO FROM TB_TIPO_EMPLEADO"
        cs.consultas(scr, tb_tipo, msj)
        CbTipoEmpleado.DataSource = tb_tipo
        CbTipoEmpleado.ValueMember = "codigo_tipo"
        CbTipoEmpleado.DisplayMember = "nombre_tipo"
    End Sub

    Private Sub cb_puesto()
        scr = "SELECT CODIGO, NOMBRE_PUESTO FROM TB_PUESTOS"
        cs.consultas(scr, tb_puesto, msj)
        CbPuesto.DataSource = tb_puesto
        CbPuesto.DisplayMember = "Nombre_puesto"
        CbPuesto.ValueMember = "Codigo"
    End Sub

    Private Sub crea_tabla()
        datos.Columns.Add("codigo")
        datos.Columns.Add("codigo_empresa")
        datos.Columns.Add("cod_depart")
        datos.Columns.Add("nombre")
        datos.Columns.Add("segundo_nombre")
        datos.Columns.Add("Apellido")
        datos.Columns.Add("segundo_apellido")
        datos.Columns.Add("dpi")
        datos.Columns.Add("cod_departamento")
        datos.Columns.Add("cod_municipio")
        datos.Columns.Add("telefono")
        datos.Columns.Add("direccion")
        datos.Columns.Add("sexo")
        datos.Columns.Add("estado_civil")
        datos.Columns.Add("nit")
        datos.Columns.Add("cod_pais")
        datos.Columns.Add("fec_alta")
        datos.Columns.Add("Fec_nacimiento")
        datos.Columns.Add("frecuencia_pago")
        datos.Columns.Add("codigo_puesto")
        datos.Columns.Add("afiliacion_igss")
        datos.Columns.Add("num_cuenta")
        datos.Columns.Add("tipo_empleado")
        datos.Columns.Add("apellido_casada")
        datos.Columns.Add("num_hijos")
        datos.Columns.Add("nombre_esposo")
        datos.Columns.Add("tipo_pago")
        datos.Columns.Add("id_foto")
        datos.Columns.Add("sueldo_base")
        datos.Columns.Add("bonific")
        datos.Columns.Add("codigo_reloj")
        datos.Columns.Add("turno")
        datos.Columns.Add("marca")
        datos.Columns.Add("af_irtra")
        datos.Columns.Add("horas_extras")
        datos.Columns.Add("emp_paga")
        datos.Columns.Add("locker")
        datos.Columns.Add("centro_costo")
        datos.AcceptChanges()
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
            PbFoto.Image = Image.FromFile(openFileDialog1.FileName)
            Try
                Imagen = PbFoto.Image
                If Imagen.Height > 75 Or Imagen.Width > 75 Then
                    Imagen = RedimensionarImagen(Imagen)
                End If
                PbFoto.Image = Imagen
            Catch ex As Exception
                MsgBox("No se pudo cargar la imagen " & Chr(13) & Chr(10) & MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Function RedimensionarImagen(ByVal Imagen As Image) As Image
        Dim BitMap As New Bitmap(Imagen)
        Imagen = Nothing
        Imagen = BitMap.GetThumbnailImage(315, 298, Nothing, IntPtr.Zero)
        Return Imagen
    End Function

    Private Sub BtGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGuardar.Click
        Dim turno As String = ""
        Dim horas_extras As String = ""
        Dim marca As String = ""
        datos.Clear()
        If RbFemenino.Checked = True Then
            sexo = "F"
        Else : RbMasculino.Checked = True
            sexo = "M"
        End If
        If RbSemanal.Checked = True Then
            frecuencia = "8"
        ElseIf RbQuincenal.Checked = True Then
            frecuencia = "15"
        End If
        If RbCheque.Checked = True Then
            pago = "C"
        ElseIf RbDeposito.Checked = True Then
            pago = "D"
        End If
        If RbMarcaSi.Checked = True Then
            marca = "S"
        ElseIf RbMarcaNo.Checked = True Then
            marca = "N"
        End If
        If Rbhorassi.Checked = True Then
            horas_extras = "S"
        ElseIf RbhorasNo.Checked = True Then
            horas_extras = "N"
        End If
        If RbMat.Checked = True Then
            turno = "MAT"
        ElseIf Rbnoc.Checked = True Then
            turno = "NOC"
        End If

        '''''''''''''''''''''''''''''''''valida varialbes obligatorias
        If (TxtEmpresa.ValueMember Is Nothing Or TxtDepar.ValueMember = "" Or TxtNombre.Text = "" Or TxtApellido.Text = "" Or TxtDpi.Text = "" Or Txtdep.Text = "" Or TxtMun.Text = "" Or TxtDireccion.Text = "" Or sexo = "" Or frecuencia = "" Or CbPuesto.SelectedValue Is Nothing Or CbTipoEmpleado.SelectedValue Is Nothing Or pago = "" Or turno = "" Or horas_extras = "" Or marca = "") Then
            MsgBox("FALTAN DATOS QUE LLENAR")
        Else
            ''''''''llena datatable con columnas dinamicas desde el form
            Dim msj As String = ""
            If cs.AsignaCodigo(LbCodigo.Text, TxtEmpresa.SelectedValue, msj, TxtDepar.SelectedValue) Then
                MsgBox("EL CODIGO A ASIGNAR ES: " + LbCodigo.Text)
            End If

            Dim dr As DataRow = datos.NewRow
            dr("Codigo") = LbCodigo.Text
            dr("codigo_empresa") = TxtEmpresa.SelectedValue
            dr("cod_depart") = TxtDepar.SelectedValue
            dr("nombre") = TxtNombre.Text
            dr("segundo_nombre") = Txt2Nombre.Text
            dr("Apellido") = TxtApellido.Text
            dr("segundo_apellido") = Txt2Apellido.Text
            dr("dpi") = TxtDpi.Text
            dr("cod_departamento") = Txtdep.Text
            dr("cod_municipio") = TxtMun.Text
            dr("telefono") = TxtTelefono.Text
            dr("Direccion") = TxtDireccion.Text
            dr("sexo") = sexo
            dr("estado_civil") = CbEstadoCivil.Text
            dr("nit") = Txtnit.Text
            dr("cod_pais") = TxtPais.SelectedValue
            dr("fec_alta") = Format(DatAlta.Value, "yyyy-MM-dd")
            dr("fec_nacimiento") = Format(DatNacimiento.Value, "yyyy-MM-dd")
            dr("frecuencia_pago") = frecuencia
            dr("codigo_puesto") = CbPuesto.SelectedValue
            dr("afiliacion_igss") = TxtAfigss.Text
            dr("num_cuenta") = TxtCuenta.Text
            dr("tipo_empleado") = CbTipoEmpleado.SelectedValue
            dr("apellido_casada") = TxtApellidoCasa.Text
            dr("num_hijos") = TxtNumhijos.Text
            dr("nombre_esposo") = TxtEsposo.Text
            dr("tipo_pago") = pago
            dr("id_foto") = LbCodigo.Text
            dr("sueldo_base") = TxtSueldobase.Text.ToString
            dr("codigo_reloj") = TxtCodigoreloj.Text
            dr("bonific") = TextBox1.Text
            dr("turno") = turno
            dr("marca") = marca
            dr("af_irtra") = TxtIrtra.Text
            dr("horas_extras") = horas_extras
            dr("emp_paga") = CbEmPaga.SelectedValue
            dr("locker") = TxtLocker.Text
            dr("centro_costo") = CbCentoCosto.SelectedValue
            datos.Rows.Add(dr)
            datos.AcceptChanges()
            ''''''llama a la funcion que hara el insert a la bd
            Dim mensaje As String = ""
            '''''''''''''''''''''''''''''''
            scr = "select COUNT(1) from TB_EMPLEADO where nit = '" & Txtnit.Text & "' and estado_empleado IN ('A','S') and nit <>'' "
            If cs.csescalar(cant_exist, scr, msj) Then
                If cant_exist > 0 Then
                    MsgBox("ESTE NIT YA EXISTE")
                    Exit Sub
                Else
                    If (cs.InsertaEmpleado(datos, mensaje)) = True Then
                        MsgBox("DATOS GURADADOS CORRECTAMENTE")
                        cs.enviar_alerta(LbCodigo.Text)

                        If PbFoto.Image Is Nothing Then
                            limpia()
                        Else
                            Dim MemoriaImg As New IO.MemoryStream
                            PbFoto.Image.Save(MemoriaImg, Imaging.ImageFormat.Png)
                            If cs.guardarfoto(LbCodigo.Text, TxtEmpresa.SelectedValue, MemoriaImg, msj) Then
                                limpia()
                            End If
                        End If
                    Else
                        MsgBox(mensaje)
                    End If
                End If
            End If
            '''''''''''''''''''''''''''''''''
        End If
    End Sub



    Private Sub limpia()
        Dim ctl As Object
        For Each ctl In Me.Controls
            If TypeOf ctl Is RadioButton Then
                ctl.Value = False
            ElseIf TypeOf ctl Is TextBox Then
                ctl.Text = Nothing
            End If
        Next
        PbFoto.Image = Nothing
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCancelar.Click
        Me.Close()
    End Sub

    Private Sub TxtEmpresa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEmpresa.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtDepar.Focus()
        End If
    End Sub

    '' definicion de enter para los campos
    Private Sub TxtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Txt2Nombre.Focus()
        End If
    End Sub

    Private Sub Txt2Nombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt2Nombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtApellido.Focus()
        End If
    End Sub

    Private Sub TxtDepar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDepar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtNombre.Focus()
        End If
    End Sub

    Private Sub Txt2Apellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt2Apellido.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtDpi.Focus()
        End If
    End Sub

    Private Sub TxtDpi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDpi.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtPais.Focus()
        End If
    End Sub

    Private Sub TxtPais_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPais.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Txtdep.Focus()
        End If
    End Sub

    Private Sub TxtDepartamento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtdep.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtMun.Focus()
        End If
    End Sub

    Private Sub CbmMunicipio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMun.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtTelefono.Focus()
        End If
    End Sub

    Private Sub TxtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefono.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtDireccion.Focus()
        End If
    End Sub

    Private Sub TxtDireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDireccion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            GroupBox1.Focus()
        End If
    End Sub

    Private Sub GroupBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GroupBox1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Cbestadocivil.Focus()
        End If
    End Sub

    Private Sub TxtEstadocivil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbEstadoCivil.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Txtnit.Focus()
        End If
    End Sub

    Private Sub Txtnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtnit.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtIrtra.Focus()
        End If
    End Sub

    Private Sub Txtafirtra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIrtra.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            DatAlta.Focus()
        End If
    End Sub


    Private Sub DatAlta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatAlta.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            DatNacimiento.Focus()
        End If
    End Sub

    Private Sub DatNacimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatNacimiento.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            GroupBox3.Focus()
        End If
    End Sub

    Private Sub GroupBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GroupBox3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            CbPuesto.Focus()
        End If
    End Sub

    Private Sub CbPuesto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbPuesto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtAfigss.Focus()
        End If
    End Sub

    Private Sub TxtAfigss_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAfigss.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtCuenta.Focus()
        End If
    End Sub

    Private Sub TxtCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuenta.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            CbTipoEmpleado.Focus()
        End If
    End Sub

    Private Sub CbTipoempleado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbTipoEmpleado.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtNumhijos.Focus()
        End If
    End Sub

    Private Sub TxtApellidoCasa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtApellidoCasa.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtNumhijos.Focus()
        End If
    End Sub

    Private Sub TxtNumhijos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumhijos.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtEsposo.Focus()
        End If
    End Sub

    Private Sub TxtEsposo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEsposo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtApellidoCasa.Focus()
        End If
    End Sub

    Private Sub GroupBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GroupBox2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtSueldobase.Focus()
        End If
    End Sub

    Private Sub TxtSueldobase_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSueldobase.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtCodigoreloj.Focus()
        End If
    End Sub

    Private Sub TxtCodigoreloj_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoreloj.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            BtExaminar.Focus()
        End If
    End Sub

    Private Sub TxtApellido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtApellido.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Txt2Apellido.Focus()
        End If
    End Sub


    Private Sub Texdep_text(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtdep.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub


    Private Sub Texmun_text(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMun.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtdpi_text(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDpi.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtnombre_text(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged
        Me.TxtNombre.Text = UCase(Me.TxtNombre.Text)
        Me.TxtNombre.SelectionStart = Me.TxtNombre.TextLength + 1
    End Sub

    Private Sub txt2nombre_text(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt2Nombre.TextChanged
        Me.Txt2Nombre.Text = UCase(Me.Txt2Nombre.Text)
        Me.Txt2Nombre.SelectionStart = Me.Txt2Nombre.TextLength + 1
    End Sub

    Private Sub txtapellido_text(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtApellido.TextChanged
        Me.TxtApellido.Text = UCase(Me.TxtApellido.Text)
        Me.TxtApellido.SelectionStart = Me.TxtApellido.TextLength + 1
    End Sub


    Private Sub txt2apellido_text(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt2Apellido.TextChanged
        Me.Txt2Apellido.Text = UCase(Me.Txt2Apellido.Text)
        Me.Txt2Apellido.SelectionStart = Me.Txt2Apellido.TextLength + 1
    End Sub

    Private Sub txtdireccion_text(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDireccion.TextChanged
        Me.TxtDireccion.Text = UCase(Me.TxtDireccion.Text)
        Me.TxtDireccion.SelectionStart = Me.TxtDireccion.TextLength + 1
    End Sub

    Private Sub TxtApellidoCasa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtApellidoCasa.TextChanged
        Me.TxtApellidoCasa.Text = UCase(Me.TxtApellidoCasa.Text)
        Me.TxtApellidoCasa.SelectionStart = Me.TxtApellidoCasa.TextLength + 1
    End Sub

    Private Sub TxtEsposo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEsposo.TextChanged
        Me.TxtEsposo.Text = UCase(Me.TxtEsposo.Text)
        Me.TxtEsposo.SelectionStart = Me.TxtEsposo.TextLength + 1
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumhijos.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub numr_reloj_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoreloj.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtdpi_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDpi.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
    Private Sub txttelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefono.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    '  Private Sub txtlocker_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLocker.KeyPress
    '      If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
    '          e.Handled = True
    '      End If
    '  End Sub
    '
End Class

