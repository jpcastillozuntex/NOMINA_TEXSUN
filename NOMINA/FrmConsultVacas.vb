Public Class FrmConsultVacas
    Dim scr As String
    Dim msj As String
    Dim dtconsulta As New DataTable
    Dim dtdetalle As New DataTable
    Dim cs As New ClsConsultas
    Dim cant As String
    Dim f As Integer
    Dim ciclo As String
    Dim codigo As Integer
    Dim empresa = FrmInicio.CbEmpresa.SelectedValue
    ' Dim empresa = 1

    Private Sub Btguardar_Click(sender As System.Object, e As System.EventArgs) Handles Btguardar.Click
        consulta()
    End Sub

    Private Sub consulta()
        limpia_fg()
        limpia_fg1()
        scr = "select TB_VACACIONES.codigo,cod_empresa,fecha_inic,fecha_calc,saldo,ciclo,estado,tb_empleado.nombre,segundo_nombre,apellido,fec_alta,c.NOMBRE as depart1 from tb_vacaciones " & _
                " LEFT JOIN TB_EMPLEADO ON TB_EMPLEADO.codigo = TB_VACACIONES.codigo AND TB_EMPLEADO.Codigo_empresa = TB_VACACIONES.cod_empresa " & _
                " left join TB_DEPTOS_EMPRESA as c on TB_EMPLEADO.COD_DEPART = c.COD_DEPAR" & _
                " where tb_vacaciones.codigo = " & TxtCodigo.Text & " and cod_empresa = " & empresa & " and estado = 'N' "
        Try
            If cs.consultas(scr, dtconsulta, msj) Then
                fg1.Rows.Count = dtconsulta.Rows.Count + 1
                For i = 0 To dtconsulta.Rows.Count - 1
                    scr = "select count(1) from tb_vacac where codigo = " & TxtCodigo.Text & " and ciclo = " & dtconsulta.Rows(i)("ciclo")
                    If cs.csescalar(cant, scr, msj) Then
                        fg(i + 1, 1) = dtconsulta.Rows(i)("codigo")
                        fg(i + 1, 2) = dtconsulta.Rows(i)("fecha_inic")
                        fg(i + 1, 3) = dtconsulta.Rows(i)("fecha_calc")
                        If dtconsulta.Rows(i)("saldo") = 15 Then
                            fg.SetCellStyle(i + 1, 4, "FirstCustomStyle")
                        End If
                        fg(i + 1, 4) = dtconsulta.Rows(i)("saldo")
                        fg(i + 1, 5) = cant
                        fg(i + 1, 6) = dtconsulta.Rows(i)("saldo") - cant
                        fg(i + 1, 7) = dtconsulta.Rows(i)("ciclo")
                        Lbnombre.Text = dtconsulta.Rows(i)("nombre") & " " & dtconsulta.Rows(i)("segundo_nombre") & " " & dtconsulta.Rows(i)("apellido")
                        Lbseccion.Text = dtconsulta.Rows(i)("depart1")
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub limpia_fg()
        For i = 1 To fg.Rows.Count - 1
            For j = 1 To 7
                fg.SetCellStyle(i, j, "defualt")
                fg(i, j) = Nothing
                Lbnombre.Text = ""
                Lbseccion.Text = ""
            Next
        Next
    End Sub

    Private Sub TxtCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCodigo.TextChanged, TxtCodigo.KeyPress
        consulta()
    End Sub

    Private Sub limpia_fg1()
        For j = 1 To fg1.Rows.Count - 1
            fg1(j, 1) = Nothing
            fg1(j, 2) = Nothing
            fg1(j, 3) = Nothing
            fg1(j, 4) = Nothing
        Next
    End Sub

    Private Sub C1FlexGrid1_Click(sender As System.Object, e As System.EventArgs) Handles fg.DoubleClick
        limpia_fg1()
        f = fg.RowSel
        ciclo = fg(f, 7)
        codigo = fg(f, 1)
        scr = "select * from tb_vacac where codigo = " & codigo & " and ciclo = " & ciclo
        If cs.consultas(scr, dtdetalle, msj) Then
            fg1.Rows.Count = dtdetalle.Rows.Count + 1
            For i = 0 To dtdetalle.Rows.Count - 1
                fg1(i + 1, 1) = i
                fg1(i + 1, 2) = dtdetalle.Rows(i)("fecha")
                fg1(i + 1, 3) = dtdetalle.Rows(i)("ciclo")
                fg1(i + 1, 4) = dtdetalle.Rows(i)("monto")
            Next
        End If
    End Sub

    Private Sub FrmConsultVacas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub


End Class