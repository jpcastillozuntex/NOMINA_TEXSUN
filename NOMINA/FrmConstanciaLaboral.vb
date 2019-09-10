Imports C1.Win.FlexReport

Public Class FrmConstanciaLaboral
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
                "where   nombre like  '%" & TxtNombre.Text & "%'  and codigo_empresa =1  and estado_empleado in ('A','S') "
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

    Private Sub Txt2nombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles Txt2nombre.TextChanged
        scr = "select codigo,nombre, segundo_nombre, apellido,segundo_apellido, fec_alta, fec_baja from tb_empleado " &
              "where   apellido like  '%" & Txt2nombre.Text & "%'  and codigo_empresa =1  and estado_empleado in ('A','S') "
        If cs.consultas(scr, dt, msj) Then
            llena_fg()
        End If
    End Sub

    Private Sub fg_Click_1(sender As System.Object, e As System.EventArgs) Handles fg.Click
        dtmontos.Clear()
        fila = fg.RowSel
        codigo = fg(fila, 1)
        Cursor = Cursors.WaitCursor
        Dim strsql As String = " select a.nombre,a.segundo_nombre, a.apellido, a.segundo_apellido, a.dpi,b.DESCRIPCION, c.nombre_municipio,d.nombre,e.Nombre_empresa,a.fec_alta, " &
                                " Sueldo_base,a.bonificacion,e.direccion,e.telefono,e.fax from TB_EMPLEADO as a " &
                                " left join TB_PUESTOS as b  on a.CODIGO_PUESTO = b.CODIGO " &
                                " left join TB_MUNICIPIO as c on a.COD_MUNICIPIO = c.CODIGO and a.COD_DEPARTAMENTO = c.COD_DEPARTAMENTO" &
                                " left join TB_DEPARTAMENTO as d on a.COD_DEPARTAMENTO = d.CODIGO_DEPARTAMENTO" &
                                " left join TB_EMPRESA as e on a.CODIGO_EMPRESA = e.CODIGO " &
                                " where a.codigo = " & codigo & " And Codigo_empresa = " & empresa
        Try
            rp.Load("C:\Plan_rep\Nomina.flxr", "const_laboral")
            rp.DataSource.RecordSource = strsql


            Dim nomb_us As TextField = DirectCast(rp.Fields("nombreuser"), TextField)
            nomb_us.text = FrmInicio.nombre

            rp.DataSource.ConnectionString = cs.con
            rp.DataSource.RecordSource = strsql
            rp.Render()
            Fv.DocumentSource = rp

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub
End Class