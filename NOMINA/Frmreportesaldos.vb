Public Class Frmreportesaldos
    Dim cs As New ClsConsultas
    Dim empresa = FrmInicio.CbEmpresa.SelectedValue
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width

    Private Sub Frmreportesaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(1080, a - 10)
        Me.Top = a / 2 - ((a - 10) / 2)
        Me.Left = l / 2 - (1080 / 2)
        Carga(empresa)
    End Sub

    Private Sub Carga(ByVal empresa As String)
        Dim nempresa As String = FrmInicio.CbEmpresa.Text
        Cursor = Cursors.WaitCursor
        Dim strsql As String = "SET CONCAT_NULL_YIELDS_NULL off" &
                                " select (c.nombre + ' ' + c.segundo_nombre +' '+ c.apellido) as nombre,a.num_anticipo,'" & nempresa & "' as empresa, a.fec_anticipo,a.cod_empleado,a.total_anticipo,a.num_cuotas,b.estado,b.monto_cuota, sum(monto_cuota) as saldo,(select count(1) from TB_DET_ANTICIPO where num_anticipo = a.num_anticipo and estado = 'p')as cuotas_p" &
                                " from TB_ANTICIPO as a, tb_det_anticipo as b, tb_empleado as c" &
                                " where a.num_anticipo = b.num_anticipo" &
                                " and b.estado = 'p'" &
                                " and c.codigo = a.cod_empleado" &
                                " and a.cod_empresa = " & empresa &
                                " and a.cod_empresa = c.Codigo_empresa " &
                                " group by a.cod_empleado,a.num_anticipo, c.nombre,a.fec_anticipo,total_anticipo, num_cuotas,estado,monto_cuota,segundo_nombre,apellido"
        Try
            Cursor = Cursors.WaitCursor
            fr.Load("C:\Plan_rep\nomina.flxr", "saldo_anticipos")
            fr.DataSource.ConnectionString = cs.con
            'rp.Fields("empresa").Text = nempresa
            fr.DataSource.RecordSource = strsql
            fr.Render()
            Fv.DocumentSource = fr

        Catch

        End Try
        Cursor = Cursors.Default
    End Sub

End Class