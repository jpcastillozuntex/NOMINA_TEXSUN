Imports System.Deployment
Imports System.Deployment.Application

Public Class FrmInicio
    Dim cs As New ClsConsultas
    Dim dt As New DataTable
    Dim dt_empresa As New DataTable
    Dim scr As String
    Dim msj As String
    Public nombre As String
    Public perfil As Integer
    Dim GblRutaApp As String = "C:\Plan_rep\iconos"
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim dt_p As New DataTable
    'Dim io_imagen As IO.MemoryStream
    Public foto_U As Image
    Public empresa As Integer
    Public IGSS As Double
    Public HORA_EXTRA As String
    Public BONIFICACION As Double
    Public SALARIO_DIARIO As Double
    Public BON_PROD As String
    Public JORNADA As String
    Public RELOJES As Integer
    Public CIERRE As Integer
    Public DIA_CIERRE As Integer
    Public ENTRADA As String
    Public SALIDA As String
    Public SALARIO_IND As String
    Public SABADO As String
    Public ENT_SABADO As String
    Public SAL_SABADO As String
    Public stmBLOBData As IO.MemoryStream
    Public image As Image
    Private Sub Login_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l, a - 40)
        Me.Top = 0
        Me.Left = 0
        TxtNombre.Visible = False
        CbEmpresa.Visible = False
        LbEmpresa.Visible = False
        Foto.Visible = False
        Try
            'If Shell("xcopy \\PROGRAMACION\Programas\programas\import\import /s c:\import /y") Then
            'End If
        Catch
        End Try
    End Sub

    Private Sub CrearMenu()
        Dim cs As New ClsConsultas
        Dim Listado As New DataTable
        Dim Mensaje As String = ""
        If cs.Listamenu(1, perfil, Listado, Mensaje) Then
            Dim Datos As New DataView(Listado, "Cod_Padre IS null ", "Cod_Menu", DataViewRowState.CurrentRows)
            CrearHijos(Datos, Listado, Nothing)
        End If
        'CbEmpresa.SelectedIndex = 0
    End Sub

    Private Sub CrearHijos(ByVal Datos As DataView, ByVal DatosMenu As DataTable, ByVal MenuPadre As ToolStripMenuItem)
        Dim I As Integer
        For I = 0 To Datos.Count - 1
            Dim MenuHijo As New ToolStripMenuItem(Datos(I)("Titulo").ToString, IconoMenu(Datos(I)("icono").ToString),
            New EventHandler(AddressOf MenuItem_Click), Datos(I)("cod_menu").ToString)
            MenuHijo.ToolTipText = Datos(I)("ToolTip").ToString
            If Datos(I)("cod_menu") = 25 Then
                MenuHijo.BackColor = Color.Turquoise
            Else
                MenuHijo.BackColor = Color.Turquoise
            End If
            If MenuPadre Is Nothing Then
                menu.Items.Add(MenuHijo)
            Else
                MenuPadre.DropDownItems.Add(MenuHijo)
            End If
            Dim Hijos As New DataView(DatosMenu, "Cod_Padre = '" & Datos(I)("Cod_Menu") & "'", "Cod_Menu", DataViewRowState.CurrentRows)
            CrearHijos(Hijos, DatosMenu, MenuHijo)
        Next
    End Sub

    Private Function IconoMenu(ByVal Ruta As String) As Image
        Dim Icono As Image
        Try
            Icono = Image.FromFile(GblRutaApp & "\" & Ruta.Replace("/", "\"))
        Catch ex As Exception
            Icono = Nothing
        End Try
        Return Icono
    End Function

    Private Sub MenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim my_sender As Object = sender.Name
        If TypeOf sender Is ToolStripMenuItem Then
            Select Case sender.Name
                Case "2"
                    FrmIngEmpleado.Show(Me)
                Case "3"
                    FrmModEmpleados.Show(Me)
                Case "4"
                    FrmImpContrato.Show(Me)
                Case "5"
                    FrmCarnet.Show(Me)
                Case "6"
                    FrmCaptaTurno.Show(Me)
                Case "7"
                    FrmMarcajes.Show(Me)
                Case "8"
                    FrmHorasExtras.Show(Me)
                Case "9"
                    FrmPermisos.Show(Me)
                Case "10"
                    FrmFaltas.Show(Me)
                Case "11"
                    FrmSuspension.Show(Me)
                Case "12"
                    FrmDescuentos.Show(Me)
                Case "13"
                    Frmnuevoanticipo.Show(Me)
                Case "14"
                    FrmBonificacion.Show(Me)
                Case "15"
                    FrmVacaciones.Show(Me)
                Case "16"
                    FrmCalcVaca.Show(Me)
                Case "17"
                    Frm_Pre_nomina.Show(Me)
                Case "18"
                    FrmAsuetos.Show(Me)
                Case "21"
                    FrmNomina.Show(Me)
                Case "20"
                    Try
                        If Shell("xcopy \\PROGRAMACION\Programas\programas\vb2010\Nomina_gen\reports /s c:\Plan_rep /y") Then
                            MsgBox("version Actualizada:" & My.Application.Info.Version.ToString, MsgBoxStyle.Information, "NOMINA")
                        End If
                    Catch ex As Exception
                        MsgBox("Ocurrio un Error de:" & ex.Message)
                    End Try
                Case "22"
                    FrmCierreNomina.Show(Me)
                Case "23"
                    FrmArchBancoNomina.Show(Me)
                Case "24"
                    Frmcomprobante.Show(Me)
                Case "25"
                    FrmConstanciaLaboral.Show(Me)
                Case "26"
                    FrmBono14.Show(Me)
                Case "27"
                    FrmAguinaldo.Show(Me)
                Case "29"
                    FrmBaja.Show(Me)
                Case "30"
                    FrmComprobantePagobono14.Show(Me)
                Case "31"
                    Frmcomprobante_aguina.Show(Me)
                Case "32"
                    FrmConsultaEmp.Show(Me)
                Case "33"
                    Frmreportesaldos.Show(Me)
                Case "34"
                    FrmConstLaboralBaja.Show(Me)
                Case "35"
                    FrmAnticipo.Show(Me)
                Case "36"
                    FrmFormatoLibroSal.Show(Me)
                Case "37"
                    FrmLibroSalarios.Show(Me)
                Case "38"
                    FrmBajaPrueba.Show(Me)
                Case "40"
                    FrMCreaEmpresa.Show(Me)
                Case "39"
                    FrmParametros.Show(Me)
                Case "41"
                    FrmCreacionCiclos.Show(Me)
                Case "42"
                    FrmDeptosEmpresa.Show(Me)
                Case "43"
                    FrmCreaPuestos.Show(Me)
                Case "44"
                    FrmCreaUsuario.Show(Me)
                Case "45"
                    FrmIsr.Show(Me)
                Case "46"
                    FrmPoliza15.Show(Me)
                Case "47"
                    FrmRepBonificacion.Show(Me)
                Case "48"
                    FrmReportesuspensiones.Show(Me)
                Case "49"
                    FrmreportePermisos.Show(Me)
                Case "51"
                    Frmcodigosreloj.Show(Me)
                Case "52"
                    FrmRepDescuentos.Show(Me)
                Case "53"
                    FrmRepIsr.Show(Me)
                Case "54"
                    FrmFaltas_Marca.Show(Me)
                Case "56"
                    FrmRepConta.Show(Me)
                Case "57"
                    FrmConsultVacas.Show(Me)
                Case "58"
                    FrmCargaMateriales.Show(Me)
                Case "59"
                    frmPruebas1.Show(Me)
                Case "61"
                    FrmCambioPassword.Show(Me)
                Case "62"
                    FrmFiniquito.Show(Me)
                Case "63"
                    Frmamonestacion.Show(Me)
                Case "64"
                    FrmAccesos.Show(Me)
                Case "65"
                    FrmEliminaPermiso.Show(Me)
                Case "66"
                    FrmSalarios.Show(Me)
                Case "67"
                    FrmEliminaFalta.Show(Me)
                Case "68"
                    FrmNuevaPoliza15.Show(Me)
                Case "69"
                    FrmCierreEmp.Show(Me)
                Case "70"
                    FrmPolizaCentroCosto.Show(Me)
                Case "82"
                    FrmISRquincenal.Show(Me)
                Case "83"
                    frmCarnetZebra.Show(Me)
                Case "84"
                    frmCarnetConfi.Show(Me)
                Case "90"
                    FrmNominaExcel.Show(Me)
                Case "87"
                    FrmEliminaDescuentos.Show(Me)
                Case "89"
                    FrmAjustes.Show(Me)
                Case "300"
                    About.Show(Me)
                Case "88"
                    FrmLibroSalario.Show(Me)
                Case "91"
                    frmCarnetcirculacion.Show(Me)
                Case "94"
                    FrmBdRecursos.Show(Me)

            End Select
        End If
    End Sub

    Private Sub BtAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtAceptar.Click
        If cs.login(TextBox1.Text, nombre, perfil, msj, foto_U) Then
            scr = "SELECT * FROM TB_EMPRESA"
            cs.consultas(scr, dt_empresa, msj)
            CbEmpresa.DataSource = dt_empresa
            CbEmpresa.DisplayMember = "NOMBRE_EMPRESA"
            CbEmpresa.ValueMember = "CODIGO"
            CbEmpresa.Visible = True
            TxtNombre.Visible = True
            LbEmpresa.Visible = True
            CrearMenu()
            password.Enabled = False
            TextBox1.Enabled = False
            password.Visible = False
            BtAceptar.Enabled = False
            lbPassword.Visible = False
            TxtNombre.Text = nombre
            Foto.Visible = True
            Try
                Redimensionarfoto(foto_U)
                Foto.Image = foto_U
            Catch
            End Try
        Else
            Txt_msj.Text = msj
        End If
    End Sub

    Private Sub CbEmpresa_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CbEmpresa.SelectionChangeCommitted, CbEmpresa.SelectedValueChanged
        Dim byImagen() As Byte = Nothing
        Dim i As Integer
        'stmBLOBData As IO.MemoryStream
        ' Dim image As Image
        Try
            i = CbEmpresa.SelectedIndex
            Dim bytBLOBData() As Byte = dt_empresa.Rows(i)("logo")
            stmBLOBData = New IO.MemoryStream(bytBLOBData)
            image = Image.FromStream(stmBLOBData)
            RedimensionarImagen(image)
            Pblogo.Image = image
        Catch ex As Exception
        End Try
        Try
            scr = "SELECT * FROM TB_PARAMETROS WHERE COD_EMPRESA = " & CbEmpresa.SelectedValue
            If cs.consultas(scr, dt_p, msj) Then
                empresa = dt_p.Rows(0)("COD_EMPRESA")
                IGSS = (dt_p.Rows(0)("IGSS"))
                HORA_EXTRA = (dt_p.Rows(0)("HORA_EXTRA"))
                BONIFICACION = dt_p.Rows(0)("BONIFICACION")
                SALARIO_DIARIO = dt_p.Rows(0)("SALARIO_DIARIO")
                BON_PROD = dt_p.Rows(0)("BON_PROD")
                JORNADA = dt_p.Rows(0)("JORNADA")
                RELOJES = dt_p.Rows(0)("RELOJES")
                CIERRE = dt_p.Rows(0)("CIERRE")
                DIA_CIERRE = dt_p.Rows(0)("DIA_CIERRE")
                ENTRADA = dt_p.Rows(0)("ENTRADA")
                SALIDA = dt_p.Rows(0)("SALIDA")
                SALARIO_IND = dt_p.Rows(0)("SALARIO_IND")
                SABADO = dt_p.Rows(0)("SABADO")
                ENT_SABADO = dt_p.Rows(0)("ENT_SABADO")
                SAL_SABADO = dt_p.Rows(0)("SAL_SABADO")
            End If
        Catch
        End Try
    End Sub

    Private Function RedimensionarImagen(ByRef Imagen As Image) As Image
        Dim BitMap As New Bitmap(Imagen)
        Imagen = Nothing
        Imagen = BitMap.GetThumbnailImage(260, 104, Nothing, IntPtr.Zero)
        Return Imagen
    End Function

    Private Function Redimensionarfoto(ByRef Imagen As Image) As Image
        Dim BitMap As New Bitmap(Imagen)
        Imagen = Nothing
        Imagen = BitMap.GetThumbnailImage(163, 150, Nothing, IntPtr.Zero)
        Return Imagen
    End Function

End Class
