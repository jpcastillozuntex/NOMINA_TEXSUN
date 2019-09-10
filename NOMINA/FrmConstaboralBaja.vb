Imports C1.Win.FlexReport
Public Class FrmConstLaboralBaja
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim cs As New ClsConsultas
    Dim msj As String
    Dim dt As New DataTable
    Dim datos As New DataTable
    Dim dtmontos As New DataTable
    Dim scr As String
    Public fila As Integer
    Public codigo As String
    'Public nombre As String
    Dim empresa = FrmInicio.CbEmpresa.SelectedValue
    Dim usuario As String = FrmInicio.nombre

    Private Sub FrmFiniquito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(a, Me.Size.Width)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
    End Sub

    Private Sub TxtNombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNombre.TextChanged
        scr = "select codigo,nombre, segundo_nombre, apellido,segundo_apellido, fec_alta, fec_baja from tb_empleado " &
                "where   nombre like  '%" & TxtNombre.Text & "%'  and codigo_empresa =1  and estado_empleado in ('B') "
        If cs.consultas(scr, dt, msj) Then
            llena_fg()
        End If
    End Sub

    Private Sub llena_fg()
        fg.Rows.Count = dt.Rows.Count + 1
        For i = 0 To dt.Rows.Count - 1
            fg(i + 1, 1) = dt.Rows(i)("codigo")
            fg(i + 1, 2) = dt.Rows(i)("nombre") & " " & dt.Rows(i)("segundo_nombre") & " " & dt.Rows(i)("apellido") & " " & dt.Rows(i)("segundo_apellido")
            fg(i + 1, 3) = dt.Rows(i)("fec_alta")
            fg(i + 1, 4) = dt.Rows(i)("fec_baja").ToString
        Next
    End Sub

    Private Sub Txt2nombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodigo.TextChanged
        scr = "select codigo,nombre, segundo_nombre, apellido,segundo_apellido, fec_alta, fec_baja from tb_empleado " &
              "where CODIGO like  '%" & TxtCodigo.Text & "%'  and codigo_empresa =1  and estado_empleado in ('B') "
        If cs.consultas(scr, dt, msj) Then
            llena_fg()
        End If
    End Sub

    Private Sub fg_Click_1(sender As System.Object, e As System.EventArgs) Handles fg.Click
        dtmontos.Clear()
        fila = fg.RowSel
        codigo = fg(fila, 1)
        Cursor = Cursors.WaitCursor
        rp.Load("C:\Plan_rep\nomina.flxr", "const_laboral_baja")
        rp.DataSource.ConnectionString = cs.con
        scr = "select a.nombre,a.segundo_nombre, a.apellido, a.segundo_apellido,a.sexo, a.dpi, c.nombre_municipio,b.descripcion,d.nombre,e.Nombre_empresa,a.fec_alta, a.Sueldo_base,f.bonificacion,e.direccion,e.telefono,e.fax,fec_baja " &
                " from TB_EMPLEADO as a, TB_PUESTOS as b , TB_MUNICIPIO as c,TB_DEPARTAMENTO as d, TB_EMPRESA as e, TB_PARAMETROS as f" &
                " where a.codigo = " & codigo &
                " and Codigo_empresa = " & empresa &
                " and a.codigo_puesto= b.codigo" &
                " and a.cod_municipio = c.codigo" &
                " and a.cod_departamento= c.cod_departamento" &
                " and a.cod_departamento = d.codigo_departamento" &
                " and a.Codigo_empresa = e.Codigo" &
                " and a.Codigo_empresa = f.cod_empresa "
        Try
            rp.DataSource.RecordSource = scr
            Dim obser As TextField = DirectCast(rp.Fields("obser"), TextField)
            obser.Text = TxtComent.Text
            Dim nomb_us As TextField = DirectCast(rp.Fields("nombreuser"), TextField)
            nomb_us.text = FrmInicio.nombre
            rp.Render()
            Fv.DocumentSource = rp
        Catch
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtCodigo_Changed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
End Class