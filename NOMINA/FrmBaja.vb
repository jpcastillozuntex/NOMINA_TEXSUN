Public Class FrmBaja
    Dim cs As New ClsConsultas
    Dim msj As String
    Dim dt As New DataTable
    Dim datos As New DataTable
    Dim scr As String
    Public fila As Integer
    Public codigo As String
    Public nombre As String
    Dim f As String = "yyyy-MM-dd"
    Dim f2 As String = "dd-MMM-yyyy"
    Dim dtliquid As New DataTable
    'Dim empresa = 1
    Dim resulta As MsgBoxResult
    Dim empresa = FrmInicio.CbEmpresa.SelectedValue
    Dim anio As Integer
    Dim anioantes As Integer
    Dim fecha As Date

    Private Sub FrmBaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Grpbaja.Enabled = False
        fg.Rows.Count = 1
    End Sub

    Private Sub fg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fg.Click
        limpia()
        fila = fg.RowSel
        If fila > 0 Then
            Try
                Grpbaja.Enabled = True
                Cbtipo.Visible = True
                DatFecha.Visible = True
                codigo = fg(fila, 1)
                nombre = FrmInicio.CbEmpresa.Text
                Cbtipo.SelectedIndex = 0
                BtCalcular.Visible = True
                TextBox1.Text = fg(fila, 2)
                TxtCodigo.Text = fg(fila, 1)
            Catch
            End Try
            Try
                scr = "select codigo,nombre, segundo_nombre, apellido, segundo_apellido, codigo_puesto, fec_alta, fec_baja from tb_empleado where codigo = " & codigo & " and codigo_empresa = " & empresa
                If cs.consultas(scr, datos, msj) Then
                    scr = "SELECT * FROM TB_LIQUIDACION WHERE cod_empleado = " & codigo & " and cod_empresa = " & empresa
                    If cs.consultas(scr, dtliquid, msj) Then
                        BtImprimir.Visible = True
                        BtCalcular.Visible = False
                        muestra_totales()
                    Else
                        Label1.Visible = False
                        Label2.Visible = False
                        BtImprimir.Visible = False
                    End If
                End If
            Catch ex As Exception
                MsgBox(msj)
            End Try
        End If
    End Sub

    Private Sub BtCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCalcular.Click
        DatFecha.Visible = False
        BtCalcular.Visible = False
        Cbtipo.Visible = False
        Dim scr_insert As String
        Dim scr_aguin As String
        Dim scr_bono As String
        Dim scr_vacas As String
        Dim scr_anticpo As String
        Dim scr_update As String
        Dim scr_indemni As String
        Dim scr_mates As String
        Dim ind As String = "N"
        If Cbtipo.SelectedItem = "" Then
            MsgBox("FAVOR SELECCIONAR MOTIVO")
        Else
            resulta = MsgBox("ESTA SEGURO DE DARLE DE BAJA", MsgBoxStyle.YesNo, "BAJA")
            If resulta = MsgBoxResult.Yes Then
                Try
                    anio = Format(DatFecha.Value, "yyyy")
                    anioantes = anio - 1
                    fecha = DatFecha.Value
                    scr_insert = "INSERT INTO TB_LIQUIDACION (COD_EMPLEADO,COD_EMPRESA,FEC_LIQUIDACION,MOTIVO)VALUES (" & codigo & "," & empresa & ",'" & Format(DatFecha.Value, f) & "','" & Cbtipo.SelectedItem & "')"
                    scr_vacas = "EXECUTE VACAS_BAJA @fecha = '" & Format(DatFecha.Value, f) & "', @empresa = " & empresa & ", @cod_emp =" & codigo
                    scr_aguin = "EXECUTE AGUINALDO_BAJA @FECHA ='" & Format(DatFecha.Value, f) & "',@EMPRESA = " & empresa & " , @COD_EMP = " & codigo
                    scr_bono = "EXECUTE BONO14_BAJA @fecha = '" & Format(DatFecha.Value, f) & "', @empresa = " & empresa & ", @cod_emp =" & codigo
                    scr_anticpo = "EXECUTE ANTICIPOS_BAJA @fecha = '" & Format(DatFecha.Value, f) & "', @empresa = " & empresa & ", @codigo =" & codigo
                    scr_mates = "EXECUTE MATERIALES_BAJA @fecha = '" & Format(DatFecha.Value, f) & "', @empresa = " & empresa & ", @codigo =" & codigo
                    scr_update = "UPDATE TB_EMPLEADO SET FEC_BAJA = '" & Format(DatFecha.Value, f) & "',estado_empleado = 'B' WHERE CODIGO_EMPRESA = " & empresa & "AND CODIGO = " & codigo
                    scr_indemni = "INDEMNIZACION @fecha = '" & CDate(Format(DatFecha.Value, f)) & "', @empresa = " & empresa & ", @cod_emp =" & codigo
                    If Cbtipo.SelectedItem = "DESPIDO" Then
                        ind = "S"
                    End If
                    If Cbtipo.SelectedItem = "REORGANIZACION" Then
                        ind = "S"
                    End If
                    If cs.baja(scr_insert, scr_vacas, scr_aguin, scr_bono, scr_anticpo, scr_indemni, scr_update, scr_mates, ind, msj) Then
                        muestra_totales()
                        llena_fg()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Me.Close()
                End Try
            ElseIf resulta = DialogResult.No Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub limpia()
        Txtalta.Text = ""
        TxtBaja.Text = ""
        TxtCodigo.Text = ""
        TextBox1.Text = ""
        TxtPuesto.Text = ""
        TxtAguinaldo.Text = ""
        Txtvacaciones.Text = ""
        Txtindemnizacion.Text = ""
        TxtBono.Text = ""
        TxtMotivo.Text = ""
        TxtMateriales.Text = ""
    End Sub

    Private Sub muestra_totales()
        Try
            scr = "select codigo,nombre, segundo_nombre, apellido, segundo_apellido, codigo_puesto, fec_alta, fec_baja from tb_empleado where codigo = " & codigo & " and codigo_empresa = " & empresa
            If cs.consultas(scr, datos, msj) Then
                scr = "SELECT * FROM TB_LIQUIDACION WHERE cod_empleado = " & codigo & " and cod_empresa = " & empresa
                If cs.consultas(scr, dtliquid, msj) = True Then
                    Cbtipo.Visible = False
                    DatFecha.Visible = False
                    BtCalcular.Visible = False
                    BtImprimir.Visible = True
                    Txtalta.Text = Format(datos.Rows(0)("fec_alta"), f2).ToString
                    TxtBaja.Text = Format(datos.Rows(0)("fec_baja"), f2).ToString
                    TxtCodigo.Text = Format(datos.Rows(0)("codigo"), "0000").ToString
                    TextBox1.Text = datos.Rows(0)("nombre") & " " & datos.Rows(0)("apellido") & " " & datos.Rows(0)("segundo_apellido").ToString
                    TxtPuesto.Text = datos.Rows(0)("codigo_puesto").ToString
                    TxtAguinaldo.Text = dtliquid.Rows(0)("mto_aguinaldo").ToString
                    Txtvacaciones.Text = dtliquid.Rows(0)("mto_vacaciones").ToString
                    Txtindemnizacion.Text = dtliquid.Rows(0)("mto_indemnizacion").ToString
                    TxtBono.Text = dtliquid.Rows(0)("mto_bono14").ToString
                    TxtMotivo.Text = dtliquid.Rows(0)("motivo").ToString
                    TxtMateriales.Text = dtliquid.Rows(0)("MATERIALES").ToString
                Else
                    MsgBox(msj)
                End If
            End If
        Catch ex As Exception
            MsgBox(msj)
        End Try
    End Sub

    Private Sub TxtNombre_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNombre.TextChanged
        scr = "select codigo,nombre, segundo_nombre, apellido,segundo_apellido, fec_alta, fec_baja from tb_empleado " & _
                "where   nombre like  '%" & TxtNombre.Text & "%'  and codigo_empresa =" & empresa & "  and estado_empleado in ('A','S','B') "
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
        scr = "select codigo,nombre, segundo_nombre, apellido,segundo_apellido, fec_alta, fec_baja from tb_empleado " & _
              "where   apellido like  '%" & Txt2nombre.Text & "%'  and codigo_empresa =" & empresa & "  and estado_empleado in ('A','S','B') "
        If cs.consultas(scr, dt, msj) Then
            llena_fg()
        End If
    End Sub

    Private Sub TxCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxCodigo.TextChanged
        scr = "select codigo,nombre, segundo_nombre, apellido,segundo_apellido, fec_alta, fec_baja from tb_empleado " & _
              "where   codigo like  '%" & TxCodigo.Text & "%'  and codigo_empresa =" & empresa & "  and estado_empleado in ('A','S','B') "
        If cs.consultas(scr, dt, msj) Then
            llena_fg()
        End If
    End Sub

    Private Sub txtcodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxCodigo.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtImprimir.Click
        Dim dtmontos As New DataTable
        Dim monto As Double
        Cursor = Cursors.WaitCursor
        Dim strsql As String = " SELECT A.*,B.NOMBRE,B.SEGUNDO_NOMBRE,B.APELLIDO,B.SEGUNDO_APELLIDO,FEC_ALTA,FEC_BAJA,C.NOMBRE_PUESTO,(MTO_AGUINALDO+MTO_BONO14+MTO_INDEMNIZACION+MTO_VACACIONES-MTO_ANTICIPOS-MATERIALES)AS MONTO FROM TB_LIQUIDACION AS A" & _
                                " LEFT JOIN TB_EMPLEADO AS B ON A.COD_EMPLEADO = B.CODIGO" & _
                                " LEFT JOIN TB_PUESTOS AS C ON C.CODIGO = B.CODIGO_PUESTO " & _
                                " WHERE A.COD_EMPLEADO = " & codigo & " And A.COD_EMPRESA = " & empresa
        If cs.consultas(strsql, dtmontos, msj) Then
            monto = dtmontos.Rows(0)("monto")
        End If
        Dim canti As String = cs.Cambio(monto)
        If dtmontos.Rows(0)("motivo") = "DESPIDO" Then
            Try
                Cursor = Cursors.WaitCursor
                rp.Load("C:\Plan_rep\nomina.flxr", "liquidacion_desp")
                rp.DataSource.ConnectionString = cs.con
                ''rp.Fields("nombre").Text = nombre
                'rp.Fields("cantiletras").Text = canti
                rp.DataSource.RecordSource = strsql
                rp.Render()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Cursor = Cursors.Default
            End Try
            Try
                Dim filter As New C1.Win.C1Document.Export.PdfFilter()
                filter.ShowOptions = False
                filter.FileName = "C:\Plan_rep\" + "liquidacion_" & codigo & ".pdf"
                rp.RenderToFilter(filter)
                ''rp.RenderToFile("C:\Plan_rep\" + "liquidacion_" & codigo & ".pdf", C1.C1Report.FileFormatEnum.PDF)
                Dim pathPDF As String = "C:\Plan_rep\liquidacion_" & codigo & ".pdf"
                Process.Start(pathPDF)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                Cursor = Cursors.WaitCursor
                rp.Load("C:\Plan_rep\nomina.flxr", "liquidacion")
                rp.DataSource.ConnectionString = cs.con
                '' rp.Fields("nombre").Text = nombre
                ' rp.Fields("cantiletras").Text = canti
                rp.DataSource.RecordSource = strsql
                rp.Render()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Cursor = Cursors.Default
            End Try
            Try
                Dim filter As New C1.Win.C1Document.Export.PdfFilter()
                filter.ShowOptions = False
                filter.FileName = "C:\Plan_rep\" + "liquidacion_" & codigo & ".pdf"
                rp.RenderToFilter(filter)
                ' rp.RenderToFile("C:\Plan_rep\" + "liquidacion_" & codigo & ".pdf", C1.C1Report.FileFormatEnum.PDF)
                Dim pathPDF As String = "C:\Plan_rep\liquidacion_" & codigo & ".pdf"
                Process.Start(pathPDF)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Grpbaja_Enter(sender As System.Object, e As System.EventArgs) Handles Grpbaja.Enter

    End Sub
End Class