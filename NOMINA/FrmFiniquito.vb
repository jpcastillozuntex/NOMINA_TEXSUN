Public Class FrmFiniquito
    Dim cs As New ClsConsultas
    Dim cadena As String = "CODIGO"
    Dim codigo As String
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    ' Dim empresa As Integer = 1
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width

    Private Sub FrmFiniquito_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l - 20, a - 40)
        Me.Top = a - (a - 40 / 2)
        Me.Left = l - (l - 20 / 2)
        TxtCodigoX.Text = cadena
        TxtCodigoX.ForeColor = Color.LightGray
        AddHandler TxtCodigoX.GotFocus, AddressOf GotfocusTexto
        AddHandler TxtCodigoX.LostFocus, AddressOf LostfocusTexto
    End Sub

    Private Sub GotfocusTexto(ByVal sender As Object, ByVal e As System.EventArgs)
        codigo = sender.Text
        TxtCodigoX.Text = ""
        sender.ForeColor = Color.Black
    End Sub

    Private Sub LostfocusTexto(ByVal sender As Object, ByVal e As System.EventArgs)
        If sender.Text = "" Then
            sender.Text = cadena
            codigo = ""
            sender.ForeColor = Color.LightGray
        End If
    End Sub

    Private Sub BtBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtBuscar.Click
        If codigo = "" Then
            MsgBox("INGRESE CODIGO")
        Else
            report.Load("C:\Plan_rep\nomina.flxr", "finiquito_laboral")
            report.DataSource.ConnectionString = cs.con
            Dim strsql As String = "select a.nombre,a.segundo_nombre, a.apellido, a.segundo_apellido, a.dpi, c.nombre_municipio,b.nombre_puesto,d.nombre,e.Nombre_empresa,a.fec_alta,a.Sueldo_base,f.bonificacion,a.direccion,e.telefono,e.fax,fec_nacimiento,estado_civil,fec_baja" & _
                " from TB_EMPLEADO as a, TB_PUESTOS as b , TB_MUNICIPIO as c,TB_DEPARTAMENTO as d, TB_EMPRESA as e, TB_PARAMETROS as f" & _
                " where a.codigo = " & TxtCodigoX.Text & _
                " and Codigo_empresa = " & empresa & _
                " and a.codigo_puesto= b.codigo" & _
                " and a.cod_municipio = c.codigo" & _
                " and a.cod_departamento= c.cod_departamento" & _
                " and a.cod_departamento = d.codigo_departamento" & _
                " and a.Codigo_empresa = e.Codigo" & _
                " and a.Codigo_empresa = f.cod_empresa"
            Try
                Cursor = Cursors.WaitCursor
                report.DataSource.RecordSource = strsql
                report.Render()
                Fv.DocumentSource = report
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigoX.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub


End Class