Public Class FrmEmbargo
    Dim cs As New ClsConsultas
    Dim dt As New DataTable
    Dim dtt As New DataTable
    Dim mensaje As String
    Dim y As String = "yyyy-MM-dd"
    Dim fec As Date
    'Dim empresa As Integer = 1
    Dim scr As String
    Dim msj As String
    Dim dt_cod As New DataTable
    Dim dtMes As New DataTable
    Dim anio As Integer
    Dim mes As Integer
    Dim ciclo As Integer
    Dim estado As String
    Dim cont As Integer
    Dim a As Integer = Screen.PrimaryScreen.WorkingArea.Height
    Dim l As Integer = Screen.PrimaryScreen.WorkingArea.Width
    Dim empresa As Integer = FrmInicio.CbEmpresa.SelectedValue


    Private Sub Frmnuevoanticipo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = a / 2 - (537 / 2)
        Me.Left = l / 2 - (752 / 2)
        crea_dt()
        Combo_box_Mes()
        BtBuscar.Visible = True
        BtREgresar.Visible = False
        BtGuardar.Visible = False
        CbCiclo.SelectedIndex = 0
        DatAnio.MinDate = Today.AddDays(1)
    End Sub

    Private Sub crea_dt()
        dt.Columns.Add("empresa")
        dt.Columns.Add("codigo")
        dt.Columns.Add("monto")
        dt.Columns.Add("fecha")
        dt.Columns.Add("primer")
        dt.Columns.Add("cuotas")
        dt.Columns.Add("docu")
        dt.Columns.Add("coment")
        dt.AcceptChanges()

        dtt.Columns.Add("num_anticipo")
        dtt.Columns.Add("num_cuota")
        dtt.Columns.Add("monto")
        dtt.Columns.Add("anio")
        dtt.Columns.Add("mes")
        dtt.Columns.Add("quincena")
        dtt.Columns.Add("estado")
        dtt.AcceptChanges()
    End Sub

    Private Sub Combo_box_Mes()
        Dim mes As Integer
        mes = Date.Now.Month
        scr = "SELECT MES, NUMERO FROM MES"
        cs.consultas(scr, dtMes, msj)
        Cbmes.DataSource = dtMes
        Cbmes.SelectedIndex = mes - 1
        Cbmes.DisplayMember = "MES"
        Cbmes.ValueMember = "NUMERO"
    End Sub

    Private Sub BtGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtGuardar.Click
        dtt.Clear()
        dt.Clear()
        anio = Format(DatAnio.Value, "yyyy")
        mes = Cbmes.SelectedValue
        ciclo = CbCiclo.Text
        If TxtCodigo.Text = Nothing Or TxtMonto.Text = Nothing Or TxtCuotas.Text = Nothing Or TxtDocu.Text = Nothing Then
            mensajes.Text = "FALTAN DATOS..!!"
        Else
            scr = "SELECT ESTADO FROM TB_CICLO_NOMINA WHERE ANIO = " & anio & " AND MES = " & Cbmes.SelectedValue & " AND QUINCENA = " & CbCiclo.Text
            If cs.csescalar(estado, scr, msj) Then
                If estado = "C" Then
                    mensajes.Text = "NO SE PUEDE DESCONTAR EN UN CICLO PASADO"
                Else
                    Dim cuotas As Integer = TxtCuotas.Text
                    fec = Datfecha.Value
                    Dim dtr As DataRow = dt.NewRow
                    dtr("empresa") = empresa
                    dtr("codigo") = TxtCodigo.Text
                    dtr("monto") = TxtMonto.Text
                    dtr("fecha") = Format(fec, y)
                    dtr("cuotas") = cuotas
                    dtr("docu") = TxtDocu.Text
                    dtr("coment") = TxtComent.Text
                    dt.Rows.Add(dtr)
                    dt.AcceptChanges()
                    cont = TxtCuotas.Text
                    For i = 0 To dt.Rows(0)("cuotas") - 1
                        cont = cont + 1
                        Dim dtd As DataRow = dtt.NewRow
                        dtd("num_cuota") = i + 1
                        dtd("monto") = TxtMonto.Text / cuotas
                        dtd("anio") = anio
                        dtd("mes") = mes
                        dtd("quincena") = ciclo
                        dtd("estado") = "P"
                        dtt.Rows.Add(dtd)
                        dtt.AcceptChanges()
                        If ciclo = 1 Then
                            ciclo = 2
                        ElseIf ciclo = 2 Then
                            ciclo = 1
                        End If
                        If ciclo = 1 Then
                            mes = mes + 1
                        End If
                        If mes > 12 Then
                            mes = 1
                        End If
                        If mes = 1 And ciclo = 1 Then
                            anio = anio + 1
                        End If
                    Next
                    If cs.anticipo(dt, dtt, mensaje) = True Then
                        MsgBox("DATOS GUARDADOS")
                        limpia()
                    Else
                        MsgBox(mensaje)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TxtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            dt_cod.Clear()
            scr = "select nombre,segundo_nombre, apellido,segundo_apellido, nombre_puesto  from tb_empleado as a left join tb_puestos as b on a.codigo_puesto = b.codigo where a.codigo = '" & TxtCodigo.Text & "' and codigo_empresa = " & empresa & " AND ESTADO_EMPLEADO IN ('A','S')"
            If cs.consultas(scr, dt_cod, msj) Then
                TxtMonto.Focus()
                LbNombre.Text = dt_cod.Rows(0)("NOMBRE") & " " & dt_cod.Rows(0)("SEGUNDO_NOMBRE") & " " & dt_cod.Rows(0)("APELLIDO") & " " & dt_cod.Rows(0)("SEGUNDO_APELLIDO")
                LbPuesto.Text = dt_cod.Rows(0)("NOMBRE_PUESTO")
                TxtCodigo.Enabled = False
                BtBuscar.Visible = False
                BtREgresar.Visible = True
                BtGuardar.Visible = True
            Else
                mensajes.Text = "EMPLEADO NO EXISTE O ESTA DE BAJA!!"
                LbNombre.Text = ""
                LbPuesto.Text = ""
            End If
        End If
    End Sub

    Private Sub BtREgresar_Click(sender As System.Object, e As System.EventArgs) Handles BtREgresar.Click
        TxtCodigo.Enabled = True
        BtREgresar.Visible = False
        BtBuscar.Visible = True
        BtGuardar.Visible = False
    End Sub

    Private Sub limpia()
        LbNombre.Text = ""
        LbPuesto.Text = ""
        BtBuscar.Visible = True
        BtREgresar.Visible = False
        BtGuardar.Visible = False
        CbCiclo.SelectedIndex = 0
        TxtCodigo.Enabled = True
        TxtCodigo.Text = Nothing
        TxtMonto.Text = Nothing
        TxtCuotas.Text = Nothing
        TxtDocu.Text = Nothing
        TxtComent.Text = Nothing
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuotas.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtCodigo_Changed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCodigo.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub Txtmonto_Changed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonto.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack And e.KeyChar <> (".") Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMonto.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Datfecha.Focus()
        End If
    End Sub

    Private Sub Datfecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Datfecha.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtCuotas.Focus()
        End If
    End Sub

    Private Sub TxtCuotas_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCuotas.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            DatAnio.Focus()
        End If
    End Sub

    Private Sub DatAnio_changeValue(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DatAnio.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            Cbmes.Focus()
        End If
    End Sub

    Private Sub Cbmes_change_selected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cbmes.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            CbCiclo.Focus()
        End If
    End Sub

    Private Sub Cbciclo_change(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbCiclo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtDocu.Focus()
        End If
    End Sub

    Private Sub TxtDocu_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDocu.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            TxtComent.Focus()
        End If
    End Sub


End Class