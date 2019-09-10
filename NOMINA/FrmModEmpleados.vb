Imports System.Data.SqlClient
Imports System.IO
Imports System.Security

Public Class FrmModEmpleados
    Dim Imagen As Image
    Dim sexo As String
    Dim frecuencia As String
    Dim pago As String
    Dim cs As New ClsConsultas
    Dim scr As String
    Dim cant_exist As Integer
    Dim msj As String
    Dim dt_select_d As New DataTable
    Dim tb_empresa As New DataTable
    Dim tb_depart As New DataTable
    Dim tb_pais As New DataTable
    Dim tb_estado As New DataTable
    Dim tb_tipo As New DataTable
    Dim tb_puesto As New DataTable
    Dim dt_codigo As New DataTable
    Dim dt_codigos As New DataTable
    Dim dt_emp_paga As New DataTable
    Dim dt_centro As New DataTable
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim datos As New DataTable
    Dim turno As String = ""
    Dim horas_extras As String = ""
    Dim marca As String = ""
    Dim foto As IO.MemoryStream
    Dim lbcodigo As String
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    Dim Myfile As System.IO.FileStream
    Dim dt_deptofin As New DataTable
    Dim perfil = FrmInicio.perfil
    ' Dim empresa As Integer = 1

    Private Sub FrmAgregarPer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If perfil <> 5 Then
            CbDeptoFin.Enabled = False
        End If
        Btregresar.Visible = False
        BtGuardar.Enabled = False
        Boton_contrato.Enabled = False
        Boton_constancia.Enabled = False
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
        llena_Cbox()
        crea_tabla()
        cb_centro()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles BtBuscar.Click
        Btregresar.Visible = True
        CbCodigo.Enabled = False


        If CbCodigo.Text = "" Then
            MsgBox("NO EXISTE NINGUN EMPLEADO CON ESE NOMBRE")
        End If
        scr = "select A.CODIGO,B.NOMBRE_EMPRESA,A.CODIGO_EMPRESA,E.NOMBRE AS NOMBRE_DEPAR,A.NOMBRE,SEGUNDO_NOMBRE,APELLIDO,SEGUNDO_APELLIDO,DPI,A.COD_DEPARTAMENTO,A.COD_MUNICIPIO,A.TELEFONO,A.DIRECCION,SEXO,ESTADO_CIVIL," & _
        "NIT, C.NOMBRE_PAIS, FEC_ALTA, FEC_BAJA, FEC_NACIMIENTO, FRECUENCIA_PAGO, g.NOMBRE_PUESTO, AFILIACION_IGSS, NUM_CUENTA, i.DESCRIPCION, h.NOMBRE_TIPO, APELLIDO_CASADA, NUM_HIJOS, NOMBRE_ESPOSO, TIPO_PAGO," & _
        "a.ID_FOTO, SUELDO_BASE, BONIFICACION,CODIGO_RELOJ, NUM_LOCKER, VAC_LIQ, MARCA, TURNO, AF_IRTRA, HORAS_EX, K.NOMBRE as EMP_PAGA,A.LOCKER,A.ESTADO_EMPLEADO,A.CENTRO_COSTO,CENTRO" & _
        " from TB_EMPLEADO AS A " & _
        " LEFT JOIN TB_EMPRESA AS B ON B.CODIGO = A.CODIGO_EMPRESA" & _
        " LEFT JOIN TB_PAIS AS C ON C.CODIGO_PAIS = A.COD_PAIS" & _
        " LEFT JOIN TB_DEPARTAMENTO AS D ON D.CODIGO_DEPARTAMENTO = A.COD_DEPARTAMENTO" & _
        " LEFT JOIN TB_DEPTOS_EMPRESA AS E on e.COD_DEPAR= a.COD_DEPART" & _
        " LEFT JOIN TB_MUNICIPIO AS F on F.CODIGO = A.COD_MUNICIPIO and f.COD_DEPARTAMENTO= a.COD_DEPARTAMENTO" & _
        " LEFT JOIN TB_PUESTOS AS G ON G.CODIGO = A.CODIGO_PUESTO" & _
        " LEFT JOIN TB_TIPO_EMPLEADO AS H ON H.CODIGO_TIPO = TIPO_EMPLEADO" & _
        " LEFT JOIN TB_ESTADO_EMPLEADO AS I ON I.CODIGO_ESTADO = ESTADO_EMPLEADO" & _
        " LEFT JOIN TB_FOTO AS J ON J.CODIGO_EMPLEADO= A.ID_FOTO" & _
        " left join TB_EMP_PAGA AS K ON A.EMP_PAGA = K.CODIGO" & _
        " WHERE A.CODIGO = " & CbCodigo.Text & " AND A.CODIGO_EMPRESA = " & empresa
        Try
            If cs.consultas(scr, dt_select_d, msj) Then
                BtGuardar.Enabled = True
                If dt_select_d.Rows(0)("turno") = "MAT" Then
                    RbMat.Checked = True
                ElseIf dt_select_d.Rows(0)("turno") = "NOC" Then
                    Rbnoc.Checked = True
                End If
                If dt_select_d.Rows(0)("SEXO") = "M" Then
                    RbMasculino.Checked = True
                ElseIf dt_select_d.Rows(0)("SEXO") = "F" Then
                    RbFemenino.Checked = True
                End If
                If dt_select_d.Rows(0)("FRECUENCIA_PAGO") = "8" Then
                    RbSemanal.Checked = True
                ElseIf dt_select_d.Rows(0)("FRECUENCIA_PAGO") = "15" Then
                    RbQuincenal.Checked = True
                End If
                If dt_select_d.Rows(0)("TIPO_PAGO") = "C" Then
                    RbCheque.Checked = True
                ElseIf dt_select_d.Rows(0)("TIPO_PAGO") = "D" Then
                    RbDeposito.Checked = True
                End If
                If dt_select_d.Rows(0)("MARCA") = "S" Then
                    RbMarcaSi.Checked = True
                ElseIf dt_select_d.Rows(0)("MARCA") = "N" Then
                    RbMarcaNo.Checked = True
                End If
                If dt_select_d.Rows(0)("HORAS_EX") = "S" Then
                    Rbhorassi.Checked = True
                ElseIf dt_select_d.Rows(0)("HORAS_EX") = "N" Then
                    RbhorasNo.Checked = True
                End If
                'empresa = dt_select_d.Rows(0)("nombre_empresa")
                TxtDepar.Text = dt_select_d.Rows(0)("nombre_depar")
                TxtNombre.Text = dt_select_d.Rows(0)("nombre").ToString
                Txt2Nombre.Text = dt_select_d.Rows(0)("segundo_nombre").ToString
                TxtApellido.Text = dt_select_d.Rows(0)("Apellido").ToString
                Txt2Apellido.Text = dt_select_d.Rows(0)("segundo_apellido").ToString
                TxtDpi.Text = dt_select_d.Rows(0)("dpi").ToString
                Txtdep.Text = dt_select_d.Rows(0)("cod_departamento")
                TxtMun.Text = dt_select_d.Rows(0)("cod_municipio")
                TxtTelefono.Text = dt_select_d.Rows(0)("telefono").ToString
                TxtDireccion.Text = dt_select_d.Rows(0)("Direccion").ToString
                sexo = dt_select_d.Rows(0)("sexo")
                CbEstadoCivil.Text = dt_select_d.Rows(0)("estado_civil")
                Txtnit.Text = dt_select_d.Rows(0)("nit")
                TxtPais.Text = dt_select_d.Rows(0)("NOMBRE_pais")
                DatAlta.Value = dt_select_d.Rows(0)("fec_alta")
                DatNacimiento.Value = dt_select_d.Rows(0)("fec_nacimiento")
                frecuencia = dt_select_d.Rows(0)("frecuencia_pago")
                CbPuesto.Text = dt_select_d.Rows(0)("nombre_puesto").ToString
                TxtAfigss.Text = dt_select_d.Rows(0)("afiliacion_igss").ToString
                TxtCuenta.Text = dt_select_d.Rows(0)("num_cuenta").ToString
                CbTipoEmpleado.Text = dt_select_d.Rows(0)("nombre_tipo").ToString
                TxtApellidoCasa.Text = dt_select_d.Rows(0)("apellido_casada").ToString
                TxtNumhijos.Text = dt_select_d.Rows(0)("num_hijos").ToString
                TxtEsposo.Text = dt_select_d.Rows(0)("nombre_esposo").ToString
                pago = dt_select_d.Rows(0)("tipo_pago")
                TxtSueldobase.Text = dt_select_d.Rows(0)("sueldo_base").ToString
                TxtBonif.Text = dt_select_d.Rows(0)("bonificacion").ToString
                TxtCodigoreloj.Text = dt_select_d.Rows(0)("codigo_reloj")
                marca = dt_select_d.Rows(0)("marca").ToString
                TxtIrtra.Text = dt_select_d.Rows(0)("af_irtra").ToString
                horas_extras = dt_select_d.Rows(0)("horas_ex").ToString
                CbEmpPaga.Text = dt_select_d.Rows(0)("emp_paga").ToString
                TxtLocker.Text = dt_select_d.Rows(0)("locker").ToString
                CbEstado.Text = dt_select_d.Rows(0)("Estado_empleado").ToString
                CbCentoCosto.SelectedValue = dt_select_d.Rows(0)("centro_costo").ToString
                CbDeptoFin.SelectedValue = dt_select_d.Rows(0)("centro").ToString
                Boton_constancia.Enabled = True
                Boton_contrato.Enabled = True
                Bt_ver_ctr.Enabled = True
                Bt_ver_cnst.Enabled = True
                path_constancia.Text = ""
                path_contrato.Text = ""
            End If
        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
        If cs.obtienefoto(CbCodigo.Text, empresa, foto, msj) = True Then
            PbFoto.Image = Image.FromStream(foto)
        Else
            PbFoto.Image = Nothing
        End If
    End Sub

    Private Sub requi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        cs.AutoCompletar(CbCodigo, e)
    End Sub

    Private Sub llena_Cbox()
        cb_codigo()
        ' cb_empresa()
        cb_depart()
        cb_pais()
        cb_tipo()
        cb_puesto()
        cb_emp_paga()
        cb_centro()
        cb_deptofinan()
    End Sub

    Private Sub cb_deptofinan()
        scr = "select * from TB_CENTROS WHERE TIPO_RuBRO = '02'"
        cs.consultas(scr, dt_deptofin, msj)
        CbDeptoFin.DataSource = dt_deptofin
        CbDeptoFin.ValueMember = "codigo"
        CbDeptoFin.DisplayMember = "nombre"
        CbDeptoFin.SelectedIndex = 0
    End Sub

    Private Sub cb_depart()
        scr = "SELECT NOMBRE,COD_DEPAR FROM TB_DEPTOS_EMPRESA"
        cs.consultas(scr, tb_depart, msj)
        TxtDepar.DataSource = tb_depart
        TxtDepar.DisplayMember = "nombre"
        TxtDepar.ValueMember = "cod_depar"
    End Sub

    Private Sub cb_centro()
        scr = "SELECT * FROM TB_CENTRO_COSTO order by centro_costo"
        If cs.consultas(scr, dt_centro, msj) Then
            CbCentoCosto.DataSource = dt_centro
            CbCentoCosto.DisplayMember = "CENTRO_COSTO"
            CbCentoCosto.ValueMember = "CODIGO"
        Else
            MsgBox(msj)
        End If
    End Sub

    Private Sub cb_pais()
        scr = "SELECT CODIGO_PAIS, NOMBRE_PAIS FROM TB_PAIS"
        cs.consultas(scr, tb_pais, msj)
        TxtPais.DataSource = tb_pais
        TxtPais.DisplayMember = "nombre_pais"
        TxtPais.ValueMember = "codigo_pais"
    End Sub

    Private Sub cb_emp_paga()
        scr = "SELECT * FROM TB_EMP_PAGA"
        cs.consultas(scr, dt_emp_paga, msj)
        CbEmpPaga.DataSource = dt_emp_paga
        CbEmpPaga.DisplayMember = "nombre"
        CbEmpPaga.ValueMember = "codigo"
        CbEmpPaga.SelectedIndex = 1
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

    Private Sub cb_codigo()
        Try
            scr = "SELECT CODIGO FROM TB_EMPLEADO WHERE ESTADO_EMPLEADO IN ('A','S')"
            cs.consultas(scr, dt_codigo, msj)
            CbCodigo.DataSource = dt_codigo
            CbCodigo.DisplayMember = "CODIGO"
            CbCodigo.ValueMember = "CODIGO"
        Catch
        End Try
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
        datos.Columns.Add("bonificacion")
        datos.Columns.Add("codigo_reloj")
        datos.Columns.Add("turno")
        datos.Columns.Add("marca")
        datos.Columns.Add("af_irtra")
        datos.Columns.Add("horas_extras")
        datos.Columns.Add("emp_paga")
        datos.Columns.Add("estado_empleado")
        datos.Columns.Add("locker")
        datos.Columns.Add("centro_costo")
        datos.Columns.Add("centro")
        datos.AcceptChanges()
    End Sub

    Public Sub actualiza()
        Try
            Using fs = New System.IO.FileStream("c:\Plan_rep\foto_g.jpg", FileMode.Open)
                Dim bmp = New Bitmap(fs)
                PbFoto.Image = DirectCast(bmp.Clone(), Bitmap)
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
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
        If TxtDepar.ValueMember Is Nothing Or TxtNombre.Text = "" Or TxtApellido.Text = "" Or TxtDpi.Text = "" Or Txtdep.Text = "" Or TxtMun.Text = "" Or TxtDireccion.Text = "" Or sexo = "" Or frecuencia = "" Or CbPuesto.SelectedValue Is Nothing Or CbTipoEmpleado.SelectedValue Is Nothing Or pago = "" Or turno = "" Or horas_extras = "" Or marca = "" Then
            MsgBox("FALTAN DATOS QUE LLENAR")
        Else
            ''''''''llena datatable con columnas dinamicas desde el form
            Dim dr As DataRow = datos.NewRow
            dr("Codigo") = CbCodigo.Text
            dr("codigo_empresa") = empresa
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
            dr("sueldo_base") = TxtSueldobase.Text.ToString
            dr("bonificacion") = TxtBonif.Text.ToString
            dr("codigo_reloj") = TxtCodigoreloj.Text
            dr("turno") = turno
            dr("marca") = marca
            dr("af_irtra") = TxtIrtra.Text
            dr("horas_extras") = horas_extras
            dr("emp_paga") = CbEmpPaga.SelectedValue
            dr("locker") = TxtLocker.Text
            dr("estado_empleado") = CbEstado.Text
            dr("centro_costo") = CbCentoCosto.SelectedValue
            dr("centro") = CbDeptoFin.SelectedValue
            datos.Rows.Add(dr)
            datos.AcceptChanges()
            ''''''llama a la funcion que hara el insert a la bd
            Dim mensaje As String = ""
            If cs.updatedatos(datos, CbCodigo.Text, empresa, mensaje) = True Then
                If path_constancia.Text = "" Then
                Else
                    Open_copi_constancia()
                End If
                If path_contrato.Text = "" Then
                Else
                    Open_Remote_Connection()
                End If
                MsgBox("DATOS GURADADOS CORRECTAMENTE")
                If PbFoto.Image Is Nothing Then
                    limpia()
                    regresa()
                Else
                    Dim MemoriaImg As New IO.MemoryStream
                    PbFoto.Image.Save(MemoriaImg, Imaging.ImageFormat.Png)
                    If cs.guardarfoto(CbCodigo.Text, empresa, MemoriaImg, msj) Then
                        limpia()
                        regresa()
                    Else
                        MsgBox(msj)
                    End If
                End If
            Else
                MsgBox(mensaje)
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Boton_contrato.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim result As New DialogResult
        openFileDialog1.InitialDirectory = "Bibliotecas\"
        openFileDialog1.Filter = "archivos de imagen (*.pdf)|*.pdf"
        openFileDialog1.FilterIndex = 3
        openFileDialog1.RestoreDirectory = True
        result = openFileDialog1.ShowDialog()
        If (result = DialogResult.OK) Then
            Myfile = File.OpenRead(openFileDialog1.FileName)
            path_contrato.Text = openFileDialog1.FileName
        End If
    End Sub

    Private Sub Boton_constancia_Click(sender As System.Object, e As System.EventArgs) Handles Boton_constancia.Click
        Dim openFileDialog1 As New OpenFileDialog()
        Dim result As New DialogResult
        openFileDialog1.InitialDirectory = "Bibliotecas\"
        openFileDialog1.Filter = "archivos de imagen (*.pdf)|*.pdf"
        openFileDialog1.FilterIndex = 3
        openFileDialog1.RestoreDirectory = True
        result = openFileDialog1.ShowDialog()
        If (result = DialogResult.OK) Then
            Myfile = File.OpenRead(openFileDialog1.FileName)
            path_constancia.Text = openFileDialog1.FileName
        End If
    End Sub

    Private Sub Open_Remote_Connection()
        Dim dir As String = "\\192.9.200.11\Nomina$\" & CbCodigo.Text & ".pdf"
        Try
            My.Computer.FileSystem.DeleteFile(dir)
        Catch ex As Exception
        End Try
        Try
            File.Copy(path_contrato.Text, dir, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Open_copi_constancia()
        Dim dir As String = "\\192.9.200.11\Nomina$\" & CbCodigo.Text & "Cons.pdf"
        Try
            My.Computer.FileSystem.DeleteFile(dir)
        Catch ex As Exception
        End Try
        Try
            File.Copy(path_constancia.Text, dir, True)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        path_contrato.Text = ""
        path_constancia.Text = ""
        PbFoto.Image = Nothing
        CbCodigo.Focus()
    End Sub

    Private Sub BtCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub TxtEmpresa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtDepar.Focus()
        End If
    End Sub

    Private Sub regresa()
        BtBuscar.Enabled = True
        Btregresar.Visible = False
        CbCodigo.Enabled = True
        BtGuardar.Enabled = False
        Boton_contrato.Enabled = False
        Boton_constancia.Enabled = False
        Bt_ver_ctr.Enabled = False
        Bt_ver_cnst.Enabled = False
    End Sub

    Private Sub Bt_ver_ctr_Click(sender As System.Object, e As System.EventArgs) Handles Bt_ver_ctr.Click
        Dim dir As String = "\\192.9.200.11\Nomina$\" & CbCodigo.Text & ".pdf"
        AxAcroPDF1.src = dir
        AxAcroPDF1.Refresh()
    End Sub

    Private Sub Bt_ver_cnst_Click(sender As System.Object, e As System.EventArgs) Handles Bt_ver_cnst.Click
        Dim dir As String = "\\192.9.200.11\Nomina$\" & CbCodigo.Text & "Cons.pdf"
        Try
            AxAcroPDF1.src = dir
            AxAcroPDF1.Refresh()
        Catch ex As Exception
            MsgBox("")
        End Try
    End Sub

    Private Sub CbCodigo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CbCodigo.KeyPress
        cs.AutoCompletar(CbCodigo, e)
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
            CbEstadoCivil.Focus()
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

    'Private Sub txtnombre_text(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNombre.TextChanged
    '    Me.TxtNombre.Text = UCase(Me.TxtNombre.Text)
    '    Me.TxtNombre.SelectionStart = Me.TxtNombre.TextLength + 1
    'End Sub

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

    Private Sub Btregresar_Click(sender As System.Object, e As System.EventArgs) Handles Btregresar.Click
        regresa()
        limpia()
    End Sub

    Private Sub TabPage1_Click(sender As System.Object, e As System.EventArgs) Handles TabPage1.Click

    End Sub


    Private Sub CbDeptoFin_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CbDeptoFin.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Form1.ShowDialog(Me)
    End Sub
End Class

