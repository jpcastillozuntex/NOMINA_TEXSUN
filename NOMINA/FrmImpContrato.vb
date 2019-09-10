Public Class FrmImpContrato
    Dim cs As New ClsConsultas
    Dim cadena As String = "CODIGO"
    Dim codigo As String
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    ' Dim empresa As Integer = 1
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width

    Private Sub FrmImpContrato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Dim strsql As String = " select datediff(year,'1957-05-02',getdate())as años_patron,DATEDIFF(YEAR,fec_nacimiento,GETDATE()) AS edad, TB_EMPLEADO.nombre,tb_empleado.segundo_nombre,tb_empleado.apellido,tb_empleado.segundo_apellido, tb_empleado.bonificacion,tb_pais.nombre_pais, tb_pais.gentilicio,CASE sexo WHEN 'M' THEN 'MASCULINO'  WHEN 'F' THEN 'FEMENINO'  END AS sexo,tb_empleado.estado_civil,tb_empleado.direccion,tb_empleado.dpi," & _
     " cast(day(fec_alta) as varchar (2))+ ' de '+ DATENAME(month,fec_alta)+ ' Del ' + cast(year(fec_alta)as varchar (4)) as fec_alta,tb_empleado.Sueldo_base/30 as sueldo_base, " & _
        " cast(day('" & Format(DatFecha.Value, "yyyy-MM-dd") & "') as varchar (2))+ ' de '+ DATENAME(month,'" & Format(DatFecha.Value, "yyyy-MM-dd") & "')+ ' Del ' + cast(year('" & Format(DatFecha.Value, "yyyy-MM-dd") & "')as varchar (4)) as fec_hoy," & _
     " tb_departamento.nombre AS nombre_departamento, tb_municipio.nombre_municipio,tb_empresa.Nombre_empresa,GETDATE() as fecha, " & _
     " (select COUNT(1)from TB_EMPLEADO where estado_empleado= 'A')as trabajadores," & _
     " (select nombre_puesto from TB_PUESTOS where TB_PUESTOS.codigo = TB_EMPLEADO.codigo_puesto)as nombre_puesto" & _
     " from tb_empleado, tb_pais, tb_departamento, tb_municipio,tb_empresa where tb_pais.codigo_pais = (select cod_pais from tb_empleado where codigo=" & TxtCodigoX.Text & " and Codigo_empresa=" & empresa & ") and tb_municipio.codigo= (select cod_municipio from tb_empleado where codigo=" & TxtCodigoX.Text & " and Codigo_empresa=1)  and TB_MUNICIPIO.cod_departamento = (select cod_departamento from tb_empleado where  codigo=" & TxtCodigoX.Text & " and Codigo_empresa=1) and tb_departamento.codigo_departamento= (select cod_departamento from tb_empleado where  codigo=" & TxtCodigoX.Text & " and Codigo_empresa=1) and tb_empresa.Codigo= (select codigo_empresa from tb_empleado where codigo= " & TxtCodigoX.Text & " and Codigo_empresa=1 ) and tb_empleado.codigo= " & TxtCodigoX.Text & " and tb_empleado.Codigo_empresa=" & empresa
            Try
                Cursor = Cursors.WaitCursor
                rp.Load("C:\Plan_rep\nomina.flxr", "contrato")
                rp.DataSource.ConnectionString = cs.con
                rp.DataSource.RecordSource = strsql
                rp.Render()
                Fv.DocumentSource = rp

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