Public Class FrmLibroSalarios
    Dim cs As New ClsConsultas
    Dim fec_inicio As Date
    Dim fec_fin As Date
    Dim strsql As String
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    'Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue
    Dim empresa As Integer = 1

    Private Sub FrmLibroSalarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(l, a)
        Me.Top = a / 2 - Me.Size.Height / 2
        Me.Left = l / 2 - Me.Size.Width / 2
    End Sub

    Private Sub BtCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCalcular.Click
        Dim anio As Integer = Format(Datanio.Value, "yyyy")
        Dim anio_1 As Integer = Format(Datanio.Value, "yyyy") + 1
        fec_inicio = anio & "-01-01"
        fec_fin = anio_1 & "-01-01"
        Dim nempresa As String = FrmInicio.CbEmpresa.Text
        Cursor = Cursors.WaitCursor
        If Txtdesde.Text = "" And Txthasta.Text = "" Then
            strsql = "select a.codigo, nombre,segundo_nombre,apellido,segundo_apellido,a.fec_nacimiento,b.*,a.sexo,a.afiliacion_igss,a.dpi,a.fec_alta, " & _
                     " a.Sueldo_base,TB_PAIS.gentilicio,TB_PUESTOS.Nombre_puesto,fec_baja,TB_BONO14.monto_BONO as bono14,TB_AGUINALDO.monto as aguinaldo,c.inicio,c.fin from TB_NOMINA as B" & _
                     " left join TB_EMPLEADO as A on a.codigo = b.codigo  AND A.CODIGO_EMPRESA =B.COD_EMPRESA " & _
                    " left join TB_CICLO_NOMINA as C on  C.FECHA BETWEEN '" & fec_inicio & "' AND '" & fec_fin & "'" & _
                    " left join TB_PAIS on a.cod_pais = TB_PAIS.codigo_pais  " & _
                    " left join TB_PUESTOS on a.codigo_puesto = TB_PUESTOS.codigo  " & _
                    " left join TB_BONO14 on TB_BONO14.cod_empleado = a.codigo and TB_BONO14.ciclo= '" & anio - 1 & "-" & anio & "' and  TB_BONO14.FEC_ALTA between c.inicio and c.fin " & _
                    " left join TB_AGUINALDO on TB_AGUINALDO.cod_empleado = a.codigo and TB_AGUINALDO.ciclo ='" & anio & "' and  TB_AGUINALDO.FEC_ALTA between c.inicio and c.fin " & _
                    " where a.codigo >= 1 And b.ANIO = C.ANIO And B.MES = C.MES And B.QUINCENA = C.QUINCENA" & _
                    " and fec_baja > '" & fec_inicio & "'" & _
                    " and Codigo_empresa =" & empresa & _
                    " order by a.codigo asc, mes asc"
        ElseIf Txtdesde.Text <> "" And Txthasta.Text <> "" Then
            strsql = "select a.codigo, nombre,segundo_nombre,apellido,segundo_apellido,a.fec_nacimiento,b.*,a.sexo,a.afiliacion_igss,a.dpi,a.fec_alta, " & _
                     " a.Sueldo_base,TB_PAIS.gentilicio,TB_PUESTOS.Nombre_puesto,fec_baja,TB_BONO14.monto_BONO as bono14,TB_AGUINALDO.monto as aguinaldo,c.inicio,c.fin from TB_NOMINA as B" & _
                     " left join TB_EMPLEADO as A on a.codigo = b.codigo  AND A.CODIGO_EMPRESA =B.COD_EMPRESA " & _
                    " left join TB_CICLO_NOMINA as C on  C.FECHA BETWEEN '" & fec_inicio & "' AND '" & fec_fin & "'" & _
                    " left join TB_PAIS on a.cod_pais = TB_PAIS.codigo_pais  " & _
                    " left join TB_PUESTOS on a.codigo_puesto = TB_PUESTOS.codigo  " & _
                    " left join TB_BONO14 on TB_BONO14.cod_empleado = a.codigo and TB_BONO14.ciclo= '" & anio - 1 & "-" & anio & "' and  TB_BONO14.FEC_ALTA between c.inicio and c.fin " & _
                    " left join TB_AGUINALDO on TB_AGUINALDO.cod_empleado = a.codigo and TB_AGUINALDO.ciclo ='" & anio - 1 & "-" & anio & "' and  TB_AGUINALDO.FEC_ALTA between c.inicio and c.fin " & _
                    " where a.codigo >= " & Txtdesde.Text & " And b.ANIO = C.ANIO And B.MES = C.MES And B.QUINCENA = C.QUINCENA" & _
                    " and a.codigo <= " & Txthasta.Text & _
                    " and fec_baja > '" & fec_inicio & "'" & _
                    " and Codigo_empresa =" & empresa & _
                    " order by a.codigo asc, mes asc"

        ElseIf Txtdesde.Text = "" And Txthasta.Text <> "" Then
            Exit Sub
        End If
        Try
            rp.Load("C:\Plan_rep\nomina.flxr", "libro_salar")
            rp.DataSource.ConnectionString = cs.con
            rp.DataSource.RecordSource = strsql
            rp.Render()
            Fv.DocumentSource = rp

        Catch EX As Exception
            MsgBox(EX.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Txtdesde_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtdesde.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txthasta_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txthasta.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub
End Class